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
    public class Get_Doctors_for_PracticeID
    {
        public static List<Practice_Doctors_Model> Get_Doctors_for_PracticeIDList(Practice_Parameter parameter, SessionSecurityTicket securityTicket)
        {
            //opdoc tenant
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "user";

            List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var query = new QueryBuilder<Practice_Doctors_Model>()
                        .From(parameter.start_row_index)
                            .Size(100).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                                .Value("doctor"))
                                    .Term(term2 => term2.Field(id => id.practice_for_doctor_id)
                                        .Value(parameter.practice_id.ToString())))))))
                                            .Sort(s => s
                                                .Field(parameter.sortfield, parameter.ascending ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                                     .Field("name_untouched", parameter.ascending ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc));

                queryS = query.BuildBeautified();

                string searchCommand_Doctors_PracticeID = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Doctors_PracticeID, queryS);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctors_Model>(result);
                foreach (var item in foundResults_Doctors.Documents)
                {
                    if (parameter.sortfield.Equals("bank_untouched"))
                    {
                        item.group_name = string.IsNullOrEmpty(item.bank) ? "-" : item.bank;
                    }
                    else if (parameter.sortfield.Equals("type"))
                    {
                        item.group_name = item.type.Equals("Doctor") ? "Arzt" : "Praxis";
                    }
                    else if (parameter.sortfield.Equals("account_status"))
                    {
                        item.group_name = item.account_status;
                    }
                    else if (parameter.sortfield.Equals("contract"))
                    {
                        item.group_name = item.contract.ToString();
                    }
                    else
                    {
                        item.group_name = string.IsNullOrEmpty(item.name_untouched) ? "-" : item.name_untouched.Substring(0, 1).ToUpper();
                    }

                    modelForSendL.Add(item);
                }
            }
            return modelForSendL;
        }

        public static List<Practice_Doctors_Model> Get_Doctors_That_Work_In_Practice_for_PracticeID(Practice_Parameter parameter, SessionSecurityTicket securityTicket)
        { //opdoc tenant
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "user";

            List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                if (string.IsNullOrEmpty(parameter.role))
                {
                    if (parameter.account_status.HasValue)
                    {
                        var status = parameter.account_status.Value ? "aktiv" : "inaktiv";
                        var query = new QueryBuilder<Practice_Doctors_Model>()
                                .From(0)
                                    .Size(1000).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                                        .Value("doctor"))
                                            .Term(term2 => term2.Field(id => id.practice_for_doctor_id)
                                                .Value(parameter.practice_id.ToString()))
                                                    .Term(term2 => term2.Field(st => st.account_status)
                                                        .Value(status)))))))
                                                            .Sort(s => s.Field("name_untouched", PlainElastic.Net.SortDirection.asc));

                        queryS = query.BuildBeautified();
                    }
                    else
                    {
                        var query = new QueryBuilder<Practice_Doctors_Model>()
                                .From(0)
                                    .Size(1000).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                                        .Value("doctor"))
                                            .Term(term2 => term2.Field(id => id.practice_for_doctor_id)
                                                .Value(parameter.practice_id.ToString()))))))).Sort(s => s.Field("name_untouched", PlainElastic.Net.SortDirection.asc));

                        queryS = query.BuildBeautified();

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(parameter.search_criteria))
                    {
                        var query = new QueryBuilder<Practice_Doctors_Model>()
                               .From(0)
                                   .Size(1000).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                                       .Value("doctor"))
                                           .Term(term2 => term2.Field(id => id.practice_for_doctor_id)
                                               .Value(parameter.practice_id.ToString()))
                                                   .Term(term2 => term2.Field(role => role.role)
                                                       .Value(parameter.role)))
                                                            .Should(s => s.Term(term => term.Field(name => name.name).Value(parameter.search_criteria.ToLower())))))))
                                                                .Sort(s => s
                                                                     .Field(parameter.sortfield, parameter.ascending ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc));

                        queryS = query.BuildBeautified();
                    }
                    else
                    {
                        var query = new QueryBuilder<Practice_Doctors_Model>()
                               .From(0)
                                   .Size(1000).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                                       .Value("doctor"))
                                           .Term(term2 => term2.Field(id => id.practice_for_doctor_id)
                                               .Value(parameter.practice_id.ToString()))
                                                   .Term(term2 => term2.Field(role => role.role)
                                                       .Value(parameter.role)))))))
                                                            .Sort(s => s
                                                                .Field(parameter.sortfield, parameter.ascending ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc));

                        queryS = query.BuildBeautified();

                    }
                }

                string searchCommand_Doctors_PracticeID = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Doctors_PracticeID, queryS);

                var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctors_Model>(result);

                modelForSendL = foundResults_Doctors.Documents.ToList();
            }

            return modelForSendL;
        }

        public static List<Practice_Doctors_Model> Get_Doctors_for_PracticeID_with_Bank_Account_Inheritance(Practice_Parameter parameter, SessionSecurityTicket securityTicket)
        { //opdoc tenant
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            var query = new QueryBuilder<Practice_Doctors_Model>()
                    .From(0)
                        .Size(1000).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                            .Value("doctor"))
                                .Term(term2 => term2.Field(id => id.practice_for_doctor_id)
                                    .Value(parameter.practice_id.ToString()))
                                        .Term(term3 => term3.Field(ia => ia.bank_info_inherited)
                                            .Value(true.ToString()))
                                                .Term(term4 => term4.Field(fi => fi.bank_id).Value(parameter.practice_bank_account_id)))))));

            queryS = query.BuildBeautified();

            string searchCommand_Doctors_PracticeID = Commands.Search(TenantID, "user").Pretty();
            string result = connection.Post(searchCommand_Doctors_PracticeID, queryS);

            var foundResults_Doctors = serializer.ToSearchResult<Practice_Doctors_Model>(result);

            return foundResults_Doctors.Documents.ToList();
        }


        public static Practice_Doctors_Model Set_Contract_Number_for_DoctorID(Doctor_Contracts parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "user";
            Practice_Doctors_Model modelPD = new Practice_Doctors_Model();
            // List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var query = new QueryBuilder<Practice_Doctors_Model>()
                        .From(0)
                            .Size(1000).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                                .Value("doctor"))
                                    .Term(term2 => term2.Field(id => id.id)
                                        .Value(parameter.DocID.ToString())))))));

                queryS = query.BuildBeautified();

                string search_doctor_for_DoctorID = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(search_doctor_for_DoctorID, queryS);

                modelPD = serializer.ToSearchResult<Practice_Doctors_Model>(result).Documents.FirstOrDefault();
            }
            return modelPD;
        }


        public static Practice_Doctors_Model Get_Practice_for_PracticeID(Practice_Doctors_Model parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "user";
            Practice_Doctors_Model modelPD = new Practice_Doctors_Model();
            // List<Practice_Doctors_Model> modelForSendL = new List<Practice_Doctors_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var query = new QueryBuilder<Practice_Doctors_Model>()
                        .From(0)
                            .Size(1000).Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Term(t => t.Field(type => type.type)
                                .Value("practice"))
                                    .Term(term2 => term2.Field(id => id.id)
                                        .Value(parameter.id)))))));

                queryS = query.BuildBeautified();

                string search_doctor_for_DoctorID = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(search_doctor_for_DoctorID, queryS);

                modelPD = serializer.ToSearchResult<Practice_Doctors_Model>(result).Documents.FirstOrDefault();
            }
            return modelPD;
        }

        public static long Get_Doctors_Count(string practice_id, SessionSecurityTicket securityTicket)
        {
            var query = new QueryBuilder<Practice_Doctors_Model>()
                    .Query(q => q
                     .Bool(b => b
                              .Must(must => must.Terms(t => t.Field(f1 => f1.type).Values("doctor").MinimumMatch(1))
                                 .Terms(t1 => t1.Field(f => f.practice_for_doctor_id).Values(practice_id).MinimumMatch(1))
                     )));

            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            var result = serializer.ToCountResult(connection.Post(Commands.Count(securityTicket.TenantID.ToString(), "user"), query.BuildBeautified()).Result);

            return result.count;
        }
    }
}
