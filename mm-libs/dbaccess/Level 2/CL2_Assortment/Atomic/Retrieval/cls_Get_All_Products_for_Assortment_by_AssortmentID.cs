/* 
 * Generated on 12/5/2014 1:51:17 PM
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

namespace CL2_Assortment.Atomic.Retrieval
{
	/// <summary>
    /// Get_All_Products_for_Assortment_by_AssortmentID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Products_for_Assortment_by_AssortmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Products_for_Assortment_by_AssortmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_GAPfAbA_1444_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2_GAPfAbA_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_GAPfAbA_1444_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Assortment.Atomic.Retrieval.SQL.cls_Get_All_Products_for_Assortment_by_AssortmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AssortmentID", Parameter.AssortmentID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Size", Parameter.Size);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"From", Parameter.From);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriteria", Parameter.SearchCriteria);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderByCriteria", Parameter.OrderByCriteria);



			List<L2_GAPfAbA_1444> results = new List<L2_GAPfAbA_1444>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ASS_AssortmentProductID","CMN_PRO_ProductID","Product_Number","Product_Name_DictID","Product_Description_DictID","Content" });
				while(reader.Read())
				{
					L2_GAPfAbA_1444 resultItem = new L2_GAPfAbA_1444();
					//0:Parameter CMN_PRO_ASS_AssortmentProductID of type Guid
					resultItem.CMN_PRO_ASS_AssortmentProductID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(1);
					//2:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(2);
					//3:Parameter Product_Name_DictID of type Dict
					resultItem.Product_Name_DictID = reader.GetDictionary(3);
					resultItem.Product_Name_DictID.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name_DictID);
					//4:Parameter Product_Description_DictID of type Dict
					resultItem.Product_Description_DictID = reader.GetDictionary(4);
					resultItem.Product_Description_DictID.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description_DictID);
					//5:Parameter Content of type String
					resultItem.Content = reader.GetString(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Products_for_Assortment_by_AssortmentID",ex);
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
		public static FR_L2_GAPfAbA_1444_Array Invoke(string ConnectionString,P_L2_GAPfAbA_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_GAPfAbA_1444_Array Invoke(DbConnection Connection,P_L2_GAPfAbA_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_GAPfAbA_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2_GAPfAbA_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_GAPfAbA_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2_GAPfAbA_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_GAPfAbA_1444_Array functionReturn = new FR_L2_GAPfAbA_1444_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Products_for_Assortment_by_AssortmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_GAPfAbA_1444_Array : FR_Base
	{
		public L2_GAPfAbA_1444[] Result	{ get; set; } 
		public FR_L2_GAPfAbA_1444_Array() : base() {}

		public FR_L2_GAPfAbA_1444_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2_GAPfAbA_1444 for attribute P_L2_GAPfAbA_1444
		[DataContract]
		public class P_L2_GAPfAbA_1444 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssortmentID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public int Size { get; set; } 
			[DataMember]
			public int From { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public String OrderByCriteria { get; set; } 

		}
		#endregion
		#region SClass L2_GAPfAbA_1444 for attribute L2_GAPfAbA_1444
		[DataContract]
		public class L2_GAPfAbA_1444 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ASS_AssortmentProductID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Name_DictID { get; set; } 
			[DataMember]
			public Dict Product_Description_DictID { get; set; } 
			[DataMember]
			public String Content { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_GAPfAbA_1444_Array cls_Get_All_Products_for_Assortment_by_AssortmentID(,P_L2_GAPfAbA_1444 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_GAPfAbA_1444_Array invocationResult = cls_Get_All_Products_for_Assortment_by_AssortmentID.Invoke(connectionString,P_L2_GAPfAbA_1444 Parameter,securityTicket);
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
var parameter = new CL2_Assortment.Atomic.Retrieval.P_L2_GAPfAbA_1444();
parameter.AssortmentID = ...;
parameter.LanguageID = ...;
parameter.Size = ...;
parameter.From = ...;
parameter.SearchCriteria = ...;
parameter.OrderByCriteria = ...;

*/
