/* 
 * Generated on 2/2/2015 10:19:02 PM
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
    /// var result = cls_Get_BilledFollowupsForTenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BilledFollowupsForTenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GBFfTID_1740_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GBFfTID_1740_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Import_and_BugFixes.Atomic.Retrieval.SQL.cls_Get_BilledFollowupsForTenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5TR_GBFfTID_1740> results = new List<L5TR_GBFfTID_1740>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "External_PositionType","VorgassNumber","BIL_BillPosition_TransmitionStatusID","FollowupID","BIL_BillPositionID","IfTreatmentFollowup_FromTreatment_RefID" });
				while(reader.Read())
				{
					L5TR_GBFfTID_1740 resultItem = new L5TR_GBFfTID_1740();
					//0:Parameter External_PositionType of type String
					resultItem.External_PositionType = reader.GetString(0);
					//1:Parameter VorgassNumber of type String
					resultItem.VorgassNumber = reader.GetString(1);
					//2:Parameter BIL_BillPosition_TransmitionStatusID of type Guid
					resultItem.BIL_BillPosition_TransmitionStatusID = reader.GetGuid(2);
					//3:Parameter FollowupID of type Guid
					resultItem.FollowupID = reader.GetGuid(3);
					//4:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(4);
					//5:Parameter IfTreatmentFollowup_FromTreatment_RefID of type Guid
					resultItem.IfTreatmentFollowup_FromTreatment_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BilledFollowupsForTenantID",ex);
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
		public static FR_L5TR_GBFfTID_1740_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GBFfTID_1740_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GBFfTID_1740_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GBFfTID_1740_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GBFfTID_1740_Array functionReturn = new FR_L5TR_GBFfTID_1740_Array();
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

				throw new Exception("Exception occured in method cls_Get_BilledFollowupsForTenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GBFfTID_1740_Array : FR_Base
	{
		public L5TR_GBFfTID_1740[] Result	{ get; set; } 
		public FR_L5TR_GBFfTID_1740_Array() : base() {}

		public FR_L5TR_GBFfTID_1740_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5TR_GBFfTID_1740 for attribute L5TR_GBFfTID_1740
		[DataContract]
		public class L5TR_GBFfTID_1740 
		{
			//Standard type parameters
			[DataMember]
			public String External_PositionType { get; set; } 
			[DataMember]
			public String VorgassNumber { get; set; } 
			[DataMember]
			public Guid BIL_BillPosition_TransmitionStatusID { get; set; } 
			[DataMember]
			public Guid FollowupID { get; set; } 
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public Guid IfTreatmentFollowup_FromTreatment_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GBFfTID_1740_Array cls_Get_BilledFollowupsForTenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GBFfTID_1740_Array invocationResult = cls_Get_BilledFollowupsForTenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

