using NUnit.Framework;
using TransGr8_DD_Test.Rules;

namespace TransGr8_DD_Test.Tests.Rules
{
    [TestFixture]
    public class ConcentrationDurationSpellRuleTests
    {
        private ConcentrationDurationSpellRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new ConcentrationDurationSpellRule();
        }

        [Test]
        public void Satisfy_WhenSpellDurationContainsConcentrationAndUserHasNoConcentration_ShouldReturnFalse()
        {
            // Arrange
            var user = new User()
            {
                HasConcentration = false,
            };
            Spell spell = new Spell { Duration = "Concentration" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void Satisfy_WhenSpellDurationContainsConcentrationAndUserHasConcentration_ShouldReturnTrue()
        {
            // Arrange
            var user = new User()
            {
                HasConcentration = true,
            };

            Spell spell = new Spell { Duration = "Concentration" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Satisfy_WhenSpellDurationDoesNotContainConcentration_ShouldReturnTrue()
        {
            // Arrange
            var user = new User();
            var spell = new Spell { Duration = "Instantaneous" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Satisfy_WhenSpellIsNotConcentrationAndUserHasConcentration_ShouldReturnTrue()
        {
            // Arrange
            var user = new User { HasConcentration = true };
            var spell = new Spell { Duration = "Instantaneous" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.True(result);
        }
    }
}
