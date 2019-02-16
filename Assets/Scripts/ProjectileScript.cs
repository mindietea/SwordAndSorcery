using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem fireClone = Instantiate(fire, gameObject.transform.position, gameObject.transform.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
