using NUnit.Framework;

namespace TransGr8_DD_Test.Tests
{
	[TestFixture]
	public class SpellCheckerTests
	{
		private IReadOnlyList<Spell> spells;
		private User user;
        private ISpellRepository spellRepository;
        private IReadOnlyList<ISpellRule> spellRules;

		[SetUp]
		public async Task Setup()
		{
            spellRepository = new JsonSpellRepository(Path.Join(Directory.GetCurrentDirectory(), "../../../test_spells.json"));
            spells = await spellRepository.GetAllAsync();
            
            var rules = new ISpellRule[]
            {
                new LevelRule(),
                new VerbalRule(),
                new SomaticRule(),
                new MaterialRule(),
                new RangeRule(),
                new ConcentrationRule()
            };
            
            spellRules = rules.ToList();

            var source = new FileUserSource(Path.Join(Directory.GetCurrentDirectory(), "../../../userData.json"));
            var deserializer = new JsonUserDeserializer();
            var factory = new UserFactory();
            var userRepo = new UserRepository(source, deserializer, factory);
            
            user = await userRepo.LoadAsync();
		}

		[Test]
		public async Task TestCanUserCastSpellReturnsTrue()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spellRepository, spellRules);
			string spellName = "Fireball";

            user.HasSomaticComponent = true;

			// Act
			bool result = await spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.True(result);
		}

		[Test]
		public async Task TestCanUserCastSpellReturnsFalseForInsufficientLevel()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spellRepository, spellRules);
			string spellName = "Fireball";
			user.Level = 2;

			// Act
			bool result = await spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public async Task TestCanUserCastSpellReturnsFalseForMissingVerbalComponent()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spellRepository, spellRules);
			string spellName = "Command";
			user.HasVerbalComponent = false;

			// Act
			bool result = await spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public async Task TestCanUserCastSpellReturnsFalseForMissingSomaticComponent()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spellRepository, spellRules);
			string spellName = "Cure Wounds";
			user.HasSomaticComponent = false;

			// Act
			bool result = await spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public async Task TestCanUserCastSpellReturnsFalseForMissingMaterialComponent()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spellRepository, spellRules);
			string spellName = "Identify";
			user.HasMaterialComponent = false;

			// Act
			bool result = await spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public async Task TestCanUserCastSpellReturnsFalseForInsufficientRange()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spellRepository, spellRules);
			string spellName = "Fireball";
			user.Range = 20;

			// Act
			bool result = await spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public async Task TestCanUserCastSpellReturnsFalseForMissingConcentration()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spellRepository, spellRules);
			string spellName = "Hold Person";
			user.HasConcentration = false;

			// Act
			bool result = await spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}
	}
}
