using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Doctor.Retrieval
{
    public class Get_Practices_and_Doctors
    {
        private static string elasticType = "user";
        public static List<Practice_Doctors_Model> Get_Doctors_and_PracticesList(ElasticParameterObject sort_parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {

                if (sort_parameter.filter_by == null && String.IsNullOrEmpty(sort_parameter.search_params))
                    queryS = QueryBuilderDoctors.BuildGetDoctorsQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc);
                else
                {
                    sort_parameter.search_params = sort_parameter.search_params != null ? sort_parameter.search_params.ToLower() : sort_parameter.search_params;
                    queryS = QueryBuilderDoctors.BuildGetDoctorsQueryFilter(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_parameter.search_params, sort_parameter.filter_by);
                }

                string searchCommand_Doc_Practices = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Doc_Practices, queryS);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctors_Model>(result);
                try
                {
                    foreach (var item in foundResults_Doctors.Documents)
                    {
                        item.order_name = sort_parameter.sort_by;

                        if (sort_parameter.sort_by.Equals("bank_untouched"))
                        {
                            item.group_name = string.IsNullOrEmpty(item.bank) ? "-" : item.bank;
                        }
                        else if (sort_parameter.sort_by.Equals("type"))
                        {
                            item.group_name = item.type.Equals("Doctor") ? "Arzt" : "Praxis";
                        }
                        else if (sort_parameter.sort_by.Equals("account_status"))
                        {
                            item.group_name = item.account_status;
                        }
                        else if (sort_parameter.sort_by.Equals("contract"))
                        {
                            item.group_name = item.contract.ToString();
                        }
                        else
                        {
                            item.group_name = string.IsNullOrEmpty(item.name_untouched) ? "-" : item.name_untouched.Substring(0, 1).ToUpper();
                        }
                        if (item.type == "Doctor")
                            item.doctor_count_or_practice_name = item.practice_name_for_doctor;
                        else
                        {
                            var query = new QueryBuilder<Practice_Doctors_Model>()
                                     .Query(q => q
                                      .Bool(b => b
                                               .Must(must => must.Terms(t => t.Field(f1 => f1.type).Values("doctor").MinimumMatch(1))
                                                  .Terms(t1 => t1.Field(f => f.practice_for_doctor_id).Values(item.id).MinimumMatch(1))
                                      )));

                            var doctor_count = serializer.ToCountResult(connection.Post(Commands.Count(securityTicket.TenantID.ToString(), elasticType), query.BuildBeautified()).Result);
                            item.doctor_count_or_practice_name = doctor_count.count.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.StackTrace;
                }

                modelForSendL = foundResults_Doctors.Documents.ToList();
            }

            return modelForSendL;
        }

        public static List<Practice_Doctors_Model> Get_AC_Doctors_and_Practices(Practice_Parameter parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var query = new QueryBuilder<Practice_Doctors_Model>()
                      .Query(q => q
                          .Bool(b => b
                              .Should(sh => sh.Bool(tb => tb.Should(s => s.Bool(tbt => tbt.Must(m => m
                                  .Term(tr => tr.Field("practice_for_doctor_id").Value(parameter.practice_id.ToString()))
                                  .Term(tr => tr.Field("account_status").Value("temp"))
                                  )).Bool(ab => ab.Must(mm => mm.Term(tt => tt.Field("account_status").Value("aktiv"))))
                                  ).MinimumNumberShouldMatch(1))
                                  .Match(m => m
                                      .Field("name")
                                      .Query(parameter.search_criteria.ToLower()).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                  .Match(m => m
                                      .Field("bsnr_lanr")
                                      .Query(parameter.search_criteria.ToLower()).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                  ).MinimumNumberShouldMatch(2)
                              )
                          ).Sort(s => s.Field(sr => sr.type, PlainElastic.Net.SortDirection.asc)
                                       .Field(parameter.sortfield, parameter.ascending ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc))
                          .From(0)
                          .Size(100);

                queryS = query.BuildBeautified();
                string searchCommand_Doc_Practices = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Doc_Practices, queryS);
                Dictionary<string, int> PracticeDoctorsCount = new Dictionary<string, int>();
                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctors_Model>(result);
                try
                {
                    foreach (var item in foundResults_Doctors.Documents)
                    {
                        item.type = item.type.Equals("Practice") ? "LABEL_PRACTICES" : "LABEL_DOCTORS";
                    }

                    modelForSendL = foundResults_Doctors.Documents.ToList();
                }
                catch (Exception ex)
                {
                    var a = ex.StackTrace;
                }
            }
            return modelForSendL;
        }

        public static List<Practice_Doctor_Last_Used_Model> Get_Last_Used_Doctors_Practices(Guid practice_id, SessionSecurityTicket securityTicket, string elastic_type_prefix = null)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var AccountID = securityTicket.AccountID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var queryS = string.Empty;
            if (String.IsNullOrEmpty(elastic_type_prefix))
            {
                elastic_type_prefix = "user_";
            }

            var elastic_type = elastic_type_prefix + AccountID;

            var modelForSendL = new List<Practice_Doctor_Last_Used_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elastic_type, connection))
            {
                var query = new QueryBuilder<Practice_Doctor_Last_Used_Model>()
                    .From(0)
                       .Size(4)
                       .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field("practice_id").Value(practice_id != Guid.Empty ? practice_id.ToString() : null)))))
                            .Sort(s => s.Field("date_of_use", PlainElastic.Net.SortDirection.desc));

                queryS = query.BuildBeautified();

                string searchCommand_Doc_Practices = Commands.Search(TenantID, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Doc_Practices, queryS);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctor_Last_Used_Model>(result);
                try
                {
                    modelForSendL = foundResults_Doctors.Documents.ToList();
                }
                catch (Exception ex)
                {
                    var a = ex.StackTrace;
                }
            }
            return modelForSendL;
        }

        public static Practice_Doctor_Last_Used_Model GetLastUsedDoctorPracticeForID(string id, string type, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            string searchCommand = Commands.Index(index: securityTicket.TenantID.ToString(), type: type, id: id);

            return serializer.ToGetResult<Practice_Doctor_Last_Used_Model>(connection.Get(searchCommand).Result).Document;
        }

        public static List<Practice_Doctors_Model> Get_Doctors_for_ID_Array(string[] doctor_ids, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                queryS = QueryBuilderDoctors.BuildGetDoctorsForIDArrayQuery(doctor_ids);
                return serializer.ToSearchResult<Practice_Doctors_Model>(connection.Post(Commands.Search(TenantID, elasticType), queryS)).Documents.ToList();
            }

            return new List<Practice_Doctors_Model>();
        }

        public static List<Practice_Doctors_Model> Get_Doctors_for_SearchCriteria(string search_criteria, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                query = QueryBuilderDoctors.BuildGetDoctorsQuerySearch(search_criteria);

                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctors_Model>(result);

                modelForSendL = foundResults_Doctors.Documents.ToList();
            }

            return modelForSendL;
        }


        public static List<Practice_Doctor_Last_Used_Model> GetACDoctorsWhereIDPresent(string id, string ordinal, string tenant_id, string elastic_type)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var queryS = string.Empty;

            var modelForSendL = new List<Practice_Doctor_Last_Used_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elastic_type, connection))
            {
                var query = new QueryBuilder<Practice_Doctor_Last_Used_Model>()
                       .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id)))));

                queryS = query.BuildBeautified();

                string searchCommand_Doc_Practices = Commands.Search(tenant_id, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Doc_Practices, queryS);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctor_Last_Used_Model>(result);
                try
                {
                    modelForSendL = foundResults_Doctors.Documents.ToList();
                }
                catch (Exception ex)
                {
                    var a = ex.StackTrace;
                }
            }
            return modelForSendL;
        }

        public static List<Practice_Doctor_Last_Used_Model> Get_Last_Used_Doctors_from_Potential_Doctors(Guid practice_id, IEnumerable<String> potential_doctors, SessionSecurityTicket securityTicket, string elastic_type_prefix = null)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var AccountID = securityTicket.AccountID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var queryS = string.Empty;
            if (String.IsNullOrEmpty(elastic_type_prefix))
            {
                elastic_type_prefix = "user_";
            }

            var elastic_type = elastic_type_prefix + AccountID;

            var modelForSendL = new List<Practice_Doctor_Last_Used_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elastic_type, connection))
            {
                var query = new QueryBuilder<Practice_Doctor_Last_Used_Model>()
                    .From(0)
                       .Size(4)
                       .Query(q => q.Bool(b => b.Must(m => m
                           .Term(t => t.Field("practice_id").Value(practice_id != Guid.Empty ? practice_id.ToString() : null))
                           .Terms(t => t.Field(f => f.id).Values(potential_doctors))
                           )))
                            .Sort(s => s.Field("date_of_use", PlainElastic.Net.SortDirection.desc));

                queryS = query.BuildBeautified();

                string searchCommand_Doc_Practices = Commands.Search(TenantID, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Doc_Practices, queryS);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctor_Last_Used_Model>(result);
                try
                {
                    modelForSendL = foundResults_Doctors.Documents.ToList();
                }
                catch (Exception ex)
                {
                    var a = ex.StackTrace;
                }
            }
            return modelForSendL;
        }

        public static List<Practice_Doctors_Model> Get_Doctors_for_SearchCriteria_and_Potential_Doctors(string search_criteria, IEnumerable<String> potential_doctors, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                query = QueryBuilderDoctors.BuildGetDoctorsQuerySearch(search_criteria, potential_doctors);

                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctors_Model>(result);

                modelForSendL = foundResults_Doctors.Documents.ToList();
            }

            return modelForSendL;
        }
    }
}
