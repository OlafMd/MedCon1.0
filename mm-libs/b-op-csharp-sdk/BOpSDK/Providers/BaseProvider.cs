using BOp.Exceptions;
using BOp.Services.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BOp.Providers
{
    abstract class BaseProvider
    {
        protected IRestClient _client;

        public BaseProvider(IRestClient client)
        {
            _client = client;
        }

        public IRestResponse Execute(JSONRestRequest request, HttpStatusCode expectedResponse)
        {
            var response = _client.Execute(request);
            if (response.StatusCode != expectedResponse)
            {
                throw new SDKServiceException(this.GetType().Name, response);
            }
            return response;
        }

        public IRestResponse<T> Execute<T>(JSONRestRequest request, HttpStatusCode expectedResponse) where T : new()
        {
            var response = _client.Execute<T>(request);
            if (response.StatusCode != expectedResponse)
            {
                throw new SDKServiceException(this.GetType().Name, response);
            }
            return response;
        }

        public byte[] Download(JSONRestRequest request) 
        {
            return _client.DownloadData(request);
        }
    }
}
