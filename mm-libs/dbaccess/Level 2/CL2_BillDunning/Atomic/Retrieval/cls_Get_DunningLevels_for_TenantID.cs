/* 
 * Generated on 29/5/2014 05:25:39
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

namespace CL2_BillDunning.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DunningLevels_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DunningLevels_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2BD_GDLfT_1048_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2BD_GDLfT_1048_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_BillDunning.Atomic.Retrieval.SQL.cls_Get_DunningLevels_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2BD_GDLfT_1048> results = new List<L2BD_GDLfT_1048>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_DUN_Dunning_LevelID","ParentLevel_RefID","GlobalPropertyMatchingID","DunningLevelName_DictID","OrderSequence","Default_DunningFee","Default_Configuration","Creation_Timestamp","Tenant_RefID","IsDeleted" });
				while(reader.Read())
				{
					L2BD_GDLfT_1048 resultItem = new L2BD_GDLfT_1048();
					//0:Parameter ACC_DUN_Dunning_LevelID of type Guid
					resultItem.ACC_DUN_Dunning_LevelID = reader.GetGuid(0);
					//1:Parameter ParentLevel_RefID of type Guid
					resultItem.ParentLevel_RefID = reader.GetGuid(1);
					//2:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(2);
					//3:Parameter DunningLevelName_DictID of type Dict
					resultItem.DunningLevelName_DictID = reader.GetDictionary(3);
					resultItem.DunningLevelName_DictID.SourceTable = "acc_dun_dunning_levels";
					loader.Append(resultItem.DunningLevelName_DictID);
					//4:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(4);
					//5:Parameter Default_DunningFee of type Decimal
					resultItem.Default_DunningFee = reader.GetDecimal(5);
					//6:Parameter Default_Configuration of type String
					resultItem.Default_Configuration = reader.GetString(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(8);
					//9:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DunningLevels_for_TenantID",ex);
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
		public static FR_L2BD_GDLfT_1048_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2BD_GDLfT_1048_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2BD_GDLfT_1048_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2BD_GDLfT_1048_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2BD_GDLfT_1048_Array functionReturn = new FR_L2BD_GDLfT_1048_Array();
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

				throw new Exception("Exception occured in method cls_Get_DunningLevels_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2BD_GDLfT_1048_Array : FR_Base
	{
		public L2BD_GDLfT_1048[] Result	{ get; set; } 
		public FR_L2BD_GDLfT_1048_Array() : base() {}

		public FR_L2BD_GDLfT_1048_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2BD_GDLfT_1048 for attribute L2BD_GDLfT_1048
		[DataContract]
		public class L2BD_GDLfT_1048 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_DUN_Dunning_LevelID { get; set; } 
			[DataMember]
			public Guid ParentLevel_RefID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict DunningLevelName_DictID { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public Decimal Default_DunningFee { get; set; } 
			[DataMember]
			public String Default_Configuration { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2BD_GDLfT_1048_Array cls_Get_DunningLevels_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2BD_GDLfT_1048_Array invocationResult = cls_Get_DunningLevels_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

