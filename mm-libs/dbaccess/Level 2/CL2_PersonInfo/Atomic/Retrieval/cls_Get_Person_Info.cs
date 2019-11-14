/* 
 * Generated on 3/31/2014 3:24:39 PM
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

namespace CL2_PersonInfo.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Person_Info.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Person_Info
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_LP_PI_GPI_1524_Array Execute(DbConnection Connection,DbTransaction Transaction,P_LP_PI_GPI_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_LP_PI_GPI_1524_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_PersonInfo.Atomic.Retrieval.SQL.cls_Get_Person_Info.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Account_ID", Parameter.Account_ID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant_ID", Parameter.Tenant_ID);



			List<LP_PI_GPI_1524> results = new List<LP_PI_GPI_1524>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FirstName","LastName","PrimaryEmail","Title","Salutation_General","Salutation_Letter","Gender" });
				while(reader.Read())
				{
					LP_PI_GPI_1524 resultItem = new LP_PI_GPI_1524();
					//0:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(0);
					//1:Parameter LastName of type String
					resultItem.LastName = reader.GetString(1);
					//2:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(2);
					//3:Parameter Title of type String
					resultItem.Title = reader.GetString(3);
					//4:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(4);
					//5:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(5);
					//6:Parameter Gender of type String
					resultItem.Gender = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Person_Info",ex);
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
		public static FR_LP_PI_GPI_1524_Array Invoke(string ConnectionString,P_LP_PI_GPI_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_LP_PI_GPI_1524_Array Invoke(DbConnection Connection,P_LP_PI_GPI_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_LP_PI_GPI_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_LP_PI_GPI_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_LP_PI_GPI_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_LP_PI_GPI_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_LP_PI_GPI_1524_Array functionReturn = new FR_LP_PI_GPI_1524_Array();
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

				throw new Exception("Exception occured in method cls_Get_Person_Info",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_LP_PI_GPI_1524_Array : FR_Base
	{
		public LP_PI_GPI_1524[] Result	{ get; set; } 
		public FR_LP_PI_GPI_1524_Array() : base() {}

		public FR_LP_PI_GPI_1524_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_LP_PI_GPI_1524 for attribute P_LP_PI_GPI_1524
		[DataContract]
		public class P_LP_PI_GPI_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid Account_ID { get; set; } 
			[DataMember]
			public Guid Tenant_ID { get; set; } 

		}
		#endregion
		#region SClass LP_PI_GPI_1524 for attribute LP_PI_GPI_1524
		[DataContract]
		public class LP_PI_GPI_1524 
		{
			//Standard type parameters
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String Gender { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_LP_PI_GPI_1524_Array cls_Get_Person_Info(,P_LP_PI_GPI_1524 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_LP_PI_GPI_1524_Array invocationResult = cls_Get_Person_Info.Invoke(connectionString,P_LP_PI_GPI_1524 Parameter,securityTicket);
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
var parameter = new CL2_PersonInfo.Atomic.Retrieval.P_LP_PI_GPI_1524();
parameter.Account_ID = ...;
parameter.Tenant_ID = ...;

*/
