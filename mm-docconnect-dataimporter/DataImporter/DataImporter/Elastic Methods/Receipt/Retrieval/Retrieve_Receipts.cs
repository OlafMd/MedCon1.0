using CSV2Core.SessionSecurity;
using DataImporter.Models;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Receipt.Retrieval
{
    public class Retrieve_Receipts
    {
        private static string elasticType = "receipts";

        public static List<Receipt_Model> Get_Receipt_Items(SessionSecurityTicket userSecurityTicket)
        {
            var TenantID = userSecurityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            List<Receipt_Model> receipts = new List<Receipt_Model>();
            string searchCommand_Receipts = Commands.Search(TenantID, elasticType).Pretty();
            var queryS = QueryBuilderReceipts.BuildGetReceiptsQuery();
            string result = connection.Post(searchCommand_Receipts, queryS);
            var foundResults_Receipts = serializer.ToSearchResult<Receipt_Model>(result);

            return foundResults_Receipts.Documents.ToList();
        }
    }
}
