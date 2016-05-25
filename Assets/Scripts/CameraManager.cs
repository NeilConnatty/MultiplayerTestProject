using UnityEngine;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour
{
    void Start ()
    {
        if (isServer) gameObject.SetActive(false);
    }
}
