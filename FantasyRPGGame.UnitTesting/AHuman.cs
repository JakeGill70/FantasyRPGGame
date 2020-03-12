using FantasyRPGGame.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace FantasyRPGGame.UnitTesting
{
    [TestFixture]
    class AHuman
    {
        [Test]
        [Category("Milestone 2")]
        public void ShouldHaveARaceOfHuman() 
        {
            // Arrange
            var mock_random = new Mock<IRandom>();

            var sut = new Human(mock_random.Object);

            // Action
            var actual = sut.Race;

            // Assert
            var expected = "Human";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 2")]
        public void ShouldBeAbleToCalculateNormalDamage()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.SetupSequence(o => o.Next(It.IsAny<int>()))
                .Returns(9)
                .Returns(75);

            var sut = new Human(mock_random.Object);

            // Action
            var actual = sut.CalculateDamage();

            // Assert
            var expected = 10;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 2")]
        public void ShouldBeAbleToCalculateDoubleDamage()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.SetupSequence(o => o.Next(It.IsAny<int>()))
                .Returns(9)
                .Returns(5);

            var sut = new Human(mock_random.Object);

            // Action
            var actual = sut.CalculateDamage();

            // Assert
            var expected = 20;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 2")]
        public void ShouldCalculateDoubleDamageTenPercentOfTheTime()
        {
            // Arrange
            var random = new Model.Random();
            var sut = new Human(random);
            sut.Strength = 0;

            // Action
            int cntDblDmg = 0;
            for (int i = 0; i < 10000; i++)
            {
                int dmg = sut.CalculateDamage();
                if (dmg != 1) {
                    cntDblDmg++;
                }
            }
            var actual = cntDblDmg;

            // Assert
            var expected = 1000;

            var variance = 50;

            Assert.That(actual, Is.EqualTo(expected).Within(variance));
        }
    }
}
