using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy
{
    [Header("Archer Enemy")]
    public GameObject gamePrefabs;
    public Transform attackPoint;
    public float arrowSpeed;
    protected override void DamagePlayer()
    {
        //Debug.Log("Archer Emeny: Throw Arrow");
        GameObject arrow = Instantiate(gamePrefabs, attackPoint.position, attackPoint.rotation);
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed * transform.localScale.x, 0);
        arrow.transform.localScale = new Vector3(transform.localScale.x, 1, 1);
    } 
}
