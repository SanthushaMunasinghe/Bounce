using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxCast : MonoBehaviour
{
    [SerializeField] private GameUIBtnManager gameUIBtnManager;

    [SerializeField] private float maxDistance;//Max Boxcast distance
    [SerializeField] private float maxRayDistance;
    public bool hitDetect;
    private int dirMultiplyer = 1;

    private Collider playerCollider;
    private RaycastHit hit;
    private RaycastHit tagHit;
    public bool isHitPlatform = false;


    void Awake()
    {
        playerCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (gameUIBtnManager.isMoveRightButtonDown)
        {
            dirMultiplyer = 1;
        }
        else if (gameUIBtnManager.isMoveLeftButtonDown)
        {
            dirMultiplyer = -1;
        }
        else
        {
            dirMultiplyer = 1;
        }
    }

    private void FixedUpdate()
    {
        hitDetect = Physics.BoxCast(playerCollider.bounds.center, transform.localScale, transform.right * dirMultiplyer, out hit, transform.rotation, maxDistance);

        if (hitDetect)
        {
            if (hit.collider.tag == "Trap" || hit.collider.tag == "Trigger")
            {
                isHitPlatform = true;
            }
        }
        else
        {
            isHitPlatform = false;
        }


        //if (hitDetect)
        //{
        //    //Output the name of the Collider your Box hit
        //    Debug.Log("Hit : " + hit.collider.name);
        //}
    }
}
