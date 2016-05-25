using UnityEngine;
using UnityEngine.Networking;

public class PlayerInitialize : NetworkBehaviour
{
    void Start ()
    {
        if (isServer) {
            GameObject.Find("StandbyCamera").SetActive(false);
            if (isLocalPlayer) {
                ((MonoBehaviour) gameObject.GetComponent("MouseLooker")).enabled = true;
                ((MonoBehaviour) gameObject.GetComponent("Controller")).enabled = true;
                gameObject.transform.FindChild("Main Camera").gameObject.SetActive(true);
            }
        } else {
            if (isLocalPlayer) {
                gameObject.SetActive(false);
            }
        }
    }
}
