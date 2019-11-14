using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>
    ///  {  
    ///    "code":70001,
    ///    "message":"Credentials invalid.",
    ///    "developerMessage":"No accounts found for \u0027tesasdt@test.com\u0027 with the provided credentials",
    ///    "additionalInformation":"http://wiki.b-op.com/wiki/Customer_Management_Service_(API)/Error_Codes#Error_-_70001"
    ///  }
    /// </example>
    [Serializable]
    public class SDKServiceException : Exception
    {
        public HttpStatusCode ServerResponseCode { get; set; }

        public string ServerResponseDescription { get; set; }
        public string SourceProvider { get; set; }
        public ServiceErrror ServiceError { get; set; }
        public SDKServiceException() { }

        public SDKServiceException(string sourceProvider, HttpStatusCode serverResponseCode, string serverResponseDescription, string message)
            : base(message)
        {
            SourceProvider = sourceProvider;
            ServerResponseCode = serverResponseCode;
            ServerResponseDescription = serverResponseDescription;
            try
            {
                ServiceError = JsonConvert.DeserializeObject<ServiceErrror>(message);
            }
            catch { }
        }

        public SDKServiceException(string sourceProvider, RestSharp.IRestResponse response)
            : this(sourceProvider, response.StatusCode, response.StatusDescription, response.Content)
        {

        }

        public SDKServiceException(string message, ServiceErrror serviceError)
            : base(message)
        {
            this.ServiceError = serviceError;
        }

    }

    [DataContract]
    public class ServiceErrror
    {
        /// <summary>
        /// Internal lookup code for the specified exception
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; set; }
        /// <summary>
        /// Simple message that can be shown to the client if required
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
        /// <summary>
        /// Message used to explain to developers what caused the error
        /// </summary>
        [DataMember(Name = "developerMessage")]
        public string DeveloperMessage { get; set; }
        /// <summary>
        /// Additiona information about the error, such as link to the wikipedia and parameter data
        /// </summary>
        [DataMember(Name = "additionalInformation")]
        public string AdditionalInformation { get; set; }

    }
}
