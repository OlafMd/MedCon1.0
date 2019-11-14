/* 
 * Generated on 7/31/2014 3:13:15 PM
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

namespace CL3_OrganizationalStructure.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Address_for_OfficeIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Address_for_OfficeIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3OS_GAAfO_1035_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3OS_GAAfO_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3OS_GAAfO_1035_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_OrganizationalStructure.Atomic.Retrieval.SQL.cls_Get_All_Address_for_OfficeIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@OfficeIDs"," IN $$OfficeIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$OfficeIDs$",Parameter.OfficeIDs);


			List<L3OS_GAAfO_1035> results = new List<L3OS_GAAfO_1035>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Street_Name","Street_Number","IsShippingAddress","IsBillingAddress","IsSpecialAddress","IfSpecialAddress_Name","City_Name","City_PostalCode","Country_Name","CMN_STR_OfficeID","CMN_AddressID","CareOf","Country_ISOCode","IsDefault" });
				while(reader.Read())
				{
					L3OS_GAAfO_1035 resultItem = new L3OS_GAAfO_1035();
					//0:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(0);
					//1:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(1);
					//2:Parameter IsShippingAddress of type bool
					resultItem.IsShippingAddress = reader.GetBoolean(2);
					//3:Parameter IsBillingAddress of type bool
					resultItem.IsBillingAddress = reader.GetBoolean(3);
					//4:Parameter IsSpecialAddress of type bool
					resultItem.IsSpecialAddress = reader.GetBoolean(4);
					//5:Parameter IfSpecialAddress_Name of type String
					resultItem.IfSpecialAddress_Name = reader.GetString(5);
					//6:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(6);
					//7:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(7);
					//8:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(8);
					//9:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(9);
					//10:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(10);
					//11:Parameter CareOf of type String
					resultItem.CareOf = reader.GetString(11);
					//12:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(12);
					//13:Parameter IsDefault of type bool
					resultItem.IsDefault = reader.GetBoolean(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Address_for_OfficeIDs",ex);
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
		public static FR_L3OS_GAAfO_1035_Array Invoke(string ConnectionString,P_L3OS_GAAfO_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3OS_GAAfO_1035_Array Invoke(DbConnection Connection,P_L3OS_GAAfO_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3OS_GAAfO_1035_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3OS_GAAfO_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3OS_GAAfO_1035_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3OS_GAAfO_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3OS_GAAfO_1035_Array functionReturn = new FR_L3OS_GAAfO_1035_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Address_for_OfficeIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3OS_GAAfO_1035_Array : FR_Base
	{
		public L3OS_GAAfO_1035[] Result	{ get; set; } 
		public FR_L3OS_GAAfO_1035_Array() : base() {}

		public FR_L3OS_GAAfO_1035_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3OS_GAAfO_1035 for attribute P_L3OS_GAAfO_1035
		[DataContract]
		public class P_L3OS_GAAfO_1035 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] OfficeIDs { get; set; } 

		}
		#endregion
		#region SClass L3OS_GAAfO_1035 for attribute L3OS_GAAfO_1035
		[DataContract]
		public class L3OS_GAAfO_1035 
		{
			//Standard type parameters
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public bool IsShippingAddress { get; set; } 
			[DataMember]
			public bool IsBillingAddress { get; set; } 
			[DataMember]
			public bool IsSpecialAddress { get; set; } 
			[DataMember]
			public String IfSpecialAddress_Name { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String CareOf { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3OS_GAAfO_1035_Array cls_Get_All_Address_for_OfficeIDs(,P_L3OS_GAAfO_1035 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3OS_GAAfO_1035_Array invocationResult = cls_Get_All_Address_for_OfficeIDs.Invoke(connectionString,P_L3OS_GAAfO_1035 Parameter,securityTicket);
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
var parameter = new CL3_OrganizationalStructure.Atomic.Retrieval.P_L3OS_GAAfO_1035();
parameter.OfficeIDs = ...;

*/
