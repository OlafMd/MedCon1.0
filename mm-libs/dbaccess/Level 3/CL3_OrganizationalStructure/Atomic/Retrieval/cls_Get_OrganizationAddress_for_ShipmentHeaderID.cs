/* 
 * Generated on 10/2/2014 4:44:55 PM
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
    /// var result = cls_Get_OrganizationAddress_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrganizationAddress_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3OS_GOAfSHI_1407_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3OS_GOAfSHI_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3OS_GOAfSHI_1407_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_OrganizationalStructure.Atomic.Retrieval.SQL.cls_Get_OrganizationAddress_for_ShipmentHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);



			List<L3OS_GOAfSHI_1407> results = new List<L3OS_GOAfSHI_1407>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsPrimary","AddressType","IsCompany","PostalAddress_Number","Street_Number","Street_Name","CompanyName_Line1","CompanyName_Line2","PostalAddress_Formatted","Town","CMN_UniversalContactDetailID","ZIP" });
				while(reader.Read())
				{
					L3OS_GOAfSHI_1407 resultItem = new L3OS_GOAfSHI_1407();
					//0:Parameter IsPrimary of type bool
					resultItem.IsPrimary = reader.GetBoolean(0);
					//1:Parameter AddressType of type String
					resultItem.AddressType = reader.GetString(1);
					//2:Parameter IsCompany of type bool
					resultItem.IsCompany = reader.GetBoolean(2);
					//3:Parameter PostalAddress_Number of type String
					resultItem.PostalAddress_Number = reader.GetString(3);
					//4:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(4);
					//5:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(5);
					//6:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(6);
					//7:Parameter CompanyName_Line2 of type String
					resultItem.CompanyName_Line2 = reader.GetString(7);
					//8:Parameter PostalAddress_Formatted of type String
					resultItem.PostalAddress_Formatted = reader.GetString(8);
					//9:Parameter Town of type String
					resultItem.Town = reader.GetString(9);
					//10:Parameter CMN_UniversalContactDetailID of type Guid
					resultItem.CMN_UniversalContactDetailID = reader.GetGuid(10);
					//11:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OrganizationAddress_for_ShipmentHeaderID",ex);
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
		public static FR_L3OS_GOAfSHI_1407_Array Invoke(string ConnectionString,P_L3OS_GOAfSHI_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3OS_GOAfSHI_1407_Array Invoke(DbConnection Connection,P_L3OS_GOAfSHI_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3OS_GOAfSHI_1407_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3OS_GOAfSHI_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3OS_GOAfSHI_1407_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3OS_GOAfSHI_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3OS_GOAfSHI_1407_Array functionReturn = new FR_L3OS_GOAfSHI_1407_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrganizationAddress_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3OS_GOAfSHI_1407_Array : FR_Base
	{
		public L3OS_GOAfSHI_1407[] Result	{ get; set; } 
		public FR_L3OS_GOAfSHI_1407_Array() : base() {}

		public FR_L3OS_GOAfSHI_1407_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3OS_GOAfSHI_1407 for attribute P_L3OS_GOAfSHI_1407
		[DataContract]
		public class P_L3OS_GOAfSHI_1407 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L3OS_GOAfSHI_1407 for attribute L3OS_GOAfSHI_1407
		[DataContract]
		public class L3OS_GOAfSHI_1407 
		{
			//Standard type parameters
			[DataMember]
			public bool IsPrimary { get; set; } 
			[DataMember]
			public String AddressType { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 
			[DataMember]
			public String PostalAddress_Number { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String CompanyName_Line2 { get; set; } 
			[DataMember]
			public String PostalAddress_Formatted { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3OS_GOAfSHI_1407_Array cls_Get_OrganizationAddress_for_ShipmentHeaderID(,P_L3OS_GOAfSHI_1407 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3OS_GOAfSHI_1407_Array invocationResult = cls_Get_OrganizationAddress_for_ShipmentHeaderID.Invoke(connectionString,P_L3OS_GOAfSHI_1407 Parameter,securityTicket);
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
var parameter = new CL3_OrganizationalStructure.Atomic.Retrieval.P_L3OS_GOAfSHI_1407();
parameter.ShipmentHeaderID = ...;

*/
