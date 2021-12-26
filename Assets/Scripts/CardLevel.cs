using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardLevel : MonoBehaviour
{
    public GameObject[] listLevels;
    public GridLayoutGroup gridLayout;

    // Start is called before the first frame update
    void Start()
    {
        //Read From Cache / File
        for (int i = 0; i < 9; i++)
        {
            int index = (int)Random.Range(1, 4);
            if (i > 5) index = 0;
            Debug.Log(index);
            GameObject level = Instantiate(listLevels[index], gridLayout.transform.position, Quaternion.identity);
            //Debug.Log("Card Level : " + level.transform.localScale);
            if (index != 0)
            {
                level.GetComponent<Button>().onClick.AddListener(() => LoadLevel("Level" + index));
                level.GetComponent<LevelState>().SetTextLevel((i+1)+ "");
            }
            level.transform.SetParent(gridLayout.transform);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
       // return null;
    }
}
