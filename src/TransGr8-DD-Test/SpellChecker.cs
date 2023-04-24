namespace TransGr8_DD_Test
{
	public interface IRule
    {
        bool check(User user, Spell spell);
    }

    public class SomaticRule : IRule
    {
        public bool check(User user, Spell spell)
        {
            return !spell.Components.Contains("S") || user.HasSomaticComponent;
        }
    }

    public class VerbalRule : IRule
    {
        public bool check(User user, Spell spell)
        {
            return !spell.Components.Contains("V") || user.HasVerbalComponent;
        }
    }

    public class MaterialRule : IRule
    {
        public bool check(User user, Spell spell)
        {
            return !spell.Components.Contains("M") || user.HasMaterialComponent;
        }
    }

    public class ConcentrationRule : IRule
    {
        public bool check(User user, Spell spell)
        {
            return !spell.Duration.Contains("Concentration") || user.HasConcentration;
        }
    }
	public class SpellChecker
	{
		private readonly List<Spell> _spellList;

		public SpellChecker(List<Spell> spells)
		{
			if (spells == null)
			{
				throw new ArgumentNullException(nameof(spells));
			}
			_spellList = spells;
		}

		public bool CanUserCastSpell(User user, string spellName)
		{
			Spell spell = _spellList.Find(s => s.Name == spellName);
			if (user == null || spell == null)
			{
				return false;
			}
			
			if (user.Level < spell.Level)
			{
				return false;
			}
			if (user.Range < spell.Range)
            {
                return false;
            }

			if (!new VerbalRule().check(user, spell))
			{
				
				return false;
				
			}
			if (!new SomaticRule().check(user, spell))
			{
				
				return false;
				
			}
			if (! new MaterialRule().check(user, spell))
			{
				return false;
			}
			if (! new ConcentrationRule().check(user, spell))
			{
				return false;
			}
			if(spell.SavingThrow == ""){
				return false;
			}
			
			
			return true;
		}
		
	}
}
