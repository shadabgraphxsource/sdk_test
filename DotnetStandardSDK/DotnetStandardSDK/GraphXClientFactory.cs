using DotnetStandardSDK.Authentication;
using DotnetStandardSDK.Controllers.Alerts;
using DotnetStandardSDK.Controllers.Mockups;
using DotnetStandardSDK.Controllers.ProductLine;
using DotnetStandardSDK.Controllers.Products;
using DotnetStandardSDK.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotnetStandardSDK
{
    public static class GraphXClientFactory
    {
        //public static readonly string baseURL = "http://localhost:52510";
        internal static readonly HttpClient _httpClient = new HttpClient();
        public static string token { get; set; }

        //public static ISecurityClient Security => RestService.For<ISecurityClient>(_httpClient);
        //public static IProductMockupRequestClient Product => RestService.For<IProductMockupRequestClient>(_httpClient);
        //public static IMockups Mockups => new Mockups(Product);

        //public static IAlertClient Alert => RestService.For<IAlertClient>(_httpClient);
    }

    public class GraphXClient1 : IGraphXClient1
    {
        private readonly string _baseURL;
        private readonly object _lock = new object();
        public GraphXClient1()
        {

        }
        private GraphXClient1(string baseURL, string companyName, string userName, string password)
        {
            lock (_lock)
            {
                _baseURL = baseURL;
                GraphXClientFactory._httpClient.BaseAddress = new Uri(_baseURL);

                //var tokenResult = GraphXClientFactory.Security.GetGraphXServerAPITokenAsync(companyName, userName, password).Result;
                //GraphXClientFactory.token = tokenResult;
                //GraphXClientFactory._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GraphXClientFactory.token}");
            }
        }
        public GraphXClient1 Build(string baseURL, string companyName, string userName, string password)
        {
            return new GraphXClient1(baseURL, companyName, userName, password);
        }
    }
    public class GraphXClientOptions
    {
        public EnvironmentType Environment { get; set; }
        public string Key { get; set; }

    }
    

    public class GraphXClient : IGraphXClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly GraphXClientOptions _options;
        private string _token;
        private DateTime _tokenSetDate;
        private IMockups _mockups;
        private IAlerts _alerts;
        private IProductLineMockups _productLine;
        private IProducts _products;
        private EnvironmentType _environmentType;
        private string _key;

        public GraphXClient(GraphXClientOptions options)
        {
            _options = options;
        }

        public GraphXClient(EnvironmentType environmentType, string Key)
        {
            _environmentType = environmentType;
            _key = Key;
        }
        public async Task<bool> EnsureAuthenticatedAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(_token))
                { 
                    _httpClient.BaseAddress = new Uri(ApplicationConstants.EnvironmentURLs[_options.Environment]);
                    var securityClient = RestService.For<ISecurityClient>(_httpClient);
                    _token = await securityClient.GenerateTokenByAPISDKKey(_options.Key);
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    _tokenSetDate = DateTime.Now;
                    _mockups = new Mockups(RestService.For<IProductMockupRequestClient>(_httpClient));
                    _alerts = new Alerts(RestService.For<IAlertClient>(_httpClient));
                    _productLine = new ProductLineMockups(RestService.For<IProductLineMockupsClient>(_httpClient));
                    _products = new Products(RestService.For<IProductsClient>(_httpClient));
                    if (string.IsNullOrEmpty(_token))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (DateTime.Now - _tokenSetDate > TimeSpan.FromHours(ApplicationConstants.TokenExpiryTimeInHour))
                    {
                        var securityClient = RestService.For<ISecurityClient>(_httpClient);
                        _token = await securityClient.GenerateTokenByAPISDKKey(_options.Key);
                        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        _tokenSetDate = DateTime.Now;
                    }
                    return true;
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }
        public static async Task<GraphXClient> BuildAsync(GraphXClientOptions options)
        {
            var client = new GraphXClient(options);
            await client.EnsureAuthenticatedAsync();
            return client;
        }

        public IMockups Mockups
        {
            get
            {
                if (!EnsureAuthenticatedAsync().Result)
                    throw new InvalidOperationException("Authenticate first");

                return _mockups;
            }
        }
        public IAlerts Alerts
        {
            get
            {
                if (!EnsureAuthenticatedAsync().Result)
                    throw new InvalidOperationException("Authenticate first");

                return _alerts;
            }
        }
        public IProductLineMockups ProductLine
        {
            get
            {
                if (!EnsureAuthenticatedAsync().Result)
                    throw new InvalidOperationException("Authenticate first");

                return _productLine;
            }
        }
        public IProducts Products
        {
            get
            {
                if (!EnsureAuthenticatedAsync().Result)
                    throw new InvalidOperationException("Authenticate first");
                return _products;
            }
        }
    }

    public static class GraphXClientServiceCollectionExtensions
    {
        public static async Task<IServiceCollection> AddGraphXClientAsync(
            this IServiceCollection services,
            Action<GraphXClientOptions> configureOptions)
        {
            var options = new GraphXClientOptions();
            configureOptions(options);

            // Register options as singleton
            services.AddSingleton(options);

            // Register GraphXClient as singleton using a factory
            var client = await GraphXClient.BuildAsync(options);
            services.AddSingleton<IGraphXClient>(client);

            return services;
        }
    }
}
