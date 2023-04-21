using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Interface
{
    public interface ISpellChecker
    {
        bool CanUserCastSpell(User user, string spellName);
    }
}
