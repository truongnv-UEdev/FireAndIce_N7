using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    float currentTime;
    public float videoIntroLength = 22f;
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (Input.GetButtonUp("Cancel")) EscapeIntro();
        if (currentTime >= videoIntroLength) EscapeIntro();
    }

    void EscapeIntro()
    {
        SceneManager.LoadScene("MainMenuUI");
    }
}
