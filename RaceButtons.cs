using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RaceButtons : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject GameMenu;
    public bool ispaused;
	public GameObject CountDown;

    void Start()
    {
    	pauseMenu.SetActive(false);
        GameMenu.SetActive(true);

    }

    public void MainMenu()
	{
		Time.timeScale = 1f;
		BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().Play();
		SceneManager.LoadScene(1);
	}

    public void Restrat() {
		Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(ispaused)
			{
				ResumeGame();
			}

			else
			{
				PauseGame();
			}
		}
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}

	public void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		ispaused = true;
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		ispaused = false;
	}
}
