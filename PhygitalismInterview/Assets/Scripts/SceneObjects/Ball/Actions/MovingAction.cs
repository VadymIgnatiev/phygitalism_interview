using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Ball.Actions
{
    public class MovingAction : IBallAction
    {
        private ITrajectoryDataSource m_TrajectorySource;

        private BallFacade m_Ball;
        private Vector3[] m_WayPoints;
        private int m_TargetWayPointIndex;

        public bool IsComplited { get; private set; }

        public MovingAction(BallFacade ball, ITrajectoryDataSource trajectorySource)
        {
            m_Ball = ball;
            m_TrajectorySource = trajectorySource;

            m_WayPoints = m_TrajectorySource.GetWayPoints(m_Ball.BallIndex);

            if (m_WayPoints.Length > 0)
            {
                m_TargetWayPointIndex = 1;                                
            }
        }

        public void StartAction()
        {
            m_TargetWayPointIndex = 1;
            m_Ball.transform.position = m_WayPoints[0];
            IsComplited = false;
        }

        public void Update()
        {
            if (m_TargetWayPointIndex < m_WayPoints.Length)
            {
                m_Ball.transform.position = Vector3.MoveTowards(m_Ball.transform.position, m_WayPoints[m_TargetWayPointIndex], m_Ball.MovingSpeed * Time.deltaTime);

                if (Vector3.Distance(m_Ball.transform.position, m_WayPoints[m_TargetWayPointIndex]) < 0.001f)
                {
                    m_TargetWayPointIndex++;
                }
            }
            else
            {
                IsComplited = true;
            }
        }
    }
}
