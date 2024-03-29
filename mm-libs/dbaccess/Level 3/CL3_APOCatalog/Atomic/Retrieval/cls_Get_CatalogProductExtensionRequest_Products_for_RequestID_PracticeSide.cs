/* 
 * Generated on 3/12/2014 2:39:30 PM
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
    /// var result = cls_Get_CatalogProductExtensionRequest_Products_for_RequestID_PracticeSide.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CatalogProductExtensionRequest_Products_for_RequestID_PracticeSide
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CA_GCPERPfRPS_1502 Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_GCPERPfRPS_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CA_GCPERPfRPS_1502();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_APOCatalog.Atomic.Retrieval.SQL.cls_Get_CatalogProductExtensionRequest_Products_for_RequestID_PracticeSide.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RequestID", Parameter.RequestID);



			List<L3CA_GCPERPfRPS_1502_raw> results = new List<L3CA_GCPERPfRPS_1502_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Request_Answer","IsAnswerSent","IfAnswerSent_Date","CMN_BPT_CTM_CatalogProductExtensionRequestID","CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID","CMN_PRO_Product_RefID","Comment","Product_Name_DictID","Product_Description_DictID","Product_Number" });
				while(reader.Read())
				{
					L3CA_GCPERPfRPS_1502_raw resultItem = new L3CA_GCPERPfRPS_1502_raw();
					//0:Parameter Request_Answer of type String
					resultItem.Request_Answer = reader.GetString(0);
					//1:Parameter IsAnswerSent of type bool
					resultItem.IsAnswerSent = reader.GetBoolean(1);
					//2:Parameter IfAnswerSent_Date of type DateTime
					resultItem.IfAnswerSent_Date = reader.GetDate(2);
					//3:Parameter CMN_BPT_CTM_CatalogProductExtensionRequestID of type Guid
					resultItem.CMN_BPT_CTM_CatalogProductExtensionRequestID = reader.GetGuid(3);
					//4:Parameter CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID of type Guid
					resultItem.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID = reader.GetGuid(4);
					//5:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(5);
					//6:Parameter Comment of type String
					resultItem.Comment = reader.GetString(6);
					//7:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(7);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//8:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(8);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//9:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CatalogProductExtensionRequest_Products_for_RequestID_PracticeSide",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3CA_GCPERPfRPS_1502_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CA_GCPERPfRPS_1502 Invoke(string ConnectionString,P_L3CA_GCPERPfRPS_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CA_GCPERPfRPS_1502 Invoke(DbConnection Connection,P_L3CA_GCPERPfRPS_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CA_GCPERPfRPS_1502 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_GCPERPfRPS_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CA_GCPERPfRPS_1502 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_GCPERPfRPS_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CA_GCPERPfRPS_1502 functionReturn = new FR_L3CA_GCPERPfRPS_1502();
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

				throw new Exception("Exception occured in method cls_Get_CatalogProductExtensionRequest_Products_for_RequestID_PracticeSide",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3CA_GCPERPfRPS_1502_raw 
	{
		public String Request_Answer; 
		public bool IsAnswerSent; 
		public DateTime IfAnswerSent_Date; 
		public Guid CMN_BPT_CTM_CatalogProductExtensionRequestID; 
		public Guid CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID; 
		public Guid CMN_PRO_Product_RefID; 
		public String Comment; 
		public Dict Product_Name; 
		public Dict Product_Description; 
		public String Product_Number; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3CA_GCPERPfRPS_1502[] Convert(List<L3CA_GCPERPfRPS_1502_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3CA_GCPERPfRPS_1502 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_CTM_CatalogProductExtensionRequestID)).ToArray()
	group el_L3CA_GCPERPfRPS_1502 by new 
	{ 
		el_L3CA_GCPERPfRPS_1502.CMN_BPT_CTM_CatalogProductExtensionRequestID,

	}
	into gfunct_L3CA_GCPERPfRPS_1502
	select new L3CA_GCPERPfRPS_1502
	{     
		Request_Answer = gfunct_L3CA_GCPERPfRPS_1502.FirstOrDefault().Request_Answer ,
		IsAnswerSent = gfunct_L3CA_GCPERPfRPS_1502.FirstOrDefault().IsAnswerSent ,
		IfAnswerSent_Date = gfunct_L3CA_GCPERPfRPS_1502.FirstOrDefault().IfAnswerSent_Date ,
		CMN_BPT_CTM_CatalogProductExtensionRequestID = gfunct_L3CA_GCPERPfRPS_1502.Key.CMN_BPT_CTM_CatalogProductExtensionRequestID ,

		Products = 
		(
			from el_Products in gfunct_L3CA_GCPERPfRPS_1502.Where(element => !EqualsDefaultValue(element.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID)).ToArray()
			group el_Products by new 
			{ 
				el_Products.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID,

			}
			into gfunct_Products
			select new L3CA_GCPERPfRPS_1502a
			{     
				CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID = gfunct_Products.Key.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID ,
				CMN_PRO_Product_RefID = gfunct_Products.FirstOrDefault().CMN_PRO_Product_RefID ,
				Comment = gfunct_Products.FirstOrDefault().Comment ,
				Product_Name = gfunct_Products.FirstOrDefault().Product_Name ,
				Product_Description = gfunct_Products.FirstOrDefault().Product_Description ,
				Product_Number = gfunct_Products.FirstOrDefault().Product_Number ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3CA_GCPERPfRPS_1502 : FR_Base
	{
		public L3CA_GCPERPfRPS_1502 Result	{ get; set; }

		public FR_L3CA_GCPERPfRPS_1502() : base() {}

		public FR_L3CA_GCPERPfRPS_1502(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CA_GCPERPfRPS_1502 for attribute P_L3CA_GCPERPfRPS_1502
		[DataContract]
		public class P_L3CA_GCPERPfRPS_1502 
		{
			//Standard type parameters
			[DataMember]
			public Guid RequestID { get; set; } 

		}
		#endregion
		#region SClass L3CA_GCPERPfRPS_1502 for attribute L3CA_GCPERPfRPS_1502
		[DataContract]
		public class L3CA_GCPERPfRPS_1502 
		{
			[DataMember]
			public L3CA_GCPERPfRPS_1502a[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public String Request_Answer { get; set; } 
			[DataMember]
			public bool IsAnswerSent { get; set; } 
			[DataMember]
			public DateTime IfAnswerSent_Date { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_CatalogProductExtensionRequestID { get; set; } 

		}
		#endregion
		#region SClass L3CA_GCPERPfRPS_1502a for attribute Products
		[DataContract]
		public class L3CA_GCPERPfRPS_1502a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CA_GCPERPfRPS_1502 cls_Get_CatalogProductExtensionRequest_Products_for_RequestID_PracticeSide(,P_L3CA_GCPERPfRPS_1502 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CA_GCPERPfRPS_1502 invocationResult = cls_Get_CatalogProductExtensionRequest_Products_for_RequestID_PracticeSide.Invoke(connectionString,P_L3CA_GCPERPfRPS_1502 Parameter,securityTicket);
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
var parameter = new CL3_APOCatalog.Atomic.Retrieval.P_L3CA_GCPERPfRPS_1502();
parameter.RequestID = ...;

*/
