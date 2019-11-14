/* 
 * Generated on 11/02/16 12:20:12
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
    /// var result = cls_Get_Case_DoctorData_for_DoctorBptID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_DoctorData_for_DoctorBptID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCDDfDBptID_1242 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCDDfDBptID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCDDfDBptID_1242();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_DoctorData_for_DoctorBptID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorBptID", Parameter.DoctorBptID);



			List<CAS_GCDDfDBptID_1242> results = new List<CAS_GCDDfDBptID_1242>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "id","title","first_name","last_name","practice_id" });
				while(reader.Read())
				{
					CAS_GCDDfDBptID_1242 resultItem = new CAS_GCDDfDBptID_1242();
					//0:Parameter id of type Guid
					resultItem.id = reader.GetGuid(0);
					//1:Parameter title of type String
					resultItem.title = reader.GetString(1);
					//2:Parameter first_name of type String
					resultItem.first_name = reader.GetString(2);
					//3:Parameter last_name of type String
					resultItem.last_name = reader.GetString(3);
					//4:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_DoctorData_for_DoctorBptID",ex);
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
		public static FR_CAS_GCDDfDBptID_1242 Invoke(string ConnectionString,P_CAS_GCDDfDBptID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCDDfDBptID_1242 Invoke(DbConnection Connection,P_CAS_GCDDfDBptID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCDDfDBptID_1242 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCDDfDBptID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCDDfDBptID_1242 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCDDfDBptID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCDDfDBptID_1242 functionReturn = new FR_CAS_GCDDfDBptID_1242();
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

				throw new Exception("Exception occured in method cls_Get_Case_DoctorData_for_DoctorBptID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCDDfDBptID_1242 : FR_Base
	{
		public CAS_GCDDfDBptID_1242 Result	{ get; set; }

		public FR_CAS_GCDDfDBptID_1242() : base() {}

		public FR_CAS_GCDDfDBptID_1242(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCDDfDBptID_1242 for attribute P_CAS_GCDDfDBptID_1242
		[DataContract]
		public class P_CAS_GCDDfDBptID_1242 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorBptID { get; set; } 

		}
		#endregion
		#region SClass CAS_GCDDfDBptID_1242 for attribute CAS_GCDDfDBptID_1242
		[DataContract]
		public class CAS_GCDDfDBptID_1242 
		{
			//Standard type parameters
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public String title { get; set; } 
			[DataMember]
			public String first_name { get; set; } 
			[DataMember]
			public String last_name { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCDDfDBptID_1242 cls_Get_Case_DoctorData_for_DoctorBptID(,P_CAS_GCDDfDBptID_1242 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCDDfDBptID_1242 invocationResult = cls_Get_Case_DoctorData_for_DoctorBptID.Invoke(connectionString,P_CAS_GCDDfDBptID_1242 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCDDfDBptID_1242();
parameter.DoctorBptID = ...;

*/
