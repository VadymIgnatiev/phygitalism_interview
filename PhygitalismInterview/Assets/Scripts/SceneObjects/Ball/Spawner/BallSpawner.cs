using Assets.Scripts.Data;
using Assets.Scripts.Scene;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Ball.Spawner
{
    public class BallSpawner
    {
        [Inject]
        private SceneManager m_SceneManager;

        [Inject]
        private BallSpawnSettings m_BallSpawnSettings;

        [Inject]
        private BallFactory BallFactory;

        [Inject]
        private ITrajectoryDataSource m_TrajectorySource;        

        public void SpawnBalls()
        {
            int trajectoryCount = m_TrajectorySource.GetTrajectoryCount();

            float x = m_BallSpawnSettings.InitSpawnPosition.x;
            float y = m_BallSpawnSettings.InitSpawnPosition.y;
            float z = m_BallSpawnSettings.InitSpawnPosition.z;

            Vector3 newballPosition = new Vector3(x, y, z);

            for (int i = 0; i < trajectoryCount; i++)
            {
                IBallFacade ball = BallFactory.Create(i);
                //ball.Transform.position = newballPosition;
                ball.Transform.rotation = Quaternion.identity;
                m_SceneManager.AddNewBall(ball);

                x += m_BallSpawnSettings.DistanceBetweenBalls;
                newballPosition = new Vector3(x, y, z);
            }
        }
    }
}
