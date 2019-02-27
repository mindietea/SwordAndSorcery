using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScript : VRTK.VRTK_InteractableObject

{

    private VRTK.VRTK_ControllerEvents controllerEvents;
    public AudioSource voiceOverAudio;
    public AudioClip youMakeLaughClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Grabbed(VRTK.VRTK_InteractGrab currentGrabbingObject)
    {

        Debug.Log("Hello darkness my old friend");
        base.Grabbed(currentGrabbingObject);
        voiceOverAudio.Stop();
        voiceOverAudio.clip = youMakeLaughClip;
        voiceOverAudio.Play();
    }

    public override void StartUsing(VRTK.VRTK_InteractUse currentUsingObject)
    {
        Debug.Log("Hello darkness my old friend");
        base.StartUsing(currentUsingObject);
        voiceOverAudio.Stop();
        voiceOverAudio.clip = youMakeLaughClip;
        voiceOverAudio.Play();
       

    }
}
