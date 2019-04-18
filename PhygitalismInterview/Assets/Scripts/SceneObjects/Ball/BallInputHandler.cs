using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Ball
{
    public class BallInputHandler
    {
        private readonly float m_DoubleClickSensitivity;
        private float LastClickedTime;
        private bool m_IsClicked;

        public event Action SingleMouseClick = () => { };
        public event Action DoubleMouseClick = () => { };

        public BallInputHandler(float doubleClickSensitivity)
        {
            m_DoubleClickSensitivity = doubleClickSensitivity;
        }

        public void HandleMouseClick()
        {
            if (!m_IsClicked)
            {
                m_IsClicked = true;
                LastClickedTime = Time.time;
            }
            else
            {
                if (Time.time - LastClickedTime < m_DoubleClickSensitivity)
                {                    
                    DoubleMouseClick();
                    m_IsClicked = false;                    
                }
            }
        }

        public void Update()
        {
            if (m_IsClicked && Mathf.Abs(Time.time - LastClickedTime) > m_DoubleClickSensitivity)
            {                
                SingleMouseClick();
                m_IsClicked = false;
            }
        }
    }
}
