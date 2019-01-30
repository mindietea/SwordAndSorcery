using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveMarkerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = transform.position;
        sphere.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

        GameObject monster = SpawnMonster();
        monster.transform.position += new Vector3(0, 2.0f, 0);
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
        
    }
}
