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

    //When the plant become more mature, the index will increase
    //the damaging more to plant.
    public int wateringDecreasingIndex;

    public bool firstGrowthSystem;

    public float currentWaterLevel;
    public float maxWaterLevel;
    public GameObject wateringBarGameObject;        
    void Start()
    {
        wateringBarGameObject.SetActive(true);
        currentWaterLevel = 50;
        maxWaterLevel = 100;
        UpdateTheWateringBar();
        wateringDecreasingIndex = 3;

        indexTimeToGrowthEachVersionOfPlant[0] = 10;
        indexTimeToGrowthEachVersionOfPlant[1] = 20;
        indexTimeToGrowthEachVersionOfPlant[2] = 30;    
        indexTimeToGrowthEachVersionOfPlant[3] = 40;

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
            currentWaterLevel -= wateringDecreasingIndex;
            UpdateTheWateringBar();
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
                if (indexOfVersion < 3)
                {
                    indexOfVersion++;
                    ChangingWateringAmountAfterGrowth();
                    ChangeVersionOfPlant();
                }
                else
                {
                    indexTimeToGrowthEachVersionOfPlant[indexOfVersion] = 0;
                }
            }
            if (currentWaterLevel<=0)
            {
                plantVersions[indexOfVersion].GetComponent<MeshRenderer>().material = materialBlack;
                if (firstGrowthSystem)
                {
                    UIManager.Instance._timerText.text = "Your plant dried up.";
                    UIManager.Instance._timerText.fontSize = 0.08F;
                }
                else
                {
                    UIManager.Instance._timerTextSecond.text = "Your plant dried up.";
                    UIManager.Instance._timerTextSecond.fontSize = 0.08F;
                }
                break;
            }
            if (currentWaterLevel >= 100)
            {
                plantVersions[indexOfVersion].GetComponent<MeshRenderer>().material = materialBlack;
                if (firstGrowthSystem)
                {
                    UIManager.Instance._timerText.text = "Your plant died. You watered too much";
                    UIManager.Instance._timerText.fontSize = 0.08F;
                }
                else
                {
                    UIManager.Instance._timerTextSecond.text = "Your plant died. You watered too much";
                    UIManager.Instance._timerTextSecond.fontSize = 0.08F;
                }
                break;
            }
        }
    }

    public void ChangingWateringAmountAfterGrowth()
    {
        switch (indexOfVersion)
        {
            case 0:
                wateringDecreasingIndex = 2;
                break;
            case 1:
                wateringDecreasingIndex = 4;
                break;
            case 2:
                wateringDecreasingIndex = 6;
                break;
        }
    }

    public void ChangeVersionOfPlant()
    {
        plantVersions[indexOfVersion-1].SetActive(false);
        plantVersions[indexOfVersion].SetActive(true);
    }

    public void UpdateTheWateringBar()
    {
        if (firstGrowthSystem)
        {
            UIManager.Instance.wateringBar.fillAmount = currentWaterLevel / maxWaterLevel;
        }
        else
        {
            UIManager.Instance.wateringBarSecond.fillAmount = currentWaterLevel / maxWaterLevel;
        }
    }

}
