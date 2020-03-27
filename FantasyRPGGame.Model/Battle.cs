using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.Model
{
    public class Battle
    {
        private IList<Creature> _creatures;
        public ICollection<string> Messages { get; private set; }

        public Battle() {
            _creatures = new List<Creature>();
            Messages = new LinkedList<string>();
        }

        public void AddCreature(Creature creature) {
            _creatures.Add(creature);
        }

        public Creature GetCreature(int index)
        {
            Creature creature;
            try
            {
                creature = _creatures[index];
            }
            catch (IndexOutOfRangeException e) {
                creature = null;
            }
            return creature;
        }

        public bool RemoveCreature(int index) {
            bool wasSuccessfullyRemoved = false;
            try
            {
                _creatures.RemoveAt(index);
                wasSuccessfullyRemoved = true;
            }
            catch (IndexOutOfRangeException e) {
                wasSuccessfullyRemoved = false;
            }
            return wasSuccessfullyRemoved;
        }

        public int Duel(int index1, int index2)
        {

            int winnerIndex = -1; // Default to "Battle was a draw"

            Creature creature1 = GetCreature(index1);
            Creature creature2 = GetCreature(index2);

            bool creature1Won = false;
            bool creature2Won = false;

            int damgeGiven = 0;
            string msg = "";

            while (!(creature1Won || creature2Won)) {
                // Creature 1 attacks Creature 2
                damgeGiven = creature1.Attack(creature2);
                msg = $"The {creature1.Race} deals {damgeGiven} to the {creature2.Race}.";
                Messages.Add(msg); // Log creature 1's attack

                // Creature 2 attacks Creature 1
                damgeGiven = creature2.Attack(creature1);
                msg = $"The {creature2.Race} deals {damgeGiven} to the {creature1.Race}.";
                Messages.Add(msg); // Log creature 2's attack

                // Determine the results of the battle
                creature1Won = (creature2.HitPoints < 1);
                creature2Won = (creature1.HitPoints < 1);
            }

            // Determine the winner
            if (creature1Won && creature2Won)
            {
                msg = $"The battle between creatures 1 and 2, the {creature1.Race} and the {creature2.Race}, was a draw.";
                winnerIndex = -1; // This is redundant because the default is -1, but 
                                    // this helps protect against any sort of silly 
                                    // mistakes later on.
            }
            else if (creature1Won) {
                msg = $"Creature 1, the {creature1.Race}, was victorious! Creature 2, the {creature2.Race}, was defeated.";
                winnerIndex = index1;
            }
            else if (creature2Won)
            {
                msg = $"Creature 2, the {creature2.Race}, was victorious! Creature 1, the {creature1.Race}, was defeated.";
                winnerIndex = index2;
            }
            Messages.Add(msg); // Log the result of the duel

            return winnerIndex;
        }
    }
}
