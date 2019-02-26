	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	/*
	 * A generic class that can be placed on anything.
	 * Make sure to define the tags that can cause damage to this object! In "damageTags"
	 * Also make sure that anything that should be able to deal damage has a DamageScript on it.
	 */
	public class HealthScript : MonoBehaviour
	{

		protected GameObject healthCanvas;
		protected Text healthText;
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

	void Update()
	{
		lastDamaged += Time.deltaTime;
		// UpdateHealth();
	}

	// void UpdateHealth(){
	// 	healthText.text = "Health: " + currentHealth;
	// }

	public void InflictDamage(int dmg)
	{
		currentHealth = Mathf.Max(0, currentHealth -= dmg);
        Debug.Log(this.gameObject.name + " Health: " + currentHealth);
    }

    public void HealDamage(int heal)
	{
		currentHealth = Mathf.Min(maxHealth, currentHealth += heal);
	}

	private void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts){
			// Debug.Log(contact.thisCollider.name + " hit " + contact.otherCollider.name);

			if(contact.otherCollider.name == "Player" || contact.thisCollider.name == "Player"){
				// Debug.Log("This Collider, " + contact.thisCollider.name + " Collided with other Collider, " + contact.otherCollider.name);
				// Debug.Log("Player Hit By Enemy");
				// Debug.Log("Printing: " + collision.gameObject);
				CheckDamage(collision.gameObject);
			}

			if(contact.otherCollider.name == "Bip001 Spine1" || contact.thisCollider.name == "Bip001 Spine1"){
				// Debug.Log("This Collider, " + contact.thisCollider.name + " Collided with other Collider, " + contact.otherCollider.name);
				// Debug.Log("Enemy Hit By Player");
				// Debug.Log("Printing: " + collision.gameObject);
				CheckDamage(collision.gameObject);
			}

            if(contact.otherCollider.name == "Zombie" || contact.thisCollider.name == "Zombie")
            {
                CheckDamage(collision.gameObject);
            }

             if(contact.otherCollider.name == "Bone_L_hand" || contact.thisCollider.name == "Bone_L_hand" || contact.otherCollider.name == "Bone_R_hand" || contact.thisCollider.name == "Bone_R_hand")
            {
                CheckDamage(collision.gameObject);
            }


        }
    }

	// private void OnTriggerEnter(Collider other)
	// {
	// 	CheckDamage(other.gameObject);
	// }

	private void CheckDamage(GameObject other)
	{
		// Deals damage if it is one of the damageTags
		// Debug.Log(this.gameObject.name + " : " + other.gameObject.name + " " + other.tag);
		if (lastDamaged >= damageCooldown && damageTags.Contains(other.tag))
        {
            DamageScript dmgScript = other.GetComponent<DamageScript>();
			if (dmgScript != null)
			{
				// Take Damage
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
