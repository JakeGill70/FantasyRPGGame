using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FantasyRPGGame.Model;

namespace FantasyRPGGame.IntegrationTesting
{
    [TestFixture]
    public class ACreatureAndARandom
    {
        [Test]
        [Category("Milestone 3")]
        public void ShouldHaveAOnePercentChanceOfTakingNoDamage()
        {
            // Arrange
            var random = new Model.Random();

            var sut = new Model.DummyCreature(random);

            // Action
            int cntNoDmg = 0;

            for (int i = 0; i < 10000; i++)
            {
                int dmg = sut.TakeDamage(10);
                if (dmg == 0)
                {
                    cntNoDmg++;
                }
            }

            var actual_cntNoDmg = cntNoDmg;

            // Assert
            var expected_cntNoDmg = 100;

            var variance = 15;

            Assert.That(actual_cntNoDmg, Is.EqualTo(expected_cntNoDmg).Within(variance));
        }

        [Test]
        [Category("Milestone 3")]
        public void ShouldHaveANintyNinePercentChanceOfTakingSomeDamage()
        {
            // Arrange
            var random = new Model.Random();

            var sut = new Model.DummyCreature(random);

            // Action
            int cntDmg = 0;

            for (int i = 0; i < 10000; i++)
            {
                int dmg = sut.TakeDamage(10);
                if (dmg == 10)
                {
                    cntDmg++;
                }
            }

            var actual_cntDmg = cntDmg;

            // Assert
            var expected_cntDmg = 9900;

            var variance = 15;

            Assert.That(actual_cntDmg, Is.EqualTo(expected_cntDmg).Within(variance));
        }
    }
}
