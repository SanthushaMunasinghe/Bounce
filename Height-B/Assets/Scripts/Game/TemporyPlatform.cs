using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporyPlatform : MonoBehaviour
{
    [SerializeField] private int platformLifeCount;
    [SerializeField] private GameObject crushParticle;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private AudioSource breakSFX;

    private int currentHits = 0;

    private void Awake()
    {
        parentTransform = GameObject.Find("GameLevel").transform;
        breakSFX = GameObject.Find("Break").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            currentHits++;

            if (currentHits >= platformLifeCount)
            {
                Instantiate(crushParticle, transform.position, Quaternion.identity, parentTransform);
                breakSFX.Play();
                Destroy(gameObject);
            }
        }
    }
}
