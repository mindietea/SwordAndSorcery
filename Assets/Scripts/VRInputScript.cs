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
    public MagicDrawScript magicDrawScript;
    private IEnumerator currentDrawRoutine;

	// Start is called before the first frame update
	void Start()
	{
        magicDrawScript = GameManager.GetMagicScreen().GetComponent<MagicDrawScript>();
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

        right.TriggerPressed += ControllerEvents_TriggerPressed;
        right.TriggerPressed += ControllerEvents_TriggerReleased;
    }

	void OnDisable() {
		
		right.ButtonOneReleased -= ControllerEvents_ButtonOneReleased;

		right.ButtonTwoPressed -= ControllerEvents_ButtonTwoPressed;
		right.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;

        right.TriggerPressed -= ControllerEvents_TriggerPressed;
        right.TriggerPressed -= ControllerEvents_TriggerReleased;

    }

    private void ControllerEvents_TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        //Debug.Log("Right trigger pressed");
        
        // Move in front of controller
        magicDrawPlane.transform.position = pointer.GetPointerOrigin().position + 5 * pointer.GetPointerOrigin().forward;

        // Rotate to face controller
        magicDrawPlane.transform.LookAt(pointer.GetPointerOrigin().position, pointer.GetPointerOrigin().up);
        magicDrawPlane.transform.Rotate(new Vector3(90, 0, 0));
        currentDrawRoutine = UpdateDrawing();
        StartCoroutine(currentDrawRoutine);
    }

    private void ControllerEvents_TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        StopCoroutine(currentDrawRoutine);
    }

    private IEnumerator UpdateDrawing()
    {
        while (true)
        {
            Debug.Log("Test");
            Ray ray = new Ray(pointer.GetPointerOrigin().position, pointer.GetPointerOrigin().forward);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.gameObject.tag == "MagicDrawPlane")
                {
                    Debug.Log("Tex coords hit: " + hit.textureCoord);
                    //magicDrawScript.DrawAt(hit.textureCoord.x, hit.textureCoord.y);
                }

            }

            yield return new WaitForSeconds(drawFrequency);
        }
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
