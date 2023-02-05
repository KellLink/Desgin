using System;
using System.Collections;
using System.Collections.Generic;
using Script.CampSystem;
using Script.CharacterSystem.Vistor;
using Script.GameEventSystem.Observer;
using UnityEngine;

public class GameFacade
{
    private static GameFacade _gameFacade = new GameFacade();

    public static GameFacade Instance()
    {
        return _gameFacade;
    }

    private GameFacade()
    {
    }

    private bool _isGameOver = false;

    public bool IsGameOver
    {
        get { return _isGameOver; }
    }

    private AchievementSystem _achievementSystem = new AchievementSystem();
    private CampSystem _campSystem = new CampSystem();
    private CharacterSystem _characterSystem = new CharacterSystem();
    private EnergySystem _energySystem = new EnergySystem();
    private GameEventSystem _gameEventSystem = new GameEventSystem();
    private StageSystem _stageSystem = new StageSystem();

    private UICampInfo _uiCampInfo = new UICampInfo();
    private UIGamePause _uiGamePause = new UIGamePause();
    private UISodierInfo _uiSodierInfo = new UISodierInfo();
    private UIStateInfo _uiStateInfo = new UIStateInfo();

    public void Init()
    {
        _gameEventSystem.Init();
        _achievementSystem.Init();
        _campSystem.Init();
        _characterSystem.Init();
        _stageSystem.Init();
        _energySystem.Init();
        
        _uiCampInfo.Init();
        _uiGamePause.Init();
        _uiSodierInfo.Init();
        _uiStateInfo.Init();
        
        LoadMemento();
    }

    public void Update()
    {
        _campSystem.Update();
        _achievementSystem.Update();
        _characterSystem.Update();
        _energySystem.Update();
        _gameEventSystem.Update();
        _stageSystem.Update();

        _uiCampInfo.Update();
        _uiGamePause.Update();
        _uiSodierInfo.Update();
        _uiStateInfo.Update();
    }

    public void End()
    {
        CreateMemento();
        
        _achievementSystem.End();
        _campSystem.End();
        _characterSystem.End();
        _energySystem.End();
        _gameEventSystem.End();
        _stageSystem.End();

        _uiCampInfo.End();
        _uiGamePause.End();
        _uiSodierInfo.End();
        _uiStateInfo.End();
    }

    public Vector3 GetEnemyTargetPosition()
    {
        //TODO 
        return _stageSystem.TargetPosition;
    }

    public void ShowCampInfo(ICamp camp)
    {
        _uiCampInfo.ShowCampInfo(camp);
    }

    public void ShowPause()
    {
        _uiGamePause.ShowPause();
    }
    
    public void HidePause()
    {
        _uiGamePause.HidePause();
    }

    public void AddSoldier(ISoldier soldier)
    {
        _characterSystem.AddSoldier(soldier);
    }

    public void RemoveSoldier(ISoldier soldier)
    {
        _characterSystem.RemoveSoldier(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        _characterSystem.AddEnemy(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        _characterSystem.RemoveEnemy(enemy);
    }

    public bool ConsumEnergy(int energy)
    {
        return _energySystem.ConsumEnergy(energy);
    }

    public void ShowMessage(String msg)
    {
        _uiStateInfo.ShowMessage(msg);
    }

    public void RecycleEnergy(int energy)
    {
        _energySystem.RecycleEnergy(energy);
    }

    public void UpdateEnergyBar(int currentEnergy, int maxEnergy)
    {
        _uiStateInfo.UpdateEnergyBar(currentEnergy, maxEnergy);
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        _gameEventSystem.RegisterObserver(eventType, observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        _gameEventSystem.RegisterObserver(eventType, observer);
    }

    public void NotifySubject(GameEventType eventType)
    {
        _gameEventSystem.NotifySubject(eventType);
    }

    public void LoadMemento()
    {
        AchievementMemento memento = _achievementSystem.CreateMemento();
        memento.LoadData();
        _achievementSystem.SetMemento(memento);
    }

    public void CreateMemento()
    {
        AchievementMemento memento = _achievementSystem.CreateMemento();
        memento.SaveData();
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        _characterSystem.RunVisitor(visitor);
    }
    
    
}