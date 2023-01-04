using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - target.transform.position;

    }

    void LateUpdate()
    {
        Vector3 currentPos = transform.position;
        if(PlayerMovement.isGameOver)
        currentPos.z = (cameraOffset + target.transform.position).z;
        else currentPos.z = (cameraOffset + target.transform.position).z;
        transform.position = currentPos;
    }
}
