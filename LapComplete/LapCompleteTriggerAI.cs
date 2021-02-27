using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCompleteTriggerAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LapCompleteTrigAI;
    public GameObject HalfFlagTrigAI;
    public static int Ailap;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AICar01") {
            Ailap += 1;

            HalfFlagTrigAI.SetActive(true);
            LapCompleteTrigAI.SetActive (false);
        }
    }
}
