# GraphXSDKClient (.NET Standard 2.0)

This SDK enables you to place mockup and product line orders, retrieve order status, and integrate with the GXSIO API in your .NET applications.

---

## Supported Platforms

- **.NET Standard 2.0**
- **.NET Core 2.0+**
- **.NET 5/6/7/8/9**
- **.NET Framework 4.6.1 and above (including 4.7.0+)**

---

## Installation

Install via NuGet Package Manager Console:

Or via .NET CLI:

---

## Configuration & Usage

### .NET Core / .NET 5+ Example

1. **Register the SDK in your DI container (e.g., in `Program.cs`):**
```csharp
using DotnetStandardSDK;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

await services.AddGraphXClientAsync(options =>
{
    options.Environment = EnvironmentType.Production; // or Development
        options.Key = "your-api-key";
    });
    
2. **Inject and use the client:**```csharp
public class MyService
{
    private readonly IGraphXClient _client;

    public MyService(IGraphXClient client)
    {
        _client = client;
    }

    public async Task UseSdkAsync()
    {
        var request = new GetProductMockupRequestExternalRequest { /* set properties */ };
        var result = await _client.Mockups.GetProductMockupRequestExternal(request);
        // handle result
    }
}---

### .NET Framework Example

1. **Reference the NuGet package in your project.**
2. **Create and use the client:**```csharp
using DotnetStandardSDK;

var options = new GraphXClientOptions
{
    Environment = EnvironmentType.Production,
    Key = "your-api-key"
};

var client = await GraphXClient.BuildAsync(options);
var request = new GetProductMockupRequestExternalRequest { /* set properties */ };
var result = await client.Mockups.GetProductMockupRequestExternal(request);
// handle result---
```
## Features

- Place mockup and product line orders
- Retrieve order status
- Secure integration with GXSIO API
- Supports dependency injection for modern .NET applications

---

## Example: Placing a Mockup Order

---

## License

MIT

---

## Repository

[https://github.com/g7-solutions/GXSIO-API-SDK-.net](https://github.com/g7-solutions/GXSIO-API-SDK-.net)



