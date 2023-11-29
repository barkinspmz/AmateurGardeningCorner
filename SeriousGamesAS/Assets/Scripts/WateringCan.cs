using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour, IInteractable
{
    [SerializeField] private string animationName;
    private Animator _animator;

    [SerializeField] private GrowthSystem _growthSystemThatRelevant;
    [SerializeField] private PlantSeed seedPlanter;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {

    }

    public void Interact()
    {
        if (!seedPlanter.isThisPotEmpty)
        {
            _animator.SetTrigger(animationName);
            _growthSystemThatRelevant.wateringRequirementIndexToGrow--;
            if (_growthSystemThatRelevant.wateringRequirementIndexToGrow <= 0)
            {
                if (_growthSystemThatRelevant.indexOfVersion < 4)
                {
                    _growthSystemThatRelevant.indexOfVersion++;
                    _growthSystemThatRelevant.ChangingWateringAmountAfterGrowth();
                    _growthSystemThatRelevant.ChangeVersionOfPlant();
                }
            }

        }
        else
        {
            StartCoroutine(WritingInfosToCanvas("There is no any planted seed."));
        }

    }
    IEnumerator WritingInfosToCanvas(string text)
    {
        UIManager.Instance._waterCanText.text = text;
        yield return new WaitForSeconds(3f);
        UIManager.Instance._waterCanText.text = "";
    }
}
