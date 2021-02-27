using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalCash : MonoBehaviour {

    public int CashValue;
    public static int TotalCash;
    public GameObject CashDisplay;
    public static AudioSource Audio;

    void Start()
    {
        TotalCash = PlayerPrefs.GetInt("SavedCash");
        Audio.Play();
    }

	void Update () {
        CashValue = TotalCash;
        CashDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Cash Earned: $" + CashValue;
	}
}