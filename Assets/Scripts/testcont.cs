using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class testcont : MonoBehaviour
{
    CharacterController Mover;
    [SerializeField] private float speed;
    public AudioSource gemSFX;
    private float runSpeed;
    [SerializeField] private float jumpStrength = 4f;
    Vector3 Xmove;
    Vector3 Zmove;
    Vector3 Ymove;
    private bool grounded;
    void Start()
    {
        runSpeed = speed + 3;
        gemSFX = GetComponent<AudioSource>();
        Mover = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        if (grounded && Ymove.y < 0)
        {
            Ymove.y = 0;
        }
    //Prevents the value of Ymove.y from dropping into negative values while the player is grounded.
    }
    void Update()
    {
        grounded = Mover.isGrounded;//Mover.isGrounded detects collision with the ground, and returns a boolean value. 
        Xmove = transform.forward * Input.GetAxis("Vertical");
        Zmove = transform.right * Input.GetAxis("Horizontal");
        Ymove.y += Manager.instance.gravity * Time.deltaTime;
        
        Mover.Move(speed * Time.deltaTime * (Xmove + Zmove));
        //Mover.Move is constantly running because it's inside Update(), but will only move the player
        //when inputs are detected, because the values given to Mover.Move have changed from zero.
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Ymove.y += Mathf.Sqrt(-jumpStrength * Manager.instance.gravity);
        }
        Mover.Move(Ymove * Time.deltaTime);
        //Constantly applying gravity to the player. When a jump input is detected, and the player collider is touching the ground,
        //the value of Ymove changes, cancelling out the force of gravity and allowing the player to move upwards.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = runSpeed - 3;
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
        //Only handles the sound effects for collisions with gems. The source of the sound effect comes from
        //the player and not from the gems themselves.
    }
}
