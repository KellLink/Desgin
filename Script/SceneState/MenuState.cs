using UnityEngine;
using UnityEngine.UI;


public class MenuState : ISceneState
{
    private Button _startButton;
    public MenuState(SceneStateController controller) : base("02-GameMenu", controller)
    {
    }

    public override void StateStart()
    {
        _startButton = GameObject.Find("StartButton").GetComponent<Button>();
        _startButton.onClick.AddListener(StartButtonOnClick);
    }

    public override void StateEnd()
    {
        
    }

    public override void StateUpdate()
    {
        
    }

    private void StartButtonOnClick()
    {
        _controller.SetState(new PlayState(_controller));
    }
}