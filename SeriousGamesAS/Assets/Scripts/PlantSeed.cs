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
            StartCoroutine(WritingInfosToCanvas("This pot is full! Try to plant on other pots."));
        }
        if (PlayersCondition.Instance.isPlayerGetSeed && isThisPotEmpty)
        {
            PlayersCondition.Instance.isPlayerGetSeed = false;
            growthSystemObj.SetActive(true);
            isThisPotEmpty = false;
        }
        if (!PlayersCondition.Instance.isPlayerGetSeed&&isThisPotEmpty)
        {
            StartCoroutine(WritingInfosToCanvas("You do not have any seed to plant."));
        }
    }

    IEnumerator WritingInfosToCanvas(string text)
    {
        UIManager.Instance._planterPotText.text = text;
        yield return new WaitForSeconds(3f);
        UIManager.Instance._planterPotText.text = "";
    }
}
