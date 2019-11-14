/* 
 * Generated on 2/15/2015 5:31:52 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Diagnosis_for_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GDfDI_1726 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GDfDI_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GDfDI_1726();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_Diagnosis_for_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnoseID", Parameter.DiagnoseID);


			List<L5DI_GDfDI_1726> results = new List<L5DI_GDfDI_1726>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ICD10_Code","PotentialDiagnosis_Name_DictID","PotentialDiagnosis_Description_DictID" });
				while(reader.Read())
				{
					L5DI_GDfDI_1726 resultItem = new L5DI_GDfDI_1726();
					//0:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(0);
					//1:Parameter PotentialDiagnosis_Name of type Dict
					resultItem.PotentialDiagnosis_Name = reader.GetDictionary(1);
					resultItem.PotentialDiagnosis_Name.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name);
					//2:Parameter PotentialDiagnosis_Description of type Dict
					resultItem.PotentialDiagnosis_Description = reader.GetDictionary(2);
					resultItem.PotentialDiagnosis_Description.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Description);

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
		public static FR_L5DI_GDfDI_1726 Invoke(string ConnectionString,P_L5DI_GDfDI_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GDfDI_1726 Invoke(DbConnection Connection,P_L5DI_GDfDI_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GDfDI_1726 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GDfDI_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GDfDI_1726 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GDfDI_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GDfDI_1726 functionReturn = new FR_L5DI_GDfDI_1726();
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
	public class FR_L5DI_GDfDI_1726 : FR_Base
	{
		public L5DI_GDfDI_1726 Result	{ get; set; }

		public FR_L5DI_GDfDI_1726() : base() {}

		public FR_L5DI_GDfDI_1726(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GDfDI_1726 for attribute P_L5DI_GDfDI_1726
		[Serializable]
		public class P_L5DI_GDfDI_1726 
		{
			//Standard type parameters
			public Guid DiagnoseID; 

		}
		#endregion
		#region SClass L5DI_GDfDI_1726 for attribute L5DI_GDfDI_1726
		[Serializable]
		public class L5DI_GDfDI_1726 
		{
			//Standard type parameters
			public String ICD10_Code; 
			public Dict PotentialDiagnosis_Name; 
			public Dict PotentialDiagnosis_Description; 

		}
		#endregion

	#endregion
}
