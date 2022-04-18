using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BoxTrigger : MonoBehaviour
{
    void Start()
    {
        this.hitBox = base.GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (!isClickTrigger)
            {
                whenEnter.Invoke();
            }
            else
            {
                canBeClicked = true;
                clickTriggerIcon.SetActive(true);
            }
		}
    }

    private void OnTriggerExit(Collider other)
	{
		if (!isClickTrigger)
        {
            whenExit.Invoke();
        }
        else
        {
            canBeClicked = false;
            clickTriggerIcon.SetActive(false);
        }
    }


    void Update()
    {
        if (canBeClicked && Input.GetKeyDown(KeyCode.Q))
        {
            whenEnter.Invoke();
        }
    }
    BoxCollider hitBox;

    public UnityEvent whenEnter;

    public UnityEvent whenExit;
    private bool canBeClicked;

    [SerializeField] private bool isClickTrigger = false;

    [SerializeField] private GameObject clickTriggerIcon;
}
