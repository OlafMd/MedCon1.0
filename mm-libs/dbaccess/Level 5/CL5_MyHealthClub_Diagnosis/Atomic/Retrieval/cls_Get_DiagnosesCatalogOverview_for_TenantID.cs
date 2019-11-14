/* 
 * Generated on 11/12/2014 2:05:18 PM
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
    /// var result = cls_Get_DiagnosesCatalogOverview_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiagnosesCatalogOverview_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GDCOfTID_1347_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GDCOfTID_1347_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_DiagnosesCatalogOverview_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5DI_GDCOfTID_1347_raw> results = new List<L5DI_GDCOfTID_1347_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Catalog_Name_DictID","IsPrivateCatalog","HEC_DIA_PotentialDiagnosis_CatalogID","HEC_DIA_PotentialDiagnosis_Catalog_AccessID","IsContributor","FirstName","LastName","Title" });
				while(reader.Read())
				{
					L5DI_GDCOfTID_1347_raw resultItem = new L5DI_GDCOfTID_1347_raw();
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
					//4:Parameter IsContributor of type bool
					resultItem.IsContributor = reader.GetBoolean(4);
					//5:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(5);
					//6:Parameter LastName of type String
					resultItem.LastName = reader.GetString(6);
					//7:Parameter Title of type String
					resultItem.Title = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DiagnosesCatalogOverview_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DI_GDCOfTID_1347_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DI_GDCOfTID_1347_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GDCOfTID_1347_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GDCOfTID_1347_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GDCOfTID_1347_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GDCOfTID_1347_Array functionReturn = new FR_L5DI_GDCOfTID_1347_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_DiagnosesCatalogOverview_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DI_GDCOfTID_1347_raw 
	{
		public Dict Catalog_Name; 
		public bool IsPrivateCatalog; 
		public Guid HEC_DIA_PotentialDiagnosis_CatalogID; 
		public Guid HEC_DIA_PotentialDiagnosis_Catalog_AccessID; 
		public bool IsContributor; 
		public String FirstName; 
		public String LastName; 
		public String Title; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DI_GDCOfTID_1347[] Convert(List<L5DI_GDCOfTID_1347_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DI_GDCOfTID_1347 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DIA_PotentialDiagnosis_CatalogID)).ToArray()
	group el_L5DI_GDCOfTID_1347 by new 
	{ 
		el_L5DI_GDCOfTID_1347.HEC_DIA_PotentialDiagnosis_CatalogID,

	}
	into gfunct_L5DI_GDCOfTID_1347
	select new L5DI_GDCOfTID_1347
	{     
		Catalog_Name = gfunct_L5DI_GDCOfTID_1347.FirstOrDefault().Catalog_Name ,
		IsPrivateCatalog = gfunct_L5DI_GDCOfTID_1347.FirstOrDefault().IsPrivateCatalog ,
		HEC_DIA_PotentialDiagnosis_CatalogID = gfunct_L5DI_GDCOfTID_1347.Key.HEC_DIA_PotentialDiagnosis_CatalogID ,

		CatalogAccess = 
		(
			from el_CatalogAccess in gfunct_L5DI_GDCOfTID_1347.Where(element => !EqualsDefaultValue(element.HEC_DIA_PotentialDiagnosis_Catalog_AccessID)).ToArray()
			group el_CatalogAccess by new 
			{ 
				el_CatalogAccess.HEC_DIA_PotentialDiagnosis_Catalog_AccessID,

			}
			into gfunct_CatalogAccess
			select new L5DI_GDCOfTID_1347_CatalogAccess
			{     
				HEC_DIA_PotentialDiagnosis_Catalog_AccessID = gfunct_CatalogAccess.Key.HEC_DIA_PotentialDiagnosis_Catalog_AccessID ,
				IsContributor = gfunct_CatalogAccess.FirstOrDefault().IsContributor ,
				FirstName = gfunct_CatalogAccess.FirstOrDefault().FirstName ,
				LastName = gfunct_CatalogAccess.FirstOrDefault().LastName ,
				Title = gfunct_CatalogAccess.FirstOrDefault().Title ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GDCOfTID_1347_Array : FR_Base
	{
		public L5DI_GDCOfTID_1347[] Result	{ get; set; } 
		public FR_L5DI_GDCOfTID_1347_Array() : base() {}

		public FR_L5DI_GDCOfTID_1347_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5DI_GDCOfTID_1347 for attribute L5DI_GDCOfTID_1347
		[DataContract]
		public class L5DI_GDCOfTID_1347 
		{
			[DataMember]
			public L5DI_GDCOfTID_1347_CatalogAccess[] CatalogAccess { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict Catalog_Name { get; set; } 
			[DataMember]
			public bool IsPrivateCatalog { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosis_CatalogID { get; set; } 

		}
		#endregion
		#region SClass L5DI_GDCOfTID_1347_CatalogAccess for attribute CatalogAccess
		[DataContract]
		public class L5DI_GDCOfTID_1347_CatalogAccess 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosis_Catalog_AccessID { get; set; } 
			[DataMember]
			public bool IsContributor { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DI_GDCOfTID_1347_Array cls_Get_DiagnosesCatalogOverview_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DI_GDCOfTID_1347_Array invocationResult = cls_Get_DiagnosesCatalogOverview_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

