using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletonscriipt : MonoBehaviour
{
	public float speed;
	Rigidbody rb;
	Animator anim;
	bool holdingDown;

	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
    	anim = GetComponent<Animator>();

	}
	
	void FixedUpdate()
    {
   
    	float movehorizontal = Input.GetAxis("Horizontal");
    	float moveVertical = Input.GetAxis("Vertical");

    	Vector3 movement = new Vector3 (movehorizontal, 0.0f, moveVertical);

    	rb.AddForce(movement * speed);
    }


    // Update is called once per frame
    // void Update()
    // {
 
    //     if (Input.GetKey (KeyCode.W))
    //     {
    //     	anim.SetInteger("cond", 1);
    //     	holdingDown = true;
    //     }

    //     if (!Input.anyKey && holdingDown)
    //     {
    //         anim.SetInteger("cond", 0);
    //         holdingDown = false;
    //     }


    //     if (Input.GetKey (KeyCode.A))
    //     {
    //     	anim.SetInteger("cond", 2);
    //     	holdingDown = true;
    //     }


    //     if (Input.GetKey (KeyCode.D))
    //     {
    //     	anim.SetInteger("cond", 3);
    //     	holdingDown = true;
    //     }
        
    // }

}
