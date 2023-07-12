using NUnit.Framework;
using TransGr8_DD_Test.Rules;

namespace TransGr8_DD_Test.Tests.Rules
{
    [TestFixture]
    public class RangeSpellRuleTests
    {
        private RangeSpellRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new RangeSpellRule();
        }

        [Test]
        public void Satisfy_WhenUserLevelIsLessThanSpellLevel_ShouldReturnFalse()
        {
            // Arrange

            var user = new User()
            {
                Range = 1
            };
            var spell = new Spell()
            {
                Range = 2
            };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void Satisfy_WhenUserLevelIsGreaterThanSpellLevel_ShouldReturnTrue()
        {
            // Arrange

            var user = new User()
            {
                Range = 2
            };
            var spell = new Spell()
            {
                Range = 1
            };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Satisfy_WhenUserLevelSpellLevelAreEqual_ShouldReturnTrue()
        {
            // Arrange

            var user = new User()
            {
                Range = 2
            };
            var spell = new Spell()
            {
                Range = 2
            };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.True(result);
        }
    }
}
