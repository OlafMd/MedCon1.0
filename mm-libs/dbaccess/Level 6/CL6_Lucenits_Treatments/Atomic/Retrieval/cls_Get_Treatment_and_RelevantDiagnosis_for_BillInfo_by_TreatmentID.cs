/* 
 * Generated on 8/20/2013 12:54:32 PM
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

namespace CL6_Lucenits_Treatments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TR_GTaRDfBIbT_1204_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GTaRDfBIbT_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6TR_GTaRDfBIbT_1204_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Treatments.Atomic.Retrieval.SQL.cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@TreatmentID"," IN $$TreatmentID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$TreatmentID$",Parameter.TreatmentID);


			List<L6TR_GTaRDfBIbT_1204_raw> results = new List<L6TR_GTaRDfBIbT_1204_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","TreatmentPractice_RefID","IsTreatmentPerformed","IfTreatmentPerformed_ByDoctor_RefID","IfTreatmentPerformed_Date","IsTreatmentFollowup","IfTreatmentFollowup_FromTreatment_RefID","IsScheduled","IfSheduled_Date","IsTreatmentBilled","IfTreatmentBilled_Date","Treatment_Comment","IsTreatmentOfLeftEye","IsTreatmentOfRightEye","HEC_Patient_Treatment_RelevantDiagnosisID","HEC_DIA_Diagnosis_StateID","HEC_DIA_PotentialDiagnosisID","Doctor_RefID","ICD10_Code","DiagnosisState_Name_DictID","DiagnosisState_Abbreviation","Creation_Date","DiagnosedOnDate","PotentialDiagnosis_Name_DictID","CMN_PRO_ProductID","Product_Number","Quantity","Product_Name_DictID" });
				while(reader.Read())
				{
					L6TR_GTaRDfBIbT_1204_raw resultItem = new L6TR_GTaRDfBIbT_1204_raw();
					//0:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(0);
					//1:Parameter TreatmentPractice_RefID of type Guid
					resultItem.TreatmentPractice_RefID = reader.GetGuid(1);
					//2:Parameter IsTreatmentPerformed of type bool
					resultItem.IsTreatmentPerformed = reader.GetBoolean(2);
					//3:Parameter IfTreatmentPerformed_ByDoctor_RefID of type Guid
					resultItem.IfTreatmentPerformed_ByDoctor_RefID = reader.GetGuid(3);
					//4:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(4);
					//5:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(5);
					//6:Parameter IfTreatmentFollowup_FromTreatment_RefID of type Guid
					resultItem.IfTreatmentFollowup_FromTreatment_RefID = reader.GetGuid(6);
					//7:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(7);
					//8:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(8);
					//9:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(9);
					//10:Parameter IfTreatmentBilled_Date of type DateTime
					resultItem.IfTreatmentBilled_Date = reader.GetDate(10);
					//11:Parameter Treatment_Comment of type String
					resultItem.Treatment_Comment = reader.GetString(11);
					//12:Parameter IsTreatmentOfLeftEye of type bool
					resultItem.IsTreatmentOfLeftEye = reader.GetBoolean(12);
					//13:Parameter IsTreatmentOfRightEye of type bool
					resultItem.IsTreatmentOfRightEye = reader.GetBoolean(13);
					//14:Parameter HEC_Patient_Treatment_RelevantDiagnosisID of type Guid
					resultItem.HEC_Patient_Treatment_RelevantDiagnosisID = reader.GetGuid(14);
					//15:Parameter HEC_DIA_Diagnosis_StateID of type Guid
					resultItem.HEC_DIA_Diagnosis_StateID = reader.GetGuid(15);
					//16:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(16);
					//17:Parameter Doctor_RefID of type Guid
					resultItem.Doctor_RefID = reader.GetGuid(17);
					//18:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(18);
					//19:Parameter DiagnosisState_Name of type Dict
					resultItem.DiagnosisState_Name = reader.GetDictionary(19);
					resultItem.DiagnosisState_Name.SourceTable = "hec_dia_diagnosis_states";
					loader.Append(resultItem.DiagnosisState_Name);
					//20:Parameter DiagnosisState_Abbreviation of type String
					resultItem.DiagnosisState_Abbreviation = reader.GetString(20);
					//21:Parameter Creation_Date of type DateTime
					resultItem.Creation_Date = reader.GetDate(21);
					//22:Parameter DiagnosedOnDate of type DateTime
					resultItem.DiagnosedOnDate = reader.GetDate(22);
					//23:Parameter PotentialDiagnosis_Name_DictID of type Dict
					resultItem.PotentialDiagnosis_Name_DictID = reader.GetDictionary(23);
					resultItem.PotentialDiagnosis_Name_DictID.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name_DictID);
					//24:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(24);
					//25:Parameter Product_Number of type string
					resultItem.Product_Number = reader.GetString(25);
					//26:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(26);
					//27:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(27);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6TR_GTaRDfBIbT_1204_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_GTaRDfBIbT_1204_Array Invoke(string ConnectionString,P_L6TR_GTaRDfBIbT_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GTaRDfBIbT_1204_Array Invoke(DbConnection Connection,P_L6TR_GTaRDfBIbT_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GTaRDfBIbT_1204_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GTaRDfBIbT_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GTaRDfBIbT_1204_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GTaRDfBIbT_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GTaRDfBIbT_1204_Array functionReturn = new FR_L6TR_GTaRDfBIbT_1204_Array();
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

				throw new Exception("Exception occured in method cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6TR_GTaRDfBIbT_1204_raw 
	{
		public Guid HEC_Patient_TreatmentID; 
		public Guid TreatmentPractice_RefID; 
		public bool IsTreatmentPerformed; 
		public Guid IfTreatmentPerformed_ByDoctor_RefID; 
		public DateTime IfTreatmentPerformed_Date; 
		public bool IsTreatmentFollowup; 
		public Guid IfTreatmentFollowup_FromTreatment_RefID; 
		public bool IsScheduled; 
		public DateTime IfSheduled_Date; 
		public bool IsTreatmentBilled; 
		public DateTime IfTreatmentBilled_Date; 
		public String Treatment_Comment; 
		public bool IsTreatmentOfLeftEye; 
		public bool IsTreatmentOfRightEye; 
		public Guid HEC_Patient_Treatment_RelevantDiagnosisID; 
		public Guid HEC_DIA_Diagnosis_StateID; 
		public Guid HEC_DIA_PotentialDiagnosisID; 
		public Guid Doctor_RefID; 
		public String ICD10_Code; 
		public Dict DiagnosisState_Name; 
		public String DiagnosisState_Abbreviation; 
		public DateTime Creation_Date; 
		public DateTime DiagnosedOnDate; 
		public Dict PotentialDiagnosis_Name_DictID; 
		public Guid CMN_PRO_ProductID; 
		public string Product_Number; 
		public double Quantity; 
		public Dict Product_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6TR_GTaRDfBIbT_1204[] Convert(List<L6TR_GTaRDfBIbT_1204_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6TR_GTaRDfBIbT_1204 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_L6TR_GTaRDfBIbT_1204 by new 
	{ 
		el_L6TR_GTaRDfBIbT_1204.HEC_Patient_TreatmentID,

	}
	into gfunct_L6TR_GTaRDfBIbT_1204
	select new L6TR_GTaRDfBIbT_1204
	{     
		HEC_Patient_TreatmentID = gfunct_L6TR_GTaRDfBIbT_1204.Key.HEC_Patient_TreatmentID ,
		TreatmentPractice_RefID = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().TreatmentPractice_RefID ,
		IsTreatmentPerformed = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IsTreatmentPerformed ,
		IfTreatmentPerformed_ByDoctor_RefID = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IfTreatmentPerformed_ByDoctor_RefID ,
		IfTreatmentPerformed_Date = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IfTreatmentPerformed_Date ,
		IsTreatmentFollowup = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IsTreatmentFollowup ,
		IfTreatmentFollowup_FromTreatment_RefID = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IfTreatmentFollowup_FromTreatment_RefID ,
		IsScheduled = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IsScheduled ,
		IfSheduled_Date = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IfSheduled_Date ,
		IsTreatmentBilled = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IsTreatmentBilled ,
		IfTreatmentBilled_Date = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IfTreatmentBilled_Date ,
		Treatment_Comment = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().Treatment_Comment ,
		IsTreatmentOfLeftEye = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IsTreatmentOfLeftEye ,
		IsTreatmentOfRightEye = gfunct_L6TR_GTaRDfBIbT_1204.FirstOrDefault().IsTreatmentOfRightEye ,

		RelevantDiagnosis = 
		(
			from el_RelevantDiagnosis in gfunct_L6TR_GTaRDfBIbT_1204.Where(element => !EqualsDefaultValue(element.HEC_Patient_Treatment_RelevantDiagnosisID)).ToArray()
			group el_RelevantDiagnosis by new 
			{ 
				el_RelevantDiagnosis.HEC_Patient_Treatment_RelevantDiagnosisID,

			}
			into gfunct_RelevantDiagnosis
			select new L6TR_GTaRDfBIbT_1204_RelevantDiagnose
			{     
				HEC_Patient_Treatment_RelevantDiagnosisID = gfunct_RelevantDiagnosis.Key.HEC_Patient_Treatment_RelevantDiagnosisID ,
				HEC_DIA_Diagnosis_StateID = gfunct_RelevantDiagnosis.FirstOrDefault().HEC_DIA_Diagnosis_StateID ,
				HEC_DIA_PotentialDiagnosisID = gfunct_RelevantDiagnosis.FirstOrDefault().HEC_DIA_PotentialDiagnosisID ,
				Doctor_RefID = gfunct_RelevantDiagnosis.FirstOrDefault().Doctor_RefID ,
				ICD10_Code = gfunct_RelevantDiagnosis.FirstOrDefault().ICD10_Code ,
				DiagnosisState_Name = gfunct_RelevantDiagnosis.FirstOrDefault().DiagnosisState_Name ,
				DiagnosisState_Abbreviation = gfunct_RelevantDiagnosis.FirstOrDefault().DiagnosisState_Abbreviation ,
				Creation_Date = gfunct_RelevantDiagnosis.FirstOrDefault().Creation_Date ,
				DiagnosedOnDate = gfunct_RelevantDiagnosis.FirstOrDefault().DiagnosedOnDate ,
				PotentialDiagnosis_Name_DictID = gfunct_RelevantDiagnosis.FirstOrDefault().PotentialDiagnosis_Name_DictID ,

			}
		).ToArray(),
		Article = 
		(
			from el_Article in gfunct_L6TR_GTaRDfBIbT_1204.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
			group el_Article by new 
			{ 
				el_Article.CMN_PRO_ProductID,

			}
			into gfunct_Article
			select new L6TR_GTaRDfBIbT_1204_Article
			{     
				CMN_PRO_ProductID = gfunct_Article.Key.CMN_PRO_ProductID ,
				Product_Number = gfunct_Article.FirstOrDefault().Product_Number ,
				Quantity = gfunct_Article.FirstOrDefault().Quantity ,
				Product_Name = gfunct_Article.FirstOrDefault().Product_Name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_GTaRDfBIbT_1204_Array : FR_Base
	{
		public L6TR_GTaRDfBIbT_1204[] Result	{ get; set; } 
		public FR_L6TR_GTaRDfBIbT_1204_Array() : base() {}

		public FR_L6TR_GTaRDfBIbT_1204_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GTaRDfBIbT_1204 for attribute P_L6TR_GTaRDfBIbT_1204
		[DataContract]
		public class P_L6TR_GTaRDfBIbT_1204 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTaRDfBIbT_1204 for attribute L6TR_GTaRDfBIbT_1204
		[DataContract]
		public class L6TR_GTaRDfBIbT_1204 
		{
			[DataMember]
			public L6TR_GTaRDfBIbT_1204_RelevantDiagnose[] RelevantDiagnosis { get; set; }
			[DataMember]
			public L6TR_GTaRDfBIbT_1204_Article[] Article { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public Guid TreatmentPractice_RefID { get; set; } 
			[DataMember]
			public bool IsTreatmentPerformed { get; set; } 
			[DataMember]
			public Guid IfTreatmentPerformed_ByDoctor_RefID { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public Guid IfTreatmentFollowup_FromTreatment_RefID { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 
			[DataMember]
			public String Treatment_Comment { get; set; } 
			[DataMember]
			public bool IsTreatmentOfLeftEye { get; set; } 
			[DataMember]
			public bool IsTreatmentOfRightEye { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTaRDfBIbT_1204_RelevantDiagnose for attribute RelevantDiagnosis
		[DataContract]
		public class L6TR_GTaRDfBIbT_1204_RelevantDiagnose 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Treatment_RelevantDiagnosisID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_Diagnosis_StateID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public Guid Doctor_RefID { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public Dict DiagnosisState_Name { get; set; } 
			[DataMember]
			public String DiagnosisState_Abbreviation { get; set; } 
			[DataMember]
			public DateTime Creation_Date { get; set; } 
			[DataMember]
			public DateTime DiagnosedOnDate { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name_DictID { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTaRDfBIbT_1204_Article for attribute Article
		[DataContract]
		public class L6TR_GTaRDfBIbT_1204_Article 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public string Product_Number { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_GTaRDfBIbT_1204_Array cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID(,P_L6TR_GTaRDfBIbT_1204 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_GTaRDfBIbT_1204_Array invocationResult = cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID.Invoke(connectionString,P_L6TR_GTaRDfBIbT_1204 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Atomic.Retrieval.P_L6TR_GTaRDfBIbT_1204();
parameter.TreatmentID = ...;

*/
