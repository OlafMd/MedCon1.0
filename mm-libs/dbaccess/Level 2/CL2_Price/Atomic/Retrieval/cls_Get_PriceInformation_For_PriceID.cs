/* 
 * Generated on 22/11/2013 04:36:27
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

namespace CL2_Price.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PriceInformation_For_PriceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PriceInformation_For_PriceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PR_GPIfP_1135 Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_GPIfP_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PR_GPIfP_1135();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Price.Atomic.Retrieval.SQL.cls_Get_PriceInformation_For_PriceID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PriceID", Parameter.PriceID);



			List<L2PR_GPIfP_1135> results = new List<L2PR_GPIfP_1135>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Price_RefID","PriceValue_Amount","Symbol","Name_DictID","ISO4127","CMN_CurrencyID" });
				while(reader.Read())
				{
					L2PR_GPIfP_1135 resultItem = new L2PR_GPIfP_1135();
					//0:Parameter Price_RefID of type Guid
					resultItem.Price_RefID = reader.GetGuid(0);
					//1:Parameter PriceValue_Amount of type String
					resultItem.PriceValue_Amount = reader.GetString(1);
					//2:Parameter Symbol of type String
					resultItem.Symbol = reader.GetString(2);
					//3:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(3);
					resultItem.Name.SourceTable = "cmn_currencies";
					loader.Append(resultItem.Name);
					//4:Parameter ISO4127 of type String
					resultItem.ISO4127 = reader.GetString(4);
					//5:Parameter CMN_CurrencyID of type Guid
					resultItem.CMN_CurrencyID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PriceInformation_For_PriceID",ex);
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
		public static FR_L2PR_GPIfP_1135 Invoke(string ConnectionString,P_L2PR_GPIfP_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PR_GPIfP_1135 Invoke(DbConnection Connection,P_L2PR_GPIfP_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PR_GPIfP_1135 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_GPIfP_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PR_GPIfP_1135 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_GPIfP_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PR_GPIfP_1135 functionReturn = new FR_L2PR_GPIfP_1135();
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

				throw new Exception("Exception occured in method cls_Get_PriceInformation_For_PriceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PR_GPIfP_1135 : FR_Base
	{
		public L2PR_GPIfP_1135 Result	{ get; set; }

		public FR_L2PR_GPIfP_1135() : base() {}

		public FR_L2PR_GPIfP_1135(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PR_GPIfP_1135 for attribute P_L2PR_GPIfP_1135
		[DataContract]
		public class P_L2PR_GPIfP_1135 
		{
			//Standard type parameters
			[DataMember]
			public Guid PriceID { get; set; } 

		}
		#endregion
		#region SClass L2PR_GPIfP_1135 for attribute L2PR_GPIfP_1135
		[DataContract]
		public class L2PR_GPIfP_1135 
		{
			//Standard type parameters
			[DataMember]
			public Guid Price_RefID { get; set; } 
			[DataMember]
			public String PriceValue_Amount { get; set; } 
			[DataMember]
			public String Symbol { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public String ISO4127 { get; set; } 
			[DataMember]
			public Guid CMN_CurrencyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PR_GPIfP_1135 cls_Get_PriceInformation_For_PriceID(,P_L2PR_GPIfP_1135 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PR_GPIfP_1135 invocationResult = cls_Get_PriceInformation_For_PriceID.Invoke(connectionString,P_L2PR_GPIfP_1135 Parameter,securityTicket);
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
var parameter = new CL2_Price.Atomic.Retrieval.P_L2PR_GPIfP_1135();
parameter.PriceID = ...;

*/
