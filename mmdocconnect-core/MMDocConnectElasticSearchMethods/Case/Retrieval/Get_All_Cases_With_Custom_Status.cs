using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Case.Retrieval
{
    public class Get_All_Cases_With_Custom_Status
    {
        public static List<Submitted_Case_Model> Get_All_Submited_Cases_With_Custom_Status(string status, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "submitted_case";
            
            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                queryS = QueryBuilderCase.BuildGetAllCaseQuery(status, securityTicket.TenantID.ToString());
                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, queryS);

                return serializer.ToSearchResult<Submitted_Case_Model>(result).Documents.ToList();
            }

            return new List<Submitted_Case_Model>();
        }


    }
}
