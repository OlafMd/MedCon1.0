/* 
 * Generated on 2/18/2014 10:47:04 AM
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
    /// var result = cls_Get_Treatment_and_RelevantDiagnosis_for_TreatmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatment_and_RelevantDiagnosis_for_TreatmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TR_GTaRDfT_1156 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GTaRDfT_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6TR_GTaRDfT_1156();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Treatments.Atomic.Retrieval.SQL.cls_Get_Treatment_and_RelevantDiagnosis_for_TreatmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentID", Parameter.TreatmentID);



			List<L6TR_GTaRDfT_1156_raw> results = new List<L6TR_GTaRDfT_1156_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","TreatmentPractice_RefID","IsTreatmentPerformed","IfTreatmentPerformed_ByDoctor_RefID","IfTreatmentPerformed_Date","IsTreatmentFollowup","IfTreatmentFollowup_FromTreatment_RefID","IsScheduled","IfSheduled_Date","IsTreatmentBilled","IfTreatmentBilled_Date","Treatment_Comment","IsTreatmentOfLeftEye","IsTreatmentOfRightEye","HEC_Patient_Treatment_RelevantDiagnosisID","HEC_DIA_Diagnosis_StateID","HEC_DIA_Diagnosis_LocalizationID","HEC_DIA_PotentialDiagnosisID","Doctor_RefID","DiagnosisLocalization_Name_DictID","ICD10_Code","DiagnosisState_Name_DictID","DiagnosisState_Abbreviation","DoctorFirstName","DoctorLastName","Creation_Date","DiagnosedOnDate","PotentialDiagnosis_Name_DictID","CMN_PRO_ProductID","Product_Number","Quantity","Product_Name_DictID","TransmitionCode" });
				while(reader.Read())
				{
					L6TR_GTaRDfT_1156_raw resultItem = new L6TR_GTaRDfT_1156_raw();
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
					//16:Parameter HEC_DIA_Diagnosis_LocalizationID of type Guid
					resultItem.HEC_DIA_Diagnosis_LocalizationID = reader.GetGuid(16);
					//17:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(17);
					//18:Parameter Doctor_RefID of type Guid
					resultItem.Doctor_RefID = reader.GetGuid(18);
					//19:Parameter DiagnosisLocalization_Name of type Dict
					resultItem.DiagnosisLocalization_Name = reader.GetDictionary(19);
					resultItem.DiagnosisLocalization_Name.SourceTable = "hec_dia_diagnosis_localizations";
					loader.Append(resultItem.DiagnosisLocalization_Name);
					//20:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(20);
					//21:Parameter DiagnosisState_Name of type Dict
					resultItem.DiagnosisState_Name = reader.GetDictionary(21);
					resultItem.DiagnosisState_Name.SourceTable = "hec_dia_diagnosis_states";
					loader.Append(resultItem.DiagnosisState_Name);
					//22:Parameter DiagnosisState_Abbreviation of type String
					resultItem.DiagnosisState_Abbreviation = reader.GetString(22);
					//23:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(23);
					//24:Parameter DoctorLastName of type String
					resultItem.DoctorLastName = reader.GetString(24);
					//25:Parameter Creation_Date of type DateTime
					resultItem.Creation_Date = reader.GetDate(25);
					//26:Parameter DiagnosedOnDate of type DateTime
					resultItem.DiagnosedOnDate = reader.GetDate(26);
					//27:Parameter PotentialDiagnosis_Name_DictID of type Dict
					resultItem.PotentialDiagnosis_Name_DictID = reader.GetDictionary(27);
					resultItem.PotentialDiagnosis_Name_DictID.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name_DictID);
					//28:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(28);
					//29:Parameter Product_Number of type string
					resultItem.Product_Number = reader.GetString(29);
					//30:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(30);
					//31:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(31);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//32:Parameter TransmitionCode of type int
					resultItem.TransmitionCode = reader.GetInteger(32);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Treatment_and_RelevantDiagnosis_for_TreatmentID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6TR_GTaRDfT_1156_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_GTaRDfT_1156 Invoke(string ConnectionString,P_L6TR_GTaRDfT_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GTaRDfT_1156 Invoke(DbConnection Connection,P_L6TR_GTaRDfT_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GTaRDfT_1156 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GTaRDfT_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GTaRDfT_1156 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GTaRDfT_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GTaRDfT_1156 functionReturn = new FR_L6TR_GTaRDfT_1156();
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

				throw new Exception("Exception occured in method cls_Get_Treatment_and_RelevantDiagnosis_for_TreatmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6TR_GTaRDfT_1156_raw 
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
		public Guid HEC_DIA_Diagnosis_LocalizationID; 
		public Guid HEC_DIA_PotentialDiagnosisID; 
		public Guid Doctor_RefID; 
		public Dict DiagnosisLocalization_Name; 
		public String ICD10_Code; 
		public Dict DiagnosisState_Name; 
		public String DiagnosisState_Abbreviation; 
		public String DoctorFirstName; 
		public String DoctorLastName; 
		public DateTime Creation_Date; 
		public DateTime DiagnosedOnDate; 
		public Dict PotentialDiagnosis_Name_DictID; 
		public Guid CMN_PRO_ProductID; 
		public string Product_Number; 
		public double Quantity; 
		public Dict Product_Name; 
		public int TransmitionCode; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6TR_GTaRDfT_1156[] Convert(List<L6TR_GTaRDfT_1156_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6TR_GTaRDfT_1156 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_L6TR_GTaRDfT_1156 by new 
	{ 
		el_L6TR_GTaRDfT_1156.HEC_Patient_TreatmentID,

	}
	into gfunct_L6TR_GTaRDfT_1156
	select new L6TR_GTaRDfT_1156
	{     
		HEC_Patient_TreatmentID = gfunct_L6TR_GTaRDfT_1156.Key.HEC_Patient_TreatmentID ,
		TreatmentPractice_RefID = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().TreatmentPractice_RefID ,
		IsTreatmentPerformed = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IsTreatmentPerformed ,
		IfTreatmentPerformed_ByDoctor_RefID = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IfTreatmentPerformed_ByDoctor_RefID ,
		IfTreatmentPerformed_Date = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IfTreatmentPerformed_Date ,
		IsTreatmentFollowup = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IsTreatmentFollowup ,
		IfTreatmentFollowup_FromTreatment_RefID = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IfTreatmentFollowup_FromTreatment_RefID ,
		IsScheduled = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IsScheduled ,
		IfSheduled_Date = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IfSheduled_Date ,
		IsTreatmentBilled = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IsTreatmentBilled ,
		IfTreatmentBilled_Date = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IfTreatmentBilled_Date ,
		Treatment_Comment = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().Treatment_Comment ,
		IsTreatmentOfLeftEye = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IsTreatmentOfLeftEye ,
		IsTreatmentOfRightEye = gfunct_L6TR_GTaRDfT_1156.FirstOrDefault().IsTreatmentOfRightEye ,

		RelevantDiagnosis = 
		(
			from el_RelevantDiagnosis in gfunct_L6TR_GTaRDfT_1156.Where(element => !EqualsDefaultValue(element.HEC_Patient_Treatment_RelevantDiagnosisID)).ToArray()
			group el_RelevantDiagnosis by new 
			{ 
				el_RelevantDiagnosis.HEC_Patient_Treatment_RelevantDiagnosisID,

			}
			into gfunct_RelevantDiagnosis
			select new L6TR_GTaRDfT_1156a
			{     
				HEC_Patient_Treatment_RelevantDiagnosisID = gfunct_RelevantDiagnosis.Key.HEC_Patient_Treatment_RelevantDiagnosisID ,
				HEC_DIA_Diagnosis_StateID = gfunct_RelevantDiagnosis.FirstOrDefault().HEC_DIA_Diagnosis_StateID ,
				HEC_DIA_Diagnosis_LocalizationID = gfunct_RelevantDiagnosis.FirstOrDefault().HEC_DIA_Diagnosis_LocalizationID ,
				HEC_DIA_PotentialDiagnosisID = gfunct_RelevantDiagnosis.FirstOrDefault().HEC_DIA_PotentialDiagnosisID ,
				Doctor_RefID = gfunct_RelevantDiagnosis.FirstOrDefault().Doctor_RefID ,
				DiagnosisLocalization_Name = gfunct_RelevantDiagnosis.FirstOrDefault().DiagnosisLocalization_Name ,
				ICD10_Code = gfunct_RelevantDiagnosis.FirstOrDefault().ICD10_Code ,
				DiagnosisState_Name = gfunct_RelevantDiagnosis.FirstOrDefault().DiagnosisState_Name ,
				DiagnosisState_Abbreviation = gfunct_RelevantDiagnosis.FirstOrDefault().DiagnosisState_Abbreviation ,
				DoctorFirstName = gfunct_RelevantDiagnosis.FirstOrDefault().DoctorFirstName ,
				DoctorLastName = gfunct_RelevantDiagnosis.FirstOrDefault().DoctorLastName ,
				Creation_Date = gfunct_RelevantDiagnosis.FirstOrDefault().Creation_Date ,
				DiagnosedOnDate = gfunct_RelevantDiagnosis.FirstOrDefault().DiagnosedOnDate ,
				PotentialDiagnosis_Name_DictID = gfunct_RelevantDiagnosis.FirstOrDefault().PotentialDiagnosis_Name_DictID ,

			}
		).ToArray(),
		Article = 
		(
			from el_Article in gfunct_L6TR_GTaRDfT_1156.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
			group el_Article by new 
			{ 
				el_Article.CMN_PRO_ProductID,

			}
			into gfunct_Article
			select new L6TR_GTaRDfT_1156b
			{     
				CMN_PRO_ProductID = gfunct_Article.Key.CMN_PRO_ProductID ,
				Product_Number = gfunct_Article.FirstOrDefault().Product_Number ,
				Quantity = gfunct_Article.FirstOrDefault().Quantity ,
				Product_Name = gfunct_Article.FirstOrDefault().Product_Name ,

			}
		).ToArray(),
		PerformedStatus = 
		(
			from el_PerformedStatus in gfunct_L6TR_GTaRDfT_1156.ToArray()
			select new L6TR_GTaRDfT_1156c
			{     
				TransmitionCode = el_PerformedStatus.TransmitionCode,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_GTaRDfT_1156 : FR_Base
	{
		public L6TR_GTaRDfT_1156 Result	{ get; set; }

		public FR_L6TR_GTaRDfT_1156() : base() {}

		public FR_L6TR_GTaRDfT_1156(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GTaRDfT_1156 for attribute P_L6TR_GTaRDfT_1156
		[DataContract]
		public class P_L6TR_GTaRDfT_1156 
		{
			//Standard type parameters
			[DataMember]
			public Guid TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTaRDfT_1156 for attribute L6TR_GTaRDfT_1156
		[DataContract]
		public class L6TR_GTaRDfT_1156 
		{
			[DataMember]
			public L6TR_GTaRDfT_1156a[] RelevantDiagnosis { get; set; }
			[DataMember]
			public L6TR_GTaRDfT_1156b[] Article { get; set; }
			[DataMember]
			public L6TR_GTaRDfT_1156c PerformedStatus { get; set; }

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
		#region SClass L6TR_GTaRDfT_1156a for attribute RelevantDiagnosis
		[DataContract]
		public class L6TR_GTaRDfT_1156a 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Treatment_RelevantDiagnosisID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_Diagnosis_StateID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_Diagnosis_LocalizationID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public Guid Doctor_RefID { get; set; } 
			[DataMember]
			public Dict DiagnosisLocalization_Name { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public Dict DiagnosisState_Name { get; set; } 
			[DataMember]
			public String DiagnosisState_Abbreviation { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 
			[DataMember]
			public DateTime Creation_Date { get; set; } 
			[DataMember]
			public DateTime DiagnosedOnDate { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name_DictID { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTaRDfT_1156b for attribute Article
		[DataContract]
		public class L6TR_GTaRDfT_1156b 
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
		#region SClass L6TR_GTaRDfT_1156c for attribute PerformedStatus
		[DataContract]
		public class L6TR_GTaRDfT_1156c 
		{
			//Standard type parameters
			[DataMember]
			public int TransmitionCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_GTaRDfT_1156 cls_Get_Treatment_and_RelevantDiagnosis_for_TreatmentID(,P_L6TR_GTaRDfT_1156 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_GTaRDfT_1156 invocationResult = cls_Get_Treatment_and_RelevantDiagnosis_for_TreatmentID.Invoke(connectionString,P_L6TR_GTaRDfT_1156 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Atomic.Retrieval.P_L6TR_GTaRDfT_1156();
parameter.TreatmentID = ...;

*/
