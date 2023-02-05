namespace Script.GameEventSystem.Subject
{
    public class SoldierKilledSubject : IGameEventSubject
    {
        private int _soldierKilledNum = 0;

        public int SoldierKilledNum => _soldierKilledNum;

        public override void Notify()
        {
            _soldierKilledNum++;
            base.Notify();
        }
    }
}