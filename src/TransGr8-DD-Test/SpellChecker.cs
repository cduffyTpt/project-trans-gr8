namespace TransGr8_DD_Test
{
    public class SpellChecker
	{
		private readonly ISpellRepository _spellRepository;
		private readonly ICheckerEngine _checkerEngine;

        internal SpellChecker(ISpellRepository spellRepository, ICheckerEngine checkerEngine)
        {
            _spellRepository = spellRepository;
            _checkerEngine = checkerEngine;
        }

        internal SpellChecker(List<Spell> spells) : this(new SpellRepository(spells), new CheckerEngine())
		{
			_checkerEngine.Register(new LevelChecker());
			_checkerEngine.Register(new VerbalComponentChecker());
			_checkerEngine.Register(new SomaticComponentChecker());
			_checkerEngine.Register(new MaterialComponentChecker());
			_checkerEngine.Register(new RangeChecker());
			_checkerEngine.Register(new ConcentrationChecker());
		}

		public bool CanUserCastSpell(User user, string spellName)
		{
			Spell spell = _spellRepository.GetSpell(spellName);
			return _checkerEngine.Check(user, spell);
		}
	}
}



