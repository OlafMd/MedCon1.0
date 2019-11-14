/* 
 * Generated on 2/2/2015 2:44:14 PM
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

namespace CL5_Lucentis_Import_and_BugFixes.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllData_in_2015_toDelete.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllData_in_2015_toDelete
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IB_GADD_1440_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IB_GADD_1440_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Import_and_BugFixes.Atomic.Retrieval.SQL.cls_Get_AllData_in_2015_toDelete.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5IB_GADD_1440> results = new List<L5IB_GADD_1440>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BIL_BillPositionID","VorgangsNummer","BIL_BillPosition_TransmitionStatusID","BIL_BillHeaderID","BillNumber","AssignmentID","HEC_Patient_TreatmentID","IsTreatmentFollowup","OriginalTreatmentID" });
				while(reader.Read())
				{
					L5IB_GADD_1440 resultItem = new L5IB_GADD_1440();
					//0:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(0);
					//1:Parameter VorgangsNummer of type string
					resultItem.VorgangsNummer = reader.GetString(1);
					//2:Parameter BIL_BillPosition_TransmitionStatusID of type Guid
					resultItem.BIL_BillPosition_TransmitionStatusID = reader.GetGuid(2);
					//3:Parameter BIL_BillHeaderID of type Guid
					resultItem.BIL_BillHeaderID = reader.GetGuid(3);
					//4:Parameter BillNumber of type int
					resultItem.BillNumber = reader.GetInteger(4);
					//5:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(5);
					//6:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(6);
					//7:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(7);
					//8:Parameter OriginalTreatmentID of type Guid
					resultItem.OriginalTreatmentID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllData_in_2015_toDelete",ex);
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
		public static FR_L5IB_GADD_1440_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IB_GADD_1440_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IB_GADD_1440_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IB_GADD_1440_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IB_GADD_1440_Array functionReturn = new FR_L5IB_GADD_1440_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllData_in_2015_toDelete",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IB_GADD_1440_Array : FR_Base
	{
		public L5IB_GADD_1440[] Result	{ get; set; } 
		public FR_L5IB_GADD_1440_Array() : base() {}

		public FR_L5IB_GADD_1440_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5IB_GADD_1440 for attribute L5IB_GADD_1440
		[DataContract]
		public class L5IB_GADD_1440 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public string VorgangsNummer { get; set; } 
			[DataMember]
			public Guid BIL_BillPosition_TransmitionStatusID { get; set; } 
			[DataMember]
			public Guid BIL_BillHeaderID { get; set; } 
			[DataMember]
			public int BillNumber { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public Guid OriginalTreatmentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IB_GADD_1440_Array cls_Get_AllData_in_2015_toDelete(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IB_GADD_1440_Array invocationResult = cls_Get_AllData_in_2015_toDelete.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

