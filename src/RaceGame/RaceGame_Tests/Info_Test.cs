using System;
using NUnit.Framework;
using RaceGame;


namespace RaceGame_Tests
{
    [TestFixture]
    class Info_Test
    {
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_Info_with_nullParams_Expect_ArgumentNullException()
        {
            Info info = new Info(null,null,null);
        }
        
    }
    
}


