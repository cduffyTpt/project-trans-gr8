using NUnit.Framework;
using TransGr8_DD_Test.Rules;

namespace TransGr8_DD_Test.Tests.Rules
{
    [TestFixture]
    public class LevelSpellTests
    {

        private LevelSpellRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new LevelSpellRule();
        }

        [Test]
        public void Satisfy_WhenUserLevelIsLessThanSpellLevel_ShouldReturnFalse()
        {
            // Arrange

            var user = new User()
            {
                Level = 1
            };
            var spell = new Spell()
            {
                Level = 2
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
                Level = 2
            };
            var spell = new Spell()
            {
                Level = 1
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
                Level = 2
            };
            var spell = new Spell()
            {
                Level = 2
            };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.True(result);
        }
    }
}
