using System.Collections.Generic;
using UnityEngine;

namespace CustomInputSystem
{
    public class InputManager : MonoBehaviour
    {
        private TestController _testController = new();

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
                _testController.Cast_1();

            if (GetKeyDown(Actions.Cast_2))
                _testController.Cast_2();
            
            if (GetKeyDown(Actions.Cast_3))
                _testController.Cast_3();

            if (GetKeyDown(Actions.Cast_4))
                _testController.Cast_4();
            
            if (GetKeyDown(Actions.Inventory))
                _testController.SwitchInventory();

            if (GetKeyDown(Actions.Menu))
                _testController.SwitchMenu();
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
            _keyBindings[action] = newKey;
            
            Debug.Log($"Rebound {action} to : {newKey}");
        }

        public KeyCode GetKeyBinding(Actions action)
        {
            return _keyBindings[action];
        }
    }
}