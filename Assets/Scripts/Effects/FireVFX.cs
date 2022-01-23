using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireVFX : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public int Damage = 50;
    private const float damgeMaxTime = 0.1f;
    public float fireTime = 10f;
    private float currentFireTime;
    private float damgeTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        damgeTime = damgeMaxTime;
        currentFireTime = fireTime;
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (currentFireTime <= 0)
        {
          //  animator.SetTrigger("FireDown");
            Destroy(gameObject, 2f);
            damgeTime = 3f;
        }
        else
            currentFireTime -= Time.deltaTime;
        if (damgeTime > 0)
            damgeTime -= Time.deltaTime;
    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collision VFX");
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
}
