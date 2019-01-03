using Agero.Core.Checker;
using System;
using System.Runtime.Serialization;

namespace Agero.Core.ApiInfo
{
    /// <summary>API system info</summary>
    [DataContract]
    public class ApiSystemInfo
    {
        /// <summary>Constructor</summary>
        public ApiSystemInfo(string userName, string userDomainName, string operatingSystem, bool is64BitOperatingSystem, 
            int processorCount, string clrVersion, bool is64BitProcess, string machineName, DateTimeOffset localTime, DateTimeOffset utcTime, 
            string hostName, string[] ipAddresses, bool isServerGC)
        {
            Check.ArgumentIsNull(ipAddresses, "ipAddresses");

            UserName = userName;
            UserDomainName = userDomainName;
            OperatingSystem = operatingSystem;
            Is64BitOperatingSystem = is64BitOperatingSystem;
            ProcessorCount = processorCount;
            ClrVersion = clrVersion;
            Is64BitProcess = is64BitProcess;
            MachineName = machineName;
            LocalTime = localTime;
            UtcTime = utcTime;
            HostName = hostName;
            IpAddresses = ipAddresses;
            IsServerGC = isServerGC;
        }

        /// <summary>Operating system's user name under which API is running</summary>
        [DataMember(Name = "userName")]
        public string UserName { get; }

        /// <summary>Operating system's user domain name under which API is running</summary>
        [DataMember(Name = "userDomainName")]
        public string UserDomainName { get; }

        /// <summary>Operating system description</summary>
        [DataMember(Name = "operatingSystem")]
        public string OperatingSystem { get; }

        /// <summary>Returns whether operating system is 64-bit</summary>
        [DataMember(Name = "is64BitOperatingSystem")]
        public bool Is64BitOperatingSystem { get; }
        
        /// <summary>Number of CPU cors</summary>
        [DataMember(Name = "processorCount")]
        public int ProcessorCount { get; }

        /// <summary>CLR version</summary>
        [DataMember(Name = "clrVersion")]
        public string ClrVersion { get; }

        /// <summary>Returns whether API process is 64-bit</summary>
        [DataMember(Name = "is64BitProcess")]
        public bool Is64BitProcess { get; }

        /// <summary>Machine name</summary>
        [DataMember(Name = "machineName")]
        public string MachineName { get; }

        /// <summary>Current local time</summary>
        [DataMember(Name = "localTime")]
        public DateTimeOffset LocalTime { get; }

        /// <summary>Current UTC time</summary>
        [DataMember(Name = "utcTime")]
        public DateTimeOffset UtcTime { get; }

        /// <summary>Host name</summary>
        [DataMember(Name = "hostName")]
        public string HostName { get; }

        /// <summary>IP addresses</summary>
        [DataMember(Name = "ipAddresses")]
        public string[] IpAddresses { get; }

        /// <summary>Returns whether server garbage collection is enabled</summary>
        [DataMember(Name = "isServerGC")]
        public bool IsServerGC { get; }
    }
}