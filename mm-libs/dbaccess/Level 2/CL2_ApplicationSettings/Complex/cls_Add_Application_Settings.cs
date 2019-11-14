/* 
 * Generated on 1/31/2014 4:54:04 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN;

namespace CL2_ApplicationSettings.Complex
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_Application_Settings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_Application_Settings
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2AS_AAS_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            foreach (var item in Parameter.Settings)
            {

                ORM_CMN_Tenant_ApplicationSettings_Definition.Query definitionExistsQuery = new ORM_CMN_Tenant_ApplicationSettings_Definition.Query()
                {
                    ApplicationID = Parameter.ApplicationID,
                    Tenant_RefID = securityTicket.TenantID,
                    ItemKey = item.SettingsName,
                    IsDeleted = false
                };

                // Check if settings definition exists
                var tenantApplicationSettingsDefinition = new ORM_CMN_Tenant_ApplicationSettings_Definition();


                if (ORM_CMN_Tenant_ApplicationSettings_Definition.Query.Exists(Connection, Transaction, definitionExistsQuery))
                {
                    tenantApplicationSettingsDefinition = ORM_CMN_Tenant_ApplicationSettings_Definition.Query.Search(Connection, Transaction, definitionExistsQuery).Single();
                }
                else
                {
                    tenantApplicationSettingsDefinition.CMN_Tenant_ApplicationSettings_DefinitionsID = Guid.NewGuid();
                }

                tenantApplicationSettingsDefinition.ApplicationID = Parameter.ApplicationID;
                tenantApplicationSettingsDefinition.ItemKey = item.SettingsName;
                tenantApplicationSettingsDefinition.Tenant_RefID = securityTicket.TenantID;
                tenantApplicationSettingsDefinition.Creation_Timestamp = DateTime.Now;

                tenantApplicationSettingsDefinition.Save(Connection, Transaction);



                ORM_CMN_Tenant_ApplicationSetting.Query settingsQuery = new ORM_CMN_Tenant_ApplicationSetting.Query()
                {
                    ApplicationSettings_Definition_RefID = tenantApplicationSettingsDefinition.CMN_Tenant_ApplicationSettings_DefinitionsID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                };

                // Check if settings value for definition exists
                var tenantApplicationSettings = new ORM_CMN_Tenant_ApplicationSetting();

                if (ORM_CMN_Tenant_ApplicationSetting.Query.Exists(Connection, Transaction, settingsQuery))
                {
                    tenantApplicationSettings = ORM_CMN_Tenant_ApplicationSetting.Query.Search(Connection, Transaction, settingsQuery).Single();
                }
                else
                {
                    tenantApplicationSettings.CMN_Tenant_ApplicationSettingsID = Guid.NewGuid();
                }

                tenantApplicationSettings.ApplicationSettings_Definition_RefID = tenantApplicationSettingsDefinition.CMN_Tenant_ApplicationSettings_DefinitionsID;
                tenantApplicationSettings.ItemValue = item.SettingsValue;
                tenantApplicationSettings.Creation_Timestamp = DateTime.Now;
                tenantApplicationSettings.Tenant_RefID = securityTicket.TenantID;
                tenantApplicationSettings.Save(Connection, Transaction);

            }
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2AS_AAS_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2AS_AAS_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AS_AAS_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AS_AAS_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Add_Application_Settings",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2AS_AAS_1631 for attribute P_L2AS_AAS_1631
		[DataContract]
		public class P_L2AS_AAS_1631 
		{
			[DataMember]
			public P_L2AS_AAS_1631a[] Settings { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion
		#region SClass P_L2AS_AAS_1631a for attribute Settings
		[DataContract]
		public class P_L2AS_AAS_1631a 
		{
			//Standard type parameters
			[DataMember]
			public String SettingsName { get; set; } 
			[DataMember]
			public String SettingsValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_Application_Settings(,P_L2AS_AAS_1631 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_Application_Settings.Invoke(connectionString,P_L2AS_AAS_1631 Parameter,securityTicket);
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
var parameter = new CL2_ApplicationSettings.Complex.P_L2AS_AAS_1631();
parameter.Settings = ...;

parameter.ApplicationID = ...;

*/
