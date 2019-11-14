/* 
 * Generated on 12/5/2014 4:13:28 PM
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
using CL1_TMS_PRO;
using CL1_CMN_BPT;
using CL1_CMN_PRO;

namespace CL6_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    ///  
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DeveloperTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DeveloperTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_SDT_1700 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
           

            if(Parameter.Delete){
                //DELETING DEV TASK
                ORM_TMS_PRO_DeveloperTask developerTaskToDelete = ORM_TMS_PRO_DeveloperTask.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask.Query() { 
                    TMS_PRO_DeveloperTaskID = Parameter.DeveloperTaskID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                developerTaskToDelete.IsDeleted = true;
                developerTaskToDelete.Save(Connection, Transaction);
                //DELETING FEATURE 2 TAG
                ORM_TMS_PRO_Feature_2_DeveloperTask Feature_2_DeveloperTask2Delete = ORM_TMS_PRO_Feature_2_DeveloperTask.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Feature_2_DeveloperTask.Query() { 
                    DeveloperTask_RefID = Parameter.DeveloperTaskID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                Feature_2_DeveloperTask2Delete.IsDeleted = true;
                Feature_2_DeveloperTask2Delete.Save(Connection, Transaction);

                //DELETING STATUS HISTORY
                var statusHistory2Delete = ORM_TMS_PRO_DeveloperTask_StatusHistory.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask_StatusHistory.Query()
                { DeveloperTask_RefID = Parameter.DeveloperTaskID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                foreach (var history in statusHistory2Delete)
                {
                    history.IsDeleted = true;
                    history.Save(Connection, Transaction);
                    
                }
                //DELETING DEV TASK 2 TAG
                var developerTask2Tags = ORM_TMS_PRO_DeveloperTask_2_Tag.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask_2_Tag.Query() 
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    DeveloperTask_RefID = Parameter.DeveloperTaskID
                }
                );

                foreach(var developerTask2Tag in developerTask2Tags){
                    developerTask2Tag.IsDeleted = true;
                    developerTask2Tag.Save(Connection,Transaction);
                }
                //DELETING PRODUCT RELEASES 2 DEV TASK
                var productReleases2DevTask = ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    TMS_PRO_DeveloperTask_RefID = Parameter.DeveloperTaskID
                });
                foreach (var productRelease in productReleases2DevTask)
                {
                    productRelease.IsDeleted = true;
                    productRelease.Save(Connection, Transaction);
                }
                //DELETING DEV TASK INVOLVEMENTS
                var involment_query = new ORM_TMS_PRO_DeveloperTask_Involvement.Query();
                involment_query.DeveloperTask_RefID = Parameter.DeveloperTaskID;
                involment_query.Tenant_RefID = securityTicket.TenantID;
                involment_query.IsDeleted = false;

                var involments = ORM_TMS_PRO_DeveloperTask_Involvement.Query.Search(Connection, Transaction, involment_query);
                foreach (var involment in involments)
                {

                    var dtinv_query = new ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime.Query();
                    dtinv_query.TMS_PRO_DeveloperTask_Involvement_RefID = involment.TMS_PRO_DeveloperTask_InvolvementID;
                    dtinv_query.IsDeleted = false;

                    var dtinv = ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime.Query.Search(Connection, Transaction, dtinv_query);

                    foreach (var dt in dtinv)
                    {

                        dt.IsDeleted = true;
                        dt.Save(Connection, Transaction);

                        var inv_query = new ORM_CMN_BPT_InvestedWorkTime.Query();
                        inv_query.CMN_BPT_InvestedWorkTimeID = dt.CMN_BPT_InvestedWorkTime_RefID;
                        inv_query.IsDeleted = false;

                        ORM_CMN_BPT_InvestedWorkTime.Query.SoftDelete(Connection, Transaction, inv_query);
                    }

                }
                //DELETING RECOMENDATIONS
                var devTaskRecomentations = ORM_TMS_PRO_DeveloperTask_Recommendation.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask_Recommendation.Query() {
                
                    DeveloperTask_RefID = Parameter.DeveloperTaskID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
                foreach (var devTaskRecomendation in devTaskRecomentations)
                {
                    devTaskRecomendation.IsDeleted = true;
                    devTaskRecomendation.Save(Connection,Transaction);
                }
                //deleting peers development
                var peersDevelopment = ORM_TMS_PRO_Peers_Development.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Peers_Development.Query()
                {
                    DeveloperTask_RefID = Parameter.DeveloperTaskID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                foreach (var item in peersDevelopment)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }
                returnValue.Result = Parameter.DeveloperTaskID;
            }
            if (Parameter.Archive)
            {
                ORM_TMS_PRO_DeveloperTask developerTaskToArchive = ORM_TMS_PRO_DeveloperTask.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask.Query()
                {
                    TMS_PRO_DeveloperTaskID = Parameter.DeveloperTaskID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                developerTaskToArchive.IsArchived = true;
                developerTaskToArchive.Save(Connection,Transaction);
            }
			
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_SDT_1700 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_SDT_1700 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_SDT_1700 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_SDT_1700 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DeveloperTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_SDT_1700 for attribute P_L6DT_SDT_1700
		[DataContract]
		public class P_L6DT_SDT_1700 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 
			[DataMember]
			public Boolean Delete { get; set; } 
			[DataMember]
			public Boolean Archive { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DeveloperTask(,P_L6DT_SDT_1700 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DeveloperTask.Invoke(connectionString,P_L6DT_SDT_1700 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Complex.Manipulation.P_L6DT_SDT_1700();
parameter.DeveloperTaskID = ...;
parameter.Delete = ...;
parameter.Archive = ...;

*/
