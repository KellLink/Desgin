using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterSystem : IGameSystem
{
    private List<ICharacter> _enemies = new List<ICharacter>();
    private List<ICharacter> _soldiers = new List<ICharacter>();

    public void AddEnemy(IEnemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        _enemies.Remove(enemy);
    }

    public void AddSoldier(ISoldier soldier)
    {
        _soldiers.Add(soldier);
    }

    private void Remove(ISoldier soldier)
    {
        _soldiers.Remove(soldier);
    }

    public override void Update()
    {
        foreach (IEnemy enemy in _enemies)
        {
            enemy.Update();
            enemy.UpdateFSM(_soldiers);
        }

        foreach (var character in _soldiers)
        {
            var soldier = (ISoldier) character;
            soldier.Update();
            soldier.UpdateFSM(_enemies);
        }
    }
}
