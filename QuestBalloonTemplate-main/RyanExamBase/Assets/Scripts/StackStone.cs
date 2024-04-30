using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 

public class StackStone : MonoBehaviour 
{
  
    public AudioSource source; 
    public AudioClip clip; 
    public ScoreKeeper scoreKeeper;
    public Text Zenscore;
    public Text Score;

    private float cooldown = 0.5f; // cooldown duration between score increases
    private float lastCollisionTime = -1; // Private float to track the time of the last collision that resulted in a score increment

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.name == "CustomHandRight" && (Time.time - lastCollisionTime > cooldown))  //https://discussions.unity.com/t/if-collision-happned-2-times-in-2-seconds-play-sound/215898
        // Checkif the time since the last valid collision exceeds the cooldown period
        //if Time since the start minus the time from the last collision is greater than the cool down period then execute
        {
            source.PlayOneShot(clip); 
            scoreKeeper.IncrementRockScore();
            lastCollisionTime = Time.time; // Update the lastCollisionTime to the current time
        }
    }
}
