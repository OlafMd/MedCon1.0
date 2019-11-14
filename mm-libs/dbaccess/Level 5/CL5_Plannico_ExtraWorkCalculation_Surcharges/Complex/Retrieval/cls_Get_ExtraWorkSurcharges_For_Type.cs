/* 
 * Generated on 15-Nov-13 16:49:31
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
using CL5_Plannico_ExtraWorkCalculation_Surcharges.Atomic.Retrieval;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_ExtraWorkCalculation_Surcharges.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ExtraWorkSurcharges_For_Type.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ExtraWorkSurcharges_For_Type
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EW_GEWSFT_1605 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EW_GEWSFT_1605 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EW_GEWSFT_1605();
            returnValue.Result = new L5EW_GEWSFT_1605();
            

            L5EW_GEWCSFT_1428[] allExtraWorkSurcharges = cls_Get_ExtraWorkCalculation_Surcharges_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            if (allExtraWorkSurcharges == null)
                return null;

            L5EW_GEWCSFT_1428[] extraWorkSurchargesResult = allExtraWorkSurcharges.Where(x => (x.IsNightTimeSurcharge && Parameter.IsNightTimeSurcharge && !x.IsSpecialEventSurcharge && !Parameter.IsSpecialEventSurcharge) || (!x.IsNightTimeSurcharge && !Parameter.IsNightTimeSurcharge && x.IsSpecialEventSurcharge && Parameter.IsSpecialEventSurcharge)).ToArray();

            returnValue.Result.ExtraWorkSurcharges = extraWorkSurchargesResult;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EW_GEWSFT_1605 Invoke(string ConnectionString,P_L5EW_GEWSFT_1605 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWSFT_1605 Invoke(DbConnection Connection,P_L5EW_GEWSFT_1605 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWSFT_1605 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EW_GEWSFT_1605 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EW_GEWSFT_1605 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EW_GEWSFT_1605 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EW_GEWSFT_1605 functionReturn = new FR_L5EW_GEWSFT_1605();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5EW_GEWSFT_1605 : FR_Base
	{
		public L5EW_GEWSFT_1605 Result	{ get; set; }

		public FR_L5EW_GEWSFT_1605() : base() {}

		public FR_L5EW_GEWSFT_1605(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}
