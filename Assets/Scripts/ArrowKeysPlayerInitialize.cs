using UnityEngine;
using UnityEngine.Networking;

public class ArrowKeysPlayerInitialize : NetworkBehaviour
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
                ((MonoBehaviour) gameObject.GetComponent("ArrowKeysLooker")).enabled = true;
                ((MonoBehaviour) gameObject.GetComponent("ArrowKeysController")).enabled = true;
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
