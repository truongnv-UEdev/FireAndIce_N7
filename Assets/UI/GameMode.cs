using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;


public class GameMode : MonoBehaviour
{
    public int numberOfKey = 3;
    private float currentTime;
    bool isGameEnd;
    int _numKeys;
    int currentLevel;

    void Awake()
    {
        //Check Sound
        if (!PlayerPrefs.HasKey("_Mute"))
        {
            PlayerPrefs.SetInt("_Mute", 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        _numKeys = 0;
        isGameEnd = false;
        currentTime = 0;
        Thread time = new Thread(() => {
            TimeCal();            
        });
        time.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_numKeys >= numberOfKey)
        {
            isGameEnd = true;

            Debug.Log(getCurrentTime());
        }

        if (isGameEnd)
        {
            PlayerPrefs.SetInt("nextlevel", currentLevel+1);
            if(currentLevel > PlayerPrefs.GetInt("level")) PlayerPrefs.SetInt("level", currentLevel);
            PlayerPrefs.SetInt("nextlevel", currentLevel + 1);
            PlayerPrefs.SetString("finishtime", getCurrentTime());
        }
    }
    public void ResetGame()
    {

        //currentTime = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void BackToMenu()
    {

        //currentTime = 0;
        SceneManager.LoadScene("MainMenuUI");
        //Application.LoadLevel(Application.loadedLevel);
    }

    void TimeCal()
    {
        while (!isGameEnd)
        {
            Thread.Sleep(1000);
            currentTime++;
        }
        
    }

    public string getCurrentTime()
    {
        //float Min;
        float Sec;
        double Min;
        Min = System.Math.Truncate(currentTime / 60);
        Sec = currentTime % 60;
        string time= (Min.ToString()+"m"+Sec.ToString()+"s");
        return (time);
    }

    public string getNumKeys()
    {
        return _numKeys.ToString();
    }
    
    public void setNumKey()
    {
        _numKeys+=1;
        Debug.Log(_numKeys);
    }

    public bool getIsEndGame()
    {
        return isGameEnd;
    }
}
