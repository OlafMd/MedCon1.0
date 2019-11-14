/* 
 * Generated on 4/17/2014 10:06:44 AM
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
using System.Runtime.Serialization;

namespace CL5_APOBilling_Bill.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CompanyCustomers_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CompanyCustomers_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GPCfT_1711_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BL_GPCfT_1711_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Bill.Atomic.Retrieval.SQL.cls_Get_CompanyCustomers_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5BL_GPCfT_1711> results = new List<L5BL_GPCfT_1711>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_CTM_CustomerID","CMN_BPT_BusinessParticipantID","CompanyName_Line1","DisplayName","LegalGuardian","CMN_COM_CompanyInfoID","ACC_PAY_Type_RefID","InternalCustomerNumber" });
				while(reader.Read())
				{
					L5BL_GPCfT_1711 resultItem = new L5BL_GPCfT_1711();
					//0:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter CompanyName_Line1 of type string
					resultItem.CompanyName_Line1 = reader.GetString(2);
					//3:Parameter DisplayName of type string
					resultItem.DisplayName = reader.GetString(3);
					//4:Parameter LegalGuardian of type string
					resultItem.LegalGuardian = reader.GetString(4);
					//5:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(5);
					//6:Parameter ACC_PAY_Type_RefID of type Guid
					resultItem.ACC_PAY_Type_RefID = reader.GetGuid(6);
					//7:Parameter InternalCustomerNumber of type String
					resultItem.InternalCustomerNumber = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CompanyCustomers_for_TenantID",ex);
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
		public static FR_L5BL_GPCfT_1711_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GPCfT_1711_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GPCfT_1711_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GPCfT_1711_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GPCfT_1711_Array functionReturn = new FR_L5BL_GPCfT_1711_Array();
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

				throw new Exception("Exception occured in method cls_Get_CompanyCustomers_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GPCfT_1711_Array : FR_Base
	{
		public L5BL_GPCfT_1711[] Result	{ get; set; } 
		public FR_L5BL_GPCfT_1711_Array() : base() {}

		public FR_L5BL_GPCfT_1711_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5BL_GPCfT_1711 for attribute L5BL_GPCfT_1711
		[DataContract]
		public class L5BL_GPCfT_1711 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public string CompanyName_Line1 { get; set; } 
			[DataMember]
			public string DisplayName { get; set; } 
			[DataMember]
			public string LegalGuardian { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid ACC_PAY_Type_RefID { get; set; } 
			[DataMember]
			public String InternalCustomerNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GPCfT_1711_Array cls_Get_CompanyCustomers_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GPCfT_1711_Array invocationResult = cls_Get_CompanyCustomers_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

