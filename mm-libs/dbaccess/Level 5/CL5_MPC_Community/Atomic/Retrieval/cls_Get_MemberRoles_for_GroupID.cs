/* 
 * Generated on 26.03.2015 11:14:07
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
    /// var result = cls_Get_MemberRoles_for_GroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MemberRoles_for_GroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MC_GMRfGMID_1505 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_GMRfGMID_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5MC_GMRfGMID_1505();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Community.Atomic.Retrieval.SQL.cls_Get_MemberRoles_for_GroupID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GroupID", Parameter.GroupID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MemberID", Parameter.MemberID);



			List<L5MC_GMRfGMID_1505_raw> results = new List<L5MC_GMRfGMID_1505_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_USR_UserID","HEC_CMT_MembershipID","IsAvailableFor_Tenants","IsAvailableFor_Doctors","FirstName","LastName","PrimaryEmail","HEC_CMT_OfferedRoleID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5MC_GMRfGMID_1505_raw resultItem = new L5MC_GMRfGMID_1505_raw();
					//0:Parameter CMN_BPT_USR_UserID of type Guid
					resultItem.CMN_BPT_USR_UserID = reader.GetGuid(0);
					//1:Parameter HEC_CMT_MembershipID of type Guid
					resultItem.HEC_CMT_MembershipID = reader.GetGuid(1);
					//2:Parameter IsAvailableFor_Tenants of type bool
					resultItem.IsAvailableFor_Tenants = reader.GetBoolean(2);
					//3:Parameter IsAvailableFor_Doctors of type bool
					resultItem.IsAvailableFor_Doctors = reader.GetBoolean(3);
					//4:Parameter FirstName of type string
					resultItem.FirstName = reader.GetString(4);
					//5:Parameter LastName of type string
					resultItem.LastName = reader.GetString(5);
					//6:Parameter PrimaryEmail of type string
					resultItem.PrimaryEmail = reader.GetString(6);
					//7:Parameter HEC_CMT_OfferedRoleID of type Guid
					resultItem.HEC_CMT_OfferedRoleID = reader.GetGuid(7);
					//8:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_MemberRoles_for_GroupID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5MC_GMRfGMID_1505_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MC_GMRfGMID_1505 Invoke(string ConnectionString,P_L5MC_GMRfGMID_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MC_GMRfGMID_1505 Invoke(DbConnection Connection,P_L5MC_GMRfGMID_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MC_GMRfGMID_1505 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_GMRfGMID_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MC_GMRfGMID_1505 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_GMRfGMID_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MC_GMRfGMID_1505 functionReturn = new FR_L5MC_GMRfGMID_1505();
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

				throw new Exception("Exception occured in method cls_Get_MemberRoles_for_GroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5MC_GMRfGMID_1505_raw 
	{
		public Guid CMN_BPT_USR_UserID; 
		public Guid HEC_CMT_MembershipID; 
		public bool IsAvailableFor_Tenants; 
		public bool IsAvailableFor_Doctors; 
		public string FirstName; 
		public string LastName; 
		public string PrimaryEmail; 
		public Guid HEC_CMT_OfferedRoleID; 
		public string GlobalPropertyMatchingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5MC_GMRfGMID_1505[] Convert(List<L5MC_GMRfGMID_1505_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5MC_GMRfGMID_1505 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_CMT_MembershipID)).ToArray()
	group el_L5MC_GMRfGMID_1505 by new 
	{ 
		el_L5MC_GMRfGMID_1505.HEC_CMT_MembershipID,

	}
	into gfunct_L5MC_GMRfGMID_1505
	select new L5MC_GMRfGMID_1505
	{     
		CMN_BPT_USR_UserID = gfunct_L5MC_GMRfGMID_1505.FirstOrDefault().CMN_BPT_USR_UserID ,
		HEC_CMT_MembershipID = gfunct_L5MC_GMRfGMID_1505.Key.HEC_CMT_MembershipID ,
		IsAvailableFor_Tenants = gfunct_L5MC_GMRfGMID_1505.FirstOrDefault().IsAvailableFor_Tenants ,
		IsAvailableFor_Doctors = gfunct_L5MC_GMRfGMID_1505.FirstOrDefault().IsAvailableFor_Doctors ,
		FirstName = gfunct_L5MC_GMRfGMID_1505.FirstOrDefault().FirstName ,
		LastName = gfunct_L5MC_GMRfGMID_1505.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L5MC_GMRfGMID_1505.FirstOrDefault().PrimaryEmail ,

		Roles = 
		(
			from el_Roles in gfunct_L5MC_GMRfGMID_1505.Where(element => !EqualsDefaultValue(element.HEC_CMT_OfferedRoleID)).ToArray()
			group el_Roles by new 
			{ 
				el_Roles.HEC_CMT_OfferedRoleID,

			}
			into gfunct_Roles
			select new L5MC_GMRfGMID_1505_Role
			{     
				HEC_CMT_OfferedRoleID = gfunct_Roles.Key.HEC_CMT_OfferedRoleID ,
				GlobalPropertyMatchingID = gfunct_Roles.FirstOrDefault().GlobalPropertyMatchingID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5MC_GMRfGMID_1505 : FR_Base
	{
		public L5MC_GMRfGMID_1505 Result	{ get; set; }

		public FR_L5MC_GMRfGMID_1505() : base() {}

		public FR_L5MC_GMRfGMID_1505(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MC_GMRfGMID_1505 for attribute P_L5MC_GMRfGMID_1505
		[DataContract]
		public class P_L5MC_GMRfGMID_1505 
		{
			//Standard type parameters
			[DataMember]
			public Guid GroupID { get; set; } 
			[DataMember]
			public Guid MemberID { get; set; } 

		}
		#endregion
		#region SClass L5MC_GMRfGMID_1505 for attribute L5MC_GMRfGMID_1505
		[DataContract]
		public class L5MC_GMRfGMID_1505 
		{
			[DataMember]
			public L5MC_GMRfGMID_1505_Role[] Roles { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_USR_UserID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Tenants { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Doctors { get; set; } 
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 
			[DataMember]
			public string PrimaryEmail { get; set; } 

		}
		#endregion
		#region SClass L5MC_GMRfGMID_1505_Role for attribute Roles
		[DataContract]
		public class L5MC_GMRfGMID_1505_Role 
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
FR_L5MC_GMRfGMID_1505 cls_Get_MemberRoles_for_GroupID(,P_L5MC_GMRfGMID_1505 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MC_GMRfGMID_1505 invocationResult = cls_Get_MemberRoles_for_GroupID.Invoke(connectionString,P_L5MC_GMRfGMID_1505 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Retrieval.P_L5MC_GMRfGMID_1505();
parameter.GroupID = ...;
parameter.MemberID = ...;

*/
