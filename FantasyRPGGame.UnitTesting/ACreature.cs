﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FantasyRPGGame.Model;

namespace FantasyRPGGame.UnitTesting
{
    [TestFixture]
    class ACreature
    {
        [Test]
        [Category("Milestone 1")]
        public void ShouldBeAbleToChangeStrength()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.Setup(o => o.Next(It.IsAny<int>())).Returns(5);

            var sut = new DummyCreature(mock_random.Object);
            // Action
            sut.Strength = 50;

            // Assert
            var expected = 50;
            var actual = sut.Strength;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 1")]
        public void ShouldBeAbleToChangeHitPoints()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.Setup(o => o.Next(It.IsAny<int>())).Returns(5);

            var sut = new DummyCreature(mock_random.Object);
            // Action
            sut.HitPoints = 50;

            // Assert
            var expected = 50;
            var actual = sut.HitPoints;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 1")]
        public void ShouldBeAbleToCalculateDamage()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.Setup(o => o.Next(It.IsAny<int>())).Returns(5);

            var sut = new DummyCreature(mock_random.Object);
            // Action
            var actual = sut.CalculateDamage();

            // Assert
            var expected = 6;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 1")]
        public void ShouldBeAbleToTakeDamage()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.Setup(o => o.Next(It.IsAny<int>())).Returns(5);

            var sut = new DummyCreature(mock_random.Object);
            sut.HitPoints = 50;

            // Action
            sut.TakeDamage(5);

            // Assert
            var actual = sut.HitPoints;
            var expected = 45;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 1")]
        public void ShouldBeAbleToTakeDamageMultipleTimes()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.Setup(o => o.Next(It.IsAny<int>())).Returns(5);

            var sut = new DummyCreature(mock_random.Object);
            sut.HitPoints = 50;

            // Action
            sut.TakeDamage(5);
            sut.TakeDamage(10);
            sut.TakeDamage(3);

            // Assert
            var actual = sut.HitPoints;
            var expected = 32;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 1")]
        public void ShouldBeAbleToAttackAnotherCreature()
        {
            // Arrange
            var mock_random = new Mock<IRandom>();
            mock_random.Setup(o => o.Next(It.IsAny<int>())).Returns(5);

            var sut_attacker = new DummyCreature(mock_random.Object);
            var sut_defender = new DummyCreature(mock_random.Object);

            sut_attacker.HitPoints = 50;
            sut_defender.HitPoints = 50;

            // Action
            sut_attacker.Attack(sut_defender);

            // Assert
            var attackerHP_actual = sut_attacker.HitPoints;
            var attackerHP_expected = 50;

            var defenderHP_actual = sut_defender.HitPoints;
            var defenderHP_expected = 44;

            Assert.That(attackerHP_actual, Is.EqualTo(attackerHP_expected));
            Assert.That(defenderHP_actual, Is.EqualTo(defenderHP_expected));
        }

        [Test]
        [Category("Milestone 3")]
        public void ShouldHaveAOnePercentChanceOfTakingNoDamage()
        {
            // Arrange
            var random = new Model.Random();

            var sut = new DummyCreature(random);

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

            var sut = new DummyCreature(random);

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
