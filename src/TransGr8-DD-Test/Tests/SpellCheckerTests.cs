using NUnit.Framework;
using TransGr8_DD_Test.Interfaces;
using TransGr8_DD_Test.Spells;

namespace TransGr8_DD_Test.Tests
{

    [TestFixture]
	public abstract class SpellCheckerTests
	{


		protected List<ISpell> spells;
		protected User user;

		[SetUp]
		public void Setup()
		{

			spells = new List<ISpell>();

            spells.Add(new FireballSpell());
            spells.Add(new MagicMissileSpell());
            spells.Add(new CureWoundsSpell());


            // Create a new User object with default values for testing.
            user = new User
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
