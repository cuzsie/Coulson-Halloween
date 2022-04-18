using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour 
{
	public Dialogue dialogue;
	public DialogueManager dialogueManager;
	public bool thingy;
	
	void Start()
	{
		if (PlayerPrefs.GetString("dialogue") == "true")
		{
			thingy = true;
		}
		if (PlayerPrefs.GetString("dialogue") == "true")
		{
			thingy = false;
		}
	}
	
	public void TriggerDialogue ()
	{
		if (!thingy)
		{
			dialogueManager.StartDialogue(dialogue);
		}
		else
		{
			dialogue.whenDone.Invoke();
		}
	}
}
