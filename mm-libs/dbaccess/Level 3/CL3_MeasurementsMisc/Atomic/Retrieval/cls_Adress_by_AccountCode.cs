/* 
 * Generated on 8/13/2014 2:49:18 PM
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

namespace CL3_MeasurementsMisc.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Adress_by_AccountCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Adress_by_AccountCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_AbAC_1608_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_AbAC_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_AbAC_1608_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MeasurementsMisc.Atomic.Retrieval.SQL.cls_Adress_by_AccountCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L3_AbAC_1608> results = new List<L3_AbAC_1608>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Longitude","Lattitude","CareOf","Province_EconomicRegion_RefID","Tenant_RefID","IsDeleted","Creation_Timestamp","Country_ISOCode","Country_Name","City_Name","City_PostalCode","Province_Name","City_Region","City_AdministrativeDistrict","Street_Number","Street_Name","CMN_AddressID" });
				while(reader.Read())
				{
					L3_AbAC_1608 resultItem = new L3_AbAC_1608();
					//0:Parameter Longitude of type String
					resultItem.Longitude = reader.GetString(0);
					//1:Parameter Lattitude of type String
					resultItem.Lattitude = reader.GetString(1);
					//2:Parameter CareOf of type String
					resultItem.CareOf = reader.GetString(2);
					//3:Parameter Province_EconomicRegion_RefID of type Guid
					resultItem.Province_EconomicRegion_RefID = reader.GetGuid(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);
					//7:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(7);
					//8:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(8);
					//9:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(9);
					//10:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(10);
					//11:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(11);
					//12:Parameter City_Region of type String
					resultItem.City_Region = reader.GetString(12);
					//13:Parameter City_AdministrativeDistrict of type String
					resultItem.City_AdministrativeDistrict = reader.GetString(13);
					//14:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(14);
					//15:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(15);
					//16:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Adress_by_AccountCode",ex);
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
		public static FR_L3_AbAC_1608_Array Invoke(string ConnectionString,P_L3_AbAC_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_AbAC_1608_Array Invoke(DbConnection Connection,P_L3_AbAC_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_AbAC_1608_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_AbAC_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_AbAC_1608_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_AbAC_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_AbAC_1608_Array functionReturn = new FR_L3_AbAC_1608_Array();
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

				throw new Exception("Exception occured in method cls_Adress_by_AccountCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_AbAC_1608_Array : FR_Base
	{
		public L3_AbAC_1608[] Result	{ get; set; } 
		public FR_L3_AbAC_1608_Array() : base() {}

		public FR_L3_AbAC_1608_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_AbAC_1608 for attribute P_L3_AbAC_1608
		[DataContract]
		public class P_L3_AbAC_1608 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L3_AbAC_1608 for attribute L3_AbAC_1608
		[DataContract]
		public class L3_AbAC_1608 
		{
			//Standard type parameters
			[DataMember]
			public String Longitude { get; set; } 
			[DataMember]
			public String Lattitude { get; set; } 
			[DataMember]
			public String CareOf { get; set; } 
			[DataMember]
			public Guid Province_EconomicRegion_RefID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public String City_Region { get; set; } 
			[DataMember]
			public String City_AdministrativeDistrict { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_AbAC_1608_Array cls_Adress_by_AccountCode(,P_L3_AbAC_1608 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_AbAC_1608_Array invocationResult = cls_Adress_by_AccountCode.Invoke(connectionString,P_L3_AbAC_1608 Parameter,securityTicket);
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
var parameter = new CL3_MeasurementsMisc.Atomic.Retrieval.P_L3_AbAC_1608();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
