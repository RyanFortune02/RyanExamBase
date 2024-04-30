using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatCollision : MonoBehaviour
{

    public ScoreKeeper scoreKeeper;

    void OnCollisionEnter(Collision collision)
    {//Moved logic here to see if it worked to feed dog and it does!
        if (collision.gameObject.name == "Dog")
        { 
            scoreKeeper.IncrementDogScore();
            Destroy(gameObject);  // Destroy the treat


        }
    }
}
