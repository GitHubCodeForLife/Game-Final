using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamgeUI : MonoBehaviour
{
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDamage(int damage)
    {
        text.text = damage.ToString();
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
