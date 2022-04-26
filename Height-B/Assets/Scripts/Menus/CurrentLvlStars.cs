using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLvlStars : MonoBehaviour
{
    [SerializeField] private List<GameObject> starsImgs = new List<GameObject>();

    public void AssignStars(int starsCount)
    {
        foreach (Transform child in transform)
        {
            starsImgs.Add(child.gameObject);
        }

        for (int i = 0; i < starsImgs.Count; i++)
        {
            if (i <= starsCount - 1)
            {
                starsImgs[i].GetComponent<Image>().color = Color.white;
            }
        }
    }
}
