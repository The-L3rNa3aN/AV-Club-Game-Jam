using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action leftInput;
    public static Action rightInput;
    public static Action jumpInput;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            leftInput?.Invoke();

        if (Input.GetKeyDown(KeyCode.D))
            rightInput?.Invoke();

        if (Input.GetButtonDown("Jump"))
            jumpInput?.Invoke();
    }
}
