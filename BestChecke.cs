using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestChecke : MonoBehaviour
{
    public GameObject Map1;
    public GameObject Map2;
    void Start()
    { 
        Debug.Log(PlayerPrefs.GetInt("MinBest" + 1) + ":" + PlayerPrefs.GetInt("SecBest" + 1));
        Debug.Log(PlayerPrefs.GetInt("MinBest" + 2) + ":" + PlayerPrefs.GetInt("SecBest" + 2));
        if (PlayerPrefs.GetInt("MinBest" + 1) == 0 && PlayerPrefs.GetInt("SecBest" + 1) == 0){
            Map1.GetComponent<TMPro.TextMeshProUGUI>().text = "Best: N/A";
        }
        else{
            Map1.GetComponent<TMPro.TextMeshProUGUI>().text = "Best: " + PlayerPrefs.GetInt("MinBest" + 1) + ":" + PlayerPrefs.GetInt("SecBest" + 1) + "." + PlayerPrefs.GetInt("MilliBest" + 1);
        }
        if (PlayerPrefs.GetInt("MinBest" + 2) == 0 && PlayerPrefs.GetInt("SecBest" + 2) == 0){
            Map2.GetComponent<TMPro.TextMeshProUGUI>().text = "Best: N/A";
        }
        else {
            Map2.GetComponent<TMPro.TextMeshProUGUI>().text = "Best: " + PlayerPrefs.GetInt("MinBest" + 2) + ":" + PlayerPrefs.GetInt("SecBest" +2) + "." + PlayerPrefs.GetInt("MilliBest" + 2);
        }
    }
}
