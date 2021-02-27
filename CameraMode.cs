using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour
{
    
    public GameObject NormalCam;
    public GameObject FarCam;
    public GameObject FPPCam;
    private int mode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ViewMode")) {
            if (mode == 2){
                mode = 0;
            }
            else {
                mode += 1;
            }

            StartCoroutine(changeMode());
        }

    }

    IEnumerator changeMode(){
        yield return new WaitForSeconds(0.01f);

        if (mode == 2){
            FPPCam.SetActive(true);
            FarCam.SetActive(false);
        }

        else if (mode == 1){ 
            FarCam.SetActive(true);
            NormalCam.SetActive(false);
        }

        else {
            NormalCam.SetActive(true);
            FPPCam.SetActive(false);
        }
    }
}
