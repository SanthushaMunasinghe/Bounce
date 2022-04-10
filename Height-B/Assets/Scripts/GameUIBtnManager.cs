using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameUIBtnManager : MonoBehaviour
{
    //Player Movement
    public bool isMoveRightButtonDown = false;
    public bool isMoveLeftButtonDown = false;

    //Player Jump
    public bool increaseJumpHeight = false;
    public bool decreaseJumpHeight = false;



    private void Awake()
    {
        
    }

    //Player Movement
    public void OnMoveRightButtonDown()
    {
        isMoveRightButtonDown = true;
    }

    public void OnMoveRightButtonUp()
    {
        isMoveRightButtonDown = false;
    }
    
    public void OnMoveLeftButtonDown()
    {
        isMoveLeftButtonDown = true;
    }

    public void OnMoveLeftButtonUp()
    {
        isMoveLeftButtonDown = false;
    }
    
    //PlayerJump
    public void OnHeightUpButtonDown()
    {
        increaseJumpHeight = true;
    }

    public void OnHeightUpButtonUp()
    {
        increaseJumpHeight = false;
    }
    
    public void OnHeightDownButtonDown()
    {
        decreaseJumpHeight = true;
    }

    public void OnHeightDownButtonUp()
    {
        decreaseJumpHeight = false;
    }
}
