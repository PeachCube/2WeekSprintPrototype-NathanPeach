using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Manager : MonoBehaviour
{
    static public Manager instance = null;
    public int gems = 0;
    public TextMeshProUGUI Gems;
    public float gravity;

    void Awake()
    {
        SetGemCount(0);
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
    public void SetGemCount(int value)
    {
        gems += value;
        Gems.text = "" + gems.ToString();
    }

}
