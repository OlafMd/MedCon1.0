/* 
 * Generated on 10/14/2013 12:18:29 PM
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
using CL1_USR;

namespace CL2_ApplicationSettings.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_USR_Account_ApplicationSetting.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_USR_Account_ApplicationSetting
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2USR_SAS_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_USR_Account_ApplicationSetting();
			if (Parameter.USR_Account_ApplicationSettingID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.USR_Account_ApplicationSettingID);
			    if (result.Status != FR_Status.Success || item.USR_Account_ApplicationSettingID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.USR_Account_ApplicationSettingID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.USR_Account_ApplicationSettingID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Account_RefID = Parameter.Account_RefID;
			item.ApplicationSetting_Definition_RefID = Parameter.ApplicationSetting_Definition_RefID;
			item.ItemValue = Parameter.ItemValue;
			


			return new FR_Guid(item.Save(Connection, Transaction),item.USR_Account_ApplicationSettingID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2USR_SAS_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2USR_SAS_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2USR_SAS_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2USR_SAS_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_USR_Account_ApplicationSetting",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2USR_SAS_1039 for attribute P_L2USR_SAS_1039
		[DataContract]
		public class P_L2USR_SAS_1039 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_Account_ApplicationSettingID { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public Guid ApplicationSetting_Definition_RefID { get; set; } 
			[DataMember]
			public String ItemValue { get; set; } 
			[DataMember]
			public Guid Audit_UpdatedByAccount_RefID { get; set; } 
			[DataMember]
			public String Audit_UpdatedOn { get; set; } 
			[DataMember]
			public Guid Audit_CreatedByAccount_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_USR_Account_ApplicationSetting(,P_L2USR_SAS_1039 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_USR_Account_ApplicationSetting.Invoke(connectionString,P_L2USR_SAS_1039 Parameter,securityTicket);
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
var parameter = new CL2_ApplicationSettings.Atomic.Manipulation.P_L2USR_SAS_1039();
parameter.USR_Account_ApplicationSettingID = ...;
parameter.Account_RefID = ...;
parameter.ApplicationSetting_Definition_RefID = ...;
parameter.ItemValue = ...;
parameter.Audit_UpdatedByAccount_RefID = ...;
parameter.Audit_UpdatedOn = ...;
parameter.Audit_CreatedByAccount_RefID = ...;
parameter.IsDeleted = ...;

*/