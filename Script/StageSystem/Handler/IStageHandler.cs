using System.Runtime.InteropServices;
using UnityEngine;


public class IStageHandler : MonoBehaviour
{
    protected int _level;
    protected IStageHandler _nextHandler;
    protected int _enemyKilledForStage;
    protected StageSystem _stageSystem;

    public IStageHandler(int level, int enemyKilledForStage, StageSystem stageSystem)
    {
        _level = level;
        _enemyKilledForStage = enemyKilledForStage;
        _stageSystem = stageSystem;
    }

    public IStageHandler SetNextStageHandler(IStageHandler stageHandler)
    {
        _nextHandler = stageHandler;
        return stageHandler;
    }

    public void Handler(int level)
    {
        if (_level == level)
        {
            UpdateStage();
            CheckStageFinished();
        }
        else
        {
            
                _nextHandler.Handler(level);
            
        }
    }

    public virtual void UpdateStage()
    {
    }

    private void CheckStageFinished()
    {
        if (_stageSystem.NumOfEnemyKilled >= _enemyKilledForStage)
        {
            //TODO
            _stageSystem.EnterNextStage();
        }
    }
}