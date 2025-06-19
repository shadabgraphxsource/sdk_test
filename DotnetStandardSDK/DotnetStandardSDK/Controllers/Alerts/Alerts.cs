using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Alerts;
using DotnetStandardSDK.Utilities;
using System;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Alerts
{
    internal class Alerts : IAlerts
    {
        private readonly IAlertClient _alertClient;

        public Alerts(IAlertClient alertClient)
        {
            _alertClient = alertClient;
        }

        public async Task<Result<string>> PostAlertsForMockupOrder(PostAlertsForOrderRequest postAlertsForOrderRequest)
        {
            try
            {
                var postAlertsForOrderRequestOriginal = ApplicationConstants.GenericTypeMapper.Map<PostAlertsForOrderRequest, PostAlertsForOrderRequestOriginal>(postAlertsForOrderRequest);
                var request = new GenericPostRequestInfo<PostAlertsForOrderRequestOriginal> { TObject = postAlertsForOrderRequestOriginal };
                var response = await _alertClient.PostAlertsForMockupOrder(request);
                var resultInfo = new GenericPostResponseInfo<string>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = response.Status
                };
                return ApplicationConstants.ToResult<string>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<string>> PostAlertsForTemplateOrder(PostAlertsForOrderRequest postAlertsForOrderRequest)
        {
            try
            {
                var postAlertsForOrderRequestOriginal = ApplicationConstants.GenericTypeMapper.Map<PostAlertsForOrderRequest, PostAlertsForOrderRequestOriginal>(postAlertsForOrderRequest);
                var request = new GenericPostRequestInfo<PostAlertsForOrderRequestOriginal> { TObject = postAlertsForOrderRequestOriginal };
                var response = await _alertClient.PostAlertsForTemplateOrder(request);
                var resultInfo = new GenericPostResponseInfo<string>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = response.Status
                };
                return ApplicationConstants.ToResult<string>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<string>> PostAlertsForArtOrder(PostAlertsForOrderRequest postAlertsForOrderRequest)
        {
            try
            {
                var postAlertsForOrderRequestOriginal = ApplicationConstants.GenericTypeMapper.Map<PostAlertsForOrderRequest, PostAlertsForOrderRequestOriginal>(postAlertsForOrderRequest);
                var request = new GenericPostRequestInfo<PostAlertsForOrderRequestOriginal> { TObject = postAlertsForOrderRequestOriginal };
                var response = await _alertClient.PostAlertsForArtOrder(request);
                var resultInfo = new GenericPostResponseInfo<string>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = response.Status
                };
                return ApplicationConstants.ToResult<string>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<GetAllAlertResponse>> GetAlertsForMockupOrder(string customerName, int outsourcedMockupOrderId)
        {
            try
            {
                var response = await _alertClient.GetAlertsForMockupOrder(customerName, outsourcedMockupOrderId);
                var resultInfo = new GenericPostResponseInfo<GetAllAlertResponse>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = response.TObject
                };
                return ApplicationConstants.ToResult<GetAllAlertResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetAllAlertResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<GetAllAlertResponse>> GetAlertsForTemplateOrder(string customerName, int outsourcedProductTemplateOrderId)
        {
            try
            {
                var response = await _alertClient.GetAlertsForTemplateOrder(customerName, outsourcedProductTemplateOrderId);
                var resultInfo = new GenericPostResponseInfo<GetAllAlertResponse>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = response.TObject
                };
                return ApplicationConstants.ToResult<GetAllAlertResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetAllAlertResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<GetAllAlertResponse>> GetAlertsForArtOrder(string customerName, int outsourcedArtOrderId)
        {
            try
            {
                var response = await _alertClient.GetAlertsForArtOrder(customerName, outsourcedArtOrderId);
                var resultInfo = new GenericPostResponseInfo<GetAllAlertResponse>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = response.TObject
                };
                return ApplicationConstants.ToResult<GetAllAlertResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetAllAlertResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }
    }
}