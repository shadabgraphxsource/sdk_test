using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Alerts;
using Refit;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Alerts
{
    
    internal interface IAlertClient
    {
        
        [Post("/api/ProductMockupRequest/PostAlertsForMockupOrder")]
        Task<GenericPostResponseInfo<string>> PostAlertsForMockupOrder(GenericPostRequestInfo<PostAlertsForOrderRequestOriginal> getProductMockupRequestExternalRequest);
        [Post("/api/ProductMockupRequest/PostAlertsForTemplateOrder")]
        Task<GenericPostResponseInfo<string>> PostAlertsForTemplateOrder(GenericPostRequestInfo<PostAlertsForOrderRequestOriginal> getProductMockupRequestExternalRequest);
        [Post("/api/ProductMockupRequest/PostAlertsForArtOrder")]
        Task<GenericPostResponseInfo<string>> PostAlertsForArtOrder(GenericPostRequestInfo<PostAlertsForOrderRequestOriginal> getProductMockupRequestExternalRequest);
        [Get("/api/ProductMockupRequest/GetAlertsForMockupOrder")]
        Task<GenericPostResponseInfo<GetAllAlertResponse>> GetAlertsForMockupOrder(string customerName, int outsourcedMockupOrderId);
        [Get("/api/ProductMockupRequest/GetAlertsForTemplateOrder")]
        Task<GenericPostResponseInfo<GetAllAlertResponse>> GetAlertsForTemplateOrder(string customerName, int outsourcedProductTemplateOrderId);
        [Get("/api/ProductMockupRequest/GetAlertsForArtOrder")]
        Task<GenericPostResponseInfo<GetAllAlertResponse>> GetAlertsForArtOrder(string customerName, int outsourcedArtOrderId);

    }
}
