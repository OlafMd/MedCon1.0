/* 
 * Generated on 5/25/2015 11:21:23 AM
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
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Patient.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_for_PatientEdit.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_for_PatientEdit
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GDFPE_1112 Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GDFPE_1112 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_PA_GDFPE_1112();
            returnValue.Result = new PA_GDFPE_1112();
            returnValue.Result.InitalData = cls_Get_Data_for_AddPatientView.Invoke(Connection, Transaction, new P_PA_GDAPV_1629 { ID = Parameter.ID, isPracticeLoggedIn = Parameter.isPracticeLoggedIn }, securityTicket).Result;
            returnValue.Result.PatientData = cls_Get_PatientEdit_Data_for_PatientID.Invoke(Connection, Transaction, new P_PA_GPDfPID_1101 { PatientID = Parameter.PatientID }, securityTicket).Result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_PA_GDFPE_1112 Invoke(string ConnectionString,P_PA_GDFPE_1112 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GDFPE_1112 Invoke(DbConnection Connection,P_PA_GDFPE_1112 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GDFPE_1112 Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GDFPE_1112 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GDFPE_1112 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GDFPE_1112 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GDFPE_1112 functionReturn = new FR_PA_GDFPE_1112();
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

				throw new Exception("Exception occured in method cls_Get_Data_for_PatientEdit",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GDFPE_1112 : FR_Base
	{
		public PA_GDFPE_1112 Result	{ get; set; }

		public FR_PA_GDFPE_1112() : base() {}

		public FR_PA_GDFPE_1112(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GDFPE_1112 for attribute P_PA_GDFPE_1112
		[DataContract]
		public class P_PA_GDFPE_1112 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public bool isPracticeLoggedIn { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass PA_GDFPE_1112 for attribute PA_GDFPE_1112
		[DataContract]
		public class PA_GDFPE_1112 
		{
			//Standard type parameters
			[DataMember]
			public PA_GDAPV_1629 InitalData { get; set; } 
			[DataMember]
			public PA_GPDfPID_1101 PatientData { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GDFPE_1112 cls_Get_Data_for_PatientEdit(,P_PA_GDFPE_1112 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GDFPE_1112 invocationResult = cls_Get_Data_for_PatientEdit.Invoke(connectionString,P_PA_GDFPE_1112 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Complex.Retrieval.P_PA_GDFPE_1112();
parameter.ID = ...;
parameter.isPracticeLoggedIn = ...;
parameter.PatientID = ...;

*/
