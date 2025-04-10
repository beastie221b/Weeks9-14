using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Penguin : MonoBehaviour
{
    int health = 100;
    bool rolling = false;
    float IFrameSpeed = 0.5f;
    public UnityEvent penguinEvent = new UnityEvent();
    IEnumerator RollingCoroutine;
    public Slider healthBar;
    public TMP_Text score;
    int currentScore = 0;
    public GameObject gameOverScreen;

    void Start()
    {
        // In default, the player can be damaged.
        penguinEvent.AddListener(Damage);
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        // If player press the space bar, the penguin rolls by rotating 360 degrees.
        if (Input.GetKeyDown("space") && rolling == false) // Stop the player from rolling again when it is already rolling.
        {
            // Start rolling
            rolling = true;
            Roll();
        }

        healthBar.value = health;
        score.text = "SCORE: " + currentScore.ToString();

        // Set the game over screen on when the health is running out.
        if (health == 0)
        {
            gameOverScreen.SetActive(true);
        }
    }

    void Roll()
    {
        // Remove damage listener, making the player invisible.
        penguinEvent.RemoveAllListeners();
        penguinEvent.AddListener(Dodge);
        // Start rolling coroutine to end rolling.
        RollingCoroutine = RollEnd();
        StartCoroutine(RollingCoroutine);
        // Start roll animation coroutine.
        RollingCoroutine = RollAnimation();
        StartCoroutine(RollAnimation());
    }

    IEnumerator RollAnimation()
    {
        float numOfFrames = IFrameSpeed / Time.deltaTime;
        float angle = 360 / numOfFrames;
        // Rotate 360 degree in IFrame speed seconds.
        for (int i = 0; i < numOfFrames; i++)
        {
            transform.Rotate(new Vector3(0, 0, -angle));
            yield return null;
        }
        transform.rotation = Quaternion.identity;
    }
    
    IEnumerator RollEnd()
    {
        // IFrame for 0.5 second
        yield return new WaitForSeconds(IFrameSpeed);
        // IFrame ended, add back damage listener.
        penguinEvent.RemoveAllListeners();
        penguinEvent.AddListener(Damage);
        // Reset rolling
        rolling = false;
    }

    public void Damage()
    {
        // Penguin hurts.
        health -= 10;
    }

    public void Dodge()
    {
        currentScore++;
    }
}
