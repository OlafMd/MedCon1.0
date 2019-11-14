/* 
 * Generated on 11/19/2013 11:58:24 AM
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
using CL5_Plannico_Breaks.Atomic.Retrieval;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_Breaks.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DefaultBreakes_For_DeafultBreakeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DefaultBreakes_For_DeafultBreakeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BR_GDBFDBID_1155 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BR_GDBFDBID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BR_GDBFDBID_1155();

            ORM_CMN_PPS_BreakTime_Default.Query defaultBreakTimeQuery = new ORM_CMN_PPS_BreakTime_Default.Query();
            defaultBreakTimeQuery.CMN_PPS_BreakTime_DefaultID = Parameter.CMN_PPS_BreakTime_DefaultID;
            defaultBreakTimeQuery.IsDeleted = false;
            defaultBreakTimeQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_PPS_BreakTime_Default> defaultBreakes = ORM_CMN_PPS_BreakTime_Default.Query.Search(Connection, Transaction, defaultBreakTimeQuery);
            if (defaultBreakes.Count != 0)
            {

                L5BR_GDBFT_1153 breakItem = new L5BR_GDBFT_1153();
                breakItem.BreakTime_Template_RefID = defaultBreakes[0].BreakTime_Template_RefID;
                breakItem.CMN_PPS_BreakTime_DefaultID = defaultBreakes[0].CMN_PPS_BreakTime_DefaultID;
                breakItem.ExpectedWorkTime_in_sec = defaultBreakes[0].ExpectedWorkTime_in_sec;
                breakItem.ValidFromTimeOffset_in_sec = defaultBreakes[0].ValidFromTimeOffset_in_sec;
                breakItem.ValidToTimeOffset_in_sec = defaultBreakes[0].ValidToTimeOffset_in_sec;

                ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query structureBindingQuery = new ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query();
                structureBindingQuery.BreakTime_Default_RefID = defaultBreakes[0].CMN_PPS_BreakTime_DefaultID;
                structureBindingQuery.IsDeleted = false;
                structureBindingQuery.Tenant_RefID = securityTicket.TenantID;

                var structureBindings = ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query.Search(Connection, Transaction, structureBindingQuery);

                if (structureBindings.Count != 0)
                {
                    breakItem.BoundTo_Office_RefID = structureBindings[0].BoundTo_Office_RefID;
                    breakItem.BoundTo_WorkArea_RefID = structureBindings[0].BoundTo_WorkArea_RefID;
                    breakItem.BoundTo_Workplace_RefID = structureBindings[0].BoundTo_Workplace_RefID;
                }
                else
                {
                    breakItem.BoundTo_Office_RefID = Guid.Empty;
                    breakItem.BoundTo_WorkArea_RefID = Guid.Empty;
                    breakItem.BoundTo_Workplace_RefID = Guid.Empty;
                }
                returnValue.Result = new L5BR_GDBFDBID_1155();
                returnValue.Result.DefaultBreak = breakItem;
            }
            else { return returnValue; }
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BR_GDBFDBID_1155 Invoke(string ConnectionString,P_L5BR_GDBFDBID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BR_GDBFDBID_1155 Invoke(DbConnection Connection,P_L5BR_GDBFDBID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BR_GDBFDBID_1155 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BR_GDBFDBID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BR_GDBFDBID_1155 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BR_GDBFDBID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BR_GDBFDBID_1155 functionReturn = new FR_L5BR_GDBFDBID_1155();
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
				throw new Exception("Exception occured in method cls_Get_DefaultBreakes_For_DeafultBreakeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BR_GDBFDBID_1155 : FR_Base
	{
		public L5BR_GDBFDBID_1155 Result	{ get; set; }

		public FR_L5BR_GDBFDBID_1155() : base() {}

		public FR_L5BR_GDBFDBID_1155(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BR_GDBFDBID_1155 cls_Get_DefaultBreakes_For_DeafultBreakeID(,P_L5BR_GDBFDBID_1155 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BR_GDBFDBID_1155 invocationResult = cls_Get_DefaultBreakes_For_DeafultBreakeID.Invoke(connectionString,P_L5BR_GDBFDBID_1155 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_Breaks.Complex.Retrieval.P_L5BR_GDBFDBID_1155();
parameter.CMN_PPS_BreakTime_DefaultID = ...;

*/