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
    private float speed = 2f;
    private bool jumping = false;
    public float jumpStrength=10f;
    public AudioSource gemSFX;
    private Vector3 velocity;
    void Start()
    {
        gemSFX = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        velocity = GetComponent<Rigidbody>().velocity;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (movement.sqrMagnitude > 1.0f)
        { 
            movement.Normalize(); 
        }
        rb.AddRelativeForce(movement * speed, ForceMode.VelocityChange);
    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up*jumpStrength, ForceMode.Impulse);
            jumping = true;
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && jumping == false)
        {
            speed = 3;
        }
            else
            {
            speed = 2;
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
            gemSFX.pitch = 1;
            gemSFX.Play(0);
        }
        if (other.CompareTag("GemII"))
        {
            Manager.instance.SetGemCount(5);
            gemSFX.pitch = 1.2f;
            gemSFX.Play(0);
        }
        if (other.CompareTag("GemIII"))
        {
            Manager.instance.SetGemCount(20);
            gemSFX.pitch = 1.4f;
            gemSFX.Play(0);
        }
    }
}
