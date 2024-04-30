using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockHand : OVRGrabbable
{

    public ScoreKeeper scoreKeeper;
    public AudioSource source;
    public AudioClip clip;
    public Text ZenScoreText;
    public Text RockScoreText;

    override public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity); //calls original grabend method
        source.PlayOneShot(clip); //plays rock sound
        scoreKeeper.IncrementRockScore();  //increases score after each grab of rock
    }
}
