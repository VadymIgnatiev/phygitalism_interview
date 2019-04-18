using Assets.Scripts.Data.DataSources.JsounSource;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    [CreateAssetMenu(fileName = "TrajectoryDataFilesInstaller", menuName = "Create TrajectoryDataFilesInstaller")]
    public class TrajectoryDataSourceInstaller : ScriptableObjectInstaller<TrajectoryDataSourceInstaller>
    {
        [SerializeField]
        private TrajectoryDataFiles m_TrajectoryDataFiles;

        public override void InstallBindings()
        {
            Container.BindInstance(m_TrajectoryDataFiles);
        }
    }
}
