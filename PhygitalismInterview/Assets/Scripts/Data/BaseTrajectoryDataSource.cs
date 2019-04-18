using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public abstract class BaseTrajectoryDataSource : ITrajectoryDataSource
    {
        protected Dictionary<int, Vector3[]> TrajectoryСache;

        public BaseTrajectoryDataSource()
        {
            TrajectoryСache = new Dictionary<int, Vector3[]>();
        }

        public abstract Vector3[] GetWayPoints(int trajectoryIndex);
        public abstract int GetTrajectoryCount();        
    }
}
