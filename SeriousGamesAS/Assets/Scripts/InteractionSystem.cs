using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform interactorSource;
    public float interactionRange;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactionRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObj))
                {
                    interactableObj.Interact();
                }
            }
        }
    }
}
