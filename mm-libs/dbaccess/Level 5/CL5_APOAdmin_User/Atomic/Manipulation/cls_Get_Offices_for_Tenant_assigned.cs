/* 
 * Generated on 1/22/2014 5:33:41 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_User.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Offices_for_Tenant_assigned.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Offices_for_Tenant_assigned
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GOfTa_1545_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_GOfTa_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5US_GOfTa_1545_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_User.Atomic.Manipulation.SQL.cls_Get_Offices_for_Tenant_assigned.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UserAccountID", Parameter.UserAccountID);



			List<L5US_GOfTa_1545> results = new List<L5US_GOfTa_1545>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_OfficeID","Parent_RefID","Office_Name_DictID","Office_Description_DictID","Office_InternalName","AssignmentID","CMN_BPT_EMP_Employee_RefID","IsOfficeToAccountDeleted","USR_AccountID" });
				while(reader.Read())
				{
					L5US_GOfTa_1545 resultItem = new L5US_GOfTa_1545();
					//0:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(0);
					//1:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(1);
					//2:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(2);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//3:Parameter Office_Description of type Dict
					resultItem.Office_Description = reader.GetDictionary(3);
					resultItem.Office_Description.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Description);
					//4:Parameter Office_InternalName of type String
					resultItem.Office_InternalName = reader.GetString(4);
					//5:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(5);
					//6:Parameter CMN_BPT_EMP_Employee_RefID of type Guid
					resultItem.CMN_BPT_EMP_Employee_RefID = reader.GetGuid(6);
					//7:Parameter IsOfficeToAccountDeleted of type bool
					resultItem.IsOfficeToAccountDeleted = reader.GetBoolean(7);
					//8:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Offices_for_Tenant_assigned",ex);
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
		public static FR_L5US_GOfTa_1545_Array Invoke(string ConnectionString,P_L5US_GOfTa_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GOfTa_1545_Array Invoke(DbConnection Connection,P_L5US_GOfTa_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GOfTa_1545_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_GOfTa_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GOfTa_1545_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_GOfTa_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GOfTa_1545_Array functionReturn = new FR_L5US_GOfTa_1545_Array();
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

				throw new Exception("Exception occured in method cls_Get_Offices_for_Tenant_assigned",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GOfTa_1545_Array : FR_Base
	{
		public L5US_GOfTa_1545[] Result	{ get; set; } 
		public FR_L5US_GOfTa_1545_Array() : base() {}

		public FR_L5US_GOfTa_1545_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5US_GOfTa_1545 for attribute P_L5US_GOfTa_1545
		[DataContract]
		public class P_L5US_GOfTa_1545 
		{
			//Standard type parameters
			[DataMember]
			public Guid? UserAccountID { get; set; } 

		}
		#endregion
		#region SClass L5US_GOfTa_1545 for attribute L5US_GOfTa_1545
		[DataContract]
		public class L5US_GOfTa_1545 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public Dict Office_Description { get; set; } 
			[DataMember]
			public String Office_InternalName { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_Employee_RefID { get; set; } 
			[DataMember]
			public bool IsOfficeToAccountDeleted { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GOfTa_1545_Array cls_Get_Offices_for_Tenant_assigned(,P_L5US_GOfTa_1545 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GOfTa_1545_Array invocationResult = cls_Get_Offices_for_Tenant_assigned.Invoke(connectionString,P_L5US_GOfTa_1545 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Atomic.Manipulation.P_L5US_GOfTa_1545();
parameter.UserAccountID = ...;

*/
