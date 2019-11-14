/* 
 * Generated on 8/26/2013 11:11:45 AM
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Absence.Atomic.Retrieval
{
	/// <summary>
    /// Get Absence reason 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_cls_Get_AbsenceReason_Name_ReasonIdList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_cls_Get_AbsenceReason_Name_ReasonIdList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GARN__1203_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GARN__1203 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_GARN__1203_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Absence.Atomic.Retrieval.SQL.cls_cls_Get_AbsenceReason_Name_ReasonIdList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ReasonIdList"," IN $$ReasonIdList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ReasonIdList$",Parameter.ReasonIdList);


			List<L5AR_GARN__1203> results = new List<L5AR_GARN__1203>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Name_DictID","ShortName","CMN_BPT_STA_AbsenceReasonID" });
				while(reader.Read())
				{
					L5AR_GARN__1203 resultItem = new L5AR_GARN__1203();
					//0:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(0);
					resultItem.Name.SourceTable = "cmn_bpt_sta_absencereasons";
					loader.Append(resultItem.Name);
					//1:Parameter ShortName of type String
					resultItem.ShortName = reader.GetString(1);
					//2:Parameter CMN_BPT_STA_AbsenceReasonID of type Guid
					resultItem.CMN_BPT_STA_AbsenceReasonID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L5AR_GARN__1203_Array Invoke(string ConnectionString,P_L5AR_GARN__1203 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GARN__1203_Array Invoke(DbConnection Connection,P_L5AR_GARN__1203 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GARN__1203_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GARN__1203 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GARN__1203_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GARN__1203 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GARN__1203_Array functionReturn = new FR_L5AR_GARN__1203_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GARN__1203_Array : FR_Base
	{
		public L5AR_GARN__1203[] Result	{ get; set; } 
		public FR_L5AR_GARN__1203_Array() : base() {}

		public FR_L5AR_GARN__1203_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GARN__1203_Array cls_cls_Get_AbsenceReason_Name_ReasonIdList(P_L5AR_GARN__1203 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5AR_GARN__1203_Array result = cls_cls_Get_AbsenceReason_Name_ReasonIdList.Invoke(connectionString,P_L5AR_GARN__1203 Parameter,securityTicket);
	 return result;
}
*/