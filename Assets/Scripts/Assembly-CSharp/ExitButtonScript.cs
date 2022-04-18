using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200001D RID: 29
public class ExitButtonScript : MonoBehaviour
{
	private void Start()
	{
		this.button = base.GetComponent<Button>(); 
		this.button.onClick.AddListener(new UnityAction(this.ExitGame));
	}

	private void ExitGame()
	{
		Application.Quit();
	}

	private Button button;
}
