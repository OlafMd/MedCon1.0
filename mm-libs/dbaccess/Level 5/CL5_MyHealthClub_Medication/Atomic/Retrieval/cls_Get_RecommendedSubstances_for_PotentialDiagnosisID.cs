/* 
 * Generated on 10/22/2014 1:03:42 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_MyHealthClub_Medication.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RecommendedSubstances_for_PotentialDiagnosisID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RecommendedSubstances_for_PotentialDiagnosisID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GRSfPDID_1506_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GRSfPDID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GRSfPDID_1506_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Medication.Atomic.Retrieval.SQL.cls_Get_RecommendedSubstances_for_PotentialDiagnosisID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PotentialDiagnosisID", Parameter.PotentialDiagnosisID);



			List<L5ME_GRSfPDID_1506_raw> results = new List<L5ME_GRSfPDID_1506_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "SubstanceName_Label_DictID","Substance_RefID","SubstanceStrength","Substance_Unit_RefID","SubstanceUnitName","HEC_DIA_RecommendedSubstanceID","HEC_DIA_RecommendedSubstance_DosageID","IsDefault","HEC_DosageID","DosageText" });
				while(reader.Read())
				{
					L5ME_GRSfPDID_1506_raw resultItem = new L5ME_GRSfPDID_1506_raw();
					//0:Parameter SubstanceName_Label of type Dict
					resultItem.SubstanceName_Label = reader.GetDictionary(0);
					resultItem.SubstanceName_Label.SourceTable = "hec_sub_substance_names";
					loader.Append(resultItem.SubstanceName_Label);
					//1:Parameter Substance_RefID of type Guid
					resultItem.Substance_RefID = reader.GetGuid(1);
					//2:Parameter SubstanceStrength of type String
					resultItem.SubstanceStrength = reader.GetString(2);
					//3:Parameter Substance_Unit_RefID of type Guid
					resultItem.Substance_Unit_RefID = reader.GetGuid(3);
					//4:Parameter SubstanceUnitName of type String
					resultItem.SubstanceUnitName = reader.GetString(4);
					//5:Parameter HEC_DIA_RecommendedSubstanceID of type Guid
					resultItem.HEC_DIA_RecommendedSubstanceID = reader.GetGuid(5);
					//6:Parameter HEC_DIA_RecommendedSubstance_DosageID of type Guid
					resultItem.HEC_DIA_RecommendedSubstance_DosageID = reader.GetGuid(6);
					//7:Parameter IsDefault of type bool
					resultItem.IsDefault = reader.GetBoolean(7);
					//8:Parameter HEC_DosageID of type Guid
					resultItem.HEC_DosageID = reader.GetGuid(8);
					//9:Parameter DosageText of type String
					resultItem.DosageText = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RecommendedSubstances_for_PotentialDiagnosisID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GRSfPDID_1506_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GRSfPDID_1506_Array Invoke(string ConnectionString,P_L5ME_GRSfPDID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GRSfPDID_1506_Array Invoke(DbConnection Connection,P_L5ME_GRSfPDID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GRSfPDID_1506_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GRSfPDID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GRSfPDID_1506_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GRSfPDID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GRSfPDID_1506_Array functionReturn = new FR_L5ME_GRSfPDID_1506_Array();
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

				throw new Exception("Exception occured in method cls_Get_RecommendedSubstances_for_PotentialDiagnosisID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GRSfPDID_1506_raw 
	{
		public Dict SubstanceName_Label; 
		public Guid Substance_RefID; 
		public String SubstanceStrength; 
		public Guid Substance_Unit_RefID; 
		public String SubstanceUnitName; 
		public Guid HEC_DIA_RecommendedSubstanceID; 
		public Guid HEC_DIA_RecommendedSubstance_DosageID; 
		public bool IsDefault; 
		public Guid HEC_DosageID; 
		public String DosageText; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GRSfPDID_1506[] Convert(List<L5ME_GRSfPDID_1506_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GRSfPDID_1506 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.Substance_RefID)).ToArray()
	group el_L5ME_GRSfPDID_1506 by new 
	{ 
		el_L5ME_GRSfPDID_1506.Substance_RefID,

	}
	into gfunct_L5ME_GRSfPDID_1506
	select new L5ME_GRSfPDID_1506
	{     
		SubstanceName_Label = gfunct_L5ME_GRSfPDID_1506.FirstOrDefault().SubstanceName_Label ,
		Substance_RefID = gfunct_L5ME_GRSfPDID_1506.Key.Substance_RefID ,
		SubstanceStrength = gfunct_L5ME_GRSfPDID_1506.FirstOrDefault().SubstanceStrength ,
		Substance_Unit_RefID = gfunct_L5ME_GRSfPDID_1506.FirstOrDefault().Substance_Unit_RefID ,
		SubstanceUnitName = gfunct_L5ME_GRSfPDID_1506.FirstOrDefault().SubstanceUnitName ,
		HEC_DIA_RecommendedSubstanceID = gfunct_L5ME_GRSfPDID_1506.FirstOrDefault().HEC_DIA_RecommendedSubstanceID ,

		Dosage = 
		(
			from el_Dosage in gfunct_L5ME_GRSfPDID_1506.Where(element => !EqualsDefaultValue(element.HEC_DIA_RecommendedSubstance_DosageID)).ToArray()
			group el_Dosage by new 
			{ 
				el_Dosage.HEC_DIA_RecommendedSubstance_DosageID,

			}
			into gfunct_Dosage
			select new L5ME_GRSfPDID_1506_Dosage
			{     
				HEC_DIA_RecommendedSubstance_DosageID = gfunct_Dosage.Key.HEC_DIA_RecommendedSubstance_DosageID ,
				IsDefault = gfunct_Dosage.FirstOrDefault().IsDefault ,
				HEC_DosageID = gfunct_Dosage.FirstOrDefault().HEC_DosageID ,
				DosageText = gfunct_Dosage.FirstOrDefault().DosageText ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GRSfPDID_1506_Array : FR_Base
	{
		public L5ME_GRSfPDID_1506[] Result	{ get; set; } 
		public FR_L5ME_GRSfPDID_1506_Array() : base() {}

		public FR_L5ME_GRSfPDID_1506_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GRSfPDID_1506 for attribute P_L5ME_GRSfPDID_1506
		[DataContract]
		public class P_L5ME_GRSfPDID_1506 
		{
			//Standard type parameters
			[DataMember]
			public Guid PotentialDiagnosisID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GRSfPDID_1506 for attribute L5ME_GRSfPDID_1506
		[DataContract]
		public class L5ME_GRSfPDID_1506 
		{
			[DataMember]
			public L5ME_GRSfPDID_1506_Dosage[] Dosage { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict SubstanceName_Label { get; set; } 
			[DataMember]
			public Guid Substance_RefID { get; set; } 
			[DataMember]
			public String SubstanceStrength { get; set; } 
			[DataMember]
			public Guid Substance_Unit_RefID { get; set; } 
			[DataMember]
			public String SubstanceUnitName { get; set; } 
			[DataMember]
			public Guid HEC_DIA_RecommendedSubstanceID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GRSfPDID_1506_Dosage for attribute Dosage
		[DataContract]
		public class L5ME_GRSfPDID_1506_Dosage 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_RecommendedSubstance_DosageID { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public Guid HEC_DosageID { get; set; } 
			[DataMember]
			public String DosageText { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GRSfPDID_1506_Array cls_Get_RecommendedSubstances_for_PotentialDiagnosisID(,P_L5ME_GRSfPDID_1506 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GRSfPDID_1506_Array invocationResult = cls_Get_RecommendedSubstances_for_PotentialDiagnosisID.Invoke(connectionString,P_L5ME_GRSfPDID_1506 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL5_MyHealthClub_Medication.Atomic.Retrieval.P_L5ME_GRSfPDID_1506();
parameter.PotentialDiagnosisID = ...;

*/
