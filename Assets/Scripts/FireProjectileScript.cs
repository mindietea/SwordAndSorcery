using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Add this script to an object that shall be able to fire projectiles.
 * The spawnpoint can be specified in the inspector, should probably be set to the gameobject's.
 */
public class FireProjectileScript : VRTK.VRTK_InteractableObject
{
    public Rigidbody projectile;
    public Transform spawnpoint;
    public int speed = 10;

    private VRTK.VRTK_ControllerEvents controllerEvents;

    public override void Grabbed(VRTK.VRTK_InteractGrab currentGrabbingObject)
    {
        base.Grabbed(currentGrabbingObject);
        Debug.Log("Grabbed");
        controllerEvents = currentGrabbingObject.GetComponent<VRTK.VRTK_ControllerEvents>();
    }

    public override void StartUsing(VRTK.VRTK_InteractUse currentUsingObject)
    {
        Debug.Log("START USING");
        base.StartUsing(currentUsingObject);
        FireProjectile();
        VRTK.VRTK_ControllerHaptics.TriggerHapticPulse(VRTK.VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject), 0.63f, 0.2f, 0.01f);
       
    }

    void FireProjectile()
    {
        Rigidbody fireball;
        Vector3 pos_adjustment = Vector3.forward * 1.5f;
        // Instantiate fireball at the spawnpoint position, adjusted by a Vector3
        fireball = Instantiate(projectile, spawnpoint.position ,
            spawnpoint.rotation);
        fireball.velocity = spawnpoint.TransformDirection(Vector3.up * speed);
    }
}
