using System.Collections;
using System.Collections.Generic;
using Script.CampSystem;
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

    private AchievementSystem _achievementSystem=new AchievementSystem();
    private CampSystem _campSystem=new CampSystem();
    private CharacterSystem _characterSystem=new CharacterSystem();
    private EnergySystem _energySystem=new EnergySystem();
    private GameEventSystem _gameEventSystem=new GameEventSystem();
    private StageSystem _stageSystem=new StageSystem();

    private UICampInfo _uiCampInfo=new UICampInfo();
    private UIGamePause _uiGamePause=new UIGamePause();
    private UISodierInfo _uiSodierInfo=new UISodierInfo();
    private UIStateInfo _uiStateInfo=new UIStateInfo();
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
        return Vector3.zero;
    }

    public void ShowCampInfo(ICamp camp)
    {
        _uiCampInfo.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier)
    {
        _characterSystem.AddSoldier(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        _characterSystem.AddEnemy(enemy);
    }
}