using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RainEffect : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public GameObject rainBackGround;

    public float weatherChangeTime = 60f;
    private float curreenWeatherChangeTime;
    // Start is called before the first frame update
    void Awake()
    {
        ChangeWeather();

    }

    private void ChangeWeather()
    {
        curreenWeatherChangeTime = weatherChangeTime;
        int i = Random.Range(0, 2);
       // Debug.Log("Rain Effect: " + i);
        if (i == 0)
        {
            RainOff();
        }
        else
            RainOn();
    }

    private void RainOn()
    {
        float rate = Random.Range(10, 200);
        var emission = particleSystem.emission;
        emission.rateOverTime = rate;
        particleSystem.Play();
        rainBackGround.SetActive(true);
    }

    private void RainOff()
    {
        particleSystem.Stop();
        rainBackGround.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (curreenWeatherChangeTime <= 0)
        {
            ChangeWeather();
        }
        else
            curreenWeatherChangeTime -= Time.deltaTime;
    }
}
