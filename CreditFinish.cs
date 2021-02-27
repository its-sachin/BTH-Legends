using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CreditFinish : MonoBehaviour {
    public GameObject CreationVideo;


	void Start () {
        StartCoroutine(CreditEnd());
	}



    IEnumerator CreditEnd()
    {
        yield return new WaitForSeconds(3f);
        CreationVideo.SetActive(true);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
	

}