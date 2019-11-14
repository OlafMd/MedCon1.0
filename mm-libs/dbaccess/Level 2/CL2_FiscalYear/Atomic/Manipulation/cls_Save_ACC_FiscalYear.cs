/* 
 * Generated on 6/11/2014 11:37:13 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_FiscalYear.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ACC_FiscalYear.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ACC_FiscalYear
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_CL2_SFY_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_ACC.ORM_ACC_FiscalYear();
			if (Parameter.ACC_FiscalYearID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.ACC_FiscalYearID);
			    if (result.Status != FR_Status.Success || item.ACC_FiscalYearID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.ACC_FiscalYearID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.ACC_FiscalYearID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

            if (Parameter.FiscalYearName != null) item.FiscalYearName = Parameter.FiscalYearName;
			if (Parameter.StartDate != null) item.StartDate = Parameter.StartDate;
            if (Parameter.EndDate != null) item.EndDate = Parameter.EndDate;
            if (Parameter.IsClosed != null) item.IsClosed = Parameter.IsClosed;
            if (Parameter.IsFinalizationTriggered != null) item.IsFinalizationTriggered = Parameter.IsFinalizationTriggered;

			return new FR_Guid(item.Save(Connection, Transaction),item.ACC_FiscalYearID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_CL2_SFY_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_CL2_SFY_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_CL2_SFY_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL2_SFY_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_ACC_FiscalYear",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_CL2_SFY_1552 for attribute P_CL2_SFY_1552
		[DataContract]
		public class P_CL2_SFY_1552 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_FiscalYearID { get; set; } 
			[DataMember]
			public String FiscalYearName { get; set; } 
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsClosed { get; set; } 
			[DataMember]
			public Boolean IsFinalizationTriggered { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ACC_FiscalYear(,P_CL2_SFY_1552 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ACC_FiscalYear.Invoke(connectionString,P_CL2_SFY_1552 Parameter,securityTicket);
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
var parameter = new CL2_FiscalYear.Atomic.Manipulation.P_CL2_SFY_1552();
parameter.ACC_FiscalYearID = ...;
parameter.FiscalYearName = ...;
parameter.StartDate = ...;
parameter.EndDate = ...;
parameter.IsDeleted = ...;
parameter.IsClosed = ...;
parameter.IsFinalizationTriggered = ...;

*/
