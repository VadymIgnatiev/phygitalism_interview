using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Ball.Actions
{
    public class MoveDrawTrajectoryAction : IBallAction
    {
        private ITrajectoryDataSource m_TrajectorySource;

        private BallFacade m_Ball;
        private Vector3[] m_WayPoints;
        private int m_TargetWayPointIndex;
        private float MovingPrecision;

        public bool IsComplited { get; private set; }

        public MoveDrawTrajectoryAction(BallFacade ball, ITrajectoryDataSource trajectorySource, BallSettings ballSettings)
        {
            m_Ball = ball;
            m_TrajectorySource = trajectorySource;

            m_WayPoints = m_TrajectorySource.GetWayPoints(m_Ball.BallIndex);            

            MovingPrecision = ballSettings.MovingPrecision;            
        }

        private List<Vector3> DrawPoints = new List<Vector3>();

        public void StartAction()
        {
            m_TargetWayPointIndex = 1;
            m_Ball.transform.position = m_WayPoints[0];
            IsComplited = false;
            m_Ball.LineRenderer.positionCount = 2;
            m_Ball.LineRenderer.SetPosition(0, m_Ball.transform.position);            
        }

        public void Update()
        {
            if (m_TargetWayPointIndex < m_WayPoints.Length)
            {
                m_Ball.transform.position = Vector3.MoveTowards(m_Ball.transform.position, m_WayPoints[m_TargetWayPointIndex], m_Ball.MovingSpeed * Time.deltaTime);

                if (Vector3.Distance(m_Ball.transform.position, m_WayPoints[m_TargetWayPointIndex]) < MovingPrecision)
                {
                    m_TargetWayPointIndex++;
                    m_Ball.LineRenderer.positionCount++;
                }

                m_Ball.LineRenderer.SetPosition(m_TargetWayPointIndex, m_Ball.transform.position);
            }
            else
            {
                IsComplited = true;
            }
        }
    }
}
