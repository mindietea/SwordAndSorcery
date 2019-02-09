using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadSkeletonScript : MonoBehaviour
{

    // Range at which will pursue player
    public float pursuitRange = 10.0f;
    public float attackRange = 2.0f;
    public float runSpeed = 10.0f;

    // Animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("PursuitRange", GameManager.GetDistanceToPlayer(gameObject) <= pursuitRange);
        anim.SetBool("AttackRange", GameManager.GetDistanceToPlayer(gameObject) <= attackRange);
        
    }

    void FixedUpdate()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            // Rotate to look at player NOT allowing X rotation
            transform.LookAt(GameManager.GetPlayer().transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * runSpeed);
        }
    }
}
