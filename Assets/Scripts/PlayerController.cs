using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=10f;
    private bool jumping = false;
    public float jumpStrength=5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal")==true)
        {
            gameObject.transform.Translate(new Vector3(inputX*speed,0,0) * Time.deltaTime);      
        }
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


}
