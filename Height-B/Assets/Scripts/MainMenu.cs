using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayBtn(string sceneName)//Load Scene Button
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
