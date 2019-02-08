using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame_WorldController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
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
				SceneManager.LoadScene("GraveMarkerScene");
				break;

			case "Quit":
				Application.Quit(); ///...asthetically speaking :>
				break;

        }
	}
}
