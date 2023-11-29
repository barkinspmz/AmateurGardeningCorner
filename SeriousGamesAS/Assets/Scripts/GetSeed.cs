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
            StartCoroutine(WritingInfosToCanvas("You get your seed"));
            UIManager.Instance._objectiveText.text = "Planting this seed into the pot on table";
            UIManager.Instance.seedIcon.enabled = true;
            UIManager.Instance.seedEffect.enabled = true;
        }
        else
        {
            StartCoroutine(WritingInfosToCanvas("You got your seed already"));
        }
    }

    IEnumerator WritingInfosToCanvas(string text)
    {
        UIManager.Instance._getSeedText.text = text;
        yield return new WaitForSeconds(3f);
        UIManager.Instance._getSeedText.text = "";
    }
}
