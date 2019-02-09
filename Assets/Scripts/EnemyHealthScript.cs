using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

    // Health variables
    public int currentHealth = 100;
    public int maxHealth = 100;

    // Number of seconds between instances of taking damage
    public float damageCooldown = 0.2f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
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
        if(collision.gameObject.tag == "PlayerWeapon")
        {
            Debug.Log("Weapon hit");
        }
    }
}
