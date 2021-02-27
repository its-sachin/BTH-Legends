using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LapCompleteTrig;
    public GameObject HalfFlagTrig;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            LapCompleteTrig.SetActive (true);
            HalfFlagTrig.SetActive(false);
        }
    }
}
