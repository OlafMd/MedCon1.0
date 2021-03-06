/* 
 * Generated on 8/26/2013 1:42:57 PM
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
using CL1_CMN_CAL;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Office.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Office.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Office
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_DO_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();

            ORM_CMN_STR_Office whereInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_Office>();
            whereInstance.CMN_STR_OfficeID = Parameter.CMN_STR_OfficeID;
            int result = CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstance);

            ORM_CMN_CAL_CalendarInstance CalendarWhereInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_CalendarInstance>();
            CalendarWhereInstance.CMN_CAL_CalendarInstanceID = Parameter.CMN_CAL_CalendarInstance_RefID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, CalendarWhereInstance);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5OF_DO_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5OF_DO_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_DO_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_DO_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Base cls_Delete_Office(P_L5OF_DO_0952 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Base result = cls_Delete_Office.Invoke(connectionString,P_L5OF_DO_0952 Parameter,securityTicket);
	 return result;
}
*/