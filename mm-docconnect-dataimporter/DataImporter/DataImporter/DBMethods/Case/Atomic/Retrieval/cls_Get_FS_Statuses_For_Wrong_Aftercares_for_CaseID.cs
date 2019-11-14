/* 
 * Generated on 1/20/2017 2:33:27 PM
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

namespace DataImporter.DBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GFSSfWAfCID_1732_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GFSSfWAfCID_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GFSSfWAfCID_1732_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CaseID", Parameter.CaseID);



			List<CAS_GFSSfWAfCID_1732> results = new List<CAS_GFSSfWAfCID_1732>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsActive","StatusID","StatusCode","StatusComment","StatusDate","PositionNumber" });
				while(reader.Read())
				{
					CAS_GFSSfWAfCID_1732 resultItem = new CAS_GFSSfWAfCID_1732();
					//0:Parameter IsActive of type Boolean
					resultItem.IsActive = reader.GetBoolean(0);
					//1:Parameter StatusID of type Guid
					resultItem.StatusID = reader.GetGuid(1);
					//2:Parameter StatusCode of type int
					resultItem.StatusCode = reader.GetInteger(2);
					//3:Parameter StatusComment of type String
					resultItem.StatusComment = reader.GetString(3);
					//4:Parameter StatusDate of type DateTime
					resultItem.StatusDate = reader.GetDate(4);
					//5:Parameter PositionNumber of type String
					resultItem.PositionNumber = reader.GetString(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID",ex);
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
		public static FR_CAS_GFSSfWAfCID_1732_Array Invoke(string ConnectionString,P_CAS_GFSSfWAfCID_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GFSSfWAfCID_1732_Array Invoke(DbConnection Connection,P_CAS_GFSSfWAfCID_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GFSSfWAfCID_1732_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GFSSfWAfCID_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GFSSfWAfCID_1732_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GFSSfWAfCID_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GFSSfWAfCID_1732_Array functionReturn = new FR_CAS_GFSSfWAfCID_1732_Array();
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

				throw new Exception("Exception occured in method cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GFSSfWAfCID_1732_Array : FR_Base
	{
		public CAS_GFSSfWAfCID_1732[] Result	{ get; set; } 
		public FR_CAS_GFSSfWAfCID_1732_Array() : base() {}

		public FR_CAS_GFSSfWAfCID_1732_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GFSSfWAfCID_1732 for attribute P_CAS_GFSSfWAfCID_1732
		[DataContract]
		public class P_CAS_GFSSfWAfCID_1732 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GFSSfWAfCID_1732 for attribute CAS_GFSSfWAfCID_1732
		[DataContract]
		public class CAS_GFSSfWAfCID_1732 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsActive { get; set; } 
			[DataMember]
			public Guid StatusID { get; set; } 
			[DataMember]
			public int StatusCode { get; set; } 
			[DataMember]
			public String StatusComment { get; set; } 
			[DataMember]
			public DateTime StatusDate { get; set; } 
			[DataMember]
			public String PositionNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GFSSfWAfCID_1732_Array cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID(,P_CAS_GFSSfWAfCID_1732 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GFSSfWAfCID_1732_Array invocationResult = cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID.Invoke(connectionString,P_CAS_GFSSfWAfCID_1732 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Retrieval.P_CAS_GFSSfWAfCID_1732();
parameter.CaseID = ...;

*/