using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthSystem : MonoBehaviour
{
    public GameObject[] plantVersions;
    public int indexOfVersion;
    public int timer;
    [SerializeField] private Material materialBlack;
    void Start()
    {
        StartCoroutine(GrowthSystemTimer());
        indexOfVersion = 0;
        plantVersions[indexOfVersion].SetActive(true);
    }

    
    void Update()
    {
        
    }

    IEnumerator GrowthSystemTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (timer<=0)
            {
                plantVersions[indexOfVersion].GetComponent<MeshRenderer>().material = materialBlack;
                Debug.Log("Time is done.");
            }
        }
    }
}
