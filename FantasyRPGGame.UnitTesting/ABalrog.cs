using NUnit.Framework;
using FantasyRPGGame.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.UnitTesting
{
    [TestFixture]
    public class ABalrog
    {
        [Test]
        [Category("Milestone 5")]
        public void ShouldHaveARaceOfBalrog()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();

            var sut = new Balrog(mock_random.Object);

            // Action
            var actual = sut.Race;

            // Assert
            var expected = "Balrog";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 5")]
        public void ShouldCalculateBaseDamageTwice()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.SetupSequence(o => o.Next(It.IsAny<int>()))
                .Returns(0)
                .Returns(0)
                .Returns(100);
            
            var sut = new Balrog(mock_random.Object);
            sut.Strength = 0;

            // Action
            var actual = sut.CalculateDamage();

            // Assert
            var expected = 2;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
