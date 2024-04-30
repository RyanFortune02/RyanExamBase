using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperFloat : OVRGrabbable
{
    public Light light;
    public ScoreKeeper scoreKeeper;

    override public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity); //calls original grabend method
        
        //Access Rigid body of lantern grabbed
        Rigidbody rb = GetComponent<Rigidbody>();
        //Make it float with gravity off and applying force upwards
        rb.useGravity = false;
        rb.AddForce(Vector3.up * 1f, ForceMode.VelocityChange); // Using ForceMode.VelocityChange to ensure consistent behavior
        //Increase light intensity to make it glow
        light.intensity = 3f;
        //Increase Lantern Score
        scoreKeeper.DecrementLanternScore();
    }
}
