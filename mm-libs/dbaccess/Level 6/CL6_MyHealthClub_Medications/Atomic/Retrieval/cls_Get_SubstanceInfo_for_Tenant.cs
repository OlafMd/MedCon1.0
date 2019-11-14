/* 
 * Generated on 10/14/2014 11:02:10 AM
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

namespace CL6_MyHealthClub_Medications.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SubstanceInfo_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SubstanceInfo_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6_GSIfT_1637_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6_GSIfT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6_GSIfT_1637_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MyHealthClub_Medications.Atomic.Retrieval.SQL.cls_Get_SubstanceInfo_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L6_GSIfT_1637> results = new List<L6_GSIfT_1637>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_SUB_SubstanceID","GlobalPropertyMatchingID","NarcoticAppendixStatus","CategoryByLawStatus","IsAntroposhopicalMedicine","IsChemical","IsDeleted","IsHomeophaticMedicine","IsCOSubstance","IsExcipient","IsFoodAdditive","IsNaturalStimulant","IsPerscriptionRequired","IsAgriculturePesticide","IsCosmeticSubstance","IsActiveComponent","Creation_Timestamp","Tenant_RefID","Substance_RefID","SubstanceText_DictID","SubstanceText_Status","Modification_TimestampSubstanceTexts","Modification_TimestampSubstances" });
				while(reader.Read())
				{
					L6_GSIfT_1637 resultItem = new L6_GSIfT_1637();
					//0:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(0);
					//1:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(1);
					//2:Parameter NarcoticAppendixStatus of type int
					resultItem.NarcoticAppendixStatus = reader.GetInteger(2);
					//3:Parameter CategoryByLawStatus of type int
					resultItem.CategoryByLawStatus = reader.GetInteger(3);
					//4:Parameter IsAntroposhopicalMedicine of type bool
					resultItem.IsAntroposhopicalMedicine = reader.GetBoolean(4);
					//5:Parameter IsChemical of type bool
					resultItem.IsChemical = reader.GetBoolean(5);
					//6:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(6);
					//7:Parameter IsHomeophaticMedicine of type bool
					resultItem.IsHomeophaticMedicine = reader.GetBoolean(7);
					//8:Parameter IsCOSubstance of type bool
					resultItem.IsCOSubstance = reader.GetBoolean(8);
					//9:Parameter IsExcipient of type bool
					resultItem.IsExcipient = reader.GetBoolean(9);
					//10:Parameter IsFoodAdditive of type bool
					resultItem.IsFoodAdditive = reader.GetBoolean(10);
					//11:Parameter IsNaturalStimulant of type bool
					resultItem.IsNaturalStimulant = reader.GetBoolean(11);
					//12:Parameter IsPerscriptionRequired of type bool
					resultItem.IsPerscriptionRequired = reader.GetBoolean(12);
					//13:Parameter IsAgriculturePesticide of type bool
					resultItem.IsAgriculturePesticide = reader.GetBoolean(13);
					//14:Parameter IsCosmeticSubstance of type bool
					resultItem.IsCosmeticSubstance = reader.GetBoolean(14);
					//15:Parameter IsActiveComponent of type bool
					resultItem.IsActiveComponent = reader.GetBoolean(15);
					//16:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(16);
					//17:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(17);
					//18:Parameter Substance_RefID of type Guid
					resultItem.Substance_RefID = reader.GetGuid(18);
					//19:Parameter SubstanceText of type Dict
					resultItem.SubstanceText = reader.GetDictionary(19);
					resultItem.SubstanceText.SourceTable = "hec_sub_substance_texts";
					loader.Append(resultItem.SubstanceText);
					//20:Parameter SubstanceText_Status of type String
					resultItem.SubstanceText_Status = reader.GetString(20);
					//21:Parameter Modification_TimestampSubstanceTexts of type DateTime
					resultItem.Modification_TimestampSubstanceTexts = reader.GetDate(21);
					//22:Parameter Modification_TimestampSubstances of type DateTime
					resultItem.Modification_TimestampSubstances = reader.GetDate(22);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_SubstanceInfo_for_Tenant",ex);
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
		public static FR_L6_GSIfT_1637_Array Invoke(string ConnectionString,P_L6_GSIfT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6_GSIfT_1637_Array Invoke(DbConnection Connection,P_L6_GSIfT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6_GSIfT_1637_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6_GSIfT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6_GSIfT_1637_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6_GSIfT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6_GSIfT_1637_Array functionReturn = new FR_L6_GSIfT_1637_Array();
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

				throw new Exception("Exception occured in method cls_Get_SubstanceInfo_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6_GSIfT_1637_Array : FR_Base
	{
		public L6_GSIfT_1637[] Result	{ get; set; } 
		public FR_L6_GSIfT_1637_Array() : base() {}

		public FR_L6_GSIfT_1637_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6_GSIfT_1637 for attribute P_L6_GSIfT_1637
		[DataContract]
		public class P_L6_GSIfT_1637 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L6_GSIfT_1637 for attribute L6_GSIfT_1637
		[DataContract]
		public class L6_GSIfT_1637 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_SUB_SubstanceID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public int NarcoticAppendixStatus { get; set; } 
			[DataMember]
			public int CategoryByLawStatus { get; set; } 
			[DataMember]
			public bool IsAntroposhopicalMedicine { get; set; } 
			[DataMember]
			public bool IsChemical { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsHomeophaticMedicine { get; set; } 
			[DataMember]
			public bool IsCOSubstance { get; set; } 
			[DataMember]
			public bool IsExcipient { get; set; } 
			[DataMember]
			public bool IsFoodAdditive { get; set; } 
			[DataMember]
			public bool IsNaturalStimulant { get; set; } 
			[DataMember]
			public bool IsPerscriptionRequired { get; set; } 
			[DataMember]
			public bool IsAgriculturePesticide { get; set; } 
			[DataMember]
			public bool IsCosmeticSubstance { get; set; } 
			[DataMember]
			public bool IsActiveComponent { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid Substance_RefID { get; set; } 
			[DataMember]
			public Dict SubstanceText { get; set; } 
			[DataMember]
			public String SubstanceText_Status { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampSubstanceTexts { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampSubstances { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6_GSIfT_1637_Array cls_Get_SubstanceInfo_for_Tenant(,P_L6_GSIfT_1637 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6_GSIfT_1637_Array invocationResult = cls_Get_SubstanceInfo_for_Tenant.Invoke(connectionString,P_L6_GSIfT_1637 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Medications.Atomic.Retrieval.P_L6_GSIfT_1637();
parameter.Tenant = ...;

*/
