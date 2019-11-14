/* 
 * Generated on 1/29/2015 8:20:33 PM
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
using CL1_MRS_MPT;
using CL1_MRS_RUN;
using CL1_MRS_RUT;

namespace CL6_MRMS_Backoffice.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Reading_Session.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Reading_Session
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L6MRMS_DRS_2138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();

            var run = ORM_MRS_RUN_MeasurementRun.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                MRS_RUN_MeasurementRunID = Parameter.ReadingSessionId,
                IsDeleted = false
            }).Single();

            ORM_MRS_RUN_MeasurementRun_Route.Query.SoftDelete(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_Route.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID
            });
        
            var measurements = ORM_MRS_RUN_Measurement.Query.SoftDelete(Connection, Transaction, new ORM_MRS_RUN_Measurement.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID
            });

            ORM_MRS_RUN_MeasurementRun_StatusHistory.Query.SoftDelete(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_StatusHistory.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID
                });

            run.IsDeleted = true;
            run.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L6MRMS_DRS_2138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L6MRMS_DRS_2138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MRMS_DRS_2138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MRMS_DRS_2138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Reading_Session",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6MRMS_DRS_2138 for attribute P_L6MRMS_DRS_2138
		[DataContract]
		public class P_L6MRMS_DRS_2138 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReadingSessionId { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_Reading_Session(,P_L6MRMS_DRS_2138 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_Reading_Session.Invoke(connectionString,P_L6MRMS_DRS_2138 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Complex.Manipulation.P_L6MRMS_DRS_2138();
parameter.ReadingSessionId = ...;

*/
