/* 
 * Generated on 04.03.2015 14:19:23
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
using CL1_HEC_CMT;

namespace CL5_MPC_Community.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Join_PrivateGroup.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Join_PrivateGroup
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MC_JPG_1356 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_JPG_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5MC_JPG_1356();
            returnValue.Result = new L5MC_JPG_1356();

            var group = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, new ORM_HEC_CMT_CommunityGroup.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                IsPrivate = true,
                CommunityGroupCode = Parameter.GroupCode
            }).SingleOrDefault();

            if (group != null)
            {
                returnValue.Result.Group = new L5MC_JPG_1356_Group()
                {
                    HEC_CMT_CommunityGroupID = group.HEC_CMT_CommunityGroupID
                };

                var posibleCurrentAssignment = ORM_HEC_CMT_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_GroupSubscription.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Membership_RefID = Parameter.HEC_CMT_MembershipID,
                    CommunityGroup_RefID = group.HEC_CMT_CommunityGroupID
                }).ToArray();

                if (posibleCurrentAssignment.Length == 0)
                {
                    var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        IsCommunityOperatedByThisTenant = true
                    }).Single();

                    var m2g = new ORM_HEC_CMT_GroupSubscription()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        Membership_RefID = Parameter.HEC_CMT_MembershipID,
                        CommunityGroup_RefID = group.HEC_CMT_CommunityGroupID,
                        HEC_CMT_GroupSubscriptionID = Guid.NewGuid()
                    };
                    m2g.Save(Connection, Transaction);

                    var query = new ORM_HEC_CMT_OfferedRole.Query();
                    query.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
                    query.IsDeleted = false;
                    query.Tenant_RefID = securityTicket.TenantID;

                    var role = ORM_HEC_CMT_OfferedRole.Query.Search(Connection, Transaction, query).Single();

                    var r2gs = new ORM_HEC_CMT_OfferedRoles_2_GroupSubscription()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        AssignmentID = Guid.NewGuid(),
                        HEC_CMT_GroupSubscription_RefID = m2g.HEC_CMT_GroupSubscriptionID,
                        HEC_CMT_OfferedRole_RefID = role.HEC_CMT_OfferedRoleID
                    };
                    r2gs.Save(Connection, Transaction);

                    returnValue.Result.Group.Success = true;
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MC_JPG_1356 Invoke(string ConnectionString,P_L5MC_JPG_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MC_JPG_1356 Invoke(DbConnection Connection,P_L5MC_JPG_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MC_JPG_1356 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_JPG_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MC_JPG_1356 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_JPG_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MC_JPG_1356 functionReturn = new FR_L5MC_JPG_1356();
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

				throw new Exception("Exception occured in method cls_Join_PrivateGroup",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5MC_JPG_1356_raw 
	{
		public Guid HEC_CMT_CommunityGroupID; 
		public bool Success; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5MC_JPG_1356[] Convert(List<L5MC_JPG_1356_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5MC_JPG_1356 in gfunct_rawResult.ToArray()
	group el_L5MC_JPG_1356 by new 
	{ 
	}
	into gfunct_L5MC_JPG_1356
	select new L5MC_JPG_1356
	{     
		Group = 
		(
			from el_Group in gfunct_L5MC_JPG_1356.ToArray()
			select new L5MC_JPG_1356_Group
			{     
				HEC_CMT_CommunityGroupID = el_Group.HEC_CMT_CommunityGroupID,
				Success = el_Group.Success,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5MC_JPG_1356 : FR_Base
	{
		public L5MC_JPG_1356 Result	{ get; set; }

		public FR_L5MC_JPG_1356() : base() {}

		public FR_L5MC_JPG_1356(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MC_JPG_1356 for attribute P_L5MC_JPG_1356
		[DataContract]
		public class P_L5MC_JPG_1356 
		{
			//Standard type parameters
			[DataMember]
			public string GroupCode { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5MC_JPG_1356 for attribute L5MC_JPG_1356
		[DataContract]
		public class L5MC_JPG_1356 
		{
			[DataMember]
			public L5MC_JPG_1356_Group Group { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5MC_JPG_1356_Group for attribute Group
		[DataContract]
		public class L5MC_JPG_1356_Group 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public bool Success { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MC_JPG_1356 cls_Join_PrivateGroup(,P_L5MC_JPG_1356 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MC_JPG_1356 invocationResult = cls_Join_PrivateGroup.Invoke(connectionString,P_L5MC_JPG_1356 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5MC_JPG_1356();
parameter.GroupCode = ...;
parameter.HEC_CMT_MembershipID = ...;
parameter.GlobalPropertyMatchingID = ...;

*/
