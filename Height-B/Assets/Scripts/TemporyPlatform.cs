using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporyPlatform : MonoBehaviour
{
    [SerializeField] private float platformLifetime;

    private bool isCollided = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isCollided)
        {
            platformLifetime -= 1.0f * Time.deltaTime;
        }

        if (platformLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            isCollided = true;
        }
    }
}
