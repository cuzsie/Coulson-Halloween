using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinaleTeleporter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
	{
		Cursor.lockState = CursorLockMode.None; // Unlock the cursor(allow it to move)
        Cursor.visible = true;
		SceneManager.LoadScene("Results"); //Go to the win screen
	}
}
