/* 
 * Generated on 10/27/15 16:11:29
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GGPOSDfDIDaDID_1033_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GGPOSDfDIDaDID_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GGPOSDfDIDaDID_1033_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnoseID", Parameter.DiagnoseID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DrugID", Parameter.DrugID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ContractID", Parameter.ContractID);



			List<CAS_GGPOSDfDIDaDID_1033> results = new List<CAS_GGPOSDfDIDaDID_1033>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "injection_from","gpos_code","gpos_id","gpos_price","gpos_type" });
				while(reader.Read())
				{
					CAS_GGPOSDfDIDaDID_1033 resultItem = new CAS_GGPOSDfDIDaDID_1033();
					//0:Parameter injection_from of type int
					resultItem.injection_from = reader.GetInteger(0);
					//1:Parameter gpos_code of type String
					resultItem.gpos_code = reader.GetString(1);
					//2:Parameter gpos_id of type Guid
					resultItem.gpos_id = reader.GetGuid(2);
					//3:Parameter gpos_price of type Double
					resultItem.gpos_price = reader.GetDouble(3);
					//4:Parameter gpos_type of type String
					resultItem.gpos_type = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID",ex);
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
		public static FR_CAS_GGPOSDfDIDaDID_1033_Array Invoke(string ConnectionString,P_CAS_GGPOSDfDIDaDID_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GGPOSDfDIDaDID_1033_Array Invoke(DbConnection Connection,P_CAS_GGPOSDfDIDaDID_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GGPOSDfDIDaDID_1033_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GGPOSDfDIDaDID_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GGPOSDfDIDaDID_1033_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GGPOSDfDIDaDID_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GGPOSDfDIDaDID_1033_Array functionReturn = new FR_CAS_GGPOSDfDIDaDID_1033_Array();
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

				throw new Exception("Exception occured in method cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GGPOSDfDIDaDID_1033_Array : FR_Base
	{
		public CAS_GGPOSDfDIDaDID_1033[] Result	{ get; set; } 
		public FR_CAS_GGPOSDfDIDaDID_1033_Array() : base() {}

		public FR_CAS_GGPOSDfDIDaDID_1033_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GGPOSDfDIDaDID_1033 for attribute P_CAS_GGPOSDfDIDaDID_1033
		[DataContract]
		public class P_CAS_GGPOSDfDIDaDID_1033 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public Guid DrugID { get; set; } 
			[DataMember]
			public Guid ContractID { get; set; } 

		}
		#endregion
		#region SClass CAS_GGPOSDfDIDaDID_1033 for attribute CAS_GGPOSDfDIDaDID_1033
		[DataContract]
		public class CAS_GGPOSDfDIDaDID_1033 
		{
			//Standard type parameters
			[DataMember]
			public int injection_from { get; set; } 
			[DataMember]
			public String gpos_code { get; set; } 
			[DataMember]
			public Guid gpos_id { get; set; } 
			[DataMember]
			public Double gpos_price { get; set; } 
			[DataMember]
			public String gpos_type { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GGPOSDfDIDaDID_1033_Array cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID(,P_CAS_GGPOSDfDIDaDID_1033 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GGPOSDfDIDaDID_1033_Array invocationResult = cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID.Invoke(connectionString,P_CAS_GGPOSDfDIDaDID_1033 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GGPOSDfDIDaDID_1033();
parameter.DiagnoseID = ...;
parameter.DrugID = ...;
parameter.ContractID = ...;

*/
