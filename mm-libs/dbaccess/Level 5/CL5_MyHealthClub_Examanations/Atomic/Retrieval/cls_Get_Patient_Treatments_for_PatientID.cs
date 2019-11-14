/* 
 * Generated on 2/10/2015 10:33:59 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_Examanations.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Patient_Treatments_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GPTfPID_1728_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GPTfPID_1728 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EX_GPTfPID_1728_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Examanations.Atomic.Retrieval.SQL.cls_Get_Patient_Treatments_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);


			List<L5EX_GPTfPID_1728> results = new List<L5EX_GPTfPID_1728>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "id","treatment_date","url","doctor" });
				while(reader.Read())
				{
					L5EX_GPTfPID_1728 resultItem = new L5EX_GPTfPID_1728();
					//0:Parameter id of type Guid
					resultItem.id = reader.GetGuid(0);
					//1:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(1);
					//2:Parameter url of type Guid
					resultItem.url = reader.GetGuid(2);
					//3:Parameter doctor of type String
					resultItem.doctor = reader.GetString(3);

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
		public static FR_L5EX_GPTfPID_1728_Array Invoke(string ConnectionString,P_L5EX_GPTfPID_1728 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GPTfPID_1728_Array Invoke(DbConnection Connection,P_L5EX_GPTfPID_1728 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GPTfPID_1728_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GPTfPID_1728 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GPTfPID_1728_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GPTfPID_1728 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GPTfPID_1728_Array functionReturn = new FR_L5EX_GPTfPID_1728_Array();
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
	public class FR_L5EX_GPTfPID_1728_Array : FR_Base
	{
		public L5EX_GPTfPID_1728[] Result	{ get; set; } 
		public FR_L5EX_GPTfPID_1728_Array() : base() {}

		public FR_L5EX_GPTfPID_1728_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GPTfPID_1728 for attribute P_L5EX_GPTfPID_1728
		[Serializable]
		public class P_L5EX_GPTfPID_1728 
		{
			//Standard type parameters
			public Guid PatientID; 

		}
		#endregion
		#region SClass L5EX_GPTfPID_1728 for attribute L5EX_GPTfPID_1728
		[Serializable]
		public class L5EX_GPTfPID_1728 
		{
			//Standard type parameters
			public Guid id; 
			public DateTime treatment_date; 
			public Guid url; 
			public String doctor; 

		}
		#endregion

	#endregion
}
