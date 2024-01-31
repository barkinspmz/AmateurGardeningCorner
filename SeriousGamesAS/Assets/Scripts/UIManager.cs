using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Singleton 
    public static UIManager Instance;
    public TextMeshProUGUI _objectiveText;
    public TextMeshProUGUI _timerText;
    public TextMeshProUGUI _planterPotText;
    public TextMeshProUGUI _waterCanText;
    public TextMeshProUGUI _getSeedText;

    public TextMeshProUGUI _waterCanTextSecond;
    public TextMeshProUGUI _planterPotTextSecond;
    public TextMeshProUGUI _timerTextSecond;

    public RawImage seedIcon;
    public RawImage seedEffect;

    public Image wateringBar;
    public Image wateringBarSecond;
    void Start()
    {
        Instance = this;
    }

}
