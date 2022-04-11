using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIBtnManager : MonoBehaviour
{
    //Player Movement
    public bool isMoveRightButtonDown = false;
    public bool isMoveLeftButtonDown = false;

    //Player Jump
    public bool increaseJumpHeight = false;
    public bool decreaseJumpHeight = false;

    //Pause Game
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        
    }

    //Player Movement
    public void OnMoveRightButtonDown()
    {
        isMoveRightButtonDown = true;
    }

    public void OnMoveRightButtonUp()
    {
        isMoveRightButtonDown = false;
    }
    
    public void OnMoveLeftButtonDown()
    {
        isMoveLeftButtonDown = true;
    }

    public void OnMoveLeftButtonUp()
    {
        isMoveLeftButtonDown = false;
    }
    
    //PlayerJump
    public void OnHeightUpButtonDown()
    {
        increaseJumpHeight = true;
    }

    public void OnHeightUpButtonUp()
    {
        increaseJumpHeight = false;
    }
    
    public void OnHeightDownButtonDown()
    {
        decreaseJumpHeight = true;
    }

    public void OnHeightDownButtonUp()
    {
        decreaseJumpHeight = false;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RetryGame()
    {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }
}
