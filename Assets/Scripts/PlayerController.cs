using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=10f;
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
        if (jumping == false)
        {
            gameObject.transform.Translate(movement * speed * Time.deltaTime);
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
        //if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        //{
            //rb.AddForce(Vector3.up*jumpStrength, ForceMode.Impulse);
            //jumping = true;
        //}
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
