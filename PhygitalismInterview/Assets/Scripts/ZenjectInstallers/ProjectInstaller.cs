using Assets.Scripts.Data;
using Assets.Scripts.Data.DataSources.JsounSource;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ITrajectoryDataSource>().To<JsonTrajectoryDataSource>().AsSingle();            
        }
    }
}
