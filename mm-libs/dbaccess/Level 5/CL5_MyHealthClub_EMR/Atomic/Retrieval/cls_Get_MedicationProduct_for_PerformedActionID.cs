/* 
 * Generated on 2/12/2015 3:21:09 PM
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
	public class cls_Get_MedicationProduct_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GMPfPAID_1133_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GMPfPAID_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GMPfPAID_1133_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_MedicationProduct_for_PerformedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);


			List<L5ME_GMPfPAID_1133_raw> results = new List<L5ME_GMPfPAID_1133_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ACT_PerformedAction_MedicationUpdateID","DosageText","MedicationUpdateComment","HEC_Patient_MedicationID","HEC_ProductID","Relevant_PatientDiagnosis_RefID","HEC_Product_DosageFormID","Product_Name_DictID","DosageForm_Name_DictID","IntendedApplicationDuration_in_days","IsMedicationDeactivated" });
				while(reader.Read())
				{
					L5ME_GMPfPAID_1133_raw resultItem = new L5ME_GMPfPAID_1133_raw();
					//0:Parameter HEC_ACT_PerformedAction_MedicationUpdateID of type Guid
					resultItem.HEC_ACT_PerformedAction_MedicationUpdateID = reader.GetGuid(0);
					//1:Parameter DosageText of type String
					resultItem.DosageText = reader.GetString(1);
					//2:Parameter MedicationUpdateComment of type String
					resultItem.MedicationUpdateComment = reader.GetString(2);
					//3:Parameter HEC_Patient_MedicationID of type Guid
					resultItem.HEC_Patient_MedicationID = reader.GetGuid(3);
					//4:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(4);
					//5:Parameter Relevant_PatientDiagnosis_RefID of type Guid
					resultItem.Relevant_PatientDiagnosis_RefID = reader.GetGuid(5);
					//6:Parameter HEC_Product_DosageFormID of type Guid
					resultItem.HEC_Product_DosageFormID = reader.GetGuid(6);
					//7:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(7);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//8:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(8);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//9:Parameter IntendedApplicationDuration_in_days of type int
					resultItem.IntendedApplicationDuration_in_days = reader.GetInteger(9);
					//10:Parameter IsMedicationDeactivated of type bool
					resultItem.IsMedicationDeactivated = reader.GetBoolean(10);

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

			returnStatus.Result = L5ME_GMPfPAID_1133_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GMPfPAID_1133_Array Invoke(string ConnectionString,P_L5ME_GMPfPAID_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GMPfPAID_1133_Array Invoke(DbConnection Connection,P_L5ME_GMPfPAID_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GMPfPAID_1133_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GMPfPAID_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GMPfPAID_1133_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GMPfPAID_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GMPfPAID_1133_Array functionReturn = new FR_L5ME_GMPfPAID_1133_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GMPfPAID_1133_raw 
	{
		public Guid HEC_ACT_PerformedAction_MedicationUpdateID; 
		public String DosageText; 
		public String MedicationUpdateComment; 
		public Guid HEC_Patient_MedicationID; 
		public Guid HEC_ProductID; 
		public Guid Relevant_PatientDiagnosis_RefID; 
		public Guid HEC_Product_DosageFormID; 
		public Dict Product_Name; 
		public Dict DosageForm_Name; 
		public int IntendedApplicationDuration_in_days; 
		public bool IsMedicationDeactivated; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GMPfPAID_1133[] Convert(List<L5ME_GMPfPAID_1133_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GMPfPAID_1133 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_ACT_PerformedAction_MedicationUpdateID)).ToArray()
	group el_L5ME_GMPfPAID_1133 by new 
	{ 
		el_L5ME_GMPfPAID_1133.HEC_ACT_PerformedAction_MedicationUpdateID,

	}
	into gfunct_L5ME_GMPfPAID_1133
	select new L5ME_GMPfPAID_1133
	{     
		HEC_ACT_PerformedAction_MedicationUpdateID = gfunct_L5ME_GMPfPAID_1133.Key.HEC_ACT_PerformedAction_MedicationUpdateID ,
		DosageText = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().DosageText ,
		MedicationUpdateComment = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().MedicationUpdateComment ,
		HEC_Patient_MedicationID = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().HEC_Patient_MedicationID ,
		HEC_ProductID = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().HEC_ProductID ,
		Relevant_PatientDiagnosis_RefID = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().Relevant_PatientDiagnosis_RefID ,
		HEC_Product_DosageFormID = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().HEC_Product_DosageFormID ,
		Product_Name = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().Product_Name ,
		DosageForm_Name = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().DosageForm_Name ,
		IntendedApplicationDuration_in_days = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().IntendedApplicationDuration_in_days ,
		IsMedicationDeactivated = gfunct_L5ME_GMPfPAID_1133.FirstOrDefault().IsMedicationDeactivated ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GMPfPAID_1133_Array : FR_Base
	{
		public L5ME_GMPfPAID_1133[] Result	{ get; set; } 
		public FR_L5ME_GMPfPAID_1133_Array() : base() {}

		public FR_L5ME_GMPfPAID_1133_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GMPfPAID_1133 for attribute P_L5ME_GMPfPAID_1133
		[Serializable]
		public class P_L5ME_GMPfPAID_1133 
		{
			//Standard type parameters
			public Guid PerformedActionID; 

		}
		#endregion
		#region SClass L5ME_GMPfPAID_1133 for attribute L5ME_GMPfPAID_1133
		[Serializable]
		public class L5ME_GMPfPAID_1133 
		{
			//Standard type parameters
			public Guid HEC_ACT_PerformedAction_MedicationUpdateID; 
			public String DosageText; 
			public String MedicationUpdateComment; 
			public Guid HEC_Patient_MedicationID; 
			public Guid HEC_ProductID; 
			public Guid Relevant_PatientDiagnosis_RefID; 
			public Guid HEC_Product_DosageFormID; 
			public Dict Product_Name; 
			public Dict DosageForm_Name; 
			public int IntendedApplicationDuration_in_days; 
			public bool IsMedicationDeactivated; 

		}
		#endregion

	#endregion
}
