using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    private LevelComplete levelComplete;
    [SerializeField] private float rotSpeed;

    void Start()
    {
        levelComplete = GameObject.Find("FinishTrigger").GetComponent<LevelComplete>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelComplete.collectableCount++;
            Destroy(gameObject);
        }
    }
}
