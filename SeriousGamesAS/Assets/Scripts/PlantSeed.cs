using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour, IInteractable
{
    public bool isThisPotEmpty = true;
    public bool isFirstPot;
    [SerializeField] private GameObject growthSystemObj;
    public void Interact()
    {
        if (!isThisPotEmpty)
        {
            StartCoroutine(WritingInfosToCanvas("This pot is full! Try to plant on other pots."));
        }
        if (PlayersCondition.Instance.isPlayerGetSeed && isThisPotEmpty)
        {
            UIManager.Instance._objectiveText.text = "Water your plan with using water can.";
            PlayersCondition.Instance.isPlayerGetSeed = false;
            growthSystemObj.SetActive(true);
            UIManager.Instance.seedIcon.enabled = false;
            UIManager.Instance.seedEffect.enabled = false;
            isThisPotEmpty = false;
        }
        if (!PlayersCondition.Instance.isPlayerGetSeed&&isThisPotEmpty)
        {
            StartCoroutine(WritingInfosToCanvas("You do not have any seed to plant."));
        }
    }

    IEnumerator WritingInfosToCanvas(string text)
    {
        if (isFirstPot)
        {
            UIManager.Instance._planterPotText.text = text;
            yield return new WaitForSeconds(3f);
            UIManager.Instance._planterPotText.text = "";
        }
        else
        {
            UIManager.Instance._planterPotTextSecond.text = text;
            yield return new WaitForSeconds(3f);
            UIManager.Instance._planterPotTextSecond.text = "";
        }
    }
}
