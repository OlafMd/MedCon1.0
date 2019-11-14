/* 
 * Generated on 26.06.2014 14:02:45
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

namespace CL3_Device.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Device_for_DeviceInstanceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Device_for_DeviceInstanceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DE_GDfDIID_1452 Execute(DbConnection Connection,DbTransaction Transaction,P_L3DE_GDfDIID_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DE_GDfDIID_1452();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Device.Atomic.Retrieval.SQL.cls_Get_Device_for_DeviceInstanceID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeviceInstanceID", Parameter.DeviceInstanceID);



			List<L3DE_GDfDIID_1452> results = new List<L3DE_GDfDIID_1452>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_DEV_Device_InstanceID","PPS_DEV_DeviceID","DeviceDisplayName","DeviceInventoryNumber","PPS_DEV_Device_Instance_OfficeLocationID","CMN_STR_Office_RefID" });
				while(reader.Read())
				{
					L3DE_GDfDIID_1452 resultItem = new L3DE_GDfDIID_1452();
					//0:Parameter PPS_DEV_Device_InstanceID of type Guid
					resultItem.PPS_DEV_Device_InstanceID = reader.GetGuid(0);
					//1:Parameter PPS_DEV_DeviceID of type Guid
					resultItem.PPS_DEV_DeviceID = reader.GetGuid(1);
					//2:Parameter DeviceDisplayName of type string
					resultItem.DeviceDisplayName = reader.GetString(2);
					//3:Parameter DeviceInventoryNumber of type string
					resultItem.DeviceInventoryNumber = reader.GetString(3);
					//4:Parameter PPS_DEV_Device_Instance_OfficeLocationID of type Guid
					resultItem.PPS_DEV_Device_Instance_OfficeLocationID = reader.GetGuid(4);
					//5:Parameter CMN_STR_Office_RefID of type Guid
					resultItem.CMN_STR_Office_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Device_for_DeviceInstanceID",ex);
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
		public static FR_L3DE_GDfDIID_1452 Invoke(string ConnectionString,P_L3DE_GDfDIID_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DE_GDfDIID_1452 Invoke(DbConnection Connection,P_L3DE_GDfDIID_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DE_GDfDIID_1452 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DE_GDfDIID_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DE_GDfDIID_1452 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DE_GDfDIID_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DE_GDfDIID_1452 functionReturn = new FR_L3DE_GDfDIID_1452();
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

				throw new Exception("Exception occured in method cls_Get_Device_for_DeviceInstanceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DE_GDfDIID_1452 : FR_Base
	{
		public L3DE_GDfDIID_1452 Result	{ get; set; }

		public FR_L3DE_GDfDIID_1452() : base() {}

		public FR_L3DE_GDfDIID_1452(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DE_GDfDIID_1452 for attribute P_L3DE_GDfDIID_1452
		[DataContract]
		public class P_L3DE_GDfDIID_1452 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeviceInstanceID { get; set; } 

		}
		#endregion
		#region SClass L3DE_GDfDIID_1452 for attribute L3DE_GDfDIID_1452
		[DataContract]
		public class L3DE_GDfDIID_1452 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_DEV_Device_InstanceID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_DeviceID { get; set; } 
			[DataMember]
			public string DeviceDisplayName { get; set; } 
			[DataMember]
			public string DeviceInventoryNumber { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_Instance_OfficeLocationID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DE_GDfDIID_1452 cls_Get_Device_for_DeviceInstanceID(,P_L3DE_GDfDIID_1452 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DE_GDfDIID_1452 invocationResult = cls_Get_Device_for_DeviceInstanceID.Invoke(connectionString,P_L3DE_GDfDIID_1452 Parameter,securityTicket);
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
var parameter = new CL3_Device.Atomic.Retrieval.P_L3DE_GDfDIID_1452();
parameter.DeviceInstanceID = ...;

*/
