using Assets.Scripts.SceneObjects.Ball;
using Assets.Scripts.SceneObjects.Camera;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Scene
{
    public class SceneManager
    {
        [Inject]
        private ISceneCamera m_SceneCamera;

        private List<IBallFacade> m_Balls;        

        private int m_CurrentActiveBall;

        public SceneManager()
        {
            m_Balls = new List<IBallFacade>();
        }

        public void Start()
        {
            if (m_Balls.Count > 0)
            {
                m_SceneCamera.SetTargetTransform(m_Balls[0].Transform);
            }
        }

        public void AddNewBall(IBallFacade ball)
        {
            m_Balls.Add(ball);
        }

        public void ActiveNextBall()
        {
            m_Balls[m_CurrentActiveBall].AdjustBallSpeed(0);

            if (m_CurrentActiveBall == m_Balls.Count - 1)
            {
                m_CurrentActiveBall = 0;
                return;
            }

            m_CurrentActiveBall++;
            ActiveBall();
        }

        public void ActivePreviousBall()
        {
            m_Balls[m_CurrentActiveBall].AdjustBallSpeed(0);

            if (m_CurrentActiveBall == 0)
            {
                m_CurrentActiveBall = m_Balls.Count - 1;
                return;
            }

            m_CurrentActiveBall--;
            ActiveBall();
        }

        private void ActiveBall()
        {
            m_SceneCamera.SetTargetTransform(m_Balls[m_CurrentActiveBall].Transform);
            m_Balls[m_CurrentActiveBall].AdjustBallSpeed(0);
        }
    }
}
