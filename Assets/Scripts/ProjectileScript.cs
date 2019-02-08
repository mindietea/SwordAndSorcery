using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public ParticleSystem fireAnimation;
    private ParticleSystem fireClone;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        fireClone = Instantiate(fireAnimation, gameObject.transform.position, gameObject.transform.rotation);
        fireClone.transform.Rotate(0, 270, 90);
    }

    // Update is called once per frame
    void Update()
    {
        fireClone.transform.position = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidingObject = collision.gameObject;
        if(collidingObject.name == "Enemy")
        {
            // deal damage to enemy
        }
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

        var main = fireClone.main;
        main.stopAction = ParticleSystemStopAction.Destroy;
        fireClone.Clear();
        fireClone.Stop();
    }
}
