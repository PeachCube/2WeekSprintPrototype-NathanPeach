using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitGameScript : MonoBehaviour
{
    public void Start()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
