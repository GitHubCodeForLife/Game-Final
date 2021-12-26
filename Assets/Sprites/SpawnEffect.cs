using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    public GameObject coinGameObject;
    public GameObject damageEffect;
    public GameObject damageCritEffect;
    public GameObject SpawnCoin(Vector2 pos, Quaternion qua)
    {
        return GameObject.Instantiate(coinGameObject, pos, qua);
    }
    public GameObject SpawnDamageEffect(Vector2 pos, Quaternion qua, int damage)
    {
        GameObject damageObject = GameObject.Instantiate(damageEffect, pos, qua);
        damageObject.GetComponent<DamgeUI>().SetDamage(damage);
        return damageObject;
    }
    public GameObject SpawnDamageCritEffect(Vector2 pos, Quaternion qua, int damage)
    {
        GameObject damageObject = GameObject.Instantiate(damageCritEffect, pos, qua);
        damageObject.GetComponent<DamgeUI>().SetDamage(damage);
        return damageObject;
    }

}
