/* 
 * Generated on 1/26/2015 1:47:44 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_Patient.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Patient_Documents_BaseData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPDBD_1039_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPDBD_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPDBD_1039_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Patient.Atomic.Retrieval.SQL.cls_Get_Patient_Documents_BaseData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);


			List<L5PA_GPDBD_1039> results = new List<L5PA_GPDBD_1039>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "finding_id","referal_id","modification_time","creation_date" });
				while(reader.Read())
				{
					L5PA_GPDBD_1039 resultItem = new L5PA_GPDBD_1039();
					//0:Parameter finding_id of type Guid
					resultItem.finding_id = reader.GetGuid(0);
					//1:Parameter referal_id of type Guid
					resultItem.referal_id = reader.GetGuid(1);
					//2:Parameter modification_time of type DateTime
					resultItem.modification_time = reader.GetDate(2);
					//3:Parameter creation_date of type DateTime
					resultItem.creation_date = reader.GetDate(3);

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
		public static FR_L5PA_GPDBD_1039_Array Invoke(string ConnectionString,P_L5PA_GPDBD_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPDBD_1039_Array Invoke(DbConnection Connection,P_L5PA_GPDBD_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPDBD_1039_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPDBD_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPDBD_1039_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPDBD_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPDBD_1039_Array functionReturn = new FR_L5PA_GPDBD_1039_Array();
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
	public class FR_L5PA_GPDBD_1039_Array : FR_Base
	{
		public L5PA_GPDBD_1039[] Result	{ get; set; } 
		public FR_L5PA_GPDBD_1039_Array() : base() {}

		public FR_L5PA_GPDBD_1039_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPDBD_1039 for attribute P_L5PA_GPDBD_1039
		[Serializable]
		public class P_L5PA_GPDBD_1039 
		{
			//Standard type parameters
			public Guid PatientID; 

		}
		#endregion
		#region SClass L5PA_GPDBD_1039 for attribute L5PA_GPDBD_1039
		[Serializable]
		public class L5PA_GPDBD_1039 
		{
			//Standard type parameters
			public Guid finding_id; 
			public Guid referal_id; 
			public DateTime modification_time; 
			public DateTime creation_date; 

		}
		#endregion

	#endregion
}
