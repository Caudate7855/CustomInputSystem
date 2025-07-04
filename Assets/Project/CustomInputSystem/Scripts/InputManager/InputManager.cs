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
            { Actions.Cast_4, KeyCode.Alpha4},
            
            { Actions.Inventory, KeyCode.E },
            { Actions.Menu, KeyCode.Escape },
        };
        
        private void Update()
        {
            if (GetKeyDown(Actions.Cast_1))
                _globalController.Cast_1();

            if (GetKeyDown(Actions.Cast_2))
                _globalController.Cast_2();
            
            if (GetKeyDown(Actions.Cast_3))
                _globalController.Cast_3();

            if (GetKeyDown(Actions.Cast_4))
                _globalController.Cast_4();
            
            if (GetKeyDown(Actions.Inventory))
                _globalController.SwitchInventory();

            if (GetKeyDown(Actions.Menu))
                _globalController.SwitchMenu();
        }

        public bool GetKey(Actions action)
        {
            return Input.GetKey(_keyBindings[action]);
        }

        public bool GetKeyDown(Actions action)
        {
            return Input.GetKeyDown(_keyBindings[action]);
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
            return _keyBindings[action];
        }
    }
}