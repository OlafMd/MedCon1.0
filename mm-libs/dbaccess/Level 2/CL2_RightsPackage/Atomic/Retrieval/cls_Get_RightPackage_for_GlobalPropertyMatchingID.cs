/* 
 * Generated on 9/23/2013 11:59:13 AM
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

namespace CL2_RightsPackage.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RightPackage_for_GlobalPropertyMatchingID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RightPackage_for_GlobalPropertyMatchingID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2RP_GRPfGPM_1150 Execute(DbConnection Connection,DbTransaction Transaction,P_L2RP_GRPfGPM_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2RP_GRPfGPM_1150();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_RightsPackage.Atomic.Retrieval.SQL.cls_Get_RightPackage_for_GlobalPropertyMatchingID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GlobalPropertyMatchingID", Parameter.GlobalPropertyMatchingID);



			List<L2RP_GRPfGPM_1150> results = new List<L2RP_GRPfGPM_1150>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_ACC_RightsPackageID","Name_DictID","Description_DictID","HierarchyLevel","Creation_Timestamp" });
				while(reader.Read())
				{
					L2RP_GRPfGPM_1150 resultItem = new L2RP_GRPfGPM_1150();
					//0:Parameter TMS_PRO_ACC_RightsPackageID of type Guid
					resultItem.TMS_PRO_ACC_RightsPackageID = reader.GetGuid(0);
					//1:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(1);
					resultItem.Name.SourceTable = "tms_pro_acc_rightspackages";
					loader.Append(resultItem.Name);
					//2:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(2);
					resultItem.Description.SourceTable = "tms_pro_acc_rightspackages";
					loader.Append(resultItem.Description);
					//3:Parameter HierarchyLevel of type String
					resultItem.HierarchyLevel = reader.GetString(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RightPackage_for_GlobalPropertyMatchingID",ex);
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
		public static FR_L2RP_GRPfGPM_1150 Invoke(string ConnectionString,P_L2RP_GRPfGPM_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2RP_GRPfGPM_1150 Invoke(DbConnection Connection,P_L2RP_GRPfGPM_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2RP_GRPfGPM_1150 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2RP_GRPfGPM_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2RP_GRPfGPM_1150 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2RP_GRPfGPM_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2RP_GRPfGPM_1150 functionReturn = new FR_L2RP_GRPfGPM_1150();
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

				throw new Exception("Exception occured in method cls_Get_RightPackage_for_GlobalPropertyMatchingID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2RP_GRPfGPM_1150 : FR_Base
	{
		public L2RP_GRPfGPM_1150 Result	{ get; set; }

		public FR_L2RP_GRPfGPM_1150() : base() {}

		public FR_L2RP_GRPfGPM_1150(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2RP_GRPfGPM_1150 for attribute P_L2RP_GRPfGPM_1150
		[DataContract]
		public class P_L2RP_GRPfGPM_1150 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L2RP_GRPfGPM_1150 for attribute L2RP_GRPfGPM_1150
		[DataContract]
		public class L2RP_GRPfGPM_1150 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ACC_RightsPackageID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public String HierarchyLevel { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2RP_GRPfGPM_1150 cls_Get_RightPackage_for_GlobalPropertyMatchingID(,P_L2RP_GRPfGPM_1150 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2RP_GRPfGPM_1150 invocationResult = cls_Get_RightPackage_for_GlobalPropertyMatchingID.Invoke(connectionString,P_L2RP_GRPfGPM_1150 Parameter,securityTicket);
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
var parameter = new CL2_RightsPackage.Atomic.Retrieval.P_L2RP_GRPfGPM_1150();
parameter.GlobalPropertyMatchingID = ...;

*/
