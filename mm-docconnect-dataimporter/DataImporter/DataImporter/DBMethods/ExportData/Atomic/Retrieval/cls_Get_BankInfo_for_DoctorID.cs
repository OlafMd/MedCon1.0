/* 
 * Generated on 1/20/2017 2:34:28 PM
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

namespace DataImporter.DBMethods.ExportData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BankInfo_for_DoctorID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BankInfo_for_DoctorID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_BBIfDID_1424 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_BBIfDID_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_BBIfDID_1424();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_BankInfo_for_DoctorID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);



			List<DO_BBIfDID_1424> results = new List<DO_BBIfDID_1424>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OwnerText","IBAN","BICCode","BankName","BankID","BankAccountID" });
				while(reader.Read())
				{
					DO_BBIfDID_1424 resultItem = new DO_BBIfDID_1424();
					//0:Parameter OwnerText of type String
					resultItem.OwnerText = reader.GetString(0);
					//1:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(1);
					//2:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(2);
					//3:Parameter BankName of type String
					resultItem.BankName = reader.GetString(3);
					//4:Parameter BankID of type Guid
					resultItem.BankID = reader.GetGuid(4);
					//5:Parameter BankAccountID of type Guid
					resultItem.BankAccountID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BankInfo_for_DoctorID",ex);
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
		public static FR_DO_BBIfDID_1424 Invoke(string ConnectionString,P_DO_BBIfDID_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_BBIfDID_1424 Invoke(DbConnection Connection,P_DO_BBIfDID_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_BBIfDID_1424 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_BBIfDID_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_BBIfDID_1424 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_BBIfDID_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_BBIfDID_1424 functionReturn = new FR_DO_BBIfDID_1424();
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

				throw new Exception("Exception occured in method cls_Get_BankInfo_for_DoctorID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_BBIfDID_1424 : FR_Base
	{
		public DO_BBIfDID_1424 Result	{ get; set; }

		public FR_DO_BBIfDID_1424() : base() {}

		public FR_DO_BBIfDID_1424(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_BBIfDID_1424 for attribute P_DO_BBIfDID_1424
		[DataContract]
		public class P_DO_BBIfDID_1424 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass DO_BBIfDID_1424 for attribute DO_BBIfDID_1424
		[DataContract]
		public class DO_BBIfDID_1424 
		{
			//Standard type parameters
			[DataMember]
			public String OwnerText { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public Guid BankID { get; set; } 
			[DataMember]
			public Guid BankAccountID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_BBIfDID_1424 cls_Get_BankInfo_for_DoctorID(,P_DO_BBIfDID_1424 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_BBIfDID_1424 invocationResult = cls_Get_BankInfo_for_DoctorID.Invoke(connectionString,P_DO_BBIfDID_1424 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Atomic.Retrieval.P_DO_BBIfDID_1424();
parameter.DoctorID = ...;

*/