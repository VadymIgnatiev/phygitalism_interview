using Assets.Scripts.SceneObjects.Ball;
using Assets.Scripts.SceneObjects.Camera;
using UnityEngine;

namespace Assets.Scripts.Static
{
    [CreateAssetMenu(fileName = "ProjectSettings", menuName = "Create ProjectSettings")]
    public class ProjectSettings : ScriptableObject
    {
        public BallSettings BallSettings;
        public CameraSettings CameraSettings;        
    }
}
