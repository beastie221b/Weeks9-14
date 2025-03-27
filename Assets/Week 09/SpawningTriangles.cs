using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTriangles : MonoBehaviour
{
    public GameObject Triangle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTriangle()
    {
        GameObject newTriangle = Instantiate(Triangle, Random.insideUnitCircle * 5, Quaternion.identity);
        Destroy(newTriangle, 5);
    }
}
