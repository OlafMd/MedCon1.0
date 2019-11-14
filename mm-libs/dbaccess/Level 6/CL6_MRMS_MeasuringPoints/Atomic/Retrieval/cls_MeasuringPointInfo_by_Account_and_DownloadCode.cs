/* 
 * Generated on 2/25/2015 1:15:34 AM
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

namespace CL6_MRMS_MeasuringPoints.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_MeasuringPointInfo_by_Account_and_DownloadCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_MeasuringPointInfo_by_Account_and_DownloadCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6_MPIbAaDC_1058_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6_MPIbAaDC_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6_MPIbAaDC_1058_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MRMS_MeasuringPoints.Atomic.Retrieval.SQL.cls_MeasuringPointInfo_by_Account_and_DownloadCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L6_MPIbAaDC_1058> results = new List<L6_MPIbAaDC_1058>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MRS_MPT_MeasuringPointID","ExternalMeasuringPointID","Street_Name","Street_Number","OwnerFirstName","OwnerLastName","MeterSerial","City_Name","City_PostalCode","Country_Name" });
				while(reader.Read())
				{
					L6_MPIbAaDC_1058 resultItem = new L6_MPIbAaDC_1058();
					//0:Parameter MRS_MPT_MeasuringPointID of type Guid
					resultItem.MRS_MPT_MeasuringPointID = reader.GetGuid(0);
					//1:Parameter ExternalMeasuringPointID of type string
					resultItem.ExternalMeasuringPointID = reader.GetString(1);
					//2:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(2);
					//3:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(3);
					//4:Parameter OwnerFirstName of type String
					resultItem.OwnerFirstName = reader.GetString(4);
					//5:Parameter OwnerLastName of type String
					resultItem.OwnerLastName = reader.GetString(5);
					//6:Parameter MeterSerial of type String
					resultItem.MeterSerial = reader.GetString(6);
					//7:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(7);
					//8:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(8);
					//9:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_MeasuringPointInfo_by_Account_and_DownloadCode",ex);
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
		public static FR_L6_MPIbAaDC_1058_Array Invoke(string ConnectionString,P_L6_MPIbAaDC_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6_MPIbAaDC_1058_Array Invoke(DbConnection Connection,P_L6_MPIbAaDC_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6_MPIbAaDC_1058_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6_MPIbAaDC_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6_MPIbAaDC_1058_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6_MPIbAaDC_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6_MPIbAaDC_1058_Array functionReturn = new FR_L6_MPIbAaDC_1058_Array();
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

				throw new Exception("Exception occured in method cls_MeasuringPointInfo_by_Account_and_DownloadCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6_MPIbAaDC_1058_Array : FR_Base
	{
		public L6_MPIbAaDC_1058[] Result	{ get; set; } 
		public FR_L6_MPIbAaDC_1058_Array() : base() {}

		public FR_L6_MPIbAaDC_1058_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6_MPIbAaDC_1058 for attribute P_L6_MPIbAaDC_1058
		[DataContract]
		public class P_L6_MPIbAaDC_1058 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L6_MPIbAaDC_1058 for attribute L6_MPIbAaDC_1058
		[DataContract]
		public class L6_MPIbAaDC_1058 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_MPT_MeasuringPointID { get; set; } 
			[DataMember]
			public string ExternalMeasuringPointID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String OwnerFirstName { get; set; } 
			[DataMember]
			public String OwnerLastName { get; set; } 
			[DataMember]
			public String MeterSerial { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6_MPIbAaDC_1058_Array cls_MeasuringPointInfo_by_Account_and_DownloadCode(,P_L6_MPIbAaDC_1058 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6_MPIbAaDC_1058_Array invocationResult = cls_MeasuringPointInfo_by_Account_and_DownloadCode.Invoke(connectionString,P_L6_MPIbAaDC_1058 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_MeasuringPoints.Atomic.Retrieval.P_L6_MPIbAaDC_1058();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
