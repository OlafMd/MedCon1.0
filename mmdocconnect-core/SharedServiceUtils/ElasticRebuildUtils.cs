using CL1_CMN_CTR;
using CL1_HEC_ACT;
using CL1_HEC_BIL;
using CL1_HEC_CAS;
using CSV2Core.SessionSecurity;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Case.Models;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectDBMethods.ElasticRefresh;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServiceUtils
{
    public abstract class ElasticRefresherBase
    {
        protected bool refreshIvoms;
        protected bool refreshAftercare;
        protected bool refreshOct;
        protected bool refreshOrders;
        protected bool refreshSpecific;

        protected DbConnection connection;
        protected DbTransaction transaction;
        protected SessionSecurityTicket securityTicket;
        protected IEnumerable<Guid> patient_ids;
        protected IDictionary<Guid, CAS_GDDoT_1849> diagnoses;
        protected IDictionary<Guid, CAS_GDDoT_1001> drugs;
        protected IDictionary<Guid, PA_GPDfPIDs_1354> patients;

        protected List<Settlement_Model> existing_settlements;
        protected List<PatientDetailViewModel> existing_patient_details;
        protected List<Oct_Model> existing_octs;
        protected List<Case_Model> existing_planned_cases;
        protected List<Aftercare_Model> existing_aftercares;
        protected List<Order_Model> existing_orders;
        protected List<Submitted_Case_Model> existing_treatments;
        protected List<Patient_Model> existing_patients;

        /// <summary>
        /// <para>
        /// If refreshSpecific set to true, elastic sections to rebuild must be manually specified. 
        /// </para>        
        /// <para>
        ///   For instance,  elasticRefresher.RebuildPlanning().RebuildElastic().
        /// </para>
        /// <para>
        /// This would only rebuild the planning section.
        /// </para>
        /// </summary>
        /// <param name="patient_ids"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="securityTicket"></param>
        /// <param name="refreshSpecific"></param>
        public ElasticRefresherBase(IEnumerable<Guid> patient_ids, DbConnection connection, DbTransaction transaction, SessionSecurityTicket securityTicket, bool refreshSpecific = false)
        {
            this.patient_ids = patient_ids;
            this.connection = connection;
            this.transaction = transaction;
            this.securityTicket = securityTicket;

            // todo: dependency injection
            this.diagnoses = cls_Get_DiagnoseDetails_on_Tenant.Invoke(connection, transaction, securityTicket).Result.ToDictionary(t => t.DiagnoseID, t => t);
            this.drugs = cls_Get_Drug_Details_on_Tenant.Invoke(connection, transaction, securityTicket).Result.ToDictionary(t => t.DrugID, t => t);
            this.patients = cls_Get_Patient_Details_for_PatientIDs.Invoke(connection, transaction, new P_PA_GPDfPIDs_1354() { PatientIDs = patient_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.PatientID, t => t);
            this.refreshSpecific = refreshSpecific;
        }

        public ElasticRefresherBase UpdateIvoms()
        {
            refreshIvoms = true;
            return this;
        }

        public ElasticRefresherBase UpdateAftercare()
        {
            refreshAftercare = true;
            return this;
        }

        public ElasticRefresherBase UpdateOct()
        {
            refreshOct = true;
            return this;
        }

        public ElasticRefresherBase UpdateOrders()
        {
            refreshOrders = true;
            return this;
        }

        private void InstantiateLists()
        {
            existing_settlements = new List<Settlement_Model>();
            existing_patient_details = new List<PatientDetailViewModel>();
            existing_octs = new List<Oct_Model>();
            existing_planned_cases = new List<Case_Model>();
            existing_aftercares = new List<Aftercare_Model>();
            existing_orders = new List<Order_Model>();
            existing_treatments = new List<Submitted_Case_Model>();
            existing_patients = new List<Patient_Model>();
        }

        protected bool ShouldUpdateOcts
        {
            get
            {
                return !refreshSpecific || refreshOct;
            }
        }

        protected bool ShouldUpdateIvoms
        {
            get
            {
                return !refreshSpecific || refreshIvoms;
            }
        }

        protected bool ShouldUpdateAftercares
        {
            get
            {
                return !refreshSpecific || refreshAftercare;
            }
        }

        protected bool ShouldUpdateOrders
        {
            get
            {
                return !refreshSpecific || refreshOrders;
            }
        }

        protected bool ShouldUpdatePatientDetails
        {
            get
            {
                return !refreshSpecific || refreshIvoms || refreshAftercare || refreshOrders || refreshOct;
            }
        }

        protected bool ShouldUpdateSettlement
        {
            get
            {
                return ShouldUpdateAftercares || ShouldUpdateIvoms || ShouldUpdateOcts;
            }
        }

        protected bool ShouldUpdatePatientInOtherPractices
        {
            get
            {
                return ShouldUpdateIvoms || ShouldUpdateOcts;
            }
        }


        /// <summary>
        /// Rebuild specified elastic sections if refreshSpecific set to true, or all if refreshSpecific set to false.
        /// </summary>
        public void RebuildElastic()
        {
            foreach (var patient_id in patient_ids)
            {
                InstantiateLists();

                try
                {
                    if (ShouldUpdateOcts)
                    {
                        RebuildOCT(patient_id);
                    }

                    if (ShouldUpdateIvoms)
                    {
                        RebuildPlanning(patient_id);
                    }

                    if (ShouldUpdateAftercares)
                    {
                        RebuildAftercares(patient_id);
                    }

                    if (ShouldUpdateOrders)
                    {
                        RebuildOrders(patient_id);
                    }

                    if (ShouldUpdateSettlement)
                    {
                        RebuildSettlement(patient_id);
                    }

                    if (ShouldUpdatePatientInOtherPractices)
                    {
                        RebuildPatientInOtherPractieces(patient_id);
                    }
                }
                catch
                {
                    BackupExisting(patient_id);
                    throw;
                }
                finally
                {
                    ImportDataToElastic(patient_id);
                }
            }
        }

        private void ImportDataToElastic(Guid patient_id)
        {
            if (ShouldUpdateIvoms)
            {
                ImportPlanning(patient_id);
            }

            if (ShouldUpdateOcts)
            {
                ImportOct(patient_id);
            }

            if (ShouldUpdateAftercares)
            {
                ImportAftercares(patient_id);
            }

            if (ShouldUpdateOrders)
            {
                ImportOrders(patient_id);
            }

            if (ShouldUpdatePatientDetails)
            {
                ImportPatientDetails(patient_id);
            }

            if (ShouldUpdateSettlement)
            {
                ImportSettlement(patient_id);
            }

            if (ShouldUpdatePatientInOtherPractices)
            {
                ImportPatientToOtherPractices(patient_id);
            }
        }

        protected abstract void ImportSettlement(Guid patient_id);

        protected abstract void ImportPlanning(Guid patient_id);

        protected abstract void ImportOct(Guid patient_id);

        protected abstract void ImportAftercares(Guid patient_id);

        protected abstract void ImportOrders(Guid patient_id);

        protected abstract void ImportPatientDetails(Guid patient_id);

        protected abstract void ImportPatientToOtherPractices(Guid patient_id);

        protected abstract void RebuildOCT(Guid patient_id);

        protected abstract void RebuildPlanning(Guid patient_id);

        protected abstract void RebuildAftercares(Guid patient_id);

        protected abstract void RebuildSettlement(Guid patient_id);

        protected abstract void RebuildPatientInOtherPractieces(Guid patient_id);

        protected abstract void RebuildOrders(Guid patient_id);

        protected abstract void BackupExisting(Guid patient_id);
    }

    public class ElasticRefresher : ElasticRefresherBase
    {
        public ElasticRefresher(IEnumerable<Guid> patient_ids, DbConnection connection, DbTransaction transaction, SessionSecurityTicket securityTicket, bool refreshSpecific = false)
            : base(
            patient_ids: patient_ids,
            connection: connection,
            transaction: transaction,
            securityTicket: securityTicket,
            refreshSpecific: refreshSpecific) { }

        #region Settlement
        protected override void RebuildSettlement(Guid patient_id)
        {
            var patient_ids = new Guid[] { patient_id };
            var all_cases = cls_Get_ElasticRefresh_Cases_for_PatientIDs.Invoke(connection, transaction, new P_ER_GERCfPIDs_0843() { PatientIDs = patient_ids }, securityTicket).Result.ToArray();
            if (all_cases.Any())
            {
                var gposAssignmentsCountCache = cls_Get_Number_of_GposTypes_on_Case_for_GposType_and_PatientIDs.Invoke(connection, transaction, new P_ER_GNoGToCfGPaPIDs_1522() { GposType = EGposType.Operation.Value(), PatientIDs = patient_ids }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.Single().NumberOfTreatmentGposes);
                var existingSettlementDownloadStatuses = Get_Cases.GetSettlementDownloadStatuses(patient_ids, securityTicket);

                var acPlannedActionTypeId = cls_Get_ActionTypeID.Invoke(connection, transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedAftercare.Value() }, securityTicket).Result;
                var all_case_aftercares = cls_Get_ElasticRefresh_Aftercares_for_CaseIDs.Invoke(connection, transaction, new P_ER_GERAfCIDs_1023()
                {
                    AftercarePlannedActionTypeID = acPlannedActionTypeId,
                    CaseIDs = all_cases.Select(t => t.case_id).ToArray()
                }, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

                var ac_planned_action_type = EActionType.PlannedAftercare.Value();
                var oct_planned_action_type = EActionType.PlannedOct.Value();

                var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(connection, transaction, new P_CAS_GATID_1514() { action_type_gpmid = oct_planned_action_type }, securityTicket).Result;
                var allRelevantActions = cls_Get_RelevantActionData_for_PatientID.Invoke(connection, transaction, new P_ER_GRADfPID_1734
                {
                    PatientIDs = patient_ids
                }, securityTicket).Result;

                var relevantActionCache = allRelevantActions.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.ActionTypeGpmID).ToDictionary(x => x.Key, x => x.ToList()));
                var patientActionCache = allRelevantActions.Where(t => t.ActionTypeGpmID == EActionType.PlannedOct.Value()).GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.Localization).ToDictionary(x => x.Key, x => x.ToList()));

                var patient_oct_planned_actions = cls_Get_PlannedActions_for_ActionTypeID_and_PatientID.Invoke(connection, transaction, new P_ER_GPAfATIDaPID_1049()
                {
                    ActionTypeID = oct_planned_action_type_id,
                    PatientID = patient_id
                }, securityTicket).Result;
                var doctor_bpt_ids = all_case_aftercares.SelectMany(t => t.Value.Select(x => x.performed_by_bpt_id)).ToList();
                doctor_bpt_ids.AddRange(all_cases.Select(t => t.op_doctor_bpt_id));
                doctor_bpt_ids.AddRange(patient_oct_planned_actions.Select(t => t.ToBePerformedBy_BusinessParticipant_RefID));
                doctor_bpt_ids.AddRange(relevantActionCache.SelectMany(t => t.Value.SelectMany(d => d.Value.Select(r => r.ToBePerformedBy_BusinessParticipant_RefID))));
                var doctors = cls_Get_DoctorBasicInformation_for_DoctorBptIDs.Invoke(connection, transaction, new P_ER_GDBIfDBptIDs_0857() { DoctorBptIDs = doctor_bpt_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.bpt_id, t => t);
                var practice_bpt_ids = doctors.Select(t => t.Value.practice_bpt_id).ToList();

                if (all_case_aftercares.Any())
                {
                    practice_bpt_ids.AddRange(all_case_aftercares.SelectMany(t => t.Value.Select(x => x.performed_by_bpt_id)).ToList());
                }

                var practices = new Dictionary<Guid, ER_GPBIfPBptIDs_0908>();
                if (practice_bpt_ids.Any())
                {
                    practices = cls_Get_PracticeBasicInformation_for_PracticeBptIDs.Invoke(connection, transaction, new P_ER_GPBIfPBptIDs_0908() { PracticeBptIDs = practice_bpt_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.practice_bpt_id, t => t);
                }

                var reportDownloaded = cls_cls_Get_Report_Downloaded_PropertyValues_for_PatientID.Invoke(connection, transaction, new P_ER_GRDPVfPID_1737 { PatientIDs = patient_ids }, securityTicket).Result;
                var performed_action_data = cls_Get_PerformedActionData_for_PatientIDs.Invoke(connection, transaction, new P_ER_GPADfPIDs_1754 { PatientIDs = patient_ids }, securityTicket).Result.GroupBy(t => t.ActionID).ToDictionary(t => t.Key, t => t.Single());

                var all_case_fs_statuses = cls_Get_Case_FS_Statuses_for_PatientIDs.Invoke(connection, transaction, new P_ER_FCFSSfPIDs_1759 { PatientIDs = patient_ids }, securityTicket).Result;
                var patient_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));
                var case_fs_status_cache = all_case_fs_statuses.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());
                var previous_status_cache = cls_Get_Previous_FS_Statuses_on_Tenant.Invoke(connection, transaction, new P_ER_GPFSSoT_1805 { PatientIDs = patient_ids }, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t);
                var fake_op_properties = cls_Get_CaseProperties_for_PropertyGpmID_and_PatientIDs.Invoke(connection, transaction, new P_ER_GCPfPGIDaPIDs_1811() { PropertyGpmID = ECaseProperty.FakeCase.Value(), PatientIDs = patient_ids }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());

                var management_fees = cls_Get_Management_Fee_Property_Value_for_PatientID.Invoke(connection, transaction, new P_ER_GMFPVfCIDs_1237()
                {
                    PatientID = patient_id
                }, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.GroupBy(r => r.gpos_type).ToDictionary(r => r.Key, r => r.ToList()));

                for (var j = 0; j < all_cases.Length; j++)
                {
                    var _case = all_cases[j];
                    if (!case_fs_status_cache.ContainsKey(_case.case_id) || fake_op_properties.ContainsKey(_case.case_id))
                    {
                        continue;
                    }

                    var case_fs_statuses = case_fs_status_cache[_case.case_id];
                    var ac_op_billed_together = gposAssignmentsCountCache.ContainsKey(_case.case_id) ? gposAssignmentsCountCache[_case.case_id] > 1 : false;

                    var filtered_treatment_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 230).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == EGposType.Operation.Value()).ToList();
                    var filtered_aftercare_statuses = ac_op_billed_together ? case_fs_statuses.Where(t => t.price == 60).ToList() : case_fs_statuses.Where(fs => fs.gpos_type == EGposType.Aftercare.Value()).ToList();

                    var op_management_fee = new List<ER_GMFPVfCIDs_1237>();
                    var ac_management_fee = new List<ER_GMFPVfCIDs_1237>();
                    var oct_management_fee = new List<ER_GMFPVfCIDs_1237>();

                    if (management_fees.ContainsKey(_case.case_id))
                    {
                        var case_management_fee_properties = management_fees[_case.case_id];
                        if (case_management_fee_properties.ContainsKey(EGposType.Operation.Value()))
                        {
                            op_management_fee = case_management_fee_properties[EGposType.Operation.Value()];
                        }

                        if (case_management_fee_properties.ContainsKey(EGposType.Aftercare.Value()))
                        {
                            ac_management_fee = case_management_fee_properties[EGposType.Aftercare.Value()];
                        }

                        if (case_management_fee_properties.ContainsKey(EGposType.Oct.Value()))
                        {
                            oct_management_fee = case_management_fee_properties[EGposType.Oct.Value()];
                        }
                    }


                    #region OP

                    foreach (var fs_status in filtered_treatment_statuses)
                    {
                        var settlement = new Settlement_Model();

                        #region Aftercare
                        if (all_case_aftercares.ContainsKey(_case.case_id))
                        {
                            var aftercare = all_case_aftercares[_case.case_id].FirstOrDefault(t => !t.cancelled);
                            if (aftercare != null)
                            {
                                if (doctors.ContainsKey(aftercare.performed_by_bpt_id))
                                {
                                    var aftercare_doctor = doctors[aftercare.performed_by_bpt_id];
                                    settlement.aftercare_doctor_practice_id = aftercare_doctor.doctor_id.ToString();

                                    if (practices.ContainsKey(aftercare_doctor.practice_bpt_id))
                                    {
                                        var doctors_practice = practices[aftercare_doctor.practice_bpt_id];
                                        settlement.acpractice = doctors_practice.practice_name;
                                        settlement.bsnr = doctors_practice.bsnr;
                                    }
                                    else
                                    {
                                        settlement.acpractice = "-";
                                        settlement.bsnr = "-";
                                    }
                                }
                                else if (practices.ContainsKey(aftercare.performed_by_bpt_id))
                                {
                                    var aftercare_practice = practices[aftercare.performed_by_bpt_id];
                                    settlement.aftercare_doctor_practice_id = aftercare_practice.practice_id.ToString();
                                    settlement.acpractice = aftercare_practice.practice_name;
                                    settlement.bsnr = aftercare_practice.bsnr;
                                }
                            }
                        }
                        #endregion Aftercare

                        #region FS status

                        if (fs_status.case_fs_status_code != 3 && fs_status.case_fs_status_code != 5 && fs_status.case_fs_status_code != 10 && fs_status.case_fs_status_code != 18)
                        {
                            var status = fs_status.case_fs_status_code == 17 ? 8 : fs_status.case_fs_status_code;
                            settlement.status = "FS" + status;
                            settlement.status_date = fs_status.status_date;
                        }
                        else
                        {
                            settlement.status = "FS1";
                            if (previous_status_cache.ContainsKey(_case.case_id))
                            {
                                var case_previous_statuses = previous_status_cache[_case.case_id];
                                var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == EGposType.Operation.Value());
                                if (previous_status != null)
                                {
                                    settlement.status = "FS" + previous_status.previous_status;
                                    settlement.status_date = previous_status.status_date;
                                }
                            }
                        }

                        #endregion FS status


                        // doctor
                        var op_doctor = doctors[_case.op_doctor_bpt_id];
                        settlement.doctor = GenericUtils.GetDoctorName(op_doctor);
                        settlement.lanr = op_doctor.lanr;
                        settlement.treatment_doctor_id = op_doctor.doctor_id.ToString();

                        // diagnose 
                        var diagnose = diagnoses[_case.diagnose_id];

                        settlement.id = _case.action_id.ToString();
                        settlement.is_report_downloaded = existingSettlementDownloadStatuses.ContainsKey(settlement.id) ? existingSettlementDownloadStatuses[settlement.id] : false;
                        settlement.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnose);
                        settlement.diagnose_id = _case.diagnose_id.ToString();
                        settlement.localization = _case.localization;
                        settlement.practice_id = _case.practice_id.ToString();
                        settlement.surgery_date = _case.treatment_date;
                        settlement.surgery_date_string = _case.treatment_date.ToString("dd.MM.");
                        settlement.surgery_date_string_month = _case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                        settlement.case_id = _case.case_id.ToString();
                        settlement.case_type = "op";

                        //drug
                        var drug = drugs[_case.drug_id];
                        settlement.drug = drug.DrugName;
                        settlement.drug_id = drug.DrugID.ToString();

                        // patient
                        var patient = patients[patient_id];
                        settlement.first_name = patient.FirstName;
                        settlement.hip = patient.HipName;
                        settlement.birthday = patient.BirthDate.ToString("dd.MM.yyyy");
                        settlement.last_name = patient.LastName;
                        settlement.patient_full_name = String.Format("{0}, {1}", patient.LastName, patient.FirstName);
                        settlement.patient_id = _case.patient_id.ToString();
                        settlement.patient_insurance_number = patient.InsuranceIdNumber;
                        settlement.hip_ik_number = patient.HipIkNumber;

                        settlement.previous_status = "";
                        if (settlement.status != "FS13")
                        {
                            settlement.ac_status = "AC1";
                        }

                        if (filtered_aftercare_statuses.Any())
                        {
                            if (relevantActionCache.ContainsKey(_case.case_id))
                            {
                                var relevant_case_actions = relevantActionCache[_case.case_id];
                                if (relevant_case_actions.ContainsKey(ac_planned_action_type))
                                {
                                    var relevant_aftercares = relevantActionCache[_case.case_id][ac_planned_action_type].ToList();
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

                        existing_settlements.Add(settlement);

                        var treatment = new Submitted_Case_Model();
                        treatment.management_pauschale = !op_management_fee.Any() ? "waived" : op_management_fee.First().value;
                        var practice = practices[op_doctor.practice_bpt_id];
                        treatment.practice_bsnr = practice.bsnr;
                        treatment.practice_name = practice.practice_name;


                        treatment.status_date = fs_status.status_date;
                        treatment.status_date_string = fs_status.status_date.ToString("dd.MM.yyyy");
                        treatment.diagnose = settlement.diagnose;
                        treatment.diagnose_id = settlement.diagnose_id;
                        treatment.doctor_name = settlement.doctor;
                        treatment.id = settlement.id;
                        treatment.doctor_lanr = settlement.lanr;
                        treatment.localization = settlement.localization;
                        treatment.practice_id = settlement.practice_id.ToString();
                        treatment.treatment_date = settlement.surgery_date;
                        treatment.treatment_date_string = settlement.surgery_date.ToString("dd.MM.yyyy");
                        treatment.treatment_date_day_month = settlement.surgery_date.ToString("dd.MM.");
                        treatment.treatment_date_month_year = settlement.surgery_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                        treatment.status = "FS" + fs_status.case_fs_status_code;
                        treatment.case_id = settlement.case_id;
                        treatment.type = "op";
                        treatment.drug = settlement.drug;
                        treatment.drug_id = settlement.drug_id;
                        treatment.patient_name = settlement.patient_full_name;
                        treatment.hip_name = settlement.hip;
                        treatment.patient_birthdate = patient.BirthDate;
                        treatment.patient_birthdate_string = settlement.birthday;
                        treatment.patient_id = settlement.patient_id;
                        treatment.patient_insurance_number = settlement.patient_insurance_number;
                        treatment.doctor_id = settlement.treatment_doctor_id;
                        treatment.if_aftercare_treatment_date = _case.treatment_date;

                        existing_treatments.Add(treatment);

                        var new_patient_details = new PatientDetailViewModel();
                        new_patient_details.id = settlement.id;
                        new_patient_details.practice_id = settlement.practice_id;
                        new_patient_details.date = settlement.surgery_date;
                        new_patient_details.date_string = settlement.surgery_date.ToString("dd.MM.");
                        new_patient_details.detail_type = settlement.case_type;
                        new_patient_details.localisation = settlement.localization;
                        new_patient_details.patient_id = settlement.patient_id;
                        new_patient_details.status = settlement.status;
                        new_patient_details.case_id = settlement.case_id.ToString();
                        new_patient_details.diagnose_or_medication = settlement.diagnose;
                        new_patient_details.doctor = settlement.doctor;
                        new_patient_details.treatment_doctor_id = settlement.treatment_doctor_id;
                        new_patient_details.diagnose_id = settlement.diagnose_id;
                        new_patient_details.hip_ik = settlement.hip_ik_number;
                        new_patient_details.aftercare_doctor_practice_id = settlement.aftercare_doctor_practice_id;

                        existing_patient_details.Add(new_patient_details);
                    }

                    #endregion OP

                    if (relevantActionCache.ContainsKey(_case.case_id))
                    {
                        var relevant_case_actions = relevantActionCache[_case.case_id];

                        #region AC
                        if (relevant_case_actions.ContainsKey(ac_planned_action_type))
                        {
                            var relevant_aftercares = relevantActionCache[_case.case_id][ac_planned_action_type].Where(t => t.IsPerformed).ToList();

                            for (int index = 0; index < filtered_aftercare_statuses.Count; index++)
                            {
                                var settlement = new Settlement_Model();
                                var treatment = new Submitted_Case_Model();
                                if (index >= relevant_aftercares.Count)
                                {
                                    continue;
                                }

                                var aftercare_planned_action = relevant_aftercares[index];
                                if (!performed_action_data.ContainsKey(aftercare_planned_action.PlannedAction_RefID))
                                {
                                    continue;
                                }
                                var performed_action_details = performed_action_data[aftercare_planned_action.PlannedAction_RefID];
                                var diagnose_details = diagnoses[performed_action_details.DiagnoseID];
                                var filtered_aftercare_status = filtered_aftercare_statuses[index];

                                #region FS status

                                if (filtered_aftercare_status.case_fs_status_code != 3 && filtered_aftercare_status.case_fs_status_code != 5 && filtered_aftercare_status.case_fs_status_code != 10 && filtered_aftercare_status.case_fs_status_code != 18)
                                {
                                    var status = filtered_aftercare_status.case_fs_status_code == 17 ? 8 : filtered_aftercare_status.case_fs_status_code;
                                    settlement.status = "FS" + status;
                                    settlement.status_date = filtered_aftercare_status.status_date;

                                    treatment.status_date = filtered_aftercare_status.status_date;
                                    treatment.status_date_string = filtered_aftercare_status.status_date.ToString("dd.MM.yyyy");
                                }
                                else
                                {
                                    settlement.status = "FS1";
                                    if (previous_status_cache.ContainsKey(_case.case_id))
                                    {
                                        var case_previous_statuses = previous_status_cache[_case.case_id];
                                        var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == EGposType.Aftercare.Value());
                                        if (previous_status != null)
                                        {
                                            settlement.status = "FS" + previous_status.previous_status;
                                            settlement.status_date = previous_status.status_date;
                                            treatment.status_date = previous_status.status_date;
                                            treatment.status_date_string = previous_status.status_date.ToString("dd.MM.yyyy");
                                        }
                                    }
                                }

                                #endregion FS status

                                #region Aftercare doctor/practice

                                if (doctors.ContainsKey(aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID))
                                {
                                    var aftercare_doctor = doctors[aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                    settlement.aftercare_doctor_practice_id = aftercare_doctor.doctor_id.ToString();
                                    settlement.doctor = GenericUtils.GetDoctorName(aftercare_doctor);
                                    settlement.lanr = aftercare_doctor.lanr;

                                    if (practices.ContainsKey(aftercare_doctor.practice_bpt_id))
                                    {
                                        var doctors_practice = practices[aftercare_doctor.practice_bpt_id];
                                        settlement.acpractice = doctors_practice.practice_name;
                                        settlement.bsnr = doctors_practice.bsnr;
                                        settlement.practice_id = doctors_practice.practice_id.ToString();

                                        treatment.practice_id = doctors_practice.practice_id.ToString();
                                        treatment.practice_bsnr = doctors_practice.bsnr;
                                        treatment.practice_name = doctors_practice.practice_name;
                                    }
                                    else
                                    {
                                        settlement.acpractice = "-";
                                        settlement.bsnr = "-";
                                    }
                                }
                                else if (practices.ContainsKey(aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID))
                                {
                                    var aftercare_practice = practices[aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                    settlement.aftercare_doctor_practice_id = aftercare_practice.practice_id.ToString();
                                    settlement.acpractice = aftercare_practice.practice_name;
                                    settlement.bsnr = aftercare_practice.bsnr;
                                    settlement.practice_id = aftercare_practice.practice_id.ToString();
                                    treatment.practice_id = aftercare_practice.practice_id.ToString();
                                    treatment.practice_bsnr = aftercare_practice.bsnr;
                                    treatment.practice_name = aftercare_practice.practice_name;
                                }

                                #endregion Aftercare doctor/practice

                                var patient = patients[patient_id];

                                settlement.id = aftercare_planned_action.PlannedAction_RefID.ToString();
                                settlement.is_report_downloaded = existingSettlementDownloadStatuses.ContainsKey(settlement.id) ? existingSettlementDownloadStatuses[settlement.id] : false;
                                settlement.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnose_details);
                                settlement.diagnose_id = diagnose_details.DiagnoseID.ToString();
                                settlement.localization = performed_action_details.LocalizationCode;
                                settlement.surgery_date = performed_action_details.PerformedOnDate;
                                settlement.surgery_date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.");
                                settlement.surgery_date_string_month = performed_action_details.PerformedOnDate.ToString("MMMM yyyy", new CultureInfo("de", true));
                                settlement.if_aftercare_treatment_date = _case.treatment_date.ToString("dd.MM.yyyy");
                                settlement.case_id = _case.case_id.ToString();
                                settlement.case_type = "ac";

                                //drug
                                var drug = drugs[_case.drug_id];
                                settlement.drug = drug.DrugName;
                                settlement.drug_id = drug.DrugID.ToString();

                                // patient
                                settlement.first_name = patient.FirstName;
                                settlement.hip = patient.HipName;
                                settlement.birthday = patient.BirthDate.ToString("dd.MM.yyyy");
                                settlement.last_name = patient.LastName;
                                settlement.patient_full_name = String.Format("{0}, {1}", patient.LastName, patient.FirstName);
                                settlement.patient_id = _case.patient_id.ToString();
                                settlement.patient_insurance_number = patient.InsuranceIdNumber;
                                settlement.hip_ik_number = patient.HipIkNumber;

                                // doctor
                                var op_doctor = doctors[_case.op_doctor_bpt_id];
                                settlement.previous_status = "";
                                settlement.treatment_doctor_id = op_doctor.doctor_id.ToString();


                                existing_settlements.Add(settlement);

                                try
                                {
                                    treatment.management_pauschale = ac_management_fee.First().value;
                                }
                                catch
                                {
                                    treatment.management_pauschale = "waived";
                                }

                                if (treatment.practice_id == null && settlement.practice_id != null)
                                {
                                    treatment.practice_id = settlement.practice_id.ToString();
                                }

                                treatment.patient_birthdate = patient.BirthDate;
                                treatment.patient_birthdate_string = patient.BirthDate.ToString("dd.MM.yyyy");
                                treatment.diagnose = settlement.diagnose;
                                treatment.diagnose_id = settlement.diagnose_id;
                                treatment.doctor_name = settlement.doctor;
                                treatment.id = settlement.id;
                                treatment.doctor_lanr = settlement.lanr;
                                treatment.localization = settlement.localization;
                                treatment.treatment_date = settlement.surgery_date;
                                treatment.treatment_date_string = settlement.surgery_date.ToString("dd.MM.yyyy");
                                treatment.treatment_date_day_month = settlement.surgery_date.ToString("dd.MM.");
                                treatment.treatment_date_month_year = settlement.surgery_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                                treatment.case_id = settlement.case_id;
                                treatment.type = "ac";
                                treatment.drug = settlement.drug;
                                treatment.drug_id = settlement.drug_id;
                                treatment.patient_name = settlement.patient_full_name;
                                treatment.hip_name = settlement.hip;
                                treatment.patient_id = settlement.patient_id;
                                treatment.patient_insurance_number = settlement.patient_insurance_number;
                                treatment.doctor_id = settlement.treatment_doctor_id;

                                treatment.status = "FS" + filtered_aftercare_status.case_fs_status_code;

                                existing_treatments.Add(treatment);

                                var new_patient_details = new PatientDetailViewModel();
                                new_patient_details.id = settlement.id;
                                new_patient_details.practice_id = settlement.practice_id;
                                new_patient_details.date = settlement.surgery_date;
                                new_patient_details.date_string = settlement.surgery_date.ToString("dd.MM.");
                                new_patient_details.detail_type = settlement.case_type;
                                new_patient_details.localisation = settlement.localization;
                                new_patient_details.patient_id = settlement.patient_id;
                                new_patient_details.status = settlement.status;
                                new_patient_details.case_id = settlement.case_id.ToString();
                                new_patient_details.diagnose_or_medication = settlement.diagnose;
                                new_patient_details.doctor = settlement.doctor;
                                new_patient_details.treatment_doctor_id = settlement.treatment_doctor_id;
                                new_patient_details.diagnose_id = settlement.diagnose_id;
                                new_patient_details.hip_ik = settlement.hip_ik_number;
                                new_patient_details.aftercare_doctor_practice_id = settlement.aftercare_doctor_practice_id;

                                existing_patient_details.Add(new_patient_details);
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
                                var treatment = new Submitted_Case_Model();

                                if (index >= relevant_octs.Count)
                                {
                                    continue;
                                }

                                var oct_planned_action = patient_oct_planned_actions.Single(t => t.HEC_ACT_PlannedActionID == relevant_octs[index].PlannedAction_RefID);
                                if (!performed_action_data.ContainsKey(oct_planned_action.HEC_ACT_PlannedActionID))
                                {
                                    continue;
                                }

                                var oct_doctor_details = doctors[oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID];
                                var oct_doctors_practice = practices[oct_doctor_details.practice_bpt_id];

                                if (!performed_action_data.ContainsKey(oct_planned_action.HEC_ACT_PlannedActionID))
                                {
                                    continue;
                                }
                                var performed_action_details = performed_action_data[oct_planned_action.HEC_ACT_PlannedActionID];
                                var diagnose_details = diagnoses[performed_action_details.DiagnoseID];
                                var filtered_oct_status = filtered_oct_statuses[index];

                                #region FS Status

                                if (filtered_oct_status.case_fs_status_code != 3 && filtered_oct_status.case_fs_status_code != 5 && filtered_oct_status.case_fs_status_code != 10 && filtered_oct_status.case_fs_status_code != 18)
                                {
                                    var status = filtered_oct_status.case_fs_status_code == 17 ? 8 : filtered_oct_status.case_fs_status_code;
                                    settlement.status = "FS" + status;
                                    settlement.status_date = filtered_oct_status.status_date;

                                    treatment.status_date = filtered_oct_status.status_date;
                                    treatment.status_date_string = filtered_oct_status.status_date.ToString("dd.MM.yyyy");
                                }
                                else
                                {
                                    settlement.status = "FS1";
                                    if (previous_status_cache.ContainsKey(_case.case_id))
                                    {
                                        var case_previous_statuses = previous_status_cache[_case.case_id];
                                        var previous_status = case_previous_statuses.FirstOrDefault(t => t.gpmid == EGposType.Oct.Value());
                                        if (previous_status != null)
                                        {
                                            settlement.status = "FS" + previous_status.previous_status;
                                            settlement.status_date = previous_status.status_date;

                                            treatment.status_date = previous_status.status_date;
                                            treatment.status_date_string = previous_status.status_date.ToString("dd.MM.yyyy");
                                        }
                                    }
                                }

                                #endregion FS Status

                                var patient = patients[_case.patient_id];

                                settlement.id = oct_planned_action.HEC_ACT_PlannedActionID.ToString();
                                settlement.is_report_downloaded = existingSettlementDownloadStatuses.ContainsKey(settlement.id) ? existingSettlementDownloadStatuses[settlement.id] : false;
                                settlement.birthday = patient.BirthDate.ToString("dd.MM.yyyy");
                                settlement.bsnr = oct_doctors_practice.bsnr;
                                settlement.case_id = _case.case_id.ToString();
                                settlement.case_type = "oct";
                                settlement.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnose_details);
                                settlement.diagnose_id = performed_action_details.DiagnoseID.ToString();
                                settlement.doctor = GenericUtils.GetDoctorName(oct_doctor_details);
                                settlement.first_name = patient.FirstName;
                                settlement.hip = patient.HipName;
                                settlement.if_aftercare_treatment_date = _case.treatment_date.ToString("dd.MM.yyyy");
                                settlement.lanr = oct_doctor_details.lanr;
                                settlement.last_name = patient.LastName;

                                var drug = drugs[_case.drug_id];
                                settlement.drug = drug.DrugName;
                                settlement.drug_id = drug.DrugID.ToString();
                                settlement.localization = performed_action_details.LocalizationCode;
                                settlement.patient_full_name = String.Format("{0}, {1}", patient.LastName, patient.FirstName);
                                settlement.patient_id = patient.PatientID.ToString();
                                settlement.patient_insurance_number = patient.InsuranceIdNumber;
                                settlement.practice_id = oct_doctor_details.practice_id.ToString();
                                settlement.surgery_date = performed_action_details.PerformedOnDate;
                                settlement.surgery_date_string = performed_action_details.PerformedOnDate.ToString("dd.MM.yyyy");
                                settlement.surgery_date_string_month = performed_action_details.PerformedOnDate.ToString("MMMM yyyy", new CultureInfo("de", true));
                                settlement.treatment_doctor_id = oct_doctor_details.doctor_id.ToString();
                                settlement.hip_ik_number = patient.HipIkNumber;

                                existing_settlements.Add(settlement);

                                treatment.practice_bsnr = oct_doctors_practice.bsnr;
                                treatment.practice_name = oct_doctors_practice.practice_name;
                                treatment.management_pauschale = !oct_management_fee.Any() ? "waived" : oct_management_fee.First().value;
                                treatment.diagnose = settlement.diagnose;
                                treatment.diagnose_id = settlement.diagnose_id;
                                treatment.doctor_name = settlement.doctor;
                                treatment.id = settlement.id;
                                treatment.doctor_lanr = settlement.lanr;
                                treatment.localization = settlement.localization;
                                treatment.practice_id = settlement.practice_id.ToString();
                                treatment.treatment_date = settlement.surgery_date;
                                treatment.treatment_date_string = settlement.surgery_date.ToString("dd.MM.yyyy");
                                treatment.treatment_date_day_month = settlement.surgery_date.ToString("dd.MM.");
                                treatment.treatment_date_month_year = settlement.surgery_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                                treatment.status = "FS" + filtered_oct_status.case_fs_status_code;
                                treatment.case_id = settlement.case_id;
                                treatment.type = "oct";
                                treatment.drug = settlement.drug;
                                treatment.drug_id = settlement.drug_id;
                                treatment.patient_name = settlement.patient_full_name;
                                treatment.hip_name = settlement.hip;
                                treatment.patient_birthdate = patient.BirthDate;
                                treatment.patient_birthdate_string = patient.BirthDate.ToString("dd.MM.yyyy");
                                treatment.patient_id = settlement.patient_id;
                                treatment.patient_insurance_number = settlement.patient_insurance_number;
                                treatment.doctor_id = settlement.treatment_doctor_id;

                                existing_treatments.Add(treatment);

                                var new_patient_details = new PatientDetailViewModel();
                                new_patient_details.id = settlement.id;
                                new_patient_details.practice_id = settlement.practice_id;
                                new_patient_details.date = settlement.surgery_date;
                                new_patient_details.date_string = settlement.surgery_date.ToString("dd.MM.");
                                new_patient_details.detail_type = settlement.case_type;
                                new_patient_details.localisation = settlement.localization;
                                new_patient_details.patient_id = settlement.patient_id;
                                new_patient_details.status = settlement.status;
                                new_patient_details.case_id = settlement.case_id.ToString();
                                new_patient_details.diagnose_or_medication = settlement.diagnose;
                                new_patient_details.doctor = settlement.doctor;
                                new_patient_details.treatment_doctor_id = settlement.treatment_doctor_id;
                                new_patient_details.diagnose_id = settlement.diagnose_id;
                                new_patient_details.hip_ik = patient.HipIkNumber;
                                new_patient_details.aftercare_doctor_practice_id = settlement.aftercare_doctor_practice_id;

                                existing_patient_details.Add(new_patient_details);
                            }
                        }
                        #endregion OCTS
                    }
                }
            }
        }
        #endregion

        #region OCT
        protected override void RebuildOCT(Guid patient_id)
        {
            #region data retrieval
            var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(connection, transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
            var octGposCatalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(connection, transaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query() { GlobalPropertyMatchingID = EGposType.Oct.Value(), Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).Single();
            var gposIds = ORM_HEC_BIL_PotentialCode.Query.Search(connection, transaction, new ORM_HEC_BIL_PotentialCode.Query() { PotentialCode_Catalog_RefID = octGposCatalog.HEC_BIL_PotentialCode_CatalogID }).Select(t => t.HEC_BIL_PotentialCodeID).ToArray();
            var dbOcts = cls_Get_Octs_for_ElasticRefresh_by_PatientID.Invoke(connection, transaction, new P_ER_GOfERbPID_1818() { PatientID = patient_id }, securityTicket).Result.GroupBy(r => r.Localization).ToDictionary(x => x.Key, x => x.ToList());
            var performedOpAndOctDates = cls_Get_Oct_and_Op_Dates_by_PatientID.Invoke(connection, transaction, new P_ER_GOctaOpDbPID_1824() { PatientID = patient_id }, securityTicket).Result.GroupBy(r => r.Localization).ToDictionary(x => x.Key, x => x.ToList());
            var octFsStatuses = cls_Get_Oct_FsStatuses_by_PatientID.Invoke(connection, transaction, new P_ER_GOctFsSbPID_1829() { PatientID = patient_id }, securityTicket).Result.GroupBy(t => t.localization).ToDictionary(t => t.Key, t => t.ToList());
            var consents = cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID.Invoke(connection, transaction, new P_ER_GPCoCbGposIDsaPID_2020() { PatientID = patient_id, GposIDs = gposIds }, securityTicket).Result;
            var patientHip = cls_Get_HIP_for_PatientID.Invoke(connection, transaction, new P_PA_GHfPID_1228 { PatientID = patient_id }, securityTicket).Result;
            var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(connection, transaction, new ORM_CMN_CTR_Contract_Parameter.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t.ToList());
            var fs_statuses_data = cls_Get_ActiveNonError_OctFsStatuses_by_PatientID.Invoke(connection, transaction, new P_ER_GANEOctFsSbPID_2026() { PlannedOctActionTypeID = oct_planned_action_type_id, PatientID = patient_id, }, securityTicket).Result.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList());
            var all_contracts = ORM_CMN_CTR_Contract.Query.Search(connection, transaction, new ORM_CMN_CTR_Contract.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).GroupBy(x => x.CMN_CTR_ContractID).ToDictionary(x => x.Key, x => x.Single());
            var ivom_dates = cls_Get_Latest_NonError_NonCancelled_OpDate_for_PatientIDs.Invoke(connection, transaction, new P_CAS_GLNENCODfPIDs_1848 { PatientID = patient_id }, securityTicket).Result.Where(x => x.patient_id != Guid.Empty);
            var last_ivom_dates = ivom_dates != null && ivom_dates.Any() ? ivom_dates.GroupBy(x => x.localization_code).ToDictionary(x => x.Key, x => x.Single()) : new Dictionary<string, CAS_GLNENCODfPIDs_1848>();

            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

            #endregion

            #region update elastic
            foreach (var patientOcts in dbOcts)
            {

                foreach (var oct in patientOcts.Value)
                {
                    var lastPotentialConsent = consents.Where(t => t.consent_valid_from.Date <= oct.TreatmentDate.Date).OrderBy(t => t.consent_valid_from).FirstOrDefault();
                    var treatmentYearLength = 365d;
                    var useSettlementYear = false;

                    if (lastPotentialConsent != null)
                    {
                        useSettlementYear = allContractParameters[lastPotentialConsent.contract_id].SingleOrDefault(t => t.ParameterName == EContractParameter.UseSettlementYear.Value()) != null;

                        var treatmentYearLengthContractParameter = allContractParameters[lastPotentialConsent.contract_id].SingleOrDefault(t => t.ParameterName == "Preexaminations - Days");
                        if (treatmentYearLengthContractParameter != null)
                        {
                            treatmentYearLength = treatmentYearLengthContractParameter.IfNumericValue_Value;
                        }
                    }
                    else
                    {
                        continue;
                    }
                    #region Treatment date
                    var allDates = useSettlementYear ? performedOpAndOctDates.SelectMany(x => x.Value.Where(t => !t.IsOp)).ToList() : performedOpAndOctDates[oct.Localization].ToList();


                    var patientOctFsStatusesForLocalization = useSettlementYear ? octFsStatuses.SelectMany(t => t.Value).ToList() :
                        octFsStatuses.ContainsKey(patientOcts.Key) ? octFsStatuses[patientOcts.Key] : new List<ER_GOctFsSbPID_1829>();
                    var patientOctPerformedOnDatesForLocalization = useSettlementYear ? performedOpAndOctDates.SelectMany(t => t.Value.Where(x => !x.IsOp).ToList()).ToList() :
                        performedOpAndOctDates.ContainsKey(patientOcts.Key) ? performedOpAndOctDates[patientOcts.Key].Where(t => !t.IsOp).ToList() : new List<ER_GOctaOpDbPID_1824>();

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
                                nonErrorOctDates.Add(oct_date.TreatmentDate.Date);
                                if (oct_date.Localization == oct.Localization)
                                {
                                    nonErrorOctDatesOnLocalization.Add(oct_date.TreatmentDate.Date);
                                }
                            }
                            else
                            {
                                allDates = allDates.Where(t => t.ActionID != patientOctPerformedOnDatesForLocalization[j].ActionID).ToList();
                            }
                        }
                    }

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

                    var latestOctDate = nonErrorOctDatesOnLocalization.Where(t => t.Date >= treatmentYearStartDate && t.Date < treatmentYearEndDate).DefaultIfEmpty().Max();


                    var octsPerformedDatesInTreatmentYear = patientOctPerformedOnDatesForLocalization.Where(t => t.TreatmentDate.Date >= treatmentYearStartDate && t.TreatmentDate.Date < treatmentYearEndDate).ToList();
                    var caseIds = octsPerformedDatesInTreatmentYear.Select(t => t.CaseID).ToList();

                    var performedOpExists = useSettlementYear ?
                        performedOpAndOctDates.SelectMany(t => t.Value).Any(t =>
                        {
                            var isOpAndPerformed = t.IsOp && t.IsOpPerformed;
                            var isOpDateInRequiredTimespan = t.TreatmentDate.Date <= latestOctDate.Date && t.TreatmentDate.Date >= latestOctDate.AddDays(-treatmentYearLength).Date || caseIds.Any(cid => cid == t.CaseID);
                            var isOpInCurrentTreatmentYear = t.TreatmentDate.Date >= treatmentYearStartDate && t.TreatmentDate.Date < treatmentYearEndDate;

                            return isOpAndPerformed && (isOpDateInRequiredTimespan || isOpInCurrentTreatmentYear);
                        }) :
                        performedOpAndOctDates.ContainsKey(oct.Localization) ?
                        performedOpAndOctDates[oct.Localization].Any(t =>
                        {

                            var isOpAndPerformed = t.IsOp && t.IsOpPerformed;
                            var isOpDateInRequiredTimespan = t.TreatmentDate <= latestOctDate && t.TreatmentDate.Date >= latestOctDate.AddDays(-treatmentYearLength).Date;
                            var isOpInCurrentTreatmentYear = t.TreatmentDate.Date >= treatmentYearStartDate && t.TreatmentDate.Date < treatmentYearEndDate;

                            return isOpAndPerformed && (isOpDateInRequiredTimespan || isOpInCurrentTreatmentYear);
                        }) : false;


                    var treatmentYearOcts = nonErrorOctDates.Count(t => t >= treatmentYearStartDate.Date && t <= treatmentYearEndDate.Date);
                    #endregion

                    var octStatus = "OCT1";
                    if (oct.IsCancelled)
                    {
                        octStatus = "OCT4";
                    }
                    else if (nonErrorOctDatesOnLocalization.Count == 1 && !performedOpExists)
                    {
                        octStatus = "OCT6";
                    }

                    var diagnose_details = diagnoses[oct.DiagnoseID];
                    var existing_oct = existing_octs.SingleOrDefault(t => t.localization == oct.Localization);
                    var last_ivom_date = last_ivom_dates.ContainsKey(oct.Localization) ? last_ivom_dates[oct.Localization].treatment_date : DateTime.MinValue;
                    var treatment_date = last_ivom_date != null && last_ivom_date != DateTime.MinValue ? last_ivom_date : oct.TreatmentDate;

                    if (existing_oct == null)
                    {
                        existing_oct = new Oct_Model();
                        existing_oct.localization = oct.Localization;
                        existing_oct.treatment_year_date = treatmentYearStartDate;
                        existing_oct.treatment_year_octs = treatmentYearOcts;
                        existing_oct.case_id = oct.CaseID;
                        existing_oct.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnose_details);
                        existing_oct.diagnose_id = oct.DiagnoseID;
                        existing_oct.id = oct.ID.ToString();
                        existing_oct.oct_doctor_id = oct.OctDoctorID;
                        existing_oct.oct_doctor_name = oct.OctDoctorName;
                        existing_oct.patient_birthdate = oct.PatientBirthDate.Date;
                        existing_oct.patient_name = oct.PatientName;
                        existing_oct.patient_id = patient_id;
                        existing_oct.practice_id = oct.OctPracticeID;
                        existing_oct.treatment_date = treatment_date;
                        existing_oct.treatment_doctor_id = oct.OpDoctorID;
                        existing_oct.treatment_doctor_name = oct.OpDoctorName;
                        existing_oct.treatment_doctor_practice_id = oct.OpPracticeID;
                        existing_oct.treatment_doctor_practice_name = oct.OpPracticeName;
                        existing_oct.status = octStatus;
                        existing_oct.oct_date = latestOctDate;
                        existing_oct.hip_ik = patientHip.ik_number;
                        existing_oct.patient_hip = patientHip.hip_name;
                    }

                    if (existing_oct.treatment_year_date <= treatmentYearStartDate)
                    {
                        existing_oct.localization = oct.Localization;
                        existing_oct.treatment_year_date = treatmentYearStartDate;
                        existing_oct.treatment_year_octs = treatmentYearOcts;
                        existing_oct.case_id = oct.CaseID;
                        existing_oct.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnose_details);
                        existing_oct.diagnose_id = oct.DiagnoseID;
                        existing_oct.id = oct.ID.ToString();
                        existing_oct.oct_doctor_id = oct.OctDoctorID;
                        existing_oct.oct_doctor_name = oct.OctDoctorName;
                        existing_oct.practice_id = oct.OctPracticeID;
                        existing_oct.treatment_date = treatment_date;
                        existing_oct.treatment_doctor_id = oct.OpDoctorID;
                        existing_oct.treatment_doctor_name = oct.OpDoctorName;
                        existing_oct.treatment_doctor_practice_id = oct.OpPracticeID;
                        existing_oct.treatment_doctor_practice_name = oct.OpPracticeName;
                        existing_oct.status = octStatus;
                        existing_oct.oct_date = latestOctDate;
                    }

                    if (!existing_octs.Any(t => t.id == existing_oct.id))
                    {
                        existing_octs.Add(existing_oct);
                    }

                    if (existing_oct.status != "OCT6")
                    {
                        var date = existing_oct.oct_date != DateTime.MinValue ? existing_oct.oct_date : existing_oct.treatment_date;
                        var new_patient_details = existing_patient_details.SingleOrDefault(t => t.localisation == oct.Localization);
                        if (new_patient_details == null)
                        {
                            new_patient_details = new PatientDetailViewModel();
                            new_patient_details.id = existing_oct.id;
                            new_patient_details.practice_id = existing_oct.practice_id.ToString();
                            new_patient_details.date = date;
                            new_patient_details.date_string = date.ToString("dd.MM.");
                            new_patient_details.detail_type = "oct";
                            new_patient_details.localisation = existing_oct.localization;
                            new_patient_details.patient_id = existing_oct.patient_id.ToString();
                            new_patient_details.status = existing_oct.status;
                            new_patient_details.case_id = existing_oct.case_id.ToString();
                            new_patient_details.diagnose_or_medication = existing_oct.diagnose;
                            new_patient_details.doctor = existing_oct.oct_doctor_name;
                            new_patient_details.treatment_doctor_id = existing_oct.oct_doctor_id.ToString();
                            new_patient_details.diagnose_id = existing_oct.diagnose_id.ToString();
                            new_patient_details.hip_ik = patientHip.ik_number;
                        }

                        if (treatmentYearStartDate >= existing_oct.treatment_year_date)
                        {
                            new_patient_details.id = existing_oct.id;
                            new_patient_details.practice_id = existing_oct.practice_id.ToString();
                            new_patient_details.date = date;
                            new_patient_details.date_string = date.ToString("dd.MM.");
                            new_patient_details.detail_type = "oct";
                            new_patient_details.localisation = existing_oct.localization;
                            new_patient_details.patient_id = existing_oct.patient_id.ToString();
                            new_patient_details.status = existing_oct.status;
                            new_patient_details.case_id = existing_oct.case_id.ToString();
                            new_patient_details.diagnose_or_medication = existing_oct.diagnose;
                            new_patient_details.doctor = existing_oct.oct_doctor_name;
                            new_patient_details.treatment_doctor_id = existing_oct.oct_doctor_id.ToString();
                            new_patient_details.diagnose_id = existing_oct.diagnose_id.ToString();
                            new_patient_details.hip_ik = patientHip.ik_number;
                        }

                        if (!existing_patient_details.Any(t => t.id == new_patient_details.id))
                        {
                            existing_patient_details.Add(new_patient_details);
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Planning
        protected override void RebuildPlanning(Guid patient_id)
        {
            var all_cases = cls_Get_ElasticRefresh_Cases_for_PatientIDs.Invoke(connection, transaction, new P_ER_GERCfPIDs_0843() { PatientIDs = new Guid[] { patient_id } }, securityTicket).Result.Where(t => !t.performed).ToArray();
            if (all_cases.Any())
            {
                var doctor_bpt_ids = new List<Guid>();
                var practice_bpt_ids = new List<Guid>();
                var order_ids = new List<Guid>();
                var case_ids = new List<Guid>();

                for (var i = 0; i < all_cases.Length; i++)
                {
                    var _case = all_cases[i];
                    doctor_bpt_ids.Add(_case.op_doctor_bpt_id);
                    order_ids.Add(_case.order_id);
                    case_ids.Add(_case.case_id);
                }
                var order_statuses = cls_Get_ElasticRefresh_Order_History_for_OrderIDs.Invoke(connection, transaction, new P_ER_GEROHfOIDs_0942() { OrderIDs = order_ids.ToArray() }, securityTicket).Result.GroupBy(t => t.order_id).ToDictionary(t => t.Key, t => t.OrderByDescending(x => x.order_status_code).ToList());
                var aftercares = cls_Get_RelevantActionData_for_PatientID.Invoke(connection, transaction, new P_ER_GRADfPID_1734() { PatientIDs = new Guid[] { patient_id } }, securityTicket).Result
                    .Where(r => r.ActionTypeGpmID == EActionType.PlannedAftercare.Value() && !r.IsDeleted)
                    .GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.ToList());

                doctor_bpt_ids.AddRange(aftercares.SelectMany(t => t.Value.Select(r => r.ToBePerformedBy_BusinessParticipant_RefID)));
                var doctors = cls_Get_DoctorBasicInformation_for_DoctorBptIDs.Invoke(connection, transaction, new P_ER_GDBIfDBptIDs_0857() { DoctorBptIDs = doctor_bpt_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.bpt_id, t => t);
                practice_bpt_ids = doctors.Select(t => t.Value.practice_bpt_id).ToList();

                if (aftercares.Any())
                {
                    practice_bpt_ids.AddRange(aftercares.SelectMany(t => t.Value.Select(x => x.ToBePerformedBy_BusinessParticipant_RefID)).ToList());
                }

                var practices = new Dictionary<Guid, ER_GPBIfPBptIDs_0908>();
                if (practice_bpt_ids.Any())
                {
                    practices = cls_Get_PracticeBasicInformation_for_PracticeBptIDs.Invoke(connection, transaction, new P_ER_GPBIfPBptIDs_0908() { PracticeBptIDs = practice_bpt_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.practice_bpt_id, t => t);
                }

                var patient = patients[patient_id];

                foreach (var _case in all_cases)
                {
                    var is_orders_drug = _case.order_id != Guid.Empty;
                    var case_model_elastic = new Case_Model();
                    case_model_elastic.aftercare_name = "-";

                    if (aftercares.ContainsKey(_case.case_id))
                    {
                        var case_aftercare = aftercares[_case.case_id].Last();

                        if (doctors.ContainsKey(case_aftercare.ToBePerformedBy_BusinessParticipant_RefID))
                        {
                            var acDoctor = doctors[case_aftercare.ToBePerformedBy_BusinessParticipant_RefID];
                            case_model_elastic.is_aftercare_doctor = true;
                            case_model_elastic.aftercare_name = GenericUtils.GetDoctorName(acDoctor);
                            case_model_elastic.aftercare_doctor_practice_id = acDoctor.doctor_id.ToString();
                            case_model_elastic.aftercare_doctor_lanr = acDoctor.lanr;

                            if (practices.ContainsKey(acDoctor.practice_id))
                            {
                                var practice = practices[acDoctor.practice_bpt_id];
                                case_model_elastic.aftercare_doctors_practice_id = practice.practice_id.ToString();
                                case_model_elastic.aftercare_doctors_practice_name = practice.practice_name;
                            }
                        }
                        else if (practices.ContainsKey(case_aftercare.ToBePerformedBy_BusinessParticipant_RefID))
                        {
                            var practice = practices[case_aftercare.ToBePerformedBy_BusinessParticipant_RefID];
                            case_model_elastic.aftercare_name = practice.practice_name;
                            case_model_elastic.aftercare_doctor_practice_id = practice.practice_id.ToString();
                            case_model_elastic.aftercare_doctor_lanr = practice.bsnr;
                        }
                    }

                    if (_case.diagnose_id != Guid.Empty && diagnoses.ContainsKey(_case.diagnose_id))
                    {
                        var diagnose = diagnoses[_case.diagnose_id];
                        case_model_elastic.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnose);
                        case_model_elastic.diagnose_id = _case.diagnose_id.ToString();
                    }

                    var drug = drugs[_case.drug_id];
                    case_model_elastic.drug = drug.DrugName;
                    case_model_elastic.drug_id = drug.DrugID.ToString();
                    case_model_elastic.id = _case.case_id.ToString();
                    case_model_elastic.is_orders_drug = is_orders_drug;
                    case_model_elastic.localization = _case.localization == null ? "-" : _case.localization;
                    case_model_elastic.patient_birthdate = patient.BirthDate;
                    case_model_elastic.patient_birthdate_string = patient.BirthDate.ToString("dd.MM.yyyy");
                    case_model_elastic.patient_hip = patient.HipName;
                    case_model_elastic.patient_insurance_number = patient.InsuranceIdNumber;
                    case_model_elastic.patient_id = _case.patient_id.ToString();
                    case_model_elastic.patient_name = patient.LastName + ", " + patient.FirstName;
                    case_model_elastic.practice_id = _case.practice_id.ToString();
                    case_model_elastic.previous_status_drug_order = "";
                    case_model_elastic.status_drug_order = "";
                    if (is_orders_drug)
                    {
                        var order_status_history = order_statuses[_case.order_id].ToList();
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

                    case_model_elastic.status_treatment = _case.cancelled ? "OP4" : "OP1";
                    case_model_elastic.treatment_date = _case.treatment_date;
                    case_model_elastic.treatment_date_day_month = _case.treatment_date.ToString("dd.MM");
                    case_model_elastic.treatment_date_month_year = _case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                    if (_case.op_doctor_bpt_id != Guid.Empty && doctors.ContainsKey(_case.op_doctor_bpt_id))
                    {
                        var doctor = doctors[_case.op_doctor_bpt_id];
                        case_model_elastic.treatment_doctor_id = doctor.doctor_id.ToString();
                        case_model_elastic.treatment_doctor_lanr = doctor.lanr;
                        case_model_elastic.treatment_doctor_name = GenericUtils.GetDoctorName(doctor);
                    }

                    existing_planned_cases.Add(case_model_elastic);

                    var new_patient_details = new PatientDetailViewModel();
                    new_patient_details.id = _case.action_id.ToString();
                    new_patient_details.practice_id = case_model_elastic.practice_id;
                    new_patient_details.date = case_model_elastic.treatment_date;
                    new_patient_details.date_string = case_model_elastic.treatment_date.ToString("dd.MM.");
                    new_patient_details.detail_type = "op";
                    new_patient_details.localisation = case_model_elastic.localization;
                    new_patient_details.patient_id = case_model_elastic.patient_id;
                    new_patient_details.status = _case.cancelled ? "OP4" : "FS0";
                    new_patient_details.order_status = case_model_elastic.status_drug_order;
                    new_patient_details.previous_order_status = case_model_elastic.previous_status_drug_order;
                    new_patient_details.case_id = case_model_elastic.id.ToString();
                    new_patient_details.diagnose_or_medication = case_model_elastic.diagnose;
                    new_patient_details.doctor = case_model_elastic.treatment_doctor_name;
                    new_patient_details.treatment_doctor_id = case_model_elastic.treatment_doctor_id;
                    new_patient_details.diagnose_id = case_model_elastic.diagnose_id;
                    new_patient_details.hip_ik = patient.HipIkNumber;
                    new_patient_details.drug = case_model_elastic.drug;
                    new_patient_details.drug_id = case_model_elastic.drug_id;

                    existing_patient_details.Add(new_patient_details);
                }
            }
        }
        #endregion

        #region Aftercare
        protected override void RebuildAftercares(Guid patient_id)
        {
            var acPlannedActionTypeId = cls_Get_ActionTypeID.Invoke(connection, transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedAftercare.Value() }, securityTicket).Result;
            var fake_and_documentation_case_properties = cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs.Invoke(connection, transaction, new P_ER_GERCPfPIDaPGpmIDs_1011()
            {
                PatientID = patient_id,
                PropertyGpmIDs = new string[] { ECaseProperty.DocumentationOnly.Value(), ECaseProperty.FakeCase.Value() }
            }, securityTicket).Result;
            var all_cases = cls_Get_ElasticRefresh_Cases_for_PatientIDs.Invoke(connection, transaction, new P_ER_GERCfPIDs_0843()
            {
                IsPerformed = true,
                PatientIDs = new Guid[] { patient_id }
            }, securityTicket).Result.Where(t => t.performed && !fake_and_documentation_case_properties.Any(r => r.CaseID == t.case_id && r.Value_Boolean)).ToList();

            if (all_cases.Any())
            {
                var aftercare_diagnose_cache = cls_Get_ElasticRefresh_Aftercare_Diagnoses_for_PatientID.Invoke(connection, transaction, new P_ER_GERADfPID_1020() { PatientID = patient_id }, securityTicket).Result.ToDictionary(t => t.action_id, t => t);
                var all_case_aftercares = cls_Get_ElasticRefresh_Aftercares_for_CaseIDs.Invoke(connection, transaction, new P_ER_GERAfCIDs_1023()
                {
                    AftercarePlannedActionTypeID = acPlannedActionTypeId,
                    CaseIDs = all_cases.Select(t => t.case_id).ToArray()
                }, securityTicket).Result.Where(t => !t.performed).GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

                var doctor_bpt_ids = all_case_aftercares.SelectMany(t => t.Value.Select(x => x.performed_by_bpt_id)).ToList();
                doctor_bpt_ids.AddRange(all_cases.Select(t => t.op_doctor_bpt_id));
                var doctors = cls_Get_DoctorBasicInformation_for_DoctorBptIDs.Invoke(connection, transaction, new P_ER_GDBIfDBptIDs_0857() { DoctorBptIDs = doctor_bpt_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.bpt_id, t => t);
                var practice_bpt_ids = doctors.Select(t => t.Value.practice_bpt_id).ToList();

                if (all_case_aftercares.Any())
                {
                    practice_bpt_ids.AddRange(all_case_aftercares.SelectMany(t => t.Value.Select(x => x.performed_by_bpt_id)).ToList());
                }

                var practices = new Dictionary<Guid, ER_GPBIfPBptIDs_0908>();
                if (practice_bpt_ids.Any())
                {
                    practices = cls_Get_PracticeBasicInformation_for_PracticeBptIDs.Invoke(connection, transaction, new P_ER_GPBIfPBptIDs_0908() { PracticeBptIDs = practice_bpt_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.practice_bpt_id, t => t);
                }

                foreach (var _case in all_cases)
                {
                    if (!all_case_aftercares.ContainsKey(_case.case_id))
                    {
                        continue;
                    }

                    var patient_details = patients[_case.patient_id];
                    var op_doctor = doctors[_case.op_doctor_bpt_id];
                    var aftercares = all_case_aftercares[_case.case_id];
                    foreach (var aftercare in aftercares)
                    {
                        var aftercare_elastic = new Aftercare_Model();
                        var aftercare_bpt_id = aftercare.performed_by_bpt_id;
                        if (aftercare_bpt_id != Guid.Empty)
                        {
                            if (doctors.ContainsKey(aftercare_bpt_id))
                            {
                                var aftercare_doctor = doctors[aftercare_bpt_id];
                                aftercare_elastic.aftercare_doctor_name = GenericUtils.GetDoctorName(aftercare_doctor);
                                aftercare_elastic.aftercare_doctor_practice_id = aftercare_doctor.doctor_id.ToString();
                                aftercare_elastic.practice_id = aftercare_doctor.practice_id.ToString();
                                aftercare_elastic.ac_lanr = aftercare_doctor.lanr;
                                aftercare_elastic.aftercare_doctor_account_id = aftercare_doctor.account_id.ToString();
                            }
                            else if (practices.ContainsKey(aftercare_bpt_id))
                            {
                                var aftercare_practice = practices[aftercare_bpt_id];
                                aftercare_elastic.aftercare_doctor_practice_id = aftercare_practice.practice_id.ToString();
                                aftercare_elastic.practice_id = aftercare_practice.practice_id.ToString();
                                aftercare_elastic.aftercare_doctor_name = aftercare_practice.practice_name;
                                aftercare_elastic.aftercare_doctor_account_id = aftercare_practice.account_id.ToString();
                            }
                        }


                        var treatment_practice = practices[op_doctor.practice_bpt_id];

                        // base data
                        aftercare_elastic.case_id = _case.case_id.ToString();
                        aftercare_elastic.status = aftercare.cancelled ? "AC4" : "AC1";
                        aftercare_elastic.id = aftercare.action_id.ToString();

                        // op data
                        aftercare_elastic.treatment_doctor_id = op_doctor.doctor_id.ToString();
                        aftercare_elastic.treatment_doctors_practice_id = _case.practice_id.ToString();
                        aftercare_elastic.treatment_date = _case.treatment_date;
                        aftercare_elastic.treatment_date_day_month = _case.treatment_date.ToString("dd.MM.");
                        aftercare_elastic.treatment_date_month_year = _case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                        aftercare_elastic.treatment_doctor_name = GenericUtils.GetDoctorName(op_doctor);
                        aftercare_elastic.treatment_doctor_practice_name = treatment_practice.practice_name;
                        aftercare_elastic.bsnr = treatment_practice.bsnr;
                        aftercare_elastic.op_lanr = op_doctor.lanr;
                        if (aftercare_diagnose_cache.ContainsKey(aftercare.action_id))
                        {
                            var diagnose_details = aftercare_diagnose_cache[aftercare.action_id];
                            aftercare_elastic.diagnose = diagnose_details.diagnose_name;
                            aftercare_elastic.localization = diagnose_details.localization;
                            aftercare_elastic.diagnose_id = diagnose_details.diagnose_id.ToString();
                        }
                        else
                        {
                            var diagnose_details = diagnoses[_case.diagnose_id];
                            aftercare_elastic.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnose_details);
                            aftercare_elastic.localization = _case.localization;
                            aftercare_elastic.diagnose_id = _case.diagnose_id.ToString();
                        }

                        aftercare_elastic.drug_id = _case.drug_id.ToString();

                        // patient
                        aftercare_elastic.hip = patient_details.HipName;
                        aftercare_elastic.hip_ik_number = patient_details.HipIkNumber;
                        aftercare_elastic.patient_insurance_number = patient_details.InsuranceIdNumber;
                        aftercare_elastic.patient_birthdate = patient_details.BirthDate;
                        aftercare_elastic.patient_birthdate_string = patient_details.BirthDate.ToString("dd.MM.yyyy");
                        aftercare_elastic.patient_name = patient_details.LastName + ", " + patient_details.FirstName;
                        aftercare_elastic.patient_id = _case.patient_id.ToString();

                        existing_aftercares.Add(aftercare_elastic);

                        var new_patient_details = new PatientDetailViewModel();
                        new_patient_details.id = aftercare_elastic.id;
                        new_patient_details.practice_id = aftercare_elastic.practice_id;
                        new_patient_details.date = aftercare_elastic.treatment_date;
                        new_patient_details.date_string = aftercare_elastic.treatment_date.ToString("dd.MM.");
                        new_patient_details.detail_type = "ac";
                        new_patient_details.localisation = aftercare_elastic.localization;
                        new_patient_details.patient_id = aftercare_elastic.patient_id;
                        new_patient_details.status = aftercare_elastic.status;
                        new_patient_details.case_id = aftercare_elastic.case_id.ToString();
                        new_patient_details.diagnose_or_medication = aftercare_elastic.diagnose;
                        new_patient_details.doctor = aftercare_elastic.aftercare_doctor_name;
                        new_patient_details.treatment_doctor_id = aftercare_elastic.treatment_doctor_id;
                        new_patient_details.diagnose_id = aftercare_elastic.diagnose_id;
                        new_patient_details.hip_ik = patient_details.HipIkNumber;
                        new_patient_details.drug_id = aftercare_elastic.drug_id;
                        new_patient_details.aftercare_doctor_practice_id = aftercare_elastic.aftercare_doctor_practice_id;

                        existing_patient_details.Add(new_patient_details);
                    }
                }
            }
        }
        #endregion

        #region Order
        protected override void RebuildOrders(Guid patient_id)
        {
            var orders = cls_Get_ElasticRefresh_Orders_for_PatientID.Invoke(connection, transaction, new P_ER_GEROfPID_1123() { PatientIDs = new Guid[] { patient_id } }, securityTicket).Result;
            if (orders.Any())
            {
                var order_ids = new List<Guid>();
                var case_ids = new List<Guid>();
                for (var i = 0; i < orders.Length; i++)
                {
                    var order = orders[i];
                    order_ids.Add(order.order_id);
                    case_ids.Add(order.case_id);
                }

                var pharmacy_bpt_ids = orders.Select(t => t.pharmacy_bpt_id).ToArray();
                var order_statuses = cls_Get_ElasticRefresh_Order_History_for_OrderIDs.Invoke(connection, transaction, new P_ER_GEROHfOIDs_0942() { OrderIDs = order_ids.ToArray() }, securityTicket).Result.GroupBy(t => t.order_id).ToDictionary(t => t.Key, t => t.ToList());
                var pharmacies = cls_Get_PharmacyBasicInformation_for_PharmacyBptIDs.Invoke(connection, transaction, new P_ER_GPBIfPBptIDs_1132() { PharmacyBptIDs = pharmacy_bpt_ids }, securityTicket).Result.ToDictionary(t => t.pharmacy_bpt_id, t => t);
                var all_treatment_data = cls_Get_ElasticRefresh_TreatmentData_for_CaseIDs.Invoke(connection, transaction, new P_ER_GERTDfCIDs_1200() { CaseIDs = case_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.case_id, t => t);
                var doctor_bpt_ids = all_treatment_data.Select(t => t.Value.op_doctor_bpt_id).ToArray();
                var doctors = doctor_bpt_ids.Any() ? cls_Get_DoctorBasicInformation_for_DoctorBptIDs.Invoke(connection, transaction, new P_ER_GDBIfDBptIDs_0857()
                {
                    DoctorBptIDs = doctor_bpt_ids
                }, securityTicket).Result.ToDictionary(t => t.bpt_id, t => t) : new Dictionary<Guid, ER_GDBIfDBptIDs_0857>();

                var practice_id = orders.First().practice_id;
                var practice = cls_Get_PracticeName_for_PracticeID.Invoke(connection, transaction, new P_ER_GPNfPID_1214() { PracticeID = practice_id }, securityTicket).Result;
                foreach (var order in orders)
                {
                    var order_elastic = new Order_Model();

                    // base data
                    order_elastic.practice_id = order.practice_id.ToString();
                    order_elastic.isOverdue = (order.delivery_time_from < DateTime.Now).ToString();
                    order_elastic.drug_id = order.drug_id.ToString();
                    order_elastic.case_id = order.case_id.ToString();
                    order_elastic.practice_id = order.practice_id.ToString();
                    order_elastic.drug = drugs[order.drug_id].DrugName;


                    // treatment data
                    order_elastic.treatment_doctor_name = "-";
                    order_elastic.diagnose = "-";
                    order_elastic.localization = "-";
                    if (all_treatment_data.ContainsKey(order.case_id))
                    {
                        var treatment_data = all_treatment_data[order.case_id];
                        if (treatment_data.diagnose_id != Guid.Empty)
                        {
                            order_elastic.diagnose_id = treatment_data.diagnose_id.ToString();

                            order_elastic.localization = treatment_data.localization;
                            order_elastic.diagnose = GenericUtils.GetDiagnoseNamePascal(diagnoses[treatment_data.diagnose_id]);

                            if (doctors.ContainsKey(treatment_data.op_doctor_bpt_id))
                            {
                                var doctor = doctors[treatment_data.op_doctor_bpt_id];
                                order_elastic.treatment_doctor_name = GenericUtils.GetDoctorName(doctor);
                                order_elastic.doctor_id = doctor.doctor_id.ToString();
                                order_elastic.lanr = doctor.lanr;
                                order_elastic.treatment_doctor_practice_name = practice.name;
                                order_elastic.bsnr = practice.bsnr;
                            }
                        }
                    }

                    var treatment_date = DateTime.SpecifyKind(order.treatment_date, DateTimeKind.Utc);
                    var delivery_date = DateTime.SpecifyKind(order.delivery_date, DateTimeKind.Utc);

                    var delivery_date_from = delivery_date > treatment_date && order_elastic.localization != "-" ? treatment_date.AddHours(order.delivery_time_from.Hour).AddMinutes(order.delivery_time_from.Minute) : order.delivery_time_from;
                    var delivery_date_to = delivery_date > treatment_date && order_elastic.localization != "-" ? treatment_date.AddHours(order.delivery_time_to.Hour).AddMinutes(order.delivery_time_to.Minute) : order.delivery_time_to;

                    order_elastic.id = order.order_id.ToString();
                    order_elastic.status_drug_order = order.status_code.ToString() == "7" ? "MO6" : "MO" + order.status_code.ToString();
                    order_elastic.delivery_time_from = delivery_date_from;
                    order_elastic.delivery_time_to = delivery_date_to;
                    order_elastic.delivery_time_string = order_elastic.delivery_time_from.ToString("HH:mm") + " - " + order_elastic.delivery_time_to.ToString("HH:mm");

                    order_elastic.is_orders_drug = true;

                    order_elastic.treatment_date = delivery_date > treatment_date && order_elastic.localization != "-" ? treatment_date : delivery_date;
                    order_elastic.treatment_date_day_month = order_elastic.treatment_date.ToString("dd.MM.");
                    order_elastic.treatment_date_month_year = order_elastic.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                    order_elastic.order_modification_timestamp = order.order_modification_timestamp;
                    order_elastic.order_modification_timestamp_string = order.order_modification_timestamp.ToString("dd.MM.yyyy");

                    // patient data
                    var patient = patients[order.patient_id];
                    order_elastic.patient_name = patient.LastName + ", " + patient.FirstName;
                    order_elastic.patient_birthdate_string = patient.BirthDate.ToString("dd.MM.yyyy");
                    order_elastic.patient_birthdate = patient.BirthDate;
                    order_elastic.hip = patient.HipName;
                    order_elastic.patient_insurance_number = patient.InsuranceIdNumber;
                    order_elastic.patient_id = order.patient_id.ToString();

                    // pharmacy
                    if (pharmacies.ContainsKey(order.pharmacy_bpt_id))
                    {
                        var pharmacy = pharmacies[order.pharmacy_bpt_id];
                        order_elastic.pharmacy_id = pharmacy.pharmacy_id.ToString();
                        order_elastic.pharmacy_name = pharmacy.pharmacy_name;
                    }

                    existing_orders.Add(order_elastic);

                    var new_patient_details = new PatientDetailViewModel();

                    new_patient_details.case_id = order_elastic.case_id;
                    new_patient_details.date = order_elastic.treatment_date;
                    new_patient_details.date_string = order_elastic.treatment_date.ToString("dd.MM.");
                    new_patient_details.practice_id = order_elastic.practice_id;
                    new_patient_details.detail_type = "order";
                    new_patient_details.diagnose_or_medication = order_elastic.drug;
                    new_patient_details.id = order_elastic.id;
                    new_patient_details.status = order_elastic.status_drug_order;
                    new_patient_details.order_status = order_elastic.status_drug_order;
                    new_patient_details.hip_ik = patient.HipIkNumber;

                    if (new_patient_details.status == "MO6")
                    {
                        var order_status_history = order_statuses[order.order_id];
                        new_patient_details.previous_order_status = "MO" + order_status_history.First(t => t.order_status_code != 7 && t.order_status_code != 6).order_status_code;
                    }

                    new_patient_details.patient_id = order_elastic.patient_id;
                    new_patient_details.drug_id = order_elastic.drug_id;
                    new_patient_details.order_id = order_elastic.id;
                    new_patient_details.drug = order_elastic.drug;
                    new_patient_details.pharmacy_id = order_elastic.pharmacy_id;
                    new_patient_details.pharmacy_name = order_elastic.pharmacy_name;

                    existing_patient_details.Add(new_patient_details);
                }
            }
        }
        #endregion

        #region Patient in other practices
        protected override void RebuildPatientInOtherPractieces(Guid patient_id)
        {
            var patient = patients[patient_id];
            var relevant_actions = cls_Get_ElasticRefresh_RelevantActions_for_PatientID.Invoke(connection, transaction, new P_ER_GERRAfPID_1629() { PatientID = patient_id }, securityTicket).Result;

            var originating_practice = cls_Get_Patient_PracticeName_for_PatientID.Invoke(connection, transaction, new P_P_PA_GPPNfPID_1131() { PatientID = patient_id }, securityTicket).Result;
            var practicesSet = new List<Guid>();
            var culture = new System.Globalization.CultureInfo("de", true);
            if (relevant_actions.Any())
            {
                var bpt_ids = relevant_actions.Select(t => t.performing_bpt_id).ToArray();
                if (bpt_ids.Any())
                {
                    var doctors = cls_Get_DoctorBasicInformation_for_DoctorBptIDs.Invoke(connection, transaction, new P_ER_GDBIfDBptIDs_0857() { DoctorBptIDs = bpt_ids }, securityTicket).Result.ToDictionary(t => t.bpt_id, t => t);
                    var practices = cls_Get_PracticeBasicInformation_for_PracticeBptIDs.Invoke(connection, transaction, new P_ER_GPBIfPBptIDs_0908() { PracticeBptIDs = bpt_ids }, securityTicket).Result.ToDictionary(t => t.practice_bpt_id, t => t);

                    var used_practices = new List<Guid>();
                    foreach (var action in relevant_actions)
                    {
                        var practice_id = Guid.Empty;
                        if (doctors.ContainsKey(action.performing_bpt_id))
                        {
                            var doctor = doctors[action.performing_bpt_id];
                            practice_id = doctor.practice_id;
                        }
                        else if (practices.ContainsKey(action.performing_bpt_id))
                        {
                            var practice = practices[action.performing_bpt_id];
                            practice_id = practice.practice_id;
                        }
                        else
                        {
                            continue;
                        }

                        if (originating_practice.practice_id == practice_id)
                        {
                            continue;
                        }

                        if (practicesSet.Contains(practice_id))
                        {
                            continue;
                        }

                        practicesSet.Add(practice_id);

                        var patient_elastic = new Patient_Model();
                        patient_elastic.birthday = DateTime.Parse(patient.BirthDate.ToString("dd.MM.yyyy"), culture, System.Globalization.DateTimeStyles.AssumeLocal);
                        patient_elastic.birthday_string = patient.BirthDate.ToString("dd.MM.yyyy");
                        patient_elastic.name = patient.LastName + ", " + patient.FirstName;
                        patient_elastic.health_insurance_provider = patient.HipName;
                        patient_elastic.name_with_birthdate = patient.FirstName + " " + patient.LastName + " (" + patient.BirthDate.ToString("dd.MM.yyyy") + ")";
                        patient_elastic.id = Guid.NewGuid().ToString();
                        patient_elastic.insurance_id = String.IsNullOrEmpty(patient.InsuranceIdNumber) ? "-" : patient.InsuranceIdNumber;
                        patient_elastic.insurance_status = String.IsNullOrEmpty(patient.InsuranceStatus) ? "-" : patient.InsuranceStatus;
                        patient_elastic.practice_id = practice_id.ToString();

                        patient_elastic.originating_patient_id = patient.PatientID.ToString();
                        patient_elastic.originating_practice_id = originating_practice.practice_id.ToString();
                        patient_elastic.originating_practice_name = originating_practice.name;

                        switch (Convert.ToInt32(patient.Gender))
                        {
                            case 0: patient_elastic.sex = "M"; break;
                            case 1: patient_elastic.sex = "W"; break;
                            default: patient_elastic.sex = "o.A."; break;
                        }

                        existing_patients.Add(patient_elastic);
                    }
                }
            }
        }
        #endregion

        #region Data import
        protected override void ImportPatientToOtherPractices(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();

            Elastic_Utils.DeleteDataForField<Patient_Model>(elastic_index, "patient", "originating_patient_id", elastic_patient_id);

            if (existing_patients.Any())
            {
                Add_New_Patient.Import_Patients_to_ElasticDB(existing_patients, elastic_index);
            }
        }

        protected override void ImportSettlement(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();

            Elastic_Utils.DeleteDataForPatientID<Settlement_Model>(elastic_index, "settlement", elastic_patient_id);
            Elastic_Utils.DeleteDataForPatientID<Submitted_Case_Model>(elastic_index, "submitted_case", elastic_patient_id);

            if (existing_settlements.Any())
            {
                Add_new_Settlement.Import_Settlement_to_ElasticDB(existing_settlements, elastic_index);
            }

            if (existing_treatments.Any())
            {
                Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(existing_treatments, elastic_index);
            }
        }

        protected override void ImportPlanning(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();

            Elastic_Utils.DeleteDataForPatientID<Case_Model>(elastic_index, "case", elastic_patient_id);

            if (existing_planned_cases.Any())
            {
                Add_New_Case.Import_Case_Data_to_ElasticDB(existing_planned_cases, elastic_index);
            }
        }

        protected override void ImportOct(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();

            Elastic_Utils.DeleteDataForPatientID<Oct_Model>(elastic_index, "oct", elastic_patient_id);
            if (existing_octs.Any())
            {
                Add_New_Oct.Import_Oct_Data_to_ElasticDB(existing_octs, elastic_index);
            }
        }

        protected override void ImportAftercares(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();
            Elastic_Utils.DeleteDataForPatientID<Aftercare_Model>(elastic_index, "aftercare", elastic_patient_id);
            if (existing_aftercares.Any())
            {
                Add_New_Aftercare.Import_Aftercare_Data_to_ElasticDB(existing_aftercares, elastic_index);
            }
        }

        protected override void ImportOrders(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();

            Elastic_Utils.DeleteDataForPatientID<Order_Model>(elastic_index, "order", elastic_patient_id);
            if (existing_orders.Any())
            {
                Add_New_Order.Import_Order_Data_to_ElasticDB(existing_orders, elastic_index);
            }
        }

        protected override void ImportPatientDetails(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();

            var types = new List<string>();
            if (ShouldUpdateIvoms)
            {
                types.Add("op");
            }

            if (ShouldUpdateAftercares)
            {
                types.Add("ac");
            }

            if (ShouldUpdateOcts)
            {
                types.Add("oct");
            }

            if (ShouldUpdateOrders)
            {
                types.Add("order");
            }

            Elastic_Utils.DeleteDataForPatientID<PatientDetailViewModel>(elastic_index, "patient_details", elastic_patient_id, types);

            if (existing_patient_details.Any())
            {
                Add_New_Patient.ImportPatientDetailsToElastic(existing_patient_details, elastic_index);
            }
        }
        #endregion

        #region Backup
        protected override void BackupExisting(Guid patient_id)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = patient_id.ToString();

            existing_settlements = Elastic_Utils.GetDataForPatientID<Settlement_Model>(elastic_index, "settlement", elastic_patient_id).ToList();
            existing_patient_details = Elastic_Utils.GetDataForPatientID<PatientDetailViewModel>(elastic_index, "patient_details", elastic_patient_id).ToList();
            existing_octs = Elastic_Utils.GetDataForPatientID<Oct_Model>(elastic_index, "oct", elastic_patient_id).ToList();
            existing_planned_cases = Elastic_Utils.GetDataForPatientID<Case_Model>(elastic_index, "case", elastic_patient_id).ToList();
            existing_aftercares = Elastic_Utils.GetDataForPatientID<Aftercare_Model>(elastic_index, "aftercare", elastic_patient_id).ToList();
            existing_treatments = Elastic_Utils.GetDataForPatientID<Submitted_Case_Model>(elastic_index, "submitted_case", elastic_patient_id).ToList();
        }
        #endregion
    }
}
