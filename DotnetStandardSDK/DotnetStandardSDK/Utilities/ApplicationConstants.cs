using DotnetStandardSDK.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotnetStandardSDK.Utilities
{
    public class EnvironmentUrlAttribute : Attribute
    {
        public string Url { get; }
        public EnvironmentUrlAttribute(string url)
        {
            Url = url;
        }
    }


    public enum EnvironmentType
    {
        Development = 1,

        Production = 2
    }

    public static class ApplicationConstants
    {
        public static Dictionary<EnvironmentType, string> EnvironmentURLs = new Dictionary<EnvironmentType, string>
        {
            { EnvironmentType.Development, "http://localhost:52510"/*"https://api.dev.graphxserver.io"*/ },
            { EnvironmentType.Production, "https://api.graphxserver.io" }
        };
        public static string GetEnvironmentUrl(EnvironmentType environment)
        {
            var type = typeof(EnvironmentType);
            var memInfo = type.GetMember(environment.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(EnvironmentUrlAttribute), false);
                if (attrs.Length > 0)
                    return ((EnvironmentUrlAttribute)attrs[0]).Url;
            }
            throw new InvalidOperationException("No URL defined for this environment.");
        }

        //var url = GetEnvironmentUrl(ApplicationConstants.EnvironmentType.Development);

        public const int TokenExpiryTimeInHour = 7;
        public static class GenericTypeMapper
        {
            /// <summary>
            /// Maps properties from source to destination by matching property names (case-insensitive, using ToLower()) and compatible types.
            /// Supports nested objects and lists of objects.
            /// </summary>
            public static TDestination Map<TSource, TDestination>(TSource source)
                where TDestination : new()
            {
                if (source == null) return default;

                // Define the property names as variables
                var companyNamePropName = "companyname";
                var customerNamePropName = "customername";

                var sourceType = typeof(TSource);
                var destType = typeof(TDestination);

                // Handle collections (existing logic)
                if (typeof(IEnumerable).IsAssignableFrom(sourceType) && sourceType != typeof(string) &&
                    typeof(IEnumerable).IsAssignableFrom(destType) && destType != typeof(string))
                {
                    var srcElementType = sourceType.IsGenericType
                        ? sourceType.GetGenericArguments()[0]
                        : typeof(object);

                    var destElementType = destType.IsGenericType
                        ? destType.GetGenericArguments()[0]
                        : typeof(object);

                    var srcEnumerable = source as IEnumerable;
                    var listType = typeof(List<>).MakeGenericType(destElementType);
                    var destList = (IList)Activator.CreateInstance(listType);

                    foreach (var item in srcEnumerable)
                    {
                        if (item == null)
                        {
                            destList.Add(null);
                        }
                        else if (destElementType.IsAssignableFrom(srcElementType))
                        {
                            destList.Add(item);
                        }
                        else
                        {
                            var mappedItem = typeof(GenericTypeMapper)
                                .GetMethod(nameof(Map), BindingFlags.Public | BindingFlags.Static)
                                .MakeGenericMethod(srcElementType, destElementType)
                                .Invoke(null, new[] { item });
                            destList.Add(mappedItem);
                        }
                    }
                    return (TDestination)destList;
                }

                // Single object mapping
                var sourceProps = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var destProps = destType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var dest = new TDestination();

                // --- Hardcoded mapping for companyname/customername using variables ---
                var srcCompanyNameProp = sourceProps.FirstOrDefault(p => p.Name.Equals(companyNamePropName, StringComparison.OrdinalIgnoreCase));
                var srcCustomerNameProp = sourceProps.FirstOrDefault(p => p.Name.Equals(customerNamePropName, StringComparison.OrdinalIgnoreCase));
                var srcNameProp = srcCompanyNameProp ?? srcCustomerNameProp;
                if (srcNameProp != null)
                {
                    var srcValue = srcNameProp.GetValue(source, null);
                    foreach (var destProp in destProps)
                    {
                        if ((destProp.Name.Equals(companyNamePropName, StringComparison.OrdinalIgnoreCase) ||
                             destProp.Name.Equals(customerNamePropName, StringComparison.OrdinalIgnoreCase)) &&
                            destProp.CanWrite)
                        {
                            destProp.SetValue(dest, srcValue, null);
                        }
                    }
                }
                // --- End hardcoded mapping ---

                foreach (var destProp in destProps)
                {
                    // Skip if already set by hardcoded logic
                    if ((destProp.Name.Equals(companyNamePropName, StringComparison.OrdinalIgnoreCase) ||
                         destProp.Name.Equals(customerNamePropName, StringComparison.OrdinalIgnoreCase)))
                        continue;

                    var srcProp = sourceProps.FirstOrDefault(sp => sp.Name.ToLowerInvariant() == destProp.Name.ToLowerInvariant());
                    if (srcProp != null && srcProp.CanRead && destProp.CanWrite)
                    {
                        var srcValue = srcProp.GetValue(source, null);
                        if (srcValue == null)
                        {
                            destProp.SetValue(dest, null, null);
                            continue;
                        }

                        if (typeof(IEnumerable).IsAssignableFrom(destProp.PropertyType) && destProp.PropertyType != typeof(string))
                        {
                            var destElementType = destProp.PropertyType.IsGenericType
                                ? destProp.PropertyType.GetGenericArguments()[0]
                                : typeof(object);

                            var srcElementType = srcProp.PropertyType.IsGenericType
                                ? srcProp.PropertyType.GetGenericArguments()[0]
                                : typeof(object);

                            if (srcValue is IEnumerable srcEnumerable)
                            {
                                var listType = typeof(List<>).MakeGenericType(destElementType);
                                var destList = (IList)Activator.CreateInstance(listType);

                                foreach (var item in srcEnumerable)
                                {
                                    if (item == null)
                                    {
                                        destList.Add(null);
                                    }
                                    else if (destElementType.IsAssignableFrom(srcElementType))
                                    {
                                        destList.Add(item);
                                    }
                                    else
                                    {
                                        var mappedItem = typeof(GenericTypeMapper)
                                            .GetMethod(nameof(Map), BindingFlags.Public | BindingFlags.Static)
                                            .MakeGenericMethod(srcElementType, destElementType)
                                            .Invoke(null, new[] { item });
                                        destList.Add(mappedItem);
                                    }
                                }
                                destProp.SetValue(dest, destList, null);
                            }
                        }
                        else if (destProp.PropertyType.IsClass && destProp.PropertyType != typeof(string))
                        {
                            var mappedValue = typeof(GenericTypeMapper)
                                .GetMethod(nameof(Map), BindingFlags.Public | BindingFlags.Static)
                                .MakeGenericMethod(srcProp.PropertyType, destProp.PropertyType)
                                .Invoke(null, new[] { srcValue });
                            destProp.SetValue(dest, mappedValue, null);
                        }
                        else if (destProp.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                        {
                            destProp.SetValue(dest, srcValue, null);
                        }
                    }
                }
                return dest;
            }
        }

        /// <summary>
        /// Converts a GenericPostResponseInfo<T> to GenericResponse<T>.
        /// </summary>
        public static GenericResponse<T> ToGenericResponse<T>(GenericPostResponseInfo<T> info)
            where T : class
        {
            if (info == null) return null;

            return new GenericResponse<T>
            {
                data = info.TObject,
                status = info.Status,
                errors = info.Error != null
                    ? info.Error.Select(e => new Error { code = e.Code, message = e.Message }).ToList()
                    : new List<Error>()
            };
        }

        /// <summary>
        /// Converts a GenericResponse<T> to GenericPostResponseInfo<T>.
        /// </summary>
        public static GenericPostResponseInfo<T> ToGenericPostResponseInfo<T>(GenericResponse<T> response)
            where T : class
        {
            if (response == null) return null;

            return new GenericPostResponseInfo<T>
            {
                TObject = response.data,
                Status = response.status,
                ErrorMessage = response.errors != null && response.errors.Count > 0
                    ? string.Join("; ", response.errors.Select(e => e.message))
                    : null,
                ErrorCode = response.errors != null && response.errors.Count > 0
                    ? response.errors[0].code
                    : null,
                Error = response.errors != null
                    ? response.errors.Select(e => new ErrorList { Code = e.code, Message = e.message }).ToList()
                    : null
            };
        }

        /// <summary>
        /// Converts a GenericPostResponseInfo<T> to Result<T>.
        /// </summary>
        public static Result<T> ToResult<T>(GenericPostResponseInfo<T> responseInfo)
            where T : class
        {
            if (responseInfo == null)
                return Result<T>.Failure(new List<Error> { new Error { code = "NullResponse", message = "Response is null." } });

            // Consider "1" as success, otherwise failure
            bool isSuccess = responseInfo.Status == "1";

            if (isSuccess)
            {
                return Result<T>.Success(responseInfo.TObject);
            }
            else
            {
                var errors = new List<Error>();

                // Map ErrorList to Error
                if (responseInfo.Error != null && responseInfo.Error.Count > 0)
                {
                    errors.AddRange(responseInfo.Error.Select(e => new Error { code = e.Code, message = e.Message }));
                }
                else
                {
                    // Fallback to ErrorCode/ErrorMessage if Error list is empty
                    if (!string.IsNullOrEmpty(responseInfo.ErrorCode) || !string.IsNullOrEmpty(responseInfo.ErrorMessage))
                    {
                        errors.Add(new Error { code = responseInfo.ErrorCode, message = responseInfo.ErrorMessage });
                    }
                }

                return Result<T>.Failure(errors);
            }
        }
    }
}
