using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalculateResult : MonoBehaviour
{
    public GameObject textTime;
    Text txtTime;
    GameMode manager;
    // Start is called before the first frame update
    void Start()
    {
        txtTime = textTime.GetComponent<Text>();
        txtTime.text = PlayerPrefs.GetString("finishtime");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void NextLevel()
    {
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("nextlevel"));
    }

    public void BackToMenu()
    {
        Debug.Log("Ve menu");
        SceneManager.LoadScene(0);
    }
}
