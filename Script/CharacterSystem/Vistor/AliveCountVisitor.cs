namespace Script.CharacterSystem.Vistor
{
    public class AliveCountVisitor : ICharacterVisitor
    {
        public int EnemyCount { get; private set; }
        public int SoldierCount { get; private set; }

        public void Reset()
        {
            EnemyCount = SoldierCount = 0;
        }
        public override void visitEnemy(IEnemy enemy)
        {
            if (!enemy.IsKilled)
            {
                EnemyCount++;
            }
            
        }

        public override void visitSoldier(ISoldier soldier)
        {
            if (!soldier.IsKilled)
            {
                SoldierCount++;
            }
           
        }
    }
}