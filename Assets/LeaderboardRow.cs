using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRow : MonoBehaviour
{
    public Text playerText;
    public Text placeText;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initiate(string player, string place)
    {
        playerText.text = player;
        placeText.text = place;
        panel.SetActive(true);
    }
}
