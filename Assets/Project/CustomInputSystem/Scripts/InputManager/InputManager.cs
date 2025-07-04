using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomInputSystem
{
    public class InputManager : MonoBehaviour
    {
        private GlobalController _globalController = new();

        private Dictionary<Actions, KeyCode> _keyBindings = new()
        {
            { Actions.Cast_1, KeyCode.Alpha1 },
            { Actions.Cast_2, KeyCode.Alpha2 },
            { Actions.Cast_3, KeyCode.Alpha3 },
            { Actions.Cast_4, KeyCode.Alpha4 },
            { Actions.Cast_5, KeyCode.Alpha5 },
            { Actions.Inventory, KeyCode.E },
            { Actions.Menu, KeyCode.Escape },
        };

        private void Awake()
        {
            /*foreach (Actions action in Enum.GetValues(typeof(Actions)))
            {
                if (!_keyBindings.ContainsKey(action))
                {
                    _keyBindings[action] = KeyCode.None;
                    Debug.Log($"Added default binding for {action} = KeyCode.None");
                }
            }*/
        }

        private void Update()
        {
            foreach (var binding in _keyBindings)
            {
                if (Input.GetKeyDown(binding.Value))
                {
                    ExecuteAction(binding.Key);
                }
            }
        }

        private void ExecuteAction(Actions action)
        {
            switch (action)
            {
                case Actions.Cast_1: _globalController.Cast_1(); break;
                case Actions.Cast_2: _globalController.Cast_2(); break;
                case Actions.Cast_3: _globalController.Cast_3(); break;
                case Actions.Cast_4: _globalController.Cast_4(); break;
                case Actions.Cast_5: _globalController.Cast_5(); break;
                case Actions.Cast_6: _globalController.Cast_6(); break;

                case Actions.Inventory: _globalController.SwitchInventory(); break;
                case Actions.Menu: _globalController.SwitchMenu(); break;

                // Добавь сюда новые действия, если они требуют вызова методов
                default:
                    Debug.Log($"Action {action} pressed — no handler yet.");
                    break;
            }
        }

        public bool GetKey(Actions action)
        {
            return _keyBindings.ContainsKey(action) && Input.GetKey(_keyBindings[action]);
        }

        public bool GetKeyDown(Actions action)
        {
            return _keyBindings.ContainsKey(action) && Input.GetKeyDown(_keyBindings[action]);
        }

        public void AddKey(Actions action, KeyCode newKey)
        {
            _keyBindings.Add(action, newKey);
        }
        
        public void RebindKey(Actions action, KeyCode newKey)
        {
            Actions? alreadyBoundAction = null;

            foreach (var pair in _keyBindings)
            {
                if (pair.Value == newKey && pair.Key != action)
                {
                    alreadyBoundAction = pair.Key;
                    break;
                }
            }

            if (alreadyBoundAction.HasValue)
            {
                KeyCode oldKey = _keyBindings[action];
                _keyBindings[action] = newKey;
                _keyBindings[alreadyBoundAction.Value] = oldKey;

                Debug.Log($"Swapped keys: {action} ⇄ {alreadyBoundAction.Value}");
            }
            else
            {
                _keyBindings[action] = newKey;
                Debug.Log($"Rebound {action} to: {newKey}");
            }
        }

        public KeyCode GetKeyBinding(Actions action)
        {
            return _keyBindings.ContainsKey(action) ? _keyBindings[action] : KeyCode.None;
        }

        public bool HasBinding(Actions action)
        {
            return _keyBindings.ContainsKey(action);
        }
    }
}