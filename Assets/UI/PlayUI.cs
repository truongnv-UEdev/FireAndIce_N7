using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    public GameObject text;
    Text txtTime;
    GameMode manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameMode>();
        txtTime = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        txtTime.text = manager.getCurrentTime();
    }
}
