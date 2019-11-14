/* 
 * Generated on 06/12/15 14:20:02
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

namespace MMDocConnectDBMethods.Doctor.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_Default_Settings_for_PracticeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GPDSfPID_0909 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GPDSfPID_0909 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GPDSfPID_0909();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Practice_Default_Settings_for_PracticeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);



			List<DO_GPDSfPID_0909> results = new List<DO_GPDSfPID_0909>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OrderDrugs","DefaultShippingDateOffset","OnlyLabelRequired","WaiveServiceFee" });
				while(reader.Read())
				{
					DO_GPDSfPID_0909 resultItem = new DO_GPDSfPID_0909();
					//0:Parameter OrderDrugs of type Boolean
					resultItem.OrderDrugs = reader.GetBoolean(0);
					//1:Parameter DefaultShippingDateOffset of type Double
					resultItem.DefaultShippingDateOffset = reader.GetDouble(1);
					//2:Parameter OnlyLabelRequired of type Boolean
					resultItem.OnlyLabelRequired = reader.GetBoolean(2);
					//3:Parameter WaiveServiceFee of type Boolean
					resultItem.WaiveServiceFee = reader.GetBoolean(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_Default_Settings_for_PracticeID",ex);
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
		public static FR_DO_GPDSfPID_0909 Invoke(string ConnectionString,P_DO_GPDSfPID_0909 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GPDSfPID_0909 Invoke(DbConnection Connection,P_DO_GPDSfPID_0909 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GPDSfPID_0909 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GPDSfPID_0909 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GPDSfPID_0909 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GPDSfPID_0909 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GPDSfPID_0909 functionReturn = new FR_DO_GPDSfPID_0909();
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

				throw new Exception("Exception occured in method cls_Get_Practice_Default_Settings_for_PracticeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GPDSfPID_0909 : FR_Base
	{
		public DO_GPDSfPID_0909 Result	{ get; set; }

		public FR_DO_GPDSfPID_0909() : base() {}

		public FR_DO_GPDSfPID_0909(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GPDSfPID_0909 for attribute P_DO_GPDSfPID_0909
		[DataContract]
		public class P_DO_GPDSfPID_0909 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass DO_GPDSfPID_0909 for attribute DO_GPDSfPID_0909
		[DataContract]
		public class DO_GPDSfPID_0909 
		{
			//Standard type parameters
			[DataMember]
			public Boolean OrderDrugs { get; set; } 
			[DataMember]
			public Double DefaultShippingDateOffset { get; set; } 
			[DataMember]
			public Boolean OnlyLabelRequired { get; set; } 
			[DataMember]
			public Boolean WaiveServiceFee { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GPDSfPID_0909 cls_Get_Practice_Default_Settings_for_PracticeID(,P_DO_GPDSfPID_0909 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPDSfPID_0909 invocationResult = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(connectionString,P_DO_GPDSfPID_0909 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GPDSfPID_0909();
parameter.PracticeID = ...;

*/
