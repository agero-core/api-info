using Agero.Core.ApiInfo.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agero.Core.ApiInfo.Tests
{
    [TestClass]
    public class ApiInfoComposerTests
    {
        [TestMethod]
        public void Get_When_ApiInformation_With_ApplicationInformation_Null()
        {
            //Arrange
            IApiInfoComposer composer = new ApiInfoComposer(ConstantHelper.ApplicationName,
                ConstantHelper.ApplicationVersion, () => null);

            //Act
            ApiInformation apiInformation = composer.Get();

            //Assert
            Assert.IsNotNull(apiInformation);
            Assert.AreEqual(ConstantHelper.ApplicationName, apiInformation.Name);
            Assert.AreEqual(ConstantHelper.ApplicationVersion, apiInformation.Version);
            Assert.IsNull(apiInformation.Application);
        }

        [TestMethod]
        public void Get_When_ApiInformation_With_ApplicationInformation_Not_Null()
        {
            //Arrange
            IApiInfoComposer composer = new ApiInfoComposer(ConstantHelper.ApplicationName,
                ConstantHelper.ApplicationVersion, () => ConstantHelper.CustomerApplicationInformation);

            //Act
            ApiInformation apiInformation = composer.Get();

            //Assert
            Assert.IsNotNull(apiInformation);
            Assert.AreEqual(ConstantHelper.ApplicationName, apiInformation.Name);
            Assert.AreEqual(ConstantHelper.ApplicationVersion, apiInformation.Version);
            Assert.IsNotNull(apiInformation.Application);
        }
    }
}
