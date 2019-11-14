/* 
 * Generated on 10/13/2014 9:23:10 AM
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
using CL1_OCL;

namespace CL2_OrderCollective.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OCL_OrderCollective_Member.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OCL_OrderCollective_Member
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2OC_SOCM_0922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_OCL_OrderCollective_Member();
			if (Parameter.OCL_OrderCollective_MemberID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.OCL_OrderCollective_MemberID);
			    if (result.Status != FR_Status.Success || item.OCL_OrderCollective_MemberID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.OCL_OrderCollective_MemberID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.OCL_OrderCollective_MemberID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.OrderCollective_RefID = Parameter.OrderCollective_RefID;
			item.OrderCollectiveMemberITL = Parameter.OrderCollectiveMemberITL;
			item.IsOrderCollectiveLead = Parameter.IsOrderCollectiveLead;
			item.BusinessParticipant_RefID = Parameter.BusinessParticipant_RefID;
			item.MemberSince = Parameter.MemberSince;
			item.EndOfMembership = Parameter.EndOfMembership;
			item.Modification_Timestamp = Parameter.Modification_Timestamp;

			return new FR_Guid(item.Save(Connection, Transaction),item.OCL_OrderCollective_MemberID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2OC_SOCM_0922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2OC_SOCM_0922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2OC_SOCM_0922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2OC_SOCM_0922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_OCL_OrderCollective_Member",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2OC_SOCM_0922 for attribute P_L2OC_SOCM_0922
		[DataContract]
		public class P_L2OC_SOCM_0922 
		{
			//Standard type parameters
			[DataMember]
			public Guid OCL_OrderCollective_MemberID { get; set; } 
			[DataMember]
			public Guid OrderCollective_RefID { get; set; } 
			[DataMember]
			public String OrderCollectiveMemberITL { get; set; } 
			[DataMember]
			public Boolean IsOrderCollectiveLead { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public DateTime MemberSince { get; set; } 
			[DataMember]
			public DateTime EndOfMembership { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_OCL_OrderCollective_Member(,P_L2OC_SOCM_0922 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_OCL_OrderCollective_Member.Invoke(connectionString,P_L2OC_SOCM_0922 Parameter,securityTicket);
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
var parameter = new CL2_OrderCollective.Atomic.Manipulation.P_L2OC_SOCM_0922();
parameter.OCL_OrderCollective_MemberID = ...;
parameter.OrderCollective_RefID = ...;
parameter.OrderCollectiveMemberITL = ...;
parameter.IsOrderCollectiveLead = ...;
parameter.BusinessParticipant_RefID = ...;
parameter.MemberSince = ...;
parameter.EndOfMembership = ...;
parameter.IsDeleted = ...;
parameter.Modification_Timestamp = ...;

*/
