using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public interface ITrajectoryDataSource
    {
        int GetTrajectoryCount();
        Vector3[] GetWayPoints(int trajectoryIndex);
    }
}
