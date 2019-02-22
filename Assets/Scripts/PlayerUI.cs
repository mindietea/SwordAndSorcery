using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A basic UI health that display character health dynamically as long as they have a health script as a component and UI canvas
// How to use: Add this script to the PlayerUICanvas. A new section should appear to allow you to drag n drop the Player prefab,
// and the GameObjects that display health and enemies killed.
public class PlayerUI : MonoBehaviour
{
    public GameObject player;
    public GameObject healthTextObj;
    public GameObject enemiesKilledTextObj;

    private HealthScript healthScript;
    private Text healthText;
    private Text enemiesKilledText;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = player.GetComponentInChildren<HealthScript>() as HealthScript;
        healthText = healthTextObj.GetComponentInChildren<Text>();
        enemiesKilledText = enemiesKilledTextObj.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = healthScript.currentHealth.ToString()  + " HP";
        enemiesKilledText.text = GameManager.enemiesKilled.ToString() + "/" + GameManager.ENEMIES_TO_KILL.ToString() + " Enemies Killed";
    }
}
