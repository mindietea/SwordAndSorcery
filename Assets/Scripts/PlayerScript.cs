using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private bool dead = false;
    public MenuController menuController;
    public AudioSource voiceOverAudio;
    public AudioClip youMakeLaughClip;
    public AudioClip endClip;
    public AudioClip victoryClip;


    // Update is called once per frame
    void Update()
    {
        if (!dead && GetComponent<HealthScript>().currentHealth <= 0) {
            dead = true;
            GameManager.HandleGameLost();
        }
    }

    public void HandleGameWon()
    {
        Debug.Log("You won!!!");
        menuController.SetMenuImage(MenuController.MenuMode.VICTORY);
        menuController.PauseGame();

        voiceOverAudio.Stop();
        voiceOverAudio.clip = victoryClip;
        voiceOverAudio.Play();
    }

    public void HandleGameLost()
    {
        Debug.Log("You died :( epic fail");
        menuController.SetMenuImage(MenuController.MenuMode.DEFEAT);
        menuController.PauseGame();


        Debug.Log(UnityEngine.Random.Range(0, 2) % 2 == 0);

        voiceOverAudio.Stop();
        if (UnityEngine.Random.Range(0, 2) % 2 == 0) { Debug.Log("youMakeLaughClip"); voiceOverAudio.clip = youMakeLaughClip; }
        else {Debug.Log("endClip"); voiceOverAudio.clip = endClip; }
        voiceOverAudio.Play();
    }
}
