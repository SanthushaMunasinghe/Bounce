using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroll : MonoBehaviour
{
    [Header("Scroll")]
    [SerializeField] private GameUIBtnManager gameUIBtnManager;
    [SerializeField] private PlayerBoxCast playerBoxCast;

    [SerializeField] private float speed;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!playerBoxCast.hitDetect || playerBoxCast.isHitPlatform)
        {
            PlatformScrolling();
        }
    }

    private void PlatformScrolling()
    {
        if (gameUIBtnManager.isMoveRightButtonDown)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            ////rb.AddForce(Vector3.left * speed);
            //rb.velocity = Vector3.left * speed;

        }
        else if (gameUIBtnManager.isMoveLeftButtonDown)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            ////rb.AddForce(Vector3.right * speed);
            //rb.velocity = Vector3.right * speed;
        }
    }
}
