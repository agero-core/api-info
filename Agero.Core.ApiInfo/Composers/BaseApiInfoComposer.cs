using Agero.Core.Checker;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime;

namespace Agero.Core.ApiInfo
{
    /// <summary>Base API information composer</summary>
    public abstract class BaseApiInfoComposer
    {
        private readonly string _name;
        private readonly string _version;

        /// <summary>Constructor</summary>
        /// <param name="name">API name (required)</param>
        /// <param name="version">API version (required)</param>
        protected BaseApiInfoComposer(string name, string version)
        {
            Check.ArgumentIsNullOrWhiteSpace(name, "name");
            Check.ArgumentIsNullOrWhiteSpace(version, "version");

            _name = name;
            _version = version;
        }
        
        private static ApiSystemInfo CreateSystemInfo()
        {
            return 
                new ApiSystemInfo
                (
                    userName: Environment.UserName,
                    userDomainName: Environment.UserDomainName,
                    operatingSystem: Environment.OSVersion.VersionString,
                    is64BitOperatingSystem: Environment.Is64BitOperatingSystem,
                    processorCount: Environment.ProcessorCount,
                    clrVersion: Environment.Version.ToString(),
                    is64BitProcess: Environment.Is64BitProcess,
                    machineName: Environment.MachineName,
                    localTime: DateTimeOffset.Now,
                    utcTime: DateTimeOffset.UtcNow,
                    hostName: Dns.GetHostName(),
                    ipAddresses: GetIpAddresses(),
                    isServerGC: GCSettings.IsServerGC
                );
        }

        private static string[] GetIpAddresses()
        {
            var hostName = Dns.GetHostName();
            if (string.IsNullOrWhiteSpace(hostName))
                return new string[] { };

            var hostEntry = Dns.GetHostEntry(hostName);
            
            return
                hostEntry.AddressList
                    .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                    .Select(a => a.ToString())
                    .ToArray();
        }

        /// <summary>Create API information</summary>
        /// <param name="application">API application specific information</param>
        protected ApiInformation CreateInformation(object application)
        {
            return 
                new ApiInformation
                (
                    name: _name,
                    version: _version,
                    system: CreateSystemInfo(),
                    application: application
                );
        }
    }
}