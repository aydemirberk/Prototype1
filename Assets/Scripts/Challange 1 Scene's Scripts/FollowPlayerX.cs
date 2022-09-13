using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    Vector3 offset = new Vector3(20, 0, 5);

    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
