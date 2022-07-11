using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script for camera managment
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;

    // Start is called before the first frame update
    /// <summary>
    /// Start position of camera.
    /// </summary>
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    /// <summary>
    /// A method that makes camera follow player.
    /// </summary>
    void Update()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = newPosition;
    }
}
