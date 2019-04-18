using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Camera
{
    public class CameraFacade : MonoBehaviour, ISceneCamera
    {
        private Transform m_TargetTransform;
        private float m_RotationSpeed;
        private Vector3 m_Offset;

        [Inject]
        private CameraSettings m_CameraSettings;

        void Start()
        {
            m_RotationSpeed = m_CameraSettings.RotationSpead;
            SetOffset();
        }

        private void SetOffset()
        {
            m_Offset = (m_TargetTransform.transform.position - transform.position).normalized * m_CameraSettings.CameraOffset;
        }

        public void SetTargetTransform(Transform targetTransform)
        {
            m_TargetTransform = targetTransform;
            SetOffset();
        }

        public void LateUpdate()
        {
            float horizontal = 0;
            if (Input.GetMouseButton(0))
            {
                horizontal = Input.GetAxis("Mouse X") * m_RotationSpeed;
            }

            m_TargetTransform.Rotate(0, horizontal, 0);

            float desiredAngle = m_TargetTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = m_TargetTransform.position - (rotation * m_Offset);

            transform.LookAt(m_TargetTransform);
        }
    }
}
