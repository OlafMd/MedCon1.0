/* 
 * Generated on 3/4/2014 02:05:37
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

namespace CL2_Office.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Office_for_TenantID_and_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Office_for_TenantID_and_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2OF_GOFfTaI_1638_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2OF_GOFfTaI_1638 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2OF_GOFfTaI_1638_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Office.Atomic.Retrieval.SQL.cls_Get_Office_for_TenantID_and_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L2OF_GOFfTaI_1638> results = new List<L2OF_GOFfTaI_1638>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_OfficeID","Default_BillingAddress_RefID","Parent_RefID","Office_Name_DictID","Office_Description_DictID","Office_InternalName","Office_InternalNumber" });
				while(reader.Read())
				{
					L2OF_GOFfTaI_1638 resultItem = new L2OF_GOFfTaI_1638();
					//0:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(0);
					//1:Parameter Default_BillingAddress_RefID of type Guid
					resultItem.Default_BillingAddress_RefID = reader.GetGuid(1);
					//2:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(2);
					//3:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(3);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//4:Parameter Office_Description of type Dict
					resultItem.Office_Description = reader.GetDictionary(4);
					resultItem.Office_Description.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Description);
					//5:Parameter Office_InternalName of type String
					resultItem.Office_InternalName = reader.GetString(5);
					//6:Parameter Office_InternalNumber of type String
					resultItem.Office_InternalNumber = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Office_for_TenantID_and_ID",ex);
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
		public static FR_L2OF_GOFfTaI_1638_Array Invoke(string ConnectionString,P_L2OF_GOFfTaI_1638 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2OF_GOFfTaI_1638_Array Invoke(DbConnection Connection,P_L2OF_GOFfTaI_1638 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2OF_GOFfTaI_1638_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2OF_GOFfTaI_1638 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2OF_GOFfTaI_1638_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2OF_GOFfTaI_1638 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2OF_GOFfTaI_1638_Array functionReturn = new FR_L2OF_GOFfTaI_1638_Array();
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

				throw new Exception("Exception occured in method cls_Get_Office_for_TenantID_and_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2OF_GOFfTaI_1638_Array : FR_Base
	{
		public L2OF_GOFfTaI_1638[] Result	{ get; set; } 
		public FR_L2OF_GOFfTaI_1638_Array() : base() {}

		public FR_L2OF_GOFfTaI_1638_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2OF_GOFfTaI_1638 for attribute P_L2OF_GOFfTaI_1638
		[DataContract]
		public class P_L2OF_GOFfTaI_1638 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L2OF_GOFfTaI_1638 for attribute L2OF_GOFfTaI_1638
		[DataContract]
		public class L2OF_GOFfTaI_1638 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Guid Default_BillingAddress_RefID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public Dict Office_Description { get; set; } 
			[DataMember]
			public String Office_InternalName { get; set; } 
			[DataMember]
			public String Office_InternalNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2OF_GOFfTaI_1638_Array cls_Get_Office_for_TenantID_and_ID(,P_L2OF_GOFfTaI_1638 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2OF_GOFfTaI_1638_Array invocationResult = cls_Get_Office_for_TenantID_and_ID.Invoke(connectionString,P_L2OF_GOFfTaI_1638 Parameter,securityTicket);
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
var parameter = new CL2_Office.Atomic.Retrieval.P_L2OF_GOFfTaI_1638();
parameter.OfficeID = ...;

*/
