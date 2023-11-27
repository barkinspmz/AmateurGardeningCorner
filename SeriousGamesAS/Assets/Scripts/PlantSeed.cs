using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour, IInteractable
{
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Interact()
    {
        if (PlayersCondition.Instance.isPlayerGetSeed && !PlayersCondition.Instance.isPlayerGetPlanted)
        {
            PlayersCondition.Instance.isPlayerGetPlanted = true;
            GameObject.Find("GrowthSystem").SetActive(true);
        }
        if (!PlayersCondition.Instance.isPlayerGetSeed)
        {
            Debug.Log("You do not have any seed to plant.");
        }
    }
}
