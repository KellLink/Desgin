using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUISystem
{
    public GameObject _rootUI;
    public virtual void Init()
    {
        
    }

    public virtual void Update()
    {
        
    }
    public  virtual void  End()
    {
        
    }

    public void Show()
    {
        _rootUI.SetActive(true);
    }

    public void Hide()
    {
        _rootUI.SetActive(false);
    }

    public void Show(GameObject go)
    {
        go.SetActive(true);
    }

    public void Hide(GameObject go)
    {
        go.SetActive(false);
    }
}
