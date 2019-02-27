using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private bool dead = false;
    public MenuController menuController;

	// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if(!dead && GetComponent<HealthScript>().currentHealth <= 0) {
            GameManager.HandleGameLost();
        }
    }

    public void HandleGameWon()
    {
        Debug.Log("You won!!!");
        menuController.SetMenuImage(MenuController.MenuMode.VICTORY);
        menuController.PauseGame();
    }

    public void HandleGameLost()
    {
        Debug.Log("You died :( epic fail");
        menuController.SetMenuImage(MenuController.MenuMode.DEFEAT);
        menuController.PauseGame();
    }
}
