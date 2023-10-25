using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int bIndex;
    private void Start()
    {
        SceneManager.LoadScene(bIndex);
    }
}
