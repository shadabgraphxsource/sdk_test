using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DotnetStandardSDK.Models
{
    internal class Common
    {
    }

    [DataContract]
    public class GenericPostRequestInfo<T> : BaseRequestInfo where T : class
    {
        [DataMember]
        public T TObject { get; set; }
        [DataMember]
        public List<T> TObjectLst { get; set; }

    }
    [DataContract]
    public class BaseRequestInfo
    {
    }

    [DataContract]
    public class GenericPostResponseInfo<T> : BaseResponseInfo where T : class
    {
        [DataMember]
        public T TObject { get; set; }
        [DataMember]
        public List<T> TObjectLst { get; set; }
        [DataMember]
        public List<T> TObjectList { get; set; }

    }

    [DataContract]
    public class BaseResponseInfo
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public object ExtraData { get; set; }

        [DataMember]
        public List<ErrorList> Error { get; set; }

    }

    public class ErrorList
    {
        public string Code { get; set; }

        public string Message { get; set; }
        public int ID { get; set; }
    }

    public class GenericResponse<T>
    {
        public T data { get; set; }
        public string status { get; set; }
        public List<Error> errors { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class Result<T>
    {
        public bool IsSuccess { get; }
        public List<Error> Errors { get; } = new List<Error>(); 
        public T Value { get; }

        private Result(bool isSuccess, T value, List<Error> errors)
        {
            IsSuccess = isSuccess;
            Value = value;
            if (errors != null)
                Errors.AddRange(errors);
        }

        public static Result<T> Success(T value) =>
            new Result<T>(true, value, null);

        public static Result<T> Failure(params Error[] errors) =>
            new Result<T>(false, default, errors?.ToList());

        public static Result<T> Failure(List<Error> errors) =>
            new Result<T>(false, default, errors);
    }
}
