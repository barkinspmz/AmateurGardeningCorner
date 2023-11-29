using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour, IInteractable
{
    [SerializeField] private string animationName;
    private Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void Interact()
    {
        _animator.SetTrigger(animationName);
    }
}
