using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArround : MonoBehaviour
{
    public bool isUp = false;
    [SerializeField]
    private float speed = 10;

    public float timeMove = 2;
    private float currentTimeMove;

    public bool IsX = false;
    private void Awake()
    {
        currentTimeMove = timeMove;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentTimeMove > 0)
            currentTimeMove -= Time.deltaTime;
        else
        {
            currentTimeMove = timeMove;
            isUp = !isUp;
        }

        MoveAxis();
    }

    private void MoveAxis()
    {
        Vector3 pos = transform.position;
        if (IsX == true)
        {

            if (isUp)
                pos.x += Time.deltaTime * speed;
            else
                pos.x -= Time.deltaTime * speed;
        }
        else
        {
            if (isUp)
                pos.y += Time.deltaTime * speed;
            else
                pos.y -= Time.deltaTime * speed;
        }
        transform.position = pos;

    }
}
