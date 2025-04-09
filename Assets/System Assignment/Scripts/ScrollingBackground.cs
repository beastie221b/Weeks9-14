using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // Refer to the Lecture 8.5 "Endlessly Scrolling Backgrounds" of Professor Kit Barry.
    public Renderer r;
    public float speed;

    void Update()
    {
        r.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
