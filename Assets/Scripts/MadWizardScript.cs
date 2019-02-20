using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadWizardScript : MonoBehaviour
{
    // Range at which will pursue player
    public float pursuitRange = 10.0f;
    public float attackRange = 2.0f;
    public float runSpeed = 10.0f;
    public int outofrange = 5; 

    public bool dead = false;
    float PrevHealth;
	Vector3 originalPos;   
    // Animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        dead = false;
        PrevHealth = GetComponent<HealthScript>().currentHealth;
        originalPos = transform.position;
        Debug.Log(originalPos);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("PursuitRange", GameManager.GetDistanceToPlayer(gameObject) <= pursuitRange);
        anim.SetBool("AttackRange", GameManager.GetDistanceToPlayer(gameObject) <= attackRange);
        
         if(!dead && GetComponent<HealthScript>().currentHealth != PrevHealth) {
         	PrevHealth = GetComponent<HealthScript>().currentHealth;
            anim.SetTrigger("Damage");
        }

        if(!dead && GetComponent<HealthScript>().currentHealth <= 0) {
            dead = true;
            anim.SetBool("Death", true);
            Debug.Log("Enemy Dead");
        }

    }

    void FixedUpdate()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("move_forward_fast"))
        {
            // Rotate to look at player NOT allowing X rotation
            transform.LookAt(GameManager.GetPlayer().transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * runSpeed);
        }


        if(this.transform.position.x >= (originalPos.x + outofrange) || this.transform.position.x <= (originalPos.x - outofrange)){
         GetComponent<Rigidbody>().MovePosition(originalPos);
        }
    }
}
