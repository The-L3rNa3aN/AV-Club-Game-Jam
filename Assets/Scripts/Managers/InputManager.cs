using AVClub.Managers;
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
    'Esc' - Toggle pause menu (code in GameManager)
    Left Mouse Button - Attack (melee)
*/

public class InputManager : MonoBehaviour
{
    //Movement
    public static Action leftInput;
    public static Action rightInput;
    public static Action jumpInput;

    //Interaction.
    public static Action downInput_Down;
    public static Action downInput_Up;

    //Period-based movement.
    public static Action dashInput;
    public static Action dodgeInput;

    //Combat.
    public static Action attackInput;
    public static Action altFireInput;

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

        if (Input.GetMouseButtonDown(1))
            altFireInput?.Invoke();

        if (Input.GetButtonDown("Jump"))
            jumpInput?.Invoke();

        if (Input.GetKeyDown(KeyCode.Escape))                   //NEEDS A REVIEW.
        {
            if (GameManager.instance.isGamePaused)
                GameManager.instance.OnResumeGamePressed();
            else
            {
                GameManager.instance._gUi.ToggleScreens(false);
                GameManager.instance.TogglePauseState(true);
            }
        }
    }
}
