using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardLevel : MonoBehaviour
{
    public List<LevelInfo> levels;
    public GameObject[] listLevels;
    public GridLayoutGroup gridLayout;

    private void Awake()
    {
        //InitialLevels();
        //ReadLevels();
    }

    private void InitialLevels()
    {
       // throw new System.NotImplementedException();
    }


    // Start is called before the first frame update
    void Start()
    {
        //Read From Cache / File
        for (int i = 0; i < levels.Count; i++)
        {
            //Debug.Log(index);
            GameObject level = Instantiate(listLevels[1], gridLayout.transform.position, Quaternion.identity);
            //Debug.Log("Card Level : " + level.transform.localScale);
            Debug.Log("Card Level - Log Level " + levels[i].name);
            level.GetComponent<Button>().onClick.AddListener(() => LoadLevel("Level2"));
            level.GetComponent<LevelState>().SetTextLevel((i + 1) + "");

            level.transform.SetParent(gridLayout.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(string level)
    {
        Debug.Log(" Card Level - Load level " + level);
        SceneManager.LoadScene(level);
       // return null;
    }
}
