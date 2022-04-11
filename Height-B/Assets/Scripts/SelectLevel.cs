using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private Button[] lvlBtns;

    private int availableLvlCount = 1;

    void Awake()
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
            if (availableLvlCount == i + 1)
            {
                lvlBtns[i].interactable = true;
            }
        }
    }
}
