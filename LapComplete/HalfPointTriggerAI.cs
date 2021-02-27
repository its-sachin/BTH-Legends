using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTriggerAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LapCompleteTrigAI;
    public GameObject HalfFlagTrigAI;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "AICar01") {

            HalfFlagTrigAI.SetActive(false);
            LapCompleteTrigAI.SetActive (true);
        }
    }
}
