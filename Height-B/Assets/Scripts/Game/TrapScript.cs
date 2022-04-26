using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private GameOver gameOver;

    private void Awake()
    {
        if (GameObject.Find("GameManager") != null)
        {
            gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
        }
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameOver.GameOverBehaviour();
        }
    }
}
