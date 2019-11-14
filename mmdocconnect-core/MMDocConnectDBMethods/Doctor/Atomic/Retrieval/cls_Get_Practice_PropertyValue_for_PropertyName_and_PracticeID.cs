/* 
 * Generated on 03/04/16 09:16:26
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
    /// var result = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GPPVfPNaPID_0916 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GPPVfPNaPID_0916 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GPPVfPNaPID_0916();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PropertyName", Parameter.PropertyName);



			List<DO_GPPVfPNaPID_0916> results = new List<DO_GPPVfPNaPID_0916>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BooleanValue","NumericValue","TextValue" });
				while(reader.Read())
				{
					DO_GPPVfPNaPID_0916 resultItem = new DO_GPPVfPNaPID_0916();
					//0:Parameter BooleanValue of type Boolean
					resultItem.BooleanValue = reader.GetBoolean(0);
					//1:Parameter NumericValue of type Double
					resultItem.NumericValue = reader.GetDouble(1);
					//2:Parameter TextValue of type String
					resultItem.TextValue = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID",ex);
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
		public static FR_DO_GPPVfPNaPID_0916 Invoke(string ConnectionString,P_DO_GPPVfPNaPID_0916 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GPPVfPNaPID_0916 Invoke(DbConnection Connection,P_DO_GPPVfPNaPID_0916 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GPPVfPNaPID_0916 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GPPVfPNaPID_0916 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GPPVfPNaPID_0916 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GPPVfPNaPID_0916 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GPPVfPNaPID_0916 functionReturn = new FR_DO_GPPVfPNaPID_0916();
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

				throw new Exception("Exception occured in method cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GPPVfPNaPID_0916 : FR_Base
	{
		public DO_GPPVfPNaPID_0916 Result	{ get; set; }

		public FR_DO_GPPVfPNaPID_0916() : base() {}

		public FR_DO_GPPVfPNaPID_0916(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GPPVfPNaPID_0916 for attribute P_DO_GPPVfPNaPID_0916
		[DataContract]
		public class P_DO_GPPVfPNaPID_0916 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public String PropertyName { get; set; } 

		}
		#endregion
		#region SClass DO_GPPVfPNaPID_0916 for attribute DO_GPPVfPNaPID_0916
		[DataContract]
		public class DO_GPPVfPNaPID_0916 
		{
			//Standard type parameters
			[DataMember]
			public Boolean BooleanValue { get; set; } 
			[DataMember]
			public Double NumericValue { get; set; } 
			[DataMember]
			public String TextValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GPPVfPNaPID_0916 cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID(,P_DO_GPPVfPNaPID_0916 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPPVfPNaPID_0916 invocationResult = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString,P_DO_GPPVfPNaPID_0916 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GPPVfPNaPID_0916();
parameter.PracticeID = ...;
parameter.PropertyName = ...;

*/
