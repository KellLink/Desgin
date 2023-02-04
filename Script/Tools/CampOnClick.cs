using System;
using Script.CampSystem;
using UnityEngine;

namespace Script.Tools
{
    public class CampOnClick : MonoBehaviour
    {
        private ICamp _camp;
        public ICamp Camp
        {
            set { _camp = value; }
        }
        public void OnMouseUpAsButton()
        {
            GameFacade.Instance().ShowCampInfo(_camp);
        }
    }
}