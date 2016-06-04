using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReloadGameButton : NetworkBehaviour {

	public void loadLevel (string level)
	{
		NetworkManager nm = NetworkManager.singleton;
		if (nm) nm.dontDestroyOnLoad = false;

		SceneManager.LoadScene (level);
	}
}
