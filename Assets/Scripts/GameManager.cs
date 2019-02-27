using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
	// a reference to the menuController so that the GameManager can display the
	// victory/defeat screens
	private static MenuController menuController = null;

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
		if (enemiesKilled == ENEMIES_TO_KILL)
		{
			Boss = true;
		}
	}

	// need to use a getter like this so the FindGameObjectWithTag is called
	// at runtime when MenuCanvas has been loaded
	private static MenuController GetMenuController()
	{
		if (menuController == null)
		{
			GameObject lol = GameObject.FindGameObjectWithTag("MenuCanvas");
			menuController = GameObject.FindGameObjectWithTag("MenuCanvas").GetComponent<MenuController>();
		}
		return menuController;
	}

	public static void HandleGameWon()
	{
		Debug.Log("You won!!!");
		MenuController mc = GetMenuController();
		mc.SetMenuImage(MenuController.MenuMode.VICTORY);
		mc.PauseGame();
	}

	public static void HandleGameLost()
	{
		Debug.Log("You died :( epic fail");
		MenuController mc = GetMenuController();
		mc.SetMenuImage(MenuController.MenuMode.DEFEAT);
		mc.PauseGame();
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
