using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerPlayer : MonoBehaviour
{
    static public VectorMovement playerVector = new VectorMovement();

    private bool isRightButtonPressed = false;
    private bool isLeftButtonPressed = false;

    public void RightDownButton()
    {
        isRightButtonPressed = true;
        
    }

    public void LeftDownButton()
    {
        isLeftButtonPressed = true;
    }

    public void RightUpButton()
    {
        isRightButtonPressed = false;
    }

    public void LeftUpButton()
    {
        isLeftButtonPressed = false;
    }

    void LateUpdate()
    {
        if((isLeftButtonPressed && isRightButtonPressed) || (isLeftButtonPressed == false && isRightButtonPressed == false)) {
            playerVector.x = 0;
        }
        else if (isLeftButtonPressed == true && isRightButtonPressed == false)
        {
            playerVector.x = -1;
        } else if ((isLeftButtonPressed == false && isRightButtonPressed == true))
        {
            playerVector.x = 1;
        }
        //Debug.Log(playerVector.x + $" isLeftButtonPressed {isLeftButtonPressed} , isRightButtonPressed {isRightButtonPressed}");
    }
}

[System.Serializable]
public struct VectorMovement
{
    public int x { get; set; }
}