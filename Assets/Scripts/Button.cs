using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public void loadLevel(string level)
	{
		Application.LoadLevel (level);
	}
}
