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
        //basic toggle system; if escape is pressed and the current state of pause is false,
        //activate the pause menu and set the time scale to 0.
        //if the first check fails, use the else if statement to check for the escape
        //key being pressed and the current state of pause, then deactivate the pause menu and
        //set the time scale back to normal.
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
