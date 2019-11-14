/* 
 * Generated on 2/6/2014 1:43:12 PM
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

namespace CL3_CustomerAddresses.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PersonAddresses_for_PersonInfoID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PersonAddresses_for_PersonInfoID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ACAAD_GPAfT_1608_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3ACAAD_GPAfT_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3ACAAD_GPAfT_1608_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_CustomerAddresses.Atomic.Retrieval.SQL.cls_Get_PersonAddresses_for_PersonInfoID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PersonInfoID", Parameter.PersonInfoID);



			List<L3ACAAD_GPAfT_1608> results = new List<L3ACAAD_GPAfT_1608>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_AddressID","IsAddress_Contact","IsAddress_Billing","IsAddress_Shipping","IsPrimary","Street_Name","Street_Number","City_PostalCode","City_Name","Country_ISOCode","AddressLabel","AssignmentID","Country_Name" });
				while(reader.Read())
				{
					L3ACAAD_GPAfT_1608 resultItem = new L3ACAAD_GPAfT_1608();
					//0:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(0);
					//1:Parameter IsAddress_Contact of type bool
					resultItem.IsAddress_Contact = reader.GetBoolean(1);
					//2:Parameter IsAddress_Billing of type bool
					resultItem.IsAddress_Billing = reader.GetBoolean(2);
					//3:Parameter IsAddress_Shipping of type bool
					resultItem.IsAddress_Shipping = reader.GetBoolean(3);
					//4:Parameter IsPrimary of type bool
					resultItem.IsPrimary = reader.GetBoolean(4);
					//5:Parameter Street_Name of type string
					resultItem.Street_Name = reader.GetString(5);
					//6:Parameter Street_Number of type string
					resultItem.Street_Number = reader.GetString(6);
					//7:Parameter City_PostalCode of type string
					resultItem.City_PostalCode = reader.GetString(7);
					//8:Parameter City_Name of type string
					resultItem.City_Name = reader.GetString(8);
					//9:Parameter Country_ISOCode of type string
					resultItem.Country_ISOCode = reader.GetString(9);
					//10:Parameter AddressLabel of type string
					resultItem.AddressLabel = reader.GetString(10);
					//11:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(11);
					//12:Parameter Country_Name of type string
					resultItem.Country_Name = reader.GetString(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PersonAddresses_for_PersonInfoID",ex);
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
		public static FR_L3ACAAD_GPAfT_1608_Array Invoke(string ConnectionString,P_L3ACAAD_GPAfT_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ACAAD_GPAfT_1608_Array Invoke(DbConnection Connection,P_L3ACAAD_GPAfT_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ACAAD_GPAfT_1608_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ACAAD_GPAfT_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ACAAD_GPAfT_1608_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ACAAD_GPAfT_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ACAAD_GPAfT_1608_Array functionReturn = new FR_L3ACAAD_GPAfT_1608_Array();
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

				throw new Exception("Exception occured in method cls_Get_PersonAddresses_for_PersonInfoID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ACAAD_GPAfT_1608_Array : FR_Base
	{
		public L3ACAAD_GPAfT_1608[] Result	{ get; set; } 
		public FR_L3ACAAD_GPAfT_1608_Array() : base() {}

		public FR_L3ACAAD_GPAfT_1608_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ACAAD_GPAfT_1608 for attribute P_L3ACAAD_GPAfT_1608
		[DataContract]
		public class P_L3ACAAD_GPAfT_1608 
		{
			//Standard type parameters
			[DataMember]
			public Guid PersonInfoID { get; set; } 

		}
		#endregion
		#region SClass L3ACAAD_GPAfT_1608 for attribute L3ACAAD_GPAfT_1608
		[DataContract]
		public class L3ACAAD_GPAfT_1608 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public bool IsAddress_Contact { get; set; } 
			[DataMember]
			public bool IsAddress_Billing { get; set; } 
			[DataMember]
			public bool IsAddress_Shipping { get; set; } 
			[DataMember]
			public bool IsPrimary { get; set; } 
			[DataMember]
			public string Street_Name { get; set; } 
			[DataMember]
			public string Street_Number { get; set; } 
			[DataMember]
			public string City_PostalCode { get; set; } 
			[DataMember]
			public string City_Name { get; set; } 
			[DataMember]
			public string Country_ISOCode { get; set; } 
			[DataMember]
			public string AddressLabel { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public string Country_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ACAAD_GPAfT_1608_Array cls_Get_PersonAddresses_for_PersonInfoID(,P_L3ACAAD_GPAfT_1608 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ACAAD_GPAfT_1608_Array invocationResult = cls_Get_PersonAddresses_for_PersonInfoID.Invoke(connectionString,P_L3ACAAD_GPAfT_1608 Parameter,securityTicket);
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
var parameter = new CL3_CustomerAddresses.Atomic.Retrieval.P_L3ACAAD_GPAfT_1608();
parameter.PersonInfoID = ...;

*/
