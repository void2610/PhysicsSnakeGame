using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    DistanceJoint2D joint;
    float distance = 0.005f;
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        joint.distance = distance;
    }
}
