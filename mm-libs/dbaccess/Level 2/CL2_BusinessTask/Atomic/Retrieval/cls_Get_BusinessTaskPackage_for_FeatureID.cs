/* 
 * Generated on 01-Dec-14 4:01:44 PM
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

namespace CL2_BusinessTask.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BusinessTaskPackage_for_FeatureID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BusinessTaskPackage_for_FeatureID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2BT_GBTPfFID_1512 Execute(DbConnection Connection,DbTransaction Transaction,P_L2BT_GBTPfFID_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2BT_GBTPfFID_1512();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_BusinessTask.Atomic.Retrieval.SQL.cls_Get_BusinessTaskPackage_for_FeatureID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FeatureID", Parameter.FeatureID);



			List<L2BT_GBTPfFID_1512> results = new List<L2BT_GBTPfFID_1512>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_BusinessTaskPackageID","Parent_RefID","Project_RefID","BTP_Name" });
				while(reader.Read())
				{
					L2BT_GBTPfFID_1512 resultItem = new L2BT_GBTPfFID_1512();
					//0:Parameter TMS_PRO_BusinessTaskPackageID of type Guid
					resultItem.TMS_PRO_BusinessTaskPackageID = reader.GetGuid(0);
					//1:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(1);
					//2:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(2);
					//3:Parameter BTP_Name of type String
					resultItem.BTP_Name = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BusinessTaskPackage_for_FeatureID",ex);
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
		public static FR_L2BT_GBTPfFID_1512 Invoke(string ConnectionString,P_L2BT_GBTPfFID_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2BT_GBTPfFID_1512 Invoke(DbConnection Connection,P_L2BT_GBTPfFID_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2BT_GBTPfFID_1512 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2BT_GBTPfFID_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2BT_GBTPfFID_1512 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2BT_GBTPfFID_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2BT_GBTPfFID_1512 functionReturn = new FR_L2BT_GBTPfFID_1512();
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

				throw new Exception("Exception occured in method cls_Get_BusinessTaskPackage_for_FeatureID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2BT_GBTPfFID_1512 : FR_Base
	{
		public L2BT_GBTPfFID_1512 Result	{ get; set; }

		public FR_L2BT_GBTPfFID_1512() : base() {}

		public FR_L2BT_GBTPfFID_1512(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2BT_GBTPfFID_1512 for attribute P_L2BT_GBTPfFID_1512
		[DataContract]
		public class P_L2BT_GBTPfFID_1512 
		{
			//Standard type parameters
			[DataMember]
			public Guid FeatureID { get; set; } 

		}
		#endregion
		#region SClass L2BT_GBTPfFID_1512 for attribute L2BT_GBTPfFID_1512
		[DataContract]
		public class L2BT_GBTPfFID_1512 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_BusinessTaskPackageID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public String BTP_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2BT_GBTPfFID_1512 cls_Get_BusinessTaskPackage_for_FeatureID(,P_L2BT_GBTPfFID_1512 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2BT_GBTPfFID_1512 invocationResult = cls_Get_BusinessTaskPackage_for_FeatureID.Invoke(connectionString,P_L2BT_GBTPfFID_1512 Parameter,securityTicket);
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
var parameter = new CL2_BusinessTask.Atomic.Retrieval.P_L2BT_GBTPfFID_1512();
parameter.FeatureID = ...;

*/
