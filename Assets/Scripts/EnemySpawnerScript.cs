using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Range at which to trigger enemy spawns
    public float range = 7.0f;

	// How many monsters should be spawned
	public uint monsterCount = 5;

	// Wait this many seconds after a spawn until spawning a new enemy
	public float secondsBetweenSpawns = 4;

	// Randomly add or remove up to this many seconds from secondsBetweenSpawns
	public float spawnTimeRandomness = 2;

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
            spawn.transform.position = new Vector3(
											spawn.transform.position.x + Random.Range(-6f, 6f),
											Terrain.activeTerrain.SampleHeight(spawn.transform.position) + Terrain.activeTerrain.transform.position.y,
											spawn.transform.position.z + Random.Range(-6f, 6f)
										);

			yield return new WaitForSeconds(secondsBetweenSpawns + Random.Range(-spawnTimeRandomness, spawnTimeRandomness));
		}
		Debug.Log("spawned all enemies");
		Disable();
	}

	private void Disable()
	{
		GameObject RangeIndicator = transform.Find("RangeIndicator").gameObject;
		Debug.Log("Fading out");
		StartCoroutine(FadeTo(RangeIndicator.GetComponent<Renderer>().material, 0f, 3f));
	}

	// Provided by DMGregory on StackExchange:
	// https://gamedev.stackexchange.com/questions/142791/how-can-i-fade-a-game-object-in-and-out-over-a-specified-duration
	// Define an enumerator to perform our fading.
	// Pass it the material to fade, the opacity to fade to (0 = transparent, 1 = opaque),
	// and the number of seconds to fade over.
	IEnumerator FadeTo(Material material, float targetOpacity, float duration) {
	   // Cache the current color of the material, and its initiql opacity.
	   Color color = material.color;
	   float startOpacity = color.a;

	   // Track how many seconds we've been fading.
	   float t = 0;

	   while(t < duration) {
	       // Step the fade forward one frame.
	       t += Time.deltaTime;
	       // Turn the time into an interpolation factor between 0 and 1.
	       float blend = Mathf.Clamp01(t / duration);

	       // Blend to the corresponding opacity between start & target.
	       color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

	       // Apply the resulting color to the material.
	       material.color = color;

	       // Wait one frame, and repeat.
	       yield return null;
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
