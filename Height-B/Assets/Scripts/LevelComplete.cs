using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;
    public Text keyCountTxt;
    [SerializeField] private GameObject warningTxt;
    private float warningDuration = 2.0f;
    private float warningTimeout;

    public int keyCount;
    public int totalKeys;
    private string keyString;
    private bool isComplete;

    void Start()
    {
        keyCount = 0;
        totalKeys = keys.Length;
    }

    void Update()
    {
        CheckKeyCount();
        ActivateWarning();

        DisplayKeyCount();
    }

    private void DisplayKeyCount()
    {
        keyString = keyCount + "/" + totalKeys;
        keyCountTxt.text = keyString;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isComplete)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                warningTimeout = warningDuration;
            }
        }
    }

    private void CheckKeyCount ()
    {
        if (keyCount >= keys.Length)
        {
            isComplete = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void ActivateWarning()
    {
        if (warningTimeout > 0)
        {
            warningTxt.SetActive(true);
            warningTimeout -= 1 * Time.deltaTime;
        }
        else
        {
            warningTxt.SetActive(false);
        }
    }
}
