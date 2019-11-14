/* 
 * Generated on 11/13/2014 5:24:19 PM
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

namespace CL3_Tenant.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Tenant_Details.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Tenant_Details
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3TE_GTD_1721_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3TE_GTD_1721_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Tenant.Atomic.Retrieval.SQL.cls_Get_Tenant_Details.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3TE_GTD_1721> results = new List<L3TE_GTD_1721>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_TenantID","CMN_BPT_BusinessParticipantID","BusinessParticipantDisplayName","TenantUniversalContactDetailID","TenantUniversalContactDetailCompanyName","TenantUniversalContactDetailContactEmail","CMN_COM_CompanyInfoID","CompanyInfoUniversalContactDetailID","CompanyInfoUniversalContactDetailCompanyName","CompanyInfoUniversalContactDetailContactEmail","CMN_BPT_CTM_CustomerID","CMN_BPT_SupplierID","SupplierType_RefID" });
				while(reader.Read())
				{
					L3TE_GTD_1721 resultItem = new L3TE_GTD_1721();
					//0:Parameter CMN_TenantID of type Guid
					resultItem.CMN_TenantID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter BusinessParticipantDisplayName of type String
					resultItem.BusinessParticipantDisplayName = reader.GetString(2);
					//3:Parameter TenantUniversalContactDetailID of type Guid
					resultItem.TenantUniversalContactDetailID = reader.GetGuid(3);
					//4:Parameter TenantUniversalContactDetailCompanyName of type String
					resultItem.TenantUniversalContactDetailCompanyName = reader.GetString(4);
					//5:Parameter TenantUniversalContactDetailContactEmail of type String
					resultItem.TenantUniversalContactDetailContactEmail = reader.GetString(5);
					//6:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(6);
					//7:Parameter CompanyInfoUniversalContactDetailID of type Guid
					resultItem.CompanyInfoUniversalContactDetailID = reader.GetGuid(7);
					//8:Parameter CompanyInfoUniversalContactDetailCompanyName of type String
					resultItem.CompanyInfoUniversalContactDetailCompanyName = reader.GetString(8);
					//9:Parameter CompanyInfoUniversalContactDetailContactEmail of type String
					resultItem.CompanyInfoUniversalContactDetailContactEmail = reader.GetString(9);
					//10:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(10);
					//11:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(11);
					//12:Parameter SupplierType_RefID of type Guid
					resultItem.SupplierType_RefID = reader.GetGuid(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Tenant_Details",ex);
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
		public static FR_L3TE_GTD_1721_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3TE_GTD_1721_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3TE_GTD_1721_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3TE_GTD_1721_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3TE_GTD_1721_Array functionReturn = new FR_L3TE_GTD_1721_Array();
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

				throw new Exception("Exception occured in method cls_Get_Tenant_Details",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3TE_GTD_1721_Array : FR_Base
	{
		public L3TE_GTD_1721[] Result	{ get; set; } 
		public FR_L3TE_GTD_1721_Array() : base() {}

		public FR_L3TE_GTD_1721_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3TE_GTD_1721 for attribute L3TE_GTD_1721
		[DataContract]
		public class L3TE_GTD_1721 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_TenantID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String BusinessParticipantDisplayName { get; set; } 
			[DataMember]
			public Guid TenantUniversalContactDetailID { get; set; } 
			[DataMember]
			public String TenantUniversalContactDetailCompanyName { get; set; } 
			[DataMember]
			public String TenantUniversalContactDetailContactEmail { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid CompanyInfoUniversalContactDetailID { get; set; } 
			[DataMember]
			public String CompanyInfoUniversalContactDetailCompanyName { get; set; } 
			[DataMember]
			public String CompanyInfoUniversalContactDetailContactEmail { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public Guid SupplierType_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3TE_GTD_1721_Array cls_Get_Tenant_Details(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3TE_GTD_1721_Array invocationResult = cls_Get_Tenant_Details.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

