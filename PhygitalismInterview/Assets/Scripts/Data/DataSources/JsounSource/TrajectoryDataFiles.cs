using UnityEngine;

namespace Assets.Scripts.Data.DataSources.JsounSource
{
    [CreateAssetMenu(fileName = "TrajectoryDataFiles", menuName = "Create TrajectoryDataFiles")]    
    public class TrajectoryDataFiles : ScriptableObject
    {
        [SerializeField]
        private TextAsset[] m_TrajectoryFiles;

        public int GetTrajectoryFilesLength()
        {
            return m_TrajectoryFiles.Length;
        }

        public TextAsset GetTrajectoryFile(int trajectoryIndex)
        {
            return m_TrajectoryFiles[trajectoryIndex];
        }
    }
}
