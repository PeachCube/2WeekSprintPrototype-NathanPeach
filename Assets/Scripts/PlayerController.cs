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
    public float speed=10f;
    private bool jumping = false;
    public float jumpStrength=5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Manager.instance.gems = 0;
        Manager.instance.SetGemCount();
    }
    void FixedUpdate()
    {
        //declares variable "inputX", which gets its value from the player input. Pressing "a" = -x, pressing "d" = +x.
        float inputX = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal")==true)
        {
            gameObject.transform.Translate(new Vector3(inputX*speed,0,0) * Time.deltaTime);      
        }
        //same as inputX but for the z axis instead.
        float inputZ = Input.GetAxis("Vertical");
        if (Input.GetButton("Vertical") == true)
        {
            gameObject.transform.Translate(new Vector3(0, 0, inputZ * speed) * Time.deltaTime);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            jumping = true;
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
            Manager.instance.gems += 1;
            Manager.instance.SetGemCount();
        }
    }
}
