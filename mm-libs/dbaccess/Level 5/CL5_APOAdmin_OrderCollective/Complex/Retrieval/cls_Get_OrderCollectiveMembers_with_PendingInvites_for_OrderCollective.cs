/* 
 * Generated on 10/22/2014 1:28:41 PM
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
using CL3_OrderCollective.Atomic.Retrieval;

namespace CL5_APOAdmin_OrderCollective.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OrderCollectiveMembers_with_PendingInvites_for_OrderCollective.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrderCollectiveMembers_with_PendingInvites_for_OrderCollective
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OC_GOCMwPIfOC_0903_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OC_GOCMwPIfOC_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5OC_GOCMwPIfOC_0903_Array();
            var result = new List<L5OC_GOCMwPIfOC_0903>();

            #region Load Order Collective Members
            var orderCollectiveMembers = cls_Get_OrderCollectiveMembers_for_OrderCollective.Invoke(
                Connection, 
                Transaction,
                new P_L3OC_GOCMfOC_1329() 
                {
                    OrderCollectiveID = Parameter.OrderCollectiveId
                }, 
                securityTicket).Result;
            if (orderCollectiveMembers == null || orderCollectiveMembers.Length <= 0)
            {
                returnValue.Result = result.ToArray();
                returnValue.Status = FR_Status.Success;
                return returnValue;
            }
            #endregion

            var members = orderCollectiveMembers.ToList().OrderByDescending(ocm => ocm.IsOrderCollectiveLead);
            foreach (var member in members)
            {
                result.Add(new L5OC_GOCMwPIfOC_0903()
                {
                    IsPendingInvitation = false,
                    OrderCollectiveMember = member,
                    OrderCollectiveInvitation = null
                });
            }

            returnValue.Result = result.ToArray();
            returnValue.Status = FR_Status.Success;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OC_GOCMwPIfOC_0903_Array Invoke(string ConnectionString,P_L5OC_GOCMwPIfOC_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OC_GOCMwPIfOC_0903_Array Invoke(DbConnection Connection,P_L5OC_GOCMwPIfOC_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OC_GOCMwPIfOC_0903_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OC_GOCMwPIfOC_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OC_GOCMwPIfOC_0903_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OC_GOCMwPIfOC_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OC_GOCMwPIfOC_0903_Array functionReturn = new FR_L5OC_GOCMwPIfOC_0903_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrderCollectiveMembers_with_PendingInvites_for_OrderCollective",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OC_GOCMwPIfOC_0903_Array : FR_Base
	{
		public L5OC_GOCMwPIfOC_0903[] Result	{ get; set; } 
		public FR_L5OC_GOCMwPIfOC_0903_Array() : base() {}

		public FR_L5OC_GOCMwPIfOC_0903_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OC_GOCMwPIfOC_0903 for attribute P_L5OC_GOCMwPIfOC_0903
		[DataContract]
		public class P_L5OC_GOCMwPIfOC_0903 
		{
			//Standard type parameters
			[DataMember]
			public Guid OrderCollectiveId { get; set; } 
			[DataMember]
			public bool IsPendingInvitationListIncluded { get; set; } 

		}
		#endregion
		#region SClass L5OC_GOCMwPIfOC_0903 for attribute L5OC_GOCMwPIfOC_0903
		[DataContract]
		public class L5OC_GOCMwPIfOC_0903 
		{
			[DataMember]
			public L5OC_GOCMwPIfOC_0903a OrderCollectiveInvitation { get; set; }

			//Standard type parameters
			[DataMember]
			public bool IsPendingInvitation { get; set; } 
			[DataMember]
			public CL3_OrderCollective.Atomic.Retrieval.L3OC_GOCMfOC_1329 OrderCollectiveMember { get; set; } 

		}
		#endregion
		#region SClass L5OC_GOCMwPIfOC_0903a for attribute OrderCollectiveInvitation
		[DataContract]
		public class L5OC_GOCMwPIfOC_0903a 
		{
			//Standard type parameters
			[DataMember]
			public Guid InvitationId { get; set; } 
			[DataMember]
			public String InvitationEmail { get; set; } 
			[DataMember]
			public String InvitationCode { get; set; } 
			[DataMember]
			public DateTime InvitationSent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OC_GOCMwPIfOC_0903_Array cls_Get_OrderCollectiveMembers_with_PendingInvites_for_OrderCollective(,P_L5OC_GOCMwPIfOC_0903 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OC_GOCMwPIfOC_0903_Array invocationResult = cls_Get_OrderCollectiveMembers_with_PendingInvites_for_OrderCollective.Invoke(connectionString,P_L5OC_GOCMwPIfOC_0903 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_OrderCollective.Complex.Retrieval.P_L5OC_GOCMwPIfOC_0903();
parameter.OrderCollectiveId = ...;
parameter.IsPendingInvitationListIncluded = ...;

*/
