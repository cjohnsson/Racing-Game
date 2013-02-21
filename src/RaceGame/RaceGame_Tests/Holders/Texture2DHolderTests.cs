using NUnit.Framework;
using RaceGame.Holders;

namespace RaceGame_Tests.Holders
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class Texture2DHolderTests
    {
        private Texture2DHolder MakeTexture2DHolderWithNullParameter()
        {
            return new Texture2DHolder(null);
        }

        [Test]
        [ExpectedException(typeof(Texture2DIsNullException))]
        public void GetTexture2D_Texture2DIsNull_ThrowsTexture2DIsNullException()
        {
            //Arrange
            var texture2DHolder = MakeTexture2DHolderWithNullParameter();

            //Act
            var result = texture2DHolder.GetTexture2D();
        }

        [Test]
        [ExpectedException(typeof(Texture2DIsNullException))]
        public void GetTexture2DWidth_Texture2DIsNull_ThrowsTexture2DIsNullExeption()
        {
            //Arrange
            var texture2DHolder = MakeTexture2DHolderWithNullParameter();

            //Act
            var result = texture2DHolder.GetTexture2DWidth();
        }

        [Test]
        [ExpectedException(typeof(Texture2DIsNullException))]
        public void GetTexture2DHeight_Texture2DIsNull_ThrowsTexture2DIsNullException()
        {
            //Arrange
            var texture2DHolder = MakeTexture2DHolderWithNullParameter();

            //Act
            var result = texture2DHolder.GetTexture2DHeight();
        }
    }


    // ReSharper restore InconsistentNaming
}