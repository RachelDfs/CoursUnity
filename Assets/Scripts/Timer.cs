using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 90; //j'appelle ma variable float pour 1m30.
    public Text timeText;
    public GameObject portal;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            //spawn portal quand chrono à 00:00.
            portal.SetActive(true);
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float TimeToDisplay) //décompte du temps en minutes (Donc division part 60 car l'heure c'est un enfer)
    {
        if (TimeToDisplay < 0)
        {
            TimeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
