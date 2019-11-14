/* 
 * Generated on 11/12/2014 5:12:42 PM
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

namespace CL5_MyHealthClub_Diagnosis.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DiagnosesCatalog_for_CatalogID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiagnosesCatalog_for_CatalogID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GDCfCID_1555 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GDCfCID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GDCfCID_1555();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_DiagnosesCatalog_for_CatalogID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CatalogID", Parameter.CatalogID);



			List<L5DI_GDCfCID_1555_raw> results = new List<L5DI_GDCfCID_1555_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Catalog_Name_DictID","IsPrivateCatalog","HEC_DIA_PotentialDiagnosis_CatalogID","HEC_DIA_PotentialDiagnosis_Catalog_AccessID","BusinessParticipant_RefID","IsContributor" });
				while(reader.Read())
				{
					L5DI_GDCfCID_1555_raw resultItem = new L5DI_GDCfCID_1555_raw();
					//0:Parameter Catalog_Name of type Dict
					resultItem.Catalog_Name = reader.GetDictionary(0);
					resultItem.Catalog_Name.SourceTable = "hec_dia_potentialdiagnosis_catalogs";
					loader.Append(resultItem.Catalog_Name);
					//1:Parameter IsPrivateCatalog of type bool
					resultItem.IsPrivateCatalog = reader.GetBoolean(1);
					//2:Parameter HEC_DIA_PotentialDiagnosis_CatalogID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosis_CatalogID = reader.GetGuid(2);
					//3:Parameter HEC_DIA_PotentialDiagnosis_Catalog_AccessID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosis_Catalog_AccessID = reader.GetGuid(3);
					//4:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(4);
					//5:Parameter IsContributor of type bool
					resultItem.IsContributor = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DiagnosesCatalog_for_CatalogID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DI_GDCfCID_1555_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DI_GDCfCID_1555 Invoke(string ConnectionString,P_L5DI_GDCfCID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GDCfCID_1555 Invoke(DbConnection Connection,P_L5DI_GDCfCID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GDCfCID_1555 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GDCfCID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GDCfCID_1555 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GDCfCID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GDCfCID_1555 functionReturn = new FR_L5DI_GDCfCID_1555();
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

				throw new Exception("Exception occured in method cls_Get_DiagnosesCatalog_for_CatalogID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DI_GDCfCID_1555_raw 
	{
		public Dict Catalog_Name; 
		public bool IsPrivateCatalog; 
		public Guid HEC_DIA_PotentialDiagnosis_CatalogID; 
		public Guid HEC_DIA_PotentialDiagnosis_Catalog_AccessID; 
		public Guid BusinessParticipant_RefID; 
		public bool IsContributor; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DI_GDCfCID_1555[] Convert(List<L5DI_GDCfCID_1555_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DI_GDCfCID_1555 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DIA_PotentialDiagnosis_CatalogID)).ToArray()
	group el_L5DI_GDCfCID_1555 by new 
	{ 
		el_L5DI_GDCfCID_1555.HEC_DIA_PotentialDiagnosis_CatalogID,

	}
	into gfunct_L5DI_GDCfCID_1555
	select new L5DI_GDCfCID_1555
	{     
		Catalog_Name = gfunct_L5DI_GDCfCID_1555.FirstOrDefault().Catalog_Name ,
		IsPrivateCatalog = gfunct_L5DI_GDCfCID_1555.FirstOrDefault().IsPrivateCatalog ,
		HEC_DIA_PotentialDiagnosis_CatalogID = gfunct_L5DI_GDCfCID_1555.Key.HEC_DIA_PotentialDiagnosis_CatalogID ,

		CatalogAccess = 
		(
			from el_CatalogAccess in gfunct_L5DI_GDCfCID_1555.Where(element => !EqualsDefaultValue(element.HEC_DIA_PotentialDiagnosis_Catalog_AccessID)).ToArray()
			group el_CatalogAccess by new 
			{ 
				el_CatalogAccess.HEC_DIA_PotentialDiagnosis_Catalog_AccessID,

			}
			into gfunct_CatalogAccess
			select new L5DI_GDCfCID_1555_CatalogAccess
			{     
				HEC_DIA_PotentialDiagnosis_Catalog_AccessID = gfunct_CatalogAccess.Key.HEC_DIA_PotentialDiagnosis_Catalog_AccessID ,
				BusinessParticipant_RefID = gfunct_CatalogAccess.FirstOrDefault().BusinessParticipant_RefID ,
				IsContributor = gfunct_CatalogAccess.FirstOrDefault().IsContributor ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GDCfCID_1555 : FR_Base
	{
		public L5DI_GDCfCID_1555 Result	{ get; set; }

		public FR_L5DI_GDCfCID_1555() : base() {}

		public FR_L5DI_GDCfCID_1555(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GDCfCID_1555 for attribute P_L5DI_GDCfCID_1555
		[DataContract]
		public class P_L5DI_GDCfCID_1555 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogID { get; set; } 

		}
		#endregion
		#region SClass L5DI_GDCfCID_1555 for attribute L5DI_GDCfCID_1555
		[DataContract]
		public class L5DI_GDCfCID_1555 
		{
			[DataMember]
			public L5DI_GDCfCID_1555_CatalogAccess[] CatalogAccess { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict Catalog_Name { get; set; } 
			[DataMember]
			public bool IsPrivateCatalog { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosis_CatalogID { get; set; } 

		}
		#endregion
		#region SClass L5DI_GDCfCID_1555_CatalogAccess for attribute CatalogAccess
		[DataContract]
		public class L5DI_GDCfCID_1555_CatalogAccess 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosis_Catalog_AccessID { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public bool IsContributor { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DI_GDCfCID_1555 cls_Get_DiagnosesCatalog_for_CatalogID(,P_L5DI_GDCfCID_1555 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DI_GDCfCID_1555 invocationResult = cls_Get_DiagnosesCatalog_for_CatalogID.Invoke(connectionString,P_L5DI_GDCfCID_1555 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.P_L5DI_GDCfCID_1555();
parameter.CatalogID = ...;

*/
