/* 
 * Generated on 06/16/16 12:58:21
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Cases_For_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Cases_For_Report
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCFR_0910_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCFR_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCFR_0910_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Cases_For_Report.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Status", Parameter.Status);



			List<CAS_GCFR_0910> results = new List<CAS_GCFR_0910>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Patient_LastName","Patient_FirstName","Patient_BirthDate","Patient_Gender","CaseNumber","IM_PotentialDiagnosisLocalization_Code","IM_PotentialDiagnosis_Name","IM_PotentialDiagnosis_Code","IM_PotentialDiagnosisState_Name","IM_PotentialDiagnosisCatalog_Name","TreatmentSubmitBPName","TreatmentPracticeName","AfterCaseSubmitMedicalPractice","AfterCaseSubmitResponsibleBPNAme","Patient_RefID","PotentialDiagnosis_RefID","AfterCareDoctor","SurgeryDoctor","CaseID","StatusID","TreatmentCaseSubmitActionID","afterCaseSubmitActionID","LocalizationID","LocalizationImID","DiganoseImID","Code","Catalog_Name_DictID","PotentialDiagnosis_Name_DictID","CodeForType","TreatmentDate","AfterCareDate","BillingCode","StatusNumber","PositionNumber","IsTreatmentP","IsAftercareP","TreatmentPerformedDiganoseID","AftercasePerformedDiagnoseID","TreatmentDiagnoseUpdateIM","AftercareDiagnoseUpdateIM","TreatmentLocalizationID","AftercareLocalizationID","TreatmentLocalizationCode","AftercareLocalizationCode","AftercaseLocalizationIDIM","TreatmentLocalizationIDIM","IsPatientFeeWaived","orderId","orderStatusCode","isLabelOnly","SendInvoiceToPractice","NumberForPayment","DrugID","CodeName","IsTreatmentID","IsAftercareID","TreatmentPracticeID","AftercarePracticeID","PatientHIP","InsuranceID","GposID","BillPositionID","CaseCreationDate" });
				while(reader.Read())
				{
					CAS_GCFR_0910 resultItem = new CAS_GCFR_0910();
					//0:Parameter Patient_LastName of type String
					resultItem.Patient_LastName = reader.GetString(0);
					//1:Parameter Patient_FirstName of type String
					resultItem.Patient_FirstName = reader.GetString(1);
					//2:Parameter Patient_BirthDate of type DateTime
					resultItem.Patient_BirthDate = reader.GetDate(2);
					//3:Parameter Patient_Gender of type Double
					resultItem.Patient_Gender = reader.GetDouble(3);
					//4:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(4);
					//5:Parameter IM_PotentialDiagnosisLocalization_Code of type String
					resultItem.IM_PotentialDiagnosisLocalization_Code = reader.GetString(5);
					//6:Parameter IM_PotentialDiagnosis_Name of type String
					resultItem.IM_PotentialDiagnosis_Name = reader.GetString(6);
					//7:Parameter IM_PotentialDiagnosis_Code of type String
					resultItem.IM_PotentialDiagnosis_Code = reader.GetString(7);
					//8:Parameter IM_PotentialDiagnosisState_Name of type String
					resultItem.IM_PotentialDiagnosisState_Name = reader.GetString(8);
					//9:Parameter IM_PotentialDiagnosisCatalog_Name of type String
					resultItem.IM_PotentialDiagnosisCatalog_Name = reader.GetString(9);
					//10:Parameter TreatmentSubmitBPName of type String
					resultItem.TreatmentSubmitBPName = reader.GetString(10);
					//11:Parameter TreatmentPracticeName of type String
					resultItem.TreatmentPracticeName = reader.GetString(11);
					//12:Parameter AfterCaseSubmitMedicalPractice of type String
					resultItem.AfterCaseSubmitMedicalPractice = reader.GetString(12);
					//13:Parameter AfterCaseSubmitResponsibleBPNAme of type String
					resultItem.AfterCaseSubmitResponsibleBPNAme = reader.GetString(13);
					//14:Parameter Patient_RefID of type Guid
					resultItem.Patient_RefID = reader.GetGuid(14);
					//15:Parameter PotentialDiagnosis_RefID of type Guid
					resultItem.PotentialDiagnosis_RefID = reader.GetGuid(15);
					//16:Parameter AfterCareDoctor of type Guid
					resultItem.AfterCareDoctor = reader.GetGuid(16);
					//17:Parameter SurgeryDoctor of type Guid
					resultItem.SurgeryDoctor = reader.GetGuid(17);
					//18:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(18);
					//19:Parameter StatusID of type Guid
					resultItem.StatusID = reader.GetGuid(19);
					//20:Parameter TreatmentCaseSubmitActionID of type Guid
					resultItem.TreatmentCaseSubmitActionID = reader.GetGuid(20);
					//21:Parameter afterCaseSubmitActionID of type Guid
					resultItem.afterCaseSubmitActionID = reader.GetGuid(21);
					//22:Parameter LocalizationID of type Guid
					resultItem.LocalizationID = reader.GetGuid(22);
					//23:Parameter LocalizationImID of type Guid
					resultItem.LocalizationImID = reader.GetGuid(23);
					//24:Parameter DiganoseImID of type Guid
					resultItem.DiganoseImID = reader.GetGuid(24);
					//25:Parameter Code of type String
					resultItem.Code = reader.GetString(25);
					//26:Parameter Catalog_Name_DictID of type Dict
					resultItem.Catalog_Name_DictID = reader.GetDictionary(26);
					resultItem.Catalog_Name_DictID.SourceTable = "hec_dia_potentialdiagnosis_catalogs";
					loader.Append(resultItem.Catalog_Name_DictID);
					//27:Parameter PotentialDiagnosis_Name_DictID of type Dict
					resultItem.PotentialDiagnosis_Name_DictID = reader.GetDictionary(27);
					resultItem.PotentialDiagnosis_Name_DictID.SourceTable = "hec_dia_potentialdiagnosis_catalogs";
					loader.Append(resultItem.PotentialDiagnosis_Name_DictID);
					//28:Parameter CodeForType of type String
					resultItem.CodeForType = reader.GetString(28);
					//29:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(29);
					//30:Parameter AfterCareDate of type DateTime
					resultItem.AfterCareDate = reader.GetDate(30);
					//31:Parameter BillingCode of type String
					resultItem.BillingCode = reader.GetString(31);
					//32:Parameter StatusNumber of type String
					resultItem.StatusNumber = reader.GetString(32);
					//33:Parameter PositionNumber of type String
					resultItem.PositionNumber = reader.GetString(33);
					//34:Parameter IsTreatmentP of type bool
					resultItem.IsTreatmentP = reader.GetBoolean(34);
					//35:Parameter IsAftercareP of type bool
					resultItem.IsAftercareP = reader.GetBoolean(35);
					//36:Parameter TreatmentPerformedDiganoseID of type Guid
					resultItem.TreatmentPerformedDiganoseID = reader.GetGuid(36);
					//37:Parameter AftercasePerformedDiagnoseID of type Guid
					resultItem.AftercasePerformedDiagnoseID = reader.GetGuid(37);
					//38:Parameter TreatmentDiagnoseUpdateIM of type Guid
					resultItem.TreatmentDiagnoseUpdateIM = reader.GetGuid(38);
					//39:Parameter AftercareDiagnoseUpdateIM of type Guid
					resultItem.AftercareDiagnoseUpdateIM = reader.GetGuid(39);
					//40:Parameter TreatmentLocalizationID of type Guid
					resultItem.TreatmentLocalizationID = reader.GetGuid(40);
					//41:Parameter AftercareLocalizationID of type Guid
					resultItem.AftercareLocalizationID = reader.GetGuid(41);
					//42:Parameter TreatmentLocalizationCode of type String
					resultItem.TreatmentLocalizationCode = reader.GetString(42);
					//43:Parameter AftercareLocalizationCode of type String
					resultItem.AftercareLocalizationCode = reader.GetString(43);
					//44:Parameter AftercaseLocalizationIDIM of type Guid
					resultItem.AftercaseLocalizationIDIM = reader.GetGuid(44);
					//45:Parameter TreatmentLocalizationIDIM of type Guid
					resultItem.TreatmentLocalizationIDIM = reader.GetGuid(45);
					//46:Parameter IsPatientFeeWaived of type Boolean
					resultItem.IsPatientFeeWaived = reader.GetBoolean(46);
					//47:Parameter orderId of type Guid
					resultItem.orderId = reader.GetGuid(47);
					//48:Parameter orderStatusCode of type string
					resultItem.orderStatusCode = reader.GetString(48);
					//49:Parameter isLabelOnly of type Boolean
					resultItem.isLabelOnly = reader.GetBoolean(49);
					//50:Parameter SendInvoiceToPractice of type Boolean
					resultItem.SendInvoiceToPractice = reader.GetBoolean(50);
					//51:Parameter NumberForPayment of type int
					resultItem.NumberForPayment = reader.GetInteger(51);
					//52:Parameter DrugID of type Guid
					resultItem.DrugID = reader.GetGuid(52);
					//53:Parameter CodeName of type String
					resultItem.CodeName = reader.GetString(53);
					//54:Parameter IsTreatmentID of type Guid
					resultItem.IsTreatmentID = reader.GetGuid(54);
					//55:Parameter IsAftercareID of type Guid
					resultItem.IsAftercareID = reader.GetGuid(55);
					//56:Parameter TreatmentPracticeID of type Guid
					resultItem.TreatmentPracticeID = reader.GetGuid(56);
					//57:Parameter AftercarePracticeID of type Guid
					resultItem.AftercarePracticeID = reader.GetGuid(57);
					//58:Parameter PatientHIP of type String
					resultItem.PatientHIP = reader.GetString(58);
					//59:Parameter InsuranceID of type String
					resultItem.InsuranceID = reader.GetString(59);
					//60:Parameter GposID of type Guid
					resultItem.GposID = reader.GetGuid(60);
					//61:Parameter BillPositionID of type Guid
					resultItem.BillPositionID = reader.GetGuid(61);
					//62:Parameter CaseCreationDate of type DateTime
					resultItem.CaseCreationDate = reader.GetDate(62);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Cases_For_Report",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GCFR_0910_Array Invoke(string ConnectionString,P_CAS_GCFR_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCFR_0910_Array Invoke(DbConnection Connection,P_CAS_GCFR_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCFR_0910_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCFR_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCFR_0910_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCFR_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCFR_0910_Array functionReturn = new FR_CAS_GCFR_0910_Array();
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

				throw new Exception("Exception occured in method cls_Get_Cases_For_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCFR_0910_Array : FR_Base
	{
		public CAS_GCFR_0910[] Result	{ get; set; } 
		public FR_CAS_GCFR_0910_Array() : base() {}

		public FR_CAS_GCFR_0910_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCFR_0910 for attribute P_CAS_GCFR_0910
		[DataContract]
		public class P_CAS_GCFR_0910 
		{
			//Standard type parameters
			[DataMember]
			public Double Status { get; set; } 

		}
		#endregion
		#region SClass CAS_GCFR_0910 for attribute CAS_GCFR_0910
		[DataContract]
		public class CAS_GCFR_0910 
		{
			//Standard type parameters
			[DataMember]
			public String Patient_LastName { get; set; } 
			[DataMember]
			public String Patient_FirstName { get; set; } 
			[DataMember]
			public DateTime Patient_BirthDate { get; set; } 
			[DataMember]
			public Double Patient_Gender { get; set; } 
			[DataMember]
			public String CaseNumber { get; set; } 
			[DataMember]
			public String IM_PotentialDiagnosisLocalization_Code { get; set; } 
			[DataMember]
			public String IM_PotentialDiagnosis_Name { get; set; } 
			[DataMember]
			public String IM_PotentialDiagnosis_Code { get; set; } 
			[DataMember]
			public String IM_PotentialDiagnosisState_Name { get; set; } 
			[DataMember]
			public String IM_PotentialDiagnosisCatalog_Name { get; set; } 
			[DataMember]
			public String TreatmentSubmitBPName { get; set; } 
			[DataMember]
			public String TreatmentPracticeName { get; set; } 
			[DataMember]
			public String AfterCaseSubmitMedicalPractice { get; set; } 
			[DataMember]
			public String AfterCaseSubmitResponsibleBPNAme { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid AfterCareDoctor { get; set; } 
			[DataMember]
			public Guid SurgeryDoctor { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid StatusID { get; set; } 
			[DataMember]
			public Guid TreatmentCaseSubmitActionID { get; set; } 
			[DataMember]
			public Guid afterCaseSubmitActionID { get; set; } 
			[DataMember]
			public Guid LocalizationID { get; set; } 
			[DataMember]
			public Guid LocalizationImID { get; set; } 
			[DataMember]
			public Guid DiganoseImID { get; set; } 
			[DataMember]
			public String Code { get; set; } 
			[DataMember]
			public Dict Catalog_Name_DictID { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name_DictID { get; set; } 
			[DataMember]
			public String CodeForType { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public DateTime AfterCareDate { get; set; } 
			[DataMember]
			public String BillingCode { get; set; } 
			[DataMember]
			public String StatusNumber { get; set; } 
			[DataMember]
			public String PositionNumber { get; set; } 
			[DataMember]
			public bool IsTreatmentP { get; set; } 
			[DataMember]
			public bool IsAftercareP { get; set; } 
			[DataMember]
			public Guid TreatmentPerformedDiganoseID { get; set; } 
			[DataMember]
			public Guid AftercasePerformedDiagnoseID { get; set; } 
			[DataMember]
			public Guid TreatmentDiagnoseUpdateIM { get; set; } 
			[DataMember]
			public Guid AftercareDiagnoseUpdateIM { get; set; } 
			[DataMember]
			public Guid TreatmentLocalizationID { get; set; } 
			[DataMember]
			public Guid AftercareLocalizationID { get; set; } 
			[DataMember]
			public String TreatmentLocalizationCode { get; set; } 
			[DataMember]
			public String AftercareLocalizationCode { get; set; } 
			[DataMember]
			public Guid AftercaseLocalizationIDIM { get; set; } 
			[DataMember]
			public Guid TreatmentLocalizationIDIM { get; set; } 
			[DataMember]
			public Boolean IsPatientFeeWaived { get; set; } 
			[DataMember]
			public Guid orderId { get; set; } 
			[DataMember]
			public string orderStatusCode { get; set; } 
			[DataMember]
			public Boolean isLabelOnly { get; set; } 
			[DataMember]
			public Boolean SendInvoiceToPractice { get; set; } 
			[DataMember]
			public int NumberForPayment { get; set; } 
			[DataMember]
			public Guid DrugID { get; set; } 
			[DataMember]
			public String CodeName { get; set; } 
			[DataMember]
			public Guid IsTreatmentID { get; set; } 
			[DataMember]
			public Guid IsAftercareID { get; set; } 
			[DataMember]
			public Guid TreatmentPracticeID { get; set; } 
			[DataMember]
			public Guid AftercarePracticeID { get; set; } 
			[DataMember]
			public String PatientHIP { get; set; } 
			[DataMember]
			public String InsuranceID { get; set; } 
			[DataMember]
			public Guid GposID { get; set; } 
			[DataMember]
			public Guid BillPositionID { get; set; } 
			[DataMember]
			public DateTime CaseCreationDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCFR_0910_Array cls_Get_Cases_For_Report(,P_CAS_GCFR_0910 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCFR_0910_Array invocationResult = cls_Get_Cases_For_Report.Invoke(connectionString,P_CAS_GCFR_0910 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCFR_0910();
parameter.Status = ...;

*/
