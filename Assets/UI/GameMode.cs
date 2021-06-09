using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;


public class GameMode : MonoBehaviour
{
    private float currentTime;
    bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        currentTime = 0;
        Thread time = new Thread(() => {
            TimeCal();            
        });
        time.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetGame()
    {

        //currentTime = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
        //Application.LoadLevel(Application.loadedLevel);
    }

    void TimeCal()
    {
        while (!gameOver)
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
        string time= (Min.ToString()+" : "+Sec.ToString());
        return (time);
    }
}
