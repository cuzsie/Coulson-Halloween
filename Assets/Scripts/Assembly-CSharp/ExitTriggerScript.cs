using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200001E RID: 30
public class ExitTriggerScript : MonoBehaviour
{
	// Token: 0x0600007F RID: 127 RVA: 0x0000432C File Offset: 0x0000272C
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks >= 7 & other.tag == "Player")
		{
			SceneManager.LoadScene("Results"); //Go to the win screen
		}
	}

	// Token: 0x040000AA RID: 170
	public GameControllerScript gc;
}
