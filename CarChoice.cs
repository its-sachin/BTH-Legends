using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoice : MonoBehaviour
{

    public GameObject MyRedBody;
    public GameObject MyBlueBody;
    public GameObject AIRedBody;
    public GameObject AIBlueBody;

    private int carInt;
    // Start is called before the first frame update
    void Start()
    {
        carInt = CarColour.CarType;

        if (carInt == 0) {
            MyBlueBody.SetActive(true);
            MyRedBody.SetActive(false);

            AIRedBody.SetActive(true);
            AIBlueBody.SetActive(false);
        }

        else {
            MyRedBody.SetActive(true);
            MyBlueBody.SetActive(false);

            AIBlueBody.SetActive(true);
            AIRedBody.SetActive(false);
        }
    }

}
