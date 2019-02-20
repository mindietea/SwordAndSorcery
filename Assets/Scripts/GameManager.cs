using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static GameObject GetPlayer()
	{
        return GameObject.FindGameObjectWithTag("Player");
    }

    public static float GetDistanceToPlayer(GameObject other)
    {
        return Vector3.Distance(other.transform.position, GetPlayer().transform.position);
    }
}
