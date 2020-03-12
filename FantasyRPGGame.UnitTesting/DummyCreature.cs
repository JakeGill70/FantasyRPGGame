using FantasyRPGGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.UnitTesting
{
    public class DummyCreature : FantasyRPGGame.Model.Creature
    {
        public override int Type { get => base.Type; set => base.Type = value; }
        public override int Strength { get => base.Strength; set => base.Strength = value; }
        public override int HitPoints { get => base.HitPoints; set => base.HitPoints = value; }

        public override string Race => base.Race;

        public DummyCreature(IRandom random) : base(random){ 
            
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
