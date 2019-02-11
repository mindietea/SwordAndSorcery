using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
	private Rigidbody rb;
	Animator anim;
	bool holdingDown;
    bool Attack;
	GameObject cube;
    


	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
    	anim = GetComponent<Animator>();
        cube = GameObject.FindWithTag("Cube");
    	
	}
	
	void FixedUpdate()
    {
   
    	float movehorizontal = Input.GetAxis("Horizontal");
    	float moveVertical = Input.GetAxis("Vertical");

    	Vector3 movement = new Vector3 (movehorizontal, 0.0f, moveVertical);

    	rb.AddForce(movement * speed);

    	if (movement != Vector3.zero) {
         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1F);
     	}
    }


   //Update is called once per frame

    void Update()
    {
 
        if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) )
        {
        	anim.SetInteger("CONDITION", 1);
        	holdingDown = true;

        }

        if (!Input.anyKey && holdingDown)
        {
            anim.SetInteger("CONDITION", 0);
            holdingDown = false;
            
        }


        if (Input.GetKey (KeyCode.G))
        {
        	anim.SetInteger("CONDITION", 4);
        	holdingDown = true;
            Attack = true;
            StartCoroutine(Example());
        }


        if (Input.GetKey (KeyCode.H))
        {
        	anim.SetInteger("CONDITION", 3);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Collider myCollider = other.contacts[0].thisCollider;
        
        if (other.contacts[0].thisCollider.gameObject.name == "Bip001 Spine1"){
            anim.SetInteger("CONDITION", 3);
        }

        if (other.contacts[0].thisCollider.gameObject.name == "mesh" && Attack == true && other.gameObject.CompareTag("Cube")){
            Debug.Log("DESTROY CUBE");
            Destroy(cube);
            Attack = false;
        }

    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        Attack = false;
        print("False after Freeze");
    }

}
