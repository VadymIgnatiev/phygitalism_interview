using Assets.Scripts.Scene;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class MenuFacade : MonoBehaviour
    {
        public ButtonFacade LeftButtonFacade;
        public ButtonFacade RightButtonFacade;
        public Slider Slider;

        [Inject]
        public SceneManager m_SceneManager;

        public Action<float> ChangeSpeedValue;

        private float LastSpeedValue;

        public void Start()
        {
            LeftButtonFacade.ProcessCall = () => {                
                m_SceneManager.ActivePreviousBall();
            };

            RightButtonFacade.ProcessCall = () => {               
                m_SceneManager.ActiveNextBall();
            };

            LastSpeedValue = Slider.value;               
        }

        public void LateUpdate()
        {
            if (LastSpeedValue != Slider.value)
            {
                m_SceneManager.SetBallSpeedValue(Slider.value);
                LastSpeedValue = Slider.value;
            }
        }
    }
}
