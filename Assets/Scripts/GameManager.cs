using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameManager : NetworkBehaviour
{
    public static GameManager gm;
    public static NetworkManager nm;

    public string levelAfterVictory;

    void Awake ()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager> ();

        if (nm == null)
            nm = GameObject.FindWithTag("NetworkManager").GetComponent<NetworkManager> ();
    }

    public void LevelComplete ()
    {
        StartCoroutine (LoadNextLevel());
    }

    IEnumerator LoadNextLevel ()
    {
        yield return new WaitForSeconds (0.5f);
        nm.ServerChangeScene (levelAfterVictory);
    }
}
