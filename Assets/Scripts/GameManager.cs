using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
	// a reference to the menuController so that the GameManager can display the
	// victory/defeat screens
	private static MenuController menuController = new MenuController();

	// how many (basic) enemies have been killed so far
	public static uint enemiesKilled = 0;

	// the goal of the number of (basic) enemies to kill
	public static uint ENEMIES_TO_KILL = 1;

	public static bool Boss = false;

	// this should be called when a (basic) enemy is killed
	public static void KilledEnemy()
	{
		enemiesKilled++;
		Debug.Log("Enemies killed: " + enemiesKilled);
		if (enemiesKilled >= ENEMIES_TO_KILL)
		{
			Boss = true;
		}
	}


	public static void HandleGameWon()
	{
		Debug.Log("You won!!!");
        GameObject player = GetPlayer();
        player.GetComponent<PlayerScript>().HandleGameWon();
    }

	public static void HandleGameLost()
	{
        GameObject player = GetPlayer();
        player.GetComponent<PlayerScript>().HandleGameLost();

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
        return Camera.main.WorldToScreenPoint(target.transform.position);
    }

    public static GameObject GetMagicScreen()
    {
        return GameObject.FindGameObjectWithTag("MagicScreen");
    }
}
