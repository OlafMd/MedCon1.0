/* 
 * Generated on 2/25/2015 9:12:56 PM
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

namespace CL3_Measurements.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_MeasurementValues_by_AccountCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_MeasurementValues_by_AccountCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_MVbAC_1547_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_MVbAC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_MVbAC_1547_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Measurements.Atomic.Retrieval.SQL.cls_MeasurementValues_by_AccountCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L3_MVbAC_1547> results = new List<L3_MVbAC_1547>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MRS_RUN_Measurement_ValueID","Measurement_RefID","MeasurementValue","MeasurementTariff_RefID","Measurement_AcquisitionType_RefID","MeasuredAt_Time","MeasuredAt_Lattitude","MeasuredAt_Longitude","Creation_Timestamp","Tenant_RefID","IsDeleted" });
				while(reader.Read())
				{
					L3_MVbAC_1547 resultItem = new L3_MVbAC_1547();
					//0:Parameter MRS_RUN_Measurement_ValueID of type Guid
					resultItem.MRS_RUN_Measurement_ValueID = reader.GetGuid(0);
					//1:Parameter Measurement_RefID of type Guid
					resultItem.Measurement_RefID = reader.GetGuid(1);
					//2:Parameter MeasurementValue of type String
					resultItem.MeasurementValue = reader.GetString(2);
					//3:Parameter MeasurementTariff_RefID of type Guid
					resultItem.MeasurementTariff_RefID = reader.GetGuid(3);
					//4:Parameter Measurement_AcquisitionType_RefID of type Guid
					resultItem.Measurement_AcquisitionType_RefID = reader.GetGuid(4);
					//5:Parameter MeasuredAt_Time of type DateTime
					resultItem.MeasuredAt_Time = reader.GetDate(5);
					//6:Parameter MeasuredAt_Lattitude of type String
					resultItem.MeasuredAt_Lattitude = reader.GetString(6);
					//7:Parameter MeasuredAt_Longitude of type String
					resultItem.MeasuredAt_Longitude = reader.GetString(7);
					//8:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(8);
					//9:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(9);
					//10:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_MeasurementValues_by_AccountCode",ex);
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
		public static FR_L3_MVbAC_1547_Array Invoke(string ConnectionString,P_L3_MVbAC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_MVbAC_1547_Array Invoke(DbConnection Connection,P_L3_MVbAC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_MVbAC_1547_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_MVbAC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_MVbAC_1547_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_MVbAC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_MVbAC_1547_Array functionReturn = new FR_L3_MVbAC_1547_Array();
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

				throw new Exception("Exception occured in method cls_MeasurementValues_by_AccountCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_MVbAC_1547_Array : FR_Base
	{
		public L3_MVbAC_1547[] Result	{ get; set; } 
		public FR_L3_MVbAC_1547_Array() : base() {}

		public FR_L3_MVbAC_1547_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_MVbAC_1547 for attribute P_L3_MVbAC_1547
		[DataContract]
		public class P_L3_MVbAC_1547 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L3_MVbAC_1547 for attribute L3_MVbAC_1547
		[DataContract]
		public class L3_MVbAC_1547 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_RUN_Measurement_ValueID { get; set; } 
			[DataMember]
			public Guid Measurement_RefID { get; set; } 
			[DataMember]
			public String MeasurementValue { get; set; } 
			[DataMember]
			public Guid MeasurementTariff_RefID { get; set; } 
			[DataMember]
			public Guid Measurement_AcquisitionType_RefID { get; set; } 
			[DataMember]
			public DateTime MeasuredAt_Time { get; set; } 
			[DataMember]
			public String MeasuredAt_Lattitude { get; set; } 
			[DataMember]
			public String MeasuredAt_Longitude { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_MVbAC_1547_Array cls_MeasurementValues_by_AccountCode(,P_L3_MVbAC_1547 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_MVbAC_1547_Array invocationResult = cls_MeasurementValues_by_AccountCode.Invoke(connectionString,P_L3_MVbAC_1547 Parameter,securityTicket);
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
var parameter = new CL3_Measurements.Atomic.Retrieval.P_L3_MVbAC_1547();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
