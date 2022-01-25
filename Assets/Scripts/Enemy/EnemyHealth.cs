using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public bool isDie= false;

    public Transform damagePoint;

    //RandomTime
    private float randomAttackTime = 2f;
    private float currentRandomAttackTime = 0f;
    private Vector3 pastPos;
    [Header("Level Enemies")]
    public int level=0;

    private void Awake()
    {
        currentRandomAttackTime = 0f;
        animator = gameObject.GetComponent<Animator>();
    }
   
   
    internal void TakeCritDamage(object p)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        isDie = false;
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.value = (currentHealth * 100 / maxHealth);
    }
    private void Update()
    {
        if (currentRandomAttackTime <= 0 && level > 0)
        {
            if (RandomAttack())
            {
                //AnimatorStateInfo index =  animator.GetCurrentAnimatorStateInfo(0);
                PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
                if (playerHealth == null) return;
                bool IsRight = playerHealth.transform.position.x > transform.position.x;
                pastPos = transform.localScale;
                if (IsRight)
                    transform.localScale = new Vector3(1, 1, 1);
                else transform.localScale = new Vector3(-1, 1, 1);
                Debug.Log("Attack Player");
                animator.SetTrigger("Attack");
                StartCoroutine(WaitPlayerDie(2f));
            }
            currentRandomAttackTime = randomAttackTime;
        }
        else
            currentRandomAttackTime -= Time.deltaTime;
    }
    private IEnumerator WaitPlayerDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.localScale = pastPos;
    }


    private bool RandomAttack()
    {
        if (currentHealth < maxHealth/2 || level >=2)
        {
            float[] rate = { 50, 50 };
            float result = GameRandom.Choose(rate);
            return result == 0 ? false : true;
        }
        
        return false;
    }

    private void TakeDamage(int damage)
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt");
            //AudioManager.instance.Play("Player_Hurt");
        }
        currentHealth -= damage;
        if (healthBar != null)
            healthBar.value = (currentHealth * 100 / maxHealth);
        if (currentHealth <= 0 && isDie == false)
        {
            isDie = true;
            Die();
        }
    }

    public void TakeNormalDamage(int damage)
    {
       ShowUIDamage(damage);
       TakeDamage(damage);
    }
    public void TakeCritDamage(int damage)
    {
      
        ShowUICritDamage(damage);
        TakeDamage(damage);
    }


    private void ShowUIDamage(int damage)
    {
        //Show damge UI
        float index = Random.Range(1, 100);
        float range = (float)(index * 0.01);
        if (damagePoint != null)
            SpawnEffect.instance.SpawnDamageEffect(damagePoint.position + new Vector3(range, 0), Quaternion.identity, damage);
    }
    private void ShowUICritDamage(int damage)
    {
        //Show damge UI
        float index = Random.Range(1, 100);
        float range = (float)(index * 0.01);
        if (damagePoint != null)
            SpawnEffect.instance.SpawnDamageCritEffect(damagePoint.position + new Vector3(range, 0), Quaternion.identity, damage);
    }


    public void Die()
    {
        animator.SetTrigger("Death");

        CapsuleCollider2D capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if (capsuleCollider2D != null && rigidbody2D !=null)
        {
            rigidbody2D.gravityScale = 0f;
            capsuleCollider2D.enabled = false;
        }
        SpawnEffect.instance.SpawnItem(transform.position);
        isDie = true;
        Destroy(gameObject, 2f);
        Gamelogic gamelogic = FindObjectOfType<Gamelogic>();
        if (gamelogic != null)
            gamelogic.KillNewEnemy(gameObject);
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
    //        Debug.Log("Enemy Health 1: " + rigidbody.name);
    //        if (rigidbody != null)
    //        {
    //            int direction = transform.rotation.y == 0 ? 1 : -1;
    //            rigidbody.AddForce(new Vector2(5*direction, 5), ForceMode2D.Impulse);
    //        }
    //        collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
    //        Debug.Log("Enemy Health 2: " + rigidbody.name);
    //        if (rigidbody != null)
    //        {
    //            int direction = transform.rotation.y == 0 ? 1 : -1;
    //            rigidbody.AddForce(new Vector2(5 * direction, 5), ForceMode2D.Impulse);
    //        }
    //        collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
    //    }
    //}
}
