using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollectable : MonoBehaviour
{
    public GameObject player;
    private float min;
    private float max;
    void Start()
    {
        min = gameObject.transform.position.y;
        max = gameObject.transform.position.y + 0.25f;
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,60,0)*Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*0.2f, max - min)+ min , transform.position.z);
    }
    private void OnTriggerEnter(Collider player)
    {
        gameObject.SetActive(false);
    }
}
