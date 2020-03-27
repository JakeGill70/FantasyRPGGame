using System;
using System.Collections.Generic;
using FantasyRPGGame.Model;

namespace FantasyRPGGame.ConsoleApp
{
    class Program
    {
        const int NUMBER_OF_TEST_DUELS = 100;

        static void Main(string[] args)
        {
            Battle battle = new Battle();
            Model.Random random = new Model.Random();
            int winner = int.MaxValue;

            // Maps duels results to the number of times that result occured.
            Dictionary<int, int> winners = new Dictionary<int, int>();
            winners.Add(-1, 0); // Ties
            winners.Add(0, 0); // Human wins
            winners.Add(1, 0); // Balrog wins

            for (int i = 0; i < NUMBER_OF_TEST_DUELS; i++)
            {
                // Make some test creatures to duel
                Human human = new Human(random);
                Balrog balrog = new Balrog(random);

                // Add the creatures
                battle.AddCreature(human);
                battle.AddCreature(balrog);

                // Make the two creatures duel
                winner = battle.Duel(0, 1);
                winners[winner] += 1;

                // Remove the creatures
                battle.RemoveCreature(1);
                battle.RemoveCreature(0);

                // Add duel header
                Console.WriteLine("Human v. Balrog");
                // Print the messages
                printMessages(battle.Messages);

                // Clear the message log
                battle.Messages.Clear();
            }

            printResults(winners);

            Console.WriteLine("Press [Enter/Return] to Exit");
            Console.ReadLine();
        }

        private static void printMessages(ICollection<string> messages) {
            foreach (string msg in messages) {
                Console.WriteLine("--> " + msg);
            }
        }

        private static void printResults(Dictionary<int, int> winners) {
            Console.WriteLine($"Human Wins: {winners[0]} : {((double)winners[0] / (double)NUMBER_OF_TEST_DUELS * 100).ToString("###.0")}%");
            Console.WriteLine($"Balrog Wins: {winners[1]} : {((double)winners[1] / (double)NUMBER_OF_TEST_DUELS * 100).ToString("###.0")}%");
            Console.WriteLine($"Ties: {winners[-1]} : {((double)winners[-1] / (double)NUMBER_OF_TEST_DUELS * 100).ToString("###.0")}%");
        }
    }
}
