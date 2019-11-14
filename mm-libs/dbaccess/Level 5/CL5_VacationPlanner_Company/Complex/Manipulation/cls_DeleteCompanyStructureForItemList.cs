/* 
 * Generated on 8/26/2013 1:38:24 PM
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
using CL5_VacationPlanner_Office.Atomic.Manipulation;
using CL5_VacationPlanner_WorkArea.Atomic.Manipulation;
using CL5_VacationPlanner_WorkPlace.Atomic.Manipulation;
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Company.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_DeleteCompanyStructureForItemList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_DeleteCompanyStructureForItemList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5CM_DCSFL_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();


            foreach (var item in Parameter.Items)
            {
                //Office
                if (item.StructureType == 1)
                {
                    P_L5OF_DO_0952 par = new P_L5OF_DO_0952();
                    par.CMN_STR_OfficeID=item.StructureItemID;
                    par.CMN_CAL_CalendarInstance_RefID = item.CMN_CAL_CalendarInstance_RefID;
                    cls_Delete_Office.Invoke(Connection, Transaction, par);
                }
                //WorkArea
                else if (item.StructureType == 2)
                {
                    P_L5WA_DWA_0923 par = new P_L5WA_DWA_0923();
                    par.CMN_STR_PPS_WorkAreaID = item.StructureItemID;
                    par.CMN_CAL_CalendarInstance_RefID = item.CMN_CAL_CalendarInstance_RefID;
                    cls_Delete_WorkArea.Invoke(Connection, Transaction, par);
                }
                //WorkPlace
                else if (item.StructureType == 3)
                {
                    P_L5WP_DWP_0917 par =new P_L5WP_DWP_0917();
                    par.CMN_STR_PPS_WorkplaceID=item.StructureItemID;
                    par.CMN_CAL_CalendarInstance_RefID = item.CMN_CAL_CalendarInstance_RefID;
                    cls_Delete_WorkPlace.Invoke(Connection,Transaction,par);
                }
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5CM_DCSFL_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5CM_DCSFL_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CM_DCSFL_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CM_DCSFL_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_DeleteCompanyStructureForItemList(P_L5CM_DCSFL_1545 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Base result = cls_DeleteCompanyStructureForItemList.Invoke(connectionString,P_L5CM_DCSFL_1545 Parameter,securityTicket);
	 return result;
}
*/