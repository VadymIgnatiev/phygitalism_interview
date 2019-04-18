using Assets.Scripts.SceneObjects.Ball.Spawner;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Scene
{
    public class SceneStarter : MonoBehaviour
    {
        [Inject]
        private SceneManager m_SceneManager;

        [Inject]
        private BallSpawner m_BallSpawner;

        public void Start()
        {
            m_BallSpawner.SpawnBalls();
            m_SceneManager.Start();
        }
    }
}
