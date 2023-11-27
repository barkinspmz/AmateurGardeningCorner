using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCondition : MonoBehaviour
{
    //Singleton will be used.
    public static PlayersCondition Instance;

    public bool isPlayerGetSeed = false;

    void Start()
    {
        Instance = this;
    }

}
