using Agero.Core.Checker;
using System.Runtime.Serialization;

namespace Agero.Core.ApiInfo
{
    /// <summary>API information</summary>
    [DataContract]
    public class ApiInformation
    {
        /// <summary>Constructor</summary>
        public ApiInformation(string name, string version, ApiSystemInfo system, object application = null)
        {
            Check.ArgumentIsNullOrWhiteSpace(name, "name");
            Check.ArgumentIsNullOrWhiteSpace(version, "version");
            Check.ArgumentIsNull(system, "system");

            Name = name;
            Version = version;
            System = system;
            Application = application;
        }

        /// <summary>API name</summary>
        [DataMember(Name = "name")]
        public string Name { get; }

        /// <summary>API version</summary>
        [DataMember(Name = "version")]
        public string Version { get; }

        /// <summary>API system information</summary>
        [DataMember(Name = "system")]
        public ApiSystemInfo System { get; }

        /// <summary>API application specific information</summary>
        [DataMember(Name = "application")]
        public object Application { get; }
    }
}