using System;
using UnityEngine;



    public static class UIToolKits
        {
            public static GameObject GetCanvas(String name = "Canvas")
            {
                return GameObject.Find(name);
            }
    
            public static T FindChild<T>(GameObject parent, String childName)
            {
                return UnityToolkit.FindInChildren(parent, childName).GetComponent<T>();
            }
        }
