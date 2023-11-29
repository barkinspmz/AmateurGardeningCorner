using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingExitMech : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform exitSittingPos;
    public void Start()
    {
        
    }
    public void Interact()
    {
        var player = GameObject.Find("FPS_Player");
        if (player != null) {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;   
            player.transform.position = exitSittingPos.position;
            player.transform.rotation = exitSittingPos.rotation;
            player.GetComponent<FPSController>().canMove = true;
            this.gameObject.SetActive(false);
        }
    }
}
