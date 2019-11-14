/* 
 * Generated on 1/29/2015 11:28:32 PM
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
    /// var result = cls_Get_Reading_Session_Details.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Reading_Session_Details
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6MRMS_GRSD_1942 Execute(DbConnection Connection,DbTransaction Transaction,P_L6MRMS_GRSD_1942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6MRMS_GRSD_1942();
            returnValue.Result = new L6MRMS_GRSD_1942();

            var readingSession = cls_Get_Reading_Session.Invoke(Connection, Transaction, new P_L6MRMS_GRS_2126() { ReadingSessionId = Parameter.ReadingSessionId }, securityTicket);
            var readingSessionItems = cls_Get_All_Reading_Session_Items_with_Readers.Invoke(Connection, Transaction, new P_L6MRMS_GARSIwR_1056() { ReadingSessionId = Parameter.ReadingSessionId }, securityTicket);

            returnValue.Result.ReadingSession = readingSession.Result;
            returnValue.Result.ReadingSessionItems = readingSessionItems.Result;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6MRMS_GRSD_1942 Invoke(string ConnectionString,P_L6MRMS_GRSD_1942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GRSD_1942 Invoke(DbConnection Connection,P_L6MRMS_GRSD_1942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GRSD_1942 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MRMS_GRSD_1942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6MRMS_GRSD_1942 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MRMS_GRSD_1942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6MRMS_GRSD_1942 functionReturn = new FR_L6MRMS_GRSD_1942();
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

				throw new Exception("Exception occured in method cls_Get_Reading_Session_Details",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6MRMS_GRSD_1942 : FR_Base
	{
		public L6MRMS_GRSD_1942 Result	{ get; set; }

		public FR_L6MRMS_GRSD_1942() : base() {}

		public FR_L6MRMS_GRSD_1942(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6MRMS_GRSD_1942 for attribute P_L6MRMS_GRSD_1942
		[DataContract]
		public class P_L6MRMS_GRSD_1942 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReadingSessionId { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GRSD_1942 for attribute L6MRMS_GRSD_1942
		[DataContract]
		public class L6MRMS_GRSD_1942 
		{
			//Standard type parameters
			[DataMember]
			public L6MRMS_GRS_2126 ReadingSession { get; set; } 
			[DataMember]
			public L6MRMS_GARSIwR_1056[] ReadingSessionItems { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6MRMS_GRSD_1942 cls_Get_Reading_Session_Details(,P_L6MRMS_GRSD_1942 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6MRMS_GRSD_1942 invocationResult = cls_Get_Reading_Session_Details.Invoke(connectionString,P_L6MRMS_GRSD_1942 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Atomic.Retrieval.P_L6MRMS_GRSD_1942();
parameter.ReadingSessionId = ...;

*/
