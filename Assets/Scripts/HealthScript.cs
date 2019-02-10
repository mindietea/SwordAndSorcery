using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A generic class that can be placed on anything.
 * Make sure to define the tags that can cause damage to this object! In "damageTags"
 * Also make sure that anything that should be able to deal damage has a DamageScript on it.
 */
public class HealthScript : MonoBehaviour
{
    // Health variables
    public int currentHealth = 100;
    public int maxHealth = 100;

    // Number of seconds between instances of taking damage
    public float damageCooldown = 0.2f;

    // Timer for time in seconds since last damaged
    public float lastDamaged = 9999.0f;

    // The List of the names of tags that should be able to damage this gameObject
    public List<string> damageTags;

    // Used to affect hit indicator
    private Animator anim;
    private int damageHash = Animator.StringToHash("Damage");

    void Start()
    {
        currentHealth = maxHealth;
        lastDamaged = 9999.0f;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        lastDamaged += Time.deltaTime;
    }

    public void InflictDamage(int dmg)
    {
        currentHealth = Mathf.Max(0, currentHealth -= dmg);
    }

    public void HealDamage(int heal)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth += heal);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckDamage(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckDamage(other.gameObject);
    }

    private void CheckDamage(GameObject other)
    {
        // Deals damage if it is one of the damageTags
        if (lastDamaged >= damageCooldown && damageTags.Contains(other.tag))
        {
            DamageScript dmgScript = other.GetComponent<DamageScript>();
            if (dmgScript != null)
            {
                // Take Damage
                Debug.Log("Hit");
                InflictDamage(dmgScript.damage);
                lastDamaged = 0.0f;
                
                // Trigger damaged animation
                if(anim != null)
                {
                    anim.SetTrigger(damageHash);
                }
            }
            else
            {
                Debug.LogWarning(gameObject.name + " should take damage, but the damaging object, " + other.name + " has no DamageScript attached to it.");
            }
        }
    }
}
