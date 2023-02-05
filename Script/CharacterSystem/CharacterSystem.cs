using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.Vistor;
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

    public void RemoveSoldier(ISoldier soldier)
    {
        _soldiers.Remove(soldier);
    }

    private void RemoveKilledCharacters(List<ICharacter> characters)
    {
        List<ICharacter> removeList = new List<ICharacter>();
        foreach (ICharacter character in characters)
        {
            if (character.CanBeDestroy)
            {
                removeList.Add(character);
            }
        }
        foreach (ICharacter ch in removeList)
        {
            characters.Remove(ch);
            ch.Release();
        }
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

        RemoveKilledCharacters(_enemies);
        RemoveKilledCharacters(_soldiers);
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach (ICharacter en in _enemies)
        {
            en.RunVisitor(visitor);
        }

        foreach (ICharacter so in _soldiers)
        {
            so.RunVisitor(visitor);
        }
    }
}
