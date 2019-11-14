/* 
 * Generated on 2/13/2015 3:36:38 PM
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
	public class cls_Get_Treatment_Substances
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GTS_1523_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GTS_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EX_GTS_1523_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Examanations.Atomic.Retrieval.SQL.cls_Get_Treatment_Substances.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);


			List<L5EX_GTS_1523> results = new List<L5EX_GTS_1523>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ACT_PerformedAction_MedicationUpdateID","HEC_Patient_MedicationID","DosageText","MedicationUpdateComment","ISOCode","HEC_SUB_SubstanceID","IsActiveComponent","IfSubstance_Strength","Relevant_PatientDiagnosis_RefID","IntendedApplicationDuration_in_days","GlobalPropertyMatchingID","IsMedicationDeactivated" });
				while(reader.Read())
				{
					L5EX_GTS_1523 resultItem = new L5EX_GTS_1523();
					//0:Parameter HEC_ACT_PerformedAction_MedicationUpdateID of type Guid
					resultItem.HEC_ACT_PerformedAction_MedicationUpdateID = reader.GetGuid(0);
					//1:Parameter HEC_Patient_MedicationID of type Guid
					resultItem.HEC_Patient_MedicationID = reader.GetGuid(1);
					//2:Parameter DosageText of type String
					resultItem.DosageText = reader.GetString(2);
					//3:Parameter MedicationUpdateComment of type String
					resultItem.MedicationUpdateComment = reader.GetString(3);
					//4:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(4);
					//5:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(5);
					//6:Parameter IsActiveComponent of type bool
					resultItem.IsActiveComponent = reader.GetBoolean(6);
					//7:Parameter IfSubstance_Strength of type String
					resultItem.IfSubstance_Strength = reader.GetString(7);
					//8:Parameter Relevant_PatientDiagnosis_RefID of type Guid
					resultItem.Relevant_PatientDiagnosis_RefID = reader.GetGuid(8);
					//9:Parameter IntendedApplicationDuration_in_days of type String
					resultItem.IntendedApplicationDuration_in_days = reader.GetString(9);
					//10:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(10);
					//11:Parameter IsMedicationDeactivated of type bool
					resultItem.IsMedicationDeactivated = reader.GetBoolean(11);

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
		public static FR_L5EX_GTS_1523_Array Invoke(string ConnectionString,P_L5EX_GTS_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GTS_1523_Array Invoke(DbConnection Connection,P_L5EX_GTS_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GTS_1523_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GTS_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GTS_1523_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GTS_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GTS_1523_Array functionReturn = new FR_L5EX_GTS_1523_Array();
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
	public class FR_L5EX_GTS_1523_Array : FR_Base
	{
		public L5EX_GTS_1523[] Result	{ get; set; } 
		public FR_L5EX_GTS_1523_Array() : base() {}

		public FR_L5EX_GTS_1523_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GTS_1523 for attribute P_L5EX_GTS_1523
		[Serializable]
		public class P_L5EX_GTS_1523 
		{
			//Standard type parameters
			public Guid PerformedActionID; 

		}
		#endregion
		#region SClass L5EX_GTS_1523 for attribute L5EX_GTS_1523
		[Serializable]
		public class L5EX_GTS_1523 
		{
			//Standard type parameters
			public Guid HEC_ACT_PerformedAction_MedicationUpdateID; 
			public Guid HEC_Patient_MedicationID; 
			public String DosageText; 
			public String MedicationUpdateComment; 
			public String ISOCode; 
			public Guid HEC_SUB_SubstanceID; 
			public bool IsActiveComponent; 
			public String IfSubstance_Strength; 
			public Guid Relevant_PatientDiagnosis_RefID; 
			public String IntendedApplicationDuration_in_days; 
			public String GlobalPropertyMatchingID; 
			public bool IsMedicationDeactivated; 

		}
		#endregion

	#endregion
}
