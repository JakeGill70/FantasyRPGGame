using NUnit.Framework;
using FantasyRPGGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.UnitTesting
{
    [TestFixture]
    class ADemon
    {
        [Test]
        [Category("Milestone 4")]
        public void ShouldCalculateTenExtraDamageTwentyFivePercentOfTheTime()
        {
            // Arrange
            var random = new Model.Random();
            var sut = new DummyDemon(random);
            sut.Strength = 0;

            // Action
            int cntExtraDmg = 0;
            for (int i = 0; i < 10000; i++)
            {
                int dmg = sut.CalculateDamage();
                if (dmg != 1)
                {
                    cntExtraDmg++;
                }
            }
            var actual = cntExtraDmg;

            // Assert
            var expected = 2500;

            var variance = 50;

            Assert.That(actual, Is.EqualTo(expected).Within(variance));
        }

        [Test]
        [Category("Milestone 4")]
        public void ShouldCalculateNormalDamageSeventyFivePercentOfTheTime()
        {
            // Arrange
            var random = new Model.Random();
            var sut = new DummyDemon(random);
            sut.Strength = 0;

            // Action
            int cntDmg = 0;
            for (int i = 0; i < 10000; i++)
            {
                int dmg = sut.CalculateDamage();
                if (dmg == 1)
                {
                    cntDmg++;
                }
            }
            var actual = cntDmg;

            // Assert
            var expected = 7500;

            var variance = 50;

            Assert.That(actual, Is.EqualTo(expected).Within(variance));
        }
    }
}
