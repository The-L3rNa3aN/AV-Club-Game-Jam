using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Controls: -
    'A' key, Left Arrow - Move Left
    'D' key, Right Arrow - Move Right
    Spacebar - Jump
    'S' key, Down Arrow - Interact / Move down a platform
    'E' key, 'Z' key - Dash
    'F' key, 'X' key - Dodge
    Left Mouse Button - Attack
*/

public class InputManager : MonoBehaviour
{
    public static Action leftInput;
    public static Action rightInput;
    public static Action jumpInput;
    public static Action downInput_Down;
    public static Action downInput_Up;
    public static Action dashInput;
    public static Action dodgeInput;
    public static Action attackInput;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            leftInput?.Invoke();

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            rightInput?.Invoke();

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            downInput_Down?.Invoke();

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            downInput_Up?.Invoke();

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Z))
            dashInput?.Invoke();

        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.X))
            dodgeInput?.Invoke();

        if (Input.GetMouseButtonDown(0))
            attackInput?.Invoke();

        if (Input.GetButtonDown("Jump"))
            jumpInput?.Invoke();
    }
}
