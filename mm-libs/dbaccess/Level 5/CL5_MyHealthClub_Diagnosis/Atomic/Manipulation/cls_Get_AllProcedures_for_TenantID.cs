/* 
 * Generated on 12/9/2014 1:43:35 PM
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

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllProcedures_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllProcedures_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DIGAPfTID_1318_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DIGAPfTID_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DIGAPfTID_1318_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.SQL.cls_Get_AllProcedures_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderBy", Parameter.OrderBy);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderValue", Parameter.OrderValue);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartIndex", Parameter.StartIndex);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfElements", Parameter.NumberOfElements);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriterium", Parameter.SearchCriterium);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CatalogID", Parameter.CatalogID);

            /***For Order**/
            string newText = command.CommandText.Replace("@OrderValue", Parameter.OrderValue);
            command.CommandText = newText;

            /***For Search**/
            string newText2 = command.CommandText.Replace("@SearchCriterium", Parameter.SearchCriterium);
            command.CommandText = newText2;

			List<L5DIGAPfTID_1318> results = new List<L5DIGAPfTID_1318>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_TRE_PotentialProcedureID","PotentialProcedure_Name_DictID","PotentialProcedure_Description_DictID","Code" });
				while(reader.Read())
				{
					L5DIGAPfTID_1318 resultItem = new L5DIGAPfTID_1318();
					//0:Parameter HEC_TRE_PotentialProcedureID of type Guid
					resultItem.HEC_TRE_PotentialProcedureID = reader.GetGuid(0);
					//1:Parameter PotentialProcedure_Name of type Dict
					resultItem.PotentialProcedure_Name = reader.GetDictionary(1);
					resultItem.PotentialProcedure_Name.SourceTable = "hec_tre_potentialprocedures";
					loader.Append(resultItem.PotentialProcedure_Name);
					//2:Parameter PotentialProcedure_Description of type Dict
					resultItem.PotentialProcedure_Description = reader.GetDictionary(2);
					resultItem.PotentialProcedure_Description.SourceTable = "hec_tre_potentialprocedures";
					loader.Append(resultItem.PotentialProcedure_Description);
					//3:Parameter Code of type String
					resultItem.Code = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllProcedures_for_TenantID",ex);
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
		public static FR_L5DIGAPfTID_1318_Array Invoke(string ConnectionString,P_L5DIGAPfTID_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DIGAPfTID_1318_Array Invoke(DbConnection Connection,P_L5DIGAPfTID_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DIGAPfTID_1318_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DIGAPfTID_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DIGAPfTID_1318_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DIGAPfTID_1318 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DIGAPfTID_1318_Array functionReturn = new FR_L5DIGAPfTID_1318_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllProcedures_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DIGAPfTID_1318_Array : FR_Base
	{
		public L5DIGAPfTID_1318[] Result	{ get; set; } 
		public FR_L5DIGAPfTID_1318_Array() : base() {}

		public FR_L5DIGAPfTID_1318_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DIGAPfTID_1318 for attribute P_L5DIGAPfTID_1318
		[DataContract]
		public class P_L5DIGAPfTID_1318 
		{
			//Standard type parameters
			[DataMember]
			public String OrderBy { get; set; } 
			[DataMember]
			public String OrderValue { get; set; } 
			[DataMember]
			public int StartIndex { get; set; } 
			[DataMember]
			public int NumberOfElements { get; set; } 
			[DataMember]
			public String SearchCriterium { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public Guid CatalogID { get; set; } 

		}
		#endregion
		#region SClass L5DIGAPfTID_1318 for attribute L5DIGAPfTID_1318
		[DataContract]
		public class L5DIGAPfTID_1318 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_TRE_PotentialProcedureID { get; set; } 
			[DataMember]
			public Dict PotentialProcedure_Name { get; set; } 
			[DataMember]
			public Dict PotentialProcedure_Description { get; set; } 
			[DataMember]
			public String Code { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DIGAPfTID_1318_Array cls_Get_AllProcedures_for_TenantID(,P_L5DIGAPfTID_1318 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DIGAPfTID_1318_Array invocationResult = cls_Get_AllProcedures_for_TenantID.Invoke(connectionString,P_L5DIGAPfTID_1318 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DIGAPfTID_1318();
parameter.OrderBy = ...;
parameter.OrderValue = ...;
parameter.StartIndex = ...;
parameter.NumberOfElements = ...;
parameter.SearchCriterium = ...;
parameter.LanguageID = ...;
parameter.CatalogID = ...;

*/
