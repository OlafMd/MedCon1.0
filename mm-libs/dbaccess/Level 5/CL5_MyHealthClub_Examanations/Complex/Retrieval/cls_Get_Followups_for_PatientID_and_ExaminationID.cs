/* 
 * Generated on 2/19/2015 2:50:27 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_Examanations.Complex.Retrieval
{
	[Serializable]
	public class cls_Get_Followups_for_PatientID_and_ExaminationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GFPIDEID_1805_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GFPIDEID_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EX_GFPIDEID_1805_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Examanations.Complex.Retrieval.SQL.cls_Get_Followups_for_PatientID_and_ExaminationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ExaminationID", Parameter.ExaminationID);


			List<L5EX_GFPIDEID_1805> results = new List<L5EX_GFPIDEID_1805>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ACT_PlannedActionID","date","FollowupReason" });
				while(reader.Read())
				{
					L5EX_GFPIDEID_1805 resultItem = new L5EX_GFPIDEID_1805();
					//0:Parameter HEC_ACT_PlannedActionID of type Guid
					resultItem.HEC_ACT_PlannedActionID = reader.GetGuid(0);
					//1:Parameter date of type DateTime
					resultItem.date = reader.GetDate(1);
					//2:Parameter FollowupReason of type String
					resultItem.FollowupReason = reader.GetString(2);

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
		public static FR_L5EX_GFPIDEID_1805_Array Invoke(string ConnectionString,P_L5EX_GFPIDEID_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GFPIDEID_1805_Array Invoke(DbConnection Connection,P_L5EX_GFPIDEID_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GFPIDEID_1805_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GFPIDEID_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GFPIDEID_1805_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GFPIDEID_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GFPIDEID_1805_Array functionReturn = new FR_L5EX_GFPIDEID_1805_Array();
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
	public class FR_L5EX_GFPIDEID_1805_Array : FR_Base
	{
		public L5EX_GFPIDEID_1805[] Result	{ get; set; } 
		public FR_L5EX_GFPIDEID_1805_Array() : base() {}

		public FR_L5EX_GFPIDEID_1805_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GFPIDEID_1805 for attribute P_L5EX_GFPIDEID_1805
		[Serializable]
		public class P_L5EX_GFPIDEID_1805 
		{
			//Standard type parameters
			public Guid PatientID; 
			public Guid ExaminationID; 

		}
		#endregion
		#region SClass L5EX_GFPIDEID_1805 for attribute L5EX_GFPIDEID_1805
		[Serializable]
		public class L5EX_GFPIDEID_1805 
		{
			//Standard type parameters
			public Guid HEC_ACT_PlannedActionID; 
			public DateTime date; 
			public String FollowupReason; 

		}
		#endregion

	#endregion
}
