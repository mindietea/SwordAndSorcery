using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class MenuController : MonoBehaviour
{
    public GameObject playerCanvas;
    public GameObject menuCanvas;
	private bool isPaused = true;

	// Start is called before the first frame update
    void Start()
    {
		PauseGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

	// this function should be called when the player presses the menu
	// button on the controller
	private void PauseGame()
	{
		Debug.Log("Paused Game");
		Time.timeScale = 0;
		menuCanvas.SetActive(true);
	}

	// this function should be called when the game is paused
	// and the player presses the menu button on the controller
	private void UnpauseGame()
	{
		Debug.Log("Unpaused Game");
		Time.timeScale = 1;
		menuCanvas.SetActive(false);
	}

	public void OnButtonClicks(string incomingName)
	{
		Debug.Log ("clicked on " + incomingName);

		switch (incomingName) {
			case "NewGame":
                UnpauseGame();
				break;

			case "Quit":
				Application.Quit(); ///...asthetically speaking :>
				break;
        }
	}
}
