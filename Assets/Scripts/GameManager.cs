using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
	// how many (basic) enemies have been killed so far
	private static uint enemiesKilled = 0;

	// the goal of the number of (basic) enemies to kill
	private const uint ENEMIES_TO_KILL = 5;

	// this should be called when a (basic) enemy is killed
	public static void KilledEnemy()
	{
		enemiesKilled++;
		Debug.Log("Enemies killed: " + enemiesKilled);
		if (enemiesKilled == ENEMIES_TO_KILL)
		{
			handleGameWon();
		}
	}

	private static void handleGameWon()
	{
		Debug.Log("You won!!!");
	}

	public static void HandleGameLost()
	{
		Debug.Log("You died :( epic fail");
	}

	public static GameObject GetPlayer()
	{
        return GameObject.FindGameObjectWithTag("Player");
    }

    public static float GetDistanceToPlayer(GameObject other)
    {
        return Vector3.Distance(other.transform.position, GetPlayer().transform.position);
    }

    public static Vector3 GetWorldToScreenPoint(GameObject target)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        return screenPos;
    }
}
