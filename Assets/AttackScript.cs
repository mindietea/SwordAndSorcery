using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameObject cube;

    void Start()
    {
        cube = GameObject.FindWithTag("Cube");
    	
     //    if (cube != null){
     //    	BoxCollider cubeMesh = cube.GetComponent<BoxCollider>();
     //    	Debug.Log("Get Component done");
     //    }
     //    else{
     //    	Debug.Log("Error getting gameobject cube");
     //    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with floor");
        if (other.gameObject.CompareTag("Cube")){
         Debug.Log("Detected Cube");
        }
      
        
    }
}
