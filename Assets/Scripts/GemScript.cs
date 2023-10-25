using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private float min;
    private float max;
    public int value;
    void Start()
    {
        min = gameObject.transform.position.y;
        max = gameObject.transform.position.y + 0.25f;
    }
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,60,0)*Time.deltaTime,Space.World);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*0.2f, max - min)+ min , transform.position.z);
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Manager.instance.SetGemCount(value);
            gameObject.SetActive(false);
        }
    }
}
