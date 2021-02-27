using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using TMPro;

public class CountDown : MonoBehaviour
{

    public GameObject CountDisplay;
    public GameObject LapTimer;
    public GameObject MyCar;
    public GameObject AICar;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public AudioSource GameBGM;
    public AudioSource WinBGM;
    public AudioSource LossBGM;

    public GameObject MinBest;
    public GameObject SecBest;
    public GameObject MilliBest;

    public GameObject WinningCamera;
    public GameObject RotatingCamera;

    public GameObject ViewMode;
    public GameObject GameCanvas;
    public GameObject ExitCanvas;
    public GameObject EndText;

    private string oldRec;
    private bool isFirst = false;
    public static bool isDone = false;
    public GameObject LapBound;

    private int maxVal = 1;
    private int i = 0;
    
    void Update()
    {
        // if (lapValue == PlayerPrefs.GetInt("MaxLap")) {
        if (LapCompleteTrigger.lapValue == maxVal) {
            if (i == 0) {
                isDone = true;
                if (ModeChecker.isTime == false) {
                    StartCoroutine(winner());
                }

                else {
                    if (LapCompleteTrigger.broken) {
                        StartCoroutine(brokeIt());
                    }
                    else {
                        StartCoroutine(notBroke());
                    }
                    
                }

                i = 1;
            }
        }

        else if(ModeChecker.isAI == true && LapCompleteTriggerAI.Ailap == maxVal) {
            if (i == 0 ) {
                isDone = true;
                StartCoroutine(looser());
                
                i = 1;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        isDone = false;
        ExitCanvas.SetActive(false);
        GameCanvas.SetActive(false);

        WinningCamera.SetActive(false);
        RotatingCamera.SetActive(false);

        LapCompleteTrigger.lapValue = 0;
        LapCompleteTriggerAI.Ailap = 0;
        CarController.m_Topspeed = 200;

        ViewMode.SetActive(true);

        LapBound.GetComponent<Text>().text = "/ "+ maxVal;
        


        if (PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap) == 0 && PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap) == 0){
            MilliBest.GetComponent<Text>().text = "Le";
            SecBest.GetComponent<Text>().text = "To";
            MinBest.GetComponent<Text>().text = "Bana ";
            isFirst = true;
        }
        else {
            MilliBest.GetComponent<Text>().text = "" + PlayerPrefs.GetFloat("MilliBest"+ ButtonManage.loadaedMap).ToString("F0");
            SecBest.GetComponent<Text>().text = "" + LapController.zeroAdd(PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap)) + ".";
            MinBest.GetComponent<Text>().text = "" + LapController.zeroAdd(PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap)) + ":";
            oldRec = LapController.zeroAdd(PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap)) + ":" + LapController.zeroAdd(PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap)) + "." + PlayerPrefs.GetFloat("MilliBest"+ ButtonManage.loadaedMap).ToString("F0");
        }


        StartCoroutine(display());   

    }


    IEnumerator display() {

            yield return new WaitForSeconds(0.5f);
            CountDisplay.GetComponent<Text>().text = "3";
            CountDisplay.SetActive(true);
            GetReady.Play();

            yield return new WaitForSeconds(1f);
            CountDisplay.SetActive(false);
            CountDisplay.GetComponent<Text>().text = "2";
            CountDisplay.SetActive(true);
            GetReady.Play();

            yield return new WaitForSeconds(1f);
            CountDisplay.SetActive(false);
            CountDisplay.GetComponent<Text>().text = "1";
            CountDisplay.SetActive(true);
            GetReady.Play();

            yield return new WaitForSeconds(1f);
            CountDisplay.SetActive(false);
            GoAudio.Play();
            LapTimer.SetActive(true);
            MyCar.GetComponent<CarController>().enabled = true;
            MyCar.GetComponent<CarUserControl>().enabled = true;
            MyCar.GetComponent<CarAudio>().enabled = true;
            AICar.GetComponent<CarAIControl>().enabled = true;
            AICar.GetComponent<CarController>().enabled = true;

            GameCanvas.SetActive(true);
            

            yield return new WaitForSeconds(1f);
            GameBGM.Play();

    }

    IEnumerator winner(){
        yield return new WaitForSeconds(0.01f);
        WinningCamera.SetActive(true);

        yield return new WaitForSeconds(2f);

        everythingOff();

        RotatingCamera.SetActive(true);
        WinningCamera.SetActive(false);       
        WinBGM.Play();

        if (ModeChecker.ModeSelection != 1) {
            GlobalCash.TotalCash += 100;
            PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
        }

        yield return new WaitForSeconds(2f);
        if (ModeChecker.ModeSelection != 1) {
            EndText.GetComponent<TMPro.TextMeshProUGUI>().text = "Hurrey!! You won :)";
        }
        else{
            EndText.SetActive(false);
        }
        ExitCanvas.SetActive(true);
        GameCanvas.SetActive(false);
    }

    IEnumerator looser() {
        yield return new WaitForSeconds(0.01f);
        WinningCamera.SetActive(true);

        yield return new WaitForSeconds(2f);

        everythingOff();

        LossBGM.Play();
        if (GlobalCash.TotalCash < 150){
            GlobalCash.TotalCash = 0;
        }
        else {
            GlobalCash.TotalCash -= 150;
        }
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);

        EndText.GetComponent<TMPro.TextMeshProUGUI>().text = "Alas!! You loose :(";
        ExitCanvas.SetActive(true);
        GameCanvas.SetActive(false);

    }

    IEnumerator notBroke() {
        yield return new WaitForSeconds(0.01f);
        WinningCamera.SetActive(true);

        yield return new WaitForSeconds(2f);

        everythingOff();

        RotatingCamera.SetActive(true);
        WinningCamera.SetActive(false);       
        WinBGM.Play();

        if (GlobalCash.TotalCash < 10){
            GlobalCash.TotalCash = 0;
        }
        else {
            GlobalCash.TotalCash -= 10;
        }
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);

        yield return new WaitForSeconds(2f);
        EndText.GetComponent<TMPro.TextMeshProUGUI>().text = "Old Record Hold!\n Better Luck next Time\n Record: " + oldRec;
        ExitCanvas.SetActive(true);
        GameCanvas.SetActive(false);
    }

    IEnumerator brokeIt() {
        yield return new WaitForSeconds(0.01f);
        WinningCamera.SetActive(true);

        yield return new WaitForSeconds(2f);

        everythingOff();

        RotatingCamera.SetActive(true);
        WinningCamera.SetActive(false);       
        WinBGM.Play();

        yield return new WaitForSeconds(2f);
        if (isFirst) {
            EndText.GetComponent<TMPro.TextMeshProUGUI>().text = "Hurrey!! You broke your record. \n Old Record: N/A" + "\n" + "Your Time: " + LapController.zeroAdd(PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap)) + ":" + LapController.zeroAdd(PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap)) + "." + PlayerPrefs.GetFloat("MilliBest"+ ButtonManage.loadaedMap).ToString("F0");
        }
        else {
            EndText.GetComponent<TMPro.TextMeshProUGUI>().text = "Hurrey!! You broke your record. \n Old Record: " + oldRec + "\n" + "Your Time: " + LapController.zeroAdd(PlayerPrefs.GetInt("MinBest"+ ButtonManage.loadaedMap)) + ":" + LapController.zeroAdd(PlayerPrefs.GetInt("SecBest"+ ButtonManage.loadaedMap)) + "." + PlayerPrefs.GetFloat("MilliBest"+ ButtonManage.loadaedMap).ToString("F0");
        }
        GameCanvas.SetActive(false);
        ExitCanvas.SetActive(true);
    }

    void everythingOff() {
        MyCar.SetActive(false);
        CarController.m_Topspeed = 0.01f;
        MyCar.GetComponent<CarController>().enabled = false;
        MyCar.GetComponent<CarUserControl>().enabled = false;
        MyCar.GetComponent<CarAudio>().enabled = false;
        MyCar.SetActive(true);
        GameBGM.Stop();

        ViewMode.SetActive(false);
    }
    
}
