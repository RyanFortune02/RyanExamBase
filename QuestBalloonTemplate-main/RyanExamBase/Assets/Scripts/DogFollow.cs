using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogFollow : MonoBehaviour
{
    public GameObject Player;
    public float Dis;
    public Transform target;
    public Animator animator;


    public AudioSource source;
    public AudioClip clip;
    public ScoreKeeper scoreKeeper;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }





    void Update()
    {
        Dis = Vector3.Distance(transform.position, Player.transform.position);

        if (Dis >= 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 5 * Time.deltaTime);
            animator.Play("DogWalk");
            if (target != null)
            {
                transform.LookAt(target);

            }


        }



    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CustomHandRight")
        {
            gameObject.GetComponent<Animator>().Play("DogPet");
            //scoreKeeper.IncrementDogScore();
            source.PlayOneShot(clip);
        }

    }

    public void OnCollisionExit(Collision collision)
    {
        source.Stop();
    }




}

