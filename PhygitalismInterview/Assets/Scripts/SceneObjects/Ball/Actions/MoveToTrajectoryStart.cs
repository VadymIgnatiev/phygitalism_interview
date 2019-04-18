using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Ball.Actions
{
    public class MoveToTrajectoryStart : IBallAction
    {
        private ITrajectoryDataSource m_TrajectorySource;

        private BallFacade m_Ball;
        private Vector3[] m_WayPoints;        

        public bool IsComplited { get; private set; }

        public MoveToTrajectoryStart(BallFacade ball, ITrajectoryDataSource trajectorySource)
        {
            m_Ball = ball;
            m_TrajectorySource = trajectorySource;

            m_WayPoints = m_TrajectorySource.GetWayPoints(m_Ball.BallIndex);
            IsComplited = false;               
        }

        public void StartAction()
        {
            if (m_WayPoints.Length > 0)
            {                
                m_Ball.transform.position = m_WayPoints[0];                
            }

            IsComplited = true;
            m_Ball.LineRenderer.positionCount = 0;
        }

        public void Update()
        {            
        }
    }
}
