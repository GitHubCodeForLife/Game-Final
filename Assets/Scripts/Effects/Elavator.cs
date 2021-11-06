using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elavator : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public float speed = 2f;

    public bool isForward = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log("top: " + p_top.position.y + "current:  " + pos.y);
        if(p1.position.y == p2.position.y)
        {
            //Dy chuyen ngang
            MoveHorizontal();
        }
        else if(p1.position.x ==p2.position.x)
        {
            //Dy chuyen doc
            MoveVertical();
        }
       
    }
    void MoveVertical()
    {
        Vector3 pos = transform.position;
        if (isForward)
        {
            pos.y += speed * Time.deltaTime;
        }
        else
        {
            pos.y -= speed * Time.deltaTime;
        }

        if (pos.y >= p2.position.y)

            isForward = false;

        if (pos.y <= p1.position.y) isForward = true;

        transform.position = pos;
    }
    void MoveHorizontal()
    {
        Vector3 pos = transform.position;
        if (isForward)
        {
            pos.x += speed * Time.deltaTime;
        }
        else
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (pos.x >= p2.position.x)

            isForward = false;

        if (pos.x <= p1.position.x) 
            
            isForward = true;

        transform.position = pos;
    }
}
