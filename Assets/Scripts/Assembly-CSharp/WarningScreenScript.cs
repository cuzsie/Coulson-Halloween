using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningScreenScript : MonoBehaviour
{
	bool e;
	[SerializeField] private GameObject screen1;
	[SerializeField] private GameObject screen2;
	
	private void Update()
	{
		if (Input.anyKeyDown && e) 
		{
			SceneManager.LoadScene("MainMenu");
		}
		else if (Input.anyKeyDown && !e)
		{
			AllowClickExit();
			screen1.SetActive(false);
			screen2.SetActive(true);
		}
	}


	public void AllowClickExit()
	{
		e = true;
	}
}
