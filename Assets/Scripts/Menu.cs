using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject helpCanvas;

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Help() {
        helpCanvas.SetActive(true);
    }

    public void BackToMenu() {
        helpCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}
