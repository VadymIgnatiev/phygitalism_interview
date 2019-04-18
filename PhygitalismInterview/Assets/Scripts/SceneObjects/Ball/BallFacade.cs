using Assets.Scripts.Data;
using Assets.Scripts.SceneObjects.Ball.Spawner;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Ball
{
    public class BallFacade : MonoBehaviour, IBallFacade
    {        
        private BallSettings m_BallSettings;

        public float MovingSpeed { get; private set; }

        [SerializeField]
        public LineRenderer LineRenderer;        

        [Inject]
        private ITrajectoryDataSource m_TrajectorySource;
        
        public int BallIndex { get; private set; }

        public Transform Transform => transform;

        private BallActionManager m_BallStateManager;
        private BallInputHandler m_BallInputHandler;        

        public void Init(BallSettings ballSettings, ITrajectoryDataSource trajectorySource, int ballIndex)
        {
            BallIndex = ballIndex;
            m_BallSettings = ballSettings;
            m_TrajectorySource = trajectorySource;
            MovingSpeed = m_BallSettings.MaxBallSpeed;
            m_BallInputHandler = new BallInputHandler(m_BallSettings.DoubleClickSensitivity);
            m_BallStateManager = new BallActionManager(this, m_TrajectorySource, m_BallInputHandler, m_BallSettings);            
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

        public void AdjustBallSpeed(float value)
        {
            MovingSpeed = m_BallSettings.MaxBallSpeed * value;
        }

        //public class Factory : Factory<int, IBallFacade> { }

        public class CustomFactory : IFactory<int, IBallFacade>
        {
            [Inject]
            private BallSettings m_BallSettings;            

            [Inject]
            private ITrajectoryDataSource m_TrajectorySource;

            [Inject]
            private BallSpawnSettings m_BallSpawnSettings;

            public IBallFacade Create(int ballIndex)
            {
                GameObject ball = GameObject.Instantiate(m_BallSpawnSettings.BallPrefab);
                IBallFacade ballFacade = ball.GetComponent<IBallFacade>();
                ballFacade.Init(m_BallSettings, m_TrajectorySource, ballIndex);
                return ballFacade;
            }
        }
    }
}
