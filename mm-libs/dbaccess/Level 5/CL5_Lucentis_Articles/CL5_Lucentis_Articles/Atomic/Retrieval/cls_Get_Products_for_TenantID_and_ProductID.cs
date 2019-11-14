/* 
 * Generated on 8/30/2013 10:34:20 AM
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

namespace CL5_Lucentis_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_for_TenantID_and_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_for_TenantID_and_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LA_GPfTaPID_1234 Execute(DbConnection Connection,DbTransaction Transaction,P_L5LA_GPfTaPID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5LA_GPfTaPID_1234();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Articles.Atomic.Retrieval.SQL.cls_Get_Products_for_TenantID_and_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5LA_GPfTaPID_1234> results = new List<L5LA_GPfTaPID_1234>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ArticleRecipe","Product_Name_DictID","Product_Number","HEC_ProductID","Creation_Timestamp","Tenant_RefID","Product_Description_DictID","CMN_PRO_ProductID" });
				while(reader.Read())
				{
					L5LA_GPfTaPID_1234 resultItem = new L5LA_GPfTaPID_1234();
					//0:Parameter ArticleRecipe of type String
					resultItem.ArticleRecipe = reader.GetString(0);
					//1:Parameter Product_Name_DictID of type Dict
					resultItem.Product_Name_DictID = reader.GetDictionary(1);
					resultItem.Product_Name_DictID.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name_DictID);
					//2:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(2);
					//3:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);
					//6:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(6);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//7:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_for_TenantID_and_ProductID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LA_GPfTaPID_1234 Invoke(string ConnectionString,P_L5LA_GPfTaPID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LA_GPfTaPID_1234 Invoke(DbConnection Connection,P_L5LA_GPfTaPID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LA_GPfTaPID_1234 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LA_GPfTaPID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LA_GPfTaPID_1234 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LA_GPfTaPID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LA_GPfTaPID_1234 functionReturn = new FR_L5LA_GPfTaPID_1234();
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

				throw new Exception("Exception occured in method cls_Get_Products_for_TenantID_and_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5LA_GPfTaPID_1234 : FR_Base
	{
		public L5LA_GPfTaPID_1234 Result	{ get; set; }

		public FR_L5LA_GPfTaPID_1234() : base() {}

		public FR_L5LA_GPfTaPID_1234(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5LA_GPfTaPID_1234 for attribute P_L5LA_GPfTaPID_1234
		[DataContract]
		public class P_L5LA_GPfTaPID_1234 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5LA_GPfTaPID_1234 for attribute L5LA_GPfTaPID_1234
		[DataContract]
		public class L5LA_GPfTaPID_1234 
		{
			[DataMember]
			public L5LA_GPfTaPID_1234_Surveys[] Surveys { get; set; }

			//Standard type parameters
			[DataMember]
			public String ArticleRecipe { get; set; } 
			[DataMember]
			public Dict Product_Name_DictID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 

		}
		#endregion
		#region SClass L5LA_GPfTaPID_1234_Surveys for attribute Surveys
		[DataContract]
		public class L5LA_GPfTaPID_1234_Surveys 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_Questionnaire_AssignmentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LA_GPfTaPID_1234 cls_Get_Products_for_TenantID_and_ProductID(,P_L5LA_GPfTaPID_1234 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5LA_GPfTaPID_1234 invocationResult = cls_Get_Products_for_TenantID_and_ProductID.Invoke(connectionString,P_L5LA_GPfTaPID_1234 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Articles.Atomic.Retrieval.P_L5LA_GPfTaPID_1234();
parameter.ProductID = ...;

*/
