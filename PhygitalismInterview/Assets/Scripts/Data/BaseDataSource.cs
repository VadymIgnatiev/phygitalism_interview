using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public abstract class BaseDataSource : IDataSource
    {
        protected Dictionary<int, List<Vector3>> TrajectoryСache;

        public BaseDataSource()
        {
            TrajectoryСache = new Dictionary<int, List<Vector3>>();
        }

        public abstract List<Vector3> GetControlPoints(int trajectoryIndex);
        public abstract int GetTrajectoryCount();        
    }
}
