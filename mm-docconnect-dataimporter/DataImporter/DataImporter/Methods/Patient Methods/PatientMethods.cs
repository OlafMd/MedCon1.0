using CL1_CMN_BPT_CTM;
using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_ACT;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.DBMethods.Pharmacy.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataImporter.Methods.Patient_Methods
{
    public static class PatientMethods
    {
        public static List<PatientDetailViewModel> RebuildPatientDetails(string connectionString, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
            if (cleanupConnection == true)
            {
                Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                Connection.Open();
            }
            if (cleanupTransaction == true)
            {
                Transaction = Connection.BeginTransaction();
            }
            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

                var gposAssignmentsCountCache = cls_Get_Number_of_GposTypes_on_Case_for_CaseID_and_GposType.Invoke(Connection, Transaction, new P_CAS_GNoGPOSToCfCIDaGPOST_1023()
                {
                    GposType = EGposType.Operation.Value()
                }, securityTicket).Result.GroupBy(t => t.CaseID).Select(gr => new { Key = gr.Key, Value = gr.Single().NumberOfTreatmentGposes }).ToDictionary(t => t.Key, t => t.Value);
                var sw = new Stopwatch();

                Console.WriteLine("\nFetching all patient information");
                sw.Start();
                var all_Patients = cls_Get_All_Patients_from_DB.Invoke(Connection, Transaction, securityTicket).Result;
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching all case information");
                var allCases = cls_Get_All_Cases_from_DB_for_ElasticRebuild.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching all patient consent information");
                var patientConsentsCache = cls_Get_PatientParticipationConsents_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching order history");
                var orderStatusHistoryCache = cls_Get_Order_Status_History_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.header_id).ToDictionary(x => x.Key, x => x.ToList());

                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching doctors");
                var doctors_cache = cls_Get_Doctor_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching planned actions");
                var all_planned_actions = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();

                Console.WriteLine("Fetching relevant planned actions");
                Dictionary<Guid, Dictionary<string, List<CAS_GRADoT_1007>>> relevantActionCache, patientActionCache;
                RelevantActions(securityTicket, Connection, Transaction, out relevantActionCache, out patientActionCache);  // Olaf
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching report downloaded case properties");
                var reportDownloadedCache = cls_Get_Report_Downloaded_PropertyValues_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching practices");
                var all_practices = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching performed action data");
                var performed_action_data = cls_Get_PerformedActionData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.ActionID).ToDictionary(t => t.Key, t => t.Single());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching diagnoses");
                var diagnose_cache = cls_Get_Diagnose_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.diagnose_id).ToDictionary(t => t.Key, t => t.Single());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();

                sw.Start();
                Console.WriteLine("Fetching case fs statuses");
                Dictionary<Guid, List<CAS_GCFSSoT_1728>> case_fs_status_cache;
                Dictionary<Guid, Dictionary<string, List<CAS_GCFSSoT_1728>>> patient_fs_status_cache;
                fs_status_cache(securityTicket, Connection, Transaction, out case_fs_status_cache, out patient_fs_status_cache);
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);

                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching case previous fs statuses");
                Dictionary<Guid, List<CAS_GPFSSoT_1420>> previous_status_cache = PrevStatusCache(securityTicket, Connection, Transaction);
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);

                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching pharmacies");
                var pahrmacies_cache = cls_Get_Pharamcy_Info_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.pharmacy_supplier_id).ToDictionary(t => t.Key, t => t.Single());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);

                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching performed OCT data");
                var performed_oct_data = cls_Get_PerformedActionData_for_ActionTypeID_on_Tenant.Invoke(Connection, Transaction, new P_CAS_GPADfATID_1212()
                {
                    ActionTypeGpmID = EActionType.PerformedOct.Value()
                }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching patient properties");
                var patient_properties = cls_Get_PatientProperties_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
                Console.WriteLine("Fetching case properties");
                var fake_op_properties = cls_Get_CaseProperties_for_PropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPfPGpmID_0821()
                {
                    PropertyGpmID = ECaseProperty.FakeCase.Value()
                }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());
                var documentation_cases = cls_Get_CaseProperties_for_PropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPfPGpmID_0821()
                {
                    PropertyGpmID = ECaseProperty.DocumentationOnly.Value()
                }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());
                sw.Stop();
                Console.WriteLine("Elapsed: {0}ms\n", sw.ElapsedMilliseconds);
                sw.Reset();
                sw.Start();
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

                var existingPatientDetailsDownloadStatuses = new Dictionary<string, bool>();
                var elasticConnection = Elastic_Utils.ElsaticConnection();
                if (Elastic_Utils.IfIndexOrTypeExists(String.Format("{0}/{1}", securityTicket.TenantID.ToString(), "patient"), elasticConnection))
                {
                    var serializer = new JsonNetSerializer();
                    var command = Commands.Search(securityTicket.TenantID.ToString(), "settlement").Pretty();
                    var query = new QueryBuilder<Settlement_Model>().Size(int.MaxValue).BuildBeautified();
                    existingPatientDetailsDownloadStatuses = GetPostElestic(elasticConnection, serializer, command, query);
                }

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
                var octFsStatuses = cls_Get_Oct_FsStatusCodes_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(x => x.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(r => r.localization).ToDictionary(r => r.Key, r => r.ToList()));
                var octPerformedDates = cls_Get_PerformedOnDates_for_PlannedActionTypeID_on_Tenant.Invoke(Connection, Transaction, new P_CAS_GPoDfPATIDoT_1509() { PlannedActionTypeID = oct_planned_action_type.HEC_ACT_ActionTypeID }, securityTicket).Result
                    .GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(r => r.localization).ToDictionary(x => x.Key, x => x.ToList()));

                var patientsUpdated = 1;
                foreach (var patient in all_Patients)
                {
                    if (patientsUpdated < 6500)
                    {
                        // Console.Write("\rPatient {0} of {1} skipped.                ", patientsUpdated++, all_Patients.Length);
                        // continue;
                    }
                    #region Consents

                    if (patientConsentsCache.ContainsKey(patient.Id))
                    {
                        var patientParticipations = patientConsentsCache[patient.Id];
                        foreach (var item in patientParticipations)
                        {
                            PatientDetailViewModel elasticPatientDetailModel = new PatientDetailViewModel();
                            elasticPatientDetailModel.id = item.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID.ToString();
                            elasticPatientDetailModel.patient_id = patient.Id.ToString();
                            elasticPatientDetailModel.practice_id = patient.PracticeID.ToString();
                            elasticPatientDetailModel.date = item.participationFrom;
                            elasticPatientDetailModel.date_string = item.participationFrom.ToString("dd.MM.");
                            elasticPatientDetailModel.detail_type = "participation";
                            elasticPatientDetailModel.case_id = item.contractID.ToString();
                            elasticPatientDetailModel.status = "";

                            patientDetailList.Add(elasticPatientDetailModel);
                        }
                    }

                    #endregion Consents

                    if (allCases.ContainsKey(patient.Id))
                    {
                        var patientCases = allCases[patient.Id].Where(i => !fake_op_properties.ContainsKey(i.case_id)).ToList();

                        foreach (var p_case in patientCases)
                        {
                            var ac_op_billed_together = gposAssignmentsCountCache.ContainsKey(p_case.case_id) ? gposAssignmentsCountCache[p_case.case_id] > 1 : false;

                            #region Orders
                            if (p_case.order_header_id != Guid.Empty)
                            {
                                var patient_detail = new PatientDetailViewModel();

                                patient_detail.case_id = p_case.case_id.ToString();
                                patient_detail.date = p_case.order_delivery_date > p_case.treatment_date && p_case.localization != null ? p_case.treatment_date : p_case.order_delivery_date;
                                patient_detail.date_string = patient_detail.date.ToString("dd.MM.");
                                patient_detail.practice_id = patient.PracticeID.ToString();
                                patient_detail.detail_type = "order";
                                patient_detail.diagnose_or_medication = p_case.drug_name;
                                patient_detail.id = p_case.order_header_id.ToString();
                                patient_detail.status = p_case.order_status == 7 ? "MO6" : p_case.order_header_id != Guid.Empty ? "MO" + p_case.order_status : "";
                                patient_detail.order_status = p_case.order_status == 7 ? "MO6" : p_case.order_header_id != Guid.Empty ? "MO" + p_case.order_status : "";
                                patient_detail.hip_ik = patient.HealthInsurance_IKNumber;

                                if (patient_detail.status == "MO6")
                                {
                                    var order_status_history = orderStatusHistoryCache[p_case.order_header_id];
                                    patient_detail.previous_order_status = "MO" + order_status_history.First(t => t.order_status_code != 6 && t.order_status_code != 7).order_status_code;
                                }
                                patient_detail.patient_id = patient.Id.ToString();
                                patient_detail.drug_id = p_case.hec_drug_id.ToString();
                                patient_detail.order_id = p_case.order_header_id.ToString();

                                if (pahrmacies_cache.ContainsKey(p_case.pharmacy_supplier_id))
                                {
                                    var pharmacy = pahrmacies_cache[p_case.pharmacy_supplier_id];
                                    patient_detail.pharmacy_id = pharmacy.pharmacy_id.ToString();
                                    patient_detail.pharmacy_name = pharmacy.pharmacy_name;
                                }

                                patientDetailList.Add(patient_detail);
                            }

                            #endregion Orders

                            #region Cases

                            #region Settlement

                            if (case_fs_status_cache.ContainsKey(p_case.case_id))
                            {
                                var case_fs_statuses = case_fs_status_cache[p_case.case_id];
                                var filtered_treatment_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 230).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == EGposType.Operation.Value()).ToList();
                                var filtered_aftercare_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 60).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == EGposType.Aftercare.Value()).ToList();

                                #region OP

                                foreach (var fs_status in filtered_treatment_statuses)
                                {
                                    var settlement = new PatientDetailViewModel();

                                    #region Aftercare

                                    if (doctors_cache.ContainsKey(p_case.aftercare_bpt))
                                    {
                                        var aftercare_doctor = doctors_cache[p_case.aftercare_bpt];
                                        settlement.aftercare_doctor_practice_id = aftercare_doctor.DoctorID.ToString();

                                        if (practices_grouped_by_bpt.ContainsKey(aftercare_doctor.PracticeBPTID))
                                        {
                                            var doctors_practice = practices_grouped_by_bpt[aftercare_doctor.PracticeBPTID];
                                            settlement.practice_id = doctors_practice.PracticeID.ToString();
                                        }
                                    }
                                    else if (practices_grouped_by_bpt.ContainsKey(p_case.aftercare_bpt))
                                    {
                                        var aftercare_practice = practices_grouped_by_bpt[p_case.aftercare_bpt];
                                        settlement.aftercare_doctor_practice_id = aftercare_practice.PracticeID.ToString();
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
                                        if (previous_status_cache.ContainsKey(p_case.case_id))
                                        {
                                            var gpmid = EGposType.Operation.Value();

                                            var case_previous_statuses = previous_status_cache[p_case.case_id];
                                            var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == gpmid);
                                            if (previous_status != null)
                                            {
                                                settlement.status = "FS" + previous_status.previous_status;
                                            }
                                        }
                                    }

                                    #endregion FS status

                                    settlement.id = p_case.treatment_planned_action_id.ToString();
                                    settlement.if_settlement_is_report_downloaded = existingPatientDetailsDownloadStatuses.ContainsKey(settlement.id) ? existingPatientDetailsDownloadStatuses[settlement.id] : false;
                                    settlement.diagnose_or_medication = p_case.diagnose_name;
                                    settlement.diagnose_id = p_case.diagnose_id.ToString();
                                    settlement.doctor = p_case.treatment_doctor_name;
                                    settlement.localisation = p_case.localization;
                                    settlement.practice_id = p_case.practice_id.ToString();
                                    settlement.date = p_case.treatment_date;
                                    settlement.date_string = p_case.treatment_date.ToString("dd.MM.");
                                    settlement.case_id = p_case.case_id.ToString();
                                    settlement.detail_type = "op";
                                    settlement.order_status = p_case.order_status == 7 ? "MO6" : p_case.order_header_id != Guid.Empty ? "MO" + p_case.order_status : "";
                                    settlement.drug = p_case.drug_name;
                                    settlement.drug_id = p_case.hec_drug_id.ToString();
                                    settlement.patient_id = p_case.patient_id.ToString();
                                    settlement.treatment_doctor_id = p_case.treatment_doctor_id.ToString();
                                    settlement.hip_ik = patient.HealthInsurance_IKNumber;

                                    patientDetailList.Add(settlement);
                                }

                                #endregion OP

                                if (relevantActionCache.ContainsKey(p_case.case_id))
                                {
                                    var relevant_case_actions = relevantActionCache[p_case.case_id];

                                    #region AC

                                    var ac_planned_action_type = "mm.docconect.doc.app.planned.action.aftercare";
                                    if (relevant_case_actions.ContainsKey(ac_planned_action_type))
                                    {
                                        var relevant_aftercares = relevant_case_actions[ac_planned_action_type].Where(t => t.IsPerformed).ToList();

                                        #region Open Ac

                                        if (relevant_case_actions[ac_planned_action_type].Any(t => !t.IsPerformed))
                                        {
                                            var unsubmitted_aftercares = relevant_case_actions[ac_planned_action_type].Where(t => !t.IsPerformed).ToList();

                                            foreach (var unsubmitted_aftercare in unsubmitted_aftercares)
                                            {
                                                var patientDetal_elastic = new PatientDetailViewModel();
                                                patientDetal_elastic.case_id = p_case.case_id.ToString();
                                                patientDetal_elastic.id = unsubmitted_aftercare.PlannedAction_RefID.ToString();
                                                patientDetal_elastic.date = p_case.treatment_date;
                                                patientDetal_elastic.date_string = p_case.treatment_date.ToString("dd.MM.");
                                                patientDetal_elastic.detail_type = "ac";

                                                #region Aftercare doctor/practice

                                                if (doctors_cache.ContainsKey(unsubmitted_aftercare.ToBePerformedBy_BusinessParticipant_RefID))
                                                {
                                                    var aftercare_doctor = doctors_cache[unsubmitted_aftercare.ToBePerformedBy_BusinessParticipant_RefID];
                                                    patientDetal_elastic.aftercare_doctor_practice_id = aftercare_doctor.DoctorID.ToString();
                                                    patientDetal_elastic.doctor = GenericUtils.GetDoctorNamePascal(aftercare_doctor);

                                                    if (practices_grouped_by_bpt.ContainsKey(aftercare_doctor.PracticeBPTID))
                                                    {
                                                        var doctors_practice = practices_grouped_by_bpt[aftercare_doctor.PracticeBPTID];
                                                        patientDetal_elastic.practice_id = doctors_practice.PracticeID.ToString();
                                                    }
                                                }
                                                else if (practices_grouped_by_bpt.ContainsKey(unsubmitted_aftercare.ToBePerformedBy_BusinessParticipant_RefID))
                                                {
                                                    var aftercare_practice = practices_grouped_by_bpt[unsubmitted_aftercare.ToBePerformedBy_BusinessParticipant_RefID];
                                                    patientDetal_elastic.aftercare_doctor_practice_id = aftercare_practice.PracticeID.ToString();
                                                    patientDetal_elastic.doctor = aftercare_practice.PracticeName;
                                                    patientDetal_elastic.practice_id = aftercare_practice.PracticeID.ToString();
                                                }

                                                #endregion Aftercare doctor/practice

                                                patientDetal_elastic.order_status = p_case.order_status == 7 ? "MO6" : p_case.order_header_id != Guid.Empty ? "MO" + p_case.order_status : "";
                                                patientDetal_elastic.drug = p_case.drug_name;
                                                patientDetal_elastic.treatment_doctor_id = p_case.treatment_doctor_id.ToString();
                                                patientDetal_elastic.diagnose_or_medication = p_case.diagnose_name == null ? "" : p_case.diagnose_name;
                                                patientDetal_elastic.localisation = p_case.localization == null ? "-" : p_case.localization;
                                                patientDetal_elastic.patient_id = p_case.patient_id.ToString();
                                                patientDetal_elastic.status = unsubmitted_aftercare.IsCancelled ? "AC4" : "AC1";
                                                patientDetal_elastic.diagnose_id = p_case.diagnose_id != Guid.Empty ? p_case.diagnose_id.ToString() : "";
                                                patientDetal_elastic.drug_id = p_case.hec_drug_id.ToString();
                                                patientDetal_elastic.drug = p_case.drug_name;

                                                patientDetal_elastic.order_id = p_case.order_header_id != Guid.Empty ? p_case.order_header_id.ToString() : "";
                                                patientDetal_elastic.hip_ik = patient.HealthInsurance_IKNumber;

                                                patientDetailList.Add(patientDetal_elastic);
                                            }
                                        }

                                        #endregion Open Ac

                                        if (relevant_aftercares.Any())
                                        {
                                            for (int index = 0; index < filtered_aftercare_statuses.Count; index++)
                                            {
                                                var settlement = new PatientDetailViewModel();

                                                if (index >= relevant_aftercares.Count)
                                                {
                                                    continue;
                                                }

                                                var aftercare_planned_action = relevant_aftercares[index];

                                                if (!performed_action_data.ContainsKey(aftercare_planned_action.PlannedAction_RefID))
                                                {
                                                    Console.WriteLine("Case number: {0}", p_case.case_number);
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
                                                    if (previous_status_cache.ContainsKey(p_case.case_id))
                                                    {
                                                        var gpmid = "mm.docconnect.gpos.catalog.nachsorge";

                                                        var case_previous_statuses = previous_status_cache[p_case.case_id];
                                                        var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == gpmid);
                                                        if (previous_status != null)
                                                        {
                                                            settlement.status = "FS" + previous_status.previous_status;
                                                        }
                                                    }
                                                }

                                                #endregion FS status

                                                #region Aftercare doctor/practice

                                                if (doctors_cache.ContainsKey(aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID))
                                                {
                                                    var aftercare_doctor = doctors_cache[aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                                    settlement.aftercare_doctor_practice_id = aftercare_doctor.DoctorID.ToString();
                                                    settlement.doctor = GenericUtils.GetDoctorNamePascal(aftercare_doctor);

                                                    if (practices_grouped_by_bpt.ContainsKey(aftercare_doctor.PracticeBPTID))
                                                    {
                                                        var doctors_practice = practices_grouped_by_bpt[aftercare_doctor.PracticeBPTID];
                                                        settlement.practice_id = doctors_practice.PracticeID.ToString();
                                                    }
                                                }
                                                else if (practices_grouped_by_bpt.ContainsKey(aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID))
                                                {
                                                    var aftercare_practice = practices_grouped_by_bpt[aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                                    settlement.aftercare_doctor_practice_id = aftercare_practice.PracticeID.ToString();
                                                    settlement.practice_id = aftercare_practice.PracticeID.ToString();
                                                }

                                                #endregion Aftercare doctor/practice

                                                settlement.id = aftercare_planned_action.PlannedAction_RefID.ToString();
                                                settlement.if_settlement_is_report_downloaded = existingPatientDetailsDownloadStatuses.ContainsKey(settlement.id) ? existingPatientDetailsDownloadStatuses[settlement.id] : false;
                                                settlement.diagnose_or_medication = diagnose_details != null ? diagnose_details.diagnose_name : p_case.diagnose_name;
                                                settlement.diagnose_id = diagnose_details != null ? diagnose_details.diagnose_id.ToString() : p_case.diagnose_id.ToString();
                                                settlement.localisation = performed_action_details.LocalizationCode;
                                                settlement.date = performed_action_details.PerformedOnDate;
                                                settlement.date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.");
                                                settlement.case_id = p_case.case_id.ToString();
                                                settlement.detail_type = "ac";
                                                settlement.drug = p_case.drug_name;
                                                settlement.drug_id = p_case.hec_drug_id.ToString();
                                                settlement.patient_id = p_case.patient_id.ToString();
                                                settlement.treatment_doctor_id = p_case.treatment_doctor_id.ToString();
                                                settlement.hip_ik = patient.HealthInsurance_IKNumber;

                                                patientDetailList.Add(settlement);
                                            }
                                        }
                                    }

                                    #endregion AC

                                    #region OCTS

                                    if (patientActionCache.ContainsKey(p_case.patient_id) && patientActionCache[p_case.patient_id].ContainsKey(p_case.localization) && patient_fs_status_cache.ContainsKey(p_case.patient_id) && patient_fs_status_cache[p_case.patient_id].ContainsKey(p_case.localization))
                                    {
                                        var filtered_oct_statuses = patient_fs_status_cache[p_case.patient_id][p_case.localization].Where(fs => fs.gpos_type == EGposType.Oct.Value()).ToList();
                                        var relevant_octs = patientActionCache[p_case.patient_id][p_case.localization].Where(t => t.IsPerformed).ToList();

                                        for (int index = 0; index < filtered_oct_statuses.Count; index++)
                                        {
                                            var settlement = new PatientDetailViewModel();

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
                                                Console.WriteLine("Case number: {0}", p_case.case_number);
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
                                                if (previous_status_cache.ContainsKey(p_case.case_id))
                                                {
                                                    var gpmid = "mm.docconnect.gpos.catalog.voruntersuchung";

                                                    var case_previous_statuses = previous_status_cache[p_case.case_id];
                                                    var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == gpmid);
                                                    if (previous_status != null)
                                                    {
                                                        settlement.status = "FS" + previous_status.previous_status;
                                                    }
                                                }
                                            }

                                            #endregion FS Status

                                            settlement.id = oct_planned_action.HEC_ACT_PlannedActionID.ToString();
                                            settlement.if_settlement_is_report_downloaded = existingPatientDetailsDownloadStatuses.ContainsKey(settlement.id) ? existingPatientDetailsDownloadStatuses[settlement.id] : false;
                                            settlement.case_id = filtered_oct_status.case_id.ToString();
                                            settlement.detail_type = "oct";
                                            settlement.diagnose_or_medication = String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10);
                                            settlement.diagnose_id = performed_action_details.DiagnoseID.ToString();
                                            settlement.doctor = GenericUtils.GetDoctorNamePascal(oct_doctor_details);
                                            settlement.localisation = performed_action_details.LocalizationCode;
                                            settlement.patient_id = p_case.patient_id.ToString();
                                            settlement.practice_id = oct_doctor_details.PracticeId.ToString();
                                            settlement.date = performed_action_details.PerformedOnDate;
                                            settlement.date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.yyyy");
                                            settlement.treatment_doctor_id = oct_doctor_details.DoctorID.ToString();
                                            settlement.hip_ik = patient.HealthInsurance_IKNumber;

                                            patientDetailList.Add(settlement);
                                        }
                                    }

                                    #endregion OCTS
                                }
                            }

                            #endregion Settlement

                            #region Open
                            if (p_case.localization != null && !case_fs_status_cache.ContainsKey(p_case.case_id) || ((case_fs_status_cache.ContainsKey(p_case.case_id) && !case_fs_status_cache[p_case.case_id].Any(x => x.gpos_type == EGposType.Operation.Value()))))
                            {
                                bool is_orders_drug = p_case.order_header_id != Guid.Empty;
                                var aftercare_id = Guid.Empty;
                                if (doctors_cache.ContainsKey(p_case.aftercare_bpt))
                                {
                                    aftercare_id = doctors_cache[p_case.aftercare_bpt].DoctorID;
                                }
                                else if (practices_grouped_by_bpt.ContainsKey(p_case.aftercare_bpt))
                                {
                                    aftercare_id = practices_grouped_by_bpt[p_case.aftercare_bpt].PracticeID;
                                }

                                PatientDetailViewModel patientDetal_elastic = new PatientDetailViewModel();
                                patientDetal_elastic.case_id = p_case.case_id.ToString();
                                patientDetal_elastic.id = p_case.treatment_planned_action_id.ToString();
                                patientDetal_elastic.date = p_case.treatment_date;
                                patientDetal_elastic.date_string = p_case.treatment_date.ToString("dd.MM.");
                                patientDetal_elastic.detail_type = "op";
                                patientDetal_elastic.practice_id = p_case.practice_id.ToString();
                                patientDetal_elastic.aftercare_doctor_practice_id = p_case.aftercare_bpt == Guid.Empty ? "" : aftercare_id.ToString();
                                patientDetal_elastic.order_status = p_case.order_status == 7 ? "MO6" : p_case.order_header_id != Guid.Empty ? "MO" + p_case.order_status : "";
                                patientDetal_elastic.drug = p_case.drug_name;
                                patientDetal_elastic.treatment_doctor_id = p_case.treatment_doctor_id.ToString();
                                patientDetal_elastic.diagnose_or_medication = p_case.diagnose_name == null ? "" : p_case.diagnose_name;
                                patientDetal_elastic.doctor = p_case.treatment_doctor_name == null ? "-" : p_case.treatment_doctor_name;
                                patientDetal_elastic.localisation = p_case.localization == null ? "-" : p_case.localization;
                                patientDetal_elastic.patient_id = p_case.patient_id.ToString();
                                if (documentation_cases.ContainsKey(p_case.case_id) && documentation_cases[p_case.case_id].Value_Boolean)
                                {
                                    patientDetal_elastic.status = "FS13";
                                }
                                else
                                {
                                    patientDetal_elastic.status = p_case.is_treatment_cancelled ? "OP4" : "FS0";
                                }
                                patientDetal_elastic.diagnose_id = p_case.diagnose_id != Guid.Empty ? p_case.diagnose_id.ToString() : "";
                                patientDetal_elastic.drug_id = p_case.hec_drug_id.ToString();
                                patientDetal_elastic.drug = p_case.drug_name;
                                patientDetal_elastic.order_id = p_case.order_header_id != Guid.Empty ? p_case.order_header_id.ToString() : "";

                                if (patientDetal_elastic.status == "MO6" && orderStatusHistoryCache.ContainsKey(p_case.order_header_id))
                                {
                                    var order_status_history = orderStatusHistoryCache[p_case.order_header_id];
                                    patientDetal_elastic.previous_order_status = "MO" + order_status_history[1].order_status_code;
                                }
                                patientDetal_elastic.hip_ik = patient.HealthInsurance_IKNumber;

                                patientDetailList.Add(patientDetal_elastic);
                            }

                            #endregion Open

                            #region Open OCT

                            if (p_case.localization != null && patientActionCache.ContainsKey(p_case.patient_id) && patientActionCache[p_case.patient_id].ContainsKey(p_case.localization))
                            {
                                var relevant_case_actions = patientActionCache[p_case.patient_id][p_case.localization];
                                #region Open OCT

                                if (relevant_case_actions.Any(t => !t.IsPerformed && !t.IsOpCancelled))
                                {
                                    var unsubmitted_oct = relevant_case_actions.Last(t => !t.IsPerformed);

                                    if (patient_fs_status_cache.ContainsKey(p_case.patient_id) && patient_fs_status_cache[p_case.patient_id].ContainsKey(p_case.localization))
                                    {
                                        var case_fs_statuses = patient_fs_status_cache[p_case.patient_id][p_case.localization];
                                        var pending_oct_exists = case_fs_statuses.Any(fs => fs.gpos_type == EGposType.Oct.Value() && fs.case_fs_status_code == 21);
                                        if (pending_oct_exists)
                                        {
                                            continue;
                                        }
                                    }

                                    #region Latest oct date

                                    var latest_oct_performed_date = p_case.treatment_date;

                                    if (performed_oct_data.ContainsKey(p_case.patient_id))
                                    {
                                        var performed_oct_dates = performed_oct_data[p_case.patient_id];
                                        if (performed_oct_dates.ContainsKey(p_case.localization))
                                        {
                                            latest_oct_performed_date = performed_oct_dates[p_case.localization].Max(t => t.performed_on_date);
                                        }
                                    }

                                    if (octFsStatuses.ContainsKey(p_case.patient_id) && octPerformedDates.ContainsKey(p_case.patient_id))
                                    {
                                        var patientOctFsStatuses = octFsStatuses[p_case.patient_id];
                                        var patientOctPerformedOnDates = octPerformedDates[p_case.patient_id];
                                        if (patientOctFsStatuses.ContainsKey(p_case.localization) && patientOctPerformedOnDates.ContainsKey(p_case.localization))
                                        {
                                            var patientOctFsStatusesForLocalization = patientOctFsStatuses[p_case.localization];
                                            var patientOctPerformedOnDatesForLocalization = patientOctPerformedOnDates[p_case.localization];
                                            latest_oct_performed_date = DateTime.MinValue;

                                            for (var j = 0; j < patientOctPerformedOnDatesForLocalization.Count; j++)
                                            {
                                                if (j >= patientOctFsStatusesForLocalization.Count)
                                                {
                                                    break;
                                                }

                                                var oct_date = patientOctPerformedOnDatesForLocalization[j];
                                                var oct_fs_status_code = patientOctFsStatusesForLocalization[j].fs_status_code;
                                                if (oct_fs_status_code != 8 && oct_fs_status_code != 11 && oct_fs_status_code != 17)
                                                {
                                                    if (oct_date.date > latest_oct_performed_date)
                                                    {
                                                        latest_oct_performed_date = oct_date.date;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    #endregion Latest oct date

                                    var patientDetal_elastic = patientDetailList.SingleOrDefault(t => t.status == "OCT1" && t.patient_id == p_case.patient_id.ToString() && t.localisation == p_case.localization);
                                    if (patientDetal_elastic == null)
                                    {
                                        patientDetal_elastic = new PatientDetailViewModel();
                                        patientDetailList.Add(patientDetal_elastic);
                                    }

                                    patientDetal_elastic.case_id = unsubmitted_oct.CaseID.ToString();
                                    patientDetal_elastic.id = unsubmitted_oct.PlannedAction_RefID.ToString();
                                    patientDetal_elastic.date = latest_oct_performed_date;
                                    patientDetal_elastic.date_string = latest_oct_performed_date.ToString("dd.MM.");
                                    patientDetal_elastic.detail_type = "oct";
                                    patientDetal_elastic.hip_ik = patient.HealthInsurance_IKNumber;

                                    #region doctor/practice

                                    if (doctors_cache.ContainsKey(unsubmitted_oct.ToBePerformedBy_BusinessParticipant_RefID))
                                    {
                                        var aftercare_doctor = doctors_cache[unsubmitted_oct.ToBePerformedBy_BusinessParticipant_RefID];
                                        patientDetal_elastic.aftercare_doctor_practice_id = aftercare_doctor.DoctorID.ToString();
                                        patientDetal_elastic.doctor = GenericUtils.GetDoctorNamePascal(aftercare_doctor);

                                        if (practices_grouped_by_bpt.ContainsKey(aftercare_doctor.PracticeBPTID))
                                        {
                                            var doctors_practice = practices_grouped_by_bpt[aftercare_doctor.PracticeBPTID];
                                            patientDetal_elastic.practice_id = doctors_practice.PracticeID.ToString();
                                        }
                                    }
                                    else if (practices_grouped_by_bpt.ContainsKey(unsubmitted_oct.ToBePerformedBy_BusinessParticipant_RefID))
                                    {
                                        var aftercare_practice = practices_grouped_by_bpt[unsubmitted_oct.ToBePerformedBy_BusinessParticipant_RefID];
                                        patientDetal_elastic.aftercare_doctor_practice_id = aftercare_practice.PracticeID.ToString();
                                        patientDetal_elastic.practice_id = aftercare_practice.PracticeID.ToString();
                                    }

                                    #endregion doctor/practice

                                    var oct_doctor = doctors_cache[unsubmitted_oct.ToBePerformedBy_BusinessParticipant_RefID];
                                    var doctor_name = GenericUtils.GetDoctorNamePascal(oct_doctor);
                                    var doctor_id = oct_doctor.DoctorID.ToString();

                                    patientDetal_elastic.treatment_doctor_id = doctor_id;
                                    patientDetal_elastic.diagnose_or_medication = p_case.diagnose_name == null ? "" : p_case.diagnose_name;
                                    patientDetal_elastic.doctor = doctor_name;
                                    patientDetal_elastic.localisation = p_case.localization == null ? "-" : p_case.localization;
                                    patientDetal_elastic.patient_id = p_case.patient_id.ToString();
                                    patientDetal_elastic.status = unsubmitted_oct.IsCancelled ? "OCT4" : "OCT1";
                                    patientDetal_elastic.diagnose_id = p_case.diagnose_id != Guid.Empty ? p_case.diagnose_id.ToString() : "";

                                    patientDetal_elastic.order_id = p_case.order_header_id != Guid.Empty ? p_case.order_header_id.ToString() : "";
                                }

                                #endregion Open OCT

                            }
                            #endregion


                            #endregion Cases
                        }
                    }

                    #region Fee waivers

                    if (patient_properties.ContainsKey(patient.Id))
                    {
                        var fee_waivers = patient_properties[patient.Id].Where(t => t.gpm_id == "mm.docconnect.patient.fee.waived").ToList();
                        foreach (var fee_waiver in fee_waivers)
                        {
                            var patient_details = new PatientDetailViewModel();
                            patient_details.date = DateTime.Parse(fee_waiver.string_value);
                            patient_details.date_string = patient_details.date.ToString("dd.MM.yyyy");
                            patient_details.detail_type = "fee_waiver";
                            patient_details.id = fee_waiver.id.ToString();
                            patient_details.patient_id = patient.Id.ToString();
                            patient_details.practice_id = patient.PracticeID.ToString();

                            patientDetailList.Add(patient_details);
                        }
                    }

                    #endregion Fee waivers

                    Console.Write("\rPatient {0} of {1} updated.                ", patientsUpdated++, all_Patients.Count());
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw ex;
            }

            return patientDetailList;
        }

        private static Dictionary<Guid, List<CAS_GPFSSoT_1420>> PrevStatusCache(SessionSecurityTicket securityTicket, DbConnection Connection, DbTransaction Transaction)
        {
            var all_previous_statuses = cls_Get_Previous_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var previous_status_cache = all_previous_statuses.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());
            return previous_status_cache;
        }

        private static void fs_status_cache(SessionSecurityTicket securityTicket, DbConnection Connection, DbTransaction Transaction, out Dictionary<Guid, List<CAS_GCFSSoT_1728>> case_fs_status_cache, out Dictionary<Guid, Dictionary<string, List<CAS_GCFSSoT_1728>>> patient_fs_status_cache)
        {
            var all_case_fs_statuses = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            case_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());
            patient_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));
        }

        private static void RelevantActions(SessionSecurityTicket securityTicket, DbConnection Connection, DbTransaction Transaction, out Dictionary<Guid, Dictionary<string, List<CAS_GRADoT_1007>>> relevantActionCache, out Dictionary<Guid, Dictionary<string, List<CAS_GRADoT_1007>>> patientActionCache)
        {
            var allRelevantActions = cls_Get_RelevantActionData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            relevantActionCache = allRelevantActions.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.ActionTypeGpmID).ToDictionary(x => x.Key, x => x.ToList()));
            patientActionCache = allRelevantActions.Where(t => t.ActionTypeGpmID == EActionType.PlannedOct.Value()).GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.Localization).ToDictionary(x => x.Key, x => x.ToList()));
        }

        private static Dictionary<string, bool> GetPostElestic(ElasticConnection elasticConnection, JsonNetSerializer serializer, SearchCommand command, string query)
        {
            Dictionary<string, bool> existingPatientDetailsDownloadStatuses;
            var result = elasticConnection.Post(command, query);
            existingPatientDetailsDownloadStatuses = serializer.ToSearchResult<Settlement_Model>(result).Documents.Where(t => t.id != null).GroupBy(t => t.id, t => t.is_report_downloaded).ToDictionary(t => t.Key, t => t.Single());
            return existingPatientDetailsDownloadStatuses;
        }
    }
}