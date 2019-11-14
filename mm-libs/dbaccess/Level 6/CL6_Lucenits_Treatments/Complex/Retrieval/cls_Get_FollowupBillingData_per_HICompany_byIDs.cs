/* 
 * Generated on 06.03.2014 10:22:34
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
using CL6_Lucenits_Treatments.Atomic.Retrieval;
using CL1_BIL;
using CL3_MedicalPractices.Atomic.Retrieval;
using CL5_Lucentis_Treatments.Atomic.Retrieval;
using CL5_Lucentis_Patient.Atomic.Retrieval;
using CL5_Lucentis_Doctors.Atomic.Retrieval;
using CL5_Lucentis_Treatments.Complex.Retrieval;

namespace CL6_Lucenits_Treatments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FollowupBillingData_per_HICompany_byIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FollowupBillingData_per_HICompany_byIDs
	{
		public static readonly int QueryTimeout = 600;

		#region Method Execution
		protected static FR_L6TR_GFBDpHICfID_1412 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GFBDpHICfID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6TR_GFBDpHICfID_1412();

            var allFollowups = cls_Get_FollowupData_by_IDs.Invoke(Connection, Transaction, new P_L6TR_GFDbID_1420() { TreatmentIDList = Parameter.TreatmentID_List }, securityTicket).Result;
            if (allFollowups == null || allFollowups.Length == 0)
                return returnValue;

            returnValue.Result = new L6TR_GFBDpHICfID_1412()
            {
                Data = new L6TR_GTBDpHICfID_1130()
            };

            List<L5TR_GTHITID_1730> treatment2HICompany = cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID.Invoke(Connection, Transaction, new P_L5TR_GTHITID_1730() { TreatmentID = allFollowups.Select(a =>a.HEC_Patient_TreatmentID).ToArray() }, securityTicket).Result.ToList();
            List<Guid> insuranceompaniesIDs = treatment2HICompany.Select(t2hic => t2hic.HIS_HealthInsurance_Company_RefID).Distinct().ToList();

            var practices = cls_Get_Practice_BaseInfo_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var patients = cls_Get_AllPatientsSimpleData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var doctors = cls_Get_AllDoctors_withBankData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var patientIDs = allFollowups.Select(t => t.HEC_Patient_RefID).Distinct().ToArray();

            ///counter bill
            var treatmentCountPerPatient = cls_Get_TreatmentCount_for_PatientIDlist.Invoke(Connection, Transaction, new P_L5TR_GTCfPID_1152() { PatientID = patientIDs }, securityTicket).Result;

            var comapnies = new List<L6TR_GTBDpHICfID_1130_HICompany>();
            foreach (var HICompanyID in insuranceompaniesIDs)
            {
                var positions = new List<L6TR_GTBDpHICfID_1130_Position>();
                var treamtnIDsForHIC = treatment2HICompany.Where(thic => thic.HIS_HealthInsurance_Company_RefID == HICompanyID).Select(t => t.HEC_Patient_TreatmentID).ToArray();
                var followupIDs = allFollowups.Where(a => treamtnIDsForHIC.Contains(a.HEC_Patient_TreatmentID)).Select(s => s.FollowupID);
                foreach (var id in followupIDs)
                {
                    var followup = allFollowups.First(t => t.FollowupID == id);
                    var patient = patients.FirstOrDefault(p => p.HEC_PatientID == followup.HEC_Patient_RefID);

                    var doctor = doctors.FirstOrDefault(d => d.HEC_DoctorID == followup.IfTreatmentPerformed_ByDoctor_RefID);
                    var practice = practices.FirstOrDefault(p => p.HEC_MedicalPractiseID == followup.TreatmentPractice_RefID);

                    var pos = new L6TR_GTBDpHICfID_1130_Position()
                    {
                        TreatmentID = followup.HEC_Patient_TreatmentID,
                        FollowupID = followup.FollowupID,
                        strDoctorLANR = (doctor != null) ? doctor.LANR : "HEC_Doctor is null!!!!",
                        bTreatmentIsFollowup = followup.IsTreatmentFollowup,
                        strPracticeBSNR = practices != null ? practice.BSNR : "x",
                        dtTreatment = followup.IfTreatmentPerformed_Date,
                        iTreatmentNumber = -1,
                        iPatientSex = 0,
                        iPatientInsuranceState = "xxxxx",
                        dtPatientBirthDate = DateTime.MinValue,
                        PatientFirstName = "x",
                        PatientLastName = "x",
                        PatientInsuranceNumber = "x",
                        cTreatmentLocalization = (followup.IsTreatmentOfLeftEye) ? "L" : "R",
                        strFollowupPractice = "-",
                        strFollowupDoctor = "-",
                        strFollowupStatus = "Keine Nachuntersuchung geplant."
                    };

                    if (patient != null)
                    {
                        pos.iTreatmentNumber = treatmentCountPerPatient.FirstOrDefault(t => t.HEC_PatientID == patient.HEC_PatientID).treatmentCount;
                        pos.iPatientSex = patient.Gender;
                        pos.iPatientInsuranceState = (patient.InsuranceStateCode != null) ? patient.InsuranceStateCode : String.Empty;
                        pos.dtPatientBirthDate = patient.BirthDate;
                        pos.PatientFirstName = patient.FirstName;
                        pos.PatientLastName = patient.LastName;
                        pos.PatientInsuranceNumber = (patient.HealthInsurance_Number != null) ? patient.HealthInsurance_Number : String.Empty;
                    }

                    var articles = new List<L6TR_GTBDpHICfID_1130_ArticleInfo>();
                    foreach (var art in followup.Article)
                    {
                        articles.Add(new L6TR_GTBDpHICfID_1130_ArticleInfo()
                        {
                            ArticleID = art.CMN_PRO_ProductID,
                            Name = art.Product_Name,
                            PZN = art.Product_Number,
                            Quantity = art.Quantity,
                        });
                    }
                    pos.ArticleInfos = articles.ToArray();

                    var diagnosies = new List<L6TR_GTBDpHICfID_1130_DiagnosisInfo>();
                    foreach (var diag in followup.RelevantDiagnosis)
                    {
                        diagnosies.Add(new L6TR_GTBDpHICfID_1130_DiagnosisInfo()
                        {
                            cDiagnosisState = diag.DiagnosisState_Abbreviation,
                            DiagnosisID = diag.HEC_Patient_Treatment_RelevantDiagnosisID,
                            strDiagnosisICD10 = diag.ICD10_Code,
                            PatientInsuranceState = diag.DiagnosisState_Name,
                        });
                    }
                    pos.DiagnosisInfos = diagnosies.ToArray();
                    positions.Add(pos);
                }
                comapnies.Add(new L6TR_GTBDpHICfID_1130_HICompany()
                {
                    HIS_HealthInsurance_CompanyID = HICompanyID,
                    Positions = positions.ToArray(),
                    HealthInsurance_Number = treatment2HICompany.First(t => t.HIS_HealthInsurance_Company_RefID == HICompanyID).HealthInsurance_IKNumber
                });
            }

            returnValue.Result.Data.HICompanies = comapnies.ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_GFBDpHICfID_1412 Invoke(string ConnectionString,P_L6TR_GFBDpHICfID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GFBDpHICfID_1412 Invoke(DbConnection Connection,P_L6TR_GFBDpHICfID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GFBDpHICfID_1412 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GFBDpHICfID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GFBDpHICfID_1412 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GFBDpHICfID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GFBDpHICfID_1412 functionReturn = new FR_L6TR_GFBDpHICfID_1412();
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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
					if (cleanupTransaction == true && Transaction!=null)
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

				throw new Exception("Exception occured in method cls_Get_FollowupBillingData_per_HICompany_byIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_GFBDpHICfID_1412 : FR_Base
	{
		public L6TR_GFBDpHICfID_1412 Result	{ get; set; }

		public FR_L6TR_GFBDpHICfID_1412() : base() {}

		public FR_L6TR_GFBDpHICfID_1412(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GFBDpHICfID_1412 for attribute P_L6TR_GFBDpHICfID_1412
		[DataContract]
		public class P_L6TR_GFBDpHICfID_1412 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID_List { get; set; } 

		}
		#endregion
		#region SClass L6TR_GFBDpHICfID_1412 for attribute L6TR_GFBDpHICfID_1412
		[DataContract]
		public class L6TR_GFBDpHICfID_1412 
		{
			//Standard type parameters
			[DataMember]
			public L6TR_GTBDpHICfID_1130 Data { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_GFBDpHICfID_1412 cls_Get_FollowupBillingData_per_HICompany_byIDs(,P_L6TR_GFBDpHICfID_1412 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_GFBDpHICfID_1412 invocationResult = cls_Get_FollowupBillingData_per_HICompany_byIDs.Invoke(connectionString,P_L6TR_GFBDpHICfID_1412 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Retrieval.P_L6TR_GFBDpHICfID_1412();
parameter.TreatmentID_List = ...;

*/
