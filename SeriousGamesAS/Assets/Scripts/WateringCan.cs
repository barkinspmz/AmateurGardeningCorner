using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Watering : MonoBehaviour, IInteractable
{
    [SerializeField] private string animationName;
    private Animator _animator;

    [SerializeField] private GrowthSystem _growthSystemThatRelevant;
    [SerializeField] private PlantSeed seedPlanter;

    public ParticleSystem particleWatering;
    public bool isFirstCan;
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
            StartCoroutine(ParticleFallingNumerator());
            UIManager.Instance._objectiveText.text = "You learned the basic loop.";
            _growthSystemThatRelevant.currentWaterLevel += 25;
        }
        else
        {
            StartCoroutine(WritingInfosToCanvas("There is no any planted seed."));
        }

    }
    IEnumerator WritingInfosToCanvas(string text)
    {
        if (isFirstCan)
        {
            UIManager.Instance._waterCanText.text = text;
            yield return new WaitForSeconds(3f);
            UIManager.Instance._waterCanText.text = "";
        }
        else
        {
            UIManager.Instance._waterCanTextSecond.text = text;
            yield return new WaitForSeconds(3f);
            UIManager.Instance._waterCanTextSecond.text = "";
        }
       
    }

    IEnumerator ParticleFallingNumerator()
    {
        yield return new WaitForSeconds(0.8f);
        particleWatering.Play();
        yield return new WaitForSeconds(1.7f);
        particleWatering.Stop();
    }
}

