using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Archive.Retrieval
{
    public class Get_Archive_Items
    {
        public static List<Archive_Model> Get_Archived_items(ElasticParameterObject sort_parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "docarchive";
            List<Archive_Model> archItems = new List<Archive_Model>();
            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var sort_by_second_key = "";
                var sort_by_third_key = "";

                switch (sort_parameter.sort_by)
                {
                    case "filedate":
                        sort_parameter.sort_by = "creationtimestamp";
                        sort_by_second_key = "filetype.lower_case_sort";
                        sort_by_third_key = "recipient.lower_case_sort";
                        break;
                    case "filetype":
                        sort_by_second_key = "recipient.lower_case_sort";
                        sort_by_third_key =  "creationtimestamp";
                        break;
                    case "recipient":
                        sort_by_second_key = "filetype.lower_case_sort";
                        sort_by_third_key =  "creationtimestamp";
                        break;
                    default:
                        sort_parameter.sort_by = "creationtimestamp";
                        sort_by_second_key = "filetype.lower_case_sort";
                        sort_by_third_key = "recipient.lower_case_sort";
                        break;
                }
                if (sort_parameter.filter_by == null || sort_parameter.filter_by.filter_status.Count() == 0 && String.IsNullOrEmpty(sort_parameter.search_params) && string.IsNullOrEmpty(sort_parameter.date_from) && string.IsNullOrEmpty(sort_parameter.date_to))
                    queryS = QueryBuilderArchive.BuildGetArchiveQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_by_second_key, sort_by_third_key);
                else if (sort_parameter.filter_by == null || sort_parameter.filter_by.filter_status.Count() == 0 && !String.IsNullOrEmpty(sort_parameter.search_params))
                {
                    queryS = QueryBuilderArchive.BuildGetArchiveSearchAsYouTypeQueryWithParam(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_parameter.search_params, sort_parameter.filter_by, sort_by_second_key, sort_by_third_key, sort_parameter.date_from, sort_parameter.date_to);
                }
                else
                {
                    sort_parameter.search_params = string.IsNullOrEmpty(sort_parameter.search_params) ? "" : sort_parameter.search_params.ToLower();
                    queryS = QueryBuilderArchive.BuildGetArchiveSearchAsYouTypeQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_parameter.search_params, sort_parameter.filter_by, sort_by_second_key, sort_by_third_key, sort_parameter.date_from, sort_parameter.date_to);
                }

                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, queryS);
                Dictionary<string, int> PracticeDoctorsCount = new Dictionary<string, int>();
                var foundResults_Cases = serializer.ToSearchResult<Archive_Model>(result);
                try
                {
                    foreach (var item in foundResults_Cases.Documents)
                    {

                        switch (sort_parameter.sort_by)
                        {
                            case "creationtimestamp": item.group_name = item.filedate.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)).ToUpper(); break;
                            case "filetype": item.group_name = item.filetype.ToUpper(); break;
                            case "recipient": item.group_name = item.recipient.Substring(0, 1).ToUpper(); break;
                        }
                        item.filetime = item.creationtimestamp.ToString("HH:mm");

                        archItems.Add(item);
                    }

                }
                catch (Exception)
                {

                }

            }
            return archItems;
        }

    }
}
