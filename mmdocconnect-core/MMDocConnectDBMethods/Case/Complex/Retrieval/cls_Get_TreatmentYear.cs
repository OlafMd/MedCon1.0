/* 
 * Generated on 3/28/2017 11:03:10 AM
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
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_CMN_CTR;
using MMDocConnectUtils;
using MMDocConnectDocApp;
using MMDocConnectDBMethods.ElasticRefresh;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectDBMethods.Case.Models;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_TreatmentYear.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_TreatmentYear
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_DateTime Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_GTY_1125 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_DateTime();
            //Put your code here       
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

            var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(Connection, Transaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result;

            if (oct_gpos_ids.Any() && !String.IsNullOrEmpty(Parameter.LocalizationCode) && Parameter.LocalizationCode != "-")
            {
                var patient_consents = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(Connection, Transaction, new P_PA_GPCbDaGposIDs_1154()
                {
                    Date = Parameter.Date.Date,
                    GposIDs = oct_gpos_ids.Select(t => t.GposID).ToArray(),
                    PatientID = Parameter.PatientID
                }, securityTicket).Result;

                var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                var doctorHasCertificate = false;
                var doctorCertificateValidFrom = DateTime.MinValue;

                if (patient_consents.Any())
                {
                    var last_potential_consent = patient_consents.First(t => t.consent_valid_from.Date <= Parameter.Date.Date);
                    var contract_id = last_potential_consent.contract_id;
                    var contract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, CMN_CTR_ContractID = contract_id }).SingleOrDefault();

                    var useSettlementYear = all_contract_parameters[contract_id].SingleOrDefault(t => t.ParameterName == EContractParameter.UseSettlementYear.Value()) != null;
                    var doctorNeedsCertificate = all_contract_parameters[contract_id].SingleOrDefault(t => t.ParameterName == EContractParameter.DoctorNeedCertification.Value()) != null;

                    if (doctorNeedsCertificate && Parameter.DoctorID != Guid.Empty)
                    {
                        var doctor_properties = cls_Get_Doctors_Properties_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDPfDID_1016 { DoctorID = Parameter.DoctorID }, securityTicket).Result;

                        var is_certificated_for_oct = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.OctCertificated.Value());
                        doctorHasCertificate = is_certificated_for_oct != null ? is_certificated_for_oct.Value_Boolean : false;

                        var oct_valid_from = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.OctValidFrom.Value());
                        var validFrom = oct_valid_from != null ? oct_valid_from.Value_String : null;
                        if (validFrom != null)
                        {
                            doctorCertificateValidFrom = DateTime.Parse(validFrom, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                        }
                    }

                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
                    var performedOpAndOctDates = cls_Get_Oct_and_Op_Dates_by_PatientID.Invoke(Connection, Transaction, new P_ER_GOctaOpDbPID_1824() { PatientID = Parameter.PatientID }, securityTicket).Result.GroupBy(r => r.Localization).ToDictionary(x => x.Key, x => x.ToList());

                    var octFsStatuses = cls_Get_Oct_FsStatuses_by_PatientID.Invoke(Connection, Transaction, new P_ER_GOctFsSbPID_1829() { PatientID = Parameter.PatientID }, securityTicket).Result.GroupBy(t => t.localization).ToDictionary(t => t.Key, t => t.ToList());

                    var patientOctFsStatusesForLocalization = useSettlementYear ? octFsStatuses.SelectMany(t => t.Value).ToList() :
                        octFsStatuses.ContainsKey(Parameter.LocalizationCode) ? octFsStatuses[Parameter.LocalizationCode] : new List<ER_GOctFsSbPID_1829>();
                    var patientOctPerformedOnDatesForLocalization = useSettlementYear ? performedOpAndOctDates.SelectMany(t => t.Value).ToList() :
                        performedOpAndOctDates.ContainsKey(Parameter.LocalizationCode) ? performedOpAndOctDates[Parameter.LocalizationCode] : new List<ER_GOctaOpDbPID_1824>();
                    var allDates = useSettlementYear ? performedOpAndOctDates.SelectMany(x => x.Value.Where(t => !t.IsOp)).ToList() : performedOpAndOctDates.ContainsKey(Parameter.LocalizationCode) ? performedOpAndOctDates[Parameter.LocalizationCode] : new List<ER_GOctaOpDbPID_1824>();

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
                            if (oct_fs_status_code == 8 || oct_fs_status_code == 11 || oct_fs_status_code == 17)
                            {                            
                                allDates = allDates.Where(t => t.ActionID != patientOctPerformedOnDatesForLocalization[j].ActionID).ToList();
                            }
                        }
                    }

                    if (performedOpAndOctDates.Any())
                    {
                        var treatment_year_length_ctr_parameter = all_contract_parameters[contract_id].SingleOrDefault(t => t.ParameterName == "Preexaminations - Days");
                        var treatment_year_length = treatment_year_length_ctr_parameter != null ? treatment_year_length_ctr_parameter.IfNumericValue_Value : 365d;

                        if (doctorNeedsCertificate && doctorHasCertificate && doctorCertificateValidFrom != DateTime.MinValue)
                        {
                            allDates = allDates.Where(x => x.TreatmentDate >= doctorCertificateValidFrom).ToList();
                        }

                        if (allDates.Any())
                        {
                            var firstOpOrOctDate = DateTime.MinValue;

                            var gaps = allDates.Where(t =>
                            {
                                var isLast = allDates.Last().TreatmentDate == t.TreatmentDate;
                                if (isLast)
                                {
                                    return false;
                                }

                                var gapExists = !allDates.Any(r => r.TreatmentDate > t.TreatmentDate && r.TreatmentDate < t.TreatmentDate.AddDays(treatment_year_length));
                                return useSettlementYear ? gapExists && !t.IsOp : gapExists && t.IsOp;
                            }).ToList();

                            if (!gaps.Any())
                            {
                                var firstDate = allDates.FirstOrDefault(t =>
                                {
                                    var typeSpecificationMet= useSettlementYear ? !t.IsOp : true;
                                    return t.TreatmentDate <= Parameter.Date && typeSpecificationMet;
                                });

                                if (firstDate != null)
                                {
                                    firstOpOrOctDate = firstDate.TreatmentDate;
                                }
                            }
                            else
                            {
                                firstOpOrOctDate = gaps.Select(t => t.TreatmentDate).Where(t => t <= Parameter.Date.Date).DefaultIfEmpty().Max();
                            }

                            if (firstOpOrOctDate != DateTime.MinValue)
                            {
                                while (firstOpOrOctDate.AddDays(treatment_year_length) < Parameter.Date.Date)
                                {
                                    firstOpOrOctDate = firstOpOrOctDate.AddDays(treatment_year_length);
                                }

                                returnValue.Result = firstOpOrOctDate;
                                return returnValue;
                            }
                        }
                    }
                }
            }

            returnValue.Result = Parameter.Date;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_DateTime Invoke(string ConnectionString, P_CAS_GTY_1125 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_DateTime Invoke(DbConnection Connection, P_CAS_GTY_1125 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_DateTime Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_GTY_1125 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_DateTime Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_GTY_1125 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_DateTime functionReturn = new FR_DateTime();
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

                throw new Exception("Exception occured in method cls_Get_TreatmentYear", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_GTY_1125 for attribute P_CAS_GTY_1125
    [DataContract]
    public class P_CAS_GTY_1125
    {
        //Standard type parameters
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public String LocalizationCode { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Guid DoctorID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DateTime cls_Get_TreatmentYear(,P_CAS_GTY_1125 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DateTime invocationResult = cls_Get_TreatmentYear.Invoke(connectionString,P_CAS_GTY_1125 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GTY_1125();
parameter.PatientID = ...;
parameter.LocalizationCode = ...;
parameter.Date = ...;
parameter.DoctorID = ...;

*/
