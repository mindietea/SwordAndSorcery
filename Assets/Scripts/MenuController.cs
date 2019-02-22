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
	public void TogglePauseGame()
	{
		isPaused = !isPaused;
		if (isPaused)
		{
			PauseGame();
		}
		else
		{
			UnpauseGame();
		}
	}

	private void PauseGame()
	{
		Debug.Log("Paused Game");
		Time.timeScale = 0;
		menuCanvas.SetActive(true);
	}

	private void UnpauseGame()
	{
		Debug.Log("Unpaused Game");
		Time.timeScale = 1;
		menuCanvas.SetActive(false);
	}

	public void OnButtonClicks(string incomingName)
	{
		Debug.Log("Clicked on GUI button: " + incomingName);

		switch (incomingName) {
			case "NewGame":
                Debug.Log("Clicked New Game");
				break;

			case "Quit":
				Application.Quit(); ///...asthetically speaking :>
				break;
        }
	}
}
