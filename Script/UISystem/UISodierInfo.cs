using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISodierInfo : IUISystem
{
    private Text _hpInfo;
    private Slider _hpBar;
    private Text _levelInfo;
    private Text _soldierName;
    private Image _soldierIcon;
    private Text _attackInfo;
    private Text _attackRangeInfo;
    private Text _moveSpeedInfo;
    public override void Init()
    {
        base.Init();
        
        GameObject canvas = UIToolKits.GetCanvas();
        _rootUI = UnityToolkit.FindInChildren(canvas, "SoldierInfoUI");
        
        _hpInfo = UIToolKits.FindChild<Text>(_rootUI, "HpInfo");
        _hpBar = UIToolKits.FindChild<Slider>(_rootUI, "HpBar");
        _levelInfo = UIToolKits.FindChild<Text>(_rootUI, "LevelInfo");
        _soldierName = UIToolKits.FindChild<Text>(_rootUI, "SoldierName");
        _soldierIcon = UIToolKits.FindChild<Image>(_rootUI, "SoldierIcon");
        _attackInfo = UIToolKits.FindChild<Text>(_rootUI, "AttackInfo");
        _attackRangeInfo = UIToolKits.FindChild<Text>(_rootUI, "AttackRangeInfo");
        _moveSpeedInfo = UIToolKits.FindChild<Text>(_rootUI, "MoveSpeedInfo");
        Hide();
    }
}
