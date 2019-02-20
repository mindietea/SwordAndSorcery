using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMonsterScript : MonoBehaviour
{
    private const string IDLE = "Idle";
    private const string RUN = "Run";
    private const string ATTACK = "Attack";
    private const string DAMAGE = "Damage";
    private const string DEATH = "Death";

    public float sporeFrequency = 3.0f;
    private float sporeTimer = 999.0f;

    public float sporeRadius = 29.0f;

    Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        IdleAni();
    }

    void Update()
    {
        sporeTimer += Time.deltaTime;

        if(sporeTimer >= sporeFrequency)
        {
            AttackAni();
            sporeTimer = 0.0f;
            GetComponent<ParticleSystem>().Play();
        }

        if(Vector3.Distance(GameManager.GetPlayer().transform.position, transform.position) < sporeRadius)
        {
            Debug.Log("sporin");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sporeRadius);
    }

    public void IdleAni()
    {
        anim.CrossFade(IDLE);
    }

    public void RunAni()
    {
        anim.CrossFade(RUN);
    }

    public void AttackAni()
    {
        anim.CrossFade(ATTACK);
    }

    public void DamageAni()
    {
        anim.CrossFade(DAMAGE);
    }

    public void DeathAni()
    {
        anim.CrossFade(DEATH);
    }
}
