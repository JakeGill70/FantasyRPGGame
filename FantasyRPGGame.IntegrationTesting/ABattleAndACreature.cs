using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FantasyRPGGame.Model;
using NUnit.Framework;

namespace FantasyRPGGame.IntegrationTesting
{
    [TestFixture]
    class ABattleAndACreature
    {
        [Test]
        [Category("Milestone 6")]
        public void ShouldReportThatCreature1WonTheDuel()
        {
            // Arrange
            var sut = new Battle();
            var random = new Model.Random();
            var creature1 = new TestCreature(random) { Damage = 10 };
            var creature2 = new TestCreature(random) { Damage = 1 };

            sut.AddCreature(creature1);
            sut.AddCreature(creature2);

            // Action
            sut.Duel(0, 1);

            // Assert
            var actual = sut.Messages.Last<string>();
            var expected = "Creature 1, the TestCreature, was victorious! Creature 2, the TestCreature, was defeated.";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 6")]
        public void ShouldReportThatCreature2WonTheDuel()
        {
            // Arrange
            var sut = new Battle();
            var random = new Model.Random();
            var creature1 = new TestCreature(random) { Damage = 1 };
            var creature2 = new TestCreature(random) { Damage = 10 };

            sut.AddCreature(creature1);
            sut.AddCreature(creature2);

            // Action
            sut.Duel(0, 1);

            // Assert
            var actual = sut.Messages.Last<string>();
            var expected = "Creature 2, the TestCreature, was victorious! Creature 1, the TestCreature, was defeated.";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Milestone 6")]
        public void ShouldReportATie()
        {
            // Arrange
            var sut = new Battle();
            var random = new Model.Random();
            var creature1 = new TestCreature(random) { Damage = 10 };
            var creature2 = new TestCreature(random) { Damage = 10 };

            sut.AddCreature(creature1);
            sut.AddCreature(creature2);

            // Action
            sut.Duel(0, 1);

            // Assert
            var actual = sut.Messages.Last<string>();
            var expected = "The battle between creatures 1 and 2, the TestCreature and the TestCreature, was a draw.";

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
