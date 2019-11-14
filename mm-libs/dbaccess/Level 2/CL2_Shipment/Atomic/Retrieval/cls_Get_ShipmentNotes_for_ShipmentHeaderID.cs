/* 
 * Generated on 5/27/2014 1:37:12 PM
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

namespace CL2_Shipment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentNotes_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentNotes_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2SH_GSNfSH_1654_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2SH_GSNfSH_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2SH_GSNfSH_1654_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Shipment.Atomic.Retrieval.SQL.cls_Get_ShipmentNotes_for_ShipmentHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);



			List<L2SH_GSNfSH_1654> results = new List<L2SH_GSNfSH_1654>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_NoteID","Shipment_Header_RefID","Shipment_Position_RefID","IsNotePrintedOnDeliveryPaper","Title","Comment","NotePublishDate","SequenceOrderNumber","CreatedBy_BusinessParticipant_RefID","CreatedBy","Creation_Timestamp","Tenant_RefID","IsDeleted" });
				while(reader.Read())
				{
					L2SH_GSNfSH_1654 resultItem = new L2SH_GSNfSH_1654();
					//0:Parameter LOG_SHP_Shipment_NoteID of type Guid
					resultItem.LOG_SHP_Shipment_NoteID = reader.GetGuid(0);
					//1:Parameter Shipment_Header_RefID of type Guid
					resultItem.Shipment_Header_RefID = reader.GetGuid(1);
					//2:Parameter Shipment_Position_RefID of type Guid
					resultItem.Shipment_Position_RefID = reader.GetGuid(2);
					//3:Parameter IsNotePrintedOnDeliveryPaper of type bool
					resultItem.IsNotePrintedOnDeliveryPaper = reader.GetBoolean(3);
					//4:Parameter Title of type String
					resultItem.Title = reader.GetString(4);
					//5:Parameter Comment of type String
					resultItem.Comment = reader.GetString(5);
					//6:Parameter NotePublishDate of type DateTime
					resultItem.NotePublishDate = reader.GetDate(6);
					//7:Parameter SequenceOrderNumber of type String
					resultItem.SequenceOrderNumber = reader.GetString(7);
					//8:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(8);
					//9:Parameter CreatedBy of type String
					resultItem.CreatedBy = reader.GetString(9);
					//10:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(10);
					//11:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(11);
					//12:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShipmentNotes_for_ShipmentHeaderID",ex);
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
		public static FR_L2SH_GSNfSH_1654_Array Invoke(string ConnectionString,P_L2SH_GSNfSH_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2SH_GSNfSH_1654_Array Invoke(DbConnection Connection,P_L2SH_GSNfSH_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2SH_GSNfSH_1654_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2SH_GSNfSH_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2SH_GSNfSH_1654_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2SH_GSNfSH_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2SH_GSNfSH_1654_Array functionReturn = new FR_L2SH_GSNfSH_1654_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShipmentNotes_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2SH_GSNfSH_1654_Array : FR_Base
	{
		public L2SH_GSNfSH_1654[] Result	{ get; set; } 
		public FR_L2SH_GSNfSH_1654_Array() : base() {}

		public FR_L2SH_GSNfSH_1654_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2SH_GSNfSH_1654 for attribute P_L2SH_GSNfSH_1654
		[DataContract]
		public class P_L2SH_GSNfSH_1654 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L2SH_GSNfSH_1654 for attribute L2SH_GSNfSH_1654
		[DataContract]
		public class L2SH_GSNfSH_1654 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_NoteID { get; set; } 
			[DataMember]
			public Guid Shipment_Header_RefID { get; set; } 
			[DataMember]
			public Guid Shipment_Position_RefID { get; set; } 
			[DataMember]
			public bool IsNotePrintedOnDeliveryPaper { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public DateTime NotePublishDate { get; set; } 
			[DataMember]
			public String SequenceOrderNumber { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String CreatedBy { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2SH_GSNfSH_1654_Array cls_Get_ShipmentNotes_for_ShipmentHeaderID(,P_L2SH_GSNfSH_1654 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2SH_GSNfSH_1654_Array invocationResult = cls_Get_ShipmentNotes_for_ShipmentHeaderID.Invoke(connectionString,P_L2SH_GSNfSH_1654 Parameter,securityTicket);
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
var parameter = new CL2_Shipment.Atomic.Retrieval.P_L2SH_GSNfSH_1654();
parameter.ShipmentHeaderID = ...;

*/
