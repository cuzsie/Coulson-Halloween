using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCrap : MonoBehaviour
{
    public Text endingText;

    void Start()
    {
        if (PlayerPrefs.GetString("CurrentMode") == "afterdark")
        {
            endingText.text = "Dark Ending";
        }
    }
}
