/* 
 * Generated on 06.03.2014 11:45:06
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
using CL5_Lucentis_Treatments.Complex.Retrieval;
using CL5_Lucentis_Patient.Atomic.Retrieval;
using CL3_MedicalPractices.Atomic.Retrieval;
using CL5_Lucentis_Doctors.Atomic.Retrieval;
using CL5_Lucentis_Treatments.Atomic.Retrieval;

namespace CL6_Lucenits_Treatments.Complex.Retrieval
{
	/// <summary>
	/// 
	/// <example>
	/// string connectionString = ...;
	/// var result = cls_Get_TreatmentBillingData_per_HICompany_byIDs.Invoke(connectionString).Result;
	/// </example>
	/// </summary>
	[DataContract]
	public class cls_Get_TreatmentBillingData_per_HICompany_byIDs
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L6TR_GTBDpHICfID_1130 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GTBDpHICfID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6TR_GTBDpHICfID_1130();

			var allTreatments = cls_Get_TreatmentData_by_IDs.Invoke(Connection, Transaction, new P_L6TR_GTDbID_1422() {TreatmentIDList = Parameter.TreatmentID_List}, securityTicket).Result;

			returnValue.Result = new L6TR_GTBDpHICfID_1130();
			List<L5TR_GTHITID_1730> treatment2HICompany = cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID.Invoke(Connection, Transaction, new P_L5TR_GTHITID_1730() { TreatmentID = Parameter.TreatmentID_List }, securityTicket).Result.ToList();
			List<Guid> insuranceompaniesIDs = treatment2HICompany.Select(t2hic => t2hic.HIS_HealthInsurance_Company_RefID).Distinct().ToList();

			var practices = cls_Get_Practice_BaseInfo_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
			var patients = cls_Get_AllPatientsSimpleData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
			var doctors = cls_Get_AllDoctors_withBankData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
			var patientIDs = allTreatments.Select(t => t.HEC_Patient_RefID).Distinct().ToArray();
			var followups = cls_Get_Followups_for_Report_byIDs.Invoke(Connection, Transaction, new P_L6TR_GFTfRbIDs_1646() { TreatmentIDs = allTreatments.Select(t =>t.HEC_Patient_TreatmentID).ToArray() }, securityTicket).Result;

			///counter bill
			var treatmentCountPerPatient = cls_Get_TreatmentCount_for_PatientIDlist.Invoke(Connection, Transaction, new P_L5TR_GTCfPID_1152() { PatientID = patientIDs }, securityTicket).Result;
			Dictionary<Guid, int> positionCountPerPatient = new Dictionary<Guid, int>();
			foreach (var id in patientIDs)
				positionCountPerPatient.Add(id, 0);

			var comapnies = new List<L6TR_GTBDpHICfID_1130_HICompany>();
			foreach (var HICompanyID in insuranceompaniesIDs)
			{
				var postions = new List<L6TR_GTBDpHICfID_1130_Position>();
				var treamtnIDsForHIC = treatment2HICompany.Where(thic => thic.HIS_HealthInsurance_Company_RefID == HICompanyID).Select(t => t.HEC_Patient_TreatmentID).ToArray();
				foreach (var id in treamtnIDsForHIC)
				{
					var treatment = allTreatments.First(t => t.HEC_Patient_TreatmentID == id);
					var patient = patients.FirstOrDefault(p => p.HEC_PatientID == treatment.HEC_Patient_RefID);
					var followupsForThisThreatment = followups.Where(f => f.IfTreatmentFollowup_FromTreatment_RefID == treatment.HEC_Patient_TreatmentID).ToArray();
					L6TR_GFTfRbIDs_1646 followup = followupsForThisThreatment.Where(f => f.IsTreatmentPerformed == true).OrderBy(f => f.IfTreatmentPerformed_Date).FirstOrDefault();
					if (followup == null)
						followup = followupsForThisThreatment.Where(f => f.IsScheduled == true).OrderBy(f => f.IfSheduled_Date).FirstOrDefault();

					var doctor = doctors.FirstOrDefault(d => d.HEC_DoctorID == treatment.IfTreatmentPerformed_ByDoctor_RefID);
					var practice = practices.FirstOrDefault(p => p.HEC_MedicalPractiseID == treatment.TreatmentPractice_RefID);

					var pos = new L6TR_GTBDpHICfID_1130_Position()
					{
						TreatmentID = treatment.HEC_Patient_TreatmentID,
						FollowupID = followup == null ? Guid.Empty : followup.HEC_Patient_TreatmentID,
						strDoctorLANR = (doctor != null) ? doctor.LANR : "HEC_Doctor is null!!!!",
						bTreatmentIsFollowup = false,
						strPracticeBSNR = practices != null ? practice.BSNR : "x",
						dtTreatment = treatment.IfTreatmentPerformed_Date,
						iTreatmentNumber = -1,
						iPatientSex = 0,
						iPatientInsuranceState = "xxxxx",
						dtPatientBirthDate = DateTime.MinValue,
						PatientFirstName = "x",
						PatientLastName = "x",
						PatientInsuranceNumber = "x",
						cTreatmentLocalization = (treatment.IsTreatmentOfLeftEye) ? "L" : "R",
						strFollowupPractice = "-",
						strFollowupDoctor = "-",
						strFollowupStatus = "Keine Nachuntersuchung geplant."
					};

					if (patient != null)
					{
						pos.iTreatmentNumber = treatmentCountPerPatient.FirstOrDefault(t => t.HEC_PatientID == patient.HEC_PatientID).treatmentCount + positionCountPerPatient[treatment.HEC_Patient_RefID];
						pos.iPatientSex = patient.Gender;
						pos.iPatientInsuranceState = (patient.InsuranceStateCode != null) ? patient.InsuranceStateCode : String.Empty;
						pos.dtPatientBirthDate = patient.BirthDate;
						pos.PatientFirstName = patient.FirstName;
						pos.PatientLastName = patient.LastName;
						pos.PatientInsuranceNumber = (patient.HealthInsurance_Number != null) ? patient.HealthInsurance_Number : String.Empty;
					}
					if (followup != null)
					{
						pos.strFollowupDoctor = followup.DoctorFirstName + " " + followup.DoctorLastname;
						pos.dtFollowup = followup.IfTreatmentPerformed_Date;
						pos.strFollowupPractice = followup.DisplayName;
						pos.strFollowupStatus = (followup.IsTreatmentPerformed) ? "durchgef�hrt" : "geplant";
					}

					var articles = new List<L6TR_GTBDpHICfID_1130_ArticleInfo>();
					foreach (var art in treatment.Article)
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
					foreach (var diag in treatment.RelevantDiagnosis)
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
					postions.Add(pos);

					positionCountPerPatient[treatment.HEC_Patient_RefID] = positionCountPerPatient[treatment.HEC_Patient_RefID] + 1;
				}

				comapnies.Add(new L6TR_GTBDpHICfID_1130_HICompany()
				{
					HIS_HealthInsurance_CompanyID = HICompanyID,
					Positions = postions.ToArray(),
					HealthInsurance_Number = treatment2HICompany.First(t => t.HIS_HealthInsurance_Company_RefID == HICompanyID).HealthInsurance_IKNumber
				});
			}
			returnValue.Result.HICompanies = comapnies.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_GTBDpHICfID_1130 Invoke(string ConnectionString,P_L6TR_GTBDpHICfID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GTBDpHICfID_1130 Invoke(DbConnection Connection,P_L6TR_GTBDpHICfID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GTBDpHICfID_1130 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GTBDpHICfID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GTBDpHICfID_1130 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GTBDpHICfID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GTBDpHICfID_1130 functionReturn = new FR_L6TR_GTBDpHICfID_1130();
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

				throw new Exception("Exception occured in method cls_Get_TreatmentBillingData_per_HICompany_byIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_GTBDpHICfID_1130 : FR_Base
	{
		public L6TR_GTBDpHICfID_1130 Result	{ get; set; }

		public FR_L6TR_GTBDpHICfID_1130() : base() {}

		public FR_L6TR_GTBDpHICfID_1130(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GTBDpHICfID_1130 for attribute P_L6TR_GTBDpHICfID_1130
		[DataContract]
		public class P_L6TR_GTBDpHICfID_1130 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID_List { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTBDpHICfID_1130 for attribute L6TR_GTBDpHICfID_1130
		[DataContract]
		public class L6TR_GTBDpHICfID_1130 
		{
			[DataMember]
			public L6TR_GTBDpHICfID_1130_HICompany[] HICompanies { get; set; }

			//Standard type parameters
			[DataMember]
			public long previousMaxPositionIndex { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTBDpHICfID_1130_HICompany for attribute HICompanies
		[DataContract]
		public class L6TR_GTBDpHICfID_1130_HICompany 
		{
			[DataMember]
			public L6TR_GTBDpHICfID_1130_Position[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HIS_HealthInsurance_CompanyID { get; set; } 
			[DataMember]
			public string HealthInsurance_Number { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTBDpHICfID_1130_Position for attribute Positions
		[DataContract]
		public class L6TR_GTBDpHICfID_1130_Position 
		{
			[DataMember]
			public L6TR_GTBDpHICfID_1130_ArticleInfo[] ArticleInfos { get; set; }
			[DataMember]
			public L6TR_GTBDpHICfID_1130_DiagnosisInfo[] DiagnosisInfos { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid FollowupID { get; set; } 
			[DataMember]
			public Guid TreatmentID { get; set; } 
			[DataMember]
			public string PatientFirstName { get; set; } 
			[DataMember]
			public string PatientLastName { get; set; } 
			[DataMember]
			public string PatientInsuranceNumber { get; set; } 
			[DataMember]
			public DateTime dtPatientBirthDate { get; set; } 
			[DataMember]
			public string strDoctorLANR { get; set; } 
			[DataMember]
			public string strPracticeBSNR { get; set; } 
			[DataMember]
			public bool bTreatmentIsFollowup { get; set; } 
			[DataMember]
			public int iTreatmentNumber { get; set; } 
			[DataMember]
			public DateTime dtTreatment { get; set; } 
			[DataMember]
			public string cTreatmentLocalization { get; set; } 
			[DataMember]
			public string iPatientInsuranceState { get; set; } 
			[DataMember]
			public int iPatientSex { get; set; } 
			[DataMember]
			public string strFollowupPractice { get; set; } 
			[DataMember]
			public string strFollowupDoctor { get; set; } 
			[DataMember]
			public string strFollowupStatus { get; set; } 
			[DataMember]
			public DateTime dtFollowup { get; set; } 
			[DataMember]
			public string healthInsuranceCompany { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTBDpHICfID_1130_ArticleInfo for attribute ArticleInfos
		[DataContract]
		public class L6TR_GTBDpHICfID_1130_ArticleInfo 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string PZN { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTBDpHICfID_1130_DiagnosisInfo for attribute DiagnosisInfos
		[DataContract]
		public class L6TR_GTBDpHICfID_1130_DiagnosisInfo 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisID { get; set; } 
			[DataMember]
			public string strDiagnosisICD10 { get; set; } 
			[DataMember]
			public string cDiagnosisState { get; set; } 
			[DataMember]
			public Dict PatientInsuranceState { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_GTBDpHICfID_1130 cls_Get_TreatmentBillingData_per_HICompany_byIDs(,P_L6TR_GTBDpHICfID_1130 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_GTBDpHICfID_1130 invocationResult = cls_Get_TreatmentBillingData_per_HICompany_byIDs.Invoke(connectionString,P_L6TR_GTBDpHICfID_1130 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Retrieval.P_L6TR_GTBDpHICfID_1130();
parameter.TreatmentID_List = ...;

*/
