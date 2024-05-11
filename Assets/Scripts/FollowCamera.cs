using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float cameraDistance = -10;
    [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0, 0, cameraDistance);   
    }
}
