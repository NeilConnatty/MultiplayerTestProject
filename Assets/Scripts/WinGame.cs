using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour
{
    public string levelAfterVictory;

    void OnMouseDown()
    {
        Application.LoadLevel (levelAfterVictory);
	}

}
