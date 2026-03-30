using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuText : MonoBehaviour
{
    public TextMeshProUGUI BestTime;
    public TextMeshProUGUI LastTime;


    void Start()
    {
        GameInfo.Load();

        if (GameInfo.BestTime != 0)
        {
            BestTime.text = "Best Time: " + GameInfo.BestTime;
            LastTime.text = "Last Time: " + GameInfo.LastTime;
        }
    }
}
