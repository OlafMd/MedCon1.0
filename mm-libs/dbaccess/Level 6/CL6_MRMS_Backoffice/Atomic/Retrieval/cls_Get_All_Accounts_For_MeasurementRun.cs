/* 
 * Generated on 1/29/2015 11:10:42 PM
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

namespace CL6_MRMS_Backoffice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Accounts_For_MeasurementRun.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Accounts_For_MeasurementRun
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6MRMS_GAAfMR_0930_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6MRMS_GAAfMR_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6MRMS_GAAfMR_0930_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MRMS_Backoffice.Atomic.Retrieval.SQL.cls_Get_All_Accounts_For_MeasurementRun.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MeasurementRunID", Parameter.MeasurementRunID);



			List<L6MRMS_GAAfMR_0930> results = new List<L6MRMS_GAAfMR_0930>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LastName","FirstName","PrimaryEmail","CMN_BPT_BusinessParticipantID","Route_RefID" });
				while(reader.Read())
				{
					L6MRMS_GAAfMR_0930 resultItem = new L6MRMS_GAAfMR_0930();
					//0:Parameter LastName of type String
					resultItem.LastName = reader.GetString(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(2);
					//3:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(3);
					//4:Parameter Route_RefID of type Guid
					resultItem.Route_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Accounts_For_MeasurementRun",ex);
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
		public static FR_L6MRMS_GAAfMR_0930_Array Invoke(string ConnectionString,P_L6MRMS_GAAfMR_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GAAfMR_0930_Array Invoke(DbConnection Connection,P_L6MRMS_GAAfMR_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GAAfMR_0930_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MRMS_GAAfMR_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6MRMS_GAAfMR_0930_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MRMS_GAAfMR_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6MRMS_GAAfMR_0930_Array functionReturn = new FR_L6MRMS_GAAfMR_0930_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Accounts_For_MeasurementRun",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6MRMS_GAAfMR_0930_Array : FR_Base
	{
		public L6MRMS_GAAfMR_0930[] Result	{ get; set; } 
		public FR_L6MRMS_GAAfMR_0930_Array() : base() {}

		public FR_L6MRMS_GAAfMR_0930_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6MRMS_GAAfMR_0930 for attribute P_L6MRMS_GAAfMR_0930
		[DataContract]
		public class P_L6MRMS_GAAfMR_0930 
		{
			//Standard type parameters
			[DataMember]
			public Guid MeasurementRunID { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GAAfMR_0930 for attribute L6MRMS_GAAfMR_0930
		[DataContract]
		public class L6MRMS_GAAfMR_0930 
		{
			//Standard type parameters
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid Route_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6MRMS_GAAfMR_0930_Array cls_Get_All_Accounts_For_MeasurementRun(,P_L6MRMS_GAAfMR_0930 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6MRMS_GAAfMR_0930_Array invocationResult = cls_Get_All_Accounts_For_MeasurementRun.Invoke(connectionString,P_L6MRMS_GAAfMR_0930 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Atomic.Retrieval.P_L6MRMS_GAAfMR_0930();
parameter.MeasurementRunID = ...;

*/
