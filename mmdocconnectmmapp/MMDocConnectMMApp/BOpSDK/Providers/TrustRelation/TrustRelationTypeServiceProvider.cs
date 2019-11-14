using BOp.Services.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    internal class TrustRelationTypeServiceProvider : BaseProvider, ITrustRelationTypeServiceProvider
    {

        public TrustRelationTypeServiceProvider(IRestClient client) : base(client) { }

        public List<TrustRelationType> GetAllTrustRelationTypes(Guid? applicationID = null)
        {
            var url = string.Format("trust-relation-types/");
            var httpRequest = new JSONRestRequest(url);
            if (applicationID != null)
            {
                httpRequest.AddParameter("application-id", applicationID);
            }
            var response = Execute<List<TrustRelationType>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public TrustRelationType GetTrustRelationType(Guid trustRelationTypeID)
        {
            var url = string.Format("trust-relation-types/{0}", trustRelationTypeID);
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<TrustRelationType>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public void SaveTrustRelationType(TrustRelationType trustRelationType)
        {
            var url = string.Format("trust-relation-types/{0}", trustRelationType.ID);
            var httpRequst = new JSONRestRequest(url, Method.PUT);
            httpRequst.AddBody(trustRelationType);
            Execute(httpRequst, HttpStatusCode.NoContent); 
        }

        public void RemoveTrustRelationType(Guid trustRelationTypeID)
        {
            var url = string.Format("trust-relation-types/{0}", trustRelationTypeID);
            var httpRequst = new JSONRestRequest(url, Method.DELETE);
            Execute(httpRequst, HttpStatusCode.NoContent);
        }


        public List<TrustRelationTypeGroup> GetAllTrustRelationTypeGroups(Guid? applicationID = null)
        {
            var url = string.Format("trust-relation-groups/");
            var httpRequest = new JSONRestRequest(url);
            if (applicationID != null)
            {
                httpRequest.AddParameter("application-id", applicationID);
            }
            var response = Execute<List<TrustRelationTypeGroup>>(httpRequest, HttpStatusCode.OK);
            return response.Data.ConvertAll(o => (TrustRelationTypeGroup)o);
        }

        public TrustRelationTypeGroup GetTrustRelationGroup(string trustRelationTypeGroupCode)
        {
            var url = string.Format("trust-relation-groups/{0}", trustRelationTypeGroupCode);
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<TrustRelationTypeGroup>(httpRequest, HttpStatusCode.OK);
            return (TrustRelationTypeGroup)response.Data;
        }

        public void SaveTrustRelationTypeGroup(TrustRelationTypeGroup trustRelationTypeGroup)
        {
            var url = string.Format("trust-relation-groups/");
            var httpRequest = new JSONRestRequest(url, Method.POST);
            httpRequest.AddBody(trustRelationTypeGroup as TrustRelationTypeGroup);
            Execute(httpRequest, HttpStatusCode.Created);
        }

        public void RemoveTrustRelationTypeGroup(string trustRelationTypeGroupCode)
        {
            var url = string.Format("trust-relation-groups/{0}", trustRelationTypeGroupCode);
            var httpRequest = new JSONRestRequest(url, Method.DELETE);
            Execute(httpRequest, HttpStatusCode.NoContent);
        }
    }
}
