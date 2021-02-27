using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChecker : MonoBehaviour
{
    public GameObject AICar;
    public GameObject RaceModeDisplay;
    public GameObject ScoreModeDisplay;
    public static int ModeSelection;
    public static int currScore;
    public GameObject CashDisplay;
    private int internalScore;

    public GameObject PositionDisplay;

    public static bool isTime = false;
    public static bool isAI = false;
    // Start is called before the first frame update
    void Start()
    {
        ModeSelection = CarColour.GameMode;


        if (ModeSelection == 0) {
            RaceModeDisplay.SetActive(true);
            ScoreModeDisplay.SetActive(false);
            AICar.SetActive(true);
            PositionDisplay.SetActive(true);
            isAI = true;
        }

        else if (ModeSelection == 1) {
            RaceModeDisplay.SetActive(true);
            ScoreModeDisplay.SetActive(false);
            AICar.SetActive(false);
        }

        else {
            RaceModeDisplay.SetActive(true);
            ScoreModeDisplay.SetActive(false);
            AICar.SetActive(false);
            isTime = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ModeSelection == 1) {
            internalScore = currScore;
            CashDisplay.GetComponent<Text>().text = "" + internalScore;
        }
    }
}
