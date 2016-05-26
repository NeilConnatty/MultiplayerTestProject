using UnityEngine;
using UnityEngine.Networking;

public class RenderMesh : NetworkBehaviour
{
    public Material playerOneMaterial;
    public Material playerTwoMaterial;

    void Start ()
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

        if (isServer) {
            meshRenderer.material = playerOneMaterial;
        } else {
            meshRenderer.material = playerTwoMaterial;
        }
    }
}
