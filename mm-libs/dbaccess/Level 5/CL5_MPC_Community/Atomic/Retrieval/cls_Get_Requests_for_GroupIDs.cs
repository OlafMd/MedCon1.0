/* 
 * Generated on 27.03.2015 10:58:03
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
    /// var result = cls_Get_Requests_for_GroupIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Requests_for_GroupIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GRfGIDs_1555_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GRfGIDs_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GRfGIDs_1555_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Community.Atomic.Retrieval.SQL.cls_Get_Requests_for_GroupIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@GroupIDs"," IN $$GroupIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$GroupIDs$",Parameter.GroupIDs);


			List<L5AC_GRfGIDs_1555_raw> results = new List<L5AC_GRfGIDs_1555_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CMT_GroupSubscription_RequestID","HEC_CMT_MembershipID","CMN_BPT_USR_UserID","Member_FirstName","Member_LastName","CommunityGroup_RefID","Role_GlobalPropertyMatchingID","HEC_CMT_GroupSubscriptionID","FromSubscritpion_GroupID" });
				while(reader.Read())
				{
					L5AC_GRfGIDs_1555_raw resultItem = new L5AC_GRfGIDs_1555_raw();
					//0:Parameter HEC_CMT_GroupSubscription_RequestID of type Guid
					resultItem.HEC_CMT_GroupSubscription_RequestID = reader.GetGuid(0);
					//1:Parameter HEC_CMT_MembershipID of type Guid
					resultItem.HEC_CMT_MembershipID = reader.GetGuid(1);
					//2:Parameter CMN_BPT_USR_UserID of type Guid
					resultItem.CMN_BPT_USR_UserID = reader.GetGuid(2);
					//3:Parameter Member_FirstName of type string
					resultItem.Member_FirstName = reader.GetString(3);
					//4:Parameter Member_LastName of type string
					resultItem.Member_LastName = reader.GetString(4);
					//5:Parameter CommunityGroup_RefID of type Guid
					resultItem.CommunityGroup_RefID = reader.GetGuid(5);
					//6:Parameter Role_GlobalPropertyMatchingID of type string
					resultItem.Role_GlobalPropertyMatchingID = reader.GetString(6);
					//7:Parameter HEC_CMT_GroupSubscriptionID of type Guid
					resultItem.HEC_CMT_GroupSubscriptionID = reader.GetGuid(7);
					//8:Parameter FromSubscritpion_GroupID of type Guid
					resultItem.FromSubscritpion_GroupID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Requests_for_GroupIDs",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AC_GRfGIDs_1555_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GRfGIDs_1555_Array Invoke(string ConnectionString,P_L5AC_GRfGIDs_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GRfGIDs_1555_Array Invoke(DbConnection Connection,P_L5AC_GRfGIDs_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GRfGIDs_1555_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GRfGIDs_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GRfGIDs_1555_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GRfGIDs_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GRfGIDs_1555_Array functionReturn = new FR_L5AC_GRfGIDs_1555_Array();
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

				throw new Exception("Exception occured in method cls_Get_Requests_for_GroupIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AC_GRfGIDs_1555_raw 
	{
		public Guid HEC_CMT_GroupSubscription_RequestID; 
		public Guid HEC_CMT_MembershipID; 
		public Guid CMN_BPT_USR_UserID; 
		public string Member_FirstName; 
		public string Member_LastName; 
		public Guid CommunityGroup_RefID; 
		public string Role_GlobalPropertyMatchingID; 
		public Guid HEC_CMT_GroupSubscriptionID; 
		public Guid FromSubscritpion_GroupID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AC_GRfGIDs_1555[] Convert(List<L5AC_GRfGIDs_1555_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AC_GRfGIDs_1555 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_CMT_GroupSubscription_RequestID)).ToArray()
	group el_L5AC_GRfGIDs_1555 by new 
	{ 
		el_L5AC_GRfGIDs_1555.HEC_CMT_GroupSubscription_RequestID,

	}
	into gfunct_L5AC_GRfGIDs_1555
	select new L5AC_GRfGIDs_1555
	{     
		HEC_CMT_GroupSubscription_RequestID = gfunct_L5AC_GRfGIDs_1555.Key.HEC_CMT_GroupSubscription_RequestID ,
		HEC_CMT_MembershipID = gfunct_L5AC_GRfGIDs_1555.FirstOrDefault().HEC_CMT_MembershipID ,
		CMN_BPT_USR_UserID = gfunct_L5AC_GRfGIDs_1555.FirstOrDefault().CMN_BPT_USR_UserID ,
		Member_FirstName = gfunct_L5AC_GRfGIDs_1555.FirstOrDefault().Member_FirstName ,
		Member_LastName = gfunct_L5AC_GRfGIDs_1555.FirstOrDefault().Member_LastName ,
		CommunityGroup_RefID = gfunct_L5AC_GRfGIDs_1555.FirstOrDefault().CommunityGroup_RefID ,
		Role_GlobalPropertyMatchingID = gfunct_L5AC_GRfGIDs_1555.FirstOrDefault().Role_GlobalPropertyMatchingID ,

		RoleRequestForGroup = 
		(
			from el_RoleRequestForGroup in gfunct_L5AC_GRfGIDs_1555.Where(element => !EqualsDefaultValue(element.HEC_CMT_GroupSubscriptionID)).ToArray()
			group el_RoleRequestForGroup by new 
			{ 
				el_RoleRequestForGroup.HEC_CMT_GroupSubscriptionID,

			}
			into gfunct_RoleRequestForGroup
			select new L5AC_GRfGIDs_1555_RoleRequestForGroup
			{     
				HEC_CMT_GroupSubscriptionID = gfunct_RoleRequestForGroup.Key.HEC_CMT_GroupSubscriptionID ,
				FromSubscritpion_GroupID = gfunct_RoleRequestForGroup.FirstOrDefault().FromSubscritpion_GroupID ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GRfGIDs_1555_Array : FR_Base
	{
		public L5AC_GRfGIDs_1555[] Result	{ get; set; } 
		public FR_L5AC_GRfGIDs_1555_Array() : base() {}

		public FR_L5AC_GRfGIDs_1555_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GRfGIDs_1555 for attribute P_L5AC_GRfGIDs_1555
		[DataContract]
		public class P_L5AC_GRfGIDs_1555 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] GroupIDs { get; set; } 

		}
		#endregion
		#region SClass L5AC_GRfGIDs_1555 for attribute L5AC_GRfGIDs_1555
		[DataContract]
		public class L5AC_GRfGIDs_1555 
		{
			[DataMember]
			public L5AC_GRfGIDs_1555_RoleRequestForGroup RoleRequestForGroup { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_USR_UserID { get; set; } 
			[DataMember]
			public string Member_FirstName { get; set; } 
			[DataMember]
			public string Member_LastName { get; set; } 
			[DataMember]
			public Guid CommunityGroup_RefID { get; set; } 
			[DataMember]
			public string Role_GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GRfGIDs_1555_RoleRequestForGroup for attribute RoleRequestForGroup
		[DataContract]
		public class L5AC_GRfGIDs_1555_RoleRequestForGroup 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscriptionID { get; set; } 
			[DataMember]
			public Guid FromSubscritpion_GroupID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GRfGIDs_1555_Array cls_Get_Requests_for_GroupIDs(,P_L5AC_GRfGIDs_1555 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GRfGIDs_1555_Array invocationResult = cls_Get_Requests_for_GroupIDs.Invoke(connectionString,P_L5AC_GRfGIDs_1555 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Retrieval.P_L5AC_GRfGIDs_1555();
parameter.GroupIDs = ...;

*/
