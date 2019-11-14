/* 
 * Generated on 28/10/2013 04:39:26
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

namespace CL2_Address.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Address_for_TenantID_or_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Address_for_TenantID_or_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2ADD_GADDfToI_1447_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2ADD_GADDfToI_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2ADD_GADDfToI_1447_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Address.Atomic.Retrieval.SQL.cls_Get_Address_for_TenantID_or_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AddressID", Parameter.AddressID);



			List<L2ADD_GADDfToI_1447> results = new List<L2ADD_GADDfToI_1447>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_AddressID","Street_Name","Street_Number","City_AdministrativeDistrict","City_Region","City_Name","City_PostalCode","Province_Name","Country_Name","Country_ISOCode","Creation_Timestamp","IsDeleted","Tenant_RefID","Province_EconomicRegion_RefID" });
				while(reader.Read())
				{
					L2ADD_GADDfToI_1447 resultItem = new L2ADD_GADDfToI_1447();
					//0:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(0);
					//1:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(1);
					//2:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(2);
					//3:Parameter City_AdministrativeDistrict of type String
					resultItem.City_AdministrativeDistrict = reader.GetString(3);
					//4:Parameter City_Region of type String
					resultItem.City_Region = reader.GetString(4);
					//5:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(5);
					//6:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(6);
					//7:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(7);
					//8:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(8);
					//9:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(9);
					//10:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(10);
					//11:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(11);
					//12:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(12);
					//13:Parameter Province_EconomicRegion_RefID of type Guid
					resultItem.Province_EconomicRegion_RefID = reader.GetGuid(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Address_for_TenantID_or_ID",ex);
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
		public static FR_L2ADD_GADDfToI_1447_Array Invoke(string ConnectionString,P_L2ADD_GADDfToI_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2ADD_GADDfToI_1447_Array Invoke(DbConnection Connection,P_L2ADD_GADDfToI_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2ADD_GADDfToI_1447_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2ADD_GADDfToI_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2ADD_GADDfToI_1447_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2ADD_GADDfToI_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2ADD_GADDfToI_1447_Array functionReturn = new FR_L2ADD_GADDfToI_1447_Array();
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

				throw new Exception("Exception occured in method cls_Get_Address_for_TenantID_or_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2ADD_GADDfToI_1447_Array : FR_Base
	{
		public L2ADD_GADDfToI_1447[] Result	{ get; set; } 
		public FR_L2ADD_GADDfToI_1447_Array() : base() {}

		public FR_L2ADD_GADDfToI_1447_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2ADD_GADDfToI_1447 for attribute P_L2ADD_GADDfToI_1447
		[DataContract]
		public class P_L2ADD_GADDfToI_1447 
		{
			//Standard type parameters
			[DataMember]
			public Guid? AddressID { get; set; } 

		}
		#endregion
		#region SClass L2ADD_GADDfToI_1447 for attribute L2ADD_GADDfToI_1447
		[DataContract]
		public class L2ADD_GADDfToI_1447 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_AdministrativeDistrict { get; set; } 
			[DataMember]
			public String City_Region { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid Province_EconomicRegion_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2ADD_GADDfToI_1447_Array cls_Get_Address_for_TenantID_or_ID(,P_L2ADD_GADDfToI_1447 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2ADD_GADDfToI_1447_Array invocationResult = cls_Get_Address_for_TenantID_or_ID.Invoke(connectionString,P_L2ADD_GADDfToI_1447 Parameter,securityTicket);
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
var parameter = new CL2_Address.Atomic.Retrieval.P_L2ADD_GADDfToI_1447();
parameter.AddressID = ...;

*/
