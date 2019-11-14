/* 
 * Generated on 9/12/2013 08:32:52
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

namespace CL5_APOAdmin_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Addresses_for_CompanyInfoID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Addresses_for_CompanyInfoID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AAS_GAfCI_1526_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AAS_GAfCI_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AAS_GAfCI_1526_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Supplier.Atomic.Retrieval.SQL.cls_Get_Addresses_for_CompanyInfoID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CompanyInfoID", Parameter.CompanyInfoID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsDefaultAddress", Parameter.IsDefaultAddress);



			List<L5AAS_GAfCI_1526> results = new List<L5AAS_GAfCI_1526>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_COM_CompanyInfo_AddressID","CompanyInfo_RefID","IsBilling","IsShipping","IsDefault","IsDeleted","CareOf","Street_Name","Street_Number","ZIP","Town","Country_639_1_ISOCode" });
				while(reader.Read())
				{
					L5AAS_GAfCI_1526 resultItem = new L5AAS_GAfCI_1526();
					//0:Parameter CMN_COM_CompanyInfo_AddressID of type Guid
					resultItem.CMN_COM_CompanyInfo_AddressID = reader.GetGuid(0);
					//1:Parameter CompanyInfo_RefID of type Guid
					resultItem.CompanyInfo_RefID = reader.GetGuid(1);
					//2:Parameter IsBilling of type bool
					resultItem.IsBilling = reader.GetBoolean(2);
					//3:Parameter IsShipping of type bool
					resultItem.IsShipping = reader.GetBoolean(3);
					//4:Parameter IsDefault of type bool
					resultItem.IsDefault = reader.GetBoolean(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter CareOf of type String
					resultItem.CareOf = reader.GetString(6);
					//7:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(7);
					//8:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(8);
					//9:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(9);
					//10:Parameter Town of type String
					resultItem.Town = reader.GetString(10);
					//11:Parameter Country_639_1_ISOCode of type String
					resultItem.Country_639_1_ISOCode = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Addresses_for_CompanyInfoID",ex);
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
		public static FR_L5AAS_GAfCI_1526_Array Invoke(string ConnectionString,P_L5AAS_GAfCI_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AAS_GAfCI_1526_Array Invoke(DbConnection Connection,P_L5AAS_GAfCI_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AAS_GAfCI_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AAS_GAfCI_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AAS_GAfCI_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AAS_GAfCI_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AAS_GAfCI_1526_Array functionReturn = new FR_L5AAS_GAfCI_1526_Array();
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

				throw new Exception("Exception occured in method cls_Get_Addresses_for_CompanyInfoID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AAS_GAfCI_1526_Array : FR_Base
	{
		public L5AAS_GAfCI_1526[] Result	{ get; set; } 
		public FR_L5AAS_GAfCI_1526_Array() : base() {}

		public FR_L5AAS_GAfCI_1526_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AAS_GAfCI_1526 for attribute P_L5AAS_GAfCI_1526
		[DataContract]
		public class P_L5AAS_GAfCI_1526 
		{
			//Standard type parameters
			[DataMember]
			public Guid CompanyInfoID { get; set; } 
			[DataMember]
			public bool? IsDefaultAddress { get; set; } 

		}
		#endregion
		#region SClass L5AAS_GAfCI_1526 for attribute L5AAS_GAfCI_1526
		[DataContract]
		public class L5AAS_GAfCI_1526 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_COM_CompanyInfo_AddressID { get; set; } 
			[DataMember]
			public Guid CompanyInfo_RefID { get; set; } 
			[DataMember]
			public bool IsBilling { get; set; } 
			[DataMember]
			public bool IsShipping { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String CareOf { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Country_639_1_ISOCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AAS_GAfCI_1526_Array cls_Get_Addresses_for_CompanyInfoID(,P_L5AAS_GAfCI_1526 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AAS_GAfCI_1526_Array invocationResult = cls_Get_Addresses_for_CompanyInfoID.Invoke(connectionString,P_L5AAS_GAfCI_1526 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Atomic.Retrieval.P_L5AAS_GAfCI_1526();
parameter.CompanyInfoID = ...;
parameter.IsDefaultAddress = ...;

*/
