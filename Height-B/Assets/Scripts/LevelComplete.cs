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

    //Save Result
    [SerializeField] private int currentLvl = 1;
    [SerializeField] private PlatformScroll platformScroll;

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
                StartCoroutine(FinishDelay(other.gameObject));
            }
            else
            {
                warningTimeout = warningDuration;
            }
        }
    }

    private IEnumerator FinishDelay(GameObject playerObj)
    {
        yield return new WaitForSeconds(0.25f);
        platformScroll.speed = 0;
        playerObj.GetComponent<PlayerMovement>().StopMovement();
        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("CompletedCount", currentLvl+1);
        SceneManager.LoadScene("LevelSelect");
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
