using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaceManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public List<Player> players;


    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < checkpoints.Count; x++)
        {
            checkpoints[x].index = x;
            if (x == checkpoints.Count - 1)
            {
                checkpoints[x].isLastCheckpoint = true;
            }
        }
    }
}
