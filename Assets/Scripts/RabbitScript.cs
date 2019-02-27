using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript : MonoBehaviour
{

    public float runSpeed = 1.0f;
    public float explosionRange = 2.0f;
    public ParticleSystem explosion;

    private Animator anim;

    AudioSource explosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (!anim.GetBool("Dead"))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                transform.eulerAngles.y + Random.Range(-10.0f, 10.0f),
                transform.eulerAngles.z);

            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * runSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!anim.GetBool("Dead") && collision.gameObject.tag == "Player")
        {
            anim.SetBool("Dead", true);
            Instantiate(explosion, gameObject.transform.position + Vector3.up, Quaternion.identity);
            explosionAudio.Play();
        }
    }
}
