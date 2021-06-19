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
    public Image star2, star3;
    int numStar;
    // Start is called before the first frame update
    void Start()
    {
        txtTime = textTime.GetComponent<Text>();
        txtTime.text = PlayerPrefs.GetString("finishtime");
        numStar = PlayerPrefs.GetInt("finishresult");
        Debug.Log(numStar);
    }

    // Update is called once per frame
    void Update()
    {
        switch (numStar)
        {
            case 2:
                star2.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                star2.GetComponent<Image>().color = Color.white;
                star3.GetComponent<Image>().color = Color.white;
                break;
            default: break;

        }
            
            
        

    }

    

    public void NextLevel()
    {
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("nextlevel"));
    }

    public void BackToMenu()
    {
        Debug.Log("Ve menu");
        SceneManager.LoadScene("MainMenuUI");
    }
}
