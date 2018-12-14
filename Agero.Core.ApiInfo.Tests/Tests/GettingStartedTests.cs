using System.Threading.Tasks;
using Agero.Core.ApiInfo.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Agero.Core.ApiInfo.Tests
{
    [TestClass]
    public class GettingStartedTests
    {
        [TestMethod]
        public async Task AsynchronousUsage()
        {
            IAsyncApiInfoComposer composer = new AsyncApiInfoComposer(ConstantHelper.ApplicationName,
                ConstantHelper.ApplicationVersion, async () => await Task.FromResult<object>(null));

            ApiInformation apiInformation = await composer.GetAsync();

            var json = JsonConvert.SerializeObject(apiInformation);
        }

        [TestMethod]
        public void SynchronousUsage()
        {
            IApiInfoComposer composer = new ApiInfoComposer(ConstantHelper.ApplicationName,
                ConstantHelper.ApplicationVersion, () => null);

            ApiInformation apiInformation = composer.Get();

            var json = JsonConvert.SerializeObject(apiInformation);
        }
    }
}