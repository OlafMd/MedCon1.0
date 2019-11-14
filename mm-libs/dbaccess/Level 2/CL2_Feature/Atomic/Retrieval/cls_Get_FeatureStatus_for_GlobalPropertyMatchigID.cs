/* 
 * Generated on 9/24/2013 2:06:53 PM
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

namespace CL2_Feature.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FeatureStatus_for_GlobalPropertyMatchigID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FeatureStatus_for_GlobalPropertyMatchigID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2FE_GFSfGPM_1405 Execute(DbConnection Connection,DbTransaction Transaction,P_L2FE_GFSfGPM_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2FE_GFSfGPM_1405();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Feature.Atomic.Retrieval.SQL.cls_Get_FeatureStatus_for_GlobalPropertyMatchigID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GlobalPropertyMatchingID", Parameter.GlobalPropertyMatchingID);



			List<L2FE_GFSfGPM_1405> results = new List<L2FE_GFSfGPM_1405>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_Feature_StatusID","Label_DictID","IsPersistent" });
				while(reader.Read())
				{
					L2FE_GFSfGPM_1405 resultItem = new L2FE_GFSfGPM_1405();
					//0:Parameter TMS_PRO_Feature_StatusID of type Guid
					resultItem.TMS_PRO_Feature_StatusID = reader.GetGuid(0);
					//1:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(1);
					resultItem.Label.SourceTable = "tms_pro_feature_statuses";
					loader.Append(resultItem.Label);
					//2:Parameter IsPersistent of type bool
					resultItem.IsPersistent = reader.GetBoolean(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_FeatureStatus_for_GlobalPropertyMatchigID",ex);
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
		public static FR_L2FE_GFSfGPM_1405 Invoke(string ConnectionString,P_L2FE_GFSfGPM_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2FE_GFSfGPM_1405 Invoke(DbConnection Connection,P_L2FE_GFSfGPM_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2FE_GFSfGPM_1405 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2FE_GFSfGPM_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2FE_GFSfGPM_1405 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2FE_GFSfGPM_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2FE_GFSfGPM_1405 functionReturn = new FR_L2FE_GFSfGPM_1405();
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

				throw new Exception("Exception occured in method cls_Get_FeatureStatus_for_GlobalPropertyMatchigID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2FE_GFSfGPM_1405 : FR_Base
	{
		public L2FE_GFSfGPM_1405 Result	{ get; set; }

		public FR_L2FE_GFSfGPM_1405() : base() {}

		public FR_L2FE_GFSfGPM_1405(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2FE_GFSfGPM_1405 for attribute P_L2FE_GFSfGPM_1405
		[DataContract]
		public class P_L2FE_GFSfGPM_1405 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L2FE_GFSfGPM_1405 for attribute L2FE_GFSfGPM_1405
		[DataContract]
		public class L2FE_GFSfGPM_1405 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_Feature_StatusID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public bool IsPersistent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2FE_GFSfGPM_1405 cls_Get_FeatureStatus_for_GlobalPropertyMatchigID(,P_L2FE_GFSfGPM_1405 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2FE_GFSfGPM_1405 invocationResult = cls_Get_FeatureStatus_for_GlobalPropertyMatchigID.Invoke(connectionString,P_L2FE_GFSfGPM_1405 Parameter,securityTicket);
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
var parameter = new CL2_Feature.Atomic.Retrieval.P_L2FE_GFSfGPM_1405();
parameter.GlobalPropertyMatchingID = ...;

*/
