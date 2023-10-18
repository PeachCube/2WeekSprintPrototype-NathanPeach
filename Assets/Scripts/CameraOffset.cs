using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public GameObject player;
    //private Vector3 offset;
    private Vector3 manualRotation;
    void Start()
    {
        //offset = transform.position - player.transform.position;
        manualRotation.y = 180;
    }
    void Update()
    {
        //transform.position = player.transform.position + offset + new Vector3(0, 2, -3);
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
