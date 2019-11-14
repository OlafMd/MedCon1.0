/* 
 * Generated on 12/26/2014 2:17:06 PM
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
	public class cls_Get_PatientFindingData_for_FindingID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPFDfFID_1641 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPFDfFID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPFDfFID_1641();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Patient.Atomic.Retrieval.SQL.cls_Get_PatientFindingData_for_FindingID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FindingID", Parameter.FindingID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);


			List<L5PA_GPFDfFID_1641> results = new List<L5PA_GPFDfFID_1641>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "patient_name","doctor_name","Office_Name_DictID","MedicalPracticeType_Name_DictID","OrganizationalUnit_Name_DictID","CreationDate" });
				while(reader.Read())
				{
					L5PA_GPFDfFID_1641 resultItem = new L5PA_GPFDfFID_1641();
					//0:Parameter patient_name of type String
					resultItem.patient_name = reader.GetString(0);
					//1:Parameter doctor_name of type String
					resultItem.doctor_name = reader.GetString(1);
					//2:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(2);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//3:Parameter MedicalPracticeType_Name of type Dict
					resultItem.MedicalPracticeType_Name = reader.GetDictionary(3);
					resultItem.MedicalPracticeType_Name.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name);
					//4:Parameter OrganizationalUnit_Name of type Dict
					resultItem.OrganizationalUnit_Name = reader.GetDictionary(4);
					resultItem.OrganizationalUnit_Name.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Name);
					//5:Parameter CreationDate of type DateTime
					resultItem.CreationDate = reader.GetDate(5);

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
		public static FR_L5PA_GPFDfFID_1641 Invoke(string ConnectionString,P_L5PA_GPFDfFID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPFDfFID_1641 Invoke(DbConnection Connection,P_L5PA_GPFDfFID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPFDfFID_1641 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPFDfFID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPFDfFID_1641 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPFDfFID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPFDfFID_1641 functionReturn = new FR_L5PA_GPFDfFID_1641();
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
	public class FR_L5PA_GPFDfFID_1641 : FR_Base
	{
		public L5PA_GPFDfFID_1641 Result	{ get; set; }

		public FR_L5PA_GPFDfFID_1641() : base() {}

		public FR_L5PA_GPFDfFID_1641(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPFDfFID_1641 for attribute P_L5PA_GPFDfFID_1641
		[Serializable]
		public class P_L5PA_GPFDfFID_1641 
		{
			//Standard type parameters
			public Guid FindingID; 
			public Guid PatientID; 

		}
		#endregion
		#region SClass L5PA_GPFDfFID_1641 for attribute L5PA_GPFDfFID_1641
		[Serializable]
		public class L5PA_GPFDfFID_1641 
		{
			//Standard type parameters
			public String patient_name; 
			public String doctor_name; 
			public Dict Office_Name; 
			public Dict MedicalPracticeType_Name; 
			public Dict OrganizationalUnit_Name; 
			public DateTime CreationDate; 

		}
		#endregion

	#endregion
}
