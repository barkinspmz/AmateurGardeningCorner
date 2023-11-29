using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    //Singleton 
    public static UIManager Instance;
    public TextMeshProUGUI _objectiveText;
    public TextMeshProUGUI _timerText;
    public TextMeshProUGUI _planterPotText;
    public TextMeshProUGUI _waterCanText;
    public TextMeshProUGUI _getSeedText;
    void Start()
    {
        Instance = this;
    }

    
    void Update()
    {
        
    }
}
