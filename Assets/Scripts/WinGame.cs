using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WinGame : NetworkBehaviour
{
    public string levelAfterVictory;

    void OnMouseDown()
    {
        if (isServer) GameManager.gm.LevelComplete ();
	}



}
