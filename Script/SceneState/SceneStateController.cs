using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private static SceneStateController _sceneStateController;  
    private SceneStateController (){}  
  
    public static SceneStateController Instance() {  
        if (_sceneStateController == null) {  
            _sceneStateController = new SceneStateController();  
        }  
        return _sceneStateController;  
    }
    
    private ISceneState _sceneState;
    private AsyncOperation _asyncOperation = null;

    public void SetState(ISceneState state, bool loadScene = true)
    {
        if (_sceneState != null)
        {
            _sceneState.StateEnd();
        }

        _sceneState = state;
        if (loadScene)
        {
            _asyncOperation = SceneManager.LoadSceneAsync(_sceneState.GetSceneName());
        }
        else
        {
            _sceneState.StateStart();
        }
    }

    public void StateUpdate()
    {
        if (_asyncOperation != null && _asyncOperation.isDone)
        {
            _sceneState.StateStart();
            _asyncOperation = null;
        }

        if (_sceneState != null && _asyncOperation == null)
        {
            _sceneState.StateUpdate();
        }
    }
}