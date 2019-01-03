using System;
using System.Threading.Tasks;

namespace Agero.Core.ApiInfo
{
    /// <summary>Async API information composer</summary>
    public class AsyncApiInfoComposer : BaseApiInfoComposer, IAsyncApiInfoComposer
    {
        private readonly Func<Task<object>> _getApplicationInfoAsync;

        /// <summary>Constructor</summary>
        /// <param name="name">API name (required)</param>
        /// <param name="version">API version (required)</param>
        /// <param name="getApplicationInfoAsync">Returns API application specific information (optional)</param>
        public AsyncApiInfoComposer(string name, string version, Func<Task<object>> getApplicationInfoAsync = null) 
            : base(name, version)
        {
            _getApplicationInfoAsync = getApplicationInfoAsync ?? (async () => await Task.FromResult<object>(null));
        }

        /// <summary>Returns API information</summary>
        public async Task<ApiInformation> GetAsync()
        {
            var application = await _getApplicationInfoAsync();

            return CreateInformation(application);
        }
    }
}