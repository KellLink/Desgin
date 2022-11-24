using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState
{
    private Image _logoImage;
    private float _colorSpeed = 0.5f;
    private float _logoMaxTime = 3f;
    private float _logoCurrentIime = 0f;

    public StartState(SceneStateController controller) : base("01-GameStart", controller)
    {
    }

    public override void StateStart()
    {
        _logoImage = GameObject.Find("Logo").GetComponent<Image>();
        _logoImage.color = Color.black;
    }

    public override void StateUpdate()
    {
        _logoImage.color = Color.Lerp(_logoImage.color, Color.white, Time.deltaTime * _colorSpeed);
        _logoCurrentIime += Time.deltaTime;
        if (_logoCurrentIime > _logoMaxTime)
        {
            base._controller.SetState(new MenuState(_controller));
        }
    }

    public override void StateEnd()
    {
        
    }
}