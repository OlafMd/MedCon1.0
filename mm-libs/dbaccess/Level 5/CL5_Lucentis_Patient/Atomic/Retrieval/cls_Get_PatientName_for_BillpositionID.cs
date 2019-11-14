/* 
 * Generated on 3/6/2014 2:49:36 PM
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

namespace CL5_Lucentis_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientName_for_BillpositionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientName_for_BillpositionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPfBPID_1126 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPfBPID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPfBPID_1126();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Patient.Atomic.Retrieval.SQL.cls_Get_PatientName_for_BillpositionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillPositionID", Parameter.BillPositionID);



			List<L5PA_GPfBPID_1126> results = new List<L5PA_GPfBPID_1126>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FirstName","LastName" });
				while(reader.Read())
				{
					L5PA_GPfBPID_1126 resultItem = new L5PA_GPfBPID_1126();
					//0:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(0);
					//1:Parameter LastName of type String
					resultItem.LastName = reader.GetString(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientName_for_BillpositionID",ex);
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
		public static FR_L5PA_GPfBPID_1126 Invoke(string ConnectionString,P_L5PA_GPfBPID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfBPID_1126 Invoke(DbConnection Connection,P_L5PA_GPfBPID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfBPID_1126 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPfBPID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPfBPID_1126 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPfBPID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPfBPID_1126 functionReturn = new FR_L5PA_GPfBPID_1126();
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

				throw new Exception("Exception occured in method cls_Get_PatientName_for_BillpositionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPfBPID_1126 : FR_Base
	{
		public L5PA_GPfBPID_1126 Result	{ get; set; }

		public FR_L5PA_GPfBPID_1126() : base() {}

		public FR_L5PA_GPfBPID_1126(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPfBPID_1126 for attribute P_L5PA_GPfBPID_1126
		[DataContract]
		public class P_L5PA_GPfBPID_1126 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillPositionID { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPfBPID_1126 for attribute L5PA_GPfBPID_1126
		[DataContract]
		public class L5PA_GPfBPID_1126 
		{
			//Standard type parameters
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GPfBPID_1126 cls_Get_PatientName_for_BillpositionID(,P_L5PA_GPfBPID_1126 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPfBPID_1126 invocationResult = cls_Get_PatientName_for_BillpositionID.Invoke(connectionString,P_L5PA_GPfBPID_1126 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Patient.Atomic.Retrieval.P_L5PA_GPfBPID_1126();
parameter.BillPositionID = ...;

*/
