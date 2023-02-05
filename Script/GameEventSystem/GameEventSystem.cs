using System.Collections;
using System.Collections.Generic;
using Script.GameEventSystem.Observer;
using Script.GameEventSystem.Subject;
using UnityEngine;

public enum GameEventType
{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage
}

public class GameEventSystem : IGameSystem
{
    private Dictionary<GameEventType, IGameEventSubject> _gameEvents =
        new Dictionary<GameEventType, IGameEventSubject>();
    public void Init()
    {
        base.Init();
        InitGameEvents();
    }

    private void InitGameEvents()
    {
        _gameEvents.Add(GameEventType.EnemyKilled,new EnemyKilledSubject());
        _gameEvents.Add(GameEventType.SoldierKilled,new SoldierKilledSubject());
        _gameEvents.Add(GameEventType.NewStage,new NewStageSubject());
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        if (!_gameEvents.ContainsKey(eventType))
        {
            Debug.Log("No such event");
            return;
        }

        IGameEventSubject subject = _gameEvents[eventType];
        subject.RegisterObserver(observer);
        observer.SetSubject(subject);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        if (!_gameEvents.ContainsKey(eventType))
        {
            Debug.Log("No such event");
            return;
        }
        IGameEventSubject subject = _gameEvents[eventType];
        subject.RemoveObserver(observer);
        observer.SetSubject(null);
    }

    public void NotifySubject(GameEventType eventType)
    {
        if (!_gameEvents.ContainsKey(eventType))
        {
            Debug.Log("No such event");
            return;
        }
        IGameEventSubject subject = _gameEvents[eventType];
        subject.Notify();
    }

    public void Update()
    {
    }

    public void End()
    {
    }
}