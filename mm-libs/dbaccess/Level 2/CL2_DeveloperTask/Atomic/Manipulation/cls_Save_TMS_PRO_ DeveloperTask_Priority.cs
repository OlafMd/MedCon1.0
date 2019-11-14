/* 
 * Generated on 10/7/2014 1:48:04 PM
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
namespace CL2_DeveloperTask.Atomic.Manipulation
{
	/// <summary>
	/// 
	/// <example>
	/// string connectionString = ...;
	/// var result = cls_Save_TMS_PRO_DeveloperTask_Priority.Invoke(connectionString).Result;
	/// </example>
	/// </summary>
	[DataContract]
	public class cls_Save_TMS_PRO_DeveloperTask_Priority
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2DTP_SDTP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
			var item = new CL1_TMS_PRO.ORM_TMS_PRO_DeveloperTask_Priority();
			if (Parameter.TMS_PRO_DeveloperTask_PriorityID != Guid.Empty)
			{
                //ORM_TMS_PRO_DeveloperTask_Priority.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask_Priority.Query()
                //{
                //    Tenant_RefID = securityTicket.TenantID,
                //    IsDeleted = false,
                //    TMS_PRO_DeveloperTask_PriorityID = Parameter.TMS_PRO_DeveloperTask_PriorityID
                //});
				var result = item.Load(Connection, Transaction, Parameter.TMS_PRO_DeveloperTask_PriorityID);
				if (result.Status != FR_Status.Success || item.TMS_PRO_DeveloperTask_PriorityID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
					return error;
				}
			}

			if (Parameter.IsDeleted == true || Parameter.IfDeleteReplaceWith != Guid.Empty)
			{

				CL1_TMS_PRO.ORM_TMS_PRO_DeveloperTask.Query searchQuery = new CL1_TMS_PRO.ORM_TMS_PRO_DeveloperTask.Query();
				searchQuery.DeveloperTask_Type_RefID = Parameter.TMS_PRO_DeveloperTask_PriorityID;

				CL1_TMS_PRO.ORM_TMS_PRO_DeveloperTask.Query updateQuery = new CL1_TMS_PRO.ORM_TMS_PRO_DeveloperTask.Query();
				updateQuery.DeveloperTask_Type_RefID = Parameter.IfDeleteReplaceWith;

				CL1_TMS_PRO.ORM_TMS_PRO_DeveloperTask.Query.Update(Connection, Transaction, searchQuery, updateQuery);

				item.IsDeleted = true;
				item.Save(Connection, Transaction);

			   //cls_Update_TMS_PRO_DTPriorityLevels_for_TenantID.Invoke(Connection, Transaction, securityTicket);

				return new FR_Guid(item.TMS_PRO_DeveloperTask_PriorityID);
			}
			if (Parameter.TMS_PRO_DeveloperTask_PriorityID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
				item.IsPersistent = true;
			}
			if(Parameter.Label!=null)
			{
				item.Label = Parameter.Label;
			}
			if (Parameter.Description != null)
			{
				item.Description = Parameter.Description;
			}
			if (Parameter.IconLocationURL != null)
			{
				item.IconLocationURL = Parameter.IconLocationURL;
			}
			if (Parameter.Groups != null)
			{
				item.Groups = Parameter.Groups;
			}
			item.PriorityLevel = (int)Parameter.PriorityLevel;
			if (Parameter.Priority_Colour != null)
			{
				item.Priority_Colour = Parameter.Priority_Colour;
			}
			return new FR_Guid(item.Save(Connection, Transaction), item.TMS_PRO_DeveloperTask_PriorityID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2DTP_SDTP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2DTP_SDTP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2DTP_SDTP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2DTP_SDTP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_PRO_DeveloperTask_Priority",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2DTP_SDTP_1431 for attribute P_L2DTP_SDTP_1431
		[DataContract]
		public class P_L2DTP_SDTP_1431 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTask_PriorityID { get; set; } 
			[DataMember]
			public String IconLocationURL { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public String Groups { get; set; } 
			[DataMember]
			public long PriorityLevel { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsPersistent { get; set; } 
			[DataMember]
			public String Priority_Colour { get; set; } 
			[DataMember]
			public Guid IfDeleteReplaceWith { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TMS_PRO_DeveloperTask_Priority(,P_L2DTP_SDTP_1431 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TMS_PRO_DeveloperTask_Priority.Invoke(connectionString,P_L2DTP_SDTP_1431 Parameter,securityTicket);
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
var parameter = new CL2_DeveloperTask.Atomic.Manipulation.P_L2DTP_SDTP_1431();
parameter.TMS_PRO_DeveloperTask_PriorityID = ...;
parameter.IconLocationURL = ...;
parameter.Label = ...;
parameter.Description = ...;
parameter.Groups = ...;
parameter.PriorityLevel = ...;
parameter.Creation_Timestamp = ...;
parameter.IsDeleted = ...;
parameter.IsPersistent = ...;
parameter.Priority_Colour = ...;
parameter.IfDeleteReplaceWith = ...;
parameter.GlobalPropertyMatchingID = ...;

*/
