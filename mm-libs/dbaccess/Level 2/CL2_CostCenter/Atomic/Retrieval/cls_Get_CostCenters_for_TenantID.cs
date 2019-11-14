/* 
 * Generated on 9/10/2014 14:25:58
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

namespace CL2_CostCenter.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CostCenters_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CostCenters_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CC_GCCfT_1349_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2CC_GCCfT_1349_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_CostCenter.Atomic.Retrieval.SQL.cls_Get_CostCenters_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2CC_GCCfT_1349> results = new List<L2CC_GCCfT_1349>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_CostCenterID","InternalID","CostCenterName_DictID","Description_DictID","IsDeleted","CostCenterType_RefID","ResponsiblePerson_RefID","Currency_RefID","CostCenter_Parent_RefID","R_CostCenter_HasChildren","OpenForBooking","FirstName","LastName","CostCenterType_Name_DictID","CurrencyName_DictID","Office_RefID" });
				while(reader.Read())
				{
					L2CC_GCCfT_1349 resultItem = new L2CC_GCCfT_1349();
					//0:Parameter CMN_STR_CostCenterID of type Guid
					resultItem.CMN_STR_CostCenterID = reader.GetGuid(0);
					//1:Parameter InternalID of type String
					resultItem.InternalID = reader.GetString(1);
					//2:Parameter CostCenterName of type Dict
					resultItem.CostCenterName = reader.GetDictionary(2);
					resultItem.CostCenterName.SourceTable = "cmn_str_costcenters";
					loader.Append(resultItem.CostCenterName);
					//3:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(3);
					resultItem.Description.SourceTable = "cmn_str_costcenters";
					loader.Append(resultItem.Description);
					//4:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(4);
					//5:Parameter CostCenterType_RefID of type Guid
					resultItem.CostCenterType_RefID = reader.GetGuid(5);
					//6:Parameter ResponsiblePerson_RefID of type Guid
					resultItem.ResponsiblePerson_RefID = reader.GetGuid(6);
					//7:Parameter Currency_RefID of type Guid
					resultItem.Currency_RefID = reader.GetGuid(7);
					//8:Parameter CostCenter_Parent_RefID of type Guid
					resultItem.CostCenter_Parent_RefID = reader.GetGuid(8);
					//9:Parameter R_CostCenter_HasChildren of type bool
					resultItem.R_CostCenter_HasChildren = reader.GetBoolean(9);
					//10:Parameter OpenForBooking of type bool
					resultItem.OpenForBooking = reader.GetBoolean(10);
					//11:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(11);
					//12:Parameter LastName of type String
					resultItem.LastName = reader.GetString(12);
					//13:Parameter CostCenterType_Name of type Dict
					resultItem.CostCenterType_Name = reader.GetDictionary(13);
					resultItem.CostCenterType_Name.SourceTable = "cmn_str_costcenter_types";
					loader.Append(resultItem.CostCenterType_Name);
					//14:Parameter CurrencyName of type Dict
					resultItem.CurrencyName = reader.GetDictionary(14);
					resultItem.CurrencyName.SourceTable = "cmn_currencies";
					loader.Append(resultItem.CurrencyName);
					//15:Parameter Office_RefID of type Guid
					resultItem.Office_RefID = reader.GetGuid(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CostCenters_for_TenantID",ex);
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
		public static FR_L2CC_GCCfT_1349_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CC_GCCfT_1349_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CC_GCCfT_1349_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CC_GCCfT_1349_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CC_GCCfT_1349_Array functionReturn = new FR_L2CC_GCCfT_1349_Array();
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

				throw new Exception("Exception occured in method cls_Get_CostCenters_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CC_GCCfT_1349_Array : FR_Base
	{
		public L2CC_GCCfT_1349[] Result	{ get; set; } 
		public FR_L2CC_GCCfT_1349_Array() : base() {}

		public FR_L2CC_GCCfT_1349_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2CC_GCCfT_1349 for attribute L2CC_GCCfT_1349
		[DataContract]
		public class L2CC_GCCfT_1349 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_CostCenterID { get; set; } 
			[DataMember]
			public String InternalID { get; set; } 
			[DataMember]
			public Dict CostCenterName { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid CostCenterType_RefID { get; set; } 
			[DataMember]
			public Guid ResponsiblePerson_RefID { get; set; } 
			[DataMember]
			public Guid Currency_RefID { get; set; } 
			[DataMember]
			public Guid CostCenter_Parent_RefID { get; set; } 
			[DataMember]
			public bool R_CostCenter_HasChildren { get; set; } 
			[DataMember]
			public bool OpenForBooking { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Dict CostCenterType_Name { get; set; } 
			[DataMember]
			public Dict CurrencyName { get; set; } 
			[DataMember]
			public Guid Office_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CC_GCCfT_1349_Array cls_Get_CostCenters_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CC_GCCfT_1349_Array invocationResult = cls_Get_CostCenters_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

