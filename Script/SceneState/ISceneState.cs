using System;

public class ISceneState
{
    private String _sceneName;
    protected SceneStateController _controller;

    public ISceneState(string sceneName,SceneStateController controller)
    {
        _sceneName = sceneName;
        _controller = controller;
    }

    public String GetSceneName()
    {
        return _sceneName;
    }

    public virtual void StateStart()
    {
        
    }
    public virtual void StateEnd()
    {
        
    }
    public virtual void StateUpdate()
    {
        
    }
}