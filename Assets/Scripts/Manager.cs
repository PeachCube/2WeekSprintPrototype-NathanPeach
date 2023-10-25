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
    //in the inspector, gravity is set to -9.81. In-game, nothing that uses "gravity" from the
    //manager script accelerates, and this isn't how gravity works in real life, but I'm fine with
    //how I have this set up for now.
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
                Destroy(gameObject);
    }
    void Start()
    {
        SetGemCount(0);
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
