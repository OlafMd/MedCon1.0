/* 
 * Generated on 1/20/2017 2:33:27 PM
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

namespace DataImporter.DBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_GPOS_Details_for_InsuranceToBrokerContractID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_GPOS_Details_for_InsuranceToBrokerContractID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GGPOSDfITBCID_1245_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GGPOSDfITBCID_1245 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GGPOSDfITBCID_1245_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_GPOS_Details_for_InsuranceToBrokerContractID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"InsuranceToBrokerContractID", Parameter.InsuranceToBrokerContractID);



			List<CAS_GGPOSDfITBCID_1245> results = new List<CAS_GGPOSDfITBCID_1245>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "InjectionFrom","GposCode","GposID","GposPrice","GposType" });
				while(reader.Read())
				{
					CAS_GGPOSDfITBCID_1245 resultItem = new CAS_GGPOSDfITBCID_1245();
					//0:Parameter InjectionFrom of type int
					resultItem.InjectionFrom = reader.GetInteger(0);
					//1:Parameter GposCode of type String
					resultItem.GposCode = reader.GetString(1);
					//2:Parameter GposID of type Guid
					resultItem.GposID = reader.GetGuid(2);
					//3:Parameter GposPrice of type Double
					resultItem.GposPrice = reader.GetDouble(3);
					//4:Parameter GposType of type String
					resultItem.GposType = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_GPOS_Details_for_InsuranceToBrokerContractID",ex);
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
		public static FR_CAS_GGPOSDfITBCID_1245_Array Invoke(string ConnectionString,P_CAS_GGPOSDfITBCID_1245 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GGPOSDfITBCID_1245_Array Invoke(DbConnection Connection,P_CAS_GGPOSDfITBCID_1245 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GGPOSDfITBCID_1245_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GGPOSDfITBCID_1245 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GGPOSDfITBCID_1245_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GGPOSDfITBCID_1245 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GGPOSDfITBCID_1245_Array functionReturn = new FR_CAS_GGPOSDfITBCID_1245_Array();
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

				throw new Exception("Exception occured in method cls_Get_GPOS_Details_for_InsuranceToBrokerContractID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GGPOSDfITBCID_1245_Array : FR_Base
	{
		public CAS_GGPOSDfITBCID_1245[] Result	{ get; set; } 
		public FR_CAS_GGPOSDfITBCID_1245_Array() : base() {}

		public FR_CAS_GGPOSDfITBCID_1245_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GGPOSDfITBCID_1245 for attribute P_CAS_GGPOSDfITBCID_1245
		[DataContract]
		public class P_CAS_GGPOSDfITBCID_1245 
		{
			//Standard type parameters
			[DataMember]
			public Guid InsuranceToBrokerContractID { get; set; } 

		}
		#endregion
		#region SClass CAS_GGPOSDfITBCID_1245 for attribute CAS_GGPOSDfITBCID_1245
		[DataContract]
		public class CAS_GGPOSDfITBCID_1245 
		{
			//Standard type parameters
			[DataMember]
			public int InjectionFrom { get; set; } 
			[DataMember]
			public String GposCode { get; set; } 
			[DataMember]
			public Guid GposID { get; set; } 
			[DataMember]
			public Double GposPrice { get; set; } 
			[DataMember]
			public String GposType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GGPOSDfITBCID_1245_Array cls_Get_GPOS_Details_for_InsuranceToBrokerContractID(,P_CAS_GGPOSDfITBCID_1245 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GGPOSDfITBCID_1245_Array invocationResult = cls_Get_GPOS_Details_for_InsuranceToBrokerContractID.Invoke(connectionString,P_CAS_GGPOSDfITBCID_1245 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Retrieval.P_CAS_GGPOSDfITBCID_1245();
parameter.InsuranceToBrokerContractID = ...;

*/
