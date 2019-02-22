using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerScript : MonoBehaviour
{
	// Wait this many seconds after a spawn until spawning a new enemy
	public float secondsBetweenSpawns = 4;

	// Randomly add or remove up to this many seconds from secondsBetweenSpawns
	public float spawnTimeRandomness = 2;
	
    public GameObject monster;
    bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

	IEnumerator SpawnBoss()
	{
		GameObject spawn = Instantiate(monster);
        spawn.transform.position = transform.position;
        spawn.transform.position = new Vector3(
				spawn.transform.position.x + Random.Range(-6f, 6f),
				Terrain.activeTerrain.SampleHeight(spawn.transform.position) + Terrain.activeTerrain.transform.position.y,
				spawn.transform.position.z + Random.Range(-6f, 6f)
		);

		yield return new WaitForSeconds(secondsBetweenSpawns + Random.Range(-spawnTimeRandomness, spawnTimeRandomness));
		Debug.Log("spawned Boss");
	}


    // Update is called once per frame
    void Update()
    {
        if(!spawned && GameManager.Boss == true)
        {
            spawned = true;
            StartCoroutine("SpawnBoss");
        }
    }
}
