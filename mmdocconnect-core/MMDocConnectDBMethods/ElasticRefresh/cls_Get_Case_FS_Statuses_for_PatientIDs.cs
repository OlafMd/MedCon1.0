/* 
 * Generated on 4/22/2017 9:40:38 PM
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_FS_Statuses_for_PatientIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_FS_Statuses_for_PatientIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_FCFSSfPIDs_1759_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_FCFSSfPIDs_1759 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_FCFSSfPIDs_1759_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_Case_FS_Statuses_for_PatientIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<ER_FCFSSfPIDs_1759> results = new List<ER_FCFSSfPIDs_1759>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "case_fs_status_code","case_id","case_type","gpos_type","status_date","price","hec_bill_position_id","patient_id","localization" });
				while(reader.Read())
				{
					ER_FCFSSfPIDs_1759 resultItem = new ER_FCFSSfPIDs_1759();
					//0:Parameter case_fs_status_code of type int
					resultItem.case_fs_status_code = reader.GetInteger(0);
					//1:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(1);
					//2:Parameter case_type of type String
					resultItem.case_type = reader.GetString(2);
					//3:Parameter gpos_type of type String
					resultItem.gpos_type = reader.GetString(3);
					//4:Parameter status_date of type DateTime
					resultItem.status_date = reader.GetDate(4);
					//5:Parameter price of type Double
					resultItem.price = reader.GetDouble(5);
					//6:Parameter hec_bill_position_id of type Guid
					resultItem.hec_bill_position_id = reader.GetGuid(6);
					//7:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(7);
					//8:Parameter localization of type String
					resultItem.localization = reader.GetString(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_FS_Statuses_for_PatientIDs",ex);
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
		public static FR_ER_FCFSSfPIDs_1759_Array Invoke(string ConnectionString,P_ER_FCFSSfPIDs_1759 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_FCFSSfPIDs_1759_Array Invoke(DbConnection Connection,P_ER_FCFSSfPIDs_1759 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_FCFSSfPIDs_1759_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_FCFSSfPIDs_1759 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_FCFSSfPIDs_1759_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_FCFSSfPIDs_1759 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_FCFSSfPIDs_1759_Array functionReturn = new FR_ER_FCFSSfPIDs_1759_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_FS_Statuses_for_PatientIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_FCFSSfPIDs_1759_Array : FR_Base
	{
		public ER_FCFSSfPIDs_1759[] Result	{ get; set; } 
		public FR_ER_FCFSSfPIDs_1759_Array() : base() {}

		public FR_ER_FCFSSfPIDs_1759_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_FCFSSfPIDs_1759 for attribute P_ER_FCFSSfPIDs_1759
		[DataContract]
		public class P_ER_FCFSSfPIDs_1759 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass ER_FCFSSfPIDs_1759 for attribute ER_FCFSSfPIDs_1759
		[DataContract]
		public class ER_FCFSSfPIDs_1759 
		{
			//Standard type parameters
			[DataMember]
			public int case_fs_status_code { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public String case_type { get; set; } 
			[DataMember]
			public String gpos_type { get; set; } 
			[DataMember]
			public DateTime status_date { get; set; } 
			[DataMember]
			public Double price { get; set; } 
			[DataMember]
			public Guid hec_bill_position_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public String localization { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_FCFSSfPIDs_1759_Array cls_Get_Case_FS_Statuses_for_PatientIDs(,P_ER_FCFSSfPIDs_1759 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_FCFSSfPIDs_1759_Array invocationResult = cls_Get_Case_FS_Statuses_for_PatientIDs.Invoke(connectionString,P_ER_FCFSSfPIDs_1759 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_FCFSSfPIDs_1759();
parameter.PatientIDs = ...;

*/
