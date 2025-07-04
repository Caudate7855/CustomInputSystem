using System;
using System.Collections.Generic;
using CustomInputSystem;
using UnityEditor;
using UnityEngine;

namespace Editor.InputSystem.InputMaps
{
    public class KeyboardWindow : EditorWindow
    {
        private KeyCodeConverter  _keyCodeConverter = new();
        
        private static Dictionary<Actions, string> _displayNames = new()
        {
            { Actions.Cast_1, "Каст 1" },
            { Actions.Cast_2, "Каст 2" },
            { Actions.Cast_3, "Каст 3" },
            { Actions.Cast_4, "Каст 4" },
            { Actions.Inventory, "Инвентарь" },
            { Actions.Menu, "Меню" }
        };

        private Actions? waitingForBind = null;

        [MenuItem("InputSystem/Keyboard Layout")]
        public static void ShowKeyboardLayoutWindow()
        {
            GetWindow<KeyboardWindow>("Keyboard Layout");
        }

        private void OnGUI()
        {
            GUILayout.Label("Назначение клавиш", EditorStyles.boldLabel);

            foreach (var action in Enum.GetValues(typeof(Actions)))
            {
                DrawBindingRow((Actions)action);
            }

            if (waitingForBind.HasValue)
            {
                GUILayout.Space(10);
                GUILayout.Label("Нажмите любую клавишу...", EditorStyles.helpBox);

                Event e = Event.current;
                if (e.isKey)
                {
                    InputManager inputManager = FindObjectOfType<InputManager>();
                    if (inputManager != null)
                    {
                        inputManager.RebindKey(waitingForBind.Value, e.keyCode);
                        Repaint();
                    }

                    waitingForBind = null;
                    GUIUtility.keyboardControl = 0;
                }

                GUI.FocusControl(null);
            }
        }

        private void DrawBindingRow(Actions action)
        {
            InputManager inputManager = FindObjectOfType<InputManager>();
            if (inputManager == null) return;

            GUILayout.BeginHorizontal();

            GUILayout.Label(_displayNames.ContainsKey(action) ? _displayNames[action] : action.ToString(),
                GUILayout.Width(150));
            GUILayout.Label(_keyCodeConverter.GetKeyCodeView(inputManager.GetKeyBinding(action)), GUILayout.Width(100));

            if (waitingForBind == null && GUILayout.Button("Изменить", GUILayout.Width(100)))
            {
                waitingForBind = action;
            }

            GUILayout.EndHorizontal();

            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        }
    }
}