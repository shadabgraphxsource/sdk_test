using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;

namespace DotnetStandardSDK.Models.Alerts
{
    public class AlertDetail
    {
        public List<Attachment> attachments { get; set; }
        public string alertCreatedOn { get; set; }
        public List<AlertReplies> alertReplies { get; set; }
        public string alertMessage { get; set; }
        public string actionTakenOn { get; set; }
        public string alertHeadPuncher { get; set; }
        public string alertSubject { get; set; }
        public object alertCategory { get; set; }
        public string alertPuncher { get; set; }
        public string createdByRole { get; set; }
    }

    public class Attachment
    {
        public string originalFileName { get; set; }
        public string filenameOnDisk { get; set; }
        public string cloudUrl { get; set; }
    }

    public class GetAllAlertResponse
    {
        public List<AlertDetail> alertDetails { get; set; }
        public string errorMessage { get; set; }
    }

    public class AlertReplies
    {
        public string alertMessage { get; set; }
        public string alertCreatedBy { get; set; }
        public string alertCreatedOn { get; set; }
        public bool isReinstated { get; set; }       
        public string createdByRole { get; set; }
    }
}
