using System;
using System.Collections.Generic;
using CustomInputSystem;
using UnityEngine;

namespace Editor.InputSystem
{
    [CreateAssetMenu(fileName = "KeyMap", menuName = "InputSystem/KeyMap")]
    public class KeyMap : ScriptableObject
    {
        public List<GameAction>  GameAction = new();
    }

    [Serializable]
    public class GameAction
    {
        public Actions Actions;
        public KeyCode KeyCode;
    }
}