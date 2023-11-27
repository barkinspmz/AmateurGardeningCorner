using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    //Singleton will be used.
    public static Players Instance;

    public bool isPlayerGetSeed = false;
    public bool isPlayerGetPlanted = false;

    void Start()
    {
        Instance = this;
    }

}
