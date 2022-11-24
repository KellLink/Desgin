using System.Collections;
using System.Collections.Generic;
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

    private AchievementSystem _achievementSystem;
    private CampSystem _campSystem;
    private CharacterSystem _characterSystem;
    private EnergySystem _energySystem;
    private GameEventSystem _gameEventSystem;
    private StageSystem _stageSystem;

    private UICampInfo _uiCampInfo;
    private UIGamePause _uiGamePause;
    private UISodierInfo _uiSodierInfo;
    private UIStateInfo _uiStateInfo;
    public void Init()
    {
        _achievementSystem.Init();
        _campSystem.Init();
        _characterSystem.Init();
        _energySystem.Init();
        _gameEventSystem.Init();
        _stageSystem.Init();
        
        _uiCampInfo.Init();
        _uiGamePause.Init();
        _uiSodierInfo.Init();
        _uiStateInfo.Init();
    }

    public void Update()
    {
        _achievementSystem.Update();
        _campSystem.Update();
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
}