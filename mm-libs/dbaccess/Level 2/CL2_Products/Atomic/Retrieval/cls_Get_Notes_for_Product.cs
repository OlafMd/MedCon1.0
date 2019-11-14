/* 
 * Generated on 8/8/2014 04:45:35
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_Products.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Notes_for_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Notes_for_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2P_GNfP_1655_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2P_GNfP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2P_GNfP_1655_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Products.Atomic.Retrieval.SQL.cls_Get_Notes_for_Product.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductID"," IN $$ProductID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductID$",Parameter.ProductID);


			List<L2P_GNfP_1655> results = new List<L2P_GNfP_1655>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_NoteID","Product_RefID","NoteContent","IsImportant","CreatedBy_BusinessParticipant_RefID","DisplayName","Creation_Timestamp","Product_Name_DictID" });
				while(reader.Read())
				{
					L2P_GNfP_1655 resultItem = new L2P_GNfP_1655();
					//0:Parameter CMN_PRO_Product_NoteID of type Guid
					resultItem.CMN_PRO_Product_NoteID = reader.GetGuid(0);
					//1:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(1);
					//2:Parameter NoteContent of type String
					resultItem.NoteContent = reader.GetString(2);
					//3:Parameter IsImportant of type bool
					resultItem.IsImportant = reader.GetBoolean(3);
					//4:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(4);
					//5:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);
					//7:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(7);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Notes_for_Product",ex);
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
		public static FR_L2P_GNfP_1655_Array Invoke(string ConnectionString,P_L2P_GNfP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2P_GNfP_1655_Array Invoke(DbConnection Connection,P_L2P_GNfP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2P_GNfP_1655_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2P_GNfP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2P_GNfP_1655_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2P_GNfP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2P_GNfP_1655_Array functionReturn = new FR_L2P_GNfP_1655_Array();
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

				throw new Exception("Exception occured in method cls_Get_Notes_for_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2P_GNfP_1655_Array : FR_Base
	{
		public L2P_GNfP_1655[] Result	{ get; set; } 
		public FR_L2P_GNfP_1655_Array() : base() {}

		public FR_L2P_GNfP_1655_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2P_GNfP_1655 for attribute P_L2P_GNfP_1655
		[DataContract]
		public class P_L2P_GNfP_1655 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductID { get; set; } 

		}
		#endregion
		#region SClass L2P_GNfP_1655 for attribute L2P_GNfP_1655
		[DataContract]
		public class L2P_GNfP_1655 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_NoteID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public String NoteContent { get; set; } 
			[DataMember]
			public bool IsImportant { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2P_GNfP_1655_Array cls_Get_Notes_for_Product(,P_L2P_GNfP_1655 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2P_GNfP_1655_Array invocationResult = cls_Get_Notes_for_Product.Invoke(connectionString,P_L2P_GNfP_1655 Parameter,securityTicket);
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
var parameter = new CL2_Products.Atomic.Retrieval.P_L2P_GNfP_1655();
parameter.ProductID = ...;

*/
