namespace TransGr8_DD_Test
{
    internal interface IChecker
    {
		bool Evaluate(User user, Spell spell);
    }
	public class LevelChecker : IChecker
	{
		public bool Evaluate(User user, Spell spell)
		{
			return user.Level < spell.Level;
		}
	}
	public class VerbalComponentChecker : IChecker
	{
		public bool Evaluate(User user, Spell spell)
		{
			return spell.Components.Contains("V") && !user.HasVerbalComponent;
		}
	}
	public class SomaticComponentChecker : IChecker
	{
		public bool Evaluate(User user, Spell spell)
		{
			return spell.Components.Contains("S") && !user.HasSomaticComponent;
		}
	}
	public class MaterialComponentChecker : IChecker
	{
		public bool Evaluate(User user, Spell spell)
		{
			return spell.Components.Contains("M") && !user.HasMaterialComponent;
		}
	}
	public class RangeChecker : IChecker
	{
		public bool Evaluate(User user, Spell spell)
		{
			return user.Range < spell.Range;
		}
	}
	public class ConcentrationChecker : IChecker
	{
		public bool Evaluate(User user, Spell spell)
		{
			return spell.Duration.Contains("Concentration") && !user.HasConcentration;
		}
	}
}



