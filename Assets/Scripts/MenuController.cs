using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK;

public class MenuController : MonoBehaviour
{
    public GameObject playerCanvas;
    public GameObject menuCanvas;
	private bool isPaused = true;

	// these textures need to be configured from the Unity component
	public Texture pauseTexture;
	public Texture victoryTexture;
	public Texture defeatTexture;
	public GameObject menuImage; // the child of MenuCanvas

	// Start is called before the first frame update
    void Start()
    {
		//PauseGame();
		//GameManager.HandleGameLost();
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

	public void PauseGame()
	{
		Debug.Log("Paused Game");
		Time.timeScale = 0;
		menuCanvas.SetActive(true);
	}

	public void UnpauseGame()
	{
		Debug.Log("Unpaused Game");
		Time.timeScale = 1;
		menuCanvas.SetActive(false);
	}

	public enum MenuMode {PAUSE, VICTORY, DEFEAT};
	public void SetMenuImage(MenuMode mode)
	{
		RawImage m_RawImage = menuImage.GetComponent<RawImage>();

		switch (mode)
		{
			case MenuMode.PAUSE:
				m_RawImage.texture = pauseTexture;
				break;

			case MenuMode.VICTORY:
				m_RawImage.texture = victoryTexture;
				break;

			case MenuMode.DEFEAT:
				m_RawImage.texture = defeatTexture;
				break;
		}
	}

	// TODO: doesn't seem to get called
	public void OnButtonClicks(string incomingName)
	{
		Debug.Log("Clicked on GUI button: " + incomingName);

		switch (incomingName)
		{
			case "NewGame":
                Debug.Log("Clicked New Game");
				break;

			case "Quit":
				Application.Quit(); ///...asthetically speaking :>
				break;
        }
	}
}
