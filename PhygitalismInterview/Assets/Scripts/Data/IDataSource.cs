using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public interface IDataSource
    {
        int GetTrajectoryCount();
        List<Vector3> GetControlPoints(int trajectoryIndex);
    }
}
