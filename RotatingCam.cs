using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCam : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,-0.8f,0, Space.World);
    }
}
