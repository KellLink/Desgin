namespace Script.CharacterSystem.Soldier
{
    public class SoldierCaptive : ISoldier
    {
        private IEnemy _enemy;

        public SoldierCaptive(IEnemy enemy)
        {
            _enemy = enemy;
            SoldierAttr attr = new SoldierAttr(enemy.Attr.AttrStrategy,1, enemy.Attr.BaseAttr);
            Attr = attr;
            CharacterGameObject = enemy.GameObj;
            Weapon = enemy.Weapon;
        }

        protected override void PlaySound()
        {
            
        }

        protected override void PlayEffect()
        {
            _enemy.PlayEffect();
        }
    }
}