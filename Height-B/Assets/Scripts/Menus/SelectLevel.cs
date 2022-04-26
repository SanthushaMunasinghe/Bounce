using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private Button[] lvlBtns;

    [SerializeField] private CurrentLvlStars[] currentLvlStars;

    private int availableLvlCount = 1;

    void Awake()
    {
        LvlActivation();
        LvlStarsStatus();

        if (!PlayerPrefs.HasKey("Audio"))
        {
            PlayerPrefs.SetInt("Audio", 1);
        }
    }

    private void LvlActivation()
    {
        if (PlayerPrefs.HasKey("CompletedCount"))
        {
            availableLvlCount = PlayerPrefs.GetInt("CompletedCount");
        }
        else
        {
            PlayerPrefs.SetInt("CompletedCount", 1);
        }

        for (int i = 0; i < lvlBtns.Length; i++)
        {
            if (availableLvlCount >= i + 1)
            {
                lvlBtns[i].interactable = true;
            }
        }
    }

    private void LvlStarsStatus()
    {
        for (int i = 0; i < currentLvlStars.Length; i++)
        {
            if (!PlayerPrefs.HasKey("StarsCountLvl" + (i+1)))
            {
                PlayerPrefs.SetInt("StarsCountLvl" + (i + 1), 0);
            }

            currentLvlStars[i].AssignStars(PlayerPrefs.GetInt("StarsCountLvl" + (i + 1)));
        }
    }
}
