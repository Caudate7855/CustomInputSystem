using System;
using UnityEngine;

namespace CustomInputSystem
{
    public class InputSystemKey
    {
        public KeyCode KeyCode;
        public Action OnKeyPressedAction;

        public InputSystemKey(KeyCode keyCode, Action action)
        {
            KeyCode = keyCode;
            OnKeyPressedAction += action;
        }

        public void OnKeyPressed()
        {
            OnKeyPressedAction?.Invoke();
        }
    }
}