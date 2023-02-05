namespace Script.GameEventSystem.Subject
{
    public class NewStageSubject : IGameEventSubject
    {
        private int _stageCount = 0;

        public int StageCount => _stageCount;

        public override void Notify()
        {
            _stageCount++;
            base.Notify();
        }
    }
}