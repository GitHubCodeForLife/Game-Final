using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    int direction = 1;
    public GameObject impactEffect;
    public int damage = 20;

   // public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //  rigidbody.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime* direction;
    }
 
    public void SetDirection(int direction)
    {
        this.direction = direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        //Debug.Log(collision.name);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        if (collision.CompareTag("Enemies"))
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}

