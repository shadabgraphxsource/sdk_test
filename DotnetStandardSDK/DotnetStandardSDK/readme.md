

# GraphXSDKClient (.NET Standard 2.0)

This SDK enables you to place mockup and product line orders, retrieve order status, and integrate with the GXSIO API in your .NET applications.

---

## Supported Platforms

- **.NET Standard 2.0**
- **.NET Core 2.0+**
- **.NET 5/6/7/8/9**
- **.NET Framework 4.6.1 and above (including 4.7.0+)**

---
## Installation & Usage Guide

Follow these steps to install and use the GXSIO-API-SDK from GitHub Packages in your .NET project:

### 1. Add `nuget.config` for GitHub Packages
Create or update a `nuget.config` file in your project root with the following content:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/<OWNER>/index.json" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="<GITHUB_USERNAME>" />
      <add key="ClearTextPassword" value="<PERSONAL_ACCESS_TOKEN>" />
    </github>
  </packageSourceCredentials>
</configuration>
```
- Replace `<OWNER>` with the GitHub organization or username that owns the package.
- Replace `<GITHUB_USERNAME>` and `<PERSONAL_ACCESS_TOKEN>` with your GitHub username and a Personal Access Token (PAT) with `read:packages` scope.

### 2. Add the Package Dependency
Install the SDK package using the .NET CLI:

```powershell
dotnet add package GraphXSDKClient --version 1.0.0 --source "github"
```

### 3. Configuration & Usage

#### .NET Core / .NET 5+ Example

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
```    
2. **Inject and use the client:**
```csharp
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
```
#### .NET Framework Example

1. **Reference the NuGet package in your project.**
```csharp
using DotnetStandardSDK;
```
2. **Create and use the client:**
```csharp
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

```powershell
dotnet build

dotnet run
```

## Notes
- Ensure your PAT is kept secure and not committed to source control.
- For more details, see the official GitHub documentation on [authenticating to GitHub Packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-to-github-packages).

