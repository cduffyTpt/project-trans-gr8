namespace TransGr8_DD_Test
{
    public class SpellChecker
	{
		private readonly ISpellRepository _spellRepository;

		internal SpellChecker(List<Spell> spells)
		{
			_spellRepository = new SpellRepository(spells);
		}

		public bool CanUserCastSpell(User user, string spellName)
		{
			Spell spell = _spellRepository.GetSpell(spellName);
			if (user.Level < spell.Level)
				return false;
			if (!user.HasVerbalComponent && spell.Components.Contains("V"))
				return false;
			if (!user.HasSomaticComponent && spell.Components.Contains("S"))
				return false;
			if (!user.HasMaterialComponent && spell.Components.Contains("M"))
				return false;
			if (user.Range < spell.Range)
				return false;
			if (!user.HasConcentration && spell.Duration.Contains("Concentration"))
				return false;
			// Add additional checks as needed for specific saving throws or other requirements.
			return true;
		}
	}
}
