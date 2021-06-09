using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    public GameObject textTime, textKey, buttonSound;
    Text txtTime, txtKey;
    Image btnSound;
    GameMode manager;
    public AudioClip _audioClip;
    public AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameMode>();
        txtTime = textTime.GetComponent<Text>();
        txtKey = textKey.GetComponent<Text>();
        btnSound = buttonSound.GetComponent<Image>();
        ChangeColorSoundBtn();
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

    public void SoundControl()
    {
        if (PlayerPrefs.GetInt("_Mute") == 1)
        {
            _audioSource.PlayOneShot(_audioClip);
            PlayerPrefs.SetInt("_Mute", 0);
            ChangeColorSoundBtn();
        }
        else
        {
            PlayerPrefs.SetInt("_Mute", 1);
            ChangeColorSoundBtn();
        }
    }

    public void ChangeColorSoundBtn()
    {
        if (PlayerPrefs.GetInt("_Mute") == 0)
        {
            btnSound.color = Color.white;
        }
        else
        {
            btnSound.color = Color.green;
        }
    }
}
