using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthSystem : MonoBehaviour
{
    public GameObject[] plantVersions;
    public int indexOfVersion;
    public int timer;
    [SerializeField] private Material materialBlack;

    private int[] indexTimeToGrowthEachVersionOfPlant = new int[4];

    public int wateringRequirementIndexToGrow;

    public bool firstGrowthSystem;
    void Start()
    {
        wateringRequirementIndexToGrow = 2;

        indexTimeToGrowthEachVersionOfPlant[0] = 15;
        indexTimeToGrowthEachVersionOfPlant[1] = 30;
        indexTimeToGrowthEachVersionOfPlant[2] = 45;    
        indexTimeToGrowthEachVersionOfPlant[3] = 60;

        StartCoroutine(GrowthSystemTimer());
        indexOfVersion = 0;
        plantVersions[indexOfVersion].SetActive(true);
    }

    IEnumerator GrowthSystemTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            indexTimeToGrowthEachVersionOfPlant[indexOfVersion]--;
            if (firstGrowthSystem)
            {
                UIManager.Instance._timerText.text = indexTimeToGrowthEachVersionOfPlant[indexOfVersion].ToString();
            }
            else
            {
                UIManager.Instance._timerTextSecond.text = indexTimeToGrowthEachVersionOfPlant[indexOfVersion].ToString();
            }
            
            if (indexTimeToGrowthEachVersionOfPlant[indexOfVersion]<=0)
            {
                plantVersions[indexOfVersion].GetComponent<MeshRenderer>().material = materialBlack;
                indexTimeToGrowthEachVersionOfPlant[indexOfVersion] = 0;
                Debug.Log("Time is done.");
                break;
            }
        }
    }

    public void ChangingWateringAmountAfterGrowth()
    {
        switch (indexOfVersion)
        {
            case 0:
                wateringRequirementIndexToGrow = 2;
                break;
            case 1:
                wateringRequirementIndexToGrow = 3;
                break;
            case 2:
                wateringRequirementIndexToGrow = 4;
                break;
        }
    }

    public void ChangeVersionOfPlant()
    {
        plantVersions[indexOfVersion-1].SetActive(false);
        plantVersions[indexOfVersion].SetActive(true);
    }
}
