/* 
 * Generated on 2/16/2015 14:02:09
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
using CL2_Contact.DomainManagement;
namespace CL2_Contact.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ContantTypeID_for_GlobalPropertyMatchingID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ContantTypeID_for_GlobalPropertyMatchingID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CN_GCTIDfGPMID_1359 Execute(DbConnection Connection,DbTransaction Transaction,P_L2CN_GCTIDfGPMID_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L2CN_GCTIDfGPMID_1359();
			//Put your code here
            returnValue.Result = new L2CN_GCTIDfGPMID_1359();
            returnValue.Result.ContactTypeID = new Guid();
             returnValue.Result.ContactTypeID = DomainManagement.DMComunactionContactTypes.Get_CommunactionContactType_for_GlobalPropertyMatchingID(Connection, Transaction, Parameter.Type, securityTicket);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2CN_GCTIDfGPMID_1359 Invoke(string ConnectionString,P_L2CN_GCTIDfGPMID_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CN_GCTIDfGPMID_1359 Invoke(DbConnection Connection,P_L2CN_GCTIDfGPMID_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CN_GCTIDfGPMID_1359 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CN_GCTIDfGPMID_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CN_GCTIDfGPMID_1359 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CN_GCTIDfGPMID_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CN_GCTIDfGPMID_1359 functionReturn = new FR_L2CN_GCTIDfGPMID_1359();
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

				throw new Exception("Exception occured in method cls_Get_ContantTypeID_for_GlobalPropertyMatchingID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CN_GCTIDfGPMID_1359 : FR_Base
	{
		public L2CN_GCTIDfGPMID_1359 Result	{ get; set; }

		public FR_L2CN_GCTIDfGPMID_1359() : base() {}

		public FR_L2CN_GCTIDfGPMID_1359(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2CN_GCTIDfGPMID_1359 for attribute P_L2CN_GCTIDfGPMID_1359
		[DataContract]
		public class P_L2CN_GCTIDfGPMID_1359 
		{
			//Standard type parameters
			[DataMember]
			public String Type { get; set; } 

		}
		#endregion
		#region SClass L2CN_GCTIDfGPMID_1359 for attribute L2CN_GCTIDfGPMID_1359
		[DataContract]
		public class L2CN_GCTIDfGPMID_1359 
		{
			//Standard type parameters
			[DataMember]
			public Guid ContactTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CN_GCTIDfGPMID_1359 cls_Get_ContantTypeID_for_GlobalPropertyMatchingID(,P_L2CN_GCTIDfGPMID_1359 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CN_GCTIDfGPMID_1359 invocationResult = cls_Get_ContantTypeID_for_GlobalPropertyMatchingID.Invoke(connectionString,P_L2CN_GCTIDfGPMID_1359 Parameter,securityTicket);
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
var parameter = new CL2_Contact.Complex.Retrieval.P_L2CN_GCTIDfGPMID_1359();
parameter.Type = ...;

*/
