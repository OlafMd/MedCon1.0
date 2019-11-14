/* 
 * Generated on 2/19/2015 6:32:14 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_EMR.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Substances_for_ExaminationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EMR_GSfEID_1210_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EMR_GSfEID_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EMR_GSfEID_1210_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_Substances_for_ExaminationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);


			List<L5EMR_GSfEID_1210> results = new List<L5EMR_GSfEID_1210>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DosageText","IfSubstance_Strength","ISOCode","SubstanceName_Label_DictID","HEC_ACT_PerformedAction_MedicationUpdateID","IsMedicationDeactivated","IsSubstance","Creation_Timestamp","HEC_SUB_SubstanceID","IntendedApplicationDuration_in_days","CMN_UnitID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5EMR_GSfEID_1210 resultItem = new L5EMR_GSfEID_1210();
					//0:Parameter DosageText of type String
					resultItem.DosageText = reader.GetString(0);
					//1:Parameter IfSubstance_Strength of type String
					resultItem.IfSubstance_Strength = reader.GetString(1);
					//2:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(2);
					//3:Parameter SubstanceName_Label_DictID of type Dict
					resultItem.SubstanceName_Label_DictID = reader.GetDictionary(3);
					resultItem.SubstanceName_Label_DictID.SourceTable = "hec_sub_substance_names";
					loader.Append(resultItem.SubstanceName_Label_DictID);
					//4:Parameter HEC_ACT_PerformedAction_MedicationUpdateID of type Guid
					resultItem.HEC_ACT_PerformedAction_MedicationUpdateID = reader.GetGuid(4);
					//5:Parameter IsMedicationDeactivated of type Boolean
					resultItem.IsMedicationDeactivated = reader.GetBoolean(5);
					//6:Parameter IsSubstance of type Boolean
					resultItem.IsSubstance = reader.GetBoolean(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(8);
					//9:Parameter IntendedApplicationDuration_in_days of type int
					resultItem.IntendedApplicationDuration_in_days = reader.GetInteger(9);
					//10:Parameter CMN_UnitID of type Guid
					resultItem.CMN_UnitID = reader.GetGuid(10);
					//11:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(11);

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
		public static FR_L5EMR_GSfEID_1210_Array Invoke(string ConnectionString,P_L5EMR_GSfEID_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EMR_GSfEID_1210_Array Invoke(DbConnection Connection,P_L5EMR_GSfEID_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EMR_GSfEID_1210_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EMR_GSfEID_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EMR_GSfEID_1210_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EMR_GSfEID_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EMR_GSfEID_1210_Array functionReturn = new FR_L5EMR_GSfEID_1210_Array();
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
	public class FR_L5EMR_GSfEID_1210_Array : FR_Base
	{
		public L5EMR_GSfEID_1210[] Result	{ get; set; } 
		public FR_L5EMR_GSfEID_1210_Array() : base() {}

		public FR_L5EMR_GSfEID_1210_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EMR_GSfEID_1210 for attribute P_L5EMR_GSfEID_1210
		[Serializable]
		public class P_L5EMR_GSfEID_1210 
		{
			//Standard type parameters
			public Guid PerformedActionID; 

		}
		#endregion
		#region SClass L5EMR_GSfEID_1210 for attribute L5EMR_GSfEID_1210
		[Serializable]
		public class L5EMR_GSfEID_1210 
		{
			//Standard type parameters
			public String DosageText; 
			public String IfSubstance_Strength; 
			public String ISOCode; 
			public Dict SubstanceName_Label_DictID; 
			public Guid HEC_ACT_PerformedAction_MedicationUpdateID; 
			public Boolean IsMedicationDeactivated; 
			public Boolean IsSubstance; 
			public DateTime Creation_Timestamp; 
			public Guid HEC_SUB_SubstanceID; 
			public int IntendedApplicationDuration_in_days; 
			public Guid CMN_UnitID; 
			public String GlobalPropertyMatchingID; 

		}
		#endregion

	#endregion
}
