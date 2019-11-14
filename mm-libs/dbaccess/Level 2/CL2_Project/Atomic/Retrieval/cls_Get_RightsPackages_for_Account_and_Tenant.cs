/* 
 * Generated on 1/29/2014 1:53:08 PM
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

namespace CL2_Project.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RightsPackages_for_Account_and_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RightsPackages_for_Account_and_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_PR_GRPfAaT_1007_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_PR_GRPfAaT_1007_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Project.Atomic.Retrieval.SQL.cls_Get_RightsPackages_for_Account_and_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2_PR_GRPfAaT_1007> results = new List<L2_PR_GRPfAaT_1007>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_ACC_RightsPackageID","Name_DictID","Description_DictID","HierarchyLevel","Creation_Timestamp","IsDeleted","Tenant_RefID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L2_PR_GRPfAaT_1007 resultItem = new L2_PR_GRPfAaT_1007();
					//0:Parameter TMS_PRO_ACC_RightsPackageID of type Guid
					resultItem.TMS_PRO_ACC_RightsPackageID = reader.GetGuid(0);
					//1:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(1);
					resultItem.Name.SourceTable = "tms_pro_acc_rightspackages";
					loader.Append(resultItem.Name);
					//2:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(2);
					resultItem.Description.SourceTable = "tms_pro_acc_rightspackages";
					loader.Append(resultItem.Description);
					//3:Parameter HierarchyLevel of type String
					resultItem.HierarchyLevel = reader.GetString(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(6);
					//7:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RightsPackages_for_Account_and_Tenant",ex);
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
		public static FR_L2_PR_GRPfAaT_1007_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_PR_GRPfAaT_1007_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_PR_GRPfAaT_1007_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_PR_GRPfAaT_1007_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_PR_GRPfAaT_1007_Array functionReturn = new FR_L2_PR_GRPfAaT_1007_Array();
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

				throw new Exception("Exception occured in method cls_Get_RightsPackages_for_Account_and_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_PR_GRPfAaT_1007_Array : FR_Base
	{
		public L2_PR_GRPfAaT_1007[] Result	{ get; set; } 
		public FR_L2_PR_GRPfAaT_1007_Array() : base() {}

		public FR_L2_PR_GRPfAaT_1007_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2_PR_GRPfAaT_1007 for attribute L2_PR_GRPfAaT_1007
		[DataContract]
		public class L2_PR_GRPfAaT_1007 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ACC_RightsPackageID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public String HierarchyLevel { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_PR_GRPfAaT_1007_Array cls_Get_RightsPackages_for_Account_and_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_PR_GRPfAaT_1007_Array invocationResult = cls_Get_RightsPackages_for_Account_and_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

