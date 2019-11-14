/* 
 * Generated on 27.01.2015 10:51:54
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

namespace CL5_MyHealthClub_EMR.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MedicationSubstance_for_PerformedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MedicationSubstance_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GMSfPAID_1329_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GMSfPAID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GMSfPAID_1329_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_MedicationSubstance_for_PerformedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);



			List<L5ME_GMSfPAID_1329_raw> results = new List<L5ME_GMSfPAID_1329_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ACT_PerformedAction_MedicationUpdateID","DosageText","MedicationUpdateComment","ISOCode","IsActiveComponent","IfSubstance_Strength","HEC_Patient_MedicationID","HEC_SUB_SubstanceID","Relevant_PatientDiagnosis_RefID","IntendedApplicationDuration_in_days","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5ME_GMSfPAID_1329_raw resultItem = new L5ME_GMSfPAID_1329_raw();
					//0:Parameter HEC_ACT_PerformedAction_MedicationUpdateID of type Guid
					resultItem.HEC_ACT_PerformedAction_MedicationUpdateID = reader.GetGuid(0);
					//1:Parameter DosageText of type String
					resultItem.DosageText = reader.GetString(1);
					//2:Parameter MedicationUpdateComment of type String
					resultItem.MedicationUpdateComment = reader.GetString(2);
					//3:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(3);
					//4:Parameter IsActiveComponent of type bool
					resultItem.IsActiveComponent = reader.GetBoolean(4);
					//5:Parameter IfSubstance_Strength of type String
					resultItem.IfSubstance_Strength = reader.GetString(5);
					//6:Parameter HEC_Patient_MedicationID of type Guid
					resultItem.HEC_Patient_MedicationID = reader.GetGuid(6);
					//7:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(7);
					//8:Parameter Relevant_PatientDiagnosis_RefID of type Guid
					resultItem.Relevant_PatientDiagnosis_RefID = reader.GetGuid(8);
					//9:Parameter IntendedApplicationDuration_in_days of type int
					resultItem.IntendedApplicationDuration_in_days = reader.GetInteger(9);
					//10:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_MedicationSubstance_for_PerformedActionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GMSfPAID_1329_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GMSfPAID_1329_Array Invoke(string ConnectionString,P_L5ME_GMSfPAID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GMSfPAID_1329_Array Invoke(DbConnection Connection,P_L5ME_GMSfPAID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GMSfPAID_1329_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GMSfPAID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GMSfPAID_1329_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GMSfPAID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GMSfPAID_1329_Array functionReturn = new FR_L5ME_GMSfPAID_1329_Array();
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

				throw new Exception("Exception occured in method cls_Get_MedicationSubstance_for_PerformedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GMSfPAID_1329_raw 
	{
		public Guid HEC_ACT_PerformedAction_MedicationUpdateID; 
		public String DosageText; 
		public String MedicationUpdateComment; 
		public String ISOCode; 
		public bool IsActiveComponent; 
		public String IfSubstance_Strength; 
		public Guid HEC_Patient_MedicationID; 
		public Guid HEC_SUB_SubstanceID; 
		public Guid Relevant_PatientDiagnosis_RefID; 
		public int IntendedApplicationDuration_in_days; 
		public string GlobalPropertyMatchingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GMSfPAID_1329[] Convert(List<L5ME_GMSfPAID_1329_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GMSfPAID_1329 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_ACT_PerformedAction_MedicationUpdateID)).ToArray()
	group el_L5ME_GMSfPAID_1329 by new 
	{ 
		el_L5ME_GMSfPAID_1329.HEC_ACT_PerformedAction_MedicationUpdateID,

	}
	into gfunct_L5ME_GMSfPAID_1329
	select new L5ME_GMSfPAID_1329
	{     
		HEC_ACT_PerformedAction_MedicationUpdateID = gfunct_L5ME_GMSfPAID_1329.Key.HEC_ACT_PerformedAction_MedicationUpdateID ,
		DosageText = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().DosageText ,
		MedicationUpdateComment = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().MedicationUpdateComment ,
		ISOCode = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().ISOCode ,
		IsActiveComponent = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().IsActiveComponent ,
		IfSubstance_Strength = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().IfSubstance_Strength ,
		HEC_Patient_MedicationID = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().HEC_Patient_MedicationID ,
		HEC_SUB_SubstanceID = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().HEC_SUB_SubstanceID ,
		Relevant_PatientDiagnosis_RefID = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().Relevant_PatientDiagnosis_RefID ,
		IntendedApplicationDuration_in_days = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().IntendedApplicationDuration_in_days ,
		GlobalPropertyMatchingID = gfunct_L5ME_GMSfPAID_1329.FirstOrDefault().GlobalPropertyMatchingID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GMSfPAID_1329_Array : FR_Base
	{
		public L5ME_GMSfPAID_1329[] Result	{ get; set; } 
		public FR_L5ME_GMSfPAID_1329_Array() : base() {}

		public FR_L5ME_GMSfPAID_1329_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GMSfPAID_1329 for attribute P_L5ME_GMSfPAID_1329
		[DataContract]
		public class P_L5ME_GMSfPAID_1329 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GMSfPAID_1329 for attribute L5ME_GMSfPAID_1329
		[DataContract]
		public class L5ME_GMSfPAID_1329 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ACT_PerformedAction_MedicationUpdateID { get; set; } 
			[DataMember]
			public String DosageText { get; set; } 
			[DataMember]
			public String MedicationUpdateComment { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public bool IsActiveComponent { get; set; } 
			[DataMember]
			public String IfSubstance_Strength { get; set; } 
			[DataMember]
			public Guid HEC_Patient_MedicationID { get; set; } 
			[DataMember]
			public Guid HEC_SUB_SubstanceID { get; set; } 
			[DataMember]
			public Guid Relevant_PatientDiagnosis_RefID { get; set; } 
			[DataMember]
			public int IntendedApplicationDuration_in_days { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GMSfPAID_1329_Array cls_Get_MedicationSubstance_for_PerformedActionID(,P_L5ME_GMSfPAID_1329 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GMSfPAID_1329_Array invocationResult = cls_Get_MedicationSubstance_for_PerformedActionID.Invoke(connectionString,P_L5ME_GMSfPAID_1329 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Retrieval.P_L5ME_GMSfPAID_1329();
parameter.PerformedActionID = ...;

*/
