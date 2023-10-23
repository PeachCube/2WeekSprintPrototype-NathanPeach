using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=5f;
    private bool jumping = false;
    public float jumpStrength=5f;
    public AudioSource gemSFX;

    void Start()
    {
        gemSFX = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        {
            gameObject.transform.Translate(movement * speed * Time.smoothDeltaTime);
            if (movement.sqrMagnitude > 1.0f)
                movement.Normalize();
        }
        //declares variable "inputX", which gets its value from the player input. Pressing "a" = -x, pressing "d" = +x.
        //float inputX = Input.GetAxis("Horizontal");
        //if (Input.GetButton("Horizontal")==true)
        //{
        //gameObject.transform.Translate(new Vector3(inputX*speed,0,0) * Time.smoothDeltaTime);      
        //}
        //same as inputX but for the z axis instead.
        //float inputZ = Input.GetAxis("Vertical");
        //if (Input.GetButton("Vertical") == true)
        //{
        //gameObject.transform.Translate(new Vector3(0, 0, inputZ * speed) * Time.smoothDeltaTime);
        //}
    }
    private void Update()
    {
        speed = 5;
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up*jumpStrength, ForceMode.Impulse);
            jumping = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) && jumping == false)
        {
            speed = 10;
        }
            else
            {
            speed = 5;
            }
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumping = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            Manager.instance.SetGemCount(1);
            gemSFX.Play(0);
        }
        if (other.CompareTag("GemII"))
        {
            Manager.instance.SetGemCount(5);
            gemSFX.Play(0);
        }
        if (other.CompareTag("GemIII"))
        {
            Manager.instance.SetGemCount(20);
            gemSFX.Play(0);
        }
    }
}
