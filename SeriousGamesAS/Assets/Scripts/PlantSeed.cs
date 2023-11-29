using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour, IInteractable
{
    public bool isThisPotEmpty = true;
    [SerializeField] private GameObject growthSystemObj;
    public void Interact()
    {
        if (!isThisPotEmpty)
        {
            Debug.Log("This pot is full! Try to plant on other pots.");
        }
        if (PlayersCondition.Instance.isPlayerGetSeed && isThisPotEmpty)
        {
            PlayersCondition.Instance.isPlayerGetSeed = false;
            growthSystemObj.SetActive(true);
            isThisPotEmpty = false;
        }
        if (!PlayersCondition.Instance.isPlayerGetSeed&&isThisPotEmpty)
        {
            Debug.Log("You do not have any seed to plant.");
        }
    }
}
