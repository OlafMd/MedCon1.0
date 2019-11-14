/* 
 * Generated on 06-Jan-14 15:37:45
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
using VacationPlaner;

namespace CL5_Plannico_ExtraWorkCalculation_Surcharges.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ExtraWorkCalculation_Surcharges_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ExtraWorkCalculation_Surcharges_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EW_GEWCSFT_1428_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EW_GEWCSFT_1428_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Plannico_ExtraWorkCalculation_Surcharges.Atomic.Retrieval.SQL.cls_Get_ExtraWorkCalculation_Surcharges_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5EW_GEWCSFT_1428> results = new List<L5EW_GEWCSFT_1428>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID","IsNightTimeSurcharge","IsSpecialEventSurcharge","Surcharge_Name_DictID","BoundTo_Office_RefID","BoundTo_WorkArea_RefID","BoundTo_Workplace_RefID" });
				while(reader.Read())
				{
					L5EW_GEWCSFT_1428 resultItem = new L5EW_GEWCSFT_1428();
					//0:Parameter CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID of type Guid
					resultItem.CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID = reader.GetGuid(0);
					//1:Parameter IsNightTimeSurcharge of type bool
					resultItem.IsNightTimeSurcharge = reader.GetBoolean(1);
					//2:Parameter IsSpecialEventSurcharge of type bool
					resultItem.IsSpecialEventSurcharge = reader.GetBoolean(2);
					//3:Parameter Surcharge_Name of type Dict
					resultItem.Surcharge_Name = reader.GetDictionary(3);
					resultItem.Surcharge_Name.SourceTable = "cmn_bpt_emp_extraworkcalculation_surcharges";
					loader.Append(resultItem.Surcharge_Name);
					//4:Parameter BoundTo_Office_RefID of type Guid
					resultItem.BoundTo_Office_RefID = reader.GetGuid(4);
					//5:Parameter BoundTo_WorkArea_RefID of type Guid
					resultItem.BoundTo_WorkArea_RefID = reader.GetGuid(5);
					//6:Parameter BoundTo_Workplace_RefID of type Guid
					resultItem.BoundTo_Workplace_RefID = reader.GetGuid(6);

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
		public static FR_L5EW_GEWCSFT_1428_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWCSFT_1428_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWCSFT_1428_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EW_GEWCSFT_1428_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EW_GEWCSFT_1428_Array functionReturn = new FR_L5EW_GEWCSFT_1428_Array();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EW_GEWCSFT_1428_Array : FR_Base
	{
		public L5EW_GEWCSFT_1428[] Result	{ get; set; } 
		public FR_L5EW_GEWCSFT_1428_Array() : base() {}

		public FR_L5EW_GEWCSFT_1428_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}
