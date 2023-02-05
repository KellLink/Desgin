using Script.GameEventSystem.Observer;
using Script.GameEventSystem.Subject;


    public class EventKilledObserverStageSystem : IGameEventObserver
    {
        private EnemyKilledSubject _subject;
        private StageSystem _stageSystem;

        public EventKilledObserverStageSystem(StageSystem stageSystem)
        {
            _stageSystem = stageSystem;
        }

        public override void SetSubject(IGameEventSubject gameEventSubject)
        {
            _subject = gameEventSubject as EnemyKilledSubject;
        }

        public override void Update()
        {
            _stageSystem.NumOfEnemyKilled = _subject.EnemyKilledNum;
            
        }
    }
