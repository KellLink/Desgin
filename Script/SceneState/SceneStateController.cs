using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private ISceneState _sceneState;
    private AsyncOperation _asyncOperation;

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
        if (_sceneState != null)
        {
            _sceneState.StateUpdate();
        }

        if (_asyncOperation != null && _asyncOperation.isDone)
        {
            _sceneState.StateStart();
            _asyncOperation = null;
        }
    }
}