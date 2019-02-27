using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MushroomMonsterScript : MonoBehaviour
{
    private const string IDLE = "Idle";
    private const string RUN = "Run";
    private const string ATTACK = "Attack";
    private const string DAMAGE = "Damage";
    private const string DEATH = "Death";

    // How often a spore puff is sent out
    public float sporeFrequency = 3.0f;
    // How long a spore puff lasts
    public float sporeDuration = 2.0f;
    // Range of spore puff
    public float sporeRadius = 29.0f;

    // An object that causes the screen to be purple when inside the spore puff
    public GameObject uiTint;

    // Poison colors
    public Color normalColor;
    public Color poisonedColor;
    public Color poisonDamageColor;

    // Player is in poison
    public bool poisoned = false;
    // Time between ticks of poison
    public float poisonFrequency = 1.0f;
    // Time for poison tick animation
    public bool poisonAnimationOn = false;
    public float poisonAnimationDuration = 0.2f;
    public float poisonAnimationTimer = 0.0f;
    // Damage for each poison tick
    public int poisonDamage = 2;
    // Timer for poison
    public float poisonTimer = 0.0f;
    public float burstTimeRandomness = 1.0f;

    // Should be Private but we make public for debugging :p
    public bool sporesActive = false;
    public float sporeTimer;

    Animation anim;

    void Start()
    {
        uiTint.GetComponent<Image>().color = normalColor;

        poisonAnimationTimer = 0.0f;
        poisonTimer = 0.0f;
        poisoned = false;
        sporesActive = false;
        anim = GetComponent<Animation>();
        IdleAni();

        sporeTimer = Random.Range(-burstTimeRandomness, burstTimeRandomness);

        uiTint = GameObject.FindGameObjectWithTag("UiTint");

    }

    void Update()
    {
 

        sporeTimer += Time.deltaTime;

        if (GetComponent<HealthScript>().currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(poisoned)
        {
            poisonTimer += Time.deltaTime;
            PoisonTick();
        }

        if(poisonAnimationOn)
        {
            poisonAnimationTimer += Time.deltaTime;
        }

        if(sporeTimer >= sporeDuration)
        {
            sporesActive = false;
            IdleAni();
        }

        if (sporeTimer >= sporeFrequency)
        {
            sporesActive = true;
            AttackAni();
            sporeTimer = Random.Range(-burstTimeRandomness, burstTimeRandomness);
            GetComponent<ParticleSystem>().Play();
        }

        // Check if player is poisoned
        if (!poisoned && sporesActive && (GameManager.GetDistanceToPlayer(gameObject) < sporeRadius))
        {
            StartPoison();
        }

        if(poisoned && (!sporesActive || (GameManager.GetDistanceToPlayer(gameObject) > sporeRadius)))
        {
            EndPoison();
        }

    }

    private void StartPoison()
    {
        poisoned = true;
        poisonTimer = 0.0f;
    }

    private void PoisonTick()
    {
        // Inflict poison damage and start poison animation
        if(poisonTimer >= poisonFrequency)
        {
            GameManager.GetPlayer().GetComponent<HealthScript>().InflictDamage(poisonDamage);
            poisonTimer = 0.0f;
            poisonAnimationTimer = 0.0f;
            poisonAnimationOn = true;
            
            uiTint.GetComponent<Image>().color = poisonedColor;
        }

        // End poison animation
        if (poisonAnimationOn && poisonAnimationTimer >= poisonAnimationDuration)
        {
            poisonAnimationOn = false;
            uiTint.GetComponent<Image>().color = poisonDamageColor;
        }
    }

    private void EndPoison()
    {
        poisoned = false;
        poisonAnimationOn = false;
        uiTint.GetComponent<Image>().color = normalColor;
        poisonTimer = 0.0f;

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
