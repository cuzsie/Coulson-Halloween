using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashText : MonoBehaviour
{
    Text text;

    string[] splash = {
        "Now with more Coulson!",
        "Play the full game!",
        "Emilee is Here!",
        "Put splash text here!",
        ".png!",
        "Not stolen from Minecraft!",
        "Baldi Ripoff!",
        "Wait till the full game releases!",
        "Helpful advice!",
        "Gluten free!",
        "Pizza!",
        "Down with the So and So!"
    };


    void Start()
    {
        text = base.GetComponent<Text>();
        text.text = splash[Random.Range(0, splash.Length)];
    }
}
