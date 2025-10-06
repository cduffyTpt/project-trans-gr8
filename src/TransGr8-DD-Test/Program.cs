namespace TransGr8_DD_Test
{
	public class Program
	{
		static async Task Main(string[] args)
        {
            ISpellRepository spellRepository = new JsonSpellRepository("spells.json");
            
            JsonSpellRepository.SpellService spellService = new JsonSpellRepository.SpellService(spellRepository);
            IEnumerable<Spell> spells = await spellService.GetAllAsync(CancellationToken.None);


            var source = new FileUserSource("userData.json");
            var deserializer = new JsonUserDeserializer();
            var factory = new UserFactory();
            var userRepo = new UserRepository(source, deserializer, factory);

            User user = await userRepo.LoadAsync();
            
            var rules = new ISpellRule[]
            {
                new LevelRule(),
                new VerbalRule(),
                new SomaticRule(),
                new MaterialRule(),
                new RangeRule(),
                new ConcentrationRule()
            };

			string spellName = args[0];
			// Use the spell checker to determine if the user can cast the spell.
            SpellRepository repo = new InMemorySpellRepository(spells.ToList());
            
			SpellChecker spellChecker = new SpellChecker(repo, rules);
            
			bool canCast = spellChecker.CanUserCastSpell(user, spellName);

			// Output the result.
			Console.WriteLine("Can the user cast {0}? {1}", spellName, canCast);
			Console.ReadKey();
		}
	}
}