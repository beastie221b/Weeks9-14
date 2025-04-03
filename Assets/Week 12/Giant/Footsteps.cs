using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Footsteps : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public CinemachineImpulseSource impulseSource;
    public float speed = 0.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = (direction < 0);
        animator.SetFloat("movement", Mathf.Abs(direction));
        //impulseSource.GenerateImpulse();

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed;
            impulseSource.GenerateImpulse();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed;
            impulseSource.GenerateImpulse();
        }
    }

}
