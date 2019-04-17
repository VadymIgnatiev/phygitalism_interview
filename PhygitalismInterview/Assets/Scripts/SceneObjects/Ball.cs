using Assets.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private int m_BallIndex;

        [Inject]
        private ITrajectoryDataSource m_TrajectorySource;
        private Vector3[] m_WayPoints;
        private int m_TargetWayPointIndex;
        private float m_MovingSpeed;
        private bool m_IsMoving;

        public int BallIndex { get { return m_BallIndex; }}

        public void Start()
        {
            m_WayPoints = m_TrajectorySource.GetWayPoints(m_BallIndex);

            if (m_WayPoints.Length > 0)
            {
                m_TargetWayPointIndex = 1;
                m_MovingSpeed = 5;
                transform.position = m_WayPoints[0];
                m_IsMoving = false;
            }
        }        

        public void Update()
        {
            if ( m_IsMoving && m_TargetWayPointIndex < m_WayPoints.Length)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_WayPoints[m_TargetWayPointIndex], m_MovingSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, m_WayPoints[m_TargetWayPointIndex]) < 0.001f)
                {
                    m_TargetWayPointIndex++;
                }
            }
        }

        public void StartMovingByTrajectory()
        {
            if (m_IsMoving) return;

            m_TargetWayPointIndex = 1;            
            transform.position = m_WayPoints[0];
            m_IsMoving = true;
        }
    }
}
