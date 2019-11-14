/* 
 * Generated on 24.06.2014 14:37:40
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
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval;

namespace CL6_Lucenits_Patient.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AvailabilityData_for_BusinessParticipantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AvailabilityData_for_BusinessParticipantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DO_GADfBP_1344 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DO_GADfBP_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DO_GADfBP_1344();
            returnValue.Result = new L6DO_GADfBP_1344();
            returnValue.Result.OtherWorkTime = new L5DO_GDaSAfBPID_1111();
            returnValue.Result.OtherWorkTime = cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID.Invoke(Connection, Transaction, new P_L5DO_GDaSAfBPID_1111 { StaffID = Parameter.StaffID }, securityTicket).Result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DO_GADfBP_1344 Invoke(string ConnectionString,P_L6DO_GADfBP_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DO_GADfBP_1344 Invoke(DbConnection Connection,P_L6DO_GADfBP_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DO_GADfBP_1344 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DO_GADfBP_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DO_GADfBP_1344 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DO_GADfBP_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DO_GADfBP_1344 functionReturn = new FR_L6DO_GADfBP_1344();
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

				throw new Exception("Exception occured in method cls_Get_AvailabilityData_for_BusinessParticipantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DO_GADfBP_1344 : FR_Base
	{
		public L6DO_GADfBP_1344 Result	{ get; set; }

		public FR_L6DO_GADfBP_1344() : base() {}

		public FR_L6DO_GADfBP_1344(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DO_GADfBP_1344 for attribute P_L6DO_GADfBP_1344
		[DataContract]
		public class P_L6DO_GADfBP_1344 
		{
			//Standard type parameters
			[DataMember]
			public Guid StaffID { get; set; } 

		}
		#endregion
		#region SClass L6DO_GADfBP_1344 for attribute L6DO_GADfBP_1344
		[DataContract]
		public class L6DO_GADfBP_1344 
		{
			//Standard type parameters
			[DataMember]
			public L5DO_GDaSAfBPID_1111 OtherWorkTime { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DO_GADfBP_1344 cls_Get_AvailabilityData_for_BusinessParticipantID(,P_L6DO_GADfBP_1344 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DO_GADfBP_1344 invocationResult = cls_Get_AvailabilityData_for_BusinessParticipantID.Invoke(connectionString,P_L6DO_GADfBP_1344 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Patient.Complex.Retrieval.P_L6DO_GADfBP_1344();
parameter.StaffID = ...;

*/
