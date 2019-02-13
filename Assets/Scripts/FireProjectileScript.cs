using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Add this script to an object that shall be able to fire projectiles.
 * The spawnpoint can be specified in the inspector, should probably be set to the gameobject's.
 */
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
        if(Input.GetKeyDown(KeyCode.LeftShift)) // TODO change to button on VR controller
        {
            Rigidbody fireball;
            Vector3 adjustment = Vector3.up;
            // Instantiate fireball at the spawnpoint position, adjusted by a Vector3
            fireball = Instantiate(projectile, spawnpoint.position + adjustment,
                spawnpoint.rotation);
            fireball.velocity = spawnpoint.TransformDirection(Vector3.forward * speed);
        }
    }
}
