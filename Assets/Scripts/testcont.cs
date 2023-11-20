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
    }
    void Update()
    {
        grounded = Mover.isGrounded;
        Xmove = transform.forward * Input.GetAxis("Vertical");
        Zmove = transform.right * Input.GetAxis("Horizontal");
        Ymove.y += Manager.instance.gravity * Time.deltaTime;
        
        Mover.Move(speed * Time.deltaTime * (Xmove + Zmove));
        //constantly moving the player. When movement inputs are detected, Xmove and Zmove change
        //their values which causes the player to move since the values inside the Move() function have changed.
        
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Ymove.y += Mathf.Sqrt(-jumpStrength * Manager.instance.gravity);
        }
        Mover.Move(Ymove * Time.deltaTime);
        //constantly applying gravity to the player. When a jump input is detected, the value of Ymove changes,
        //cancelling out the force of gravity and allowing the player to move upwards.
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
    }
}
