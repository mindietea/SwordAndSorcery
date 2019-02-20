using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private bool dead = false;

	private void HandleDeath()
	{
		dead = true;
		Debug.Log("Player Dead");
		GameManager.HandleGameLost();
	}

	// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if(!dead && GetComponent<HealthScript>().currentHealth <= 0) {
            HandleDeath();
        }
    }
}
