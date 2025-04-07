using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5f;
    public Penguin penguin;
    bool damaged = false;
    public Spawner spawner;

    void Start()
    {
        // Get parent object.
        spawner = GetComponentInParent<Spawner>();
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

        // If the obstacle is out of screen, ask spawner to generate the next one, destroy the current object.
        if (Camera.main.WorldToScreenPoint(transform.position).x < 0)
        {
            // Spawn the next obstacle.
            spawner.spawnEvent.Invoke();
            // Destroy current one.
            Destroy(gameObject);
        }

        // Move obstacle to the left base on speed.
        Vector2 pos = transform.position;

        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }
}
