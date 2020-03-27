using FantasyRPGGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.IntegrationTesting
{
    public class TestCreature : Creature
    {
        public int Damage { get; set; }
        public override string Race => "TestCreature";

        public TestCreature(IRandom random = null) : base(random) { 
        
        }
        
        public override int Attack(Creature creature) { 
            return creature.TakeDamage(Damage); 
        }
    }
}
