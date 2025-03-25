using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    //public KitClock clock;

    public GameObject angryBird;
    public float t = 0;

    public void Start()
    {
        //clock.OnTheHour.AddListener(Chime);

        angryBird.SetActive(false);
    }
    public void Chime(int hour)
    {
        Debug.Log("Chiming " + hour + " o'clock !");
    }

    public void ChimeWithoutArguments()
    {
        Debug.Log("Chiming !");
    }

    public void BirdPopsUp()
    {
        StartCoroutine(BirdShowTime());
    }

    IEnumerator BirdShowTime()
    {
        t = 0;
        while (t < 1)
        {
            angryBird.SetActive(true);
            t += Time.deltaTime;
            yield return null;
        }
        angryBird.SetActive(false);
    }
}
