using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_BIL;
using CL1_CMN_BPT_CTM;
using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_ACT;
using CL1_HEC_BIL;
using CL1_HEC_CAS;
using CL1_USR;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Archive.Atomic.Retrieval;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.Order.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.DBMethods.Pharmacy.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Retrieval;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectElasticSearchMethods.Receipt.Retrieval;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_Methods.Doctor.Manipulation
{
    public static class RebuildElastic
    {
        public static List<Case_Model> RebuildPlanning(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();

            var Transaction = Connection.BeginTransaction();
            try
            {
                List<Case_Model> cases = new List<Case_Model>();
                var doctorsCache = cls_Get_Doctor_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
                var practiceCache = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PracticeBptID).ToDictionary(t => t.Key, t => t.Single());
                var orderStatusCache = cls_Get_Order_Status_History_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.header_id).ToDictionary(t => t.Key, t => t);
                var fsStatusCache = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var all_cases = cls_Get_All_Cases_from_DB_for_ElasticRebuild.Invoke(Connection, Transaction, securityTicket).Result.Where(c => !c.is_treatment_performed && !fsStatusCache.Any(t => t.case_id == c.case_id && t.gpos_type == EGposType.Operation.Value())).ToList();
                var patientCache = cls_Get_Patient_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());
                var aftercares = cls_Get_RelevantActionData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result
                    .Where(r => r.ActionTypeGpmID == EActionType.PlannedAftercare.Value() && !r.IsDeleted)
                    .GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.ToList());

                int i = 1;
                foreach (var _case in all_cases)
                {
                    var is_orders_drug = _case.order_header_id != Guid.Empty;
                    var case_model_elastic = new Case_Model();
                    case_model_elastic.aftercare_name = "-";

                    if (aftercares.ContainsKey(_case.case_id))
                    {
                        var case_aftercare = aftercares[_case.case_id].Last();

                        if (doctorsCache.ContainsKey(case_aftercare.ToBePerformedBy_BusinessParticipant_RefID))
                        {
                            var acDoctor = doctorsCache[case_aftercare.ToBePerformedBy_BusinessParticipant_RefID];
                            case_model_elastic.is_aftercare_doctor = true;
                            case_model_elastic.aftercare_name = GenericUtils.GetDoctorNamePascal(acDoctor);
                            case_model_elastic.aftercare_doctors_practice_name = acDoctor.PracticeName;
                            case_model_elastic.aftercare_doctor_practice_id = acDoctor.DoctorID.ToString();
                            case_model_elastic.aftercare_doctor_lanr = acDoctor.DoctorLANR;

                            if (practiceCache.ContainsKey(acDoctor.PracticeBPTID))
                            {
                                case_model_elastic.aftercare_doctors_practice_id = practiceCache[acDoctor.PracticeBPTID].PracticeID.ToString();
                            }
                        }
                        else if (practiceCache.ContainsKey(case_aftercare.ToBePerformedBy_BusinessParticipant_RefID))
                        {
                            var practice = practiceCache[case_aftercare.ToBePerformedBy_BusinessParticipant_RefID];
                            case_model_elastic.aftercare_name = practice.PracticeName;
                            case_model_elastic.aftercare_doctor_practice_id = practice.PracticeID.ToString();
                            case_model_elastic.aftercare_doctor_lanr = practice.PracticeBSNR;
                        }
                    }

                    //TODO: Check delviery and treatment date
                    case_model_elastic.delivery_time_from = _case.order_delivery_time_from;
                    case_model_elastic.delivery_time_string = _case.order_delivery_date.ToString("dd.MM.yyyy");
                    case_model_elastic.delivery_time_to = _case.order_delivery_time_to;
                    case_model_elastic.diagnose = _case.diagnose_name == null ? "" : _case.diagnose_name;
                    case_model_elastic.diagnose_id = _case.diagnose_id == Guid.Empty ? "" : _case.diagnose_id.ToString();
                    case_model_elastic.drug = _case.drug_name;
                    case_model_elastic.drug_id = _case.hec_drug_id.ToString();
                    case_model_elastic.id = _case.case_id.ToString();
                    case_model_elastic.is_orders_drug = is_orders_drug;
                    case_model_elastic.localization = _case.localization == null ? "-" : _case.localization;
                    case_model_elastic.order_modification_timestamp = _case.order_modification_timestamp;
                    case_model_elastic.order_modification_timestamp_string = _case.order_modification_timestamp.ToString("dd.MM.yyyy");

                    if (patientCache.ContainsKey(_case.patient_id))
                    {
                        var patient = patientCache[_case.patient_id];

                        case_model_elastic.patient_birthdate = patient.birthday;
                        case_model_elastic.patient_birthdate_string = patient.birthday.ToString("dd.MM.yyyy");
                        case_model_elastic.patient_hip = patient.health_insurance_provider;
                        case_model_elastic.patient_insurance_number = patient.insurance_id;
                        case_model_elastic.patient_id = _case.patient_id.ToString();
                        case_model_elastic.patient_name = patient.patient_last_name + ", " + patient.patient_first_name;
                    }

                    case_model_elastic.practice_id = _case.practice_id.ToString();
                    case_model_elastic.previous_status_drug_order = "";
                    case_model_elastic.status_drug_order = "";
                    if (is_orders_drug)
                    {
                        var order_status_history = orderStatusCache[_case.order_header_id].ToList();
                        if (order_status_history.First().order_status_code == 6)
                        {
                            case_model_elastic.previous_status_drug_order = "MO" + order_status_history[1].order_status_code;
                        }
                        else if (order_status_history.First().order_status_code == 7)
                        {
                            case_model_elastic.previous_status_drug_order = "MO" + order_status_history[2].order_status_code;
                        }
                        else
                        {
                            case_model_elastic.previous_status_drug_order = "";
                        }
                        var status = "MO" + order_status_history.First().order_status_code;
                        case_model_elastic.status_drug_order = status == "MO7" ? "MO6" : status;
                    }

                    case_model_elastic.status_treatment = _case.diagnose_name == null ? "" : _case.is_treatment_cancelled ? "OP4" : _case.treatment_date < DateTime.Now.Date ? "OP1" : "OP1";
                    case_model_elastic.treatment_date = _case.treatment_date;
                    case_model_elastic.treatment_date_day_month = _case.treatment_date.ToString("dd.MM");
                    case_model_elastic.treatment_date_month_year = _case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                    case_model_elastic.treatment_doctor_id = _case.treatment_doctor_id != Guid.Empty ? _case.treatment_doctor_id.ToString() : "";
                    case_model_elastic.treatment_doctor_lanr = _case.treatment_doctor_lanr == null ? "" : _case.treatment_doctor_lanr;
                    case_model_elastic.treatment_doctor_name = _case.treatment_doctor_name == null ? "-" : _case.treatment_doctor_name;

                    cases.Add(case_model_elastic);

                    Console.Write("\rCase {0} of {1} updated.                ", i++, all_cases.Count);

                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return cases;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Planning section elastic rebuild", ex);
            }
        }

        public static List<Aftercare_Model> RebuildAftercare(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();

            var Transaction = Connection.BeginTransaction();
            try
            {
                var acPlannedActionTypeGpmId = EActionType.PlannedAftercare.Value();
                var acPlannedActionType = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, new ORM_HEC_ACT_ActionType.Query()
                {
                    GlobalPropertyMatchingID = acPlannedActionTypeGpmId,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (acPlannedActionType == null)
                {
                    acPlannedActionType = new ORM_HEC_ACT_ActionType();
                    acPlannedActionType.GlobalPropertyMatchingID = acPlannedActionTypeGpmId;
                    acPlannedActionType.Modification_Timestamp = DateTime.Now;
                    acPlannedActionType.Tenant_RefID = securityTicket.TenantID;

                    acPlannedActionType.Save(Connection, Transaction);
                }

                var fake_op_properties = cls_Get_CaseProperties_for_PropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPfPGpmID_0821()
                {
                    PropertyGpmID = "mm.doc.connect.case.treatment.year.fake"
                }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());

                var documentation_properties = cls_Get_CaseProperties_for_PropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPfPGpmID_0821()
                {
                    PropertyGpmID = ECaseProperty.DocumentationOnly.Value()
                }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.Single());

                var all_cases = cls_Get_All_Cases_from_DB_for_ElasticRebuild.Invoke(Connection, Transaction, securityTicket).Result.Where(t =>
                {
                    var is_fake = fake_op_properties.Keys.Any(x => x == t.case_id);
                    var is_documentation = documentation_properties.ContainsKey(t.case_id) && documentation_properties[t.case_id].Value_Boolean;

                    return t.is_treatment_performed && !is_fake && !is_documentation;
                }).ToList();

                var patient_cache = cls_Get_Patient_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());
                var all_practices = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var practices_grouped_by_bpt = new Dictionary<Guid, DO_GPDoT_1735>();
                var practices_grouped_by_id = new Dictionary<Guid, DO_GPDoT_1735>();
                var doctors_cache = cls_Get_Doctor_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
                var accounts = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).GroupBy(t => t.BusinessParticipant_RefID).ToDictionary(t => t.Key, t => t.Single().USR_AccountID);

                foreach (var practice in all_practices)
                {
                    if (!practices_grouped_by_id.ContainsKey(practice.PracticeID))
                    {
                        practices_grouped_by_id.Add(practice.PracticeID, practice);
                    }

                    if (!practices_grouped_by_bpt.ContainsKey(practice.PracticeBptID))
                    {
                        practices_grouped_by_bpt.Add(practice.PracticeBptID, practice);
                    }
                }

                var days_for_aftercare = cls_Get_Days_for_Aftercare_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.Single().days);
                var aftercare_diagnose_cache = cls_Get_Aftercare_Diagnose_Details_for_AftercarePlannedActionID.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.action_id).ToDictionary(t => t.Key, t => t.SingleOrDefault());
                var all_cancelled_aftercares = cls_Get_All_Cancelled_AftercareActionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GACAAIDsfCID_0008()
                {
                    AftercarePlannedActionTypeID = acPlannedActionType.HEC_ACT_ActionTypeID
                }, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

                var aftercares = new List<Aftercare_Model>();
                int i = 1;
                foreach (var _case in all_cases)
                {
                    if (!all_cancelled_aftercares.ContainsKey(_case.case_id))
                    {
                        continue;
                    }

                    try
                    {
                        if (!days_for_aftercare.ContainsKey(_case.patient_id))
                        {
                            continue;
                        }

                        var days = days_for_aftercare[_case.patient_id];

                        var cancelled_aftercares = all_cancelled_aftercares[_case.case_id];
                        foreach (var cancelled_aftercare in cancelled_aftercares)
                        {
                            var is_aftercare_doctor = false;
                            var aftercare_bpt_id = cancelled_aftercare.aftercare_bpt != Guid.Empty ? cancelled_aftercare.aftercare_bpt : _case.aftercare_bpt;
                            DO_GDDoT_1735 aftercare_doctor = null;
                            DO_GPDoT_1735 aftercare_practice = new DO_GPDoT_1735();     

                            if (aftercare_bpt_id != Guid.Empty)
                            {
                                if (doctors_cache.ContainsKey(aftercare_bpt_id))
                                {
                                    is_aftercare_doctor = true;
                                    aftercare_doctor = doctors_cache[aftercare_bpt_id];
                                }
                                else if (practices_grouped_by_bpt.ContainsKey(aftercare_bpt_id))
                                {
                                    aftercare_practice = practices_grouped_by_bpt[aftercare_bpt_id];
                                }
                                else
                                {
                                    aftercare_practice.PracticeName = "??? - o?-b";
                                }
                            }


                            #region IMPORT AFTERCARE TO ELASTIC

                            var patient_details = patient_cache[_case.patient_id];
                            var treatment_practice = practices_grouped_by_id[_case.practice_id];
                            var diagnose_details = aftercare_diagnose_cache.ContainsKey(cancelled_aftercare.aftercare_planned_action_id) ? aftercare_diagnose_cache[cancelled_aftercare.aftercare_planned_action_id] : null;

                            var aftercare = new Aftercare_Model();
                            aftercare.aftercare_doctor_name = is_aftercare_doctor ? GenericUtils.GetDoctorNamePascal(aftercare_doctor) : aftercare_practice.PracticeName;
                            aftercare.diagnose = diagnose_details != null ? diagnose_details.diagnose_name : _case.diagnose_name;
                            aftercare.id = cancelled_aftercare.aftercare_planned_action_id.ToString();
                            aftercare.localization = diagnose_details != null ? diagnose_details.localization : _case.localization;
                            aftercare.patient_birthdate = patient_details.birthday;
                            aftercare.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
                            aftercare.patient_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
                            aftercare.treatment_doctors_practice_id = _case.practice_id.ToString();
                            aftercare.status = cancelled_aftercare.is_aftercare_cancelled ? "AC4" : DateTime.Now.Date > _case.treatment_date.AddDays(days) ? "AC1" : "AC1";
                            aftercare.treatment_date = _case.treatment_date;
                            aftercare.treatment_date_day_month = _case.treatment_date.ToString("dd.MM.");
                            aftercare.treatment_date_month_year = _case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                            aftercare.treatment_doctor_name = _case.treatment_doctor_name;
                            aftercare.treatment_doctor_practice_name = treatment_practice.PracticeName;
                            aftercare.case_id = _case.case_id.ToString();
                            aftercare.hip = patient_details.health_insurance_provider;
                            aftercare.hip_ik_number = patient_details.HealthInsurance_IKNumber;
                            aftercare.patient_insurance_number = patient_details.insurance_id;
                            aftercare.op_lanr = _case.treatment_doctor_lanr;
                            aftercare.bsnr = treatment_practice.PracticeBSNR;
                            aftercare.aftercare_doctor_practice_id = is_aftercare_doctor ? aftercare_doctor.DoctorID.ToString() : aftercare_practice.PracticeID.ToString();
                            aftercare.treatment_doctor_id = _case.treatment_doctor_id.ToString();
                            aftercare.diagnose_id = diagnose_details != null ? diagnose_details.diagnose_id.ToString() : _case.diagnose_id.ToString();
                            aftercare.drug_id = _case.hec_drug_id.ToString();
                            aftercare.patient_id = _case.patient_id.ToString();
                            if (accounts.ContainsKey(aftercare_bpt_id))
                            {
                                aftercare.aftercare_doctor_account_id = accounts[aftercare_bpt_id].ToString();
                            }

                            if (is_aftercare_doctor)
                            {
                                aftercare.practice_id = aftercare_doctor.PracticeId.ToString();
                                aftercare.ac_lanr = aftercare_doctor.DoctorLANR;
                            }
                            else
                            {
                                aftercare.practice_id = aftercare_practice.PracticeID.ToString();
                            }

                            aftercares.Add(aftercare);

                            #endregion IMPORT AFTERCARE TO ELASTIC

                        }
                        if (i == 709)
                            System.Diagnostics.Debugger.Launch();

                        Console.Write("\rCase {0} of {1} updated.                ", i++, all_cases.Count);

                    }
                    catch (Exception inner)
                    {
                        throw new Exception("Something went wrong, case number: " + _case.case_number, inner);
                    }
                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return aftercares;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Aftercare section elastic rebuild", ex);
            }
        }

        public static List<Settlement_Model> RebuildSettlement(string connectionString, SessionSecurityTicket securityTicket, DbConnection Connection = null, DbTransaction Transaction = null)
        {
            var handleConnection = Connection == null;
            var handleTransaction = Transaction == null;

            if (handleConnection)
            {
                Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                Connection.Open();
            }

            if (handleTransaction)
            {
                Transaction = Connection.BeginTransaction();
            }

            try
            {
                var gposAssignmentsCountCache = cls_Get_Number_of_GposTypes_on_Case_for_CaseID_and_GposType.Invoke(Connection, Transaction, new P_CAS_GNoGPOSToCfCIDaGPOST_1023()
                {
                    GposType = "mm.docconnect.gpos.catalog.operation"
                }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.Single().NumberOfTreatmentGposes);

                var existingSettlementDownloadStatuses = new Dictionary<string, bool>();
                var elasticConnection = Elastic_Utils.ElsaticConnection();
                if (Elastic_Utils.IfIndexOrTypeExists(String.Format("{0}/{1}", securityTicket.TenantID.ToString(), "settlement"), elasticConnection))
                {
                    var serializer = new JsonNetSerializer();
                    var command = Commands.Search(securityTicket.TenantID.ToString(), "settlement").Pretty();
                    var query = new QueryBuilder<Settlement_Model>().Size(int.MaxValue).BuildBeautified();
                    var result = elasticConnection.Post(command, query);
                    existingSettlementDownloadStatuses = serializer.ToSearchResult<Settlement_Model>(result).Documents.Where(t => t.id != null).GroupBy(t => t.id, t => t.is_report_downloaded).ToDictionary(t => t.Key, t => t.Single());
                }

                var all_cases = cls_Get_All_Cases_from_DB_for_ElasticRebuild.Invoke(Connection, Transaction, securityTicket).Result;
                var settlements = new List<Settlement_Model>();
                var doctors_cache = cls_Get_Doctor_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
                var all_planned_actions = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
                var patient_cache = cls_Get_Patient_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());
                var relevantActionsCache = cls_Get_RelevantActionData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var patientActionCache = relevantActionsCache.Where(t => t.ActionTypeGpmID == EActionType.PlannedOct.Value()).GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.Localization).ToDictionary(x => x.Key, x => x.ToList()));
                var aftercares = relevantActionsCache.Where(t => t.ActionTypeGpmID == EActionType.PlannedAftercare.Value()).GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.Last());
                var relevantActionCache = relevantActionsCache.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.ActionTypeGpmID).ToDictionary(x => x.Key, x => x.ToList()));
                var reportDownloadedCache = cls_Get_Report_Downloaded_PropertyValues_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var all_practices = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var practices_grouped_by_bpt = all_practices.GroupBy(t => t.PracticeBptID).ToDictionary(t => t.Key, t => t.Single());
                var performed_action_data = cls_Get_PerformedActionData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.ActionID).ToDictionary(t => t.Key, t => t.Single());
                var diagnose_cache = cls_Get_Diagnose_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.diagnose_id).ToDictionary(t => t.Key, t => t.Single());
                var all_case_fs_statuses = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var case_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());
                var patient_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));

                var previous_status_cache = cls_Get_Previous_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t);
                var fake_op_properties = cls_Get_CaseProperties_for_PropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPfPGpmID_0821()
                {
                    PropertyGpmID = "mm.doc.connect.case.treatment.year.fake"
                }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());

                int i = 1;

                all_cases = all_cases.Where(t => case_fs_status_cache.ContainsKey(t.case_id) && !fake_op_properties.ContainsKey(t.case_id)).ToArray();
                for (var j = 0; j < all_cases.Length; j++)
                {
                    var _case = all_cases[j];
                    var case_fs_statuses = case_fs_status_cache[_case.case_id];
                    var ac_op_billed_together = gposAssignmentsCountCache.ContainsKey(_case.case_id) ? gposAssignmentsCountCache[_case.case_id] > 1 : false;

                    var filtered_treatment_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 230).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == "mm.docconnect.gpos.catalog.operation").ToList();
                    var filtered_aftercare_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 60).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == "mm.docconnect.gpos.catalog.nachsorge").ToList();

                    if (!patient_cache.ContainsKey(_case.patient_id))
                    {
                        continue;
                    }

                    var patient_details = patient_cache[_case.patient_id];

                    #region OP

                    foreach (var fs_status in filtered_treatment_statuses)
                    {
                        var settlement = new Settlement_Model();

                        #region Aftercare
                        var aftercare_bpt = aftercares.ContainsKey(_case.case_id) ? aftercares[_case.case_id].ToBePerformedBy_BusinessParticipant_RefID : Guid.Empty;
                        if (aftercare_bpt != Guid.Empty)
                        {
                            if (doctors_cache.ContainsKey(aftercare_bpt))
                            {
                                var aftercare_doctor = doctors_cache[aftercare_bpt];
                                settlement.aftercare_doctor_practice_id = aftercare_doctor.DoctorID.ToString();

                                if (practices_grouped_by_bpt.ContainsKey(aftercare_doctor.PracticeBPTID))
                                {
                                    var doctors_practice = practices_grouped_by_bpt[aftercare_doctor.PracticeBPTID];
                                    settlement.acpractice = doctors_practice.PracticeName;
                                    settlement.bsnr = doctors_practice.PracticeBSNR;
                                }
                                else
                                {
                                    settlement.acpractice = "-";
                                    settlement.bsnr = "-";
                                }
                            }
                            else if (practices_grouped_by_bpt.ContainsKey(aftercare_bpt))
                            {
                                var aftercare_practice = practices_grouped_by_bpt[aftercare_bpt];
                                settlement.aftercare_doctor_practice_id = aftercare_practice.PracticeID.ToString();
                                settlement.acpractice = aftercare_practice.PracticeName;
                                settlement.bsnr = aftercare_practice.PracticeBSNR;
                            }
                        }
                        #endregion Aftercare

                        #region FS status

                        if (fs_status.case_fs_status_code != 3 && fs_status.case_fs_status_code != 5 && fs_status.case_fs_status_code != 10 && fs_status.case_fs_status_code != 18)
                        {
                            var status = fs_status.case_fs_status_code == 17 ? 8 : fs_status.case_fs_status_code;
                            settlement.status = "FS" + status;
                        }
                        else
                        {
                            settlement.status = "FS1";
                            if (previous_status_cache.ContainsKey(_case.case_id))
                            {
                                var gpmid = "mm.docconnect.gpos.catalog.operation";

                                var case_previous_statuses = previous_status_cache[_case.case_id];
                                var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == gpmid);
                                if (previous_status != null)
                                {
                                    settlement.status = "FS" + previous_status.previous_status;
                                }
                            }
                        }
                        settlement.status_date = fs_status.status_date;

                        #endregion FS status

                        settlement.id = _case.treatment_planned_action_id.ToString();
                        settlement.is_report_downloaded = existingSettlementDownloadStatuses.ContainsKey(settlement.id) ? existingSettlementDownloadStatuses[settlement.id] : false;
                        settlement.diagnose = _case.diagnose_name;
                        settlement.diagnose_id = _case.diagnose_id.ToString();
                        settlement.doctor = _case.treatment_doctor_name;
                        settlement.lanr = _case.treatment_doctor_lanr;
                        settlement.localization = _case.localization;
                        settlement.practice_id = _case.practice_id.ToString();
                        settlement.surgery_date = _case.treatment_date;
                        settlement.surgery_date_string = _case.treatment_date.ToString("dd.MM.");
                        settlement.surgery_date_string_month = _case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                        settlement.case_id = _case.case_id.ToString();
                        settlement.case_type = "op";
                        settlement.drug = _case.drug_name;
                        settlement.drug_id = _case.hec_drug_id.ToString();
                        settlement.first_name = patient_details.patient_first_name;
                        settlement.hip = patient_details.health_insurance_provider;
                        settlement.birthday = patient_details.birthday.ToString("dd.MM.yyyy");
                        settlement.last_name = patient_details.patient_last_name;
                        settlement.patient_full_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
                        settlement.patient_id = _case.patient_id.ToString();
                        settlement.patient_insurance_number = patient_details.insurance_id;
                        settlement.previous_status = "";
                        settlement.treatment_doctor_id = _case.treatment_doctor_id.ToString();
                        if (settlement.status != "FS13")
                        {
                            settlement.ac_status = "AC1";
                        }
                        settlement.hip_ik_number = patient_details.HealthInsurance_IKNumber;
                        if (filtered_aftercare_statuses.Any())
                        {
                            if (relevantActionCache.ContainsKey(_case.case_id))
                            {
                                var relevant_case_actions = relevantActionCache[_case.case_id];
                                if (relevant_case_actions.ContainsKey(EActionType.PlannedAftercare.Value()))
                                {
                                    var relevant_aftercares = relevantActionCache[_case.case_id][EActionType.PlannedAftercare.Value()].ToList();
                                    if (relevant_aftercares.Any() && relevant_aftercares.Last().IsPerformed)
                                    {
                                        var aftercare_planned_action = relevant_aftercares.Last();

                                        if (!performed_action_data.ContainsKey(aftercare_planned_action.PlannedAction_RefID))
                                        {
                                            continue;
                                        }
                                        var performed_action_details = performed_action_data[aftercare_planned_action.PlannedAction_RefID];

                                        settlement.ac_status = performed_action_details.PerformedOnDate.ToString("dd.MM.yyyy");

                                        var aftercare_status = filtered_aftercare_statuses.Last().case_fs_status_code;
                                        if (aftercare_status == 8 || aftercare_status == 11 || aftercare_status == 17)
                                        {
                                            settlement.ac_status = "FS8";
                                        }
                                    }
                                }
                            }
                        }
                        else if (settlement.status == "FS8")
                        {
                            settlement.ac_status = "AC4";
                        }

                        settlements.Add(settlement);
                    }

                    #endregion OP

                    if (relevantActionCache.ContainsKey(_case.case_id))
                    {
                        var relevant_case_actions = relevantActionCache[_case.case_id];

                        #region AC

                        var ac_planned_action_type = "mm.docconect.doc.app.planned.action.aftercare";
                        if (relevant_case_actions.ContainsKey(ac_planned_action_type))
                        {
                            var relevant_aftercares = relevantActionCache[_case.case_id][ac_planned_action_type].Where(t => t.IsPerformed).ToList();

                            for (int index = 0; index < filtered_aftercare_statuses.Count; index++)
                            {
                                var settlement = new Settlement_Model();
                                if (index >= relevant_aftercares.Count)
                                {
                                    continue;
                                }

                                var aftercare_planned_action = relevant_aftercares[index];
                                if (!performed_action_data.ContainsKey(aftercare_planned_action.PlannedAction_RefID))
                                {
                                    Console.WriteLine("Case number: {0}", _case.case_number);
                                    continue;
                                }
                                var performed_action_details = performed_action_data[aftercare_planned_action.PlannedAction_RefID];
                                var diagnose_details = diagnose_cache[performed_action_details.DiagnoseID];
                                var filtered_aftercare_status = filtered_aftercare_statuses[index];

                                #region FS status

                                if (filtered_aftercare_status.case_fs_status_code != 3 && filtered_aftercare_status.case_fs_status_code != 5 && filtered_aftercare_status.case_fs_status_code != 10 && filtered_aftercare_status.case_fs_status_code != 18)
                                {
                                    var status = filtered_aftercare_status.case_fs_status_code == 17 ? 8 : filtered_aftercare_status.case_fs_status_code;
                                    settlement.status = "FS" + status;
                                }
                                else
                                {
                                    settlement.status = "FS1";
                                    if (previous_status_cache.ContainsKey(_case.case_id))
                                    {
                                        var gpmid = "mm.docconnect.gpos.catalog.nachsorge";

                                        var case_previous_statuses = previous_status_cache[_case.case_id];
                                        var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == gpmid);
                                        if (previous_status != null)
                                        {
                                            settlement.status = "FS" + previous_status.previous_status;
                                        }
                                    }
                                }
                                settlement.status_date = filtered_aftercare_status.status_date;

                                #endregion FS status

                                #region Aftercare doctor/practice

                                if (doctors_cache.ContainsKey(aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID))
                                {
                                    var aftercare_doctor = doctors_cache[aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                    settlement.aftercare_doctor_practice_id = aftercare_doctor.DoctorID.ToString();
                                    settlement.doctor = GenericUtils.GetDoctorNamePascal(aftercare_doctor);
                                    settlement.lanr = aftercare_doctor.DoctorLANR;

                                    if (practices_grouped_by_bpt.ContainsKey(aftercare_doctor.PracticeBPTID))
                                    {
                                        var doctors_practice = practices_grouped_by_bpt[aftercare_doctor.PracticeBPTID];
                                        settlement.acpractice = doctors_practice.PracticeName;
                                        settlement.bsnr = doctors_practice.PracticeBSNR;
                                        settlement.practice_id = doctors_practice.PracticeID.ToString();
                                    }
                                    else
                                    {
                                        settlement.acpractice = "-";
                                        settlement.bsnr = "-";
                                    }
                                }
                                else if (practices_grouped_by_bpt.ContainsKey(aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID))
                                {
                                    var aftercare_practice = practices_grouped_by_bpt[aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                    settlement.aftercare_doctor_practice_id = aftercare_practice.PracticeID.ToString();
                                    settlement.acpractice = aftercare_practice.PracticeName;
                                    settlement.bsnr = aftercare_practice.PracticeBSNR;
                                }

                                #endregion Aftercare doctor/practice

                                settlement.id = aftercare_planned_action.PlannedAction_RefID.ToString();
                                settlement.is_report_downloaded = existingSettlementDownloadStatuses.ContainsKey(settlement.id) ? existingSettlementDownloadStatuses[settlement.id] : false;
                                settlement.diagnose = diagnose_details != null ? diagnose_details.diagnose_name : _case.diagnose_name;
                                settlement.diagnose_id = diagnose_details != null ? diagnose_details.diagnose_id.ToString() : _case.diagnose_id.ToString();
                                settlement.localization = performed_action_details.LocalizationCode;
                                settlement.surgery_date = performed_action_details.PerformedOnDate;
                                settlement.surgery_date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.");
                                settlement.surgery_date_string_month = performed_action_details.PerformedOnDate.ToString("MMMM yyyy", new CultureInfo("de", true));
                                settlement.if_aftercare_treatment_date = _case.treatment_date.ToString("dd.MM.yyyy");
                                settlement.case_id = _case.case_id.ToString();
                                settlement.case_type = "ac";
                                settlement.drug = _case.drug_name;
                                settlement.drug_id = _case.hec_drug_id.ToString();
                                settlement.first_name = patient_details.patient_first_name;
                                settlement.hip = patient_details.health_insurance_provider;
                                settlement.birthday = patient_details.birthday.ToString("dd.MM.yyyy");
                                settlement.last_name = patient_details.patient_last_name;
                                settlement.patient_full_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
                                settlement.patient_id = _case.patient_id.ToString();
                                settlement.patient_insurance_number = patient_details.insurance_id;
                                settlement.previous_status = "";
                                settlement.treatment_doctor_id = _case.treatment_doctor_id.ToString();
                                settlement.hip_ik_number = patient_details.HealthInsurance_IKNumber;

                                settlements.Add(settlement);
                            }
                        }

                        #endregion AC

                        #region OCTS

                        if (patientActionCache.ContainsKey(_case.patient_id) && patientActionCache[_case.patient_id].ContainsKey(_case.localization) && patient_fs_status_cache.ContainsKey(_case.patient_id) && patient_fs_status_cache[_case.patient_id].ContainsKey(_case.localization))
                        {
                            var filtered_oct_statuses = patient_fs_status_cache[_case.patient_id][_case.localization].Where(fs => fs.gpos_type == EGposType.Oct.Value()).ToList();
                            var relevant_octs = patientActionCache[_case.patient_id][_case.localization].Where(t => t.IsPerformed).ToList();

                            for (int index = 0; index < filtered_oct_statuses.Count; index++)
                            {
                                var settlement = new Settlement_Model();

                                if (index >= relevant_octs.Count)
                                {
                                    continue;
                                }

                                var oct_planned_action = all_planned_actions.Single(t => t.HEC_ACT_PlannedActionID == relevant_octs[index].PlannedAction_RefID);
                                if (!performed_action_data.ContainsKey(oct_planned_action.HEC_ACT_PlannedActionID))
                                {
                                    continue;
                                }

                                var oct_doctor_details = doctors_cache[oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                var oct_doctors_practice = practices_grouped_by_bpt[oct_doctor_details.PracticeBPTID];

                                if (!performed_action_data.ContainsKey(oct_planned_action.HEC_ACT_PlannedActionID))
                                {
                                    Console.WriteLine("Case number: {0}", _case.case_number);
                                    continue;
                                }
                                var performed_action_details = performed_action_data[oct_planned_action.HEC_ACT_PlannedActionID];
                                var diagnose_details = diagnose_cache[performed_action_details.DiagnoseID];
                                var filtered_oct_status = filtered_oct_statuses[index];

                                #region FS Status

                                if (filtered_oct_status.case_fs_status_code != 3 && filtered_oct_status.case_fs_status_code != 5 && filtered_oct_status.case_fs_status_code != 10 && filtered_oct_status.case_fs_status_code != 18)
                                {
                                    var status = filtered_oct_status.case_fs_status_code == 17 ? 8 : filtered_oct_status.case_fs_status_code;
                                    settlement.status = "FS" + status;
                                }
                                else
                                {
                                    settlement.status = "FS1";
                                    if (previous_status_cache.ContainsKey(_case.case_id))
                                    {
                                        var gpmid = "mm.docconnect.gpos.catalog.voruntersuchung";

                                        var case_previous_statuses = previous_status_cache[_case.case_id];
                                        var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == gpmid);
                                        if (previous_status != null)
                                        {
                                            settlement.status = "FS" + previous_status.previous_status;
                                        }
                                    }
                                }
                                settlement.status_date = filtered_oct_status.status_date;

                                #endregion FS Status

                                settlement.id = oct_planned_action.HEC_ACT_PlannedActionID.ToString();
                                settlement.is_report_downloaded = existingSettlementDownloadStatuses.ContainsKey(settlement.id) ? existingSettlementDownloadStatuses[settlement.id] : false;
                                settlement.birthday = patient_details.birthday.ToString("dd.MM.yyyy");
                                settlement.bsnr = oct_doctors_practice.PracticeBSNR;
                                settlement.case_id = _case.case_id.ToString();
                                settlement.case_type = "oct";
                                settlement.diagnose = String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10);
                                settlement.diagnose_id = performed_action_details.DiagnoseID.ToString();
                                settlement.doctor = GenericUtils.GetDoctorNamePascal(oct_doctor_details);
                                settlement.first_name = patient_details.patient_first_name;
                                settlement.hip = patient_details.health_insurance_provider;
                                settlement.if_aftercare_treatment_date = _case.treatment_date.ToString("dd.MM.yyyy");
                                settlement.lanr = oct_doctor_details.DoctorLANR;
                                settlement.last_name = patient_details.patient_last_name;
                                settlement.drug = _case.drug_name;
                                settlement.drug_id = _case.hec_drug_id.ToString();
                                settlement.localization = performed_action_details.LocalizationCode;
                                settlement.patient_full_name = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name);
                                settlement.patient_id = patient_details.id.ToString();
                                settlement.patient_insurance_number = patient_details.insurance_id;
                                settlement.practice_id = oct_doctors_practice.PracticeID.ToString();
                                settlement.surgery_date = performed_action_details.PerformedOnDate;
                                settlement.surgery_date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.yyyy");
                                settlement.surgery_date_string_month = performed_action_details.PerformedOnDate.ToString("MMMM yyyy", new CultureInfo("de", true));
                                settlement.treatment_doctor_id = oct_doctor_details.DoctorID.ToString();
                                settlement.hip_ik_number = patient_details.HealthInsurance_IKNumber;

                                settlements.Add(settlement);
                            }
                        }

                        #endregion OCTS
                    }

                    Console.Write("\rCase {0} of {1} updated.            ", i++, all_cases.Length);

                }

                if (handleTransaction)
                {
                    Transaction.Commit();
                }

                if (handleConnection)
                {
                    Connection.Close();
                }

                Console.WriteLine();
                Console.WriteLine();
                return settlements;
            }
            catch (Exception ex)
            {
                if (handleTransaction)
                {
                    Transaction.Rollback();
                }

                if (handleConnection)
                {
                    Connection.Close();
                }

                throw new Exception("Something went wrong during Settlement section elastic rebuild", ex);
            }
        }

        public static List<Practice_Doctors_Model> RebuildDoctorsAndPractices(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();

            var Transaction = Connection.BeginTransaction();
            try
            {
                var all_Practices = cls_Get_All_Practices_from_DB.Invoke(Connection, Transaction, securityTicket).Result;
                List<Practice_Doctors_Model> LdoctorPracticeM = new List<Practice_Doctors_Model>();
                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();

                if (all_Practices.Any())
                {
                    int i = 1;
                    foreach (var practice in all_Practices)
                    {
                        Practice_Doctors_Model doctorPracticeM = new Practice_Doctors_Model();

                        bool statusAcc = accountService.GetAccountStatusHistory(securityTicket.TenantID, practice.AccountID).OrderBy(st => st.CreationTimestamp).Reverse().FirstOrDefault()?.Status == EAccountStatus.BANNED;
                        doctorPracticeM.account_status = statusAcc ? "inaktiv" : "aktiv";
                        doctorPracticeM.id = practice.PracticeID.ToString();
                        doctorPracticeM.name = practice.Name;
                        doctorPracticeM.name_untouched = practice.Name;
                        doctorPracticeM.salutation = "";
                        doctorPracticeM.type = "Practice";
                        doctorPracticeM.address = practice.Street_Name + " " + practice.Street_Number;
                        doctorPracticeM.zip = practice.ZIP;
                        doctorPracticeM.city = practice.City;
                        if (practice.Contact_Email != null)
                        {
                            doctorPracticeM.email = practice.Contact_Email;
                        }
                        doctorPracticeM.phone = practice.Contact_Telephone;

                        doctorPracticeM.bank_untouched = practice.BankName != null ? practice.BankName : "";
                        doctorPracticeM.bank = practice.BankName != null ? practice.BankName : "";

                        if (practice.IBAN != null)
                        {
                            doctorPracticeM.iban = practice.IBAN;
                        }
                        if (practice.BICCode != null)
                        {
                            doctorPracticeM.bic = practice.BICCode;
                        }
                        doctorPracticeM.bsnr_lanr = practice.BSNR;
                        doctorPracticeM.aditional_info = "";
                        doctorPracticeM.tenantid = securityTicket.TenantID.ToString();
                        doctorPracticeM.role = practice.IsSurgeryPractice ? "op" : "ac";
                        doctorPracticeM.autocomplete_name = practice.Name;

                        DO_GPCN_1133[] dataContract = cls_Get_Practice_Contract_Numbers.Invoke(Connection, Transaction, new P_DO_GPCN_1133() { PracticeID = practice.PracticeID }, securityTicket).Result;
                        doctorPracticeM.contract = dataContract.Length;
                        LdoctorPracticeM.Add(doctorPracticeM);
                        Console.Write("\rPractices {0} of {1} updated.                ", i++, all_Practices.Length);
                    }
                }

                var all_Doctors = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
                // var all_Doctors = cls_Get_All_Doctors_from_DB.Invoke(Connection, Transaction, securityTicket).Result;
                if (all_Doctors.Count != 0)
                {
                    var i = 1;
                    var tempDoctors = Get_Doctors_for_PracticeID.GetTemporaryDoctors(securityTicket).ToDictionary(t => t.id, t => new { address = t.address, city = t.city });

                    foreach (var doctor in all_Doctors)
                    {
                        var data = cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString, new P_DO_GDDfDID_0823 { DoctorID = doctor.HEC_DoctorID }, securityTicket).Result.Single();

                        Practice_Doctors_Model doctorPracticeM = new Practice_Doctors_Model();
                        if (data.doctor_account_id != Guid.Empty)
                        {
                            bool statusAcc = true;
                            var accountStatusHistory = accountService.GetAccountStatusHistory(securityTicket.TenantID, data.doctor_account_id).OrderBy(st => st.CreationTimestamp);
                            if (accountStatusHistory.Any())
                            {
                                statusAcc = accountStatusHistory.Reverse().First().Status == EAccountStatus.BANNED;
                            }

                            doctorPracticeM.account_status = statusAcc ? "inaktiv" : "aktiv";

                            doctorPracticeM.name_untouched = data.first_name + " " + data.last_name;
                        }
                        else
                        {
                            doctorPracticeM.account_status = "temp";
                            if (data.last_name.ToLower().Contains("dr"))
                            {
                                doctorPracticeM.name_untouched = data.last_name.Substring(data.last_name.IndexOf(' ') + 1);
                            }
                            else
                            {
                                doctorPracticeM.name_untouched = data.first_name + " " + data.last_name;
                            }
                        }

                        doctorPracticeM.id = data.id.ToString();
                        var title = string.IsNullOrEmpty(data.title) ? "" : data.title.Trim();
                        doctorPracticeM.tenantid = securityTicket.TenantID.ToString();
                        doctorPracticeM.name = GenericUtils.GetDoctorName(data);
                        doctorPracticeM.bsnr_lanr = data.lanr;
                        doctorPracticeM.salutation = title;
                        doctorPracticeM.type = "Doctor";
                        doctorPracticeM.bank = string.IsNullOrEmpty(data.BankName) ? "" : data.BankName;
                        doctorPracticeM.bank_untouched = string.IsNullOrEmpty(data.BankName) ? "" : data.BankName;

                        if (data.DoctorComunication.Where(k => k.Type == "Phone").SingleOrDefault() != null)
                            doctorPracticeM.phone = data.DoctorComunication.Where(k => k.Type == "Phone").Single().Content;

                        if (data.DoctorComunication.Where(k => k.Type == "Email").SingleOrDefault() != null)
                            doctorPracticeM.email = data.DoctorComunication.Where(k => k.Type == "Email").Single().Content;

                        doctorPracticeM.iban = string.IsNullOrEmpty(data.IBAN) ? "" : data.IBAN;

                        doctorPracticeM.bic = string.IsNullOrEmpty(data.BICCode) ? "" : data.BICCode;

                        var practice = all_Practices.Where(pr => pr.PracticeID == data.practice_id).SingleOrDefault();
                        doctorPracticeM.autocomplete_name = GenericUtils.GetDoctorName(data);

                        if (practice != null)
                        {
                            doctorPracticeM.practice_for_doctor_id = practice.PracticeID.ToString();
                            doctorPracticeM.practice_name_for_doctor = practice.Name;

                            doctorPracticeM.address = practice.Street_Name + " " + practice.Street_Number;

                            doctorPracticeM.zip = practice.ZIP;
                            doctorPracticeM.city = practice.City;
                            doctorPracticeM.role = practice.IsSurgeryPractice ? "op" : "ac";
                            if (data.BankAccountID == practice.BankAccountID)
                            {
                                doctorPracticeM.bank_id = practice.BankAccountID.ToString();
                                doctorPracticeM.bank_info_inherited = true;
                                doctorPracticeM.bank_untouched = practice.BankName != null ? practice.BankName : "";
                                doctorPracticeM.bank = practice.BankName != null ? practice.BankName : "";

                                if (practice.IBAN != null)
                                {
                                    doctorPracticeM.iban = practice.IBAN;
                                }
                                if (practice.BICCode != null)
                                {
                                    doctorPracticeM.bic = practice.BICCode;
                                }
                            }
                            else
                            {
                                doctorPracticeM.bank_id = data.BankAccountID.ToString();
                                doctorPracticeM.bank_info_inherited = false;
                                doctorPracticeM.bank_untouched = data.BankName != null ? data.BankName : "";
                                doctorPracticeM.bank = data.BankName != null ? data.BankName : "";

                                if (data.IBAN != null)
                                {
                                    doctorPracticeM.iban = data.IBAN;
                                }
                                if (data.BICCode != null)
                                {
                                    doctorPracticeM.bic = data.BICCode;
                                }
                            }
                        }
                        else
                        {
                            if (tempDoctors.ContainsKey(data.id.ToString()))
                            {
                                doctorPracticeM.address = tempDoctors[data.id.ToString()].address;
                                doctorPracticeM.city = tempDoctors[data.id.ToString()].city;
                            }
                        }

                        var docContracts = cls_Get_Doctor_Contract_Numbers.Invoke(Connection, Transaction, new P_DO_CDCD_1505() { DoctorID = data.id }, securityTicket).Result;
                        doctorPracticeM.contract = docContracts.Count();
                        LdoctorPracticeM.Add(doctorPracticeM);
                        Console.Write("\rdoctors {0} of {1} updated.                ", i++, all_Doctors.Count);
                    }
                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return LdoctorPracticeM;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Practice-Doctor section elastic rebuild", ex);
            }
        }

        public static List<Patient_Model> RebuildPatients(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();

            var Transaction = Connection.BeginTransaction();
            try
            {
                List<Patient_Model> patientModelL = new List<Patient_Model>();
                var all_Patients = cls_Get_All_Patients_from_DB.Invoke(Connection, Transaction, securityTicket).Result.Select(t => MapPatientDbToExtension(t)).ToList();
                var rejected_oct_case_properties = cls_Get_CaseProperties_for_PropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPfPGpmID_0821()
                {
                    PropertyGpmID = "mm.doc.connect.case.has.rejected.oct"
                }, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());
                var HIPLIst = cls_Get_All_HIPs.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                var doctors = cls_Get_Doctor_Data_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var doctors_cache = cls_Get_Doctor_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
                var all_practices = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                var patient_properties = cls_Get_PatientProperties_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());
                var practices_grouped_by_bpt = new Dictionary<Guid, DO_GPDoT_1735>();
                var practices_grouped_by_id = new Dictionary<Guid, DO_GPDoT_1735>();

                foreach (var practice in all_practices)
                {
                    if (!practices_grouped_by_id.ContainsKey(practice.PracticeID))
                    {
                        practices_grouped_by_id.Add(practice.PracticeID, practice);
                    }

                    if (!practices_grouped_by_bpt.ContainsKey(practice.PracticeBptID))
                    {
                        practices_grouped_by_bpt.Add(practice.PracticeBptID, practice);
                    }
                }

                var relevant_actions = cls_Get_RelevantPlannedActions_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.performing_bpt_id).ToDictionary(x => x.Key, x => x.ToList()));
                foreach (var patient in relevant_actions)
                {
                    var practice_bpt_ids = new List<Guid>();
                    var existing_patient = all_Patients.First(t => t.Id == patient.Key);
                    foreach (var bpt_id in patient.Value.Keys)
                    {
                        var performing_bpt_practice_id = Guid.Empty;
                        if (doctors_cache.ContainsKey(bpt_id))
                        {
                            performing_bpt_practice_id = doctors_cache[bpt_id].PracticeBPTID;
                        }
                        else if (practices_grouped_by_bpt.ContainsKey(bpt_id))
                        {
                            performing_bpt_practice_id = bpt_id;
                        }

                        if (!practice_bpt_ids.Contains(performing_bpt_practice_id) && performing_bpt_practice_id != Guid.Empty)
                        {
                            practice_bpt_ids.Add(performing_bpt_practice_id);
                        }
                    }

                    foreach (var practice_bpt_id in practice_bpt_ids)
                    {
                        var practice = practices_grouped_by_bpt[practice_bpt_id];
                        var originating_practice = practices_grouped_by_id[existing_patient.PracticeID];

                        if (practice.PracticeID != originating_practice.PracticeID)
                        {
                            all_Patients.Add(new PatientRebuildDbDataExtension()
                            {
                                BirthDate = existing_patient.BirthDate,
                                FirstName = existing_patient.FirstName,
                                Gender = existing_patient.Gender,
                                HIPID = existing_patient.HIPID,
                                HipNumber = existing_patient.HipNumber,
                                Id = Guid.NewGuid(),
                                InsuranceStatus = existing_patient.InsuranceStatus,
                                LastName = existing_patient.LastName,
                                PracticeID = practice.PracticeID,
                                ValidFrom = existing_patient.ValidFrom,
                                ValidThrough = existing_patient.ValidThrough,
                                OriginatingPracticeId = existing_patient.PracticeID,
                                OriginatingPatientId = existing_patient.Id,
                                OriginatingPracticeName = originating_practice.PracticeName
                            });
                        }
                    }
                }

                var i = 1;
                foreach (var patient in all_Patients)
                {
                    var patientModel = new Patient_Model();
                    var HIP = HIPLIst.Where(li => li.id == patient.HIPID).SingleOrDefault();
                    var previous_case_details = cls_Get_Previous_Case_Data_for_PatientID.Invoke(Connection, Transaction, new P_CAS_GPCDfPID_1144() { PatientID = patient.Id }, securityTicket).Result;
                    var op_doc_details = previous_case_details != null ? doctors.FirstOrDefault(t => t.id == previous_case_details.treatment_doctor_id) : null;
                    var ac_doc_details = previous_case_details != null ? doctors.FirstOrDefault(t => t.id == previous_case_details.aftercare_doctor_id) : null;

                    var culture = new System.Globalization.CultureInfo("de", true);
                    patientModel.birthday = DateTime.Parse(patient.BirthDate.ToString("dd.MM.yyyy"), culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    patientModel.birthday_string = patient.BirthDate.ToString("dd.MM.yyyy");
                    patientModel.name = patient.LastName + ", " + patient.FirstName;
                    patientModel.health_insurance_provider = HIP == null ? "-" : HIP.name;
                    patientModel.name_with_birthdate = patient.FirstName + " " + patient.LastName + " (" + patient.BirthDate.ToString("dd.MM.yyyy") + ")";
                    patientModel.id = patient.Id.ToString();
                    patientModel.insurance_id = String.IsNullOrEmpty(patient.HipNumber) ? "-" : patient.HipNumber;
                    patientModel.insurance_status = String.IsNullOrEmpty(patient.InsuranceStatus) ? "-" : patient.InsuranceStatus;
                    patientModel.practice_id = patient.PracticeID.ToString();
                    patientModel.last_first_op_doctor_name = op_doc_details != null ? GenericUtils.GetDoctorName(op_doc_details) : "-";
                    patientModel.last_first_ac_doctor_name = ac_doc_details != null ? GenericUtils.GetDoctorName(ac_doc_details) : "-";
                    patientModel.op_doctor_lanr = op_doc_details != null ? op_doc_details.lanr : "-";
                    patientModel.ac_doctor_lanr = ac_doc_details != null ? ac_doc_details.lanr : "-";
                    patientModel.op_practice_id = op_doc_details != null ? op_doc_details.practice_id.ToString() : "-";
                    patientModel.practice = op_doc_details != null ? op_doc_details.practice : "";
                    patientModel.practice_bsnr = op_doc_details != null ? op_doc_details.BSNR : "-";
                    patientModel.op_doctor_id = op_doc_details != null ? op_doc_details.id.ToString() : "-";
                    patientModel.ac_doctor_id = ac_doc_details != null ? ac_doc_details.id.ToString() : "-";
                    patientModel.ac_practice_id = ac_doc_details != null ? ac_doc_details.practice_id.ToString() : "-";
                    patientModel.ac_practice = ac_doc_details != null ? ac_doc_details.practice : "";
                    if (patient.OriginatingPatientId != Guid.Empty)
                    {
                        patientModel.originating_patient_id = patient.OriginatingPatientId.ToString();
                        patientModel.originating_practice_id = patient.OriginatingPracticeId.ToString();
                        patientModel.originating_practice_name = patient.OriginatingPracticeName;
                    }

                    patientModel.ac_practice_bsnr = ac_doc_details != null ? ac_doc_details.BSNR : "-";

                    switch (Convert.ToInt32(patient.Gender))
                    {
                        case 0: patientModel.sex = "M"; break;
                        case 1: patientModel.sex = "W"; break;
                        default: patientModel.sex = "o.A."; break;
                    }

                    if (patient.ValidFrom != DateTime.MinValue)
                    {
                        patientModel.participation_consent_from = patient.ValidFrom;
                        patientModel.has_participation_consent = true;
                    }

                    if (patient.ValidThrough != DateTime.MinValue)
                        patientModel.participation_consent_to = patient.ValidThrough;

                    if (rejected_oct_case_properties.ContainsKey(patient.Id))
                    {
                        patientModel.has_rejected_oct = true;
                    }

                    if (patient_properties.ContainsKey(patient.Id))
                    {
                        var properties = patient_properties[patient.Id];
                        var externalId = properties.FirstOrDefault(t => t.gpm_id == "mm.docconnect.patient.external.id");
                        if (externalId != null)
                        {
                            patientModel.external_id = externalId.string_value;
                        }
                    }

                    patientModelL.Add(patientModel);

                    Console.Write("\rPatients {0} of {1} updated.                ", i++, all_Patients.Count);

                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return patientModelL;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Patients section elastic rebuild", ex);
            }
        }

        private class PatientRebuildDbDataExtension : DO_GAPDB_1001
        {
            public Guid OriginatingPatientId { get; set; }

            public Guid OriginatingPracticeId { get; set; }

            public string OriginatingPracticeName { get; set; }
        }

        private static PatientRebuildDbDataExtension MapPatientDbToExtension(DO_GAPDB_1001 patient)
        {
            var result = new PatientRebuildDbDataExtension();
            var source_properties = patient.GetType().GetProperties();
            foreach (var prop in source_properties)
            {
                prop.SetValue(result, prop.GetValue(patient));
            }

            return result;
        }

        public static List<Order_Model> RebuildOrders(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();
            var Transaction = Connection.BeginTransaction();
            List<Order_Model> OrderModelL = new List<Order_Model>();
            try
            {
                var orders = cls_Get_all_orders.Invoke(Connection, Transaction, securityTicket).Result;
                if (orders.Any())
                {
                    var doctorsCache = cls_Get_Doctor_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorID).ToDictionary(t => t.Key, t => t.Single());
                    var practiceCache = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PracticeBptID).ToDictionary(t => t.Key, t => t.Single());
                    var orderStatusCache = cls_Get_Order_Status_History_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.header_id).ToDictionary(t => t.Key, t => t);
                    var fsStatusCache = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                    var case_details = cls_Get_All_Cases_from_DB_for_ElasticRebuild.Invoke(Connection, Transaction, securityTicket).Result.ToDictionary(t => t.case_id, t => t);
                    var patientCache = cls_Get_Patient_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());
                    var pharmacy_cache = cls_Get_Pharamcy_Info_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.pharmacy_supplier_id).ToDictionary(t => t.Key, t => t.Single());

                    var i = 1;
                    foreach (var order in orders)
                    {
                        var caseForUpdate = case_details[order.CaseID];
                        var orderM = new Order_Model();

                        orderM.drug_id = caseForUpdate.hec_drug_id.ToString();
                        if (caseForUpdate.diagnose_id != Guid.Empty)
                        {
                            orderM.diagnose_id = caseForUpdate.diagnose_id.ToString();
                        }

                        var treatment_date = DateTime.SpecifyKind(order.Treatment_Date, DateTimeKind.Utc);
                        var delivery_date = DateTime.SpecifyKind(order.Position_RequestedDateOfDelivery, DateTimeKind.Utc);

                        var delivery_date_from = delivery_date > treatment_date && caseForUpdate.localization != null ? treatment_date.AddHours(order.RequestedDateOfDelivery_TimeFrame_From.Hour).AddMinutes(order.RequestedDateOfDelivery_TimeFrame_From.Minute) : order.RequestedDateOfDelivery_TimeFrame_From;
                        var delivery_date_to = delivery_date > treatment_date && caseForUpdate.localization != null ? treatment_date.AddHours(order.RequestedDateOfDelivery_TimeFrame_To.Hour).AddMinutes(order.RequestedDateOfDelivery_TimeFrame_To.Minute) : order.RequestedDateOfDelivery_TimeFrame_To;

                        orderM.case_id = caseForUpdate.case_id.ToString();
                        orderM.id = order.OrderID.ToString();
                        orderM.status_drug_order = order.StatusCode.ToString() == "7" ? "MO6" : "MO" + order.StatusCode.ToString();
                        orderM.delivery_time_from = delivery_date_from;
                        orderM.delivery_time_to = delivery_date_to;
                        orderM.delivery_time_string = orderM.delivery_time_from.ToString("HH:mm") + " - " + orderM.delivery_time_to.ToString("HH:mm");
                        orderM.practice_id = caseForUpdate.practice_id.ToString();
                        orderM.order_modification_timestamp = caseForUpdate.order_modification_timestamp;
                        orderM.order_modification_timestamp_string = caseForUpdate.order_modification_timestamp.ToString("dd.MM.yyyy");
                        orderM.is_orders_drug = true;
                        orderM.treatment_date = delivery_date > treatment_date && caseForUpdate.localization != null ? treatment_date : delivery_date;
                        orderM.treatment_date_day_month = orderM.treatment_date.ToString("dd.MM.");
                        orderM.treatment_date_month_year = orderM.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                        orderM.localization = caseForUpdate.diagnose_id != Guid.Empty ? caseForUpdate.localization : "-";
                        orderM.diagnose = !String.IsNullOrEmpty(caseForUpdate.diagnose_name) ? caseForUpdate.diagnose_name : "-";
                        orderM.drug = caseForUpdate.drug_name;


                        if (patientCache.ContainsKey(caseForUpdate.patient_id))
                        {
                            var patient = patientCache[caseForUpdate.patient_id];
                            orderM.patient_name = patient.patient_last_name + ", " + patient.patient_first_name;
                            orderM.patient_birthdate_string = patient.birthday.ToString("dd.MM.yyyy");
                            orderM.patient_birthdate = patient.birthday;
                            orderM.hip = patient.health_insurance_provider;
                            orderM.patient_insurance_number = patient.insurance_id;
                            orderM.patient_id = caseForUpdate.patient_id.ToString();
                        }

                        if (doctorsCache.ContainsKey(caseForUpdate.treatment_doctor_id))
                        {
                            var doctor = doctorsCache[caseForUpdate.treatment_doctor_id];
                            var practice = practiceCache[doctor.PracticeBPTID];
                            orderM.treatment_doctor_name = caseForUpdate.treatment_doctor_name;
                            orderM.treatment_doctor_practice_name = practice.PracticeName;
                            orderM.lanr = doctor.DoctorLANR;
                            orderM.bsnr = practice.PracticeBSNR;
                            orderM.doctor_id = caseForUpdate.treatment_doctor_id.ToString();
                        }

                        orderM.practice_id = caseForUpdate.practice_id.ToString();
                        orderM.isOverdue = (delivery_date_to < DateTime.Now).ToString();

                        orderM.pharmacy_id = pharmacy_cache.ContainsKey(caseForUpdate.pharmacy_supplier_id) ? pharmacy_cache[caseForUpdate.pharmacy_supplier_id].pharmacy_id.ToString() : null;
                        orderM.pharmacy_name = pharmacy_cache.ContainsKey(caseForUpdate.pharmacy_supplier_id) ? pharmacy_cache[caseForUpdate.pharmacy_supplier_id].pharmacy_name : null;


                        OrderModelL.Add(orderM);

                        Console.Write("\rOrders {0} of {1} updated.                ", i++, orders.Length);

                    }
                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return OrderModelL;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Orders section elastic rebuild", ex);
            }
        }

        public static List<Submitted_Case_Model> RebuildTreatments(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();
            var Transaction = Connection.BeginTransaction();
            List<Submitted_Case_Model> treatments = new List<Submitted_Case_Model>();
            Dictionary<Guid, int> gposAssignmentsCountCache = cls_Get_Number_of_GposTypes_on_Case_for_CaseID_and_GposType.Invoke(Connection, Transaction, new P_CAS_GNoGPOSToCfCIDaGPOST_1023()
            {
                GposType = "mm.docconnect.gpos.catalog.operation"
            }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.Single().NumberOfTreatmentGposes);

            var all_cases = cls_Get_All_Cases_from_DB_for_ElasticRebuild.Invoke(Connection, Transaction, securityTicket).Result;
            List<Settlement_Model> settlements = new List<Settlement_Model>();
            var doctors_cache = cls_Get_Doctor_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
            var all_planned_actions = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
            var patient_cache = cls_Get_Patient_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());
            var relevantActionsCache = cls_Get_RelevantActionData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var relevantActionCache = relevantActionsCache.Where(t => t.IsPerformed && !t.IsCancelled).GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.ActionTypeGpmID).ToDictionary(x => x.Key, x => x.ToList()));
            var patientActionCache = relevantActionsCache.Where(t => t.ActionTypeGpmID == EActionType.PlannedOct.Value()).GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.Localization).ToDictionary(x => x.Key, x => x.ToList()));
            var reportDownloadedCache = cls_Get_Report_Downloaded_PropertyValues_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var all_practices = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var practices_grouped_by_bpt = new Dictionary<Guid, DO_GPDoT_1735>();
            var practices_grouped_by_id = new Dictionary<Guid, DO_GPDoT_1735>();
            var fake_op_properties = cls_Get_CaseProperties_for_PropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPfPGpmID_0821()
            {
                PropertyGpmID = "mm.doc.connect.case.treatment.year.fake"
            }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());

            foreach (var practice in all_practices)
            {
                if (!practices_grouped_by_id.ContainsKey(practice.PracticeID))
                {
                    practices_grouped_by_id.Add(practice.PracticeID, practice);
                }

                if (!practices_grouped_by_bpt.ContainsKey(practice.PracticeBptID))
                {
                    practices_grouped_by_bpt.Add(practice.PracticeBptID, practice);
                }
            }

            var performed_action_data = cls_Get_PerformedActionData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.ActionID).ToDictionary(t => t.Key, t => t.Single());
            var diagnose_cache = cls_Get_Diagnose_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.diagnose_id).ToDictionary(t => t.Key, t => t.Single());
            var all_case_fs_statuses = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var case_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());
            var patient_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));
            var management_fee_cache = cls_Get_Management_Fee_Property_Value_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.GPOSTypeID).ToDictionary(x => x.Key, x => x.ToList()));

            try
            {
                var i = 1;
                all_cases = all_cases.Where(t => case_fs_status_cache.ContainsKey(t.case_id) && !fake_op_properties.ContainsKey(t.case_id)).ToArray();
                for (var j = 0; j < all_cases.Length; j++)
                {
                    var casedata = all_cases[j];
                    var case_fs_statuses = case_fs_status_cache[casedata.case_id];
                    var ac_op_billed_together = gposAssignmentsCountCache.ContainsKey(casedata.case_id) ? gposAssignmentsCountCache[casedata.case_id] > 1 : false;

                    var filtered_treatment_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 230).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == EGposType.Operation.Value()).ToList();
                    var filtered_aftercare_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 60).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == EGposType.Aftercare.Value()).ToList();

                    if (!patient_cache.ContainsKey(casedata.patient_id))
                    {
                        continue;
                    }

                    var patient_details = patient_cache[casedata.patient_id];

                    #region Management fee

                    var op_gpos_type = "mm.docconnect.gpos.catalog.operation";
                    var ac_gpos_type = "mm.docconnect.gpos.catalog.nachsorge";
                    var oct_gpos_type = "mm.docconnect.gpos.catalog.voruntersuchung";
                    var op_management_fee = new List<CAS_GMFPVoT_0919>();
                    var ac_management_fee = new List<CAS_GMFPVoT_0919>();
                    var oct_management_fee = new List<CAS_GMFPVoT_0919>();

                    if (management_fee_cache.ContainsKey(casedata.case_id))
                    {
                        var case_management_fee_properties = management_fee_cache[casedata.case_id];
                        if (case_management_fee_properties.ContainsKey(op_gpos_type))
                        {
                            op_management_fee = case_management_fee_properties[op_gpos_type];
                        }

                        if (case_management_fee_properties.ContainsKey(ac_gpos_type))
                        {
                            ac_management_fee = case_management_fee_properties[ac_gpos_type];
                        }

                        if (case_management_fee_properties.ContainsKey(oct_gpos_type))
                        {
                            oct_management_fee = case_management_fee_properties[oct_gpos_type];
                        }
                    }

                    #endregion Management fee

                    #region OP

                    foreach (var fs_status in filtered_treatment_statuses)
                    {
                        if (!practices_grouped_by_id.ContainsKey(casedata.practice_id))
                        {
                            continue;
                        }

                        var practice = practices_grouped_by_id[casedata.practice_id];
                        var status = fs_status.case_fs_status_code;

                        if (status == 17)
                        {
                            status = 8;
                        }
                        else if (status == 18)
                        {
                            status = 10;
                        }

                        var treatment = new Submitted_Case_Model();
                        treatment.management_pauschale = !op_management_fee.Any() ? "waived" : op_management_fee.First().PropertyValue;
                        treatment.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
                        treatment.practice_bsnr = practice.PracticeBSNR;
                        treatment.practice_name = practice.PracticeName;
                        treatment.status_date = fs_status.status_date;
                        treatment.status_date_string = fs_status.status_date.ToString("dd.MM.yyyy");
                        treatment.diagnose = casedata.diagnose_name;
                        treatment.diagnose_id = casedata.diagnose_id.ToString();
                        treatment.doctor_name = casedata.treatment_doctor_name;
                        treatment.id = casedata.treatment_planned_action_id.ToString();
                        treatment.doctor_lanr = casedata.treatment_doctor_lanr;
                        treatment.localization = casedata.localization;
                        treatment.practice_id = casedata.practice_id.ToString();
                        treatment.treatment_date = casedata.treatment_date;
                        treatment.treatment_date_string = casedata.treatment_date.ToString("dd.MM.yyyy");
                        treatment.treatment_date_day_month = casedata.treatment_date.ToString("dd.MM.");
                        treatment.treatment_date_month_year = casedata.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                        treatment.status = "FS" + status;
                        treatment.case_id = casedata.case_id.ToString();
                        treatment.type = "op";
                        treatment.drug = casedata.drug_name;
                        treatment.drug_id = casedata.hec_drug_id.ToString();
                        treatment.patient_name = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name);
                        treatment.hip_name = patient_details.health_insurance_provider;
                        treatment.patient_birthdate = patient_details.birthday;
                        treatment.patient_id = casedata.patient_id.ToString();
                        treatment.patient_insurance_number = patient_details.insurance_id;
                        treatment.doctor_id = casedata.treatment_doctor_id.ToString();

                        treatments.Add(treatment);
                    }

                    #endregion OP

                    if (relevantActionCache.ContainsKey(casedata.case_id))
                    {
                        var relevant_case_actions = relevantActionCache[casedata.case_id];

                        #region AC

                        var ac_planned_action_type = "mm.docconect.doc.app.planned.action.aftercare";
                        if (relevant_case_actions.ContainsKey(ac_planned_action_type))
                        {
                            var relevant_aftercares = relevantActionCache[casedata.case_id][ac_planned_action_type].Where(t => t.IsPerformed).ToList();

                            for (int index = 0; index < filtered_aftercare_statuses.Count; index++)
                            {
                                var fs_status = filtered_aftercare_statuses[index];
                                if (index >= relevant_aftercares.Count)
                                {
                                    continue;
                                }

                                var aftercare_planned_action = relevant_aftercares[index];
                                if (!doctors_cache.ContainsKey(aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID))
                                {
                                    continue;
                                }

                                var aftercare_doctor = doctors_cache[aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                var status = fs_status.case_fs_status_code;

                                if (!performed_action_data.ContainsKey(aftercare_planned_action.PlannedAction_RefID))
                                {
                                    Console.WriteLine("Case number: {0}", casedata.case_number);
                                    continue;
                                }
                                var performed_action_details = performed_action_data[aftercare_planned_action.PlannedAction_RefID];
                                var diagnose_details = diagnose_cache[performed_action_details.DiagnoseID];

                                if (!practices_grouped_by_bpt.ContainsKey(aftercare_doctor.PracticeBPTID))
                                {
                                    continue;
                                }
                                var doctors_practice = practices_grouped_by_bpt[aftercare_doctor.PracticeBPTID];

                                if (status == 17)
                                {
                                    status = 8;
                                }
                                else if (status == 18)
                                {
                                    status = 10;
                                }

                                var treatment = new Submitted_Case_Model();
                                treatment.if_aftercare_treatment_date = casedata.treatment_date;
                                treatment.doctor_id = aftercare_doctor.DoctorID.ToString();
                                treatment.doctor_name = GenericUtils.GetDoctorNamePascal(aftercare_doctor);
                                treatment.doctor_lanr = aftercare_doctor.DoctorLANR;
                                treatment.practice_name = doctors_practice.PracticeName;
                                treatment.practice_bsnr = doctors_practice.PracticeBSNR;
                                treatment.practice_id = doctors_practice.PracticeID.ToString();
                                var ac_management_fee_value = ac_management_fee.Any() ? ac_management_fee.FirstOrDefault(t => t.HecBillPositionID == fs_status.hec_bill_position_id) : null;
                                treatment.management_pauschale = ac_management_fee_value == null ? "waived" : ac_management_fee_value.PropertyValue;
                                treatment.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
                                treatment.status_date = fs_status.status_date;
                                treatment.status_date_string = fs_status.status_date.ToString("dd.MM.yyyy");
                                treatment.diagnose = String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10);
                                treatment.diagnose_id = performed_action_details.DiagnoseID.ToString();
                                treatment.id = aftercare_planned_action.PlannedAction_RefID.ToString();
                                treatment.localization = casedata.localization;
                                treatment.treatment_date = performed_action_details.PerformedOnDate;
                                treatment.treatment_date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.yyyy");
                                treatment.treatment_date_day_month = performed_action_details.PerformedOnDate.ToString("dd.MM.");
                                treatment.treatment_date_month_year = performed_action_details.PerformedOnDate.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                                treatment.status = "FS" + status;
                                treatment.case_id = casedata.case_id.ToString();
                                treatment.type = "ac";
                                treatment.drug = casedata.drug_name;
                                treatment.drug_id = casedata.hec_drug_id.ToString();
                                treatment.patient_name = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name);
                                treatment.hip_name = patient_details.health_insurance_provider;
                                treatment.patient_birthdate = patient_details.birthday;
                                treatment.patient_id = casedata.patient_id.ToString();
                                treatment.patient_insurance_number = patient_details.insurance_id;

                                treatments.Add(treatment);
                            }
                        }

                        #endregion AC

                        #region OCTS

                        if (patientActionCache.ContainsKey(casedata.patient_id) && patientActionCache[casedata.patient_id].ContainsKey(casedata.localization) && patient_fs_status_cache.ContainsKey(casedata.patient_id) && patient_fs_status_cache[casedata.patient_id].ContainsKey(casedata.localization))
                        {
                            var filtered_oct_statuses = patient_fs_status_cache[casedata.patient_id][casedata.localization].Where(fs => fs.gpos_type == EGposType.Oct.Value()).ToList();
                            var relevant_octs = patientActionCache[casedata.patient_id][casedata.localization].Where(t => t.IsPerformed).ToList();

                            for (int index = 0; index < filtered_oct_statuses.Count; index++)
                            {
                                if (index >= relevant_octs.Count)
                                {
                                    continue;
                                }

                                var oct_planned_action = all_planned_actions.Single(t => t.HEC_ACT_PlannedActionID == relevant_octs[index].PlannedAction_RefID);
                                if (!performed_action_data.ContainsKey(oct_planned_action.HEC_ACT_PlannedActionID))
                                {
                                    continue;
                                }

                                var oct_doctor_details = doctors_cache[oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                var oct_doctors_practice = practices_grouped_by_bpt[oct_doctor_details.PracticeBPTID];

                                if (!performed_action_data.ContainsKey(oct_planned_action.HEC_ACT_PlannedActionID))
                                {
                                    Console.WriteLine("Case number: {0}", casedata.case_number);
                                    continue;
                                }
                                var performed_action_details = performed_action_data[oct_planned_action.HEC_ACT_PlannedActionID];
                                var diagnose_details = diagnose_cache[performed_action_details.DiagnoseID];
                                var fs_status = filtered_oct_statuses[index];
                                var status = fs_status.case_fs_status_code;

                                if (status == 17)
                                {
                                    status = 8;
                                }
                                else if (status == 18)
                                {
                                    status = 10;
                                }

                                var treatment = new Submitted_Case_Model();
                                treatment.if_aftercare_treatment_date = casedata.treatment_date;
                                treatment.doctor_id = oct_doctor_details.DoctorID.ToString();
                                treatment.doctor_name = GenericUtils.GetDoctorNamePascal(oct_doctor_details);
                                treatment.doctor_lanr = oct_doctor_details.DoctorLANR;
                                treatment.practice_name = oct_doctors_practice.PracticeName;
                                treatment.practice_bsnr = oct_doctors_practice.PracticeBSNR;
                                treatment.practice_id = oct_doctors_practice.PracticeID.ToString();
                                var oct_management_fee_value = oct_management_fee.Any() ? oct_management_fee.SingleOrDefault(t => t.HecBillPositionID == fs_status.hec_bill_position_id) : null;
                                treatment.management_pauschale = oct_management_fee_value == null ? "waived" : oct_management_fee_value.PropertyValue;
                                treatment.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
                                treatment.status_date = fs_status.status_date;
                                treatment.status_date_string = fs_status.status_date.ToString("dd.MM.yyyy");
                                treatment.diagnose = String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10);
                                treatment.diagnose_id = performed_action_details.DiagnoseID.ToString();
                                treatment.id = oct_planned_action.HEC_ACT_PlannedActionID.ToString();
                                treatment.localization = casedata.localization;
                                treatment.treatment_date = performed_action_details.PerformedOnDate;
                                treatment.treatment_date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.yyyy");
                                treatment.treatment_date_day_month = performed_action_details.PerformedOnDate.ToString("dd.MM.");
                                treatment.treatment_date_month_year = performed_action_details.PerformedOnDate.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                                treatment.status = "FS" + status;
                                treatment.case_id = casedata.case_id.ToString();
                                treatment.type = "oct";
                                treatment.drug = casedata.drug_name;
                                treatment.drug_id = casedata.hec_drug_id.ToString();
                                treatment.patient_name = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name);
                                treatment.hip_name = patient_details.health_insurance_provider;
                                treatment.patient_birthdate = patient_details.birthday;
                                treatment.patient_id = casedata.patient_id.ToString();
                                treatment.patient_insurance_number = patient_details.insurance_id;

                                treatments.Add(treatment);
                            }
                        }

                        #endregion OCTS
                    }

                    Console.Write("\rTreatments {0} of {1} updated.                ", i++, all_cases.Length);

                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return treatments;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Treatments section elastic rebuild", ex);
            }
        }

        public static List<Archive_Model> RebuildArchive(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();
            var Transaction = Connection.BeginTransaction();
            List<Archive_Model> archiveL = new List<Archive_Model>();

            try
            {
                var archiveData = cls_Get_Archive_data_for_Elastic.Invoke(Connection, Transaction, securityTicket).Result;
                var i = 1;
                var dummyGuid = Guid.Empty;
                foreach (var archiveItem in archiveData.Where(t => t.gpmid == "pdf mm" || String.IsNullOrEmpty(t.gpmid) || Guid.TryParse(t.gpmid, out dummyGuid)))
                {
                    Archive_Model archive = new Archive_Model();
                    archive.id = archiveItem.id.ToString();
                    archive.documentId = archiveItem.document_id;
                    archive.description = archiveItem.description;
                    archive.filedate = archiveItem.file_date.Date;
                    archive.datestring = archiveItem.file_date.ToString("dd.MM.yyyy");
                    archive.creationtimestamp = new DateTime(archiveItem.file_date.Year, archiveItem.file_date.Month, archiveItem.file_date.Day, archiveItem.file_date.Hour, archiveItem.file_date.Minute, 0);
                    archive.recipient = archiveItem.recipient;
                    archive.filetype = archiveItem.file_type;
                    archiveL.Add(archive);

                    Console.Write("\rArchive {0} of {1} updated.                ", i++, archiveL.Count());
                }
                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return archiveL;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Archive section elastic rebuild", ex);
            }
        }

        public static List<Receipt_Model> RebuildReceipt(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();
            var Transaction = Connection.BeginTransaction();
            List<Receipt_Model> receiptL = new List<Receipt_Model>();
            try
            {
                var receiptData = cls_Get_Receipt_data_for_Elastic.Invoke(Connection, Transaction, securityTicket).Result;

                var existingReceipts = Retrieve_Receipts.Get_Receipt_Items(securityTicket);

                foreach (var receiptItem in receiptData)
                {
                    var existingReceipt = existingReceipts.SingleOrDefault(t => t.id == receiptItem.id.ToString());

                    Receipt_Model receipt = new Receipt_Model();
                    receipt.id = receiptItem.id.ToString();
                    receipt.documentID = receiptItem.document_id.ToString();
                    receipt.filedate = receiptItem.file_date;
                    receipt.filedateString = receiptItem.file_date.ToString("dd.MM.yyyy");
                    receipt.amount = string.Format("{0:n}", receiptItem.file_type) + " €";
                    receipt.amountNo = string.IsNullOrEmpty(receiptItem.file_type) ? 0 : Int32.Parse(receiptItem.file_type);
                    receipt.doctorID = receiptItem.recipient;
                    receipt.period = receiptItem.description;
                    receipt.periodDate = receiptItem.file_date;
                    if (existingReceipt != null)
                    {
                        receipt.isViewed = existingReceipt.isViewed;
                    }

                    receiptL.Add(receipt);
                }
                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return receiptL;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during Receipt section elastic rebuild", ex);
            }
        }

        public static List<Oct_Model> RebuildOct(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();
            var Transaction = Connection.BeginTransaction();
            List<Oct_Model> octs = new List<Oct_Model>();

            try
            {
                var dbOcts = cls_Get_Octs_for_ElasticRebuild.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.GroupBy(r => r.Localization).ToDictionary(x => x.Key, x => x));
                var i = 1;

                if (dbOcts.Any())
                {
                    var octGposCatalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
                    {
                        GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.voruntersuchung",
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    var oct_planned_action_type_gpmid = "mm.docconect.doc.app.planned.action.oct";

                    var oct_planned_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, new ORM_HEC_ACT_ActionType.Query()
                    {
                        GlobalPropertyMatchingID = oct_planned_action_type_gpmid,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (oct_planned_action_type == null)
                    {
                        oct_planned_action_type = new ORM_HEC_ACT_ActionType();
                        oct_planned_action_type.GlobalPropertyMatchingID = oct_planned_action_type_gpmid;
                        oct_planned_action_type.Modification_Timestamp = DateTime.Now;
                        oct_planned_action_type.Tenant_RefID = securityTicket.TenantID;

                        oct_planned_action_type.Save(Connection, Transaction);
                    }

                    var gposIds = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode.Query() { PotentialCode_Catalog_RefID = octGposCatalog.HEC_BIL_PotentialCode_CatalogID }).Select(t => t.HEC_BIL_PotentialCodeID).ToArray();
                    var diagnose_cache = cls_Get_Diagnose_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.diagnose_id).ToDictionary(t => t.Key, t => t.Single());

                    var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                    var patientConsents = cls_Get_Patient_Consents_on_Contract_for_GposIDs_on_Tenant.Invoke(Connection, Transaction, new P_PA_GPCbDaGposIDs_1154() { GposIDs = gposIds }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());

                    var performedOpAndOctDates = cls_Get_Oct_and_OP_Dates_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.OrderBy(t => t.TreatmentDate).GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.GroupBy(r => r.Localization).ToDictionary(x => x.Key, x => x.ToList()));

                    var octFsStatuses = cls_Get_Oct_FsStatusCodes_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(x => x.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(r => r.localization).ToDictionary(r => r.Key, r => r.ToList()));
                    var octPerformedDates = cls_Get_PerformedOnDates_for_PlannedActionTypeID_on_Tenant.Invoke(Connection, Transaction, new P_CAS_GPoDfPATIDoT_1509() { PlannedActionTypeID = oct_planned_action_type.HEC_ACT_ActionTypeID }, securityTicket).Result
                        .GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(r => r.localization).ToDictionary(x => x.Key, x => x.ToList()));
                    var patientHipIKNumbers = cls_Get_Patient_IK_Numbers_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(x => x.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(r => r.patient_id).ToDictionary(r => r.Key, r => r.First()));
                    var doctor_properties = cls_Get_Doctor_Properties.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(x => x.DoctorID).ToDictionary(x => x.Key, x => x.ToList());
                    var last_ivom_dates = cls_Get_Latest_NonError_NonCancelled_OpDate_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(x => x.patient_id).ToDictionary(x => x.Key, x => x.GroupBy(t => t.localization_code).ToDictionary(t => t.Key, t => t.ToList()));

                    var culture = new System.Globalization.CultureInfo("de", true);

                    var hip_ik = String.Empty;
                    var patient_hip_name = String.Empty;

                    foreach (var patientOcts in dbOcts)
                    {
                        var opAndOctDates = performedOpAndOctDates[patientOcts.Key];
                        var patientOctFsStatuses = octFsStatuses.ContainsKey(patientOcts.Key) ? octFsStatuses[patientOcts.Key] : new Dictionary<string, List<CAS_GOFsSCoT_1516>>();
                        var patientOctPerformedOnDates = octPerformedDates.ContainsKey(patientOcts.Key) ? octPerformedDates[patientOcts.Key] : new Dictionary<string, List<CAS_GPoDfPATIDoT_1509>>();

                        foreach (var localizationOcts in patientOcts.Value)
                        {
                            foreach (var oct in localizationOcts.Value)
                            {
                                if (!patientConsents.ContainsKey(oct.PatientID))
                                {
                                    continue;
                                }

                                var consents = patientConsents[oct.PatientID];
                                var lastPotentialConsent = consents.Where(t => t.consent_valid_from.Date <= oct.TreatmentDate.Date).OrderBy(t => t.consent_valid_from).FirstOrDefault();
                                var treatmentYearLength = 365d;
                                var maxOctsPerTreatmentYear = 6d;
                                var useSettlementYear = false;

                                if (lastPotentialConsent != null)
                                {
                                    useSettlementYear = allContractParameters[lastPotentialConsent.contract_id].Any(t => t.ParameterName == EContractParameter.UseSettlementYear.Value());

                                    var treatmentYearLengthContractParameter = allContractParameters[lastPotentialConsent.contract_id].SingleOrDefault(t => t.ParameterName == EContractParameter.TreatmentYearLength.Value());
                                    if (treatmentYearLengthContractParameter != null)
                                    {
                                        treatmentYearLength = treatmentYearLengthContractParameter.IfNumericValue_Value;
                                    }
                                }
                                else
                                {
                                    continue;
                                }

                                var allDates = useSettlementYear ? opAndOctDates.SelectMany(x => x.Value.Where(t => !t.IsOp)).ToList() : opAndOctDates[oct.Localization].ToList();

                                var patientOctFsStatusesForLocalization = useSettlementYear ? patientOctFsStatuses.SelectMany(t => t.Value).ToList() :
                                    patientOctFsStatuses.ContainsKey(localizationOcts.Key) ? patientOctFsStatuses[localizationOcts.Key] : new List<CAS_GOFsSCoT_1516>();
                                var patientOctPerformedOnDatesForLocalization = useSettlementYear ? patientOctPerformedOnDates.SelectMany(t => t.Value).ToList() :
                                    patientOctPerformedOnDates.ContainsKey(localizationOcts.Key) ? patientOctPerformedOnDates[localizationOcts.Key] : new List<CAS_GPoDfPATIDoT_1509>();

                                if (patientHipIKNumbers.ContainsKey(oct.PatientID))
                                {
                                    var hip = patientHipIKNumbers[oct.PatientID].First().Value;
                                    hip_ik = hip.ik_number;
                                    patient_hip_name = hip.hip_name;
                                }

                                var nonErrorOctDates = new List<DateTime>();
                                var nonErrorOctDatesOnLocalization = new List<DateTime>();
                                if (patientOctFsStatusesForLocalization.Any())
                                {
                                    for (var j = 0; j < patientOctPerformedOnDatesForLocalization.Count; j++)
                                    {
                                        if (patientOctPerformedOnDatesForLocalization.Count <= j || patientOctFsStatusesForLocalization.Count <= j)
                                        {
                                            break;
                                        }

                                        var oct_date = patientOctPerformedOnDatesForLocalization[j];
                                        var oct_fs_status_code = patientOctFsStatusesForLocalization[j].fs_status_code;
                                        if (oct_fs_status_code != 8 && oct_fs_status_code != 11 && oct_fs_status_code != 17)
                                        {
                                            nonErrorOctDates.Add(oct_date.date.Date);
                                            if (oct_date.localization == oct.Localization)
                                            {
                                                nonErrorOctDatesOnLocalization.Add(oct_date.date.Date);
                                            }
                                        }
                                        else
                                        {
                                            allDates = allDates.Where(t => t.ActionID != patientOctPerformedOnDatesForLocalization[j].id).ToList();
                                        }
                                    }
                                }

                                #region Treatment year date

                                var treatmentYearStartDate = oct.TreatmentDate.Date;
                                var treatmentYearEndDate = oct.TreatmentDate.Date.AddDays(treatmentYearLength);

                                if (allDates.Any())
                                {
                                    var latestPerformedOctDate = allDates.LastOrDefault(t => !t.IsOp);
                                    var dateToCheck = latestPerformedOctDate != null ? latestPerformedOctDate.TreatmentDate.Date : oct.TreatmentDate.Date;
                                    var firstOpOrOctDate = DateTime.MinValue;

                                    var gaps = allDates.Where(t =>
                                    {
                                        var isLast = allDates.Last().TreatmentDate == t.TreatmentDate;
                                        if (isLast)
                                        {
                                            return false;
                                        }
                                        var gapExists = !allDates.Any(r => r.TreatmentDate > t.TreatmentDate && r.TreatmentDate < t.TreatmentDate.AddDays(treatmentYearLength));
                                        return useSettlementYear ? gapExists && !t.IsOp : gapExists && t.IsOp;
                                    }).ToList();

                                    if (!gaps.Any())
                                    {
                                        var firstDate = allDates.FirstOrDefault(t =>
                                        {
                                            var typeSpecificationMet = useSettlementYear ? !t.IsOp : true;
                                            return t.TreatmentDate <= dateToCheck && typeSpecificationMet;
                                        });

                                        if (firstDate != null)
                                        {
                                            firstOpOrOctDate = firstDate.TreatmentDate;
                                        }
                                    }
                                    else
                                    {
                                        firstOpOrOctDate = gaps.Select(t => t.TreatmentDate).Where(t => t <= dateToCheck).DefaultIfEmpty().Max();
                                    }

                                    if (firstOpOrOctDate != DateTime.MinValue)
                                    {
                                        while (firstOpOrOctDate.AddDays(treatmentYearLength) < dateToCheck)
                                        {
                                            firstOpOrOctDate = firstOpOrOctDate.AddDays(treatmentYearLength);
                                        }

                                        treatmentYearStartDate = firstOpOrOctDate;
                                        treatmentYearEndDate = firstOpOrOctDate.AddDays(treatmentYearLength);
                                    }
                                }
                                #endregion

                                var latestOctDate = nonErrorOctDatesOnLocalization.Where(t => t.Date >= treatmentYearStartDate && t.Date < treatmentYearEndDate).DefaultIfEmpty().Max();

                                var octsPerformedDatesInTreatmentYear = patientOctPerformedOnDatesForLocalization.Where(t => t.date.Date >= treatmentYearStartDate && t.date.Date < treatmentYearEndDate).ToList();
                                var caseIds = octsPerformedDatesInTreatmentYear.Select(t => t.case_id).ToList();

                                var performedOpExists = useSettlementYear ?
                                    opAndOctDates.SelectMany(t => t.Value).Any(t =>
                                    {
                                        var isOpAndPerformed = t.IsOp && t.IsOpPerformed;
                                        var isOpDateInRequiredTimespan = t.TreatmentDate.Date <= latestOctDate.Date && t.TreatmentDate.Date >= latestOctDate.AddDays(-treatmentYearLength).Date || caseIds.Any(cid => cid == t.CaseID);
                                        var isOpInCurrentTreatmentYear = t.TreatmentDate.Date >= treatmentYearStartDate && t.TreatmentDate.Date < treatmentYearEndDate;

                                        return isOpAndPerformed && (isOpDateInRequiredTimespan || isOpInCurrentTreatmentYear);
                                    }) :
                                    opAndOctDates.ContainsKey(oct.Localization) ?
                                    opAndOctDates[oct.Localization].Any(t =>
                                    {

                                        var isOpAndPerformed = t.IsOp && t.IsOpPerformed;
                                        var isOpDateInRequiredTimespan = t.TreatmentDate <= latestOctDate && t.TreatmentDate.Date >= latestOctDate.AddDays(-treatmentYearLength).Date;
                                        var isOpInCurrentTreatmentYear = t.TreatmentDate.Date >= treatmentYearStartDate && t.TreatmentDate.Date < treatmentYearEndDate;

                                        return isOpAndPerformed && (isOpDateInRequiredTimespan || isOpInCurrentTreatmentYear);
                                    }) : false;

                                var treatmentYearOcts = nonErrorOctDates.Count(t => t >= treatmentYearStartDate.Date && t <= treatmentYearEndDate.Date);

                                var octStatus = "OCT1";
                                if (oct.IsCancelled)
                                {
                                    octStatus = "OCT4";
                                }
                                else if (nonErrorOctDatesOnLocalization.Count == 1 && !performedOpExists)
                                {
                                    octStatus = "OCT6";
                                }


                                var diagnose_details = diagnose_cache[oct.DiagnoseID];

                                var last_ivoms_for_patient = last_ivom_dates.ContainsKey(oct.PatientID) ? last_ivom_dates[oct.PatientID] : new Dictionary<string, List<CAS_GLNENCODfT_1936>>();
                                var last_ivom_date_list = last_ivoms_for_patient != null && last_ivoms_for_patient.ContainsKey(oct.Localization) ? last_ivoms_for_patient[oct.Localization] : new List<CAS_GLNENCODfT_1936>();
                                var last_ivom_date = last_ivom_date_list.Any() ? last_ivom_date_list.Select(x => x.treatment_date).Max() : DateTime.MinValue;
                                var treatment_date = last_ivom_date != null && last_ivom_date != DateTime.MinValue ? last_ivom_date : oct.TreatmentDate;

                                var existing_oct = octs.FirstOrDefault(t => t.patient_id == oct.PatientID && t.localization == oct.Localization);
                                if (existing_oct != null)
                                {
                                    if (existing_oct.treatment_year_date <= treatmentYearStartDate)
                                    {
                                        existing_oct.treatment_year_date = treatmentYearStartDate;
                                        existing_oct.treatment_year_octs = treatmentYearOcts;
                                        existing_oct.oct_date = latestOctDate;
                                        existing_oct.treatment_date = treatment_date;
                                        existing_oct.oct_doctor_id = oct.OctDoctorID;
                                        existing_oct.oct_doctor_name = oct.OctDoctorName;
                                        existing_oct.treatment_doctor_id = oct.OpDoctorID;
                                        existing_oct.treatment_doctor_name = oct.OpDoctorName;
                                        existing_oct.treatment_doctor_practice_id = oct.OpPracticeID;
                                        existing_oct.treatment_doctor_practice_name = oct.OpPracticeName;
                                        existing_oct.practice_id = oct.OctPracticeID;
                                        existing_oct.status = octStatus;
                                        existing_oct.diagnose_id = oct.DiagnoseID;
                                        existing_oct.diagnose = String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10);
                                        existing_oct.id = oct.ID.ToString();
                                    }

                                    continue;
                                }

                                var oct_entry = new Oct_Model()
                                {
                                    case_id = oct.CaseID,
                                    diagnose = String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10),
                                    diagnose_id = oct.DiagnoseID,
                                    id = oct.ID.ToString(),
                                    localization = oct.Localization,
                                    oct_doctor_id = oct.OctDoctorID,
                                    oct_doctor_name = oct.OctDoctorName,
                                    patient_birthdate = oct.PatientBirthDate.Date,
                                    patient_name = oct.PatientName,
                                    patient_id = oct.PatientID,
                                    practice_id = oct.OctPracticeID,
                                    treatment_date = treatment_date,
                                    treatment_doctor_id = oct.OpDoctorID,
                                    treatment_doctor_name = oct.OpDoctorName,
                                    treatment_doctor_practice_id = oct.OpPracticeID,
                                    treatment_doctor_practice_name = oct.OpPracticeName,
                                    status = octStatus,
                                    treatment_year_date = treatmentYearStartDate,
                                    treatment_year_octs = treatmentYearOcts,
                                    oct_date = latestOctDate,
                                    hip_ik = hip_ik,
                                    patient_hip = patient_hip_name
                                };

                                if (oct_entry.treatment_year_octs == maxOctsPerTreatmentYear)
                                {
                                    var anyPerformedOpDate = opAndOctDates.Any(t => t.Value.Any(x => x.IsOp && x.TreatmentDate.Date >= treatmentYearStartDate && x.TreatmentDate.Date < treatmentYearEndDate));

                                    var next_treatment_year_start_date = oct_entry.treatment_year_date.AddDays(treatmentYearLength).Date;
                                    if (anyPerformedOpDate && next_treatment_year_start_date <= DateTime.Now.Date)
                                    {
                                        oct_entry.treatment_year_octs = 0;
                                        oct_entry.treatment_year_date = next_treatment_year_start_date;
                                    }
                                }

                                octs.Add(oct_entry);
                            }
                        }

                        Console.Write("\rOct {0} of {1} updated.                ", i++, dbOcts.Count);

                    }
                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
                Console.WriteLine();
                return octs;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during OCT section elastic rebuild", ex);
            }
        }
    }
}