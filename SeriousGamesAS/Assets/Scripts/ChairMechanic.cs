using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairMechanic : MonoBehaviour, IInteractable
{
    public GameObject player;
    public Transform positionThatPlayerStay;
    public GameObject hiddenLeaveWallToSitting;
    void Start()
    {
        
    }

    public void Interact()
    {
        player.transform.position = transform.position;
        player.transform.rotation = positionThatPlayerStay.rotation;
        player.gameObject.GetComponent<FPSController>().canMove = false;
        StartCoroutine(OpenHiddenWall());
    }

    IEnumerator OpenHiddenWall()
    {
        yield return new WaitForSeconds(1f);
        hiddenLeaveWallToSitting.SetActive(true);
    }
}
