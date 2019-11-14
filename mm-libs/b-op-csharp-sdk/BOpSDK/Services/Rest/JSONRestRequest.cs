using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Serializers;
using BOp.Providers.TrustRelation;
using BOp.Providers.TMS;

namespace BOp.Services.Rest
{
    internal class JSONRestRequest : RestRequest
    {

        public JSONRestRequest() : this("", Method.GET) { }

        public JSONRestRequest(string resource) : this(resource, Method.GET) { }

        public JSONRestRequest(string resource, Method method)
            : base(resource, method)
        {
            RequestFormat = DataFormat.Json;
            JsonSerializer = new BOp.Services.Serialization.JSONSerializer();
            AddHeader("Accept", "application/json");
        }
        public void ApplyTrustRelationRequestFilters(TrustRelationRequestFilter filter)
        {
            if (filter != null)
            {
                if (filter.RequestStatus != TrustRequestStatus.None)
                    this.AddParameter("status", (int)filter.RequestStatus);

                if (filter.From != null)
                    this.AddParameter("from", String.Format("{0:yyyy-MM-dd}", filter.From));

                if (filter.To != null)
                    this.AddParameter("to", String.Format("{0:yyyy-MM-dd}", filter.To));

            }
        }
        public void ApplyTrustRelationFilters(TrustRelationFilter filter)
        {
            if (filter != null)
            {
                if (filter.Active != null)
                    this.AddParameter("status", filter.Active.Value ? "active" : "revoked");

            }
        }

        public void ApplySessionFilters(SessionFilter filter)
        {
            if (filter != null)
            {
                if (filter.Active != null)
                {
                    this.AddParameter("active", filter.Active);
                }
                if (filter.From != null)
                {
                    this.AddParameter("from", String.Format("{0:dd/MM/yyyy}", filter.From));
                }
                if (filter.To != null)
                {
                    this.AddParameter("to", String.Format("{0:dd/MM/yyyy}", filter.To));
                }
            }
        }
    }
}
