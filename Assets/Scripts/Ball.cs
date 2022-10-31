using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds; // Remember: The [] after the type of the Variable, creates an Array
    [SerializeField] float randomFactor = 0.2f;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted = false; // bool is the same as Boolean 

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigiBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigiBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted) // The ! before the bool means the oposite of current value of the boolean
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            // You need this syntax GetComponent<component you want> to acess components, others than the Transform component
            myRigiBody2D.velocity = new Vector2(xPush, yPush); // The velocity property has a x and y axis
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (
                UnityEngine.Random.Range(0f, randomFactor), 
                UnityEngine.Random.Range(0f, randomFactor)
            );

        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; // Remember: The Array has an Length Property
            // With GetComponent<>() you can select a specific component on the current game Object
            myAudioSource.PlayOneShot(clip); // To Play a sound effect use the Play() Method, or the PlayOneShot()
            myRigiBody2D.velocity += velocityTweak;
        }
    }
}
