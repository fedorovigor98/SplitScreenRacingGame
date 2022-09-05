using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{


    public static void WatchKeys(out float verticalInput, out float horizontalInput, out bool isBraking, int currentPlayer)
    {
        if(currentPlayer == 2)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                    verticalInput = 1;
                else if (Input.GetKey(KeyCode.DownArrow))
                    verticalInput = -1;
                else
                    verticalInput = 0;
                if (Input.GetKey(KeyCode.RightArrow))
                    horizontalInput = 1;
                else if (Input.GetKey(KeyCode.LeftArrow))
                    horizontalInput = -1;
                else
                    horizontalInput = 0;
                isBraking = Input.GetKey(KeyCode.RightShift);
            }
        else
            {
                if (Input.GetKey(KeyCode.W))
                    verticalInput = 1;
                else if (Input.GetKey(KeyCode.S))
                    verticalInput = -1;
                else
                    verticalInput = 0;
                if (Input.GetKey(KeyCode.D))
                    horizontalInput = 1;
                else if (Input.GetKey(KeyCode.A))
                    horizontalInput = -1;
                else
                    horizontalInput = 0;
                isBraking = Input.GetKey(KeyCode.LeftShift);
            }
    }
}