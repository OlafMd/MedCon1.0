
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMDocConnectElasticSearchMethods.Models;
using CSV2Core.SessionSecurity;
using PlainElastic.Net.Queries;
using System;
using PlainElastic.Net.Serialization;
using PlainElastic.Net;
using PlainElastic.Net.Builders;
using MMDocConnectElasticSearchMethods.Patient.Retrieval;
using System.Globalization;
using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Oct.Entity;

namespace MMDocConnectElasticSearchMethods.Patient.Manipulation
{
    public class Retrieve_Patients
    {
        private static string elasticType = "patient";

        public static List<Patient_Model> Get_Patients_for_Autocomplete(string search_criteria, Guid practice_id, string connectionString, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            List<Patient_Model> modelForSendL = new List<Patient_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var query = new QueryBuilder<Patient_Model>()
                  .Query(q => q
                      .Filtered(f => f.Filter(r => r.Missing(m => m.Field("originating_practice_id")))
                      .Query(q1 => q1
                          .Bool(b => b
                              .Should(sh => sh
                                  .Match(m => m
                                      .Field("name_with_birthdate")
                                      .Query(search_criteria.Replace('.', '-').ToLower()).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                  .Match(m => m
                                      .Field("insurance_id")
                                      .Query(search_criteria.ToLower()).Operator(PlainElastic.Net.Operator.AND)
                                    )
                                ).MinimumNumberShouldMatch(1)
                              .Must(ma => ma.Match(m => m.Field("practice_id").Query(practice_id.ToString())))
                          )
                      )))
                      .Sort(s => s.Field("name.lower_case_sort", PlainElastic.Net.SortDirection.asc)).From(0)
                      .Size(int.MaxValue);

                queryS = query.BuildBeautified();
                string searchCommand_Doc_Practices = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Doc_Practices, queryS);

                var foundResults_Patients = serializer.ToSearchResult<Patient_Model>(result);

                return foundResults_Patients.Documents.Select(item =>
                {
                    Patient_Model modelP = new Patient_Model();
                    modelP.name_with_birthdate = item.name_with_birthdate;
                    modelP.id = item.id;

                    return modelP;
                }).ToList();
            }

            return modelForSendL;
        }

        public static List<PatientModelFront> Get_Patients_On_Tenant(ElasticParameterObject Parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                string sort_by_second_key = "name";
                string sort_by_third_key = "name";
                var sortBY = Parameter.sort_by;
                switch (Parameter.sort_by)
                {
                    case "name":
                        sort_by_second_key = "name";
                        sort_by_third_key = "birthday";
                        break;
                    case "participation_consent":
                        Parameter.sort_by = "name";
                        sort_by_second_key = "birthday";
                        sort_by_third_key = "name";
                        break;
                    case "last_first_op_doctor_name":
                        sort_by_second_key = "name";
                        sort_by_third_key = "name";
                        break;
                    case "last_first_ac_doctor_name":
                        sort_by_second_key = "name";
                        sort_by_third_key = "name";
                        break;
                    default:
                        sort_by_second_key = "name";
                        sort_by_third_key = "birthday";
                        break;
                }

                var query = QueryBuilderPatients.BuildGetPatientsSearchAsYouTypeQueryTenant(Parameter.start_row_index, 100, Parameter.sort_by, Parameter.isAsc, Parameter.search_params, sort_by_second_key, sort_by_third_key);

                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                var foundResults = serializer.ToSearchResult<Patient_Model>(result);
                return foundResults.Documents.Select(item =>
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
                    var patient = new PatientModelFront();

                    patient.birthday_string = item.birthday_string;
                    patient.birthday = DateTime.Parse(item.birthday_string, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    patient.health_insurance_provider = item.health_insurance_provider;
                    patient.id = item.id;
                    patient.insurance_id = item.insurance_id;
                    patient.insurance_status = item.insurance_status;
                    patient.name = item.name;
                    patient.sex = item.sex;
                    patient.last_first_ac_doctor_name = item.last_first_ac_doctor_name;
                    patient.last_first_op_doctor_name = item.last_first_op_doctor_name;
                    patient.ac_practice = item.ac_practice;
                    patient.practice = item.practice;

                    if (!item.has_participation_consent)
                        patient.participation_consent_status = "/";
                    else
                    {
                        var todaysDate = DateTime.Now.Date;
                        int startCompare = item.participation_consent_from.Date.CompareTo(todaysDate);
                        int endCompare = item.participation_consent_to == DateTime.MinValue ? 1 : item.participation_consent_to.Date.CompareTo(todaysDate);

                        if (startCompare <= 0 && endCompare >= 0)
                            patient.participation_consent_status = "aktualisiert";
                        else
                            patient.participation_consent_status = "abgelaufen";

                    }

                    switch (sortBY)
                    {
                        case "name":
                            patient.group_name = string.IsNullOrEmpty(item.name) ? "-" : item.name.Substring(0, 1).ToUpper();
                            break;
                        case "sex":
                            patient.group_name = string.IsNullOrEmpty(item.sex) ? "-" : item.sex;
                            break;
                        case "health_insurance_provider":
                            patient.group_name = string.IsNullOrEmpty(item.health_insurance_provider) ? "-" : item.health_insurance_provider;
                            break;
                        case "last_first_op_doctor_name":
                            patient.group_name = string.IsNullOrEmpty(item.last_first_op_doctor_name) ? "-" : item.last_first_op_doctor_name;
                            break;
                        case "last_first_ac_doctor_name":
                            patient.group_name = string.IsNullOrEmpty(item.last_first_ac_doctor_name) ? "-" : item.last_first_ac_doctor_name;
                            break;
                        case "participation_consent":
                            patient.group_name = string.IsNullOrEmpty(patient.participation_consent_status) ? "-" : patient.participation_consent_status;
                            break;
                    }

                    return patient;
                }).ToList();
            }

            return new List<PatientModelFront>();
        }


        public static List<PatientModelFront> Get_PatientsList(ElasticParameterObject Parameter, string practice_id, IEnumerable<Guid> patientsIdsWithInvalidConsent, SessionSecurityTicket securityTicket)
        {
            List<PatientModelFront> patientList = new List<PatientModelFront>();
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                string sort_by_second_key = "name";
                string sort_by_third_key = "name";

                switch (Parameter.sort_by)
                {
                    case "name":
                        sort_by_second_key = "name";
                        sort_by_third_key = "birthday";
                        break;
                    case "participation_consent":
                        Parameter.sort_by = "name";
                        sort_by_second_key = "name";
                        sort_by_third_key = "birthday";
                        break;
                }

                string query = String.Empty;
                var hip_name = !String.IsNullOrEmpty(Parameter.hip_name) ? Parameter.hip_name.ToLower() : null;

                if (Parameter.page_size == 0)
                {
                    Parameter.page_size = 100;
                }

                var patient_ids_with_invalid_consent_array = Parameter.invalid_consent && patientsIdsWithInvalidConsent.Any() ? Array.ConvertAll(patientsIdsWithInvalidConsent.ToArray(), x => x.ToString()) : null;
                query = QueryBuilderPatients.BuildGetPatientsSearchAsYouTypeQuery(Parameter, Parameter.sort_by, practice_id, sort_by_second_key, sort_by_third_key, hip_name, patient_ids_with_invalid_consent_array);

                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                var foundResults = serializer.ToSearchResult<Patient_Model>(result);
                foreach (var item in foundResults.Documents)
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
                    PatientModelFront patient = new PatientModelFront();
                    patient.birthday_string = item.birthday_string;
                    patient.birthday = DateTime.Parse(item.birthday_string, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    patient.health_insurance_provider = item.health_insurance_provider;
                    patient.id = item.id;
                    patient.insurance_id = item.insurance_id;
                    patient.insurance_status = item.insurance_status;
                    patient.name = item.name;
                    patient.sex = item.sex;
                    patient.has_rejected_oct = item.has_rejected_oct;
                    patient.originating_patient_id = item.originating_patient_id;
                    patient.originating_practice_id = item.originating_practice_id;
                    patient.originating_practice_name = item.originating_practice_name;
                    patient.external_id = item.external_id;

                    switch (Parameter.sort_by)
                    {
                        case "name":
                            patient.group_name = string.IsNullOrEmpty(item.name) ? "-" : item.name.Substring(0, 1).ToUpper();
                            break;
                        case "sex":
                            patient.group_name = string.IsNullOrEmpty(item.sex) ? "-" : item.sex;
                            break;
                        case "health_insurance_provider":
                            patient.group_name = string.IsNullOrEmpty(item.health_insurance_provider) ? "-" : item.health_insurance_provider;
                            break;
                    }
                    patientList.Add(patient);

                }
            }

            return patientList;
        }

        public static Patient_Model Get_Patient_for_PatientID(string patient_id, SessionSecurityTicket securityTicket)
        {
            Patient_Model patient = new Patient_Model();
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            string query = QueryBuilderPatients.BuildGetPatientQuery(patient_id);

            string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
            string result = connection.Post(searchCommand, query);

            var foundResults = serializer.ToSearchResult<Patient_Model>(result);

            foreach (var item in foundResults.Documents)
            {
                patient = item;
            }
            return patient;
        }

        public static List<PatientDetailViewModelExtended> Get_PatientDetailList(ElasticParameterObject Parameter, string patient_id, IEnumerable<string> case_ids, IEnumerable<string> doctor_ids, 
            IEnumerable<string> other_case_ids, List<DateTime> min_fee_waiver_dates, string practice_id, List<string> consent_ids, List<OctHipParameter> octRangeParameters, List<AftercareHipParameter> acRangeParameters, SessionSecurityTicket securityTicket)
        {
            List<PatientDetailViewModelExtended> patientDetailList = new List<PatientDetailViewModelExtended>();
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient_details";

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                string sort_by_second_key = "detail_type";

                switch (Parameter.sort_by)
                {
                    case "date":
                        sort_by_second_key = "detail_type";
                        break;
                    case "detail_type":
                        sort_by_second_key = "date";
                        break;
                    case "localisation":
                        sort_by_second_key = "date";
                        break;
                    case "status":
                        sort_by_second_key = "date";
                        break;
                }

                string query = String.Empty;
                query = QueryBuilderPatients.BuildGetPatientDetailsQuery(Parameter.start_row_index, 100, Parameter.sort_by, Parameter.isAsc, patient_id, 
                    sort_by_second_key, case_ids, doctor_ids, other_case_ids, min_fee_waiver_dates, practice_id, consent_ids, octRangeParameters, acRangeParameters);

                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                var foundResults = serializer.ToSearchResult<PatientDetailViewModelExtended>(result);
                patientDetailList = foundResults.Documents.Select(item =>
                {
                    var lcid = "de";
                    switch (Parameter.sort_by)
                    {
                        case "date":
                            item.group_name = string.IsNullOrEmpty(item.date_string) ? "-" : (new CultureInfo(lcid)).DateTimeFormat.GetMonthName(item.date.Month).ToUpper() + " " + item.date.Year;
                            break;
                        case "detail_type":
                            item.group_name = string.IsNullOrEmpty(item.detail_type) ? "-" : item.detail_type;
                            break;
                        case "status":
                            item.group_name = string.IsNullOrEmpty(item.status) ? "-" : item.status;
                            break;
                        case "localisation":
                            item.group_name = string.IsNullOrEmpty(item.localisation) ? "-" : item.localisation;
                            break;
                    }
                    item.date_string = item.date.ToString("dd.MM.yyyy");

                    return item;
                }).ToList();
            }

            return patientDetailList;
        }

        public static IEnumerable<PatientDetailViewModel> GetPatientDetailsListForDetailTypeAndPatientID(string detail_type, string patient_id, SessionSecurityTicket securityTicket)
        {
            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient_details";

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                return serializer.ToSearchResult<PatientDetailViewModel>(connection.Post(Commands.Search(TenantID, elasticType).Pretty(), QueryBuilderPatients.BuildGetPatientDetailsListForDetailTypeAndPatientID(detail_type, patient_id))).Documents;
            }

            return patientDetailList;
        }

        public static IEnumerable<PatientDetailViewModel> GetPatientDetailsListForContractID(string contract_id, SessionSecurityTicket securityTicket)
        {
            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient_details";

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                return serializer.ToSearchResult<PatientDetailViewModel>(connection.Post(Commands.Search(TenantID, elasticType).Pretty(), QueryBuilderPatients.BuildGetPatientDetailsForContractIDQuery(contract_id))).Documents;
            }

            return patientDetailList;
        }

        public static List<PatientDetailViewModelExtended> Get_PatientDetailListTenant(ElasticParameterObject Parameter, string patient_id, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient_details";

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                string sort_by_second_key = "detail_type";

                switch (Parameter.sort_by)
                {
                    case "date":
                        sort_by_second_key = "detail_type";
                        break;
                    case "detail_type":
                        sort_by_second_key = "date";
                        break;
                    case "localisation":
                        sort_by_second_key = "date";
                        break;
                    case "status":
                        sort_by_second_key = "date";
                        break;
                }

                string query = String.Empty;
                query = QueryBuilderPatients.BuildGetPatientDetailsQueryTenant(Parameter.start_row_index, 100, Parameter.sort_by, Parameter.isAsc, patient_id, sort_by_second_key);

                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                var foundResults = serializer.ToSearchResult<PatientDetailViewModelExtended>(result);
                return foundResults.Documents.Select(item =>
                {
                    var lcid = "de";
                    switch (Parameter.sort_by)
                    {
                        case "date":
                            item.group_name = string.IsNullOrEmpty(item.date_string) ? "-" : (new CultureInfo(lcid)).DateTimeFormat.GetMonthName(item.date.Month).ToUpper() + " " + item.date.Year;
                            break;
                        case "detail_type":
                            item.group_name = string.IsNullOrEmpty(item.detail_type) ? "-" : item.detail_type;
                            break;
                        case "status":
                            item.group_name = string.IsNullOrEmpty(item.status) ? "-" : item.status;
                            break;
                        case "localisation":
                            item.group_name = string.IsNullOrEmpty(item.localisation) ? "-" : item.localisation;
                            break;
                    }

                    return item;
                }).ToList();
            }

            return new List<PatientDetailViewModelExtended>();
        }

        public static PatientDetailViewModel Get_PatientDetaiForID(string id, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var elasticType = "patient_details";

            var query = QueryBuilderPatients.BuildGetPatientDetailQuery(id);

            var searchCommand = Commands.Search(TenantID, elasticType).Pretty();
            var result = connection.Post(searchCommand, query);

            var foundResults = serializer.ToSearchResult<PatientDetailViewModel>(result);

            return foundResults.Documents.SingleOrDefault();
        }

        public static IEnumerable<PatientDetailViewModel> Get_PatientDetailsWhereFieldsHaveValues(List<FieldValueParameter> parameters, string practice_id, string index_name)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            var elasticType = "patient_details";

            var searchCommand = Commands.Search(index_name, elasticType).Pretty();
            var query = QueryBuilderPatients.BuildGetPatientDetailsWhereFieldsHaveValuesQuery(parameters, practice_id);
            var result = connection.Post(searchCommand, query);

            return serializer.ToSearchResult<PatientDetailViewModel>(result).Documents;
        }

        /// <summary>
        /// Retrives participation consent(s) from Elastic by their status and patientId.
        /// <para>securityTicket represents the index, elastic type is "patient_details"</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="securityTicket"></param>
        /// <returns></returns>
        public static PatientDetailViewModel Get_PatientDetailByParticipationConsentStatus(string id, string status, SessionSecurityTicket securityTicket)
        {
            PatientDetailViewModel detail = new PatientDetailViewModel();
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient_details";

            string query = QueryBuilderPatients.BuildGetPatientDetailQuery_ByParticipationStatus(id, status);

            string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
            string result = connection.Post(searchCommand, query);

            var foundResults = serializer.ToSearchResult<PatientDetailViewModel>(result);

            return foundResults.Documents.SingleOrDefault();
        }
        /// <summary>
        /// Delete patient details entry on elastic
        /// </summary>
        /// <param name="id"></param>
        /// <param name="securityTicket"></param>
        public static void Delete_PatientDetail(string id, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient_details";
            if (!string.IsNullOrEmpty(id))
            {
                var command = Commands.Delete(TenantID, elasticType, id);
                connection.Delete(command);
            }
        }

        public static List<PatientDetailViewModel> Get_PatientDetaiForIDandOrderID(string orderID, SessionSecurityTicket securityTicket)
        {
            List<PatientDetailViewModel> detailsList = new List<PatientDetailViewModel>();
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient_details";

            string query = QueryBuilderPatients.BuildGetPatientDetailQueryAndOrderID(orderID);

            string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
            string result = connection.Post(searchCommand, query);

            var foundResults = serializer.ToSearchResult<PatientDetailViewModel>(result);

            return foundResults.Documents.ToList();
        }

        public static IEnumerable<Patient_Model> GetPatientsWhereIDPresent(string id, string ordinal, string tenant_id)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elasticType, connection))
            {
                query = QueryBuilderPatients.BuildGetPatientsWhereIDPresentQuery(id, ordinal);

                string searchCommand_Cases = Commands.Search(tenant_id, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<Patient_Model>(result).Documents;
            }

            return new List<Patient_Model>();
        }

        public static IEnumerable<Patient_Model> GetPatientsWhereFieldsPresent(string tenant_id, List<KeyValuePair<string, string>> parameters)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elasticType, connection))
            {
                query = QueryBuilderPatients.BuildGetPatientsWhereFieldsPresentQuery(parameters);

                string searchCommand_Cases = Commands.Search(tenant_id, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<Patient_Model>(result).Documents;
            }

            return new List<Patient_Model>();
        }


        public static IEnumerable<PatientDetailViewModel> GetPatientDetailsWhereIDPresent(string id, string ordinal, string tenant_id)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;
            var elastic_type = "patient_details";

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elastic_type, connection))
            {
                query = QueryBuilderPatients.BuildGetPatientDetailsWhereIDPresentQuery(id, ordinal);

                string searchCommand_Cases = Commands.Search(tenant_id, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<PatientDetailViewModel>(result).Documents;
            }

            return new List<PatientDetailViewModel>();
        }

        public static IEnumerable<PatientDetailViewModel> GetPatientDetailsForIdAndOrdinal(string id, string ordinal, string tenant_id)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;
            var elastic_type = "patient_details";

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elastic_type, connection))
            {
                query = QueryBuilderPatients.BuildGetPatientDetailsForIdAndOrdinal(id, ordinal);

                string searchCommand_Cases = Commands.Search(tenant_id, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<PatientDetailViewModel>(result).Documents;
            }

            return new List<PatientDetailViewModel>();
        }

    }
}
