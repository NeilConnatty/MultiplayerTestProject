using UnityEngine;
using UnityEngine.Networking;

public class CameraEnable : NetworkBehaviour
{
    void Start ()
    {
        if (isLocalPlayer) {
            gameObject.GetComponent<Camera>().enabled = true;
        } else {
            gameObject.GetComponent<Camera>().enabled = false;
        }
    }
}
