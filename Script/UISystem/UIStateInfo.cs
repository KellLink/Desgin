using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStateInfo : IUISystem
{
    private List<GameObject> _hearts=new List<GameObject>();
    private Text _soldierCount;
    private Text _enemyCount;
    private Text _stageCount;
    private Slider _energyBar;
    private Text _energyText;
    private GameObject _gameOverUI;
    private Button _returnToMenuButton;
    private Text _message;
    public override void Init()
    {
        base.Init();
        
        GameObject canvas = GameObject.Find("Canvas");
        _rootUI = UnityToolkit.FindInChildren(canvas,"GameStateUI");

        GameObject heart1 = UnityToolkit.FindInChildren(_rootUI, "heart1");
        GameObject heart2 = UnityToolkit.FindInChildren(_rootUI, "heart2");
        GameObject heart3 = UnityToolkit.FindInChildren(_rootUI, "heart3");
        _hearts.Add(heart1);
        _hearts.Add(heart2);
        _hearts.Add(heart3);
        
        _soldierCount=UIToolKits.FindChild<Text>(_rootUI, "SoldierCount");
        _enemyCount=UIToolKits.FindChild<Text>(_rootUI, "EnemyCount");
        _stageCount=UIToolKits.FindChild<Text>(_rootUI, "StageCount");
        _energyBar=UIToolKits.FindChild<Slider>(_rootUI, "EnergyBar");
        _energyText=UIToolKits.FindChild<Text>(_rootUI, "EnergyText");
        _returnToMenuButton=UIToolKits.FindChild<Button>(_rootUI, "ReturnToMenuButton");
        _message=UIToolKits.FindChild<Text>(_rootUI, "Message");
        _gameOverUI=UnityToolkit.FindInChildren(_rootUI, "GameOver");
        
        Hide(_gameOverUI);
    }
}
