using UnityEngine;
using VRTK;

public class MenuToggle : MonoBehaviour
{
	public VRTK_ControllerEvents controllerEvents;
	public MenuController menuController;

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
		controllerEvents.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
	}

	// for capturing VRTK_ControllerEvents
	void OnDisable()
	{
		controllerEvents.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;
	}

	private void ControllerEvents_ButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
	{
		Debug.Log("MenuToggle got ButtonTwoReleased");
		menuController.TogglePauseGame();
	}
}
