/* 
 * Generated on 8/26/2013 2:07:47 PM
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

namespace CL5_VacationPlanner_WorkArea.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WorkArea_for_Shortname.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WorkArea_for_Shortname
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WA_GWAFSN_1319 Execute(DbConnection Connection,DbTransaction Transaction,P_L5WA_GWAFSN_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5WA_GWAFSN_1319();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_WorkArea.Atomic.Retrieval.SQL.cls_Get_WorkArea_for_Shortname.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShortName", Parameter.ShortName);


			List<L5WA_GWAFSN_1319> results = new List<L5WA_GWAFSN_1319>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_PPS_WorkAreaID","Parent_RefID","Office_RefID","WorkAreaName_DictID","WorkAreaDescription_DictID","Default_StartWorkingHour","ShortName","CMN_STR_PPS_WorkArea_TypeID","WorkAreaTypeName_DictID","WorkAreaTypeDescription_DictID","CMN_BPT_STA_SettingProfile_RefID","CMN_CAL_CalendarInstance_RefID" });
				while(reader.Read())
				{
					L5WA_GWAFSN_1319 resultItem = new L5WA_GWAFSN_1319();
					//0:Parameter CMN_STR_PPS_WorkAreaID of type Guid
					resultItem.CMN_STR_PPS_WorkAreaID = reader.GetGuid(0);
					//1:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(1);
					//2:Parameter Office_RefID of type Guid
					resultItem.Office_RefID = reader.GetGuid(2);
					//3:Parameter WorkAreaName of type Dict
					resultItem.WorkAreaName = reader.GetDictionary(3);
					resultItem.WorkAreaName.SourceTable = "cmn_str_pps_workareas";
					loader.Append(resultItem.WorkAreaName);
					//4:Parameter WorkAreaDescription of type Dict
					resultItem.WorkAreaDescription = reader.GetDictionary(4);
					resultItem.WorkAreaDescription.SourceTable = "cmn_str_pps_workareas";
					loader.Append(resultItem.WorkAreaDescription);
					//5:Parameter Default_StartWorkingHour of type String
					resultItem.Default_StartWorkingHour = reader.GetString(5);
					//6:Parameter ShortName of type String
					resultItem.ShortName = reader.GetString(6);
					//7:Parameter CMN_STR_PPS_WorkArea_TypeID of type Guid
					resultItem.CMN_STR_PPS_WorkArea_TypeID = reader.GetGuid(7);
					//8:Parameter WorkAreaTypeName of type Dict
					resultItem.WorkAreaTypeName = reader.GetDictionary(8);
					resultItem.WorkAreaTypeName.SourceTable = "cmn_str_pps_workarea_types";
					loader.Append(resultItem.WorkAreaTypeName);
					//9:Parameter WorkAreaTypeDescription of type Dict
					resultItem.WorkAreaTypeDescription = reader.GetDictionary(9);
					resultItem.WorkAreaTypeDescription.SourceTable = "cmn_str_pps_workarea_types";
					loader.Append(resultItem.WorkAreaTypeDescription);
					//10:Parameter CMN_BPT_STA_SettingProfile_RefID of type Guid
					resultItem.CMN_BPT_STA_SettingProfile_RefID = reader.GetGuid(10);
					//11:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
					resultItem.CMN_CAL_CalendarInstance_RefID = reader.GetGuid(11);

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

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WA_GWAFSN_1319 Invoke(string ConnectionString,P_L5WA_GWAFSN_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WA_GWAFSN_1319 Invoke(DbConnection Connection,P_L5WA_GWAFSN_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WA_GWAFSN_1319 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WA_GWAFSN_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WA_GWAFSN_1319 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WA_GWAFSN_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WA_GWAFSN_1319 functionReturn = new FR_L5WA_GWAFSN_1319();
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
	public class FR_L5WA_GWAFSN_1319 : FR_Base
	{
		public L5WA_GWAFSN_1319 Result	{ get; set; }

		public FR_L5WA_GWAFSN_1319() : base() {}

		public FR_L5WA_GWAFSN_1319(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WA_GWAFSN_1319 cls_Get_WorkArea_for_Shortname(P_L5WA_GWAFSN_1319 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5WA_GWAFSN_1319 result = cls_Get_WorkArea_for_Shortname.Invoke(connectionString,P_L5WA_GWAFSN_1319 Parameter,securityTicket);
	 return result;
}
*/