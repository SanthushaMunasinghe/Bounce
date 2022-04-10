using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Game Over");
            gameOver.GameOverBehaviour();
        }
    }
}
