using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverController : MonoBehaviour {

    public GameObject buttons;
	// Use this for initialization
	void Start () {
        PlayerScript.gameOver = false;
        StartCoroutine(EnableButtons());
	}

	IEnumerator EnableButtons() {
        yield return new WaitForSecondsRealtime(1);
        buttons.SetActive(true);
	}
}
