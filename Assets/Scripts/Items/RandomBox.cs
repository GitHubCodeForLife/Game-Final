using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    float[] rates = {10,20,20,30,20};
    //0 : Gun 1 tia
    //1 : Gun 2 tia
    //2 : Gun 3 tia
    //3 : Loai dan 
    //4 : Bat tu

    public GameObject effectPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           int index = (int) GameRandom.Choose(rates);
            Debug.Log("Random Box : " + index.ToString());
            PlayerAttack playerAttack = FindObjectOfType<PlayerAttack>();
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            switch (index)
            {
                case 0:
                    // code block
                    playerAttack.ChangeGun("Gun");
                    break;
                case 1:
                    // code block
                    playerAttack.ChangeGun("TwoGun");
                    break;
                case 2:
                    // code block
                    playerAttack.ChangeGun("ThreeGun");
                    break;
                case 3:
                    // code block
                    playerAttack.ChangeBullet();
                    break;
                case 4:
                    // code block
                    playerHealth.SetDeathLessTimer(5);
                    break;
                default:
                    // code block
                    break;
            }
       
     
            //playerAttack.ChangeBullet();
            //playerHealth.SetDeathLessTimer(5);
            if (effectPrefab != null)
            {
                GameObject collectedObject = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(collectedObject, 1.5f);
            }
            Destroy(gameObject);
        }
    }
}
