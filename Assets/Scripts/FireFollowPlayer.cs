using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFollowPlayer : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y+0.75f;
        transform.position = pos;
    }
}
