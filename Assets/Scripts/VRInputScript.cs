using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;

public class VRInputScript : MonoBehaviour
{
	public VRTK_ControllerEvents right;
	public VRTK_ControllerEvents left;
	public float holdToReloadTime = 2.0f;

	private float holdATimer = 0.0f;
	IEnumerator currentATimer;

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
		right.ButtonOnePressed += ControllerEvents_ButtonOnePressed;
		right.ButtonOneReleased += ControllerEvents_ButtonOneReleased;
	}

	// for capturing VRTK_ControllerEvents
	void OnDisable()
	{
		right.ButtonOnePressed -= ControllerEvents_ButtonOnePressed;
		right.ButtonOneReleased -= ControllerEvents_ButtonOneReleased;
	}

	private void ControllerEvents_ButtonOnePressed(object sender, ControllerInteractionEventArgs e) {
		currentATimer = StartNewGameTimer();
		StartCoroutine(currentATimer);
	}

	private void ControllerEvents_ButtonOneReleased(object sender, ControllerInteractionEventArgs e) {
		if(currentATimer != null) {
			StopCoroutine(currentATimer);
		}
	}

	private IEnumerator StartNewGameTimer() {
		yield return new WaitForSeconds(holdToReloadTime);
		Debug.Log("Starting new game");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
