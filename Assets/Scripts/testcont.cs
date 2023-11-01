using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class testcont : MonoBehaviour
{
    CharacterController Mover;
    public float speed;
    public AudioSource gemSFX;
    private bool jumping;
    private float runSpeed;
    void Start()
    {
        runSpeed = speed + 3;
        gemSFX = GetComponent<AudioSource>();
        Mover = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 Xmove = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 Zmove = transform.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector3 Ymove = new Vector3(0, gameObject.transform.position.y + Manager.instance.gravity, 0);
        Mover.Move(((Xmove + Zmove) * speed) + Ymove * Time.deltaTime);

        //if (Xmove + Zmove >= )
        //{

        //}
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            
            jumping = true;
        }
        if (Mover.collisionFlags == CollisionFlags.Below)
        {
            
            jumping = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && (jumping == false))
        {
            speed = runSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GemI"))
        {
            gemSFX.pitch = 1;
            gemSFX.Play(0);
        }
        if (other.CompareTag("GemII"))
        {
            gemSFX.pitch = 1.2f;
            gemSFX.Play(0);
        }
        if (other.CompareTag("GemIII"))
        {
            gemSFX.pitch = 1.4f;
            gemSFX.Play(0);
        }
    }
}
