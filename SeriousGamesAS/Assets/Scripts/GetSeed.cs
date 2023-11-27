using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSeed : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        if(!PlayersCondition.Instance.isPlayerGetSeed)
        {
            PlayersCondition.Instance.isPlayerGetSeed = true;
        }
        else
        {
            Debug.Log("You got your seed already");
        }
    }
}
