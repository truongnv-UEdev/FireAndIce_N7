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
		SceneManager.LoadScene(1);
	}
	public void chooseLevel2()
	{
		SceneManager.LoadScene(2);
	}
	public void chooseLevel3()
	{
		SceneManager.LoadScene(3);
	}
	public void chooseLevel4()
	{
		SceneManager.LoadScene(4);
	}

	public void chooseLevel5()
	{
		SceneManager.LoadScene(5);
	}
}
