/* 
 * Generated on 9/9/2014 2:37:07 PM
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
using CL5_MyHealthClub_Device.Atomic.Retrieval;
using CL5_MyHealthClub_OrgUnits.Atomic.Retrieval;
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval;

namespace CL6_MyHealthClub_Dashboard.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllWorktimeExceptions_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllWorktimeExceptions_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DA_GLWEfTID_0953 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DA_GLWEfTID_0953();
			//Put your code here
            returnValue.Result = new L6DA_GLWEfTID_0953();
            returnValue.Result.DeviceInstanceWorktimeException = cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.OrgUnitsWorktimeException = cls_Get_OrgUnit_WorktimeExceptions_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.StaffWorktimeException = cls_Get_Staff_WorktimeExceptions_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DA_GLWEfTID_0953 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DA_GLWEfTID_0953 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DA_GLWEfTID_0953 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DA_GLWEfTID_0953 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DA_GLWEfTID_0953 functionReturn = new FR_L6DA_GLWEfTID_0953();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_AllWorktimeExceptions_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DA_GLWEfTID_0953 : FR_Base
	{
		public L6DA_GLWEfTID_0953 Result	{ get; set; }

		public FR_L6DA_GLWEfTID_0953() : base() {}

		public FR_L6DA_GLWEfTID_0953(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6DA_GLWEfTID_0953 for attribute L6DA_GLWEfTID_0953
		[DataContract]
		public class L6DA_GLWEfTID_0953 
		{
			//Standard type parameters
			[DataMember]
			public L5OU_GOWEfTID_1156[] OrgUnitsWorktimeException { get; set; } 
			[DataMember]
			public L5DO_GSWEfTID_1129[] StaffWorktimeException { get; set; } 
			[DataMember]
			public L5DE_GDIWEfTID_1234[] DeviceInstanceWorktimeException { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DA_GLWEfTID_0953 cls_Get_AllWorktimeExceptions_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DA_GLWEfTID_0953 invocationResult = cls_Get_AllWorktimeExceptions_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

