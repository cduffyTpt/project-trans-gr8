namespace TransGr8_DD_Test
{
	public class SpellChecker
	{
        private readonly ISpellRepository _spellRepository;
        private readonly IReadOnlyList<ISpellRule> _rules;
        public SpellChecker(ISpellRepository spellRepository, IEnumerable<ISpellRule> rules)
        {
            _spellRepository = spellRepository;
            _rules = rules.ToList();
        }

		public async Task<bool> CanUserCastSpell(User user, string spellName)
		{
			Spell spell = await _spellRepository.FindByNameAsync(spellName);

            foreach (var rule in _rules)
            {
                if (!rule.Validate(user, spell))
                    return false;
            }
            return true;
        }
	}
}
