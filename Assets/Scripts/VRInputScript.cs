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

    // Reload game
	public float holdToReloadTime = 2.0f;
	IEnumerator currentReloadTimer;

    // Draw magic spell
    public float drawFrequency = 0.5f;
    public GameObject magicDrawPlane;
    public VRTK_StraightPointerRenderer pointer;

	// Start is called before the first frame update
	void Start()
	{
        StartCoroutine(UpdateDrawing());
	}

	// Update is called once per frame
	void Update()
	{

	}

    private IEnumerator UpdateDrawing()
    {
        while (true)
        {
            RaycastHit hit;
            Physics.Raycast(pointer.GetPointerOrigin().position, pointer.GetPointerOrigin().forward, out hit);
            Debug.Log("Tex coords hit: " + hit.textureCoord);

            yield return new WaitForSeconds(drawFrequency);
        }
    }

    // for capturing VRTK_ControllerEvents
    void OnEnable()
	{
		right.ButtonOneReleased += ControllerEvents_ButtonOneReleased;

		right.ButtonTwoPressed += ControllerEvents_ButtonTwoPressed;
		right.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;

        right.TriggerPressed += ControllerEvents_TriggerPressed;
	}

	void OnDisable() {
		
		right.ButtonOneReleased -= ControllerEvents_ButtonOneReleased;

		right.ButtonTwoPressed -= ControllerEvents_ButtonTwoPressed;
		right.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;

        right.TriggerPressed -= ControllerEvents_TriggerPressed;

	}

    private void ControllerEvents_TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        //Debug.Log("Right trigger pressed");
        
        // Move in front of controller
        magicDrawPlane.transform.position = pointer.GetPointerOrigin().position + 5 * pointer.GetPointerOrigin().forward;

        // Rotate to face controller
        magicDrawPlane.transform.LookAt(pointer.GetPointerOrigin().position, pointer.GetPointerOrigin().up);
        magicDrawPlane.transform.Rotate(new Vector3(90, 0, 0));
        StartCoroutine(UpdateDrawing());
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
