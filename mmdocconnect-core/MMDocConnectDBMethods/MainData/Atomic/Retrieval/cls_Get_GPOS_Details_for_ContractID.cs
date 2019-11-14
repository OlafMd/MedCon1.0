/* 
 * Generated on 10/22/15 18:09:01
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
    /// var result = cls_Get_GPOS_Details_for_ContractID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_GPOS_Details_for_ContractID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GGPOSDfCID_1616_Array Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GGPOSDfCID_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GGPOSDfCID_1616_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_GPOS_Details_for_ContractID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ContractID", Parameter.ContractID);



			List<MD_GGPOSDfCID_1616> results = new List<MD_GGPOSDfCID_1616>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "GposID","GposNumber","GposName","GposType","DrugNames","DiagnoseNames","FeeValue","FromInjection","ManagementFeeValue","WaiveWithOrder" });
				while(reader.Read())
				{
					MD_GGPOSDfCID_1616 resultItem = new MD_GGPOSDfCID_1616();
					//0:Parameter GposID of type Guid
					resultItem.GposID = reader.GetGuid(0);
					//1:Parameter GposNumber of type String
					resultItem.GposNumber = reader.GetString(1);
					//2:Parameter GposName of type String
					resultItem.GposName = reader.GetString(2);
					//3:Parameter GposType of type String
					resultItem.GposType = reader.GetString(3);
					//4:Parameter DrugNames of type String
					resultItem.DrugNames = reader.GetString(4);
					//5:Parameter DiagnoseNames of type String
					resultItem.DiagnoseNames = reader.GetString(5);
					//6:Parameter FeeValue of type Double
					resultItem.FeeValue = reader.GetDouble(6);
					//7:Parameter FromInjection of type int
					resultItem.FromInjection = reader.GetInteger(7);
					//8:Parameter ManagementFeeValue of type String
					resultItem.ManagementFeeValue = reader.GetString(8);
					//9:Parameter WaiveWithOrder of type Boolean
					resultItem.WaiveWithOrder = reader.GetBoolean(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_GPOS_Details_for_ContractID",ex);
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
		public static FR_MD_GGPOSDfCID_1616_Array Invoke(string ConnectionString,P_MD_GGPOSDfCID_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSDfCID_1616_Array Invoke(DbConnection Connection,P_MD_GGPOSDfCID_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSDfCID_1616_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GGPOSDfCID_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GGPOSDfCID_1616_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GGPOSDfCID_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GGPOSDfCID_1616_Array functionReturn = new FR_MD_GGPOSDfCID_1616_Array();
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

				throw new Exception("Exception occured in method cls_Get_GPOS_Details_for_ContractID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GGPOSDfCID_1616_Array : FR_Base
	{
		public MD_GGPOSDfCID_1616[] Result	{ get; set; } 
		public FR_MD_GGPOSDfCID_1616_Array() : base() {}

		public FR_MD_GGPOSDfCID_1616_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GGPOSDfCID_1616 for attribute P_MD_GGPOSDfCID_1616
		[DataContract]
		public class P_MD_GGPOSDfCID_1616 
		{
			//Standard type parameters
			[DataMember]
			public Guid ContractID { get; set; } 

		}
		#endregion
		#region SClass MD_GGPOSDfCID_1616 for attribute MD_GGPOSDfCID_1616
		[DataContract]
		public class MD_GGPOSDfCID_1616 
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
			public String DrugNames { get; set; } 
			[DataMember]
			public String DiagnoseNames { get; set; } 
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
FR_MD_GGPOSDfCID_1616_Array cls_Get_GPOS_Details_for_ContractID(,P_MD_GGPOSDfCID_1616 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GGPOSDfCID_1616_Array invocationResult = cls_Get_GPOS_Details_for_ContractID.Invoke(connectionString,P_MD_GGPOSDfCID_1616 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GGPOSDfCID_1616();
parameter.ContractID = ...;

*/
