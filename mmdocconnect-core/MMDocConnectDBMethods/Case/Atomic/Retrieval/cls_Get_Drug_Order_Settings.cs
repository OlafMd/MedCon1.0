/* 
 * Generated on 08/06/15 15:57:18
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
    /// var result = cls_Get_Drug_Order_Settings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Drug_Order_Settings
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GDOS_1108 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GDOS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GDOS_1108();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Drug_Order_Settings.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CaseID", Parameter.CaseID);



			List<CAS_GDOS_1108> results = new List<CAS_GDOS_1108>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "drug_id","is_label_only","is_patient_fee_waived","is_send_invoice_to_practice","treatment_date" });
				while(reader.Read())
				{
					CAS_GDOS_1108 resultItem = new CAS_GDOS_1108();
					//0:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(0);
					//1:Parameter is_label_only of type Boolean
					resultItem.is_label_only = reader.GetBoolean(1);
					//2:Parameter is_patient_fee_waived of type Boolean
					resultItem.is_patient_fee_waived = reader.GetBoolean(2);
					//3:Parameter is_send_invoice_to_practice of type Boolean
					resultItem.is_send_invoice_to_practice = reader.GetBoolean(3);
					//4:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Drug_Order_Settings",ex);
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
		public static FR_CAS_GDOS_1108 Invoke(string ConnectionString,P_CAS_GDOS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GDOS_1108 Invoke(DbConnection Connection,P_CAS_GDOS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GDOS_1108 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GDOS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GDOS_1108 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GDOS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GDOS_1108 functionReturn = new FR_CAS_GDOS_1108();
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

				throw new Exception("Exception occured in method cls_Get_Drug_Order_Settings",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GDOS_1108 : FR_Base
	{
		public CAS_GDOS_1108 Result	{ get; set; }

		public FR_CAS_GDOS_1108() : base() {}

		public FR_CAS_GDOS_1108(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GDOS_1108 for attribute P_CAS_GDOS_1108
		[DataContract]
		public class P_CAS_GDOS_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GDOS_1108 for attribute CAS_GDOS_1108
		[DataContract]
		public class CAS_GDOS_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Boolean is_label_only { get; set; } 
			[DataMember]
			public Boolean is_patient_fee_waived { get; set; } 
			[DataMember]
			public Boolean is_send_invoice_to_practice { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GDOS_1108 cls_Get_Drug_Order_Settings(,P_CAS_GDOS_1108 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GDOS_1108 invocationResult = cls_Get_Drug_Order_Settings.Invoke(connectionString,P_CAS_GDOS_1108 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GDOS_1108();
parameter.CaseID = ...;

*/
