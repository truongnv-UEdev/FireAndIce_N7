using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape_Menu : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("_LastScene"));
	}

	public void chooseLevel1()
    {
		Debug.Log("Chooselv1");
		SceneManager.LoadScene("Level1");
	}
	public void chooseLevel2()
	{
		SceneManager.LoadScene("Level2");
	}
	public void chooseLevel3()
	{
		SceneManager.LoadScene("Level3");
	}
	public void chooseLevel4()
	{
		SceneManager.LoadScene("Level4");
	}
}
