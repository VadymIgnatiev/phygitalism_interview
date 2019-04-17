using Assets.Scripts.Data;
using Assets.Scripts.Data.DataSources.JsounSource;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    public class ProjectInstallerInstaller : MonoInstaller<ProjectInstallerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IDataSource>().To<JsonDataSource>().AsSingle();            
        }
    }
}
