using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapController : MonoBehaviour
{
    public GameObject Min;
    public GameObject Sec;
    public GameObject MilliSec;

    private static GameObject MinP;
    private static GameObject SecP;
    private static GameObject MilliSecP;
    
    public static float milliCount;
    public static int secCount;
    public static int minCount;


    void Start()
    {
        MinP = Min;
        SecP = Sec;
        MilliSecP = MilliSec;
        setZero();

    }
    void Update()
    {
        if (CountDown.isDone == false){
            // Debug.Log(PlayerPrefs.GetInt("MinBest") + "" + PlayerPrefs.GetInt("MinBest"));
            milliCount += Time.deltaTime * 10;
            if (milliCount > 9) {
                milliCount = 0;
                secCount += 1;
                if (secCount > 59) {
                    secCount = 0;
                    minCount += 1;
                    if (minCount > 59) {
                        minCount = 0;
                    }
                    Min.GetComponent<Text> ().text = zeroAdd(minCount) + ":";
                }
                Sec.GetComponent<Text>().text = "" + zeroAdd(secCount) + ".";
                
            }

            MilliSec.GetComponent<Text>().text = "" + milliCount.ToString("F0");
        }
        Debug.Log(zeroAdd(minCount) + ":" + zeroAdd(secCount));
    }

    public static void setZero() {
        milliCount = 0;
        secCount = 0;
        minCount = 0;

        MinP.GetComponent<Text> ().text = "00" + ":";
        SecP.GetComponent<Text>().text = "00" + ".";
        MilliSecP.GetComponent<Text>().text = "0";
    }

    public static string zeroAdd(int num) {
        string r;
        if (num >= 10) {
            r = "" + num;
        }
        else {
            r = "0" + num;
        }
        return r;
    }
}
