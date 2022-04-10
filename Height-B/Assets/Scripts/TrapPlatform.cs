using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;
    [SerializeField] private Renderer objRenderer;

    [SerializeField] private Color color1;
    [SerializeField] private Color color2;

    private int colCount = 0;

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
            if (colCount == 0)
            {
                objRenderer.material.color = color1;
            }
            else if (colCount == 1)
            {
                objRenderer.material.color = color2;
            }
            else if (colCount == 2)
            {
                gameOver.GameOverBehaviour();
            }

            colCount += 1;
        }
    }
}
