/* 
 * Generated on 10/21/15 15:50:04
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

namespace MMDocConnectDBMethods.MainData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_GPOS_BaseData_for_GPOSID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_GPOS_BaseData_for_GPOSID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GGPOSBDfGPOSID_1544 Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GGPOSBDfGPOSID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GGPOSBDfGPOSID_1544();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_GPOS_BaseData_for_GPOSID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GposID", Parameter.GposID);



			List<MD_GGPOSBDfGPOSID_1544> results = new List<MD_GGPOSBDfGPOSID_1544>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "GposID","GposNumber","GposName","GposType","FeeValue","FromInjection","ManagementFeeValue","WaiveWithOrder" });
				while(reader.Read())
				{
					MD_GGPOSBDfGPOSID_1544 resultItem = new MD_GGPOSBDfGPOSID_1544();
					//0:Parameter GposID of type Guid
					resultItem.GposID = reader.GetGuid(0);
					//1:Parameter GposNumber of type String
					resultItem.GposNumber = reader.GetString(1);
					//2:Parameter GposName of type String
					resultItem.GposName = reader.GetString(2);
					//3:Parameter GposType of type String
					resultItem.GposType = reader.GetString(3);
					//4:Parameter FeeValue of type Double
					resultItem.FeeValue = reader.GetDouble(4);
					//5:Parameter FromInjection of type int
					resultItem.FromInjection = reader.GetInteger(5);
					//6:Parameter ManagementFeeValue of type String
					resultItem.ManagementFeeValue = reader.GetString(6);
					//7:Parameter WaiveWithOrder of type Boolean
					resultItem.WaiveWithOrder = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_GPOS_BaseData_for_GPOSID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_MD_GGPOSBDfGPOSID_1544 Invoke(string ConnectionString,P_MD_GGPOSBDfGPOSID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSBDfGPOSID_1544 Invoke(DbConnection Connection,P_MD_GGPOSBDfGPOSID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSBDfGPOSID_1544 Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GGPOSBDfGPOSID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GGPOSBDfGPOSID_1544 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GGPOSBDfGPOSID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GGPOSBDfGPOSID_1544 functionReturn = new FR_MD_GGPOSBDfGPOSID_1544();
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

				throw new Exception("Exception occured in method cls_Get_GPOS_BaseData_for_GPOSID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GGPOSBDfGPOSID_1544 : FR_Base
	{
		public MD_GGPOSBDfGPOSID_1544 Result	{ get; set; }

		public FR_MD_GGPOSBDfGPOSID_1544() : base() {}

		public FR_MD_GGPOSBDfGPOSID_1544(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GGPOSBDfGPOSID_1544 for attribute P_MD_GGPOSBDfGPOSID_1544
		[DataContract]
		public class P_MD_GGPOSBDfGPOSID_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid GposID { get; set; } 

		}
		#endregion
		#region SClass MD_GGPOSBDfGPOSID_1544 for attribute MD_GGPOSBDfGPOSID_1544
		[DataContract]
		public class MD_GGPOSBDfGPOSID_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid GposID { get; set; } 
			[DataMember]
			public String GposNumber { get; set; } 
			[DataMember]
			public String GposName { get; set; } 
			[DataMember]
			public String GposType { get; set; } 
			[DataMember]
			public Double FeeValue { get; set; } 
			[DataMember]
			public int FromInjection { get; set; } 
			[DataMember]
			public String ManagementFeeValue { get; set; } 
			[DataMember]
			public Boolean WaiveWithOrder { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GGPOSBDfGPOSID_1544 cls_Get_GPOS_BaseData_for_GPOSID(,P_MD_GGPOSBDfGPOSID_1544 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GGPOSBDfGPOSID_1544 invocationResult = cls_Get_GPOS_BaseData_for_GPOSID.Invoke(connectionString,P_MD_GGPOSBDfGPOSID_1544 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GGPOSBDfGPOSID_1544();
parameter.GposID = ...;

*/
