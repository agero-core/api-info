using System;

namespace Agero.Core.ApiInfo
{
    /// <summary>Sync API information composer</summary>
    public class ApiInfoComposer : BaseApiInfoComposer, IApiInfoComposer
    {
        private readonly Func<object> _getApplicationInfo;

        /// <summary>Constructor</summary>
        /// <param name="name">API name (required)</param>
        /// <param name="version">API version (required)</param>
        /// <param name="getApplicationInfo">Returns API application specific information (optional)</param>
        public ApiInfoComposer(string name, string version, Func<object> getApplicationInfo = null) 
            : base(name, version)
        {
            _getApplicationInfo = getApplicationInfo ?? (() => null);
        }

        /// <summary>Returns API information</summary>
        public ApiInformation Get()
        {
            var application = _getApplicationInfo();

            return CreateInformation(application);
        }
    }
}