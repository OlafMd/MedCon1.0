/* 
 * Generated on 12/4/2014 1:58:13 PM
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

namespace CL3_Project.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Admin_Project_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Admin_Project_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DPFT_DPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
   
			var returnValue = new FR_Guid();
			var item = new CL1_TMS_PRO.ORM_TMS_PRO_Project();
			if (Parameter.TMS_PRO_ProjectID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.TMS_PRO_ProjectID);
			    if (result.Status != FR_Status.Success || item.TMS_PRO_ProjectID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No such ID";
			        error.Status = FR_Status.Error_Internal;
			        return error;
			    }
			}
			returnValue = new FR_Guid(item.Save(Connection, Transaction), item.TMS_PRO_ProjectID);
			ORM_TMS_PRO_Project.Query query = new ORM_TMS_PRO_Project.Query();
			query.TMS_PRO_ProjectID = item.TMS_PRO_ProjectID;
            item.IsDeleted = true;
			ORM_TMS_PRO_Project.Query.SoftDelete(Connection, Transaction, query);
           
            #region Delete ORM_TMS_PRO_BusinessTask
            ORM_TMS_PRO_BusinessTask.Query ORM_TMS_PRO_BusinessTaskquery = new ORM_TMS_PRO_BusinessTask.Query();
            ORM_TMS_PRO_BusinessTaskquery.Project_RefID = Parameter.TMS_PRO_ProjectID;
            ORM_TMS_PRO_BusinessTaskquery.IsArchived = false;
            ORM_TMS_PRO_BusinessTaskquery.IsDeleted = false;
            ORM_TMS_PRO_BusinessTask.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_BusinessTaskquery);
           
            #endregion

            #region Delete ORM_TMS_PRO_BusinessTaskPackage

            ORM_TMS_PRO_BusinessTaskPackage.Query ORM_TMS_PRO_BusinessTaskPackagequery = new ORM_TMS_PRO_BusinessTaskPackage.Query();
            ORM_TMS_PRO_BusinessTaskPackagequery.Project_RefID = Parameter.TMS_PRO_ProjectID;
            ORM_TMS_PRO_BusinessTaskPackagequery.IsDeleted = false;

            ORM_TMS_PRO_BusinessTaskPackage.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_BusinessTaskPackagequery);


            #endregion
            
            #region Delete ORM_TMS_PRO_ProjectMember

            var ORM_TMS_PRO_ProjectMemberquery = new ORM_TMS_PRO_ProjectMember.Query();
            ORM_TMS_PRO_ProjectMemberquery.IsDeleted = true;
            ORM_TMS_PRO_ProjectMemberquery.Project_RefID = Parameter.TMS_PRO_ProjectID;

            ORM_TMS_PRO_ProjectMember.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_ProjectMemberquery);

            #endregion
            
            #region Delete ORM_TMS_PRO_BussinessTask_2_Feature
            var ORM_TMS_PRO_BussinessTask_2_Featurequery = new ORM_TMS_PRO_BusinessTask_2_Feature.Query();
            ORM_TMS_PRO_BussinessTask_2_Featurequery.Feature_RefID = Parameter.TMS_PRO_ProjectID;
            ORM_TMS_PRO_BussinessTask_2_Featurequery.IsDeleted = true;
            ORM_TMS_PRO_BusinessTask_2_Feature.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_BussinessTask_2_Featurequery);
            
            #endregion

            #region Delete ORM_TMS_PRO_Features
            var ORM_TMS_PRO_Featuresquery = new ORM_TMS_PRO_Feature.Query();
            ORM_TMS_PRO_Featuresquery.TMS_PRO_FeatureID = Parameter.TMS_PRO_ProjectID;
            ORM_TMS_PRO_Featuresquery.IsDeleted = true;
            ORM_TMS_PRO_Feature.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_Featuresquery);

            #endregion
            #region Delete ORM_TMS_DeveloperTasks
            var ORM_TMS_Developertaskquery = new ORM_TMS_PRO_DeveloperTask.Query();
            ORM_TMS_Developertaskquery.TMS_PRO_DeveloperTaskID = Parameter.TMS_PRO_ProjectID;
            ORM_TMS_Developertaskquery.IsDeleted = true;
            ORM_TMS_PRO_DeveloperTask.Query.SoftDelete(Connection, Transaction, ORM_TMS_Developertaskquery);
            #endregion






            return returnValue;
			
			
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DPFT_DPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DPFT_DPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DPFT_DPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DPFT_DPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Admin_Project_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DPFT_DPN_1100 for attribute P_L3DPFT_DPN_1100
		[DataContract]
		public class P_L3DPFT_DPN_1100 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ProjectID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_Admin_Project_for_Tenant(,P_L3DPFT_DPN_1100 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_Admin_Project_for_Tenant.Invoke(connectionString,P_L3DPFT_DPN_1100 Parameter,securityTicket);
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
var parameter = new CL3_Project.Complex.Manipulation.P_L3DPFT_DPN_1100();
parameter.TMS_PRO_ProjectID = ...;
parameter.IsDeleted = ...;

*/
