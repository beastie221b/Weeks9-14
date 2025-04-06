using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5f;
    public Penguin penguin;
    bool damaged = false;

    void Start()
    {

    }

    void Update()
    {
        // Damage the penguin if penguin is hitting the obstacle.
        if (transform.position.x > penguin.transform.position.x - 1 && 
            transform.position.x < penguin.transform.position.x + 1 &&
            damaged == false)
        {
            // Call penguin event to invoke damage.
            penguin.penguinEvent.Invoke();
            // Prevent the penguin to be damaged again by the same obstacle.
            damaged = true;
        }

        // Move obstacle to the left base on speed
        Vector2 pos = transform.position;

        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }
}
