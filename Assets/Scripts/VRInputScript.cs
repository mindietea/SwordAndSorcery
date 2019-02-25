using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;

public class VRInputScript : MonoBehaviour
{
	public VRTK_ControllerEvents right;
	public VRTK_ControllerEvents left;

	public MenuController menuController;

	public float holdToReloadTime = 2.0f;
	IEnumerator currentReloadTimer;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	// for capturing VRTK_ControllerEvents
	void OnEnable()
	{
		right.ButtonOneReleased += ControllerEvents_ButtonOneReleased;

		right.ButtonTwoPressed += ControllerEvents_ButtonTwoPressed;
		right.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
	}

	void OnDisable() {
		
		right.ButtonOneReleased -= ControllerEvents_ButtonOneReleased;

		right.ButtonTwoPressed -= ControllerEvents_ButtonTwoPressed;
		right.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;

	}

	private void ControllerEvents_ButtonOneReleased(object sender, ControllerInteractionEventArgs e)
	{
		Debug.Log("MenuToggle got ButtonOneReleased");
		menuController.TogglePauseGame();
	}

	private void ControllerEvents_ButtonTwoPressed(object sender, ControllerInteractionEventArgs e) {
		Debug.Log("B pressed");
		currentReloadTimer = StartNewGameTimer();
		StartCoroutine(currentReloadTimer);
	}

	private void ControllerEvents_ButtonTwoReleased(object sender, ControllerInteractionEventArgs e) {
		Debug.Log("B released");
		Debug.Log("Stopping reload timer");
		StopCoroutine(currentReloadTimer);
	}

	private IEnumerator StartNewGameTimer() {
		Debug.Log("Starting reload timer");
		yield return new WaitForSeconds(holdToReloadTime);
		Debug.Log("Starting new game");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
