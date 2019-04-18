using Assets.Scripts.Scene;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class MenuFacade : MonoBehaviour
    {
        public ButtonFacade LeftButtonFacade;
        public ButtonFacade RightButtonFacade;

        [Inject]
        public SceneManager m_SceneManager;

        public void Start()
        {
            LeftButtonFacade.ProcessCall = () => {
                
            };

            LeftButtonFacade.ProcessCall = () => {

            };
        }
        
    }
}
