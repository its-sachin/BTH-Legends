using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManage : MonoBehaviour
{
    public static int loadaedMap = 1;
    public void PlayGame(){
        SceneManager.LoadScene(2);
    }

    public void MainMenu(){
        BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

    public void Map1() {
        loadaedMap = 1;
        BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(3);
    }

    public void Map2() {
        loadaedMap = 2;
        BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}

    public void OpenFB()
    {
    	Application.OpenURL("https://www.facebook.com/profile.php?id=100010131825138");
    }


    public void OpenINSTA()
    {
    	Application.OpenURL("https://www.instagram.com/_.mr._sachin._/");
    }

}
