/* 
 * Generated on 2/19/2015 11:18:58
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
using CL5_MyHealthClub_Patient.Atomic.Retrieval;
using CL5_MyHealthClub_Examanations.Atomic.Retrieval;
using BOp.Providers;

namespace CL6_MyHealthClub_Examanations.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Curent_Patient_data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Curent_Patient_data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6EX_GCPD_1353 Execute(DbConnection Connection,DbTransaction Transaction,P_L6EX_GCPD_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6EX_GCPD_1353();
            returnValue.Result = new L6EX_GCPD_1353();
            List<L6EX_GCPD_1353_current_diagnosis> diagnoseList = new List<L6EX_GCPD_1353_current_diagnosis>();
            List<L6EX_GCPD_1353_current_medication> medicationList = new List<L6EX_GCPD_1353_current_medication>();
            returnValue.Result.current_diagnosis = diagnoseList.ToArray();
            returnValue.Result.current_medication = medicationList.ToArray();
            
            var curentPatientDiagnoses = cls_Get_Curent_Patient_Diagnoses.Invoke(Connection,Transaction, new P_L5EX_GCPM_1150 { PatientID = Parameter.PatientID }, securityTicket).Result.ToList();
            var curentPatientMedications = cls_Get_Current_Patient_Medications.Invoke(Connection, Transaction, new P_L5EX_GCPM_1331 {PatientID = Parameter.PatientID }, securityTicket).Result.ToList();
            var curentPatientSubstances = cls_Get_Curent_Patient_Substances.Invoke(Connection, Transaction, new P_L5EX_GCPS_1354 { PatientID = Parameter.PatientID }, securityTicket).Result.ToList();

            var _providerFactory = ProviderFactory.Instance;
            var documentProvider = _providerFactory.CreateDocumentServiceProvider();

            foreach (var item in curentPatientDiagnoses)
            {
                L6EX_GCPD_1353_current_diagnosis diagnose = new L6EX_GCPD_1353_current_diagnosis();
                diagnose.date = item.diagnosed_on.ToShortDateString();
                diagnose.doctor = item.doctor;
                diagnose.id = item.HEC_ACT_PerformedAction_DiagnosisUpdateID.ToString();
                diagnose.icd10 = item.ICD10_Code;
                diagnose.name = item.PotentialDiagnosis_Name.Contents[0].Content;
                diagnose.doctor_url = (item.ProfileImage_Document_RefID == Guid.Empty) ? "../Images/icons/no_avatar.png" :documentProvider.GenerateImageThumbnailLink(item.ProfileImage_Document_RefID, securityTicket.SessionTicket, false, 40);
                diagnoseList.Add(diagnose);
            }

            foreach (var item in curentPatientMedications)
            {
                L6EX_GCPD_1353_current_medication medication = new L6EX_GCPD_1353_current_medication();
                medication.medication_id = item.HEC_Patient_MedicationID.ToString();
                medication.medication = item.Product_Name.Contents[0].Content + " " + item.PackageContent_Amount + " " + item.ISOCode + " " +item.DosageForm_Name.Contents[0].Content;
                medication.added_date = item.R_DateOfAdding.ToShortDateString();
                medication.use_until_date = item.R_ActiveUntill.ToShortDateString();
                medicationList.Add(medication);
            }

            foreach (var item in curentPatientSubstances)
            {
                L6EX_GCPD_1353_current_medication medication = new L6EX_GCPD_1353_current_medication();
                medication.medication_id = item.HEC_Patient_MedicationID.ToString();
                medication.medication = item.GlobalPropertyMatchingID + " " + item.R_DosageText + " " + item.R_IfSubstance_Strength;
                medication.added_date = item.R_DateOfAdding.ToShortDateString();
                medication.use_until_date = item.R_ActiveUntill.ToShortDateString();
                medicationList.Add(medication);
            }
            P_L5PA_GPDDfPID_1358 patientInfoparam = new P_L5PA_GPDDfPID_1358();
            patientInfoparam.PatientID = Parameter.PatientID;
            var patientInfo = cls_Get_PatientDetailData_for_PatientID.Invoke(Connection, Transaction, patientInfoparam,securityTicket).Result;
            L6EX_GCPD_1353_patient_info patientdata = new L6EX_GCPD_1353_patient_info();
            patientdata.Patient_name = patientInfo.FirstName + " " + patientInfo.LastName;
            patientdata.Patient_birthday = patientInfo.BirthDate;
            returnValue.Result.patient_info = patientdata;
            returnValue.Result.current_diagnosis = diagnoseList.ToArray();
            returnValue.Result.current_medication = medicationList.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6EX_GCPD_1353 Invoke(string ConnectionString,P_L6EX_GCPD_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6EX_GCPD_1353 Invoke(DbConnection Connection,P_L6EX_GCPD_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6EX_GCPD_1353 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6EX_GCPD_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6EX_GCPD_1353 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6EX_GCPD_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6EX_GCPD_1353 functionReturn = new FR_L6EX_GCPD_1353();
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

				throw new Exception("Exception occured in method cls_Get_Curent_Patient_data",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6EX_GCPD_1353 : FR_Base
	{
		public L6EX_GCPD_1353 Result	{ get; set; }

		public FR_L6EX_GCPD_1353() : base() {}

		public FR_L6EX_GCPD_1353(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6EX_GCPD_1353 for attribute P_L6EX_GCPD_1353
		[DataContract]
		public class P_L6EX_GCPD_1353 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L6EX_GCPD_1353 for attribute L6EX_GCPD_1353
		[DataContract]
		public class L6EX_GCPD_1353 
		{
			[DataMember]
			public L6EX_GCPD_1353_current_diagnosis[] current_diagnosis { get; set; }
			[DataMember]
			public L6EX_GCPD_1353_current_medication[] current_medication { get; set; }
			[DataMember]
			public L6EX_GCPD_1353_patient_info patient_info { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L6EX_GCPD_1353_current_diagnosis for attribute current_diagnosis
		[DataContract]
		public class L6EX_GCPD_1353_current_diagnosis 
		{
			//Standard type parameters
			[DataMember]
			public String icd10 { get; set; } 
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String date { get; set; } 
			[DataMember]
			public String doctor_url { get; set; } 
			[DataMember]
			public String doctor { get; set; } 
			[DataMember]
			public String id { get; set; } 

		}
		#endregion
		#region SClass L6EX_GCPD_1353_current_medication for attribute current_medication
		[DataContract]
		public class L6EX_GCPD_1353_current_medication 
		{
			//Standard type parameters
			[DataMember]
			public String medication { get; set; } 
			[DataMember]
			public String added_date { get; set; } 
			[DataMember]
			public String use_until_date { get; set; } 
			[DataMember]
			public String medication_id { get; set; } 

		}
		#endregion
		#region SClass L6EX_GCPD_1353_patient_info for attribute patient_info
		[DataContract]
		public class L6EX_GCPD_1353_patient_info 
		{
			//Standard type parameters
			[DataMember]
			public String Patient_name { get; set; } 
			[DataMember]
			public DateTime Patient_birthday { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6EX_GCPD_1353 cls_Get_Curent_Patient_data(,P_L6EX_GCPD_1353 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6EX_GCPD_1353 invocationResult = cls_Get_Curent_Patient_data.Invoke(connectionString,P_L6EX_GCPD_1353 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Examanations.Complex.Retrieval.P_L6EX_GCPD_1353();
parameter.PatientID = ...;

*/
