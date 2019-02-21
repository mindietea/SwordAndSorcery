using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class MenuController : MonoBehaviour
{
    public GameObject playerCanvas;
    public GameObject menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        playerCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnButtonClicks (string incomingName)
	{
		Debug.Log ("clicked on " + incomingName);

		switch (incomingName) {
			case "NewGame":
                playerCanvas.SetActive(true);
                menuCanvas.SetActive(false);
				break;

			case "Quit":
				Application.Quit(); ///...asthetically speaking :>
				break;

        }
	}
}
