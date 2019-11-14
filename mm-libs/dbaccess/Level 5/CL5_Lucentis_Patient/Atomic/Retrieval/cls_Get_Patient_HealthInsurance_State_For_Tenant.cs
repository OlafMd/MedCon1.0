/* 
 * Generated on 7/8/2013 11:30:47 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_Lucentis_Patient.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Patient_HealthInsurance_State_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPHISFT_0849_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPHISFT_0849_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Patient.Atomic.Retrieval.SQL.cls_Get_Patient_HealthInsurance_State_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5PA_GPHISFT_0849> results = new List<L5PA_GPHISFT_0849>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_HealthInsurance_StateID","HealthInsuranceState_Abbreviation","HealthInsuranceState_Name_DictID" });
				while(reader.Read())
				{
					L5PA_GPHISFT_0849 resultItem = new L5PA_GPHISFT_0849();
					//0:Parameter HEC_Patient_HealthInsurance_StateID of type Guid
					resultItem.HEC_Patient_HealthInsurance_StateID = reader.GetGuid(0);
					//1:Parameter HealthInsuranceState_Abbreviation of type String
					resultItem.HealthInsuranceState_Abbreviation = reader.GetString(1);
					//2:Parameter HealthInsuranceState_Name_DictID of type Dict
					resultItem.HealthInsuranceState_Name_DictID = reader.GetDictionary(2);
					resultItem.HealthInsuranceState_Name_DictID.SourceTable = "hec_patient_healthinsurance_states";
					loader.Append(resultItem.HealthInsuranceState_Name_DictID);

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
		public static FR_L5PA_GPHISFT_0849_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPHISFT_0849_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPHISFT_0849_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPHISFT_0849_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPHISFT_0849_Array functionReturn = new FR_L5PA_GPHISFT_0849_Array();
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
	public class FR_L5PA_GPHISFT_0849_Array : FR_Base
	{
		public L5PA_GPHISFT_0849[] Result	{ get; set; } 
		public FR_L5PA_GPHISFT_0849_Array() : base() {}

		public FR_L5PA_GPHISFT_0849_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PA_GPHISFT_0849 for attribute L5PA_GPHISFT_0849
		[Serializable]
		public class L5PA_GPHISFT_0849 
		{
			//Standard type parameters
			public Guid HEC_Patient_HealthInsurance_StateID; 
			public String HealthInsuranceState_Abbreviation; 
			public Dict HealthInsuranceState_Name_DictID; 

		}
		#endregion

	#endregion
}
