/* 
 * Generated on 3/29/2017 5:46:54 PM
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ElasticRefresh_Orders_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ElasticRefresh_Orders_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GEROfPID_1123_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GEROfPID_1123 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GEROfPID_1123_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_ElasticRefresh_Orders_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<ER_GEROfPID_1123> results = new List<ER_GEROfPID_1123>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "patient_id","status_code","case_id","order_id","delivery_time_from","delivery_time_to","delivery_date","treatment_date","pharmacy_bpt_id","order_modification_timestamp","practice_id","drug_id" });
				while(reader.Read())
				{
					ER_GEROfPID_1123 resultItem = new ER_GEROfPID_1123();
					//0:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(0);
					//1:Parameter status_code of type int
					resultItem.status_code = reader.GetInteger(1);
					//2:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(2);
					//3:Parameter order_id of type Guid
					resultItem.order_id = reader.GetGuid(3);
					//4:Parameter delivery_time_from of type DateTime
					resultItem.delivery_time_from = reader.GetDate(4);
					//5:Parameter delivery_time_to of type DateTime
					resultItem.delivery_time_to = reader.GetDate(5);
					//6:Parameter delivery_date of type DateTime
					resultItem.delivery_date = reader.GetDate(6);
					//7:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(7);
					//8:Parameter pharmacy_bpt_id of type Guid
					resultItem.pharmacy_bpt_id = reader.GetGuid(8);
					//9:Parameter order_modification_timestamp of type DateTime
					resultItem.order_modification_timestamp = reader.GetDate(9);
					//10:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(10);
					//11:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ElasticRefresh_Orders_for_PatientID",ex);
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
		public static FR_ER_GEROfPID_1123_Array Invoke(string ConnectionString,P_ER_GEROfPID_1123 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GEROfPID_1123_Array Invoke(DbConnection Connection,P_ER_GEROfPID_1123 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GEROfPID_1123_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GEROfPID_1123 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GEROfPID_1123_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GEROfPID_1123 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GEROfPID_1123_Array functionReturn = new FR_ER_GEROfPID_1123_Array();
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

				throw new Exception("Exception occured in method cls_Get_ElasticRefresh_Orders_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GEROfPID_1123_Array : FR_Base
	{
		public ER_GEROfPID_1123[] Result	{ get; set; } 
		public FR_ER_GEROfPID_1123_Array() : base() {}

		public FR_ER_GEROfPID_1123_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GEROfPID_1123 for attribute P_ER_GEROfPID_1123
		[DataContract]
		public class P_ER_GEROfPID_1123 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass ER_GEROfPID_1123 for attribute ER_GEROfPID_1123
		[DataContract]
		public class ER_GEROfPID_1123 
		{
			//Standard type parameters
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public int status_code { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid order_id { get; set; } 
			[DataMember]
			public DateTime delivery_time_from { get; set; } 
			[DataMember]
			public DateTime delivery_time_to { get; set; } 
			[DataMember]
			public DateTime delivery_date { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid pharmacy_bpt_id { get; set; } 
			[DataMember]
			public DateTime order_modification_timestamp { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GEROfPID_1123_Array cls_Get_ElasticRefresh_Orders_for_PatientID(,P_ER_GEROfPID_1123 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GEROfPID_1123_Array invocationResult = cls_Get_ElasticRefresh_Orders_for_PatientID.Invoke(connectionString,P_ER_GEROfPID_1123 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GEROfPID_1123();
parameter.PatientIDs = ...;

*/
