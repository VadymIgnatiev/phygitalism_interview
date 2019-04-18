using UnityEngine;
using Zenject;

namespace Assets.Scripts.SceneObjects.Camera
{
    public class CameraFacade : MonoBehaviour
    {
        public GameObject target;
        public float rotateSpeed = 5;
        public Vector3 offset;

        [Inject]
        private CameraSettings m_CameraSettings;

        void Start()
        {
            offset = target.transform.position - transform.position;
        }

        void LateUpdate()
        {
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.transform.Rotate(0, horizontal, 0);

            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = target.transform.position - (rotation * offset);

            transform.LookAt(target.transform);
        }
    }
}
