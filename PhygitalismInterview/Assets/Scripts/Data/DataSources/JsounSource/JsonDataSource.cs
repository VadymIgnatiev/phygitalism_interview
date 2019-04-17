using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Data.DataSources.JsounSource
{
    public class JsonDataSource : BaseDataSource
    {
        [Inject]
        private TrajectoryDataFiles m_TrajectoryDataFiles;

        public override List<Vector3> GetControlPoints(int trajectoryIndex)
        {
            if (TrajectoryСache.ContainsKey(trajectoryIndex))
                return TrajectoryСache[trajectoryIndex];

            string trajectoryJson = m_TrajectoryDataFiles.GetTrajectoryFile(trajectoryIndex).text;

            TrajectoryData trajectoryData = JsonUtility.FromJson<TrajectoryData>(trajectoryJson);

            List<Vector3> result = new List<Vector3>();

            for (int i = 0; i < trajectoryData.x.Length; i++)
            {
                result.Add(new Vector3(trajectoryData.x[i], trajectoryData.y[i], trajectoryData.z[i]));
            }

            TrajectoryСache.Add(trajectoryIndex, result);

            return result;
        }        

        public override int GetTrajectoryCount()
        {
            return m_TrajectoryDataFiles.GetTrajectoryFilesLength();
        }
    }
}
