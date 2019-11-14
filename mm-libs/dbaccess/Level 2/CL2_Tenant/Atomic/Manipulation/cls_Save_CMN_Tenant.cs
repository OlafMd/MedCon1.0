/* 
 * Generated on 10/13/2014 11:50:19
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

namespace CL2_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2_ST_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_CMN.ORM_CMN_Tenant();
			if (Parameter.CMN_TenantID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.CMN_TenantID);
			    if (result.Status != FR_Status.Success || item.CMN_TenantID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.CMN_TenantID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.CMN_TenantID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.TenantITL = Parameter.TenantITL;
			item.UniversalContactDetail_RefID = Parameter.UniversalContactDetail_RefID;
			item.CMN_CAL_CalendarInstance_RefID = Parameter.CMN_CAL_CalendarInstance_RefID;
			item.IsUsing_Offices = Parameter.IsUsing_Offices;
			item.IsUsing_WorkAreas = Parameter.IsUsing_WorkAreas;
			item.IsUsing_Workplaces = Parameter.IsUsing_Workplaces;
			item.IsUsing_CostCenters = Parameter.IsUsing_CostCenters;
			item.CMN_BPT_STA_SettingProfile_RefID = Parameter.CMN_BPT_STA_SettingProfile_RefID;
			item.DocumentServerRootURL = Parameter.DocumentServerRootURL;
			item.Customers_DefaultPricelist_RefID = Parameter.Customers_DefaultPricelist_RefID;


			return new FR_Guid(item.Save(Connection, Transaction),item.CMN_TenantID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2_ST_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2_ST_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2_ST_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2_ST_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CMN_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2_ST_1149 for attribute P_L2_ST_1149
		[DataContract]
		public class P_L2_ST_1149 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_TenantID { get; set; } 
			[DataMember]
			public String TenantITL { get; set; } 
			[DataMember]
			public Guid UniversalContactDetail_RefID { get; set; } 
			[DataMember]
			public Guid CMN_CAL_CalendarInstance_RefID { get; set; } 
			[DataMember]
			public Boolean IsUsing_Offices { get; set; } 
			[DataMember]
			public Boolean IsUsing_WorkAreas { get; set; } 
			[DataMember]
			public Boolean IsUsing_Workplaces { get; set; } 
			[DataMember]
			public Boolean IsUsing_CostCenters { get; set; } 
			[DataMember]
			public Guid CMN_BPT_STA_SettingProfile_RefID { get; set; } 
			[DataMember]
			public String DocumentServerRootURL { get; set; } 
			[DataMember]
			public Guid Customers_DefaultPricelist_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_Tenant(,P_L2_ST_1149 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CMN_Tenant.Invoke(connectionString,P_L2_ST_1149 Parameter,securityTicket);
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
var parameter = new CL2_Tenant.Atomic.Manipulation.P_L2_ST_1149();
parameter.CMN_TenantID = ...;
parameter.TenantITL = ...;
parameter.UniversalContactDetail_RefID = ...;
parameter.CMN_CAL_CalendarInstance_RefID = ...;
parameter.IsUsing_Offices = ...;
parameter.IsUsing_WorkAreas = ...;
parameter.IsUsing_Workplaces = ...;
parameter.IsUsing_CostCenters = ...;
parameter.CMN_BPT_STA_SettingProfile_RefID = ...;
parameter.DocumentServerRootURL = ...;
parameter.Customers_DefaultPricelist_RefID = ...;
parameter.IsDeleted = ...;

*/
