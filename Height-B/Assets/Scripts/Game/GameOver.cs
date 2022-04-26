using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlatformScroll platformScroll;

    [SerializeField] private GameObject gameOverTxt;

    [SerializeField] private AudioSource BgSFX;
    [SerializeField] private AudioSource gameoverSFX;

    public void GameOverBehaviour()
    {
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        BgSFX.Stop();
        gameoverSFX.Play();
        playerMovement.StopMovement();
        platformScroll.speed = 0;
        gameOverTxt.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
