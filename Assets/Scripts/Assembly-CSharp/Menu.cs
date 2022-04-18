using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Animator a;

    public void SwitchMenu(string m)
    {
        if (m == "bob")
        {
            a.SetTrigger("Bob");
        }
        else if (m == "s1")
        {
            a.SetTrigger("S1");
        }
        else if (m == "outside")
        {
            a.SetTrigger("Out");
        }
    }
}
