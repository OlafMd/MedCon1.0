/* 
 * Generated on 26.03.2015 14:44:46
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
    /// var result = cls_Get_PublicGroups_with_SubscriptionData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PublicGroups_with_SubscriptionData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GPGwSD_1444_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GPGwSD_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GPGwSD_1444_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Community.Atomic.Retrieval.SQL.cls_Get_PublicGroups_with_SubscriptionData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MemberID", Parameter.MemberID);



			List<L5AC_GPGwSD_1444_raw> results = new List<L5AC_GPGwSD_1444_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CMT_CommunityGroupID","CommunityGroup_Name_DictID","CommunityGroup_Description_DictID","IsPrivate","CommunityGroupCode","HealthcareCommunityGroupITL","HEC_CMT_GroupSubscriptionID","HEC_CMT_GroupSubscription_RequestID" });
				while(reader.Read())
				{
					L5AC_GPGwSD_1444_raw resultItem = new L5AC_GPGwSD_1444_raw();
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
					//6:Parameter HEC_CMT_GroupSubscriptionID of type Guid
					resultItem.HEC_CMT_GroupSubscriptionID = reader.GetGuid(6);
					//7:Parameter HEC_CMT_GroupSubscription_RequestID of type Guid
					resultItem.HEC_CMT_GroupSubscription_RequestID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PublicGroups_with_SubscriptionData",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AC_GPGwSD_1444_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GPGwSD_1444_Array Invoke(string ConnectionString,P_L5AC_GPGwSD_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GPGwSD_1444_Array Invoke(DbConnection Connection,P_L5AC_GPGwSD_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GPGwSD_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GPGwSD_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GPGwSD_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GPGwSD_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GPGwSD_1444_Array functionReturn = new FR_L5AC_GPGwSD_1444_Array();
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

				throw new Exception("Exception occured in method cls_Get_PublicGroups_with_SubscriptionData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AC_GPGwSD_1444_raw 
	{
		public Guid HEC_CMT_CommunityGroupID; 
		public Dict CommunityGroup_Name; 
		public Dict CommunityGroup_Description; 
		public bool IsPrivate; 
		public string CommunityGroupCode; 
		public string HealthcareCommunityGroupITL; 
		public Guid HEC_CMT_GroupSubscriptionID; 
		public Guid HEC_CMT_GroupSubscription_RequestID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AC_GPGwSD_1444[] Convert(List<L5AC_GPGwSD_1444_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AC_GPGwSD_1444 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_CMT_CommunityGroupID)).ToArray()
	group el_L5AC_GPGwSD_1444 by new 
	{ 
		el_L5AC_GPGwSD_1444.HEC_CMT_CommunityGroupID,

	}
	into gfunct_L5AC_GPGwSD_1444
	select new L5AC_GPGwSD_1444
	{     
		HEC_CMT_CommunityGroupID = gfunct_L5AC_GPGwSD_1444.Key.HEC_CMT_CommunityGroupID ,
		CommunityGroup_Name = gfunct_L5AC_GPGwSD_1444.FirstOrDefault().CommunityGroup_Name ,
		CommunityGroup_Description = gfunct_L5AC_GPGwSD_1444.FirstOrDefault().CommunityGroup_Description ,
		IsPrivate = gfunct_L5AC_GPGwSD_1444.FirstOrDefault().IsPrivate ,
		CommunityGroupCode = gfunct_L5AC_GPGwSD_1444.FirstOrDefault().CommunityGroupCode ,
		HealthcareCommunityGroupITL = gfunct_L5AC_GPGwSD_1444.FirstOrDefault().HealthcareCommunityGroupITL ,

		Subscription = 
		(
			from el_Subscription in gfunct_L5AC_GPGwSD_1444.Where(element => !EqualsDefaultValue(element.HEC_CMT_GroupSubscriptionID)).ToArray()
			group el_Subscription by new 
			{ 
				el_Subscription.HEC_CMT_GroupSubscriptionID,

			}
			into gfunct_Subscription
			select new L5AC_GPGwSD_1444_Subscription
			{     
				HEC_CMT_GroupSubscriptionID = gfunct_Subscription.Key.HEC_CMT_GroupSubscriptionID ,

			}
		).FirstOrDefault(),
		PendingRequests = 
		(
			from el_PendingRequests in gfunct_L5AC_GPGwSD_1444.Where(element => !EqualsDefaultValue(element.HEC_CMT_GroupSubscription_RequestID)).ToArray()
			group el_PendingRequests by new 
			{ 
				el_PendingRequests.HEC_CMT_GroupSubscription_RequestID,

			}
			into gfunct_PendingRequests
			select new L5AC_GPGwSD_1444_PendingRequest
			{     
				HEC_CMT_GroupSubscription_RequestID = gfunct_PendingRequests.Key.HEC_CMT_GroupSubscription_RequestID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GPGwSD_1444_Array : FR_Base
	{
		public L5AC_GPGwSD_1444[] Result	{ get; set; } 
		public FR_L5AC_GPGwSD_1444_Array() : base() {}

		public FR_L5AC_GPGwSD_1444_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GPGwSD_1444 for attribute P_L5AC_GPGwSD_1444
		[DataContract]
		public class P_L5AC_GPGwSD_1444 
		{
			//Standard type parameters
			[DataMember]
			public Guid MemberID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GPGwSD_1444 for attribute L5AC_GPGwSD_1444
		[DataContract]
		public class L5AC_GPGwSD_1444 
		{
			[DataMember]
			public L5AC_GPGwSD_1444_Subscription Subscription { get; set; }
			[DataMember]
			public L5AC_GPGwSD_1444_PendingRequest[] PendingRequests { get; set; }

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
		#region SClass L5AC_GPGwSD_1444_Subscription for attribute Subscription
		[DataContract]
		public class L5AC_GPGwSD_1444_Subscription 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscriptionID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GPGwSD_1444_PendingRequest for attribute PendingRequests
		[DataContract]
		public class L5AC_GPGwSD_1444_PendingRequest 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GPGwSD_1444_Array cls_Get_PublicGroups_with_SubscriptionData(,P_L5AC_GPGwSD_1444 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GPGwSD_1444_Array invocationResult = cls_Get_PublicGroups_with_SubscriptionData.Invoke(connectionString,P_L5AC_GPGwSD_1444 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Retrieval.P_L5AC_GPGwSD_1444();
parameter.MemberID = ...;

*/
