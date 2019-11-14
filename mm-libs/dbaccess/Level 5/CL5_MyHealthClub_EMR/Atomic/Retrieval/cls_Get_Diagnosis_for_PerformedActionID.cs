/* 
 * Generated on 2/20/2015 11:33:54 AM
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
    /// var result = cls_Get_Diagnosis_for_PerformedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Diagnosis_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GDfPAID_1919_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GDfPAID_1919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GDfPAID_1919_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_Diagnosis_for_PerformedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);



			List<L5ME_GDfPAID_1919_raw> results = new List<L5ME_GDfPAID_1919_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PotentialDiagnosis_Name_DictID","HEC_Patient_DiagnosisID","HEC_DIA_PotentialDiagnosisID","ICD10_Code","R_DiagnosedOnDate","R_ScheduledExpiryDate","R_IsActive","R_IsConfirmed","R_IsNegated","R_IsAssumed","R_DeactivatedOnDate","HEC_ACT_PerformedAction_DiagnosisUpdateID" });
				while(reader.Read())
				{
					L5ME_GDfPAID_1919_raw resultItem = new L5ME_GDfPAID_1919_raw();
					//0:Parameter PotentialDiagnosis_Name of type Dict
					resultItem.PotentialDiagnosis_Name = reader.GetDictionary(0);
					resultItem.PotentialDiagnosis_Name.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name);
					//1:Parameter HEC_Patient_DiagnosisID of type Guid
					resultItem.HEC_Patient_DiagnosisID = reader.GetGuid(1);
					//2:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(2);
					//3:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(3);
					//4:Parameter R_DiagnosedOnDate of type DateTime
					resultItem.R_DiagnosedOnDate = reader.GetDate(4);
					//5:Parameter R_ScheduledExpiryDate of type DateTime
					resultItem.R_ScheduledExpiryDate = reader.GetDate(5);
					//6:Parameter R_IsActive of type Boolean
					resultItem.R_IsActive = reader.GetBoolean(6);
					//7:Parameter R_IsConfirmed of type Boolean
					resultItem.R_IsConfirmed = reader.GetBoolean(7);
					//8:Parameter R_IsNegated of type Boolean
					resultItem.R_IsNegated = reader.GetBoolean(8);
					//9:Parameter R_IsAssumed of type Boolean
					resultItem.R_IsAssumed = reader.GetBoolean(9);
					//10:Parameter R_DeactivatedOnDate of type DateTime
					resultItem.R_DeactivatedOnDate = reader.GetDate(10);
					//11:Parameter HEC_ACT_PerformedAction_DiagnosisUpdateID of type Guid
					resultItem.HEC_ACT_PerformedAction_DiagnosisUpdateID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Diagnosis_for_PerformedActionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GDfPAID_1919_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GDfPAID_1919_Array Invoke(string ConnectionString,P_L5ME_GDfPAID_1919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GDfPAID_1919_Array Invoke(DbConnection Connection,P_L5ME_GDfPAID_1919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GDfPAID_1919_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GDfPAID_1919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GDfPAID_1919_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GDfPAID_1919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GDfPAID_1919_Array functionReturn = new FR_L5ME_GDfPAID_1919_Array();
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

				throw new Exception("Exception occured in method cls_Get_Diagnosis_for_PerformedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GDfPAID_1919_raw 
	{
		public Dict PotentialDiagnosis_Name; 
		public Guid HEC_Patient_DiagnosisID; 
		public Guid HEC_DIA_PotentialDiagnosisID; 
		public String ICD10_Code; 
		public DateTime R_DiagnosedOnDate; 
		public DateTime R_ScheduledExpiryDate; 
		public Boolean R_IsActive; 
		public Boolean R_IsConfirmed; 
		public Boolean R_IsNegated; 
		public Boolean R_IsAssumed; 
		public DateTime R_DeactivatedOnDate; 
		public Guid HEC_ACT_PerformedAction_DiagnosisUpdateID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GDfPAID_1919[] Convert(List<L5ME_GDfPAID_1919_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GDfPAID_1919 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_DiagnosisID)).ToArray()
	group el_L5ME_GDfPAID_1919 by new 
	{ 
		el_L5ME_GDfPAID_1919.HEC_Patient_DiagnosisID,

	}
	into gfunct_L5ME_GDfPAID_1919
	select new L5ME_GDfPAID_1919
	{     
		PotentialDiagnosis_Name = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().PotentialDiagnosis_Name ,
		HEC_Patient_DiagnosisID = gfunct_L5ME_GDfPAID_1919.Key.HEC_Patient_DiagnosisID ,
		HEC_DIA_PotentialDiagnosisID = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().HEC_DIA_PotentialDiagnosisID ,
		ICD10_Code = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().ICD10_Code ,
		R_DiagnosedOnDate = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().R_DiagnosedOnDate ,
		R_ScheduledExpiryDate = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().R_ScheduledExpiryDate ,
		R_IsActive = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().R_IsActive ,
		R_IsConfirmed = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().R_IsConfirmed ,
		R_IsNegated = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().R_IsNegated ,
		R_IsAssumed = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().R_IsAssumed ,
		R_DeactivatedOnDate = gfunct_L5ME_GDfPAID_1919.FirstOrDefault().R_DeactivatedOnDate ,

		Updates = 
		(
			from el_Updates in gfunct_L5ME_GDfPAID_1919.Where(element => !EqualsDefaultValue(element.HEC_ACT_PerformedAction_DiagnosisUpdateID)).ToArray()
			group el_Updates by new 
			{ 
				el_Updates.HEC_ACT_PerformedAction_DiagnosisUpdateID,

			}
			into gfunct_Updates
			select new L5ME_GDfPAID_1919_DiagnosisUpdate
			{     
				HEC_ACT_PerformedAction_DiagnosisUpdateID = gfunct_Updates.Key.HEC_ACT_PerformedAction_DiagnosisUpdateID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GDfPAID_1919_Array : FR_Base
	{
		public L5ME_GDfPAID_1919[] Result	{ get; set; } 
		public FR_L5ME_GDfPAID_1919_Array() : base() {}

		public FR_L5ME_GDfPAID_1919_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GDfPAID_1919 for attribute P_L5ME_GDfPAID_1919
		[DataContract]
		public class P_L5ME_GDfPAID_1919 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GDfPAID_1919 for attribute L5ME_GDfPAID_1919
		[DataContract]
		public class L5ME_GDfPAID_1919 
		{
			[DataMember]
			public L5ME_GDfPAID_1919_DiagnosisUpdate[] Updates { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict PotentialDiagnosis_Name { get; set; } 
			[DataMember]
			public Guid HEC_Patient_DiagnosisID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public DateTime R_DiagnosedOnDate { get; set; } 
			[DataMember]
			public DateTime R_ScheduledExpiryDate { get; set; } 
			[DataMember]
			public Boolean R_IsActive { get; set; } 
			[DataMember]
			public Boolean R_IsConfirmed { get; set; } 
			[DataMember]
			public Boolean R_IsNegated { get; set; } 
			[DataMember]
			public Boolean R_IsAssumed { get; set; } 
			[DataMember]
			public DateTime R_DeactivatedOnDate { get; set; } 

		}
		#endregion
		#region SClass L5ME_GDfPAID_1919_DiagnosisUpdate for attribute Updates
		[DataContract]
		public class L5ME_GDfPAID_1919_DiagnosisUpdate 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ACT_PerformedAction_DiagnosisUpdateID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GDfPAID_1919_Array cls_Get_Diagnosis_for_PerformedActionID(,P_L5ME_GDfPAID_1919 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GDfPAID_1919_Array invocationResult = cls_Get_Diagnosis_for_PerformedActionID.Invoke(connectionString,P_L5ME_GDfPAID_1919 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Retrieval.P_L5ME_GDfPAID_1919();
parameter.PerformedActionID = ...;

*/
