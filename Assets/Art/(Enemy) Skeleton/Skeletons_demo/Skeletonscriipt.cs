using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletonscriipt : MonoBehaviour
{

	Animator anim;
	bool holdingDown;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.W))
        {
        	anim.SetInteger("cond", 1);
        	holdingDown = true;
        }

         if (!Input.anyKey && holdingDown)
         {
             anim.SetInteger("cond", 0);
             holdingDown = false;
         }


        if (Input.GetKey (KeyCode.A))
        {
        	anim.SetInteger("cond", 2);
        	holdingDown = true;
        }


        if (Input.GetKey (KeyCode.D))
        {
        	anim.SetInteger("cond", 3);
        	holdingDown = true;
        }

        
    }
}
