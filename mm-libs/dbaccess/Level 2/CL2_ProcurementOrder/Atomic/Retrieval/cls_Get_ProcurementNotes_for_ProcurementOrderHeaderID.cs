/* 
 * Generated on 9/6/2014 11:31:14
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

namespace CL2_ProcurementOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProcurementNotes_for_ProcurementOrderHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementNotes_for_ProcurementOrderHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PO_GPNfPOH_1634_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2PO_GPNfPOH_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PO_GPNfPOH_1634_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_ProcurementOrder.Atomic.Retrieval.SQL.cls_Get_ProcurementNotes_for_ProcurementOrderHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HeaderID", Parameter.HeaderID);



			List<L2PO_GPNfPOH_1634> results = new List<L2PO_GPNfPOH_1634>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "SequenceOrderNumber","NotePublishDate","Title","Comment","CMN_STR_Office_RefID","ORD_PRC_ProcurementOrder_NoteID","ORD_PRC_ProcurementOrder_Header_RefID","ORD_PRC_ProcurementOrder_Position_RefID","Creation_Timestamp" });
				while(reader.Read())
				{
					L2PO_GPNfPOH_1634 resultItem = new L2PO_GPNfPOH_1634();
					//0:Parameter SequenceOrderNumber of type String
					resultItem.SequenceOrderNumber = reader.GetString(0);
					//1:Parameter NotePublishDate of type DateTime
					resultItem.NotePublishDate = reader.GetDate(1);
					//2:Parameter Title of type String
					resultItem.Title = reader.GetString(2);
					//3:Parameter Comment of type String
					resultItem.Comment = reader.GetString(3);
					//4:Parameter CMN_STR_Office_RefID of type Guid
					resultItem.CMN_STR_Office_RefID = reader.GetGuid(4);
					//5:Parameter ORD_PRC_ProcurementOrder_NoteID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_NoteID = reader.GetGuid(5);
					//6:Parameter ORD_PRC_ProcurementOrder_Header_RefID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_Header_RefID = reader.GetGuid(6);
					//7:Parameter ORD_PRC_ProcurementOrder_Position_RefID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_Position_RefID = reader.GetGuid(7);
					//8:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProcurementNotes_for_ProcurementOrderHeaderID",ex);
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
		public static FR_L2PO_GPNfPOH_1634_Array Invoke(string ConnectionString,P_L2PO_GPNfPOH_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PO_GPNfPOH_1634_Array Invoke(DbConnection Connection,P_L2PO_GPNfPOH_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PO_GPNfPOH_1634_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PO_GPNfPOH_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PO_GPNfPOH_1634_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PO_GPNfPOH_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PO_GPNfPOH_1634_Array functionReturn = new FR_L2PO_GPNfPOH_1634_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementNotes_for_ProcurementOrderHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PO_GPNfPOH_1634_Array : FR_Base
	{
		public L2PO_GPNfPOH_1634[] Result	{ get; set; } 
		public FR_L2PO_GPNfPOH_1634_Array() : base() {}

		public FR_L2PO_GPNfPOH_1634_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PO_GPNfPOH_1634 for attribute P_L2PO_GPNfPOH_1634
		[DataContract]
		public class P_L2PO_GPNfPOH_1634 
		{
			//Standard type parameters
			[DataMember]
			public Guid HeaderID { get; set; } 

		}
		#endregion
		#region SClass L2PO_GPNfPOH_1634 for attribute L2PO_GPNfPOH_1634
		[DataContract]
		public class L2PO_GPNfPOH_1634 
		{
			//Standard type parameters
			[DataMember]
			public String SequenceOrderNumber { get; set; } 
			[DataMember]
			public DateTime NotePublishDate { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_NoteID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_Header_RefID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_Position_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PO_GPNfPOH_1634_Array cls_Get_ProcurementNotes_for_ProcurementOrderHeaderID(,P_L2PO_GPNfPOH_1634 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PO_GPNfPOH_1634_Array invocationResult = cls_Get_ProcurementNotes_for_ProcurementOrderHeaderID.Invoke(connectionString,P_L2PO_GPNfPOH_1634 Parameter,securityTicket);
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
var parameter = new CL2_ProcurementOrder.Atomic.Retrieval.P_L2PO_GPNfPOH_1634();
parameter.HeaderID = ...;

*/
