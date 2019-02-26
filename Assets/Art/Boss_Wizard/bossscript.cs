using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossscript : MonoBehaviour
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
        	anim.SetInteger("Cond", 1);
        	holdingDown = true;
        }

 
         if (!Input.anyKey && holdingDown)
         {
             anim.SetInteger("Cond", 0);
             holdingDown = false;
         }


        if (Input.GetKey (KeyCode.A))
        {
        	anim.SetInteger("Cond", 2);
        	holdingDown = true;
        }

        if (Input.GetKey (KeyCode.S))
        {
        	anim.SetInteger("Cond", 3);
        	holdingDown = true;
        }
        	

        if (Input.GetKey (KeyCode.D))
        {
        	anim.SetInteger("Cond", 4);
        	holdingDown = true;
        }
        	
    }

}
