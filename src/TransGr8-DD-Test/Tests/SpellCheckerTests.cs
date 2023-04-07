using NUnit.Framework;
using TransGr8_DD_Test.Models;
using TransGr8_DD_Test.Services;

namespace TransGr8_DD_Test.Tests
{

    [TestFixture]
    public class SpellCheckerTests
    {
        private SpellChecker _spellChecker;
        private List<Spell> _spells;
        private User _user;

        [SetUp]
        public void Setup()
        {
            _spells = new List<Spell>
            {
                new Spell
                {
                    Name = "Fireball",
                    Level = 3,
                    CastingTime = "1 action",
                    Components = "V, S, M (a tiny ball of bat guano and sulfur)",
                    Range = 150,
                    Duration = "Instantaneous",
                    SavingThrow = "Dexterity"
                },
                new Spell
                {
                    Name = "Magic Missile",
                    Level = 1,
                    CastingTime = "1 action",
                    Components = "V, S",
                    Range = 120,
                    Duration = "Instantaneous",
                    SavingThrow = ""
                },
                new Spell
                {
                    Name = "Cure Wounds",
                    Level = 1,
                    CastingTime = "1 action",
                    Components = "V, S",
                    Range = 1,
                    Duration = "Instantaneous",
                    SavingThrow = ""
                },
                new Spell
                {
                    Name = "Hold Person",
                    Level = 1,
                    CastingTime = "1 action",
                    Components = "V, S",
                    Range = 1,
                    Duration = "Concentration",
                    SavingThrow = ""
                }
            };

            _spellChecker = new SpellChecker(_spells);

            // Create a new User object with default values for testing.
            _user = new User
            {
                Level = 3,
                HasVerbalComponent = true,
                HasSomaticComponent = true,
                HasMaterialComponent = true,
                Range = 200,
                HasConcentration = true
            };
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsTrue_WhenAllConditionsAreValid()
        {
            // Arrange
            string spellName = "Fireball";

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsFalse_WhenUserHaveInsufficientLevel()
        {
            // Arrange
            string spellName = "Fireball";
            _user.Level = 2;

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsFalse_WhenUserHasMissingVerbalComponent()
        {
            // Arrange
            string spellName = "Fireball";
            _user.HasVerbalComponent = false;

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsFalse_WhenUserHasMissingSomaticComponent()
        {
            // Arrange
            string spellName = "Cure Wounds";
            _user.HasSomaticComponent = false;

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsFalse_WhenUserHasMissingMaterialComponent()
        {
            // Arrange
            string spellName = "Fireball";
            _user.HasMaterialComponent = false;

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsFalse_WhenUserHaveInsufficientRange()
        {
            // Arrange
            string spellName = "Fireball";
            _user.Range = 20;

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsFalse_WhenUserHasMissingConcentration()
        {
            // Arrange
            string spellName = "Hold Person";
            _user.HasConcentration = false;

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void CanUserCastSpell_ShouldReturnsFalse_WhenSpellNameNotFound()
        {
            // Arrange
            string spellName = "Identify";
            _user.HasConcentration = false;

            // Act
            bool result = _spellChecker.CanUserCastSpell(_user, spellName);

            // Assert
            Assert.False(result);
        }
    }
}
