using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (pause.activeSelf == false))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        else if ((pause.activeSelf == true) && Input.GetKeyDown(KeyCode.Escape))
             {
                 pause.SetActive(false);
                 Time.timeScale = 1;
             }  
    }
}
