using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public static bool paused;
    public GameObject gameoverScreen;
	// Update is called once per frame
	void Update () {
        if (PlayerScript.gameOver) {
            StartCoroutine(ActivateGameover());
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    IEnumerator ActivateGameover()
    {
        yield return new WaitForSecondsRealtime(.5f);
        gameoverScreen.SetActive(true);
    }

    public void Restart()
    {
        CompleteCameraController.score = 0;
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
