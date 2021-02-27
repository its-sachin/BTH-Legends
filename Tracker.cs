using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public GameObject Mark1;
    public GameObject Mark2;
    public GameObject Mark3;
    public GameObject Mark4;
    public GameObject Mark5;
    public GameObject Mark6;
    public GameObject Mark7;
    public GameObject Mark8;
    public GameObject Mark9;
    public GameObject Mark10;
    public GameObject Mark11;
    public GameObject Mark12;
    public GameObject Mark13;
    public GameObject Mark14;
    public GameObject Mark15;
    public GameObject Mark16;
    public GameObject Mark17;
    public GameObject Mark18;
    public GameObject Mark19;
    public GameObject Track;
    private int MarkCount;

    // Update is called once per frame
    void Update()
    {
        if (MarkCount == 0) {
            Track.transform.position = Mark1.transform.position;
        }

        else if (MarkCount == 1) {
            Track.transform.position = Mark2.transform.position;
        }

        else if (MarkCount == 2) {
            Track.transform.position = Mark3.transform.position;
        }
        
        else if (MarkCount == 3) {
            Track.transform.position = Mark4.transform.position;
        }

        else if (MarkCount == 4) {
            Track.transform.position = Mark5.transform.position;
        }

        else if (MarkCount == 5) {
            Track.transform.position = Mark6.transform.position;
        }

        else if (MarkCount == 6) {
            Track.transform.position = Mark7.transform.position;
        }

        else if (MarkCount == 7) {
            Track.transform.position = Mark8.transform.position;
        }

        else if (MarkCount == 8) {
            Track.transform.position = Mark9.transform.position;
        }
        
        else if (MarkCount == 9) {
            Track.transform.position = Mark10.transform.position;
        }

        else if (MarkCount == 10) {
            Track.transform.position = Mark11.transform.position;
        }

        else if (MarkCount == 11) {
            Track.transform.position = Mark12.transform.position;
        }

        else if (MarkCount == 12) {
            Track.transform.position = Mark13.transform.position;
        }

        else if (MarkCount == 13) {
            Track.transform.position = Mark14.transform.position;
        }

        else if (MarkCount == 14) {
            Track.transform.position = Mark15.transform.position;
        }
        
        else if (MarkCount == 15) {
            Track.transform.position = Mark16.transform.position;
        }

        else if (MarkCount == 16) {
            Track.transform.position = Mark17.transform.position;
        }

        else if (MarkCount == 17) {
            Track.transform.position = Mark18.transform.position;
        }

        else if (MarkCount == 18) {
            Track.transform.position = Mark19.transform.position;
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AICar01") {
            this.GetComponent<BoxCollider>().enabled = false;
            MarkCount += 1;
            if (MarkCount == 6) {
                MarkCount = 0;
            }
            yield return new WaitForSeconds(1f);

            this.GetComponent<BoxCollider>().enabled = true;

        }
    } 
}
