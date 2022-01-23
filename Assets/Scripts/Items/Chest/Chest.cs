using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chest : MonoBehaviour
{
    Animator animator;
    private bool IsOpen = false;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenChest()
    {
        if (IsOpen) return;
        IsOpen = true;
        animator.SetTrigger("Open");
        SpawnTreasure();
        //Destroy(gameObject, 2f);
    }
    public abstract void SpawnTreasure();
}
