/* 
 * Generated on 08/04/15 11:36:49
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
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using CL1_USR;
using CL1_HEC_ACT;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using CL1_CMN;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using CL1_HEC_CAS;
using MMDocConnectDocApp;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Case_Multi_Edit.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Case_Multi_Edit
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SCME_1741 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guids();
            //Put your code here          


            ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
            all_languagesQ.IsDeleted = false;

            var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();

            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
            var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.aftercare_doctor_id }, securityTicket).Result.SingleOrDefault();
            var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = Parameter.aftercare_doctor_id }, securityTicket).Result.FirstOrDefault();
            List<string> aftercare_ids = new List<string>();
            List<string> withdrawn_aftercare_ids = new List<string>();
            List<string> new_aftercare_ids = new List<string>();

            ORM_USR_Account treatment_doctor_account = null;
            if (Parameter.treatment_doctor_id != Guid.Empty)
            {
                treatment_doctor_account = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                {
                    USR_AccountID = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.accountID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();
            }

            ORM_USR_Account aftercare_doctor_account = null;
            if (Parameter.aftercare_doctor_id != Guid.Empty)
            {
                if (aftercare_doctor_details != null)
                {
                    aftercare_doctor_account = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        USR_AccountID = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.aftercare_doctor_id }, securityTicket).Result.accountID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();
                }
                else
                {
                    aftercare_doctor_account = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        USR_AccountID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.aftercare_doctor_id }, securityTicket).Result.accountID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();
                }
            }

            foreach (var case_id in Parameter.case_ids)
            {
                if (treatment_doctor_details != null && Parameter.is_treatment)
                {
                    #region UPDATE TREATMENT DOCTOR
                    var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result;
                    if (treatment_planned_action_id != null)
                    {
                        var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                        {
                            HEC_ACT_PlannedActionID = treatment_planned_action_id.planned_action_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            IsCancelled = false
                        }).SingleOrDefault();

                        if (treatment_planned_action != null)
                        {
                            treatment_planned_action.Modification_Timestamp = DateTime.Now;
                            treatment_planned_action.ToBePerformedBy_BusinessParticipant_RefID = treatment_doctor_account.BusinessParticipant_RefID;

                            treatment_planned_action.Save(Connection, Transaction);
                        }
                    }
                    #endregion
                }

                #region UPDATE AFTERCARE DOCTOR
                if (!string.IsNullOrEmpty(Parameter.aftercare_performed_date) || aftercare_doctor_details != null || aftercare_practice_details != null)
                {
                    var aftercare_planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result;
                    if (aftercare_planned_action_id != null)
                    {
                        aftercare_ids.Add(aftercare_planned_action_id.planned_action_id.ToString());
                        if (aftercare_doctor_details != null || aftercare_practice_details != null)
                        {
                            var aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                            {
                                HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                IsCancelled = false
                            }).SingleOrDefault();

                            if (aftercare_planned_action != null)
                            {
                                if (aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID != Guid.Empty)
                                {
                                    if (aftercare_doctor_account.BusinessParticipant_RefID != aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID)
                                    {
                                        bool is_current_aftercare_practice = false;
                                        CAS_GPIDfPBPTID_1336 current_aftercare_practice = null;
                                        var current_aftercare_doctor = cls_Get_PracticeID_for_Doctor_BusinessParticipantID.Invoke(
                                            Connection,
                                            Transaction,
                                            new P_CAS_GPIDfDBPTID_1205()
                                            {
                                                BusinessParticipantID = aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID
                                            },
                                            securityTicket).Result;

                                        if (current_aftercare_doctor == null)
                                        {
                                            current_aftercare_practice = cls_Get_PracticeID_for_Practice_BusinessParticipantID.Invoke(Connection, Transaction, new P_CAS_GPIDfPBPTID_1336() { BusinessParticipantID = aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID }, securityTicket).Result;
                                            is_current_aftercare_practice = true;
                                        }

                                        var new_aftercare_practice_id = aftercare_doctor_details != null ? aftercare_doctor_details.practice_id : aftercare_practice_details.practiceID;
                                        var current_aftercare_practice_id = is_current_aftercare_practice ? current_aftercare_practice.practice_id : current_aftercare_doctor.practice_id;

                                        if (new_aftercare_practice_id != current_aftercare_practice_id)
                                        {
                                            aftercare_planned_action.IsCancelled = true;
                                            aftercare_planned_action.Modification_Timestamp = DateTime.Now;
                                            aftercare_planned_action.Save(Connection, Transaction);

                                            withdrawn_aftercare_ids.Add(aftercare_planned_action.HEC_ACT_PlannedActionID.ToString());

                                            #region NEW AFTERCARE PLANNED ACTION

                                            #region DELETE CURRENT PLANNED ACTION TO CASE
                                            ORM_HEC_CAS_Case_RelevantPlannedAction.Query current_aftercare_action_2_caseQ = new ORM_HEC_CAS_Case_RelevantPlannedAction.Query();
                                            current_aftercare_action_2_caseQ.Case_RefID = case_id;
                                            current_aftercare_action_2_caseQ.PlannedAction_RefID = aftercare_planned_action_id.planned_action_id;
                                            current_aftercare_action_2_caseQ.Tenant_RefID = securityTicket.TenantID;
                                            current_aftercare_action_2_caseQ.IsDeleted = false;

                                            var current_aftercare_action_2_case = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, current_aftercare_action_2_caseQ).SingleOrDefault();
                                            if (current_aftercare_action_2_case != null)
                                            {
                                                current_aftercare_action_2_case.IsDeleted = true;
                                                current_aftercare_action_2_case.Save(Connection, Transaction);
                                            }
                                            #endregion

                                            var new_aftercare_id = cls_Create_Aftercare_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CAPA_1237()
                                            {
                                                aftercare_doctor_practice_id = Parameter.aftercare_doctor_id,
                                                all_languagesL = all_languagesL,
                                                case_id = case_id,
                                                patient_id = aftercare_planned_action.Patient_RefID,
                                                practice_id = Parameter.practice_id,
                                                treatment_date = string.IsNullOrEmpty(Parameter.aftercare_performed_date) ? DateTime.Now : DateTime.ParseExact(Parameter.aftercare_performed_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true))
                                            }, securityTicket).Result;

                                            new_aftercare_ids.Add(new_aftercare_id.ToString());

                                            #endregion NEW AFTERCARE PLANNED ACTION
                                        }
                                        else
                                        {
                                            aftercare_planned_action.Modification_Timestamp = DateTime.Now;
                                            aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = aftercare_doctor_account.BusinessParticipant_RefID;

                                            aftercare_planned_action.Save(Connection, Transaction);
                                        }
                                    }
                                }
                                else
                                {
                                    aftercare_planned_action.Modification_Timestamp = DateTime.Now;
                                    aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = aftercare_doctor_account.BusinessParticipant_RefID;

                                    aftercare_planned_action.Save(Connection, Transaction);
                                }
                            }
                        }
                    }
                    else
                    {
                        var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result;
                        if (treatment_planned_action_id != null)
                        {
                            var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                            {
                                HEC_ACT_PlannedActionID = treatment_planned_action_id.planned_action_id,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                IsCancelled = false
                            }).SingleOrDefault();

                            var result = cls_Create_Aftercare_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CAPA_1237()
                            {
                                aftercare_doctor_practice_id = Parameter.aftercare_doctor_id,
                                all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray(),
                                case_id = case_id,
                                patient_id = treatment_planned_action.Patient_RefID,
                                practice_id = aftercare_doctor_details != null ? aftercare_doctor_details.practice_id : Parameter.aftercare_doctor_id,
                                treatment_date = treatment_planned_action.PlannedFor_Date
                            }, securityTicket);

                            aftercare_ids.Add(result.Result.ToString());
                        }
                    }

                }
                #endregion
            }

            #region UPDATE LAST USED AFTERCARES
            if (aftercare_doctor_details != null || aftercare_practice_details != null)
            {
                var aftercare_name = aftercare_doctor_details == null ? aftercare_practice_details.practice_name :
                    GenericUtils.GetDoctorName(aftercare_doctor_details);

                var ac_practice_id = aftercare_doctor_details != null ? aftercare_doctor_details.practice_id : aftercare_practice_details.practiceID;

                var last_used_practices_doctors = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket);
                if (last_used_practices_doctors.Count != 0)
                {
                    last_used_practices_doctors = last_used_practices_doctors.OrderBy(l => l.date_of_use).ToList();
                    var last_used = last_used_practices_doctors.SingleOrDefault(l => l.id.ToLower().Equals(Parameter.aftercare_doctor_id.ToString().ToLower()));
                    if (last_used != null)
                    {
                        last_used.date_of_use = DateTime.Now;
                    }
                    else
                    {
                        Practice_Doctor_Last_Used_Model practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                        practice_last_used_model.id = Parameter.aftercare_doctor_id.ToString();
                        practice_last_used_model.display_name = aftercare_name;
                        practice_last_used_model.date_of_use = DateTime.Now;
                        practice_last_used_model.practice_id = ac_practice_id.ToString();

                        last_used_practices_doctors.Add(practice_last_used_model);
                    }
                }
                else
                {
                    Practice_Doctor_Last_Used_Model practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                    practice_last_used_model.id = Parameter.aftercare_doctor_id.ToString();
                    practice_last_used_model.display_name = aftercare_name;
                    practice_last_used_model.date_of_use = DateTime.Now;
                    practice_last_used_model.practice_id = ac_practice_id.ToString();

                    last_used_practices_doctors.Add(practice_last_used_model);
                }

                Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(last_used_practices_doctors, securityTicket.TenantID.ToString(), securityTicket.AccountID.ToString());

                last_used_practices_doctors = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket);

                if (last_used_practices_doctors.Count() > 3)
                {
                    var id_to_delete = last_used_practices_doctors.OrderBy(pd => pd.date_of_use).First().id;
                    Add_New_Practice_Last_Used.Delete_Practice_Last_Used(securityTicket.TenantID.ToString(), "user_" + securityTicket.AccountID.ToString(), id_to_delete);
                }
            }
            #endregion

            returnValue.Result = Parameter.case_ids;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_CAS_SCME_1741 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_CAS_SCME_1741 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SCME_1741 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SCME_1741 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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

                throw new Exception("Exception occured in method cls_Save_Case_Multi_Edit", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SCME_1741 for attribute P_CAS_SCME_1741
    [DataContract]
    public class P_CAS_SCME_1741
    {
        //Standard type parameters
        [DataMember]
        public Guid[] case_ids { get; set; }
        [DataMember]
        public Guid treatment_doctor_id { get; set; }
        [DataMember]
        public Guid aftercare_doctor_id { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public string aftercare_performed_date { get; set; }
        [DataMember]
        public Boolean is_treatment { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_Case_Multi_Edit(,P_CAS_SCME_1741 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_Case_Multi_Edit.Invoke(connectionString,P_CAS_SCME_1741 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SCME_1741();
parameter.case_ids = ...;
parameter.treatment_doctor_id = ...;
parameter.aftercare_doctor_id = ...;
parameter.practice_id = ...;
parameter.aftercare_performed_date = ...;
parameter.is_treatment = ...;

*/
