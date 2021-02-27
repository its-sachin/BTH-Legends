using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCompleteTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MinBest;
    public GameObject SecBest;
    public GameObject MilliBest;
    public GameObject LapCompleteTrig;
    public GameObject HalfFlagTrig;
    public GameObject LapCount;
    public static int lapValue;
    public static bool broken = false; 
    private int map;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            lapValue += 1;
            LapCount.GetComponent<Text>().text = "" + lapValue;
            broken = recordBreak();
            if (recordBreak() && ModeChecker.ModeSelection != 1) {
                
                MilliBest.GetComponent<Text>().text = "" + LapController.milliCount.ToString("F0");
                SecBest.GetComponent<Text>().text = "" + LapController.zeroAdd(LapController.secCount) + ".";
                MinBest.GetComponent<Text>().text = "" + LapController.zeroAdd(LapController.minCount) + ":";

                PlayerPrefs.SetInt("MinBest" + ButtonManage.loadaedMap, LapController.minCount);
                PlayerPrefs.SetInt("SecBest"+ ButtonManage.loadaedMap, LapController.secCount);  
                PlayerPrefs.SetFloat("MilliBest"+ ButtonManage.loadaedMap, LapController.milliCount);

            }

            LapController.setZero();
            
            HalfFlagTrig.SetActive(true);
            LapCompleteTrig.SetActive (false);
        }

    }

    private bool recordBreak() {
        if ((PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap) == 0 && PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap) == 0)) {
            return true;
        }
        else {
            if (PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap) > LapController.minCount) {
                return true;
            }
            else {
                if (PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap) == LapController.minCount) {
                    if (PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap) > LapController.secCount){
                        return true;
                    }
                    else {
                        if (PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap) == LapController.secCount) {
                            if (PlayerPrefs.GetFloat("MilliBest"+ ButtonManage.loadaedMap) > LapController.milliCount) {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

}
