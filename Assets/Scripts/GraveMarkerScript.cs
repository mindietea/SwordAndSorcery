using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveMarkerScript : MonoBehaviour
{
    // Range at which to trigger enemy spawns
    public float range = 7.0f;

	// How many monsters should be spawned
	public uint monsterCount = 5;

	// Wait this many seconds after a spawn until spawning a new enemy
	public float secondsBetweenSpawns = 4;

    public GameObject monster;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

	IEnumerator SpawnGroupOfMonsters()
	{
		for (int i = 0; i < monsterCount; i++)
		{
			GameObject spawn = Instantiate(monster);
            spawn.transform.position = transform.position;
            spawn.transform.position = new Vector3(spawn.transform.position.x + Random.Range(-6, 6),
												   Terrain.activeTerrain.SampleHeight(spawn.transform.position),
												   spawn.transform.position.z + Random.Range(-6, 6));
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}

    // Update is called once per frame
    void Update()
    {
        if(!spawned && GameManager.GetDistanceToPlayer(gameObject) < range)
        {
            spawned = true;
            StartCoroutine("SpawnGroupOfMonsters");
        }
    }
}
