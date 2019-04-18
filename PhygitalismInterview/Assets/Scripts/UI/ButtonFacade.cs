using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class ButtonFacade : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            ProcessCall(); // TODO: make waiting    
        }

        public Action ProcessCall = () => { };
    }
}
