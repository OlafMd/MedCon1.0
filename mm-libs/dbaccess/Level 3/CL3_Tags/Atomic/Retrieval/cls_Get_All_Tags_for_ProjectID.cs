/* 
 * Generated on 12/5/2014 10:16:29 AM
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

namespace CL3_Tags.Atomic.Retrieval
{
	/// <summary>
    /// Get_All_Tags_for_ProjectID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Tags_for_ProjectID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Tags_for_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3GT_GTFP_1359_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3TG_GTfPID_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3GT_GTFP_1359_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Tags.Atomic.Retrieval.SQL.cls_Get_All_Tags_for_ProjectID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Project_RefID", Parameter.Project_RefID);



			List<L3GT_GTFP_1359> results = new List<L3GT_GTFP_1359>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_TagID","TagValue" });
				while(reader.Read())
				{
					L3GT_GTFP_1359 resultItem = new L3GT_GTFP_1359();
					//0:Parameter TMS_PRO_TagID of type Guid
					resultItem.TMS_PRO_TagID = reader.GetGuid(0);
					//1:Parameter TagValue of type String
					resultItem.TagValue = reader.GetString(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Tags_for_ProjectID",ex);
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
		public static FR_L3GT_GTFP_1359_Array Invoke(string ConnectionString,P_L3TG_GTfPID_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3GT_GTFP_1359_Array Invoke(DbConnection Connection,P_L3TG_GTfPID_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3GT_GTFP_1359_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TG_GTfPID_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3GT_GTFP_1359_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TG_GTfPID_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3GT_GTFP_1359_Array functionReturn = new FR_L3GT_GTFP_1359_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Tags_for_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3GT_GTFP_1359_Array : FR_Base
	{
		public L3GT_GTFP_1359[] Result	{ get; set; } 
		public FR_L3GT_GTFP_1359_Array() : base() {}

		public FR_L3GT_GTFP_1359_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3TG_GTfPID_1553 for attribute P_L3TG_GTfPID_1553
		[DataContract]
		public class P_L3TG_GTfPID_1553 
		{
			//Standard type parameters
			[DataMember]
			public Guid Project_RefID { get; set; } 

		}
		#endregion
		#region SClass L3GT_GTFP_1359 for attribute L3GT_GTFP_1359
		[DataContract]
		public class L3GT_GTFP_1359 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_TagID { get; set; } 
			[DataMember]
			public String TagValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3GT_GTFP_1359_Array cls_Get_All_Tags_for_ProjectID(,P_L3TG_GTfPID_1553 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3GT_GTFP_1359_Array invocationResult = cls_Get_All_Tags_for_ProjectID.Invoke(connectionString,P_L3TG_GTfPID_1553 Parameter,securityTicket);
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
var parameter = new CL3_Tags.Atomic.Retrieval.P_L3TG_GTfPID_1553();
parameter.Project_RefID = ...;

*/
