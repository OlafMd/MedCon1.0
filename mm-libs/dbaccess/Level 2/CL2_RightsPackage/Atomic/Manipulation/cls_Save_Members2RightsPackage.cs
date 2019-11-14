/* 
 * Generated on 10/23/2014 1:21:43 PM
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
namespace CL2_RightsPackage.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Members2RightsPackage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Members2RightsPackage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2RP_SM2RP_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            var item = new CL1_TMS_PRO.ORM_TMS_PRO_Members_2_RightPackage();
            if (Parameter.AssignmentID != Guid.Empty)
            {
               item= ORM_TMS_PRO_Members_2_RightPackage.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Members_2_RightPackage.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    AssignmentID = Parameter.AssignmentID
                }).SingleOrDefault();
            }
            if (Parameter.AssignmentID == Guid.Empty)
            {
                item.AssignmentID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;
            }
            if (Parameter.isDeleted == true)
            {
                item.IsDeleted = true;
            }
            if (Parameter.ProjectMemberID != Guid.Empty)
            {
                item.ProjectMember_RefID = Parameter.ProjectMemberID;
            }
            if(Parameter.RightsPackageID!=Guid.Empty)
            {
                item.ACC_RightsPackage_RefID = Parameter.RightsPackageID;
            }
            return new FR_Guid(item.Save(Connection, Transaction), item.AssignmentID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2RP_SM2RP_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2RP_SM2RP_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2RP_SM2RP_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2RP_SM2RP_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Members2RightsPackage",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2RP_SM2RP_1318 for attribute P_L2RP_SM2RP_1318
		[DataContract]
		public class P_L2RP_SM2RP_1318 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 
			[DataMember]
			public Guid ProjectMemberID { get; set; } 
			[DataMember]
			public Guid RightsPackageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Members2RightsPackage(,P_L2RP_SM2RP_1318 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Members2RightsPackage.Invoke(connectionString,P_L2RP_SM2RP_1318 Parameter,securityTicket);
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
var parameter = new CL2_RightsPackage.Atomic.Manipulation.P_L2RP_SM2RP_1318();
parameter.AssignmentID = ...;
parameter.isDeleted = ...;
parameter.ProjectMemberID = ...;
parameter.RightsPackageID = ...;

*/
