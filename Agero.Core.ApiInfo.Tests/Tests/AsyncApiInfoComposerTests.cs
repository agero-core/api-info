using Agero.Core.ApiInfo.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Agero.Core.ApiInfo.Tests
{
    [TestClass]
    public class AsyncApiInfoComposerTests
    {
        [TestMethod]
        public async Task GetAsync_When_ApiInformation_With_ApplicationInformation_Null()
        {
            //Arrange
            Func<Task<object>> action = async () => await Task.FromResult<object>(null);

            IAsyncApiInfoComposer composer = new AsyncApiInfoComposer(ConstantHelper.ApplicationName,
                ConstantHelper.ApplicationVersion, action);

            //Act
            ApiInformation apiInformation = await composer.GetAsync();

            //Assert
            Assert.IsNotNull(apiInformation);
            Assert.AreEqual(ConstantHelper.ApplicationName, apiInformation.Name);
            Assert.AreEqual(ConstantHelper.ApplicationVersion, apiInformation.Version);
            Assert.IsNull(apiInformation.Application);
        }

        [TestMethod]
        public async Task GetAsync_When_ApiInformation_With_ApplicationInformation_Not_Null()
        {
            //Arrange
            Func<Task<object>> action = async () => await Task.FromResult<object>(ConstantHelper.CustomApplicationInformation);

            IAsyncApiInfoComposer composer = new AsyncApiInfoComposer(ConstantHelper.ApplicationName,
                ConstantHelper.ApplicationVersion, action);

            //Act
            ApiInformation apiInformation = await composer.GetAsync();

            //Assert
            Assert.IsNotNull(apiInformation);
            Assert.AreEqual(ConstantHelper.ApplicationName,apiInformation.Name);
            Assert.AreEqual(ConstantHelper.ApplicationVersion, apiInformation.Version);
            Assert.IsNotNull(apiInformation.Application);
        }
    }
}