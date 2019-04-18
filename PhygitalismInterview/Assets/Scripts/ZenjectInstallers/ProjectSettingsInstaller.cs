using Assets.Scripts.SceneObjects.Ball;
using Assets.Scripts.SceneObjects.Camera;
using Assets.Scripts.Static;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.ZenjectInstallers
{
    [CreateAssetMenu(fileName = "ProjectSettingsInstaller", menuName = "Create ProjectSettings")]
    class ProjectSettingsInstaller : ScriptableObjectInstaller<ProjectSettingsInstaller>
    {
        public BallSettings BallSettings;
        public CameraSettings CameraSettings;

        public override void InstallBindings()
        {            
            Container.BindInstance(BallSettings).IfNotBound();
            Container.BindInstance(CameraSettings).IfNotBound();
        }
    }
}
