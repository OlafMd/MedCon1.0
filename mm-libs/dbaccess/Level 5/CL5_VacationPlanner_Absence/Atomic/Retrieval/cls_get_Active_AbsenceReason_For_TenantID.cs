/* 
 * Generated on 05-Jun-14 16:27:29
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
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_Active_AbsenceReason_For_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Active_AbsenceReason_For_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GAARFT_1130_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_GAARFT_1130_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Absence.Atomic.Retrieval.SQL.cls_get_Active_AbsenceReason_For_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5AR_GAARFT_1130> results = new List<L5AR_GAARFT_1130>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_STA_AbsenceReasonID","ShortName","Name_DictID","Description_DictID","ColorCode","Parent_RefID","IsAuthorizationRequired","IsIncludedInCapacityCalculation","IsAllowedAbsence","IsCarryOverEnabled","IsDeactivated","IsLeaveTimeReducing_WorkingHours","IsLeaveTimeReducingOverTime" });
				while(reader.Read())
				{
					L5AR_GAARFT_1130 resultItem = new L5AR_GAARFT_1130();
					//0:Parameter CMN_BPT_STA_AbsenceReasonID of type Guid
					resultItem.CMN_BPT_STA_AbsenceReasonID = reader.GetGuid(0);
					//1:Parameter ShortName of type String
					resultItem.ShortName = reader.GetString(1);
					//2:Parameter ReasonName of type Dict
					resultItem.ReasonName = reader.GetDictionary(2);
					resultItem.ReasonName.SourceTable = "cmn_bpt_sta_absencereasons";
					loader.Append(resultItem.ReasonName);
					//3:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(3);
					resultItem.Description.SourceTable = "cmn_bpt_sta_absencereasons";
					loader.Append(resultItem.Description);
					//4:Parameter ColorCode of type String
					resultItem.ColorCode = reader.GetString(4);
					//5:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(5);
					//6:Parameter IsAuthorizationRequired of type bool
					resultItem.IsAuthorizationRequired = reader.GetBoolean(6);
					//7:Parameter IsIncludedInCapacityCalculation of type bool
					resultItem.IsIncludedInCapacityCalculation = reader.GetBoolean(7);
					//8:Parameter IsAllowedAbsence of type bool
					resultItem.IsAllowedAbsence = reader.GetBoolean(8);
					//9:Parameter IsCarryOverEnabled of type bool
					resultItem.IsCarryOverEnabled = reader.GetBoolean(9);
					//10:Parameter IsDeactivated of type bool
					resultItem.IsDeactivated = reader.GetBoolean(10);
					//11:Parameter IsLeaveTimeReducing_WorkingHours of type bool
					resultItem.IsLeaveTimeReducing_WorkingHours = reader.GetBoolean(11);
					//12:Parameter IsLeaveTimeReducingOverTime of type bool
					resultItem.IsLeaveTimeReducingOverTime = reader.GetBoolean(12);

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
		public static FR_L5AR_GAARFT_1130_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GAARFT_1130_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GAARFT_1130_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GAARFT_1130_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GAARFT_1130_Array functionReturn = new FR_L5AR_GAARFT_1130_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);


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
	public class FR_L5AR_GAARFT_1130_Array : FR_Base
	{
		public L5AR_GAARFT_1130[] Result	{ get; set; } 
		public FR_L5AR_GAARFT_1130_Array() : base() {}

		public FR_L5AR_GAARFT_1130_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}
