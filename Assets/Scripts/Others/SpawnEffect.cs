using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    public GameObject coinGameObject;
    public GameObject damageEffect;
    public GameObject damageCritEffect;
    public GameObject waterBall;
    public List<GameObject> items;
    public float[] rates;
    // private float[] numbers = { 10, 70, 15, 5 };
    public float[] chestRates = { 5, 70, 10, 15,5 };
    public static float[] blackChestRates = { 5, 70, 10, 15, 5 };
    public static SpawnEffect instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    public void SpawnTreasures(Vector2 pos, float[] rates, int number)
    {

        for (int i = 0; i < number; i++)
        {

            int total = (int)GameRandom.Choose(rates);
            Instantiate(items[total], pos, Quaternion.identity);
            pos.x += UnityEngine.Random.Range(-0.5f, 0.5f);
            pos.y += UnityEngine.Random.Range(0, 0.5f);
        }
    }

    public void SpawnItem(Vector2 pos, float[] yourRates = null)
    {

        if (yourRates == null) yourRates = rates;
        int number = (int)GameRandom.Choose(yourRates);
        for (int i = 0; i < number; i++)
        {
            int total = (int)GameRandom.Choose(yourRates);
            Instantiate(items[total], pos, Quaternion.identity);
        }
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

    public GameObject SpawnWaterBall(Vector3 position, Bounds bounds)
    {
        GameObject waterObject = Instantiate(waterBall, position, Quaternion.identity);
        SpriteRenderer sr = waterObject.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Debug.Log("Bound size: " + bounds.size);
            // sr.size = bounds.size;
            float x = bounds.size.x;
            float y = bounds.size.y;
            float max = x > y ? x : y;
            max = max / 3f;
            sr.transform.localScale = new Vector2(max, max);
        }
        return waterObject;
    }
}
