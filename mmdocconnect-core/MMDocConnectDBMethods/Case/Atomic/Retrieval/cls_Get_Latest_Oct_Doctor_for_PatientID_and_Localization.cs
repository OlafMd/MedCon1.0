/* 
 * Generated on 4/22/2017 8:38:05 PM
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
    /// var result = cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GLOctDfPIDaLC_1644 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GLOctDfPIDaLC_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GLOctDfPIDaLC_1644();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PlannedActionTypeID", Parameter.PlannedActionTypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LocalizationCode", Parameter.LocalizationCode);



			List<CAS_GLOctDfPIDaLC_1644> results = new List<CAS_GLOctDfPIDaLC_1644>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "title","first_name","last_name","id" });
				while(reader.Read())
				{
					CAS_GLOctDfPIDaLC_1644 resultItem = new CAS_GLOctDfPIDaLC_1644();
					//0:Parameter title of type String
					resultItem.title = reader.GetString(0);
					//1:Parameter first_name of type String
					resultItem.first_name = reader.GetString(1);
					//2:Parameter last_name of type String
					resultItem.last_name = reader.GetString(2);
					//3:Parameter id of type Guid
					resultItem.id = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization",ex);
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
		public static FR_CAS_GLOctDfPIDaLC_1644 Invoke(string ConnectionString,P_CAS_GLOctDfPIDaLC_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GLOctDfPIDaLC_1644 Invoke(DbConnection Connection,P_CAS_GLOctDfPIDaLC_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GLOctDfPIDaLC_1644 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GLOctDfPIDaLC_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GLOctDfPIDaLC_1644 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GLOctDfPIDaLC_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GLOctDfPIDaLC_1644 functionReturn = new FR_CAS_GLOctDfPIDaLC_1644();
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

				throw new Exception("Exception occured in method cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GLOctDfPIDaLC_1644 : FR_Base
	{
		public CAS_GLOctDfPIDaLC_1644 Result	{ get; set; }

		public FR_CAS_GLOctDfPIDaLC_1644() : base() {}

		public FR_CAS_GLOctDfPIDaLC_1644(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GLOctDfPIDaLC_1644 for attribute P_CAS_GLOctDfPIDaLC_1644
		[DataContract]
		public class P_CAS_GLOctDfPIDaLC_1644 
		{
			//Standard type parameters
			[DataMember]
			public Guid PlannedActionTypeID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public String LocalizationCode { get; set; } 

		}
		#endregion
		#region SClass CAS_GLOctDfPIDaLC_1644 for attribute CAS_GLOctDfPIDaLC_1644
		[DataContract]
		public class CAS_GLOctDfPIDaLC_1644 
		{
			//Standard type parameters
			[DataMember]
			public String title { get; set; } 
			[DataMember]
			public String first_name { get; set; } 
			[DataMember]
			public String last_name { get; set; } 
			[DataMember]
			public Guid id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GLOctDfPIDaLC_1644 cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization(,P_CAS_GLOctDfPIDaLC_1644 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GLOctDfPIDaLC_1644 invocationResult = cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization.Invoke(connectionString,P_CAS_GLOctDfPIDaLC_1644 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GLOctDfPIDaLC_1644();
parameter.PlannedActionTypeID = ...;
parameter.PatientID = ...;
parameter.LocalizationCode = ...;

*/
