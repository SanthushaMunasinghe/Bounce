using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject collectableHolder;
    public AudioSource collectSFX;

    public Text collectableCountTxt;
    [SerializeField] private GameObject warningTxt;
    [SerializeField] private Text levelTxt;

    private float warningDuration = 2.0f;
    private float warningTimeout;

    public float collectableCount;
    public float totalCollectables;

    private float starCount = 0;
    [SerializeField] private Image[] starImgs;
    [SerializeField] private Animation imageAnim;
    [SerializeField] private Animation triggerAnim;
    [SerializeField] private MeshRenderer lightMesh;
    [SerializeField] private AudioSource completeSFX;

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

        StartCoroutine(DisplayLvl());    }

    private IEnumerator DisplayLvl()
    {
        levelTxt.text = "LEVEL " + currentLvl;
        yield return new WaitForSeconds(2.0f);
        Destroy(levelTxt);
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
                completeSFX.Play();
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
        SetStars();
        SceneManager.LoadScene("LevelSelect");
    }

    private void SetStars()
    {
        if (PlayerPrefs.GetInt("StarsCountLvl" + currentLvl) < starCount)
        {
            PlayerPrefs.SetInt("StarsCountLvl" + currentLvl, (int)starCount);
        }

        if (PlayerPrefs.GetInt("CompletedCount") <= currentLvl)
        {
            PlayerPrefs.SetInt("CompletedCount", currentLvl + 1);
        }
    }

    private void CheckKeyCount ()
    {
        if (collectableCount >= Mathf.Round(totalCollectables * 0.25f))
        {
            isComplete = true;
            lightMesh.enabled = true;
            imageAnim.Play();
            if (lightMesh.gameObject.transform.localScale.y < 8)
            {
                triggerAnim.Play();
            }

            if (collectableCount >= Mathf.Round(totalCollectables * 0.5f))
            {
                starCount = 1;
                starImgs[0].color = Color.white;
            }
            
            if (collectableCount >= Mathf.Round(totalCollectables * 0.75f))
            {
                starCount = 2;
                starImgs[1].color = Color.white;
            }
            
            if (collectableCount >= totalCollectables)
            {
                starCount = 3;
                starImgs[2].color = Color.white;
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
