using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefrenceToggle : MonoBehaviour
{
    public string prefName;
    public Toggle toggle;


    void Start()
    {
        toggle = base.GetComponent<Toggle>();
        
        if (PlayerPrefs.GetString(prefName) == "true")
        {
            toggle.isOn = true;
        }
        if (PlayerPrefs.GetString(prefName) == "false")
        {
            toggle.isOn = false;
        }
        else
        {
            Debug.Log("you messed up >:)");
        }
    }

    public void changePrefOnToggle()
    {
        if (toggle.isOn)
        {
            Debug.Log("Is On");
            PlayerPrefs.SetString(prefName,"true");
        }
        else if (!toggle.isOn)
        {
            Debug.Log("Is Off");
            PlayerPrefs.SetString(prefName,"false");
        }
    }
}
