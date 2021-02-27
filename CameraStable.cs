using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject car;
    public float carX;
    public float carY;
    public float carZ;


    // Update is called once per frame
    void Update()
    {
        carX = car.transform.eulerAngles.x;
        carY = car.transform.eulerAngles.y;
        carZ = car.transform.eulerAngles.z;
        
        transform.eulerAngles = new Vector3(carX - carX, carY, carZ - carZ);
    }
}
