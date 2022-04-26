using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : PlayerMain
{
    [Header("Jump")]
    public Vector3 force;
    public float forceMultiplyer;
    public float jumpHeight;

    [Header("Clamp Jump")]
    //public Text playerVelocityTxt; // Debug
    [SerializeField] private float maxVelocity;

    [SerializeField] private AudioSource bounceSFX;

    void Awake()
    {
        Initialization();
        force = force.normalized;
        forceMultiplyer = jumpHeight + 5;
    }

    void Update()
    {
        MultiplyForce();
        LimitVelocity();
    }

    public void StopMovement()
    {
        playerRb.detectCollisions = false;
        playerRb.isKinematic = true;
    }

    public void MultiplyForce()
    {
        forceMultiplyer = jumpHeight + 5;
        maxVelocity = 5 + jumpHeight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerRb.AddForce(new Vector3(0, force.y * forceMultiplyer, 0), ForceMode.Impulse);
        bounceSFX.Play();
    }

    private void LimitVelocity()
    {
        if (playerRb.velocity.magnitude > maxVelocity)
        {
            playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxVelocity);
        }

        //Try This later debug when bouncing stops 
        //if (playerRb.velocity.y == 0)
        //{
        //    playerRb.AddForce(new Vector3(0, force.y * forceMultiplyer, 0), ForceMode.Impulse);
        //}

        //For Debug
        //playerVelocityTxt.text = playerRb.velocity.magnitude.ToString();
    }
}
