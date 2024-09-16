using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action OnMouseLeftClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseLeftClick?.Invoke();
        }

    }
}
