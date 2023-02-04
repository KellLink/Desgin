using System;
using UnityEngine;

namespace Script.Tools
{
    public class DestroyObject : MonoBehaviour
    {
        private void Start()
        {
            Invoke("DestroyGameObject", 1f);
        }

        private void DestroyGameObject()
        {
            DestroyObject(this.gameObject);
        }
    }
}