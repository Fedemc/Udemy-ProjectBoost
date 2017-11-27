using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody rigidBody;
    private AudioSource audioSource; 

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            print("Space pressed");
            rigidBody.AddRelativeForce(Vector3.up);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
        else
        {
            audioSource.Stop();
        }


        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

    }
}
