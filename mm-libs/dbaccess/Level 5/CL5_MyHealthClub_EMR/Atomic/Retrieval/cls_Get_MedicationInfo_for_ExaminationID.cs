/* 
 * Generated on 2/13/2015 12:39:06
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

namespace CL5_MyHealthClub_EMR.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MedicationInfo_for_ExaminationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MedicationInfo_for_ExaminationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GMIfEID_1534_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GMIfEID_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GMIfEID_1534_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_MedicationInfo_for_ExaminationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);



			List<L5ME_GMIfEID_1534> results = new List<L5ME_GMIfEID_1534>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","HEC_ProductID","DosageForm_Name_DictID","Manufacturer","Strength_Name","Strength_Units","PackageContent_DisplayLabel","SubstanceName_Label_DictID","HEC_SUB_SubstanceID","HEC_ACT_PerformedAction_MedicationUpdateID","IsSubstance","IfSubstance_Strength","DosageText","IntendedApplicationDuration_in_days","Creation_Timestamp","IfSubstance_Unit_RefID","IsMedicationDeactivated" });
				while(reader.Read())
				{
					L5ME_GMIfEID_1534 resultItem = new L5ME_GMIfEID_1534();
					//0:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(0);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//1:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(1);
					//2:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(2);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//3:Parameter Manufacturer of type String
					resultItem.Manufacturer = reader.GetString(3);
					//4:Parameter Strength_Name of type String
					resultItem.Strength_Name = reader.GetString(4);
					//5:Parameter Strength_Units of type String
					resultItem.Strength_Units = reader.GetString(5);
					//6:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(6);
					//7:Parameter SubstanceName_Label of type Dict
					resultItem.SubstanceName_Label = reader.GetDictionary(7);
					resultItem.SubstanceName_Label.SourceTable = "hec_sub_substance_names";
					loader.Append(resultItem.SubstanceName_Label);
					//8:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(8);
					//9:Parameter HEC_ACT_PerformedAction_MedicationUpdateID of type Guid
					resultItem.HEC_ACT_PerformedAction_MedicationUpdateID = reader.GetGuid(9);
					//10:Parameter IsSubstance of type Boolean
					resultItem.IsSubstance = reader.GetBoolean(10);
					//11:Parameter IfSubstance_Strength of type String
					resultItem.IfSubstance_Strength = reader.GetString(11);
					//12:Parameter DosageText of type String
					resultItem.DosageText = reader.GetString(12);
					//13:Parameter IntendedApplicationDuration_in_days of type int
					resultItem.IntendedApplicationDuration_in_days = reader.GetInteger(13);
					//14:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(14);
					//15:Parameter IfSubstance_Unit_RefID of type Guid
					resultItem.IfSubstance_Unit_RefID = reader.GetGuid(15);
					//16:Parameter IsMedicationDeactivated of type Boolean
					resultItem.IsMedicationDeactivated = reader.GetBoolean(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_MedicationInfo_for_ExaminationID",ex);
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
		public static FR_L5ME_GMIfEID_1534_Array Invoke(string ConnectionString,P_L5ME_GMIfEID_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GMIfEID_1534_Array Invoke(DbConnection Connection,P_L5ME_GMIfEID_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GMIfEID_1534_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GMIfEID_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GMIfEID_1534_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GMIfEID_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GMIfEID_1534_Array functionReturn = new FR_L5ME_GMIfEID_1534_Array();
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

				throw new Exception("Exception occured in method cls_Get_MedicationInfo_for_ExaminationID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GMIfEID_1534_Array : FR_Base
	{
		public L5ME_GMIfEID_1534[] Result	{ get; set; } 
		public FR_L5ME_GMIfEID_1534_Array() : base() {}

		public FR_L5ME_GMIfEID_1534_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GMIfEID_1534 for attribute P_L5ME_GMIfEID_1534
		[DataContract]
		public class P_L5ME_GMIfEID_1534 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GMIfEID_1534 for attribute L5ME_GMIfEID_1534
		[DataContract]
		public class L5ME_GMIfEID_1534 
		{
			//Standard type parameters
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public String Manufacturer { get; set; } 
			[DataMember]
			public String Strength_Name { get; set; } 
			[DataMember]
			public String Strength_Units { get; set; } 
			[DataMember]
			public String PackageContent_DisplayLabel { get; set; } 
			[DataMember]
			public Dict SubstanceName_Label { get; set; } 
			[DataMember]
			public Guid HEC_SUB_SubstanceID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PerformedAction_MedicationUpdateID { get; set; } 
			[DataMember]
			public Boolean IsSubstance { get; set; } 
			[DataMember]
			public String IfSubstance_Strength { get; set; } 
			[DataMember]
			public String DosageText { get; set; } 
			[DataMember]
			public int IntendedApplicationDuration_in_days { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid IfSubstance_Unit_RefID { get; set; } 
			[DataMember]
			public Boolean IsMedicationDeactivated { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GMIfEID_1534_Array cls_Get_MedicationInfo_for_ExaminationID(,P_L5ME_GMIfEID_1534 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GMIfEID_1534_Array invocationResult = cls_Get_MedicationInfo_for_ExaminationID.Invoke(connectionString,P_L5ME_GMIfEID_1534 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Retrieval.P_L5ME_GMIfEID_1534();
parameter.PerformedActionID = ...;

*/
