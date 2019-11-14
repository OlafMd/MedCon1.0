/* 
 * Generated on 03.03.2015 16:07:05
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
    /// var result = cls_Get_Groups.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Groups
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GG_1518_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GG_1518_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Community.Atomic.Retrieval.SQL.cls_Get_Groups.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5AC_GG_1518> results = new List<L5AC_GG_1518>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CMT_CommunityGroupID","CommunityGroup_Name_DictID","CommunityGroup_Description_DictID","IsPrivate","CommunityGroupCode","HealthcareCommunityGroupITL" });
				while(reader.Read())
				{
					L5AC_GG_1518 resultItem = new L5AC_GG_1518();
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

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Groups",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GG_1518_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GG_1518_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GG_1518_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GG_1518_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GG_1518_Array functionReturn = new FR_L5AC_GG_1518_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Groups",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GG_1518_Array : FR_Base
	{
		public L5AC_GG_1518[] Result	{ get; set; } 
		public FR_L5AC_GG_1518_Array() : base() {}

		public FR_L5AC_GG_1518_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5AC_GG_1518 for attribute L5AC_GG_1518
		[DataContract]
		public class L5AC_GG_1518 
		{
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

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GG_1518_Array cls_Get_Groups(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GG_1518_Array invocationResult = cls_Get_Groups.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

