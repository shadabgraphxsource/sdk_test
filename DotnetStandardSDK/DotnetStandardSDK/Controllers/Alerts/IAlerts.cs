using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Alerts;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Alerts
{
    public interface IAlerts
    {
        Task<Result<string>> PostAlertsForMockupOrder(PostAlertsForOrderRequest getProductMockupRequestExternalRequest);
        Task<Result<string>> PostAlertsForTemplateOrder(PostAlertsForOrderRequest getProductMockupRequestExternalRequest);
        Task<Result<string>> PostAlertsForArtOrder(PostAlertsForOrderRequest getProductMockupRequestExternalRequest);
        Task<Result<GetAllAlertResponse>> GetAlertsForMockupOrder(string customerName, int OutsourcedMockupOrderId);
        Task<Result<GetAllAlertResponse>> GetAlertsForTemplateOrder(string customerName, int OutsourcedProductTemplateOrderId);
        Task<Result<GetAllAlertResponse>> GetAlertsForArtOrder(string customerName, int OutsourcedArtOrderId);

    }
}
