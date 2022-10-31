using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    Light light;
    bool on = true;
    
    void Start()
    {
        light = base.GetComponent<Light>();
    }

    void Update()
    {
        int proba = 100;

        if (!on) proba = 25;

        if (UnityEngine.Random.Range(0, proba) == proba / 2)
        {
            on = !on;
        }

        switch(on)
        {
            case true:
                light.range = 30;
                break;
            case false:
                light.range = 0;
                break;
        }
    }
}
