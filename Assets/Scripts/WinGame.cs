using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour
{
    public string levelAfterVictory;

    void OnMouseDown()
    {
        StartCoroutine(LoadNextLevel());
	}

	// load the nextLevel after delay
	IEnumerator LoadNextLevel()
    {
		yield return new WaitForSeconds(1.5f);
		Application.LoadLevel (levelAfterVictory);
	}
}
