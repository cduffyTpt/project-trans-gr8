namespace TransGr8_DD_Test
{
    internal interface ICheckerEngine
    {
        void Register(IChecker checker);
        bool Check(User user, Spell spell);
    }
    internal class CheckerEngine : ICheckerEngine
    {
		private readonly List<IChecker> _checkers;

        public CheckerEngine()
        {
            _checkers = new List<IChecker>();
        }

        public void Register(IChecker checker)
		{
			_checkers.Add(checker);
		}
		public bool Check(User user, Spell spell)
        {
            foreach (IChecker checker in _checkers)
            {
				if(checker.Evaluate(user, spell))
                {
					return false;
                }
            }
			return true;
        }
        
    }
    
	
}



