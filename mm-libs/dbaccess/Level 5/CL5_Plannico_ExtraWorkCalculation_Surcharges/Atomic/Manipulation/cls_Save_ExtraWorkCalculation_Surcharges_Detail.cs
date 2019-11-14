/* 
 * Generated on 18-Nov-13 10:40:14
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
    /// var result = cls_Save_ExtraWorkCalculation_Surcharges_Detail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ExtraWorkCalculation_Surcharges_Detail
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EW_SEWCSD_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_Detail extraWorkCalculationDetail = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_Detail();
            
            if (Parameter.CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_DetailsID != Guid.Empty)
            {
                var result = extraWorkCalculationDetail.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_DetailsID);
                if (result.Status != FR_Status.Success || extraWorkCalculationDetail.CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_DetailsID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            extraWorkCalculationDetail.BoundTo_StructureCalendarEvent_RefID = Parameter.BoundTo_StructureCalendarEvent_RefID;
            extraWorkCalculationDetail.BoundTo_StructureCalendarEvent_Type_RefID = Parameter.BoundTo_StructureCalendarEvent_Type_RefID;
            extraWorkCalculationDetail.ExtraWorkCalculation_Surcharge_RefID = Parameter.ExtraWorkCalculation_Surcharge_RefID;
            extraWorkCalculationDetail.Surcharge_Standard_PercentValue = Parameter.Surcharge_Standard_PercentValue;
            extraWorkCalculationDetail.Surcharge_StartedBeforeMidnight_PercentValue = Parameter.Surcharge_StartedBeforeMidnight_PercentValue;
            extraWorkCalculationDetail.TimeFrom_in_mins = Parameter.TimeFrom_in_mins;
            extraWorkCalculationDetail.TimeTo_in_mins = Parameter.TimeTo_in_mins;
            extraWorkCalculationDetail.Tenant_RefID = securityTicket.TenantID;

            extraWorkCalculationDetail.Save(Connection, Transaction);

            returnValue = new FR_Guid(extraWorkCalculationDetail.CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_DetailsID);


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EW_SEWCSD_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EW_SEWCSD_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EW_SEWCSD_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EW_SEWCSD_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
