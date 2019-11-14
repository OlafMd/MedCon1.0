/* 
 * Generated on 12/15/2014 11:10:21 AM
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
	public class cls_Get_CatalogData_for_DiagnoseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GCDfDID__1606_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GCDfDID__1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GCDfDID__1606_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_CatalogData_for_DiagnoseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnoseID", Parameter.DiagnoseID);


			List<L5DI_GCDfDID__1606> results = new List<L5DI_GCDfDID__1606>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Catalog_Name_DictID","HEC_DIA_PotentialDiagnosis_CatalogID" });
				while(reader.Read())
				{
					L5DI_GCDfDID__1606 resultItem = new L5DI_GCDfDID__1606();
					//0:Parameter Catalog_Name of type Dict
					resultItem.Catalog_Name = reader.GetDictionary(0);
					resultItem.Catalog_Name.SourceTable = "hec_dia_potentialdiagnosis_catalogs";
					loader.Append(resultItem.Catalog_Name);
					//1:Parameter HEC_DIA_PotentialDiagnosis_CatalogID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosis_CatalogID = reader.GetGuid(1);

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
		public static FR_L5DI_GCDfDID__1606_Array Invoke(string ConnectionString,P_L5DI_GCDfDID__1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GCDfDID__1606_Array Invoke(DbConnection Connection,P_L5DI_GCDfDID__1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GCDfDID__1606_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GCDfDID__1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GCDfDID__1606_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GCDfDID__1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GCDfDID__1606_Array functionReturn = new FR_L5DI_GCDfDID__1606_Array();
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
	public class FR_L5DI_GCDfDID__1606_Array : FR_Base
	{
		public L5DI_GCDfDID__1606[] Result	{ get; set; } 
		public FR_L5DI_GCDfDID__1606_Array() : base() {}

		public FR_L5DI_GCDfDID__1606_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GCDfDID__1606 for attribute P_L5DI_GCDfDID__1606
		[Serializable]
		public class P_L5DI_GCDfDID__1606 
		{
			//Standard type parameters
			public Guid DiagnoseID; 

		}
		#endregion
		#region SClass L5DI_GCDfDID__1606 for attribute L5DI_GCDfDID__1606
		[Serializable]
		public class L5DI_GCDfDID__1606 
		{
			//Standard type parameters
			public Dict Catalog_Name; 
			public Guid HEC_DIA_PotentialDiagnosis_CatalogID; 

		}
		#endregion

	#endregion
}
