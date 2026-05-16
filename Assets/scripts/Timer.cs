using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text lapTime;
    public Text startCountdown;

    public float totalLapTime;
    public float totalCountdownTime;

    public boat speed;
    
    void Update()
    {

        if (totalCountdownTime > 0)
        {
            totalCountdownTime -= Time.deltaTime;
            startCountdown.text = Mathf.Round(totalCountdownTime).ToString();
            speed.currentSpeed = 0;
        }
        if (totalCountdownTime <= 0)
        {
            startCountdown.text = "";
            totalLapTime -= Time.deltaTime;
            lapTime.text = Mathf.Round(totalLapTime).ToString();
            speed.currentSpeed = 35;
        }
        if (totalLapTime < 0)
        {
            SceneManager.LoadScene("Lose");
        }

    }

}
