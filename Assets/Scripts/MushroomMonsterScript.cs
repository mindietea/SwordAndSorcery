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
    public float sporeDuration = 2.0f;

    public float sporeRadius = 29.0f;

    public GameObject uiTint;

    // Should be Private but we make public for debugging :p
    public bool sporesActive = false;
    public float sporeTimer = 999.0f;

    Animation anim;

    void Start()
    {
        sporesActive = false;
        anim = GetComponent<Animation>();
        IdleAni();
    }

    void Update()
    {
        sporeTimer += Time.deltaTime;

        if(sporeTimer >= sporeDuration)
        {
            sporesActive = false;
        }

        if(sporeTimer >= sporeFrequency)
        {
            sporesActive = true;
            AttackAni();
            sporeTimer = 0.0f;
            GetComponent<ParticleSystem>().Play();
        }

        // Check if player in spores
        if(sporesActive && Vector3.Distance(GameManager.GetPlayer().transform.position, transform.position) < sporeRadius)
        {
            uiTint.SetActive(true);
        } else
        {
            uiTint.SetActive(false);
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
