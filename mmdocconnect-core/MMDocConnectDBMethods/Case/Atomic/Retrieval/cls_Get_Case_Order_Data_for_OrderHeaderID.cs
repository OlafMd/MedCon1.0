/* 
 * Generated on 1/25/2017 4:57:46 PM
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_Order_Data_for_OrderHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_Order_Data_for_OrderHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCODfOHID_1413 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCODfOHID_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCODfOHID_1413();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_Order_Data_for_OrderHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderHeaderID", Parameter.OrderHeaderID);



			List<CAS_GCODfOHID_1413> results = new List<CAS_GCODfOHID_1413>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "treatment_date","patient_first_name","patient_last_name","patient_birthdate","patient_fee_waived","label_only","order_comment","drug_id","case_id","treatment_exist" });
				while(reader.Read())
				{
					CAS_GCODfOHID_1413 resultItem = new CAS_GCODfOHID_1413();
					//0:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(0);
					//1:Parameter patient_first_name of type String
					resultItem.patient_first_name = reader.GetString(1);
					//2:Parameter patient_last_name of type String
					resultItem.patient_last_name = reader.GetString(2);
					//3:Parameter patient_birthdate of type DateTime
					resultItem.patient_birthdate = reader.GetDate(3);
					//4:Parameter patient_fee_waived of type Boolean
					resultItem.patient_fee_waived = reader.GetBoolean(4);
					//5:Parameter label_only of type Boolean
					resultItem.label_only = reader.GetBoolean(5);
					//6:Parameter order_comment of type String
					resultItem.order_comment = reader.GetString(6);
					//7:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(7);
					//8:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(8);
					//9:Parameter treatment_exist of type Boolean
					resultItem.treatment_exist = reader.GetBoolean(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_Order_Data_for_OrderHeaderID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GCODfOHID_1413 Invoke(string ConnectionString,P_CAS_GCODfOHID_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCODfOHID_1413 Invoke(DbConnection Connection,P_CAS_GCODfOHID_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCODfOHID_1413 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCODfOHID_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCODfOHID_1413 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCODfOHID_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCODfOHID_1413 functionReturn = new FR_CAS_GCODfOHID_1413();
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

				throw new Exception("Exception occured in method cls_Get_Case_Order_Data_for_OrderHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCODfOHID_1413 : FR_Base
	{
		public CAS_GCODfOHID_1413 Result	{ get; set; }

		public FR_CAS_GCODfOHID_1413() : base() {}

		public FR_CAS_GCODfOHID_1413(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCODfOHID_1413 for attribute P_CAS_GCODfOHID_1413
		[DataContract]
		public class P_CAS_GCODfOHID_1413 
		{
			//Standard type parameters
			[DataMember]
			public Guid OrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass CAS_GCODfOHID_1413 for attribute CAS_GCODfOHID_1413
		[DataContract]
		public class CAS_GCODfOHID_1413 
		{
			//Standard type parameters
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public String patient_first_name { get; set; } 
			[DataMember]
			public String patient_last_name { get; set; } 
			[DataMember]
			public DateTime patient_birthdate { get; set; } 
			[DataMember]
			public Boolean patient_fee_waived { get; set; } 
			[DataMember]
			public Boolean label_only { get; set; } 
			[DataMember]
			public String order_comment { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Boolean treatment_exist { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCODfOHID_1413 cls_Get_Case_Order_Data_for_OrderHeaderID(,P_CAS_GCODfOHID_1413 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCODfOHID_1413 invocationResult = cls_Get_Case_Order_Data_for_OrderHeaderID.Invoke(connectionString,P_CAS_GCODfOHID_1413 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCODfOHID_1413();
parameter.OrderHeaderID = ...;

*/
