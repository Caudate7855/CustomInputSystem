using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomInputSystem
{
    public class CustomInputController : MonoBehaviour
    {
        private List<InputSystemKey> _keys = new();

        private void Update()
        {
            CheckButtonStates();
        }

        public void BindAction(KeyCode keyCode, Action action)
        {
            _keys.Add(new InputSystemKey(keyCode, action));
        }

        private void CheckButtonStates()
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                if (Input.GetKeyDown(_keys[i].KeyCode))
                {
                    _keys[i].OnKeyPressed();
                }
            }
        }
    }
}