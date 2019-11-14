/* 
 * Generated on 12/2/2014 9:30:44 AM
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

namespace CL3_BusinessTasks.Complex.Manipulation
{
	/// <summary>
	/// 
	/// <example>
	/// string connectionString = ...;
	/// var result = cls_Add_BusinessTaskPackage_for_ProjectID.Invoke(connectionString).Result;
	/// </example>
	/// </summary>
	[DataContract]
	public class cls_Add_BusinessTaskPackage_for_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3BT_SBTP_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
			//Guid Project_RefID = Guid.Empty;
			
		   var item = new CL1_TMS_PRO.ORM_TMS_PRO_BusinessTaskPackage();
		
			
			//item.TMS_PRO_BusinessTaskPackageID = new Guid();
			if (Parameter.Project_RefID!=null)
			item.Project_RefID = Parameter.Project_RefID;
			if(Parameter.Label!= null)
			item.Label = Parameter.Label;
			item.Tenant_RefID = securityTicket.TenantID;
			item.IsDeleted = false;
			
			item.Save(Connection, Transaction);

			return returnValue;


			
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3BT_SBTP_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3BT_SBTP_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BT_SBTP_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BT_SBTP_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Add_BusinessTaskPackage_for_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BT_SBTP_1530 for attribute P_L3BT_SBTP_1530
		[DataContract]
		public class P_L3BT_SBTP_1530 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_BusinessTaskPackageID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public String Label { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_BusinessTaskPackage_for_ProjectID(,P_L3BT_SBTP_1530 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_BusinessTaskPackage_for_ProjectID.Invoke(connectionString,P_L3BT_SBTP_1530 Parameter,securityTicket);
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
var parameter = new CL3_BusinessTasks.Complex.Manipulation.P_L3BT_SBTP_1530();
parameter.TMS_PRO_BusinessTaskPackageID = ...;
parameter.Project_RefID = ...;
parameter.Label = ...;
parameter.IsDeleted = ...;

*/
