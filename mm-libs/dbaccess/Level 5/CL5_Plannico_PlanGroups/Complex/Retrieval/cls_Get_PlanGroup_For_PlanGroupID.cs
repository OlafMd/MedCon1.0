/* 
 * Generated on 12/3/2013 1:21:45 PM
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
using CL5_Plannico_PlanGroups.Atomic.Retrieval;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_PlanGroups.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PlanGroup_For_PlanGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PlanGroup_For_PlanGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PG_GPGFPGID_1319 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PG_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5PG_GPGFPGID_1319();
            returnValue.Result = new L5PG_GPGFPGID_1319();

			//Put your code here
            ORM_CMN_BPT_EMP_Employee_PlanGroup planGroup = new ORM_CMN_BPT_EMP_Employee_PlanGroup();

            if (Parameter.CMN_BPT_EMP_Employee_PlanGroupID != Guid.Empty)
            {
                var result = planGroup.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_Employee_PlanGroupID);
                if (result.Status != FR_Status.Success || planGroup.CMN_BPT_EMP_Employee_PlanGroupID == Guid.Empty)
                    return null;
            }

            L5PG_GPGFT_1317 planGroupResult = new L5PG_GPGFT_1317();
            planGroupResult.CMN_BPT_EMP_Employee_PlanGroupID = planGroup.CMN_BPT_EMP_Employee_PlanGroupID;
            planGroupResult.PlanGroup_Name = planGroup.PlanGroup_Name;
            planGroupResult.PlanGroup_Description = planGroup.PlanGroup_Description;
            planGroupResult.BoundTo_Office_RefID = planGroup.BoundTo_Office_RefID;
            planGroupResult.BoundTo_WorkArea_RefID = planGroup.BoundTo_WorkArea_RefID;
            planGroupResult.BoundTo_WorkPlace_RefID = planGroupResult.BoundTo_WorkPlace_RefID;

            returnValue.Result.PlanGroup = planGroupResult;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PG_GPGFPGID_1319 Invoke(string ConnectionString,P_L5PG_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PG_GPGFPGID_1319 Invoke(DbConnection Connection,P_L5PG_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PG_GPGFPGID_1319 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PG_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PG_GPGFPGID_1319 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PG_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PG_GPGFPGID_1319 functionReturn = new FR_L5PG_GPGFPGID_1319();
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
	public class FR_L5PG_GPGFPGID_1319 : FR_Base
	{
		public L5PG_GPGFPGID_1319 Result	{ get; set; }

		public FR_L5PG_GPGFPGID_1319() : base() {}

		public FR_L5PG_GPGFPGID_1319(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PG_GPGFPGID_1319 cls_Get_PlanGroup_For_PlanGroupID(P_L5PG_GPGFPGID_1319 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5PG_GPGFPGID_1319 result = cls_Get_PlanGroup_For_PlanGroupID.Invoke(connectionString,P_L5PG_GPGFPGID_1319 Parameter,securityTicket);
	 return result;
}
*/