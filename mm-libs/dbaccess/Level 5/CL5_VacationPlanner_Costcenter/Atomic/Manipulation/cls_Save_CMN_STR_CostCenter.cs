/* 
 * Generated on 09-Sep-13 15:43:59
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
using CL1_CMN_STR;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Costcenter.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_STR_CostCenter.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_STR_CostCenter
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CC_SCC_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

    var returnValue = new FR_Guid();

    var item = new ORM_CMN_STR_CostCenter();
    if (Parameter.CMN_STR_CostCenterID != Guid.Empty)
    {
    var result = item.Load(Connection, Transaction, Parameter.CMN_STR_CostCenterID);
    if (result.Status != FR_Status.Success || item.CMN_STR_CostCenterID == Guid.Empty)
    {
    var error = new FR_Guid();
    error.ErrorMessage = "No Such ID";
    error.Status =  FR_Status.Error_Internal;
    return error;
    }
    }

    if(Parameter.IsDeleted == true){
    item.IsDeleted = true;
    return new FR_Guid(item.Save(Connection, Transaction),item.CMN_STR_CostCenterID);
    }

    //Creation specific parameters (Tenant, Account ... )
    if (Parameter.CMN_STR_CostCenterID == Guid.Empty)
    {
    item.Tenant_RefID = securityTicket.TenantID;
    }

    item.InternalID = Parameter.InternalID;
    item.Name = Parameter.Name;


    return new FR_Guid(item.Save(Connection, Transaction),item.CMN_STR_CostCenterID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CC_SCC_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CC_SCC_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CC_SCC_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CC_SCC_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes

	#endregion
}
