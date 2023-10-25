using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcont : MonoBehaviour
{
    private Vector3 manualRotation;
    CharacterController Mover;
    public float speed;
    public AudioSource gemSFX;
    private bool jumping;
    private bool running;
    void Start()
    {
        gemSFX = GetComponent<AudioSource>();
        Mover = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 Xmove = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 Zmove = transform.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector3 Ymove = new Vector3(0, gameObject.transform.position.y + Manager.instance.gravity, 0);
        Mover.Move(((Xmove + Zmove) * speed) + Ymove * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Rotate(manualRotation * -1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Rotate(manualRotation * 1 * Time.deltaTime);
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
