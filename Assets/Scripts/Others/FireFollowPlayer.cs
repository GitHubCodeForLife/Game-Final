using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFollowPlayer : MonoBehaviour
{
    private Transform target;
    public float height;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindObjectOfType<PlayerMovement>().transform;

        if (target == null) return;
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y+ height;
        transform.position = pos;
    }
}
