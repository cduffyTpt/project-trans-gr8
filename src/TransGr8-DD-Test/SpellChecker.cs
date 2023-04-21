using TransGr8_DD_Test.Interface;

namespace TransGr8_DD_Test
{
    public class SpellChecker: ISpellChecker { 
    
        private readonly ISpellRepository _spellRepository;
        private List<Spell> _spells;

        public SpellChecker(ISpellRepository spellRepository)
        {
            _spellRepository = spellRepository;
        }

        public SpellChecker(List<Spell> spells)
        {
            _spells = spells;
        }

        public bool CanUserCastSpell(User user, string spellName)
		{
			Spell spell = _spellRepository.GetSpellByName(spellName);
			
			if (user.Level < spell.Level)
			{
				return false;
			}
			if (spell.Components.Contains("V"))
			{
				if (!user.HasVerbalComponent)
				{
					return false;
				}
			}
			if (spell.Components.Contains("S"))
			{
				if (!user.HasSomaticComponent)
				{
					return false;
				}
			}
			else if (spell.Components.Contains("M"))
			{
				if (!user.HasMaterialComponent)
				{
					return false;
				}
			}
			if (user.Range < spell.Range)
			{
				return false;
			}
			if (spell.Duration.Contains("Concentration"))
			{
				if (!user.HasConcentration)
				{
					return false;
				}
			}
			// Add additional checks as needed for specific saving throws or other requirements.
			return true;
		}
		
	}
}
