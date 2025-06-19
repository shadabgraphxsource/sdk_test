using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Alerts
{

    #region [request original]
    public class AlertAttachmentFileOriginal
    {
        public string AttachmentURL { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
    }

    public class PostAlertsForOrderRequestOriginal

    {
        public string CompanyName { get; set; }
        public int OutsourcedMockupOrderId { get; set; }
        public int OutsourcedProductTemplateOrderId { get; set; }
        public int OutsourcedArtOrderId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<AlertAttachmentFileOriginal> AlertAttachmentFiles { get; set; }
    }
    #endregion [request original]

    #region [request]
    public class AlertAttachmentFile
    {
        public string attachmentURL { get; set; }
        public string fileName { get; set; }
        public string fileExtension { get; set; }
    }

    public class PostAlertsForOrderRequest
    {
        public string customerName { get; set; }

        public int outsourcedMockupOrderId { get; set; }
        public int outsourcedProductTemplateOrderId { get; set; }
        public int outsourcedArtOrderId { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public List<AlertAttachmentFile> alertAttachmentFiles { get; set; }
    }
    #endregion [request]


}
