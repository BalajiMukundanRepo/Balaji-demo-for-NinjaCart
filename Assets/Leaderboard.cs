using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject prefab;
    public RaceManager rm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        string[] places = {"1st", "2nd", "3rd", "4th"};
        for (int x = 0; x < rm.players.Count; x++)
        {
            RectTransform playerRow;
            playerRow = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform).GetComponent<RectTransform>();
            playerRow.GetComponent<LeaderboardRow>().Initiate("Player" + x, places[Mathf.Min(x, places.Length - 1)]);
            playerRow.localPosition = new Vector3(0, x * 30f, 0);
        }
    }
}
