using TransGr8_DD_Test.Component;
using TransGr8_DD_Test.Components;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test
{
    public class SpellChecker
	{
		private readonly List<ISpell> _spellList;

		public SpellChecker(List<ISpell> spells)
		{
			_spellList = spells;
		}

		public bool CanUserCastSpell(User user, string spellName)
		{
            ISpell spell = _spellList.Find(s => s.Name == spellName);
			
			if(spell == null) return false;

			if (user.Level < spell.Level)
			{
				return false;
			}

			foreach (IComponent component in spell.Components)
			{
				if ((component is MaterialComponent && !user.HasMaterialComponent) 
					|| (component is SomaticComponent && !user.HasSomaticComponent) 
					|| (component is VerbalComponent && !user.HasVerbalComponent)
					)
				{
					return false;
				}

			}

			if (user.Range < spell.Range)
			{
				return false;
			}

			if (spell.Duration.Contains("Concentration") && !user.HasConcentration)
			{
				return false;
				
			}


			return true; 
		
		}
		
	}
}
