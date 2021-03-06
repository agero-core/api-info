# Api Info

[![NuGet Version](http://img.shields.io/nuget/v/Agero.Core.ApiInfo.svg?style=flat)](https://www.nuget.org/packages/Agero.Core.ApiInfo/) 
[![NuGet Downloads](http://img.shields.io/nuget/dt/Agero.Core.ApiInfo.svg?style=flat)](https://www.nuget.org/packages/Agero.Core.ApiInfo/)

API Info is a library for composing API information.

## Usage:

**Asynchronous Usage:**
```csharp
//Create instance:
IAsyncApiInfoComposer composer =
      new AsyncApiInfoComposer(
         name: "TestApplication",
         version: "1.2.3.4",
         getApplicationInfoAsync: async () => await Task.FromResult<object>(new
         {
            customApplicationDescription = "Application description specific to the application",
            customApplicationInfo = "Application Info specific to the application"
         }));

//Get Info:
ApiInformation apiInformation = await composer.GetAsync();

//Serialize:
var json = JsonConvert.SerializeObject(apiInformation);
```

**Synchronous Usage:**
```csharp
//Create instance:
IApiInfoComposer composer =
      new ApiInfoComposer(
         name: "TestApplication",
         version: "1.2.3.4",
         getApplicationInfo: () => new
         {
            customApplicationDescription = "Application description specific to the application",
            customApplicationInfo = "Application Info specific to the application"
         }
      );

//Get Info:
ApiInformation apiInformation = composer.Get();

//Serialize:
var json = JsonConvert.SerializeObject(apiInformation);
```

The above code generates the below json.
```json
{  
   "name":"TestApplication",
   "version":"1.2.3.4",
   "system":{  
      "userName":"DomainName\\user",
      "userDomainName":"DomainName",
      "operatingSystem":"Unix 18.2.0.0",
      "is64BitOperatingSystem":true,
      "processorCount":4,
      "clrVersion":"4.0.30319.42000",
      "is64BitProcess":true,
      "machineName":"MACHINE-NAME",
      "localTime":"2018-12-14T13:26:22.1359566-05:00",
      "utcTime":"2018-12-14T18:26:22.1359605+00:00",
      "hostName":"MACHINE-NAME",
      "ipAddresses":[  
         "123.123.1.0"
      ],
      "isServerGC":false
   },
   "application":{  
      "customApplicationDescription":"Application description specific to the application",
      "customApplicationInfo":"Application Info specific to the application"
   }
}
```
