using Assets.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Ball
{
    public class BallFacade : MonoBehaviour
    {
        [SerializeField]
        private int m_BallIndex;

        [Inject]
        private BallSettings m_BallSettings;

        public float MovingSpeed { get; private set; }

        [Inject]
        private ITrajectoryDataSource m_TrajectorySource;
        
        public int BallIndex { get { return m_BallIndex; }}

        private BallActionManager m_BallStateManager;
        private BallInputHandler m_BallInputHandler;

        public void Start()
        {
            MovingSpeed = m_BallSettings.MaxBallSpeed;
            m_BallInputHandler = new BallInputHandler(m_BallSettings.DoubleClickSensitivity);
            m_BallStateManager = new BallActionManager(this, m_TrajectorySource, m_BallInputHandler);            
        }        

        public void Update()
        {
            m_BallInputHandler.Update();
            m_BallStateManager.Update();
        }        

        void OnMouseDown()
        {
            m_BallInputHandler.HandleMouseClick();
        }

    }
}
