/* 
 * Generated on 01/26/16 10:23:16
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
    /// var result = cls_Get_Cases_for_General_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Cases_for_General_Report
	{
		public static readonly int QueryTimeout = 300;

		#region Method Execution
		protected static FR_CAS_GCFGR_1410_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCFGR_1410_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Cases_for_General_Report.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GCFGR_1410> results = new List<CAS_GCFGR_1410>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CaseNumber","IM_PotentialDiagnosisLocalization_Code","IM_PotentialDiagnosis_Name","IM_PotentialDiagnosis_Code","IM_PotentialDiagnosisState_Name","IM_PotentialDiagnosisCatalog_Name","TreatmentSubmitBPName","TreatmentPracticeName","AfterCaseSubmitMedicalPractice","AfterCaseSubmitResponsibleBPNAme","Patient_RefID","PotentialDiagnosis_RefID","AfterCareDoctor","SurgeryDoctor","CaseID","StatusID","TreatmentCaseSubmitActionID","afterCaseSubmitActionID","LocalizationID","LocalizationImID","DiganoseImID","Code","Catalog_Name_DictID","PotentialDiagnosis_Name_DictID","CodeForType","TreatmentDate","AfterCareDate","BillingCode","StatusNumber","PositionNumber","PositionValue_IncludingTax","IsTreatmentP","IsAftercareP","TreatmentPerformedDiganoseID","AftercasePerformedDiagnoseID","TreatmentDiagnoseUpdateIM","AftercareDiagnoseUpdateIM","TreatmentLocalizationID","AftercareLocalizationID","TreatmentLocalizationCode","AftercareLocalizationCode","AftercaseLocalizationIDIM","TreatmentLocalizationIDIM","IsPatientFeeWaived","orderId","orderStatusCode","isLabelOnly","SendInvoiceToPractice","NumberForPayment","DrugID","CodeName","IsTreatmentID","IsAftercareID","AftercareBPT","GposType","GposID","BillPositionID","IsAftercareCancelled","CaseCreationDate" });
				while(reader.Read())
				{
					CAS_GCFGR_1410 resultItem = new CAS_GCFGR_1410();
					//0:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(0);
					//1:Parameter IM_PotentialDiagnosisLocalization_Code of type String
					resultItem.IM_PotentialDiagnosisLocalization_Code = reader.GetString(1);
					//2:Parameter IM_PotentialDiagnosis_Name of type String
					resultItem.IM_PotentialDiagnosis_Name = reader.GetString(2);
					//3:Parameter IM_PotentialDiagnosis_Code of type String
					resultItem.IM_PotentialDiagnosis_Code = reader.GetString(3);
					//4:Parameter IM_PotentialDiagnosisState_Name of type String
					resultItem.IM_PotentialDiagnosisState_Name = reader.GetString(4);
					//5:Parameter IM_PotentialDiagnosisCatalog_Name of type String
					resultItem.IM_PotentialDiagnosisCatalog_Name = reader.GetString(5);
					//6:Parameter TreatmentSubmitBPName of type String
					resultItem.TreatmentSubmitBPName = reader.GetString(6);
					//7:Parameter TreatmentPracticeName of type String
					resultItem.TreatmentPracticeName = reader.GetString(7);
					//8:Parameter AfterCaseSubmitMedicalPractice of type String
					resultItem.AfterCaseSubmitMedicalPractice = reader.GetString(8);
					//9:Parameter AfterCaseSubmitResponsibleBPNAme of type String
					resultItem.AfterCaseSubmitResponsibleBPNAme = reader.GetString(9);
					//10:Parameter Patient_RefID of type Guid
					resultItem.Patient_RefID = reader.GetGuid(10);
					//11:Parameter PotentialDiagnosis_RefID of type Guid
					resultItem.PotentialDiagnosis_RefID = reader.GetGuid(11);
					//12:Parameter AfterCareDoctor of type Guid
					resultItem.AfterCareDoctor = reader.GetGuid(12);
					//13:Parameter SurgeryDoctor of type Guid
					resultItem.SurgeryDoctor = reader.GetGuid(13);
					//14:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(14);
					//15:Parameter StatusID of type Guid
					resultItem.StatusID = reader.GetGuid(15);
					//16:Parameter TreatmentCaseSubmitActionID of type Guid
					resultItem.TreatmentCaseSubmitActionID = reader.GetGuid(16);
					//17:Parameter afterCaseSubmitActionID of type Guid
					resultItem.afterCaseSubmitActionID = reader.GetGuid(17);
					//18:Parameter LocalizationID of type Guid
					resultItem.LocalizationID = reader.GetGuid(18);
					//19:Parameter LocalizationImID of type Guid
					resultItem.LocalizationImID = reader.GetGuid(19);
					//20:Parameter DiganoseImID of type Guid
					resultItem.DiganoseImID = reader.GetGuid(20);
					//21:Parameter Code of type String
					resultItem.Code = reader.GetString(21);
					//22:Parameter Catalog_Name_DictID of type Dict
					resultItem.Catalog_Name_DictID = reader.GetDictionary(22);
					resultItem.Catalog_Name_DictID.SourceTable = "hec_dia_potentialdiagnosis_catalogs";
					loader.Append(resultItem.Catalog_Name_DictID);
					//23:Parameter PotentialDiagnosis_Name_DictID of type Dict
					resultItem.PotentialDiagnosis_Name_DictID = reader.GetDictionary(23);
					resultItem.PotentialDiagnosis_Name_DictID.SourceTable = "hec_dia_potentialdiagnosis_catalogs";
					loader.Append(resultItem.PotentialDiagnosis_Name_DictID);
					//24:Parameter CodeForType of type String
					resultItem.CodeForType = reader.GetString(24);
					//25:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(25);
					//26:Parameter AfterCareDate of type DateTime
					resultItem.AfterCareDate = reader.GetDate(26);
					//27:Parameter BillingCode of type String
					resultItem.BillingCode = reader.GetString(27);
					//28:Parameter StatusNumber of type String
					resultItem.StatusNumber = reader.GetString(28);
					//29:Parameter PositionNumber of type String
					resultItem.PositionNumber = reader.GetString(29);
					//30:Parameter PositionValue_IncludingTax of type Double
					resultItem.PositionValue_IncludingTax = reader.GetDouble(30);
					//31:Parameter IsTreatmentP of type bool
					resultItem.IsTreatmentP = reader.GetBoolean(31);
					//32:Parameter IsAftercareP of type bool
					resultItem.IsAftercareP = reader.GetBoolean(32);
					//33:Parameter TreatmentPerformedDiganoseID of type Guid
					resultItem.TreatmentPerformedDiganoseID = reader.GetGuid(33);
					//34:Parameter AftercasePerformedDiagnoseID of type Guid
					resultItem.AftercasePerformedDiagnoseID = reader.GetGuid(34);
					//35:Parameter TreatmentDiagnoseUpdateIM of type Guid
					resultItem.TreatmentDiagnoseUpdateIM = reader.GetGuid(35);
					//36:Parameter AftercareDiagnoseUpdateIM of type Guid
					resultItem.AftercareDiagnoseUpdateIM = reader.GetGuid(36);
					//37:Parameter TreatmentLocalizationID of type Guid
					resultItem.TreatmentLocalizationID = reader.GetGuid(37);
					//38:Parameter AftercareLocalizationID of type Guid
					resultItem.AftercareLocalizationID = reader.GetGuid(38);
					//39:Parameter TreatmentLocalizationCode of type String
					resultItem.TreatmentLocalizationCode = reader.GetString(39);
					//40:Parameter AftercareLocalizationCode of type String
					resultItem.AftercareLocalizationCode = reader.GetString(40);
					//41:Parameter AftercaseLocalizationIDIM of type Guid
					resultItem.AftercaseLocalizationIDIM = reader.GetGuid(41);
					//42:Parameter TreatmentLocalizationIDIM of type Guid
					resultItem.TreatmentLocalizationIDIM = reader.GetGuid(42);
					//43:Parameter IsPatientFeeWaived of type Boolean
					resultItem.IsPatientFeeWaived = reader.GetBoolean(43);
					//44:Parameter orderId of type Guid
					resultItem.orderId = reader.GetGuid(44);
					//45:Parameter orderStatusCode of type string
					resultItem.orderStatusCode = reader.GetString(45);
					//46:Parameter isLabelOnly of type Boolean
					resultItem.isLabelOnly = reader.GetBoolean(46);
					//47:Parameter SendInvoiceToPractice of type Boolean
					resultItem.SendInvoiceToPractice = reader.GetBoolean(47);
					//48:Parameter NumberForPayment of type int
					resultItem.NumberForPayment = reader.GetInteger(48);
					//49:Parameter DrugID of type Guid
					resultItem.DrugID = reader.GetGuid(49);
					//50:Parameter CodeName of type String
					resultItem.CodeName = reader.GetString(50);
					//51:Parameter IsTreatmentID of type Guid
					resultItem.IsTreatmentID = reader.GetGuid(51);
					//52:Parameter IsAftercareID of type Guid
					resultItem.IsAftercareID = reader.GetGuid(52);
					//53:Parameter AftercareBPT of type Guid
					resultItem.AftercareBPT = reader.GetGuid(53);
					//54:Parameter GposType of type String
					resultItem.GposType = reader.GetString(54);
					//55:Parameter GposID of type Guid
					resultItem.GposID = reader.GetGuid(55);
					//56:Parameter BillPositionID of type Guid
					resultItem.BillPositionID = reader.GetGuid(56);
					//57:Parameter IsAftercareCancelled of type Boolean
					resultItem.IsAftercareCancelled = reader.GetBoolean(57);
					//58:Parameter CaseCreationDate of type DateTime
					resultItem.CaseCreationDate = reader.GetDate(58);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Cases_for_General_Report",ex);
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
		public static FR_CAS_GCFGR_1410_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCFGR_1410_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCFGR_1410_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCFGR_1410_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCFGR_1410_Array functionReturn = new FR_CAS_GCFGR_1410_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Cases_for_General_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCFGR_1410_Array : FR_Base
	{
		public CAS_GCFGR_1410[] Result	{ get; set; } 
		public FR_CAS_GCFGR_1410_Array() : base() {}

		public FR_CAS_GCFGR_1410_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GCFGR_1410 for attribute CAS_GCFGR_1410
		[DataContract]
		public class CAS_GCFGR_1410 
		{
			//Standard type parameters
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
			public Double PositionValue_IncludingTax { get; set; } 
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
			public Guid AftercareBPT { get; set; } 
			[DataMember]
			public String GposType { get; set; } 
			[DataMember]
			public Guid GposID { get; set; } 
			[DataMember]
			public Guid BillPositionID { get; set; } 
			[DataMember]
			public Boolean IsAftercareCancelled { get; set; } 
			[DataMember]
			public DateTime CaseCreationDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCFGR_1410_Array cls_Get_Cases_for_General_Report(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCFGR_1410_Array invocationResult = cls_Get_Cases_for_General_Report.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

