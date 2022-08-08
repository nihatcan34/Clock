using System;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    [SerializeField]
    TextMeshPro dayTmp;

    private void Start()
    {
        CallDay();
    }

    private void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation =  
            Quaternion.Euler(0f,0f,hoursToDegrees* (float)time.TotalHours);
        minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);

        if (time.Hours == 24 && time.Minutes == 0 && time.Seconds == 0 && time.Milliseconds == 0)
        {
            CallDay();
            Debug.Log(time.Seconds);
        }
            
    }

    void CallDay()
    {
        dayTmp.text = DateTime.Now.Day.ToString();
    }
}
