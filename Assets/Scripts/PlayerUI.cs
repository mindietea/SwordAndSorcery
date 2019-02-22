using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A basic UI health that display character health dynamically as long as they have a health script as a component and UI canvas
// How to use: Add this script to the PlayerUICanvas. A new section should appear to allow you to drag n drop the Player prefab,
// and the GameObjects that display health and enemies killed.
public class PlayerUI : MonoBehaviour
{
    public Text healthText;
    public Text enemiesKilledText;

	private HealthScript healthScript = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		healthText.text = GetHealthScript().currentHealth.ToString()  + " HP";
        enemiesKilledText.text = GameManager.enemiesKilled.ToString() + "/" + GameManager.ENEMIES_TO_KILL.ToString() + " Enemies Killed";
    }

	// need to use a getter like this so the FindGameObjectWithTag is called
	// at runtime when the Player GameObject with the healthText has been loaded
	private HealthScript GetHealthScript()
	{
		if (healthScript == null)
		{
			healthScript = GameManager.GetPlayer().GetComponent<HealthScript>();
		}
		return healthScript;
	}
}
