using UnityEngine;
using VRTK;

public class MenuToggle : MonoBehaviour
{
	public VRTK_ControllerEvents controllerEvents;
	public MenuController menuController;

	public float holdToReloadTime = 2.0f;

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
		controllerEvents.ButtonOneReleased += ControllerEvents_ButtonOneReleased;
	}

	// for capturing VRTK_ControllerEvents
	void OnDisable()
	{
		controllerEvents.ButtonOneReleased -= ControllerEvents_ButtonOneReleased;
	}

	private void ControllerEvents_ButtonOneReleased(object sender, ControllerInteractionEventArgs e)
	{
		Debug.Log("MenuToggle got ButtonOneReleased");
		menuController.TogglePauseGame();
	}
}
