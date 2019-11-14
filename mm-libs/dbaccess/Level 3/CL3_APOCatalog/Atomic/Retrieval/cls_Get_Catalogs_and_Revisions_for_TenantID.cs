/* 
 * Generated on 3/12/2014 2:39:29 PM
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

namespace CL3_APOCatalog.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Catalogs_and_Revisions_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Catalogs_and_Revisions_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CA_GCaRfT_1458_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CA_GCaRfT_1458_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_APOCatalog.Atomic.Retrieval.SQL.cls_Get_Catalogs_and_Revisions_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3CA_GCaRfT_1458_raw> results = new List<L3CA_GCaRfT_1458_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_CatalogID","Catalog_Currency_RefID","Catalog_Language_RefID","IsPublicCatalog","CatalogCodeITL","Catalog_Name_DictID","CMN_PRO_Catalog_RevisionID","Valid_From","Valid_Through","PublishedBy_BusinessParticipant_RefID","Default_PricelistRelease_RefID","PublishedOn_Date","CatalogRevision_Name","CatalogRevision_Description","RevisionNumber" });
				while(reader.Read())
				{
					L3CA_GCaRfT_1458_raw resultItem = new L3CA_GCaRfT_1458_raw();
					//0:Parameter CMN_PRO_CatalogID of type Guid
					resultItem.CMN_PRO_CatalogID = reader.GetGuid(0);
					//1:Parameter Catalog_Currency_RefID of type Guid
					resultItem.Catalog_Currency_RefID = reader.GetGuid(1);
					//2:Parameter Catalog_Language_RefID of type Guid
					resultItem.Catalog_Language_RefID = reader.GetGuid(2);
					//3:Parameter IsPublicCatalog of type bool
					resultItem.IsPublicCatalog = reader.GetBoolean(3);
					//4:Parameter CatalogCodeITL of type String
					resultItem.CatalogCodeITL = reader.GetString(4);
					//5:Parameter Catalog_Name_DictID of type Dict
					resultItem.Catalog_Name_DictID = reader.GetDictionary(5);
					resultItem.Catalog_Name_DictID.SourceTable = "cmn_pro_mastercatalogs";
					loader.Append(resultItem.Catalog_Name_DictID);
					//6:Parameter CMN_PRO_Catalog_RevisionID of type Guid
					resultItem.CMN_PRO_Catalog_RevisionID = reader.GetGuid(6);
					//7:Parameter Valid_From of type DateTime
					resultItem.Valid_From = reader.GetDate(7);
					//8:Parameter Valid_Through of type DateTime
					resultItem.Valid_Through = reader.GetDate(8);
					//9:Parameter PublishedBy_BusinessParticipant_RefID of type Guid
					resultItem.PublishedBy_BusinessParticipant_RefID = reader.GetGuid(9);
					//10:Parameter Default_PricelistRelease_RefID of type Guid
					resultItem.Default_PricelistRelease_RefID = reader.GetGuid(10);
					//11:Parameter PublishedOn_Date of type DateTime
					resultItem.PublishedOn_Date = reader.GetDate(11);
					//12:Parameter CatalogRevision_Name of type String
					resultItem.CatalogRevision_Name = reader.GetString(12);
					//13:Parameter CatalogRevision_Description of type String
					resultItem.CatalogRevision_Description = reader.GetString(13);
					//14:Parameter RevisionNumber of type int
					resultItem.RevisionNumber = reader.GetInteger(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Catalogs_and_Revisions_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3CA_GCaRfT_1458_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CA_GCaRfT_1458_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CA_GCaRfT_1458_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CA_GCaRfT_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CA_GCaRfT_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CA_GCaRfT_1458_Array functionReturn = new FR_L3CA_GCaRfT_1458_Array();
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

				throw new Exception("Exception occured in method cls_Get_Catalogs_and_Revisions_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3CA_GCaRfT_1458_raw 
	{
		public Guid CMN_PRO_CatalogID; 
		public Guid Catalog_Currency_RefID; 
		public Guid Catalog_Language_RefID; 
		public bool IsPublicCatalog; 
		public String CatalogCodeITL; 
		public Dict Catalog_Name_DictID; 
		public Guid CMN_PRO_Catalog_RevisionID; 
		public DateTime Valid_From; 
		public DateTime Valid_Through; 
		public Guid PublishedBy_BusinessParticipant_RefID; 
		public Guid Default_PricelistRelease_RefID; 
		public DateTime PublishedOn_Date; 
		public String CatalogRevision_Name; 
		public String CatalogRevision_Description; 
		public int RevisionNumber; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3CA_GCaRfT_1458[] Convert(List<L3CA_GCaRfT_1458_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3CA_GCaRfT_1458 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_CatalogID)).ToArray()
	group el_L3CA_GCaRfT_1458 by new 
	{ 
		el_L3CA_GCaRfT_1458.CMN_PRO_CatalogID,

	}
	into gfunct_L3CA_GCaRfT_1458
	select new L3CA_GCaRfT_1458
	{     
		CMN_PRO_CatalogID = gfunct_L3CA_GCaRfT_1458.Key.CMN_PRO_CatalogID ,
		Catalog_Currency_RefID = gfunct_L3CA_GCaRfT_1458.FirstOrDefault().Catalog_Currency_RefID ,
		Catalog_Language_RefID = gfunct_L3CA_GCaRfT_1458.FirstOrDefault().Catalog_Language_RefID ,
		IsPublicCatalog = gfunct_L3CA_GCaRfT_1458.FirstOrDefault().IsPublicCatalog ,
		CatalogCodeITL = gfunct_L3CA_GCaRfT_1458.FirstOrDefault().CatalogCodeITL ,
		Catalog_Name_DictID = gfunct_L3CA_GCaRfT_1458.FirstOrDefault().Catalog_Name_DictID ,

		Revisions = 
		(
			from el_Revisions in gfunct_L3CA_GCaRfT_1458.Where(element => !EqualsDefaultValue(element.CMN_PRO_Catalog_RevisionID)).ToArray()
			group el_Revisions by new 
			{ 
				el_Revisions.CMN_PRO_Catalog_RevisionID,

			}
			into gfunct_Revisions
			select new L3CA_GCaRfT_1458a
			{     
				CMN_PRO_Catalog_RevisionID = gfunct_Revisions.Key.CMN_PRO_Catalog_RevisionID ,
				Valid_From = gfunct_Revisions.FirstOrDefault().Valid_From ,
				Valid_Through = gfunct_Revisions.FirstOrDefault().Valid_Through ,
				PublishedBy_BusinessParticipant_RefID = gfunct_Revisions.FirstOrDefault().PublishedBy_BusinessParticipant_RefID ,
				Default_PricelistRelease_RefID = gfunct_Revisions.FirstOrDefault().Default_PricelistRelease_RefID ,
				PublishedOn_Date = gfunct_Revisions.FirstOrDefault().PublishedOn_Date ,
				CatalogRevision_Name = gfunct_Revisions.FirstOrDefault().CatalogRevision_Name ,
				CatalogRevision_Description = gfunct_Revisions.FirstOrDefault().CatalogRevision_Description ,
				RevisionNumber = gfunct_Revisions.FirstOrDefault().RevisionNumber ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3CA_GCaRfT_1458_Array : FR_Base
	{
		public L3CA_GCaRfT_1458[] Result	{ get; set; } 
		public FR_L3CA_GCaRfT_1458_Array() : base() {}

		public FR_L3CA_GCaRfT_1458_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3CA_GCaRfT_1458 for attribute L3CA_GCaRfT_1458
		[DataContract]
		public class L3CA_GCaRfT_1458 
		{
			[DataMember]
			public L3CA_GCaRfT_1458a[] Revisions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CatalogID { get; set; } 
			[DataMember]
			public Guid Catalog_Currency_RefID { get; set; } 
			[DataMember]
			public Guid Catalog_Language_RefID { get; set; } 
			[DataMember]
			public bool IsPublicCatalog { get; set; } 
			[DataMember]
			public String CatalogCodeITL { get; set; } 
			[DataMember]
			public Dict Catalog_Name_DictID { get; set; } 

		}
		#endregion
		#region SClass L3CA_GCaRfT_1458a for attribute Revisions
		[DataContract]
		public class L3CA_GCaRfT_1458a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Catalog_RevisionID { get; set; } 
			[DataMember]
			public DateTime Valid_From { get; set; } 
			[DataMember]
			public DateTime Valid_Through { get; set; } 
			[DataMember]
			public Guid PublishedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid Default_PricelistRelease_RefID { get; set; } 
			[DataMember]
			public DateTime PublishedOn_Date { get; set; } 
			[DataMember]
			public String CatalogRevision_Name { get; set; } 
			[DataMember]
			public String CatalogRevision_Description { get; set; } 
			[DataMember]
			public int RevisionNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CA_GCaRfT_1458_Array cls_Get_Catalogs_and_Revisions_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CA_GCaRfT_1458_Array invocationResult = cls_Get_Catalogs_and_Revisions_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

