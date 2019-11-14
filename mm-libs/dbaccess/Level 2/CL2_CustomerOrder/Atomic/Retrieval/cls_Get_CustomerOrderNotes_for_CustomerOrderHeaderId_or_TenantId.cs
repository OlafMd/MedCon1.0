/* 
 * Generated on 7/29/2014 10:40:46 AM
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
using System.Runtime.Serialization;

namespace CL2_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderNotes_for_CustomerOrderHeaderId_or_TenantId.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderNotes_for_CustomerOrderHeaderId_or_TenantId
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CO_GCONfCOHoT_1444_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2CO_GCONfCOHoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2CO_GCONfCOHoT_1444_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_CustomerOrderNotes_for_CustomerOrderHeaderId_or_TenantId.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerOrderHeaderID", Parameter.CustomerOrderHeaderID);



			List<L2CO_GCONfCOHoT_1444> results = new List<L2CO_GCONfCOHoT_1444>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_NoteID","CustomerOrder_Header_RefID","CustomerOrder_Position_RefID","CMN_BPT_CTM_OrganizationalUnit_RefID","Title","Comment","NotePublishDate","Creation_Timestamp","CreatedBy_BusinessParticipant_RefID","CreatedBy" });
				while(reader.Read())
				{
					L2CO_GCONfCOHoT_1444 resultItem = new L2CO_GCONfCOHoT_1444();
					//0:Parameter ORD_CUO_CustomerOrder_NoteID of type Guid
					resultItem.ORD_CUO_CustomerOrder_NoteID = reader.GetGuid(0);
					//1:Parameter CustomerOrder_Header_RefID of type Guid
					resultItem.CustomerOrder_Header_RefID = reader.GetGuid(1);
					//2:Parameter CustomerOrder_Position_RefID of type Guid
					resultItem.CustomerOrder_Position_RefID = reader.GetGuid(2);
					//3:Parameter CMN_BPT_CTM_OrganizationalUnit_RefID of type Guid
					resultItem.CMN_BPT_CTM_OrganizationalUnit_RefID = reader.GetGuid(3);
					//4:Parameter Title of type String
					resultItem.Title = reader.GetString(4);
					//5:Parameter Comment of type String
					resultItem.Comment = reader.GetString(5);
					//6:Parameter NotePublishDate of type DateTime
					resultItem.NotePublishDate = reader.GetDate(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(8);
					//9:Parameter CreatedBy of type String
					resultItem.CreatedBy = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderNotes_for_CustomerOrderHeaderId_or_TenantId",ex);
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
		public static FR_L2CO_GCONfCOHoT_1444_Array Invoke(string ConnectionString,P_L2CO_GCONfCOHoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CO_GCONfCOHoT_1444_Array Invoke(DbConnection Connection,P_L2CO_GCONfCOHoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CO_GCONfCOHoT_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CO_GCONfCOHoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CO_GCONfCOHoT_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CO_GCONfCOHoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CO_GCONfCOHoT_1444_Array functionReturn = new FR_L2CO_GCONfCOHoT_1444_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderNotes_for_CustomerOrderHeaderId_or_TenantId",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CO_GCONfCOHoT_1444_Array : FR_Base
	{
		public L2CO_GCONfCOHoT_1444[] Result	{ get; set; } 
		public FR_L2CO_GCONfCOHoT_1444_Array() : base() {}

		public FR_L2CO_GCONfCOHoT_1444_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2CO_GCONfCOHoT_1444 for attribute P_L2CO_GCONfCOHoT_1444
		[DataContract]
		public class P_L2CO_GCONfCOHoT_1444 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L2CO_GCONfCOHoT_1444 for attribute L2CO_GCONfCOHoT_1444
		[DataContract]
		public class L2CO_GCONfCOHoT_1444 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_NoteID { get; set; } 
			[DataMember]
			public Guid CustomerOrder_Header_RefID { get; set; } 
			[DataMember]
			public Guid CustomerOrder_Position_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnit_RefID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public DateTime NotePublishDate { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String CreatedBy { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CO_GCONfCOHoT_1444_Array cls_Get_CustomerOrderNotes_for_CustomerOrderHeaderId_or_TenantId(,P_L2CO_GCONfCOHoT_1444 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CO_GCONfCOHoT_1444_Array invocationResult = cls_Get_CustomerOrderNotes_for_CustomerOrderHeaderId_or_TenantId.Invoke(connectionString,P_L2CO_GCONfCOHoT_1444 Parameter,securityTicket);
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
var parameter = new CL2_CustomerOrder.Atomic.Retrieval.P_L2CO_GCONfCOHoT_1444();
parameter.CustomerOrderHeaderID = ...;

*/
