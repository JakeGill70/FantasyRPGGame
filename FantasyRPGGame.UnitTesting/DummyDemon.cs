using FantasyRPGGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.UnitTesting
{
    public class DummyDemon : Model.Demon
    {
        public DummyDemon(IRandom random) : base(random)
        {
        }
    }
}
