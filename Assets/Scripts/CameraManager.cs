using UnityEngine;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour
{
    void DisableCamera ()
    {
        if (isServer) gameObject.SetActive(false);
    }
}
