/* 
 * Generated on 06-Jan-14 16:27:53
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
using CL1_CMN_PPS;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_HealthInsurances.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DefaultBreak.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DefaultBreak
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BR_SDB_1201 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_PPS_BreakTime_Default defaultBreak = new ORM_CMN_PPS_BreakTime_Default();
            if (Parameter.CMN_PPS_BreakTime_DefaultID != Guid.Empty)
            {
                var result = defaultBreak.Load(Connection, Transaction, Parameter.CMN_PPS_BreakTime_DefaultID);
                if (result.Status != FR_Status.Success || defaultBreak.CMN_PPS_BreakTime_DefaultID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            defaultBreak.BreakTime_Template_RefID = Parameter.BreakTime_Template_RefID;
            defaultBreak.ExpectedWorkTime_in_sec = Parameter.ExpectedWorkTime_in_sec;
            defaultBreak.ValidFromTimeOffset_in_sec = Parameter.ValidFromTimeOffset_in_sec;
            defaultBreak.ValidToTimeOffset_in_sec = Parameter.ValidToTimeOffset_in_sec;
            defaultBreak.Tenant_RefID = securityTicket.TenantID;
            defaultBreak.Save(Connection, Transaction);
            returnValue.Result = defaultBreak.CMN_PPS_BreakTime_DefaultID;

            ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query structureBindingQuery = new ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query();
            structureBindingQuery.BreakTime_Default_RefID = defaultBreak.CMN_PPS_BreakTime_DefaultID;
            structureBindingQuery.IsDeleted = false;
            structureBindingQuery.Tenant_RefID = securityTicket.TenantID;

            var structureBindings = ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query.Search(Connection, Transaction, structureBindingQuery);

            if (structureBindings.Count != 0)
            {
                var structureBinding = structureBindings.FirstOrDefault();
                structureBinding.BoundTo_Office_RefID = Parameter.BoundTo_Office_RefID;
                structureBinding.BoundTo_WorkArea_RefID = Parameter.BoundTo_WorkArea_RefID;
                structureBinding.BoundTo_Workplace_RefID = Parameter.BoundTo_Workplace_RefID;

                structureBinding.Save(Connection, Transaction);
            }
            else
            {
                ORM_CMN_PPS_BreakTime_Defaults_StructureBinding structureBinding = new ORM_CMN_PPS_BreakTime_Defaults_StructureBinding();
                structureBinding.BoundTo_Office_RefID = Parameter.BoundTo_Office_RefID;
                structureBinding.BoundTo_WorkArea_RefID = Parameter.BoundTo_WorkArea_RefID;
                structureBinding.BoundTo_Workplace_RefID = Parameter.BoundTo_Workplace_RefID;
                structureBinding.BreakTime_Default_RefID = defaultBreak.CMN_PPS_BreakTime_DefaultID;
                structureBinding.Tenant_RefID = securityTicket.TenantID;
                structureBinding.Save(Connection, Transaction);
            }

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BR_SDB_1201 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BR_SDB_1201 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BR_SDB_1201 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BR_SDB_1201 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
	

	#endregion
}
