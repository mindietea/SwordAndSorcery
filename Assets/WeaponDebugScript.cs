using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDebugScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Collider myCollider = other.contacts[0].thisCollider;
        Debug.Log("Weapon COllision Happened: " + other.contacts[0].thisCollider.gameObject.name);
       

    }
}
