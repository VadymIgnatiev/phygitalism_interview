using Assets.Scripts.Data;
using Assets.Scripts.Data.DataSources.JsounSource;
using Assets.Scripts.Scene;
using Assets.Scripts.SceneObjects.Ball;
using Assets.Scripts.SceneObjects.Ball.Spawner;
using Assets.Scripts.SceneObjects.Camera;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ITrajectoryDataSource>().To<JsonTrajectoryDataSource>().AsSingle();
            Container.Bind<ISceneCamera>().FromComponentInHierarchy();
            Container.Bind<SceneManager>().AsSingle(); 
            Container.Bind<BallSpawner>().AsSingle();
            Container.BindFactory<int, IBallFacade, BallFactory>().FromFactory<BallFacade.CustomFactory>();            
        }        
    }
}
