using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Distance of the camera from the object being followed.
    public float cameraDistance = -10;

    // Reference to the object that the camera will follow.
    [SerializeField] GameObject thingToFollow;

    // Update camera position after object movement.
    void LateUpdate()
    {
        // Set camera position to follow the object with an offset.
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, cameraDistance);
    }
}


