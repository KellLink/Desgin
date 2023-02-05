using System.Collections;
using System.Collections.Generic;
using Script.GameEventSystem.Observer;
using Script.StageSystem;
using UnityEngine;


public class StageSystem : IGameSystem
{
    private int _level = 1;
    private List<Vector3> _spawnPositions = new List<Vector3>();
    private IStageHandler _firstHandler;
    private Vector3 _targetPosition = Vector3.zero;

    private int _numOfEnemyKilled = 0;

    public override void Init()
    {
        base.Init();
        InitSpawnPosition();
        InitStageChin();

        GameFacade.Instance().RegisterObserver(GameEventType.EnemyKilled, new EventKilledObserverStageSystem(this));
    }

    public override void Update()
    {
        base.Update();
        _firstHandler.Handler(_level);
    }

    private void InitSpawnPosition()
    {
        int i = 1;
        while (true)
        {
            GameObject spawn = GameObject.Find("SpawnPosition" + i);
            if (spawn != null)
            {
                _spawnPositions.Add(spawn.transform.position);
                spawn.SetActive(false);
                i++;
            }
            else
            {
                break;
            }
        }

        GameObject target = GameObject.Find("Base");
        _targetPosition = target.transform.position;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Count - 1)];
    }

    private void InitStageChin()
    {
        int level = 1;
        NormalStageHandler handler1 =
            new NormalStageHandler(level++, 3, this, EnemyType.Elf, WeaponType.Gun, 3, GetRandomSpawnPosition());
        NormalStageHandler handler2 = new NormalStageHandler(level++, 6, this, EnemyType.Elf, WeaponType.Rifle, 3,
            GetRandomSpawnPosition());
        NormalStageHandler handler3 = new NormalStageHandler(level++, 9, this, EnemyType.Elf, WeaponType.Rocket, 3,
            GetRandomSpawnPosition());
        NormalStageHandler handler4 = new NormalStageHandler(level++, 14, this, EnemyType.Orge, WeaponType.Gun, 5,
            GetRandomSpawnPosition());
        NormalStageHandler handler5 = new NormalStageHandler(level++, 19, this, EnemyType.Orge, WeaponType.Rifle, 5,
            GetRandomSpawnPosition());
        NormalStageHandler handler6 = new NormalStageHandler(level++, 24, this, EnemyType.Orge, WeaponType.Rocket, 5,
            GetRandomSpawnPosition());
        NormalStageHandler handler7 = new NormalStageHandler(level++, 32, this, EnemyType.Troll, WeaponType.Gun, 8,
            GetRandomSpawnPosition());
        NormalStageHandler handler8 = new NormalStageHandler(level++, 40, this, EnemyType.Troll, WeaponType.Rifle, 8,
            GetRandomSpawnPosition());
        NormalStageHandler handler9 = new NormalStageHandler(level++, 48, this, EnemyType.Troll, WeaponType.Rocket, 8,
            GetRandomSpawnPosition());

        handler1.SetNextStageHandler(handler2)
            .SetNextStageHandler(handler3)
            .SetNextStageHandler(handler4)
            .SetNextStageHandler(handler5)
            .SetNextStageHandler(handler6)
            .SetNextStageHandler(handler7)
            .SetNextStageHandler(handler8)
            .SetNextStageHandler(handler9);

        _firstHandler = handler1;
    }

    public int NumOfEnemyKilled
    {
        get => _numOfEnemyKilled;
        set => _numOfEnemyKilled = value;
    }

    public void EnterNextStage()
    {
        _level++;
        GameFacade.Instance().NotifySubject(GameEventType.NewStage);
    }

    public Vector3 TargetPosition => _targetPosition;
}