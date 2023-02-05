namespace Script.CharacterSystem.Vistor
{
    public abstract class ICharacterVisitor
    {
        public abstract void visitEnemy(IEnemy enemy);
        public abstract void visitSoldier(ISoldier soldier);
    }
}