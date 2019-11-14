/* 
 * Generated on 12/4/2014 2:09:03 PM
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
using CL3_Tags.Atomic.Retrieval;

namespace CL3_Tags.Complex.Manipulation
{
	/// <summary>
	/// 
	/// <example>
	/// string connectionString = ...;
	/// var result = cls_Delete_Tag_for_ProjectID.Invoke(connectionString).Result;
	/// </example>
	/// </summary>
	[DataContract]
	public class cls_Delete_Tag_for_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3TG_DTGP_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            List<Guid> tagrefId = new List<Guid>();

            foreach (var tag in Parameter.TagValue)
            {
                var Tag = ORM_TMS_PRO_Tags.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Tags.Query()
                {
                    TagValue = tag,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).FirstOrDefault();
                tagrefId.Add(Tag.TMS_PRO_TagID);
            }
            
            ORM_TMS_PRO_Project_2_Tag.Query tag2ProjectQuery = new ORM_TMS_PRO_Project_2_Tag.Query();

            foreach (var id in tagrefId)
            {

                tag2ProjectQuery.Project_RefID = Parameter.Project_RefID;
                tag2ProjectQuery.Tag_RefID = id;
                tag2ProjectQuery.IsDeleted = false;
                tag2ProjectQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_TMS_PRO_Project_2_Tag.Query.SoftDelete(Connection, Transaction, tag2ProjectQuery);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3TG_DTGP_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3TG_DTGP_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TG_DTGP_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TG_DTGP_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Tag_for_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3TG_DTGP_1151 for attribute P_L3TG_DTGP_1151
		[DataContract]
		public class P_L3TG_DTGP_1151 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_TagID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public String[] TagValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_Tag_for_ProjectID(,P_L3TG_DTGP_1151 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_Tag_for_ProjectID.Invoke(connectionString,P_L3TG_DTGP_1151 Parameter,securityTicket);
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
var parameter = new CL3_Tags.Complex.Manipulation.P_L3TG_DTGP_1151();
parameter.TMS_PRO_TagID = ...;
parameter.Project_RefID = ...;
parameter.TagValue = ...;

*/
