using UnityEngine;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    public class ProjectInstallerInstaller : MonoInstaller<ProjectInstallerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");            
        }
    }
}
