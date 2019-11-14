/* 
 * Generated on 12/3/2014 8:40:03 PM
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

namespace CL5_Lucentis_Aftercare.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AftercareCount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AftercareCount
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L5AF_GAC_1132 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AF_GAC_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AF_GAC_1132();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Aftercare.Atomic.Retrieval.SQL.cls_Get_AftercareCount.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"S_Practice", Parameter.S_Practice);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"statusParameters", Parameter.statusParameters);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"s_doctorParam", Parameter.s_doctorParam);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"s_scheduled_doctorParam", Parameter.s_scheduled_doctorParam);

            /***Search parameters**/
            if (Parameter.S_Practice != "")
            {
                string newText = command.CommandText.Replace("@S_Practice", Parameter.S_Practice);
                command.CommandText = newText;
            }

            if (Parameter.s_doctorParam != "")
            {
                string newText = command.CommandText.Replace("@s_doctorParam", Parameter.s_doctorParam);
                command.CommandText = newText;
            }

            if (Parameter.s_scheduled_doctorParam != "")
            {
                string newText = command.CommandText.Replace("@s_scheduled_doctorParam", Parameter.s_scheduled_doctorParam);
                command.CommandText = newText;
            }

            /***status parameters**/
            if (Parameter.statusParameters != "")
            {
                string newText = command.CommandText.Replace("@statusParameters", Parameter.statusParameters);
                command.CommandText = newText;
            }

			List<L5AF_GAC_1132> results = new List<L5AF_GAC_1132>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "total_record_count" });
				while(reader.Read())
				{
					L5AF_GAC_1132 resultItem = new L5AF_GAC_1132();
					//0:Parameter total_record_count of type int
					resultItem.total_record_count = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AftercareCount",ex);
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
		public static FR_L5AF_GAC_1132 Invoke(string ConnectionString,P_L5AF_GAC_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AF_GAC_1132 Invoke(DbConnection Connection,P_L5AF_GAC_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AF_GAC_1132 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AF_GAC_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AF_GAC_1132 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AF_GAC_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AF_GAC_1132 functionReturn = new FR_L5AF_GAC_1132();
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

				throw new Exception("Exception occured in method cls_Get_AftercareCount",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AF_GAC_1132 : FR_Base
	{
		public L5AF_GAC_1132 Result	{ get; set; }

		public FR_L5AF_GAC_1132() : base() {}

		public FR_L5AF_GAC_1132(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AF_GAC_1132 for attribute P_L5AF_GAC_1132
		[DataContract]
		public class P_L5AF_GAC_1132 
		{
			//Standard type parameters
			[DataMember]
			public String S_Practice { get; set; } 
			[DataMember]
			public String statusParameters { get; set; } 
			[DataMember]
			public String s_doctorParam { get; set; } 
			[DataMember]
			public String s_scheduled_doctorParam { get; set; } 

		}
		#endregion
		#region SClass L5AF_GAC_1132 for attribute L5AF_GAC_1132
		[DataContract]
		public class L5AF_GAC_1132 
		{
			//Standard type parameters
			[DataMember]
			public int total_record_count { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AF_GAC_1132 cls_Get_AftercareCount(,P_L5AF_GAC_1132 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AF_GAC_1132 invocationResult = cls_Get_AftercareCount.Invoke(connectionString,P_L5AF_GAC_1132 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Aftercare.Atomic.Retrieval.P_L5AF_GAC_1132();
parameter.S_Practice = ...;
parameter.statusParameters = ...;
parameter.s_doctorParam = ...;
parameter.s_scheduled_doctorParam = ...;

*/
