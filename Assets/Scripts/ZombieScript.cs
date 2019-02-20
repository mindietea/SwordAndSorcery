using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public float pursuitRange = 10.0f;
    public float attackRange = 2.0f;
    public float hordeRange = 40.0f;
    public float runSpeed = 2.0f;
    public float walkSpeed = 0.5f;
    public float randomWalkTime = 0.1f;
    bool isInPursuit = false;
    GameObject following = null;
    private float time = 0.0f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("AttackRange", GameManager.GetDistanceToPlayer(gameObject) <= attackRange);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk_in_place"))
        {
            if (GameManager.GetDistanceToPlayer(gameObject) <= pursuitRange)
            {
                if (!isInPursuit)
                {
                    isInPursuit = true;
                    AlertHorde();
                }

                // Rotate to look at player NOT allowing X rotation
                transform.LookAt(GameManager.GetPlayer().transform);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

                GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * runSpeed);
            }
            else if(following != null)
            {
                if (isInPursuit)
                {
                    isInPursuit = false;
                }

                if (following.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("walk_in_place") && 
                    following.GetComponent<ZombieScript>().isInPursuit)
                {
                    transform.LookAt(following.transform);
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

                    GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * runSpeed);
                }
                else
                {
                    following = null;
                }
            }
            else
            {
                if (isInPursuit)
                {
                    isInPursuit = false;
                }

                // At random times, look at another zombie (creates hordes)
                if (Random.value > 0.998)
                {
                    transform.LookAt(FindZombie());
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
                }

                // At even intervals of time, randomly change direction
                if (time >= randomWalkTime)
                {
                    time -= randomWalkTime;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                        transform.eulerAngles.y + Random.Range(-10.0f, 10.0f),
                        transform.eulerAngles.z);
                }

                GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * walkSpeed);
            }
        }
    }
     
    // Finds the transform of the zombie which is the furthest away, but within hordeRange and alive
    Transform FindZombie()
    {
        float furthestDist = 0.0f;
        Transform furthest = null;

        foreach(GameObject zombie in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            float dist = Vector3.Distance(transform.position, zombie.transform.position);
            if (dist > furthestDist && dist < hordeRange)
            {
                if(zombie.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("walk_in_place"))
                {
                    furthestDist = dist;
                    furthest = zombie.transform;
                }
            }
        }

        return furthest;
    }

    // Makes other nearby zombies follow this one
    void AlertHorde()
    {
        foreach (GameObject zombie in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            float dist = Vector3.Distance(transform.position, zombie.transform.position);
            if (dist < hordeRange &&
                zombie.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("walk_in_place") &&
                zombie.GetComponent<ZombieScript>().following == null)
            {
                zombie.GetComponent<ZombieScript>().following = gameObject;
            }
        }
    }
}
