/* 
 * Generated on 5/29/2014 1:15:57 PM
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

namespace CL2_FiscalYear.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Current_FiscalYear.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Current_FiscalYear
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_GCFY_1310 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L2_GCFY_1310();
			
            DateTime currentDate = DateTime.Now.Date;

            var fyParam = new CL2_FiscalYear.Atomic.Retrieval.P_L2_GFYfD_1307
            {
                ComparingDate = currentDate
            };

            var result = CL2_FiscalYear.Atomic.Retrieval.cls_Get_FiscalYear_for_Date.Invoke(Connection, Transaction, fyParam, securityTicket).Result;

            returnValue.Result = new L2_GCFY_1310
            {
                ACC_FiscalYearID = result.ACC_FiscalYearID,
                FiscalYearName = result.FiscalYearName,
                StartDate = result.StartDate,
                EndDate = result.EndDate
            };

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2_GCFY_1310 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_GCFY_1310 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_GCFY_1310 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_GCFY_1310 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_GCFY_1310 functionReturn = new FR_L2_GCFY_1310();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Current_FiscalYear",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_GCFY_1310 : FR_Base
	{
		public L2_GCFY_1310 Result	{ get; set; }

		public FR_L2_GCFY_1310() : base() {}

		public FR_L2_GCFY_1310(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2_GCFY_1310 for attribute L2_GCFY_1310
		[DataContract]
		public class L2_GCFY_1310 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_FiscalYearID { get; set; } 
			[DataMember]
			public String FiscalYearName { get; set; } 
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_GCFY_1310 cls_Get_Current_FiscalYear(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_GCFY_1310 invocationResult = cls_Get_Current_FiscalYear.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

