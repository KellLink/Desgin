using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityToolkit
{
    public static GameObject FindInChildren(GameObject parent, String childrenName)
    {
        //Debug.Log(parent.name+"     "+childrenName);
        Transform[] childrens = parent.GetComponentsInChildren<Transform>();

        Transform children = null;
        bool isFound = false;

        foreach (Transform transform in childrens)
        {
            if (transform.name.Equals(childrenName))
            {
                if (isFound)
                {
                    Debug.LogWarning(childrenName + "are more than 1 under" + parent);
                }

                isFound = true;
                children = transform;
            }
        }

        if (!isFound)
        {
            Debug.Log("Cannot find child name:"+childrenName);
            return null;
        }
        
        return children.gameObject;
    }

    public static void AttackChildren(GameObject parent, GameObject children)
    {
        Debug.Log(parent.name+"   "+children.name);
        children.transform.parent = parent.transform;
        children.transform.localPosition = Vector3.zero;
        children.transform.localScale=Vector3.zero;
        children.transform.localEulerAngles=Vector3.zero;
        
    }
}