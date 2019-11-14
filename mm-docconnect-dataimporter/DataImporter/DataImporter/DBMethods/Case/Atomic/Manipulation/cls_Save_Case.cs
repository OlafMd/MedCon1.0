/* 
 * Generated on 07/16/15 10:16:29
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
using CL1_HEC_CAS;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using CL1_CMN;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Models;
using DataImporter.DBMethods.Case.Complex.Retrieval;
using CL1_HEC_TRE;


namespace DataImporter.DBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Case.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Case
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
            all_languagesQ.IsDeleted = false;

            var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();
            var intraocular_procedure_id = Guid.Empty;
            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_PA_GPDfPID_1729() { PatientID = Parameter.patient_id }, securityTicket).Result;
            var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = Parameter.diagnose_id }, securityTicket).Result;
            var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = Parameter.drug_id }, securityTicket).Result;

            #region NEW CASE
            ORM_HEC_CAS_Case new_case = new ORM_HEC_CAS_Case();
            new_case.HEC_CAS_CaseID = Guid.NewGuid();
            new_case.Creation_Timestamp = DateTime.Now;
            new_case.Patient_RefID = Parameter.patient_id;
            new_case.Patient_FirstName = patient_details.patient_first_name;
            new_case.Patient_LastName = patient_details.patient_last_name;
            new_case.Patient_Gender = patient_details.gender;
            new_case.Patient_BirthDate = patient_details.birthday;
            new_case.CaseNumber = cls_Get_Next_Case_Number.Invoke(Connection, Transaction, securityTicket).Result.case_number;

            new_case.Modification_Timestamp = DateTime.Now;

            DateTime today = DateTime.Today;
            int age = today.Year - patient_details.birthday.Year;
            if (patient_details.birthday > today.AddYears(-age))
                age--;

            new_case.Patient_Age = age;
            new_case.Tenant_RefID = securityTicket.TenantID;

            new_case.Save(Connection, Transaction);

            returnValue.Result = new_case.HEC_CAS_CaseID;
            #endregion NEW CASE

            #region INITIAL PERFORMED ACTION
            var initial_performed_action_id = cls_Create_Initial_Performed_Action.Invoke(Connection, Transaction, new P_CAS_CIPA_1140()
            {
                all_languagesL = all_languagesL,
                case_id = new_case.HEC_CAS_CaseID,
                patient_id = Parameter.patient_id,
                practice_id = Parameter.practice_id
            }, securityTicket).Result;
            #endregion INITIAL PERFORMED ACTION

            #region POTENTIAL PROCEDURE
            ORM_HEC_TRE_PotentialProcedure_Package.Query intraocular_packageQ = new ORM_HEC_TRE_PotentialProcedure_Package.Query();
            intraocular_packageQ.Tenant_RefID = securityTicket.TenantID;
            intraocular_packageQ.IsDeleted = false;
            intraocular_packageQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.intraocular.package";

            var intraocular_package = ORM_HEC_TRE_PotentialProcedure_Package.Query.Search(Connection, Transaction, intraocular_packageQ).FirstOrDefault();
            if (intraocular_package != null)
            {
                ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query procedure_2_packageQ = new ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query();
                procedure_2_packageQ.Tenant_RefID = securityTicket.TenantID;
                procedure_2_packageQ.IsDeleted = false;
                procedure_2_packageQ.HEC_TRE_PotentialProcedure_Package_RefID = intraocular_package.HEC_TRE_PotentialProcedure_PackageID;

                var procedure_2_package = ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query.Search(Connection, Transaction, procedure_2_packageQ).FirstOrDefault();
                if (procedure_2_package != null)
                {
                    intraocular_procedure_id = procedure_2_package.HEC_TRE_PotentialProcedure_RefID;
                }
                else
                {
                    intraocular_procedure_id = cls_Create_Potential_Procedure.Invoke(Connection, Transaction, securityTicket).Result;
                }
            }
            else
            {
                intraocular_procedure_id = cls_Create_Potential_Procedure.Invoke(Connection, Transaction, securityTicket).Result;
            }
            #endregion POTENTIAL PROCEDURE

            #region TREATMENT PLANNED ACTION
            cls_Create_Treatment_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CTPA_1225()
            {
                all_languagesL = all_languagesL,
                case_id = new_case.HEC_CAS_CaseID,
                diagnose_id = Parameter.diagnose_id,
                initial_performed_action_id = initial_performed_action_id,
                drug_id = Parameter.drug_id,
                intraocular_procedure_id = intraocular_procedure_id,
                is_confirmed = Parameter.is_confirmed,
                is_left_eye = Parameter.is_left_eye,
                patient_id = Parameter.patient_id,
                practice_id = Parameter.practice_id,
                treatment_date = Parameter.treatment_date,
                treatment_doctor_id = Parameter.treatment_doctor_id
            }, securityTicket);
            #endregion TREATMENT PLANNED ACTION

            #region AFTERCARE PLANNED ACTION
            if (Parameter.aftercare_doctor_practice_id != Guid.Empty)
            {
                cls_Create_Aftercare_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CAPA_1237()
                {
                    aftercare_doctor_practice_id = Parameter.aftercare_doctor_practice_id,
                    all_languagesL = all_languagesL,
                    case_id = new_case.HEC_CAS_CaseID,
                    patient_id = Parameter.patient_id,
                    practice_id = Parameter.practice_id,
                    treatment_date = Parameter.treatment_date
                }, securityTicket);
            }
            #endregion AFTERCARE PLANNED ACTION

            #region ADD GPOS TO THE CASE
            cls_Add_GPOS_to_Case.Invoke(Connection, Transaction, new P_CAS_AGPOStC_0906()
            {
                ac_doctor_id = Parameter.aftercare_doctor_practice_id,
                all_languagesL = all_languagesL,
                case_id = new_case.HEC_CAS_CaseID,
                diagnose_id = Parameter.diagnose_id,
                drug_id = Parameter.drug_id,
                patient_id = Parameter.patient_id,
                treatment_doctor_id = Parameter.treatment_doctor_id,
                localization = Parameter.is_left_eye ? "L" : "R",
                treatment_gpos = Parameter.treatment_gpos,
                aftercare_gpos = Parameter.aftercare_gpos,
                bevacizumab_gpos = Parameter.bevacizumab_gpos,
                management_fee_gpos = Parameter.management_fee_gpos
            }, securityTicket);
            #endregion

            #region IMPORT TO ELASTIC


            Case_Model case_model_elastic = new Case_Model();

            case_model_elastic.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
            case_model_elastic.drug = drug_details != null ? drug_details.drug_name : "";
            case_model_elastic.id = new_case.HEC_CAS_CaseID.ToString();
            case_model_elastic.localization = Parameter.diagnose_id == Guid.Empty ? "-" : Parameter.is_left_eye ? "L" : "R";
            case_model_elastic.previous_status_drug_order = "";
            case_model_elastic.status_treatment = "OP1";
            case_model_elastic.diagnose_id = Parameter.diagnose_id.ToString();
            case_model_elastic.drug_id = Parameter.drug_id.ToString();
            case_model_elastic.patient_id = Parameter.patient_id.ToString();
            case_model_elastic.treatment_doctor_id = Parameter.treatment_doctor_id.ToString();
            case_model_elastic.aftercare_doctor_practice_id = Parameter.aftercare_doctor_practice_id.ToString();
            case_model_elastic.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
            case_model_elastic.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
            case_model_elastic.patient_birthdate = patient_details.birthday;

            var is_aftercare_doctor = true;
            string aftercare_name = "";

            var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.aftercare_doctor_practice_id }, securityTicket).Result.SingleOrDefault();

            if (aftercare_doctor_details != null)
            {
                case_model_elastic.aftercare_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;
                case_model_elastic.aftercare_doctors_practice_name = aftercare_doctor_details.practice;
                case_model_elastic.aftercare_practice_bsnr = aftercare_doctor_details.BSNR;

                aftercare_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.first_name + " " + aftercare_doctor_details.last_name;
            }
            else
            {
                is_aftercare_doctor = false;
                var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = Parameter.aftercare_doctor_practice_id }, securityTicket).Result.FirstOrDefault();
                if (aftercare_practice_details != null)
                {
                    case_model_elastic.aftercare_name = aftercare_practice_details.practice_name;
                    case_model_elastic.aftercare_practice_bsnr = aftercare_doctor_details.BSNR;

                    aftercare_name = aftercare_practice_details.practice_name;
                }
                else
                {
                    case_model_elastic.aftercare_name = "-";
                }
            }

            case_model_elastic.is_aftercare_doctor = is_aftercare_doctor;
            DateTime treatment_date = DateTime.SpecifyKind(Parameter.treatment_date, DateTimeKind.Local);
            case_model_elastic.treatment_date = Parameter.treatment_date;
            case_model_elastic.treatment_date_day_month = Parameter.treatment_date.ToString("dd.MM.");
            case_model_elastic.treatment_date_month_year = Parameter.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
            case_model_elastic.treatment_doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.first_name + " " + treatment_doctor_details.last_name : "-";
            case_model_elastic.practice_id = Parameter.practice_id.ToString();
            case_model_elastic.delivery_time_string = case_model_elastic.delivery_time_from.ToString("HH:mm") + " - " + case_model_elastic.delivery_time_to.ToString("HH:mm");

            List<Case_Model> cases = new List<Case_Model>();
            cases.Add(case_model_elastic);

            Add_New_Case.Import_Case_Data_to_ElasticDB(cases, securityTicket.TenantID.ToString());

            #endregion IMPORT TO ELASTIC


            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Case", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SC_1711 for attribute P_CAS_SC_1711
    [DataContract]
    public class P_CAS_SC_1711
    {
        //Standard type parameters
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public Guid drug_id { get; set; }
        [DataMember]
        public Guid diagnose_id { get; set; }
        [DataMember]
        public Boolean is_left_eye { get; set; }
        [DataMember]
        public Boolean is_confirmed { get; set; }
        [DataMember]
        public Guid treatment_doctor_id { get; set; }
        [DataMember]
        public Guid aftercare_doctor_practice_id { get; set; }
        [DataMember]
        public String treatment_gpos { get; set; }
        [DataMember]
        public String aftercare_gpos { get; set; }
        [DataMember]
        public String bevacizumab_gpos { get; set; }
        [DataMember]
        public String management_fee_gpos { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Case(,P_CAS_SC_1711 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Case.Invoke(connectionString,P_CAS_SC_1711 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Manipulation.P_CAS_SC_1711();
parameter.patient_id = ...;
parameter.practice_id = ...;
parameter.treatment_date = ...;
parameter.drug_id = ...;
parameter.diagnose_id = ...;
parameter.is_left_eye = ...;
parameter.is_confirmed = ...;
parameter.treatment_doctor_id = ...;
parameter.aftercare_doctor_practice_id = ...;
parameter.treatment_gpos = ...;
parameter.aftercare_gpos = ...;
parameter.bevacizumab_gpos = ...;
parameter.management_fee_gpos = ...;

*/
