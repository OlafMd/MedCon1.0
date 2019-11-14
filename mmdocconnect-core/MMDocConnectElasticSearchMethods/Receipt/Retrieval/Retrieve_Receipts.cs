using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
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

        public static List<Receipt_Model> Get_Receipt_Items(ElasticParameterObject sort_parameter, string doctor_id, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            List<Receipt_Model> receipts = new List<Receipt_Model>();
            string searchCommand_Receipts = Commands.Search(TenantID, elasticType).Pretty();
            var queryS = QueryBuilderReceipts.BuildGetReceiptsQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, doctor_id);
            string result = connection.Post(searchCommand_Receipts, queryS);
            var foundResults_Receipts = serializer.ToSearchResult<Receipt_Model>(result);

            return foundResults_Receipts.Documents.Select(item =>
            {
                switch (sort_parameter.sort_by)
                {
                    case "filedate": item.group_name = item.filedate.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)).ToUpper(); break;
                }

                item.filedateString = item.filedate.ToString("dd.MM.yyyy");
                return item;
            }).ToList();
        }

        public static long GetNonViewedRecepiptsCount(string doctor_id, SessionSecurityTicket securityTicket)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString(), connection) && Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/" + elasticType, connection))
            {
                string result = connection.Post(Commands.Count(securityTicket.TenantID.ToString(), elasticType), QueryBuilderReceipts.BuildGetNonViewedReceiptsQuery(doctor_id));
                return serializer.ToCountResult(result).count;
            }

            return 0;
        }

    }
}
