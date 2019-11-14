/* 
 * Generated on 10/30/2014 11:52:57 AM
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

namespace CL6_DanuTask_Project.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ChargingLevels_for_ProjectMemberTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ChargingLevels_for_ProjectMemberTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_GCLfPMTID_1531_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_GCLfPMTID_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PR_GCLfPMTID_1531_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_Project.Atomic.Retrieval.SQL.cls_Get_ChargingLevels_for_ProjectMemberTypeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProjectMemberID", Parameter.ProjectMemberID);



			List<L6PR_GCLfPMTID_1531> results = new List<L6PR_GCLfPMTID_1531>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMP_PRO_ProjectMember_Type_AvailableChargingLevelsID","CMN_BPT_InvestedWorkTime_ChargingLevelID","ChangingLevel_Name_DictID" });
				while(reader.Read())
				{
					L6PR_GCLfPMTID_1531 resultItem = new L6PR_GCLfPMTID_1531();
					//0:Parameter TMP_PRO_ProjectMember_Type_AvailableChargingLevelsID of type Guid
					resultItem.TMP_PRO_ProjectMember_Type_AvailableChargingLevelsID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_InvestedWorkTime_ChargingLevelID of type Guid
					resultItem.CMN_BPT_InvestedWorkTime_ChargingLevelID = reader.GetGuid(1);
					//2:Parameter ChargingLevelName of type Dict
					resultItem.ChargingLevelName = reader.GetDictionary(2);
					resultItem.ChargingLevelName.SourceTable = "cmn_bpt_investedworktime_charginglevels";
					loader.Append(resultItem.ChargingLevelName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ChargingLevels_for_ProjectMemberTypeID",ex);
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
		public static FR_L6PR_GCLfPMTID_1531_Array Invoke(string ConnectionString,P_L6PR_GCLfPMTID_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PR_GCLfPMTID_1531_Array Invoke(DbConnection Connection,P_L6PR_GCLfPMTID_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PR_GCLfPMTID_1531_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_GCLfPMTID_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PR_GCLfPMTID_1531_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_GCLfPMTID_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_GCLfPMTID_1531_Array functionReturn = new FR_L6PR_GCLfPMTID_1531_Array();
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

				throw new Exception("Exception occured in method cls_Get_ChargingLevels_for_ProjectMemberTypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_GCLfPMTID_1531_Array : FR_Base
	{
		public L6PR_GCLfPMTID_1531[] Result	{ get; set; } 
		public FR_L6PR_GCLfPMTID_1531_Array() : base() {}

		public FR_L6PR_GCLfPMTID_1531_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_GCLfPMTID_1531 for attribute P_L6PR_GCLfPMTID_1531
		[DataContract]
		public class P_L6PR_GCLfPMTID_1531 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMemberID { get; set; } 

		}
		#endregion
		#region SClass L6PR_GCLfPMTID_1531 for attribute L6PR_GCLfPMTID_1531
		[DataContract]
		public class L6PR_GCLfPMTID_1531 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMP_PRO_ProjectMember_Type_AvailableChargingLevelsID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID { get; set; } 
			[DataMember]
			public Dict ChargingLevelName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_GCLfPMTID_1531_Array cls_Get_ChargingLevels_for_ProjectMemberTypeID(,P_L6PR_GCLfPMTID_1531 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_GCLfPMTID_1531_Array invocationResult = cls_Get_ChargingLevels_for_ProjectMemberTypeID.Invoke(connectionString,P_L6PR_GCLfPMTID_1531 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Atomic.Retrieval.P_L6PR_GCLfPMTID_1531();
parameter.ProjectMemberID = ...;

*/
