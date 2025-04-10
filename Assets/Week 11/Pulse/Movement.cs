using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public int reverseDirection = -1;
    public AnimationCurve curve;
    [Range(0,1)]
    public float t;

    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * 0.5f;
        Vector3 objectPosition = transform.position;
        objectPosition.x += speed * Time.deltaTime;
        objectPosition.y = t;
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);

        if (screenPosition.x > Screen.width)
        {
            objectPosition.x = 0;
            speed = speed * reverseDirection;
        }

        if (screenPosition.x < 0)
        {
            objectPosition.x = 0;
            speed = speed * reverseDirection;
        }
        
        if (t > 1)
        {
            t = 0;
        }

        objectPosition.y = curve.Evaluate(t) * 2;
        transform.position = objectPosition;
    }
} 