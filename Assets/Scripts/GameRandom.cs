using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRandom { 
     public static float Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    public static bool RandomCriteRate()
    {
        float[] rate = { 75, 25 };
        float result = Choose(rate);
        Debug.Log("Random Crit Rate: " + result.ToString());
        return result == 0 ? false : true;
    }
}
