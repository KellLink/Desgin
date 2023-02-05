using UnityEngine;

namespace Script.GameEventSystem.Subject
{
    public class EnemyKilledSubject : IGameEventSubject
    {
        private int _enemyKilledNum = 0;

        public int EnemyKilledNum => _enemyKilledNum;

        public override void Notify()
        {
            _enemyKilledNum++;
            base.Notify();
        }
    }
}