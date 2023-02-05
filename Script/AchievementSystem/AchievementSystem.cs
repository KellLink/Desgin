using System.Collections;
using System.Collections.Generic;
using Script.GameEventSystem.Observer;
using Script.GameEventSystem.Observer.NewStageObserver;
using Script.GameEventSystem.Observer.SoldierKillObserver;
using UnityEngine;

public class AchievementSystem : IGameSystem
{
    private int _enemyKilled = 0;
    private int _soldierKilled = 0;
    private int _maxStageLevel = 1;

    public override void Init()
    {
        base.Init();
        GameFacade.Instance().RegisterObserver(GameEventType.EnemyKilled,new EnemyKilledObserverAchievement(this));
        GameFacade.Instance().RegisterObserver(GameEventType.SoldierKilled,new SoldierKilledObserverAchievement(this));
        GameFacade.Instance().RegisterObserver(GameEventType.NewStage,new NewStageObserverAchievement(this));
    }

    public void AddEnemyKilledCount(int number = 1)
    {
        _enemyKilled += number;
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        _soldierKilled += number;
    }

    public void SetMaxStageLevel(int stageLevel)
    {
        if (stageLevel>_maxStageLevel)
        {
            _maxStageLevel = stageLevel;
        }
    }

    public AchievementMemento CreateMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.EnemyKilledCount = _enemyKilled;
        memento.SoldierKilledCount = _soldierKilled;
        memento.MaxStageLevel = _maxStageLevel;
        return memento;
    }

    public void SetMemento(AchievementMemento memento)
    {
        _enemyKilled = memento.EnemyKilledCount;
        _soldierKilled = memento.SoldierKilledCount;
        _maxStageLevel = memento.MaxStageLevel;
    }
}
