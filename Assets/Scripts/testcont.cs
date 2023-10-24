using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcont : MonoBehaviour
{
    private Vector3 manualRotation;
    CharacterController m_CharacterController;
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*Time.smoothDeltaTime;
        m_CharacterController.Move(move*2);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Rotate(manualRotation * -1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Rotate(manualRotation * 1 * Time.deltaTime);
        }
    }
}
