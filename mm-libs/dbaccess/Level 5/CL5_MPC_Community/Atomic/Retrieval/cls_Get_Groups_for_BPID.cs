/* 
 * Generated on 25.03.2015 15:57:22
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

namespace CL5_MPC_Community.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Groups_for_BPID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Groups_for_BPID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GGfBPID_1747_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GGfBPID_1747 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GGfBPID_1747_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Community.Atomic.Retrieval.SQL.cls_Get_Groups_for_BPID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BPID", Parameter.BPID);



			List<L5AC_GGfBPID_1747_raw> results = new List<L5AC_GGfBPID_1747_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CMT_CommunityGroupID","CommunityGroup_Name_DictID","CommunityGroup_Description_DictID","IsPrivate","CommunityGroupCode","HealthcareCommunityGroupITL","AssignmentID","Role_GlobalPropertyMatchingID","Role_HEC_CMT_OfferedRoleID","HEC_CMT_GroupSubscription_RequestID","Request_GlobalPropertyMatchingID","Request_HEC_CMT_OfferedRoleID" });
				while(reader.Read())
				{
					L5AC_GGfBPID_1747_raw resultItem = new L5AC_GGfBPID_1747_raw();
					//0:Parameter HEC_CMT_CommunityGroupID of type Guid
					resultItem.HEC_CMT_CommunityGroupID = reader.GetGuid(0);
					//1:Parameter CommunityGroup_Name of type Dict
					resultItem.CommunityGroup_Name = reader.GetDictionary(1);
					resultItem.CommunityGroup_Name.SourceTable = "hec_cmt_communitygroups";
					loader.Append(resultItem.CommunityGroup_Name);
					//2:Parameter CommunityGroup_Description of type Dict
					resultItem.CommunityGroup_Description = reader.GetDictionary(2);
					resultItem.CommunityGroup_Description.SourceTable = "hec_cmt_communitygroups";
					loader.Append(resultItem.CommunityGroup_Description);
					//3:Parameter IsPrivate of type bool
					resultItem.IsPrivate = reader.GetBoolean(3);
					//4:Parameter CommunityGroupCode of type string
					resultItem.CommunityGroupCode = reader.GetString(4);
					//5:Parameter HealthcareCommunityGroupITL of type string
					resultItem.HealthcareCommunityGroupITL = reader.GetString(5);
					//6:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(6);
					//7:Parameter Role_GlobalPropertyMatchingID of type string
					resultItem.Role_GlobalPropertyMatchingID = reader.GetString(7);
					//8:Parameter Role_HEC_CMT_OfferedRoleID of type Guid
					resultItem.Role_HEC_CMT_OfferedRoleID = reader.GetGuid(8);
					//9:Parameter HEC_CMT_GroupSubscription_RequestID of type Guid
					resultItem.HEC_CMT_GroupSubscription_RequestID = reader.GetGuid(9);
					//10:Parameter Request_GlobalPropertyMatchingID of type string
					resultItem.Request_GlobalPropertyMatchingID = reader.GetString(10);
					//11:Parameter Request_HEC_CMT_OfferedRoleID of type Guid
					resultItem.Request_HEC_CMT_OfferedRoleID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Groups_for_BPID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AC_GGfBPID_1747_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GGfBPID_1747_Array Invoke(string ConnectionString,P_L5AC_GGfBPID_1747 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GGfBPID_1747_Array Invoke(DbConnection Connection,P_L5AC_GGfBPID_1747 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GGfBPID_1747_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GGfBPID_1747 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GGfBPID_1747_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GGfBPID_1747 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GGfBPID_1747_Array functionReturn = new FR_L5AC_GGfBPID_1747_Array();
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

				throw new Exception("Exception occured in method cls_Get_Groups_for_BPID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AC_GGfBPID_1747_raw 
	{
		public Guid HEC_CMT_CommunityGroupID; 
		public Dict CommunityGroup_Name; 
		public Dict CommunityGroup_Description; 
		public bool IsPrivate; 
		public string CommunityGroupCode; 
		public string HealthcareCommunityGroupITL; 
		public Guid AssignmentID; 
		public string Role_GlobalPropertyMatchingID; 
		public Guid Role_HEC_CMT_OfferedRoleID; 
		public Guid HEC_CMT_GroupSubscription_RequestID; 
		public string Request_GlobalPropertyMatchingID; 
		public Guid Request_HEC_CMT_OfferedRoleID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AC_GGfBPID_1747[] Convert(List<L5AC_GGfBPID_1747_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AC_GGfBPID_1747 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_CMT_CommunityGroupID)).ToArray()
	group el_L5AC_GGfBPID_1747 by new 
	{ 
		el_L5AC_GGfBPID_1747.HEC_CMT_CommunityGroupID,

	}
	into gfunct_L5AC_GGfBPID_1747
	select new L5AC_GGfBPID_1747
	{     
		HEC_CMT_CommunityGroupID = gfunct_L5AC_GGfBPID_1747.Key.HEC_CMT_CommunityGroupID ,
		CommunityGroup_Name = gfunct_L5AC_GGfBPID_1747.FirstOrDefault().CommunityGroup_Name ,
		CommunityGroup_Description = gfunct_L5AC_GGfBPID_1747.FirstOrDefault().CommunityGroup_Description ,
		IsPrivate = gfunct_L5AC_GGfBPID_1747.FirstOrDefault().IsPrivate ,
		CommunityGroupCode = gfunct_L5AC_GGfBPID_1747.FirstOrDefault().CommunityGroupCode ,
		HealthcareCommunityGroupITL = gfunct_L5AC_GGfBPID_1747.FirstOrDefault().HealthcareCommunityGroupITL ,

		Roles = 
		(
			from el_Roles in gfunct_L5AC_GGfBPID_1747.Where(element => !EqualsDefaultValue(element.AssignmentID)).ToArray()
			group el_Roles by new 
			{ 
				el_Roles.AssignmentID,

			}
			into gfunct_Roles
			select new L5AC_GGfBPID_1747_Role
			{     
				AssignmentID = gfunct_Roles.Key.AssignmentID ,
				Role_GlobalPropertyMatchingID = gfunct_Roles.FirstOrDefault().Role_GlobalPropertyMatchingID ,
				Role_HEC_CMT_OfferedRoleID = gfunct_Roles.FirstOrDefault().Role_HEC_CMT_OfferedRoleID ,

			}
		).ToArray(),
		RoleRequests = 
		(
			from el_RoleRequests in gfunct_L5AC_GGfBPID_1747.Where(element => !EqualsDefaultValue(element.HEC_CMT_GroupSubscription_RequestID)).ToArray()
			group el_RoleRequests by new 
			{ 
				el_RoleRequests.HEC_CMT_GroupSubscription_RequestID,

			}
			into gfunct_RoleRequests
			select new L5AC_GGfBPID_1747_RoleRequest
			{     
				HEC_CMT_GroupSubscription_RequestID = gfunct_RoleRequests.Key.HEC_CMT_GroupSubscription_RequestID ,
				Request_GlobalPropertyMatchingID = gfunct_RoleRequests.FirstOrDefault().Request_GlobalPropertyMatchingID ,
				Request_HEC_CMT_OfferedRoleID = gfunct_RoleRequests.FirstOrDefault().Request_HEC_CMT_OfferedRoleID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GGfBPID_1747_Array : FR_Base
	{
		public L5AC_GGfBPID_1747[] Result	{ get; set; } 
		public FR_L5AC_GGfBPID_1747_Array() : base() {}

		public FR_L5AC_GGfBPID_1747_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GGfBPID_1747 for attribute P_L5AC_GGfBPID_1747
		[DataContract]
		public class P_L5AC_GGfBPID_1747 
		{
			//Standard type parameters
			[DataMember]
			public Guid BPID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GGfBPID_1747 for attribute L5AC_GGfBPID_1747
		[DataContract]
		public class L5AC_GGfBPID_1747 
		{
			[DataMember]
			public L5AC_GGfBPID_1747_Role[] Roles { get; set; }
			[DataMember]
			public L5AC_GGfBPID_1747_RoleRequest[] RoleRequests { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public Dict CommunityGroup_Name { get; set; } 
			[DataMember]
			public Dict CommunityGroup_Description { get; set; } 
			[DataMember]
			public bool IsPrivate { get; set; } 
			[DataMember]
			public string CommunityGroupCode { get; set; } 
			[DataMember]
			public string HealthcareCommunityGroupITL { get; set; } 

		}
		#endregion
		#region SClass L5AC_GGfBPID_1747_Role for attribute Roles
		[DataContract]
		public class L5AC_GGfBPID_1747_Role 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public string Role_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid Role_HEC_CMT_OfferedRoleID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GGfBPID_1747_RoleRequest for attribute RoleRequests
		[DataContract]
		public class L5AC_GGfBPID_1747_RoleRequest 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 
			[DataMember]
			public string Request_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid Request_HEC_CMT_OfferedRoleID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GGfBPID_1747_Array cls_Get_Groups_for_BPID(,P_L5AC_GGfBPID_1747 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GGfBPID_1747_Array invocationResult = cls_Get_Groups_for_BPID.Invoke(connectionString,P_L5AC_GGfBPID_1747 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Retrieval.P_L5AC_GGfBPID_1747();
parameter.BPID = ...;

*/
