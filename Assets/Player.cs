using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int place;
    public int currentCheckpoint = 0;
    public int currentLap = 0;
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI TimerText;
    public Leaderboard lb;
    public string SceneToLoad;
    public Transform LastCheckPoint;
    public float StartTime;

    private cart cartComponent;
    private Rigidbody rb;
    private float nextTimerUpdate;

    void Start()
    {
        cartComponent = GetComponent<cart>();
        rb = GetComponent<Rigidbody>();
        if (LastCheckPoint == null) LastCheckPoint = transform;
        lapText.text = "LAPS: " + currentLap + "/3";
    }

    
    // Update is called once per frame
    void Update()
    {
        if (currentLap == 0)
        {
            TimerText.text = "";
        }
        else
        {
            if (Time.time >= nextTimerUpdate)
            {
                nextTimerUpdate = Time.time + 0.1f;
                TimerText.text = "Time: " + (Time.time - StartTime).ToString("F1");
            }
        }
    }

    public void checkPointActivated(Checkpoint checkpoint)
    {
        if (checkpoint.index == currentCheckpoint)
        {
            LastCheckPoint = checkpoint.transform;
            if (checkpoint.index == 0)
            {
                if (currentLap == 0)
                {
                    StartTime = Time.time;
                }
                currentLap++;
                if (currentLap == 3)
                {
                    // logic for end game & scoring.
                    GameInfo.LastTime = (Time.time - StartTime);
                    if (GameInfo.BestTime == 0 || GameInfo.LastTime < GameInfo.BestTime)
                    {
                        GameInfo.BestTime = GameInfo.LastTime;
                    }
                    SceneManager.LoadScene(SceneToLoad);
                }
                lapText.text = "LAPS: " + currentLap + "/3";
                currentCheckpoint++;
            }
            else if (checkpoint.isLastCheckpoint)
            {
                currentCheckpoint = 0;
            }
            else
            {
                currentCheckpoint++;
            }
        }
    }

    public void resetToCheckpoint()
    {
        transform.position = LastCheckPoint.position;
        transform.rotation = LastCheckPoint.rotation;
        cartComponent.resetSpeed();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }



    public int getPlace() 
    { 
        return place; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Reset"))
        {
            resetToCheckpoint();
        }
    }

#if UNITY_EDITOR
    [ContextMenu("warp to last checkpoint")]
    void debugFinishRace()
    {
        currentLap = 3;
        currentCheckpoint = 3;
    }
#endif
}
