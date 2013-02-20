using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame.Menu;


namespace RaceGame_Tests.Menu.Main
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class RolloverUtility_Test
    {
        private RolloverUtility MakeRolloverUtility()
        {
            return new RolloverUtility(1,1,2);
        }

        [Test]
        public void GetValue_DefaultValue_Returns1()
        {
            var rolloverUtility = MakeRolloverUtility();

            var result = rolloverUtility.Value;

            Assert.AreEqual(1,result);
        }

        [Test]
        public void RaiseValue_DefaultValueIsRaisedBy1_SetsValueTo2()
        {
            var rolloverUtility = MakeRolloverUtility();

            rolloverUtility.RaiseValue();
            
            var result = rolloverUtility.Value;
            Assert.AreEqual(2,result);
        }

        [Test]
        public void RaiseValue_ValueIsMaximumValue_SetsValueTo1()
        {
            //Arrange
            var rolloverUtility = MakeRolloverUtility();
            rolloverUtility.RaiseValue();

            //Act
            rolloverUtility.RaiseValue();
            
            //Assert
            var result = rolloverUtility.Value;
            Assert.AreEqual(1,result);
        }

        [Test]
        public void LowerValue_DefaultValueIsLoweredBy1_SetsValueTo2()
        {
            //Arrange
            var rolloverUtility = MakeRolloverUtility();

            //Act
            rolloverUtility.LowerValue();

            //Assert
            var result = rolloverUtility.Value;
            Assert.AreEqual(2,result);
        }

        [Test]
        public void LowerValue_ValueIsMaximumValue_SetsValueTo1()
        {
            //Arrange
            var rolloverUtility = MakeRolloverUtility();
            rolloverUtility.RaiseValue();

            //Act
            rolloverUtility.LowerValue();

            //Assert
            var result = rolloverUtility.Value;
            Assert.AreEqual(1, result);
        }    
    }

    // ReSharper restore InconsistentNaming
}