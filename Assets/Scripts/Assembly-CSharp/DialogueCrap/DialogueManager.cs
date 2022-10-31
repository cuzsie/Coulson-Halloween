using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class DialogueManager : MonoBehaviour 
{

	public Text nameText;
	public Text dialogueText;
	public Animator animator;
	private Queue<string> sentences;
	public AudioSource AudioSource;
	public int currentSentence;
	public Image characterLeftIcon;
	public Image characterRightIcon;
	public bool InDialogue;
	public bool lockMouse;
	Sprite[] charIcons;
	string[] charNames;
	AudioClip[] charSounds;
	bool[] isRight;
	bool[] keepOG;
	UnityEvent whenDone;
	public GameControllerScript gameManager;
	public AudioClip continueAudio;
	public bool isMenu;

	// Use this for initialization
	void Start () 
	{
		sentences = new Queue<string>();
		AudioSource = base.GetComponent<AudioSource>();
	}


	void Update()
	{
		CheckForInput();
	}


	void CheckForInput()
	{
		if(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && this.InDialogue)
		{
			DisplayNextSentence();
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && InDialogue)
		{
			EndDialogue();
		}
	}

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);
		this.InDialogue = true;
		sentences.Clear();
		currentSentence--;
		charIcons = dialogue.characterIcons;
		
		charNames = dialogue.characterNames;
		charSounds = dialogue.characterTalkSounds;
		whenDone = dialogue.whenDone;
		isRight = dialogue.isRight;
		// keepOG = dialogue.keepOriginalText;
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
		foreach (string sentence in dialogue.sentences)
		{	
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		this.AudioSource.PlayOneShot(this.continueAudio);
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		currentSentence++;
		string sentence = sentences.Dequeue();

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		
		if (isRight[currentSentence])
		{
			characterRightIcon.gameObject.SetActive(true);
			this.characterRightIcon.sprite = charIcons[this.currentSentence];
			characterLeftIcon.gameObject.SetActive(false);
		}
		else
		{
			characterLeftIcon.gameObject.SetActive(true);
			this.characterLeftIcon.sprite = charIcons[this.currentSentence];
			characterRightIcon.gameObject.SetActive(false);
		}
		
		this.nameText.text = charNames[this.currentSentence];
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = ""; 
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			AudioSource.PlayOneShot(charSounds[this.currentSentence]);
			yield return new WaitForSeconds(0.03f);
			yield return null;
		}
	}

	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		currentSentence = 0;
		charIcons = null;
		charNames = null;
		charSounds = null;
		this.InDialogue = false;
		Time.timeScale = 1f;
		if (this.lockMouse)
		{
			Cursor.lockState = CursorLockMode.Locked; 
			Cursor.visible = false;
		}
		StopAllCoroutines();
		whenDone.Invoke();
		whenDone = null;
	}

}
