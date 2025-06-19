using DotnetStandardSDK.Controllers.Alerts;
using DotnetStandardSDK.Controllers.Mockups;
using DotnetStandardSDK.Controllers.ProductLine;
using DotnetStandardSDK.Controllers.Products;
using System.Threading.Tasks;

namespace DotnetStandardSDK
{
    public interface IGraphXClient1
    {
        GraphXClient1 Build(string baseURL, string companyName, string userName, string password);   
    }
    public interface IGraphXClient
    {
        Task<bool> EnsureAuthenticatedAsync();
        IMockups Mockups { get; }
        IAlerts Alerts { get; }
        IProductLineMockups ProductLine { get; }
        IProducts Products { get; }
    }
}