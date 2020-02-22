﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }


    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting");
            rigidBody.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKey(KeyCode.D) && ! Input.GetKey(KeyCode.A))
        {
            print("Rotating Right");
            transform.Rotate(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            print("Rotating Left");
            transform.Rotate(-Vector3.forward);
        }
    }

}