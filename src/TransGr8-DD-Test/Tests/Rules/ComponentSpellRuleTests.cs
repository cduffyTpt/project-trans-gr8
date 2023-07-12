using NUnit.Framework;
using TransGr8_DD_Test.Rules;

namespace TransGr8_DD_Test.Tests.Rules
{
    [TestFixture]
    public class ComponentSpellRuleTests
    {
        private ComponentSpellRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new ComponentSpellRule();
        }

        [Test]
        public void Satisfy_WhenSpellComponentContainsMAndUserHasMaterialComponent_ShouldReturnTrue()
        {
            // Arrange
            var user = new User()
            {
                HasMaterialComponent = true
            };
            var spell = new Spell { Components = "M" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Satisfy_WhenSpellComponentsDoesNotContainM_ShouldReturnFalse()
        {
            // Arrange
            var user = new User();
            var spell = new Spell { Components = "V" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Satisfy_WhenUserHasMaterialComponent_ShouldReturnFalse()
        {
            // Arrange
            var user = new User { HasMaterialComponent = true };
            var spell = new Spell { Components = "D" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Satisfy_WhenSpellComponentContainsSAndUserHasSomaticComponent_ShouldReturnTrue()
        {
            // Arrange
            var user = new User()
            {
                HasSomaticComponent = true
            };
            var spell = new Spell { Components = "S" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Satisfy_WhenSpellComponentsDoesNotContainSAndUserHasSomatic_ShouldReturnFalse()
        {
            // Arrange
            var user = new User()
            {
                HasSomaticComponent = true
            };
            var spell = new Spell { Components = "O" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Satisfy_WhenUserHasSomaticComponentAndUnkownSpellComponent_ShouldReturnFalse()
        {
            // Arrange
            var user = new User { HasSomaticComponent = true };
            var spell = new Spell { Components = "D" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Satisfy_WhenSpellDurationContainsVAndUserHasVerbalComponent_ShouldReturnTrue()
        {
            // Arrange
            var user = new User()
            {
                HasVerbalComponent = true
            };

            var spell = new Spell { Components = "V" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Satisfy_WhenSpellComponentsDoesNotContainV_ShouldReturnFalse()
        {
            // Arrange
            var user = new User();
            var spell = new Spell { Components = "O" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Satisfy_WhenUserHasVerbalComponent_ShouldReturnFalse()
        {
            // Arrange
            var user = new User { HasVerbalComponent = true };
            var spell = new Spell { Components = "D" };

            // Act
            bool result = _rule.Satisfy(user, spell);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
