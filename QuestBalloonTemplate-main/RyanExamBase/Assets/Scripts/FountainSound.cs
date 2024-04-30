using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(clip);


    }


    public void OnCollisionExit(Collision collision) 
    { 
        source.Stop();
    }

}
