/* 
 * Generated on 16/4/2014 06:07:39
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

namespace CL3_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Suppliers_for_PrivateSubscribedCatalogs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Suppliers_for_PrivateSubscribedCatalogs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SP_GSfPSC_1805_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SP_GSfPSC_1805_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Supplier.Atomic.Retrieval.SQL.cls_Get_Suppliers_for_PrivateSubscribedCatalogs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5SP_GSfPSC_1805> results = new List<L5SP_GSfPSC_1805>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_SubscribedCatalogID","CatalogCodeITL","CMN_BPT_SupplierID","ExternalSupplierProvidedIdentifier","CMN_BPT_BusinessParticipantID","CMN_TenantID","TenantITL" });
				while(reader.Read())
				{
					L5SP_GSfPSC_1805 resultItem = new L5SP_GSfPSC_1805();
					//0:Parameter CMN_PRO_SubscribedCatalogID of type Guid
					resultItem.CMN_PRO_SubscribedCatalogID = reader.GetGuid(0);
					//1:Parameter CatalogCodeITL of type String
					resultItem.CatalogCodeITL = reader.GetString(1);
					//2:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(2);
					//3:Parameter ExternalSupplierProvidedIdentifier of type String
					resultItem.ExternalSupplierProvidedIdentifier = reader.GetString(3);
					//4:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(4);
					//5:Parameter CMN_TenantID of type Guid
					resultItem.CMN_TenantID = reader.GetGuid(5);
					//6:Parameter TenantITL of type String
					resultItem.TenantITL = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Suppliers_for_PrivateSubscribedCatalogs",ex);
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
		public static FR_L5SP_GSfPSC_1805_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SP_GSfPSC_1805_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SP_GSfPSC_1805_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SP_GSfPSC_1805_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SP_GSfPSC_1805_Array functionReturn = new FR_L5SP_GSfPSC_1805_Array();
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

				throw new Exception("Exception occured in method cls_Get_Suppliers_for_PrivateSubscribedCatalogs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SP_GSfPSC_1805_Array : FR_Base
	{
		public L5SP_GSfPSC_1805[] Result	{ get; set; } 
		public FR_L5SP_GSfPSC_1805_Array() : base() {}

		public FR_L5SP_GSfPSC_1805_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5SP_GSfPSC_1805 for attribute L5SP_GSfPSC_1805
		[DataContract]
		public class L5SP_GSfPSC_1805 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_SubscribedCatalogID { get; set; } 
			[DataMember]
			public String CatalogCodeITL { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public String ExternalSupplierProvidedIdentifier { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_TenantID { get; set; } 
			[DataMember]
			public String TenantITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SP_GSfPSC_1805_Array cls_Get_Suppliers_for_PrivateSubscribedCatalogs(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SP_GSfPSC_1805_Array invocationResult = cls_Get_Suppliers_for_PrivateSubscribedCatalogs.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

