using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    public GameObject textTime;
    public GameObject textKey;
    Text txtTime, txtKey;
    GameMode manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameMode>();
        txtTime = textTime.GetComponent<Text>();
        txtKey = textKey.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txtKey.text = manager.getNumKeys();
        txtTime.text = manager.getCurrentTime();
        if (manager.getIsEndGame())
        {
            SceneManager.LoadScene(6);
        }
    }
}
