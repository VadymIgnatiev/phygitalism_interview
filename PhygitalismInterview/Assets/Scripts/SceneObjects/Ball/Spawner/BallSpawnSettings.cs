using System;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Ball.Spawner
{
    [Serializable]
    public class BallSpawnSettings
    {
        public GameObject BallPrefab;
        public Vector3 InitSpawnPosition;
        public float DistanceBetweenBalls;
    }
}
