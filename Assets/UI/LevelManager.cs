using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int _level=1;
    public GameObject[] lvl = new GameObject[4];


    // Start is called before the first frame update
    void Start()
    {
        _level = PlayerPrefs.GetInt("level");
        _level += 1;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<lvl.Length; i++)
        {
            //var color = lvl[i].GetComponent<Button>().colors;
            //color.normalColor = Color.gray;
            
            if (i + 1 > _level)
            {
                //lvl[i].GetComponent<Button>().colors = color;
                lvl[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}
