using System;
using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.Vistor;
using UnityEngine;
using UnityEngine.UI;

public class UIStateInfo : IUISystem
{
    private List<GameObject> _hearts = new List<GameObject>();
    private Text _soldierCount;
    private Text _enemyCount;
    private Text _stageCount;
    private Slider _energyBar;
    private Text _energyText;
    private GameObject _gameOverUI;
    private Button _pauseButton;
    private Text _message;

    private float _msgTime = 0;
    private float _msgMaxTime = 2;

    private AliveCountVisitor _aliveVisitor = new AliveCountVisitor();

    public override void Init()
    {
       
        GameObject canvas = GameObject.Find("Canvas");
        //GameStateUI
        _rootUI = UnityToolkit.FindInChildren(canvas, "GameStateUI");

        GameObject heart1 = UnityToolkit.FindInChildren(_rootUI, "heart1");
        GameObject heart2 = UnityToolkit.FindInChildren(_rootUI, "heart2");
        GameObject heart3 = UnityToolkit.FindInChildren(_rootUI, "heart3");
        _hearts.Add(heart1);
        _hearts.Add(heart2);
        _hearts.Add(heart3);

        _soldierCount = UIToolKits.FindChild<Text>(_rootUI, "SoldierCount");
        _enemyCount = UIToolKits.FindChild<Text>(_rootUI, "EnemyCount");
//        _stageCount = UIToolKits.FindChild<Text>(_rootUI, "StageCount");
        _energyBar = UIToolKits.FindChild<Slider>(_rootUI, "EnergyBar");
        _energyText = UIToolKits.FindChild<Text>(_rootUI, "EnergyText");
        _pauseButton = UIToolKits.FindChild<Button>(_rootUI, "PauseButton");
        _message = UIToolKits.FindChild<Text>(_rootUI, "Message");
        _gameOverUI = UnityToolkit.FindInChildren(_rootUI, "GameOver");
        
        _pauseButton.onClick.AddListener(PauseButtonOnClick);

        _message.text = "";

        Hide(_gameOverUI);
    }

    public void ShowMessage(String msg)
    {
        _message.text = msg;
        _msgTime = _msgMaxTime;
    }

    public override void Update()
    {
        base.Update();
        if (_msgTime >= 0)
        {
            _msgTime -= Time.deltaTime;
            if (_msgTime <= 0)
            {
                _message.text = "";
            }
        }

        UpdateAliveCount();
    }

    public void UpdateEnergyBar(int currentEnergy,int maxEnergy)
    {
        _energyBar.value = (float)currentEnergy / maxEnergy;
        _energyText.text = currentEnergy + " / " + maxEnergy;
    }

    public void UpdateAliveCount()
    {
        _aliveVisitor.Reset();
        GameFacade.Instance().RunVisitor(_aliveVisitor);
        _soldierCount.text = "战士数量：" + _aliveVisitor.SoldierCount;
        _enemyCount.text = "敌人数量：" + _aliveVisitor.EnemyCount;
    }

    public void PauseButtonOnClick()
    {
        GameFacade.Instance().ShowPause();
    }
}