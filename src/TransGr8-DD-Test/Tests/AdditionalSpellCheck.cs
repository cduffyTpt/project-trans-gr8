using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Tests
{
    public class AdditionalSpellCheck : SpellCheckerTests
    {

        [Test]
        public void TestUserLevelHigherThan0()
        {
            user.Level = 1;

            // Act
            bool result = user.Level > 0 ;

            // Assert
            Assert.True(result);
        }

    }
}
