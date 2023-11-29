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
    public RawImage seedIcon;
    public RawImage seedEffect;
    void Start()
    {
        Instance = this;
    }

    
    void Update()
    {
        
    }
}
