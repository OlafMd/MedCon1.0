/* 
 * Generated on 10/23/2014 2:42:29 PM
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

namespace CL3_ProjectMember.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PM_GACLfPMT_1114_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PM_GACLfPMT_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PM_GACLfPMT_1114_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ProjectMember.Atomic.Retrieval.SQL.cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MemberTypeID", Parameter.MemberTypeID);



			List<L3PM_GACLfPMT_1114> results = new List<L3PM_GACLfPMT_1114>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_InvestedWorkTime_ChargingLevelID","ChangingLevel_Name_DictID" });
				while(reader.Read())
				{
					L3PM_GACLfPMT_1114 resultItem = new L3PM_GACLfPMT_1114();
					//0:Parameter CMN_BPT_InvestedWorkTime_ChargingLevelID of type Guid
					resultItem.CMN_BPT_InvestedWorkTime_ChargingLevelID = reader.GetGuid(0);
					//1:Parameter ChangingLevel_Name of type Dict
					resultItem.ChangingLevel_Name = reader.GetDictionary(1);
					resultItem.ChangingLevel_Name.SourceTable = "cmn_bpt_investedworktime_charginglevels";
					loader.Append(resultItem.ChangingLevel_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID",ex);
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
		public static FR_L3PM_GACLfPMT_1114_Array Invoke(string ConnectionString,P_L3PM_GACLfPMT_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PM_GACLfPMT_1114_Array Invoke(DbConnection Connection,P_L3PM_GACLfPMT_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PM_GACLfPMT_1114_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PM_GACLfPMT_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PM_GACLfPMT_1114_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PM_GACLfPMT_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PM_GACLfPMT_1114_Array functionReturn = new FR_L3PM_GACLfPMT_1114_Array();
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

				throw new Exception("Exception occured in method cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PM_GACLfPMT_1114_Array : FR_Base
	{
		public L3PM_GACLfPMT_1114[] Result	{ get; set; } 
		public FR_L3PM_GACLfPMT_1114_Array() : base() {}

		public FR_L3PM_GACLfPMT_1114_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PM_GACLfPMT_1114 for attribute P_L3PM_GACLfPMT_1114
		[DataContract]
		public class P_L3PM_GACLfPMT_1114 
		{
			//Standard type parameters
			[DataMember]
			public Guid MemberTypeID { get; set; } 

		}
		#endregion
		#region SClass L3PM_GACLfPMT_1114 for attribute L3PM_GACLfPMT_1114
		[DataContract]
		public class L3PM_GACLfPMT_1114 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID { get; set; } 
			[DataMember]
			public Dict ChangingLevel_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PM_GACLfPMT_1114_Array cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID(,P_L3PM_GACLfPMT_1114 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PM_GACLfPMT_1114_Array invocationResult = cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID.Invoke(connectionString,P_L3PM_GACLfPMT_1114 Parameter,securityTicket);
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
var parameter = new CL3_ProjectMember.Atomic.Retrieval.P_L3PM_GACLfPMT_1114();
parameter.MemberTypeID = ...;

*/