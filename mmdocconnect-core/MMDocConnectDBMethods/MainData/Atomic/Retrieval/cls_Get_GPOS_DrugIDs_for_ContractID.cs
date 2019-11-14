/* 
 * Generated on 10/21/15 16:50:47
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
    /// var result = cls_Get_GPOS_DrugIDs_for_ContractID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_GPOS_DrugIDs_for_ContractID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GGPOSDIDsfCID_1629_Array Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GGPOSDIDsfCID_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GGPOSDIDsfCID_1629_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_GPOS_DrugIDs_for_ContractID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ContractID", Parameter.ContractID);



			List<MD_GGPOSDIDsfCID_1629> results = new List<MD_GGPOSDIDsfCID_1629>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "GposID","DrugID","DrugName" });
				while(reader.Read())
				{
					MD_GGPOSDIDsfCID_1629 resultItem = new MD_GGPOSDIDsfCID_1629();
					//0:Parameter GposID of type Guid
					resultItem.GposID = reader.GetGuid(0);
					//1:Parameter DrugID of type Guid
					resultItem.DrugID = reader.GetGuid(1);
					//2:Parameter DrugName of type String
					resultItem.DrugName = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_GPOS_DrugIDs_for_ContractID",ex);
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
		public static FR_MD_GGPOSDIDsfCID_1629_Array Invoke(string ConnectionString,P_MD_GGPOSDIDsfCID_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSDIDsfCID_1629_Array Invoke(DbConnection Connection,P_MD_GGPOSDIDsfCID_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSDIDsfCID_1629_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GGPOSDIDsfCID_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GGPOSDIDsfCID_1629_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GGPOSDIDsfCID_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GGPOSDIDsfCID_1629_Array functionReturn = new FR_MD_GGPOSDIDsfCID_1629_Array();
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

				throw new Exception("Exception occured in method cls_Get_GPOS_DrugIDs_for_ContractID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GGPOSDIDsfCID_1629_Array : FR_Base
	{
		public MD_GGPOSDIDsfCID_1629[] Result	{ get; set; } 
		public FR_MD_GGPOSDIDsfCID_1629_Array() : base() {}

		public FR_MD_GGPOSDIDsfCID_1629_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GGPOSDIDsfCID_1629 for attribute P_MD_GGPOSDIDsfCID_1629
		[DataContract]
		public class P_MD_GGPOSDIDsfCID_1629 
		{
			//Standard type parameters
			[DataMember]
			public Guid ContractID { get; set; } 

		}
		#endregion
		#region SClass MD_GGPOSDIDsfCID_1629 for attribute MD_GGPOSDIDsfCID_1629
		[DataContract]
		public class MD_GGPOSDIDsfCID_1629 
		{
			//Standard type parameters
			[DataMember]
			public Guid GposID { get; set; } 
			[DataMember]
			public Guid DrugID { get; set; } 
			[DataMember]
			public String DrugName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GGPOSDIDsfCID_1629_Array cls_Get_GPOS_DrugIDs_for_ContractID(,P_MD_GGPOSDIDsfCID_1629 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GGPOSDIDsfCID_1629_Array invocationResult = cls_Get_GPOS_DrugIDs_for_ContractID.Invoke(connectionString,P_MD_GGPOSDIDsfCID_1629 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GGPOSDIDsfCID_1629();
parameter.ContractID = ...;

*/
