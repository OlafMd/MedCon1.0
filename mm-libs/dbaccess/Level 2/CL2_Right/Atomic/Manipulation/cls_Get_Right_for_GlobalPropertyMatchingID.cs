/* 
 * Generated on 9/24/2013 10:00:17 AM
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

namespace CL2_Right.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Right_for_GlobalPropertyMatchingID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Right_for_GlobalPropertyMatchingID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2RT_GRfGPM_0955 Execute(DbConnection Connection,DbTransaction Transaction,P_L2RT_GRfGPM_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2RT_GRfGPM_0955();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Right.Atomic.Manipulation.SQL.cls_Get_Right_for_GlobalPropertyMatchingID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GlobalPropertyMatchingID", Parameter.GlobalPropertyMatchingID);



			List<L2RT_GRfGPM_0955> results = new List<L2RT_GRfGPM_0955>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_ACC_RightID","Right_Name_DictID" });
				while(reader.Read())
				{
					L2RT_GRfGPM_0955 resultItem = new L2RT_GRfGPM_0955();
					//0:Parameter TMS_PRO_ACC_RightID of type Guid
					resultItem.TMS_PRO_ACC_RightID = reader.GetGuid(0);
					//1:Parameter Right_Name of type Dict
					resultItem.Right_Name = reader.GetDictionary(1);
					resultItem.Right_Name.SourceTable = "tms_pro_acc_rights";
					loader.Append(resultItem.Right_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Right_for_GlobalPropertyMatchingID",ex);
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
		public static FR_L2RT_GRfGPM_0955 Invoke(string ConnectionString,P_L2RT_GRfGPM_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2RT_GRfGPM_0955 Invoke(DbConnection Connection,P_L2RT_GRfGPM_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2RT_GRfGPM_0955 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2RT_GRfGPM_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2RT_GRfGPM_0955 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2RT_GRfGPM_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2RT_GRfGPM_0955 functionReturn = new FR_L2RT_GRfGPM_0955();
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

				throw new Exception("Exception occured in method cls_Get_Right_for_GlobalPropertyMatchingID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2RT_GRfGPM_0955 : FR_Base
	{
		public L2RT_GRfGPM_0955 Result	{ get; set; }

		public FR_L2RT_GRfGPM_0955() : base() {}

		public FR_L2RT_GRfGPM_0955(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2RT_GRfGPM_0955 for attribute P_L2RT_GRfGPM_0955
		[DataContract]
		public class P_L2RT_GRfGPM_0955 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L2RT_GRfGPM_0955 for attribute L2RT_GRfGPM_0955
		[DataContract]
		public class L2RT_GRfGPM_0955 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ACC_RightID { get; set; } 
			[DataMember]
			public Dict Right_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2RT_GRfGPM_0955 cls_Get_Right_for_GlobalPropertyMatchingID(,P_L2RT_GRfGPM_0955 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2RT_GRfGPM_0955 invocationResult = cls_Get_Right_for_GlobalPropertyMatchingID.Invoke(connectionString,P_L2RT_GRfGPM_0955 Parameter,securityTicket);
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
var parameter = new CL2_Right.Atomic.Manipulation.P_L2RT_GRfGPM_0955();
parameter.GlobalPropertyMatchingID = ...;

*/
