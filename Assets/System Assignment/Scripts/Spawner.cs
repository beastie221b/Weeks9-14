using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    Penguin penguin;
    float speed = 5f;
    public GameObject small_obstacle;
    public GameObject large_obstacle;
    public UnityEvent spawnEvent;
    IEnumerator timeIncrement;

    void Start()
    {
        // Initialize all coroutine.
        timeIncrement = Increment();

        // Slowly increase obstacle speed based on time.
        StartCoroutine(timeIncrement);
        spawnEvent.AddListener(Spawn);
        // Spawn first obstacle.
        Spawn();
    }

    void Spawn()
    {
        GameObject newObject;
        // Randomly generate an obstacle.
        if (Random.Range(0, 2) == 0)
        {
            newObject = Instantiate(small_obstacle, transform);
        }
        else
        {
            newObject = Instantiate(large_obstacle, transform);
        }

        // Set the obstacl speed and give access to player object.
        Obstacles obstacle = newObject.GetComponent<Obstacles>();
        penguin = GetComponentInChildren<Penguin>();
        obstacle.speed = speed;
        obstacle.penguin = penguin;
    }

    IEnumerator Increment()
    {
        // Increase the speed every 3 seconds.
        while (true)
        {
            yield return new WaitForSeconds(3f);
            speed += 1f;
        }
    }
}
