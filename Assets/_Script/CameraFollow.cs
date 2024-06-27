using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform TF;
    public Transform playerTF;
    public Vector3 offset;

    private void LateUpdate()
    {
        TF.position = playerTF.position + (Vector3)offset;
    }
}
