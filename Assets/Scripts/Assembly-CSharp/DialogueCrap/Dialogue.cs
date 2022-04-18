using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class Dialogue {

	public Sprite[] characterIcons;
	public string[] characterNames;
	public AudioClip[] characterTalkSounds;
	
	[TextArea(3, 10)]
	public string[] sentences;
	public bool[] isRight;
	public bool[] keepOriginalText; 

	public GameObject Options;
	public UnityEvent whenDone;

}
