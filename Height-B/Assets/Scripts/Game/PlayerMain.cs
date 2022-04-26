using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    protected PlayerMovement playerMovement;
    protected PlayerUIManager playerUIManager;

    protected Rigidbody playerRb;

    void Awake()
    {
        
    }

    public void Initialization()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        playerUIManager = GetComponent<PlayerUIManager>();
    }

    void Update()
    {
        
    }


}
