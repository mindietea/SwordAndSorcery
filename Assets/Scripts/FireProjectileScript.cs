using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileScript : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform spawnpoint;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Rigidbody fireball;
            fireball = Instantiate(projectile, spawnpoint.position + Vector3.up,
                spawnpoint.rotation);
            fireball.velocity = spawnpoint.TransformDirection(Vector3.forward * speed);
        }
    }
}
