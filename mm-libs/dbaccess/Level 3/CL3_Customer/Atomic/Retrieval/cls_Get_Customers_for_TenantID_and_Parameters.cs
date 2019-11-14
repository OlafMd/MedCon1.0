/* 
 * Generated on 3/14/2014 4:24:35 PM
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

namespace CL3_Customer.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Customers_for_TenantID_and_Parameters.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Customers_for_TenantID_and_Parameters
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CU_GPCfTaP_1050_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CU_GPCfTaP_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CU_GPCfTaP_1050_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Customer.Atomic.Retrieval.SQL.cls_Get_Customers_for_TenantID_and_Parameters.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerID", Parameter.CustomerID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Customer_NameOrNumber", Parameter.Customer_NameOrNumber);



			List<L3CU_GPCfTaP_1050> results = new List<L3CU_GPCfTaP_1050>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_CTM_CustomerID","CMN_BPT_BusinessParticipantID","CompanyName_Line1","Customer_DisplayName","LegalGuardian_DisplayName","CMN_COM_CompanyInfoID","PaymentTypeID","InternalCustomerNumber" });
				while(reader.Read())
				{
					L3CU_GPCfTaP_1050 resultItem = new L3CU_GPCfTaP_1050();
					//0:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter CompanyName_Line1 of type string
					resultItem.CompanyName_Line1 = reader.GetString(2);
					//3:Parameter Customer_DisplayName of type string
					resultItem.Customer_DisplayName = reader.GetString(3);
					//4:Parameter LegalGuardian_DisplayName of type string
					resultItem.LegalGuardian_DisplayName = reader.GetString(4);
					//5:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(5);
					//6:Parameter PaymentTypeID of type Guid
					resultItem.PaymentTypeID = reader.GetGuid(6);
					//7:Parameter InternalCustomerNumber of type String
					resultItem.InternalCustomerNumber = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Customers_for_TenantID_and_Parameters",ex);
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
		public static FR_L3CU_GPCfTaP_1050_Array Invoke(string ConnectionString,P_L3CU_GPCfTaP_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CU_GPCfTaP_1050_Array Invoke(DbConnection Connection,P_L3CU_GPCfTaP_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CU_GPCfTaP_1050_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CU_GPCfTaP_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CU_GPCfTaP_1050_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CU_GPCfTaP_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CU_GPCfTaP_1050_Array functionReturn = new FR_L3CU_GPCfTaP_1050_Array();
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

				throw new Exception("Exception occured in method cls_Get_Customers_for_TenantID_and_Parameters",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CU_GPCfTaP_1050_Array : FR_Base
	{
		public L3CU_GPCfTaP_1050[] Result	{ get; set; } 
		public FR_L3CU_GPCfTaP_1050_Array() : base() {}

		public FR_L3CU_GPCfTaP_1050_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CU_GPCfTaP_1050 for attribute P_L3CU_GPCfTaP_1050
		[DataContract]
		public class P_L3CU_GPCfTaP_1050 
		{
			//Standard type parameters
			[DataMember]
			public Guid? CustomerID { get; set; } 
			[DataMember]
			public String Customer_NameOrNumber { get; set; } 

		}
		#endregion
		#region SClass L3CU_GPCfTaP_1050 for attribute L3CU_GPCfTaP_1050
		[DataContract]
		public class L3CU_GPCfTaP_1050 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public string CompanyName_Line1 { get; set; } 
			[DataMember]
			public string Customer_DisplayName { get; set; } 
			[DataMember]
			public string LegalGuardian_DisplayName { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid PaymentTypeID { get; set; } 
			[DataMember]
			public String InternalCustomerNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CU_GPCfTaP_1050_Array cls_Get_Customers_for_TenantID_and_Parameters(,P_L3CU_GPCfTaP_1050 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CU_GPCfTaP_1050_Array invocationResult = cls_Get_Customers_for_TenantID_and_Parameters.Invoke(connectionString,P_L3CU_GPCfTaP_1050 Parameter,securityTicket);
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
var parameter = new CL3_Customer.Atomic.Retrieval.P_L3CU_GPCfTaP_1050();
parameter.CustomerID = ...;
parameter.Customer_NameOrNumber = ...;

*/
