using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A basic UI health that display character health dynamically as long as they have a health script as a component and UI canvas
//How to use: Add this script as character component. A new section should appear to allow you to drag n drop the wanted character and canvas.
public class PlayerHealthUI : MonoBehaviour
{
    public GameObject actor;
    public GameObject healthCanvas;
    public GameObject scoreCanvas;
    public GameObject remainingCanvas;
    public GameManager manager;

    protected HealthScript script;
    protected Text healthText;
    protected Text scoreText;
    protected Text remainingText;

    // Start is called before the first frame update
    void Start()
    {
        script = actor.GetComponentInChildren<HealthScript>() as HealthScript;
        healthText = healthCanvas.GetComponentInChildren<Text>();
        scoreText = scoreCanvas.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + script.currentHealth.ToString();
        scoreText.text = "Score: " + GameManager.enemiesKilled.ToString();
    }
}
