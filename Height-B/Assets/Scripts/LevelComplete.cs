using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject collectableHolder;

    public Text collectableCountTxt;
    [SerializeField] private GameObject warningTxt;
    private float warningDuration = 2.0f;
    private float warningTimeout;

    public float collectableCount;
    public float totalCollectables;

    private float starCount = 0;

    private string countString;
    private bool isComplete;

    //Save Result
    [SerializeField] private int currentLvl = 1;
    [SerializeField] private PlatformScroll platformScroll;

    void Start()
    {
        collectableCount = 0;
        for (int i = 0; i < collectableHolder.transform.childCount; i++)
        {
            totalCollectables++;
        }
    }

    void Update()
    {
        CheckKeyCount();
        ActivateWarning();
    }

    private void DisplayKeyCount()
    {
        countString = Mathf.Round((collectableCount / totalCollectables) * 100) + "%";
        collectableCountTxt.text = countString;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isComplete)
            {
                StartCoroutine(FinishDelay(other.gameObject));
                Debug.Log(starCount);
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
        if (collectableCount >= Mathf.Round(totalCollectables * 0.25f))
        {
            isComplete = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;

            if (collectableCount >= Mathf.Round(totalCollectables * 0.5f))
            {
                starCount = 1;
            }
            
            if (collectableCount >= Mathf.Round(totalCollectables * 0.75f))
            {
                starCount = 2;
            }
            
            if (collectableCount >= totalCollectables)
            {
                starCount = 3;
            }
        }

        DisplayKeyCount();
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
