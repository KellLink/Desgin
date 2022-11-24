public class PlayState : ISceneState
{
    public PlayState(SceneStateController controller) : base("03-GamePlay", controller)
    {
        
    }

    public override void StateStart()
    {
        GameFacade.Instance().Init();
    }

    public override void StateEnd()
    {
        GameFacade.Instance().End();
    }

    public override void StateUpdate()
    {
        if (!GameFacade.Instance().IsGameOver)
        {
            GameFacade.Instance().Update();
        }
        else
        {
            _controller.SetState(new MenuState(_controller));
        }
    }
}