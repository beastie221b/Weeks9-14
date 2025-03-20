using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;
    public Transform minuteHand;
    public Transform hourHand;

    public float t;
    public int hour = 0;


    public UnityEvent<int> OnTheHour;

    Coroutine clockIsRunning;
    IEnumerator doOneHour;

    private void Start()
    {
        // StartCoroutine(MoveTheClockHandsOneHour());
        // StartCoroutine(MoveTheClock());
        clockIsRunning = StartCoroutine(MoveTheClock());
    }
    void Update()
    {
       /* t += Time.deltaTime;

        if (t > timeAnHourTakes)
        {
            t = 0;
            OnTheHour.Invoke();

            hour++;
            if (hour == 12)
            {
                hour = 0;
            }
        }*/
    }

    IEnumerator MoveTheClock()
    {
        while (true)
        {
            // yield return StartCoroutine(MoveTheClockHandsOneHour());
            doOneHour = MoveTheClockHandsOneHour();
            yield return StartCoroutine(doOneHour);
        }
    }

    IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while (t< timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;

        if (hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }

    public void StopTheClock()
    {
        // StopCoroutine(MoveTheClock());

        if (clockIsRunning != null)
        {
            StopCoroutine(clockIsRunning);
        }
        if (doOneHour != null)
        {
            StopCoroutine(doOneHour);
        }

    }
}

