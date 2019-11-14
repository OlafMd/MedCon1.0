/* 
 * Generated on 06-Jan-14 11:54:43
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
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_ExtraWorkCalculation_Surcharges.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ExtraWorkCalculation_Surcharge.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ExtraWorkCalculation_Surcharge
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EW_SEWCS_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge extraWorkCalculation = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge();

            if (Parameter.CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID != Guid.Empty)
            {
                var result = extraWorkCalculation.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID);
                if (result.Status != FR_Status.Success || extraWorkCalculation.CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            extraWorkCalculation.IsNightTimeSurcharge = Parameter.IsNightTimeSurcharge;
            extraWorkCalculation.IsSpecialEventSurcharge = Parameter.IsSpecialEventSurcharge;
            extraWorkCalculation.Surcharge_Name = Parameter.Surcharge_Name;
            extraWorkCalculation.Tenant_RefID = securityTicket.TenantID;

            extraWorkCalculation.Save(Connection, Transaction);

            returnValue = new FR_Guid(extraWorkCalculation.CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID);

            ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query structureBindingQuery = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query();
            structureBindingQuery.ExtraWorkCalculation_Surcharge_RefID = extraWorkCalculation.CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID;
            structureBindingQuery.IsDeleted = false;
            structureBindingQuery.Tenant_RefID = securityTicket.TenantID;

            var structureBindings = ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query.Search(Connection, Transaction, structureBindingQuery);

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
                ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding structureBinding = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding();
                structureBinding.BoundTo_Office_RefID = Parameter.BoundTo_Office_RefID;
                structureBinding.BoundTo_WorkArea_RefID = Parameter.BoundTo_WorkArea_RefID;
                structureBinding.BoundTo_Workplace_RefID = Parameter.BoundTo_Workplace_RefID;
                structureBinding.ExtraWorkCalculation_Surcharge_RefID = extraWorkCalculation.CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID;
                structureBinding.Tenant_RefID = securityTicket.TenantID;
                structureBinding.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EW_SEWCS_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EW_SEWCS_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EW_SEWCS_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EW_SEWCS_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
