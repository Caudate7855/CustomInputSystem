using UnityEditor;
using UnityEngine;

namespace Editor.InputSystem.InputMaps
{
    public class KeyboardWindow: EditorWindow
    {
        string myText = "Привет, редактор!";
        bool toggle = false;


        [MenuItem("InputSystem/Keyboard Layout")]
        public static void ShowKeyboardLayoutWindow()
        {
            GetWindow<KeyboardWindow>("Keyboard Layout");
        }
        
        private void OnGUI()
        {
            GUILayout.Label("Моё кастомное окно", EditorStyles.boldLabel);

            myText = EditorGUILayout.TextField("Текст:", myText);
            toggle = EditorGUILayout.Toggle("Включить что-то", toggle);

            if (GUILayout.Button("Нажми меня"))
            {
                Debug.Log("Нажата кнопка! Текст: " + myText + ", Тоггл: " + toggle);
            }
        }
    }
}