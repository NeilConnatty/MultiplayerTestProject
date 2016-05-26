using UnityEngine;
using UnityEngine.Networking;

public class PlayerInitialize : NetworkBehaviour
{
    private GameObject secondaryCamera;

    void Start ()
    {
        if (isServer) {
            // find and disable standby camera
            secondaryCamera = GameObject.Find("StandbyCamera");
            if (secondaryCamera)
            {
                secondaryCamera.SetActive(false);
            }
            if (isLocalPlayer) {
                ((MonoBehaviour) gameObject.GetComponent("MouseLooker")).enabled = true;
                ((MonoBehaviour) gameObject.GetComponent("Controller")).enabled = true;
                gameObject.transform.FindChild("Main Camera").gameObject.SetActive(true);
            } else {
                gameObject.SetActive(false);
            }
        } else {
            if (isLocalPlayer) {
                gameObject.SetActive(false);
            }
        }
    }
}
