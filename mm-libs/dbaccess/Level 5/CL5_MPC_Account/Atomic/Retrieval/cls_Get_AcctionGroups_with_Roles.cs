/* 
 * Generated on 05.03.2015 16:17:27
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

namespace CL5_MPC_Account.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AcctionGroups_with_Roles.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AcctionGroups_with_Roles
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GAGwR_1520 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GAGwR_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GAGwR_1520();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Account.Atomic.Retrieval.SQL.cls_Get_AcctionGroups_with_Roles.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_USR_UserID", Parameter.CMN_BPT_USR_UserID);



			List<L5AC_GAGwR_1520_raw> results = new List<L5AC_GAGwR_1520_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CMT_MembershipID","IsAvailableFor_Tenants","IsAvailableFor_Doctors","HEC_CMT_CommunityGroupID","HEC_CMT_OfferedRoleID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5AC_GAGwR_1520_raw resultItem = new L5AC_GAGwR_1520_raw();
					//0:Parameter HEC_CMT_MembershipID of type Guid
					resultItem.HEC_CMT_MembershipID = reader.GetGuid(0);
					//1:Parameter IsAvailableFor_Tenants of type bool
					resultItem.IsAvailableFor_Tenants = reader.GetBoolean(1);
					//2:Parameter IsAvailableFor_Doctors of type bool
					resultItem.IsAvailableFor_Doctors = reader.GetBoolean(2);
					//3:Parameter HEC_CMT_CommunityGroupID of type Guid
					resultItem.HEC_CMT_CommunityGroupID = reader.GetGuid(3);
					//4:Parameter HEC_CMT_OfferedRoleID of type Guid
					resultItem.HEC_CMT_OfferedRoleID = reader.GetGuid(4);
					//5:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AcctionGroups_with_Roles",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AC_GAGwR_1520_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GAGwR_1520 Invoke(string ConnectionString,P_L5AC_GAGwR_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GAGwR_1520 Invoke(DbConnection Connection,P_L5AC_GAGwR_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GAGwR_1520 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GAGwR_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GAGwR_1520 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GAGwR_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GAGwR_1520 functionReturn = new FR_L5AC_GAGwR_1520();
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

				throw new Exception("Exception occured in method cls_Get_AcctionGroups_with_Roles",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AC_GAGwR_1520_raw 
	{
		public Guid HEC_CMT_MembershipID; 
		public bool IsAvailableFor_Tenants; 
		public bool IsAvailableFor_Doctors; 
		public Guid HEC_CMT_CommunityGroupID; 
		public Guid HEC_CMT_OfferedRoleID; 
		public string GlobalPropertyMatchingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AC_GAGwR_1520[] Convert(List<L5AC_GAGwR_1520_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AC_GAGwR_1520 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_CMT_MembershipID)).ToArray()
	group el_L5AC_GAGwR_1520 by new 
	{ 
		el_L5AC_GAGwR_1520.HEC_CMT_MembershipID,

	}
	into gfunct_L5AC_GAGwR_1520
	select new L5AC_GAGwR_1520
	{     
		HEC_CMT_MembershipID = gfunct_L5AC_GAGwR_1520.Key.HEC_CMT_MembershipID ,
		IsAvailableFor_Tenants = gfunct_L5AC_GAGwR_1520.FirstOrDefault().IsAvailableFor_Tenants ,
		IsAvailableFor_Doctors = gfunct_L5AC_GAGwR_1520.FirstOrDefault().IsAvailableFor_Doctors ,

		Group = 
		(
			from el_Group in gfunct_L5AC_GAGwR_1520.Where(element => !EqualsDefaultValue(element.HEC_CMT_CommunityGroupID)).ToArray()
			group el_Group by new 
			{ 
				el_Group.HEC_CMT_CommunityGroupID,

			}
			into gfunct_Group
			select new L5AC_GAGwR_1520_Group
			{     
				HEC_CMT_CommunityGroupID = gfunct_Group.Key.HEC_CMT_CommunityGroupID ,

				Group_Roles = 
				(
					from el_Group_Roles in gfunct_Group.Where(element => !EqualsDefaultValue(element.HEC_CMT_OfferedRoleID)).ToArray()
					group el_Group_Roles by new 
					{ 
						el_Group_Roles.HEC_CMT_OfferedRoleID,

					}
					into gfunct_Group_Roles
					select new L5AC_GAGwR_1520_Group_Role
					{     
						HEC_CMT_OfferedRoleID = gfunct_Group_Roles.Key.HEC_CMT_OfferedRoleID ,
						GlobalPropertyMatchingID = gfunct_Group_Roles.FirstOrDefault().GlobalPropertyMatchingID ,

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GAGwR_1520 : FR_Base
	{
		public L5AC_GAGwR_1520 Result	{ get; set; }

		public FR_L5AC_GAGwR_1520() : base() {}

		public FR_L5AC_GAGwR_1520(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GAGwR_1520 for attribute P_L5AC_GAGwR_1520
		[DataContract]
		public class P_L5AC_GAGwR_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_USR_UserID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GAGwR_1520 for attribute L5AC_GAGwR_1520
		[DataContract]
		public class L5AC_GAGwR_1520 
		{
			[DataMember]
			public L5AC_GAGwR_1520_Group[] Group { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Tenants { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Doctors { get; set; } 

		}
		#endregion
		#region SClass L5AC_GAGwR_1520_Group for attribute Group
		[DataContract]
		public class L5AC_GAGwR_1520_Group 
		{
			[DataMember]
			public L5AC_GAGwR_1520_Group_Role[] Group_Roles { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GAGwR_1520_Group_Role for attribute Group_Roles
		[DataContract]
		public class L5AC_GAGwR_1520_Group_Role 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_OfferedRoleID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GAGwR_1520 cls_Get_AcctionGroups_with_Roles(,P_L5AC_GAGwR_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GAGwR_1520 invocationResult = cls_Get_AcctionGroups_with_Roles.Invoke(connectionString,P_L5AC_GAGwR_1520 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Account.Atomic.Retrieval.P_L5AC_GAGwR_1520();
parameter.CMN_BPT_USR_UserID = ...;

*/
