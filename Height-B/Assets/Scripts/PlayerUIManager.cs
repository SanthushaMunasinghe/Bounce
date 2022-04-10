using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUIManager : PlayerMain
{
    [SerializeField] private GameUIBtnManager gameUIBtnManager;

    [Header ("Jump")]
    [SerializeField] private Slider jumpHeightSlider;
    private float jumpValue = 1;
    [SerializeField] private float updateSpeed;

    void Awake()
    {
        Initialization();
    }

    void Update()
    {
        UpdateJumpHeight();
    }

    private void UpdateJumpHeight()
    {
        float currentJumpValue = Mathf.Round(jumpValue);

        jumpHeightSlider.value = currentJumpValue;
        playerMovement.jumpHeight = currentJumpValue;

        if (gameUIBtnManager.increaseJumpHeight)
        {
            if (jumpValue < 10)
            {
                jumpValue += updateSpeed * Time.deltaTime;
            }
        }
        else if (gameUIBtnManager.decreaseJumpHeight)
        {
            if (jumpValue > 1)
            {
                jumpValue -= updateSpeed * Time.deltaTime;
            }
        }
    }
}
