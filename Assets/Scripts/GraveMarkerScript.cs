using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveMarkerScript : MonoBehaviour
{
    // Range at which to trigger enemy spawns
    public float range = 7.0f;

    public GameObject monster;
    public bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    GameObject SpawnMonster() {
        GameObject monster = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        monster.transform.position = transform.position;
        monster.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

        return monster;
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawned && GameManager.GetDistanceToPlayer(gameObject) < range)
        {
            spawned = true;
            GameObject spawn = Instantiate(monster);
            spawn.transform.position = transform.position + transform.forward * 2;
            spawn.transform.position = new Vector3(spawn.transform.position.x, -0.5f, spawn.transform.position.z);
        }
    }
}
