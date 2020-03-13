namespace FantasyRPGGame.Model
{
    public class DummyCreature : FantasyRPGGame.Model.Creature
    {

        public override string Race => base.Race;

        public DummyCreature(IRandom random) : base(random)
        {

        }

        public override int Attack(Creature creature)
        {
            return base.Attack(creature);
        }

        public override int CalculateDamage()
        {
            return base.CalculateDamage();
        }

        public override int TakeDamage(int damage)
        {
            return base.TakeDamage(damage);
        }
    }
}
