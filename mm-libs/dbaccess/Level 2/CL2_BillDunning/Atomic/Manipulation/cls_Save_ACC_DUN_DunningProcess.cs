/* 
 * Generated on 5/27/2014 2:14:25 PM
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

namespace CL2_BillDunning.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ACC_DUN_DunningProcess.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ACC_DUN_DunningProcess
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2BD_SADDP_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_ACC_DUN.ORM_ACC_DUN_DunningProcess();
			if (Parameter.ACC_DUN_DunningProcessID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.ACC_DUN_DunningProcessID);
			    if (result.Status != FR_Status.Success || item.ACC_DUN_DunningProcessID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.ACC_DUN_DunningProcessID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.ACC_DUN_DunningProcessID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.DunnedCustomer_RefID = Parameter.DunnedCustomer_RefID;
			item.DunningModel_RefID = Parameter.DunningModel_RefID;
			item.Currency_RefID = Parameter.Currency_RefID;
			item.Current_DunningLevel_RefID = Parameter.Current_DunningLevel_RefID;
			item.DunnedAmount_Total = Parameter.DunnedAmount_Total;
			item.ReachesNextDunningLevelAtDate = Parameter.ReachesNextDunningLevelAtDate;
			item.IsDunningProcessClosed = Parameter.IsDunningProcessClosed;
			item.DunningProcessClosedAt_Date = Parameter.DunningProcessClosedAt_Date;
			item.DunningProcessClosedBy_BusinessParticipnant_RefID = Parameter.DunningProcessClosedBy_BusinessParticipnant_RefID;


			return new FR_Guid(item.Save(Connection, Transaction),item.ACC_DUN_DunningProcessID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2BD_SADDP_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2BD_SADDP_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2BD_SADDP_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2BD_SADDP_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ACC_DUN_DunningProcess",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2BD_SADDP_1412 for attribute P_L2BD_SADDP_1412
		[DataContract]
		public class P_L2BD_SADDP_1412 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_DUN_DunningProcessID { get; set; } 
			[DataMember]
			public Guid DunnedCustomer_RefID { get; set; } 
			[DataMember]
			public Guid DunningModel_RefID { get; set; } 
			[DataMember]
			public Guid Currency_RefID { get; set; } 
			[DataMember]
			public Guid Current_DunningLevel_RefID { get; set; } 
			[DataMember]
			public Decimal DunnedAmount_Total { get; set; } 
			[DataMember]
			public DateTime ReachesNextDunningLevelAtDate { get; set; } 
			[DataMember]
			public Boolean IsDunningProcessClosed { get; set; } 
			[DataMember]
			public DateTime DunningProcessClosedAt_Date { get; set; } 
			[DataMember]
			public Guid DunningProcessClosedBy_BusinessParticipnant_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ACC_DUN_DunningProcess(,P_L2BD_SADDP_1412 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ACC_DUN_DunningProcess.Invoke(connectionString,P_L2BD_SADDP_1412 Parameter,securityTicket);
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
var parameter = new CL2_BillDunning.Atomic.Manipulation.P_L2BD_SADDP_1412();
parameter.ACC_DUN_DunningProcessID = ...;
parameter.DunnedCustomer_RefID = ...;
parameter.DunningModel_RefID = ...;
parameter.Currency_RefID = ...;
parameter.Current_DunningLevel_RefID = ...;
parameter.DunnedAmount_Total = ...;
parameter.ReachesNextDunningLevelAtDate = ...;
parameter.IsDunningProcessClosed = ...;
parameter.DunningProcessClosedAt_Date = ...;
parameter.DunningProcessClosedBy_BusinessParticipnant_RefID = ...;
parameter.IsDeleted = ...;

*/
