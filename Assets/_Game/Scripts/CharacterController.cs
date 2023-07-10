using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public float rotationSpeed = 200f;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       // rb.constraints = RigidbodyConstraints.FreezeRotation;  // Karakterin dönmesini engelle
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (VariableJoystick.activeMove == true)
        {
            //anim.SetBool("Run", true);
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction*speed*Time.fixedDeltaTime, ForceMode.Impulse);
        }
        


    }

}
