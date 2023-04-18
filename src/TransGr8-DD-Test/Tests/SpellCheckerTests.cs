using NUnit.Framework;
using Serilog;
using TransGr8_DD_Test.Services;

namespace TransGr8_DD_Test.Tests
{

    [TestFixture]
    public class SpellCheckerTests
    {


        private List<Spell> spells;
        private User user;

        [SetUp]
        public void Setup()
        {
            LoggerService loggerService = new LoggerService();
            Log.Information("This is a log test");

            //Get the list of spells from the spells service instead of having their definition here
            spells = SpellService.GetSpells();


            // Get a user from User service and pick one for testing
            user = UserService.GetUsers()[0];
        }

        [Test]
        public void TestCanUserCastSpellReturnsTrue()
        {
            // Arrange
            SpellChecker spellChecker = new SpellChecker(spells);
            string spellName = "Fireball";

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void TestCanUserCastSpellReturnsFalseForInsufficientLevel()
        {
            // Arrange
            SpellChecker spellChecker = new SpellChecker(spells);
            string spellName = "Fireball";
            user.Level = 2;

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void TestCanUserCastSpellReturnsFalseForMissingVerbalComponent()
        {
            // Arrange
            SpellChecker spellChecker = new SpellChecker(spells);
            string spellName = "Command";
            user.HasVerbalComponent = false;

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void TestCanUserCastSpellReturnsFalseForMissingSomaticComponent()
        {
            // Arrange
            SpellChecker spellChecker = new SpellChecker(spells);
            string spellName = "Cure Wounds";
            user.HasSomaticComponent = false;

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void TestCanUserCastSpellReturnsFalseForMissingMaterialComponent()
        {
            // Arrange
            SpellChecker spellChecker = new SpellChecker(spells);
            string spellName = "Identify";
            user.HasMaterialComponent = false;

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void TestCanUserCastSpellReturnsFalseForInsufficientRange()
        {
            // Arrange
            SpellChecker spellChecker = new SpellChecker(spells);
            string spellName = "Fireball";
            user.Range = 20;

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void TestCanUserCastSpellReturnsFalseForMissingConcentration()
        {
            // Arrange
            SpellChecker spellChecker = new SpellChecker(spells);
            string spellName = "Hold Person";
            user.HasConcentration = false;

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.False(result);
        }
    }
}
