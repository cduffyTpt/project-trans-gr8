namespace TransGr8_DD_Test
{
	public class SpellChecker
	{
        private readonly SpellRepository _spellRepository;
        private readonly IReadOnlyList<ISpellRule> _rules;
        public SpellChecker(SpellRepository spellRepository, IEnumerable<ISpellRule> rules)
        {
            _spellRepository = spellRepository;
            _rules = rules.ToList();
        }

		public bool CanUserCastSpell(User user, string spellName)
		{
			Spell spell = _spellRepository.FindByName(spellName);

            foreach (var rule in _rules)
            {
                if (!rule.Validate(user, spell))
                    return false;
            }
            return true;
        }
	}
}
