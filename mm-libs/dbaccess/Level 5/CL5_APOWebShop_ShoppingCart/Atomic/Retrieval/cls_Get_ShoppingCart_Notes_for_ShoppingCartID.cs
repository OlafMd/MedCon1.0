/* 
 * Generated on 3/31/2014 12:17:28 PM
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

namespace CL5_APOWebShop_ShoppingCart.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShoppingCart_Notes_for_ShoppingCartID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShoppingCart_Notes_for_ShoppingCartID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSAR_GSCNfSC_1454_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSAR_GSCNfSC_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AWSAR_GSCNfSC_1454_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.SQL.cls_Get_ShoppingCart_Notes_for_ShoppingCartID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShoppingCartID", Parameter.ShoppingCartID);



			List<L5AWSAR_GSCNfSC_1454> results = new List<L5AWSAR_GSCNfSC_1454>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ShoppingCartID","ShoppingCartNoteID","CreatedBy_Account_RefID","FirstName","LastName","Memo_Text","UpdatedOn","IsNoteForProcurementOrder" });
				while(reader.Read())
				{
					L5AWSAR_GSCNfSC_1454 resultItem = new L5AWSAR_GSCNfSC_1454();
					//0:Parameter ShoppingCartID of type Guid
					resultItem.ShoppingCartID = reader.GetGuid(0);
					//1:Parameter ShoppingCartNoteID of type Guid
					resultItem.ShoppingCartNoteID = reader.GetGuid(1);
					//2:Parameter CreatedBy_Account_RefID of type Guid
					resultItem.CreatedBy_Account_RefID = reader.GetGuid(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter Memo_Text of type String
					resultItem.Memo_Text = reader.GetString(5);
					//6:Parameter UpdatedOn of type DateTime
					resultItem.UpdatedOn = reader.GetDate(6);
					//7:Parameter IsNoteForProcurementOrder of type Boolean
					resultItem.IsNoteForProcurementOrder = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShoppingCart_Notes_for_ShoppingCartID",ex);
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
		public static FR_L5AWSAR_GSCNfSC_1454_Array Invoke(string ConnectionString,P_L5AWSAR_GSCNfSC_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSAR_GSCNfSC_1454_Array Invoke(DbConnection Connection,P_L5AWSAR_GSCNfSC_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSAR_GSCNfSC_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSAR_GSCNfSC_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSAR_GSCNfSC_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSAR_GSCNfSC_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSAR_GSCNfSC_1454_Array functionReturn = new FR_L5AWSAR_GSCNfSC_1454_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShoppingCart_Notes_for_ShoppingCartID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSAR_GSCNfSC_1454_Array : FR_Base
	{
		public L5AWSAR_GSCNfSC_1454[] Result	{ get; set; } 
		public FR_L5AWSAR_GSCNfSC_1454_Array() : base() {}

		public FR_L5AWSAR_GSCNfSC_1454_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSAR_GSCNfSC_1454 for attribute P_L5AWSAR_GSCNfSC_1454
		[DataContract]
		public class P_L5AWSAR_GSCNfSC_1454 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartID { get; set; } 

		}
		#endregion
		#region SClass L5AWSAR_GSCNfSC_1454 for attribute L5AWSAR_GSCNfSC_1454
		[DataContract]
		public class L5AWSAR_GSCNfSC_1454 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartID { get; set; } 
			[DataMember]
			public Guid ShoppingCartNoteID { get; set; } 
			[DataMember]
			public Guid CreatedBy_Account_RefID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Memo_Text { get; set; } 
			[DataMember]
			public DateTime UpdatedOn { get; set; } 
			[DataMember]
			public Boolean IsNoteForProcurementOrder { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSAR_GSCNfSC_1454_Array cls_Get_ShoppingCart_Notes_for_ShoppingCartID(,P_L5AWSAR_GSCNfSC_1454 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSAR_GSCNfSC_1454_Array invocationResult = cls_Get_ShoppingCart_Notes_for_ShoppingCartID.Invoke(connectionString,P_L5AWSAR_GSCNfSC_1454 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.P_L5AWSAR_GSCNfSC_1454();
parameter.ShoppingCartID = ...;

*/
