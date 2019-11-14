/* 
 * Generated on 02/06/16 16:47:28
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
    /// var result = cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GCPVfITBCID_1647 Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GCPVfITBCID_1647 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GCPVfITBCID_1647();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"InsuranceToBrokerContractID", Parameter.InsuranceToBrokerContractID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ParameterName", Parameter.ParameterName);



			List<MD_GCPVfITBCID_1647> results = new List<MD_GCPVfITBCID_1647>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ConsentValidForMonths" });
				while(reader.Read())
				{
					MD_GCPVfITBCID_1647 resultItem = new MD_GCPVfITBCID_1647();
					//0:Parameter ConsentValidForMonths of type Double
					resultItem.ConsentValidForMonths = reader.GetDouble(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID",ex);
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
		public static FR_MD_GCPVfITBCID_1647 Invoke(string ConnectionString,P_MD_GCPVfITBCID_1647 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GCPVfITBCID_1647 Invoke(DbConnection Connection,P_MD_GCPVfITBCID_1647 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GCPVfITBCID_1647 Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GCPVfITBCID_1647 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GCPVfITBCID_1647 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GCPVfITBCID_1647 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GCPVfITBCID_1647 functionReturn = new FR_MD_GCPVfITBCID_1647();
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

				throw new Exception("Exception occured in method cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GCPVfITBCID_1647 : FR_Base
	{
		public MD_GCPVfITBCID_1647 Result	{ get; set; }

		public FR_MD_GCPVfITBCID_1647() : base() {}

		public FR_MD_GCPVfITBCID_1647(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GCPVfITBCID_1647 for attribute P_MD_GCPVfITBCID_1647
		[DataContract]
		public class P_MD_GCPVfITBCID_1647 
		{
			//Standard type parameters
			[DataMember]
			public Guid InsuranceToBrokerContractID { get; set; } 
			[DataMember]
			public String ParameterName { get; set; } 

		}
		#endregion
		#region SClass MD_GCPVfITBCID_1647 for attribute MD_GCPVfITBCID_1647
		[DataContract]
		public class MD_GCPVfITBCID_1647 
		{
			//Standard type parameters
			[DataMember]
			public Double ConsentValidForMonths { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GCPVfITBCID_1647 cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID(,P_MD_GCPVfITBCID_1647 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GCPVfITBCID_1647 invocationResult = cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID.Invoke(connectionString,P_MD_GCPVfITBCID_1647 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GCPVfITBCID_1647();
parameter.InsuranceToBrokerContractID = ...;
parameter.ParameterName = ...;

*/
