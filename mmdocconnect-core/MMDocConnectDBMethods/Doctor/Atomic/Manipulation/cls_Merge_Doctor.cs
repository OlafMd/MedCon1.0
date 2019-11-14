/* 
 * Generated on 09/03/15 13:22:32
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_HEC;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_HEC_ACT;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using CL1_HEC_CAS;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectDocApp;

namespace MMDocConnectDBMethods.Doctor.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Merge_Doctor.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Merge_Doctor
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_DO_MD_1321 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            returnValue.Result = Parameter.DoctorID;

            var temporary_doctor_bpt_id = Guid.Empty;
            List<Guid> case_ids = new List<Guid>();
            var BusinessParticipantID = Guid.Empty;

            #region PURGE TEMPORARY DOCTOR
            var temporary_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { HEC_DoctorID = Parameter.TemporaryDoctorID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
            if (temporary_doctor != null)
            {
                temporary_doctor.IsDeleted = true;
                temporary_doctor.Save(Connection, Transaction);

                var temporary_doctor_bpt = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query() { CMN_BPT_BusinessParticipantID = temporary_doctor.BusinessParticipant_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                if (temporary_doctor_bpt != null)
                {
                    temporary_doctor_bpt_id = temporary_doctor_bpt.CMN_BPT_BusinessParticipantID;
                    temporary_doctor_bpt.IsDeleted = true;
                    temporary_doctor_bpt.Save(Connection, Transaction);

                    var temporary_doctor_person_info = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query() { CMN_PER_PersonInfoID = temporary_doctor_bpt.IfNaturalPerson_CMN_PER_PersonInfo_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                    if (temporary_doctor_person_info != null)
                    {
                        temporary_doctor_person_info.IsDeleted = true;
                        temporary_doctor_person_info.Save(Connection, Transaction);

                        var temporary_doctor_communication_contact = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query() { PersonInfo_RefID = temporary_doctor_person_info.CMN_PER_PersonInfoID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                        foreach (var tdc in temporary_doctor_communication_contact)
                        {
                            tdc.IsDeleted = true;
                            tdc.Save(Connection, Transaction);
                        }
                    }
                }

                var temporary_doctor_universal_property_value = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query() { HEC_Doctor_RefID = temporary_doctor.HEC_DoctorID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                if (temporary_doctor_universal_property_value != null)
                {
                    temporary_doctor_universal_property_value.IsDeleted = true;
                    temporary_doctor_universal_property_value.Save(Connection, Transaction);

                    var temporary_doctor_universal_property = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query() { PropertyName = "Comment", HEC_Doctor_UniversalPropertyID = temporary_doctor_universal_property_value.HEC_Doctor_UniversalPropertyValueID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                    if (temporary_doctor_universal_property != null)
                    {
                        temporary_doctor_universal_property.IsDeleted = true;
                        temporary_doctor_universal_property.Save(Connection, Transaction);
                    }
                }
            }
            #endregion

            #region GET MERGED DOCTOR BPT
            var merge_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { HEC_DoctorID = Parameter.DoctorID, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).SingleOrDefault();
            if (merge_doctor != null)
            {
                BusinessParticipantID = merge_doctor.BusinessParticipant_RefID;
            }
            else
            {
                throw new Exception("Doctor not found");
            }
            #endregion

            #region LINK AFTERCARES TO MERGED DOCTOR
            var aftercare_planned_actions = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsPerformed = false,
                IsCancelled = false,
                ToBePerformedBy_BusinessParticipant_RefID = temporary_doctor_bpt_id
            });

            foreach (var aftercare in aftercare_planned_actions)
            {
                aftercare.ToBePerformedBy_BusinessParticipant_RefID = BusinessParticipantID;
                aftercare.Modification_Timestamp = DateTime.Now;

                aftercare.Save(Connection, Transaction);

                var case_id = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query() { PlannedAction_RefID = aftercare.HEC_ACT_PlannedActionID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                if (case_id != null)
                {
                    case_ids.Add(case_id.Case_RefID);
                }
            }
            #endregion

            #region UPDATE ELASTIC
            List<Case_Model> cases = new List<Case_Model>();
            List<Aftercare_Model> aftercares = new List<Aftercare_Model>();
            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
            List<Settlement_Model> settlements = new List<Settlement_Model>();
            Dictionary<Guid, CAS_GDDfDID_1608> diagnose_data_cache = new Dictionary<Guid, CAS_GDDfDID_1608>();
            Dictionary<Guid, CAS_GDDfDID_1614> drug_data_cache = new Dictionary<Guid, CAS_GDDfDID_1614>();
            Dictionary<Guid, DO_GDDfDID_0823> treatment_doctor_data_cache = new Dictionary<Guid, DO_GDDfDID_0823>();
            Dictionary<Guid, P_PA_GPDfPID_1124> patient_data_cache = new Dictionary<Guid, P_PA_GPDfPID_1124>();
            Dictionary<Guid, DO_GPDfPID_1432> treatment_practice_data_cache = new Dictionary<Guid, DO_GPDfPID_1432>();
            var merged_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.DoctorID }, securityTicket).Result.SingleOrDefault();

            var doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.DoctorID }, securityTicket).Result.SingleOrDefault();
            if (doctor_details != null)
            {
                foreach (var case_id in case_ids)
                {
                    var treatment_planned_action = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result;
                    if (treatment_planned_action != null)
                    {
                        #region IF CASE SUBMITTED, CREATE AFTERCARE
                        if (treatment_planned_action.is_treatment_performed)
                        {
                            var case_details = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;

                            #region CACHE
                            if (!diagnose_data_cache.ContainsKey(case_details.diagnose_id))
                            {
                                diagnose_data_cache.Add(case_details.diagnose_id, cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_details.diagnose_id }, securityTicket).Result);
                            }
                            var diagnose_details = diagnose_data_cache[case_details.diagnose_id];

                            if (!drug_data_cache.ContainsKey(case_details.drug_id))
                            {
                                drug_data_cache.Add(case_details.drug_id, cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = case_details.drug_id }, securityTicket).Result);
                            }
                            var drug_details = drug_data_cache[case_details.drug_id];

                            if (!treatment_doctor_data_cache.ContainsKey(case_details.op_doctor_id))
                            {
                                treatment_doctor_data_cache.Add(case_details.op_doctor_id, cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_details.op_doctor_id }, securityTicket).Result.SingleOrDefault());
                            }
                            var treatment_doctor_details = treatment_doctor_data_cache[case_details.op_doctor_id];

                            if (!patient_data_cache.ContainsKey(case_details.patient_id))
                            {
                                patient_data_cache.Add(case_details.patient_id, cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = case_details.patient_id }, securityTicket).Result);
                            }
                            var patient_details = patient_data_cache[case_details.patient_id];

                            if (!treatment_practice_data_cache.ContainsKey(case_details.practice_id))
                            {
                                treatment_practice_data_cache.Add(case_details.practice_id, cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_details.practice_id }, securityTicket).Result.FirstOrDefault());
                            }
                            var treatment_practice_details = treatment_practice_data_cache[case_details.practice_id];

                            #endregion

                            if (case_details != null)
                            {
                                #region CREATE NEW AFTERCARE
                                Aftercare_Model aftercare = new Aftercare_Model();
                                aftercare.hip_ik_number = patient_details.HealthInsurance_IKNumber;
                                aftercare.aftercare_doctor_name = MMDocConnectDocApp.GenericUtils.GetDoctorName(merged_doctor_details);
                                aftercare.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
                                aftercare.id = case_details.aftercare_planned_action_id.ToString();
                                aftercare.localization = case_details.localization;
                                aftercare.patient_birthdate = case_details.Patient_BirthDate;
                                aftercare.patient_birthdate_string = case_details.Patient_BirthDate.ToString("dd.MM.yyyy");
                                aftercare.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
                                aftercare.practice_id = merged_doctor_details.practice_id.ToString();
                                aftercare.status = "AC1";
                                aftercare.treatment_date = case_details.treatment_date;
                                aftercare.treatment_date_day_month = case_details.treatment_date.ToString("dd.MM.");
                                aftercare.treatment_date_month_year = case_details.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                                aftercare.treatment_doctor_name = treatment_doctor_details != null ? MMDocConnectDocApp.GenericUtils.GetDoctorName(treatment_doctor_details) : "-";
                                aftercare.treatment_doctor_practice_name = treatment_doctor_details.practice;
                                aftercare.case_id = case_id.ToString();
                                aftercare.hip = patient_details.health_insurance_provider;
                                aftercare.patient_insurance_number = patient_details.insurance_id;
                                aftercare.op_lanr = treatment_doctor_details == null ? "" : treatment_doctor_details.lanr;
                                aftercare.ac_lanr = merged_doctor_details.lanr;
                                aftercare.bsnr = treatment_doctor_details == null ? "" : treatment_doctor_details.BSNR;
                                aftercare.aftercare_doctor_account_id = merged_doctor_details.doctor_account_id.ToString();
                                aftercare.aftercare_doctor_practice_id = Parameter.DoctorID.ToString();
                                aftercare.treatment_doctor_id = treatment_doctor_details == null ? "" : treatment_doctor_details.id.ToString();
                                aftercare.diagnose_id = case_details.diagnose_id.ToString();
                                aftercare.drug_id = case_details.drug_id.ToString();
                                aftercare.patient_id = case_details.patient_id.ToString();
                                aftercare.treatment_doctors_practice_id = case_details.practice_id.ToString();

                                aftercares.Add(aftercare);

                                PatientDetailViewModel patientDetal_elastic = new PatientDetailViewModel();
                                patientDetal_elastic.id = aftercare.id;
                                patientDetal_elastic.drug_id = aftercare.drug_id;
                                patientDetal_elastic.practice_id = aftercare.practice_id;
                                patientDetal_elastic.case_id = aftercare.case_id;
                                patientDetal_elastic.date = aftercare.treatment_date;
                                patientDetal_elastic.date_string = aftercare.treatment_date.ToString("dd.MM.");
                                patientDetal_elastic.detail_type = "ac";
                                patientDetal_elastic.diagnose_or_medication = aftercare.diagnose;
                                patientDetal_elastic.doctor = aftercare.aftercare_doctor_name;
                                patientDetal_elastic.localisation = aftercare.localization;
                                patientDetal_elastic.patient_id = aftercare.patient_id;
                                patientDetal_elastic.treatment_doctor_id = aftercare.treatment_doctor_id;
                                patientDetal_elastic.aftercare_doctor_practice_id = aftercare.aftercare_doctor_practice_id;
                                patientDetal_elastic.diagnose_id = aftercare.diagnose_id;
                                patientDetal_elastic.status = "FS0";
                                patientDetal_elastic.hip_ik = patient_details.HealthInsurance_IKNumber;

                                patientDetailList.Add(patientDetal_elastic);
                                #endregion

                                #region Update settlement
                                var settlement = Get_Settlement.GetSettlementForID(case_details.treatment_planned_action_id.ToString(), securityTicket);
                                if (settlement != null) 
                                {
                                    settlement.acpractice = merged_doctor_details.practice;
                                    settlement.aftercare_doctor_practice_id = merged_doctor_details.id.ToString();

                                    settlements.Add(settlement);
                                }
                                #endregion
                            }
                        }
                        #endregion

                        #region IF CASE NOT SUMBITTED, EDIT AFTERCARE DATA
                        else
                        {
                            var planning_case = Get_Cases.GetCaseforCaseID(case_id.ToString(), securityTicket);
                            planning_case.aftercare_doctor_lanr = merge_doctor.DoctorIDNumber;
                            planning_case.aftercare_doctor_practice_id = merge_doctor.HEC_DoctorID.ToString();

                            var practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = doctor_details.practice_id }, securityTicket).Result.FirstOrDefault();
                            if (practice_details != null)
                            {
                                planning_case.aftercare_doctors_practice_name = practice_details.practice_name;
                                planning_case.aftercare_name = MMDocConnectDocApp.GenericUtils.GetDoctorName(doctor_details);
                                planning_case.aftercare_practice_bsnr = practice_details.practice_BSNR;
                                planning_case.is_aftercare_doctor = true;
                            }

                            cases.Add(planning_case);
                        }
                        #endregion
                    }
                }

                #region UPDATE LAST USED AFTERCARE DOCTORS LIST
                var types = Elastic_Utils.GetAllTypes(securityTicket.TenantID.ToString());
                var length = Guid.Empty.ToString().Length;
                length += 5;
                List<string> last_used_types = new List<string>();
                for (int i = 0; i < types.Length; i += length)
                {
                    int index = types.IndexOf("user_", i);
                    if (index != -1 && !last_used_types.Contains(types.Substring(index, length)))
                        last_used_types.Add(types.Substring(index, length));
                }

                foreach (var type in last_used_types)
                {
                    Practice_Doctor_Last_Used_Model new_last_used = new Practice_Doctor_Last_Used_Model();
                    try
                    {
                        var last_used = Get_Practices_and_Doctors.GetLastUsedDoctorPracticeForID(Parameter.TemporaryDoctorID.ToString(), type, securityTicket);

                        new_last_used.display_name = GenericUtils.GetDoctorName(doctor_details) + "(" + doctor_details.lanr + ")";
                        new_last_used.id = Parameter.DoctorID.ToString();
                        new_last_used.practice_id = doctor_details.practice_id.ToString();
                        new_last_used.date_of_use = last_used.date_of_use;

                        Add_New_Practice_Last_Used.Delete_Practice_Last_Used(securityTicket.TenantID.ToString(), type, Parameter.TemporaryDoctorID.ToString());
                        Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(new List<Practice_Doctor_Last_Used_Model>() { new_last_used }, securityTicket.TenantID.ToString(), type.Substring(5));
                    }
                    catch (Exception ex)
                    {
                        // left empty because it's not really an exception, rather a check whether object with given id exists 
                    }
                }
                #endregion

                if (aftercares.Count != 0)
                    Add_New_Aftercare.Import_Aftercare_Data_to_ElasticDB(aftercares, securityTicket.TenantID.ToString());

                if (patientDetailList.Count != 0)
                    Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());

                if (cases.Count != 0)
                    Add_New_Case.Import_Case_Data_to_ElasticDB(cases, securityTicket.TenantID.ToString());

                if (settlements.Count != 0)
                    Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());

                Add_New_Practice.Delete_Doctor_Practice(securityTicket.TenantID.ToString(), Parameter.TemporaryDoctorID.ToString());
            }
            else
            {
                throw new Exception("Doctor not found");
            }

            return returnValue;
            #endregion

            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_DO_MD_1321 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_DO_MD_1321 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_DO_MD_1321 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_DO_MD_1321 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
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

                throw new Exception("Exception occured in method cls_Merge_Doctor", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_DO_MD_1321 for attribute P_DO_MD_1321
    [DataContract]
    public class P_DO_MD_1321
    {
        //Standard type parameters
        [DataMember]
        public Guid DoctorID { get; set; }
        [DataMember]
        public Guid TemporaryDoctorID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Merge_Doctor(,P_DO_MD_1321 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Merge_Doctor.Invoke(connectionString,P_DO_MD_1321 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Manipulation.P_DO_MD_1321();
parameter.DoctorID = ...;
parameter.TemporaryDoctorID = ...;

*/
