using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject warningTxt;
    [SerializeField] private Text audioTxt;

    [SerializeField] private float warnDuration;
    private float countDown = 0;
    private bool isConfirmed = false;

    private void Update()
    {
        WarnAction();

        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            audioTxt.text = "Sound On";
        }
        else
        {
            audioTxt.text = "Sound Off";
        }
    }

    public void ClearData()
    {
        if (isConfirmed)
        {
            warningTxt.GetComponent<Text>().text = "Game Data Cleared!";
            isConfirmed = false;
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Audio", 1);
        }
        else
        {
            warningTxt.GetComponent<Text>().text = "Preess Again to Confirm";
            countDown = warnDuration;
            isConfirmed = true;
        }
    }

    public void MuteAudio()
    {
        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            PlayerPrefs.SetInt("Audio", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Audio", 0);
        }
    }

    private void WarnAction()
    {
        if (countDown <= 0)
        {
            warningTxt.SetActive(false);
            isConfirmed = false;
        }
        else
        {
            warningTxt.SetActive(true);
            countDown -= 1 * Time.deltaTime;
        }
    }
}
