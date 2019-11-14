/* 
 * Generated on 03/02/17 17:00:56
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

namespace MMDocConnectDBMethods.Order.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Potential_Orders_Eligible_for_Settlement.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Potential_Orders_Eligible_for_Settlement
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_OR_GPOEfS_1518_Array Execute(DbConnection Connection,DbTransaction Transaction,P_OR_GPOEfS_1518 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_OR_GPOEfS_1518_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Order.Atomic.Retrieval.SQL.cls_Get_Potential_Orders_Eligible_for_Settlement.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<OR_GPOEfS_1518> results = new List<OR_GPOEfS_1518>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "order_id","drug_id","treatment_date","patient_id" });
				while(reader.Read())
				{
					OR_GPOEfS_1518 resultItem = new OR_GPOEfS_1518();
					//0:Parameter order_id of type Guid
					resultItem.order_id = reader.GetGuid(0);
					//1:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(1);
					//2:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(2);
					//3:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Potential_Orders_Eligible_for_Settlement",ex);
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
		public static FR_OR_GPOEfS_1518_Array Invoke(string ConnectionString,P_OR_GPOEfS_1518 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_OR_GPOEfS_1518_Array Invoke(DbConnection Connection,P_OR_GPOEfS_1518 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_OR_GPOEfS_1518_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_OR_GPOEfS_1518 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_OR_GPOEfS_1518_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_OR_GPOEfS_1518 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_OR_GPOEfS_1518_Array functionReturn = new FR_OR_GPOEfS_1518_Array();
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

				throw new Exception("Exception occured in method cls_Get_Potential_Orders_Eligible_for_Settlement",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_OR_GPOEfS_1518_Array : FR_Base
	{
		public OR_GPOEfS_1518[] Result	{ get; set; } 
		public FR_OR_GPOEfS_1518_Array() : base() {}

		public FR_OR_GPOEfS_1518_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_OR_GPOEfS_1518 for attribute P_OR_GPOEfS_1518
		[DataContract]
		public class P_OR_GPOEfS_1518 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass OR_GPOEfS_1518 for attribute OR_GPOEfS_1518
		[DataContract]
		public class OR_GPOEfS_1518 
		{
			//Standard type parameters
			[DataMember]
			public Guid order_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_OR_GPOEfS_1518_Array cls_Get_Potential_Orders_Eligible_for_Settlement(,P_OR_GPOEfS_1518 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_OR_GPOEfS_1518_Array invocationResult = cls_Get_Potential_Orders_Eligible_for_Settlement.Invoke(connectionString,P_OR_GPOEfS_1518 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Atomic.Retrieval.P_OR_GPOEfS_1518();
parameter.PatientIDs = ...;

*/
