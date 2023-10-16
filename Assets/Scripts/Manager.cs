using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Manager : MonoBehaviour
{
    static public Manager instance = null;
    public int gems;
    public TextMeshProUGUI Gems;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
                Destroy(gameObject);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SetGemCount()
    {
        Gems.text = "" + gems.ToString();
    }

}
