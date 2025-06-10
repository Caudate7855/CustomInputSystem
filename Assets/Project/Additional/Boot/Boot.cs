using System;
using UnityEngine;

namespace CustomInputSystem.Boot
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private CustomInputController _customInputController;
        
        private void Awake()
        {
            _customInputController.BindAction(KeyCode.Alpha1, DoCast1);
            _customInputController.BindAction(KeyCode.Alpha2, DoCast2);
            _customInputController.BindAction(KeyCode.Alpha3, DoCast3);
            _customInputController.BindAction(KeyCode.Alpha4, DoCast4);
        }

        private void DoCast1()
        {
            Debug.Log("DoCast1");
        }
        
        private void DoCast2()
        {
            Debug.Log("DoCast2");
        }
        
        private void DoCast3()
        {
            Debug.Log("DoCast3");
        }
        
        private void DoCast4()
        {
            Debug.Log("DoCast4");
        }
    }
}