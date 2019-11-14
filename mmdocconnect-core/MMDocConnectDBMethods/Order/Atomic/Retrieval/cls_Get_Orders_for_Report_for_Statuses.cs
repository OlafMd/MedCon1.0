/* 
 * Generated on 3/14/2017 11:52:41 AM
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

namespace MMDocConnectDBMethods.Order.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Orders_for_Report_for_Statuses.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Orders_for_Report_for_Statuses
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_OR_GOfRfS_1038_Array Execute(DbConnection Connection,DbTransaction Transaction,P_OR_GOfRfS_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_OR_GOfRfS_1038_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Order.Atomic.Retrieval.SQL.cls_Get_Orders_for_Report_for_Statuses.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@OrderStatuses"," IN $$OrderStatuses$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$OrderStatuses$",Parameter.OrderStatuses);


			List<OR_GOfRfS_1038> results = new List<OR_GOfRfS_1038>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Patient_RefID","StatusCode","CaseID","StatusID","BusinesParticipantWhoCreatedOrder","OrderID","OrderNumber","CaseNumber","DrugName","PZN","DeliveryDate","DeliveryTimeFrom","DeliveryTimeTo","OnlyLabel","ChargesFee","SendInvoiceToPractice","TreatmentDate","DoctorID","OrderCreationTimestamp","CaseCreationDate","OrderComment","HeaderComment","IsDeleted","PharmacyName","PharmacyID" });
				while(reader.Read())
				{
					OR_GOfRfS_1038 resultItem = new OR_GOfRfS_1038();
					//0:Parameter Patient_RefID of type Guid
					resultItem.Patient_RefID = reader.GetGuid(0);
					//1:Parameter StatusCode of type Double
					resultItem.StatusCode = reader.GetDouble(1);
					//2:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(2);
					//3:Parameter StatusID of type Guid
					resultItem.StatusID = reader.GetGuid(3);
					//4:Parameter BusinesParticipantWhoCreatedOrder of type Guid
					resultItem.BusinesParticipantWhoCreatedOrder = reader.GetGuid(4);
					//5:Parameter OrderID of type Guid
					resultItem.OrderID = reader.GetGuid(5);
					//6:Parameter OrderNumber of type String
					resultItem.OrderNumber = reader.GetString(6);
					//7:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(7);
					//8:Parameter DrugName of type String
					resultItem.DrugName = reader.GetString(8);
					//9:Parameter PZN of type String
					resultItem.PZN = reader.GetString(9);
					//10:Parameter DeliveryDate of type DateTime
					resultItem.DeliveryDate = reader.GetDate(10);
					//11:Parameter DeliveryTimeFrom of type DateTime
					resultItem.DeliveryTimeFrom = reader.GetDate(11);
					//12:Parameter DeliveryTimeTo of type DateTime
					resultItem.DeliveryTimeTo = reader.GetDate(12);
					//13:Parameter OnlyLabel of type Boolean
					resultItem.OnlyLabel = reader.GetBoolean(13);
					//14:Parameter ChargesFee of type Boolean
					resultItem.ChargesFee = reader.GetBoolean(14);
					//15:Parameter SendInvoiceToPractice of type Boolean
					resultItem.SendInvoiceToPractice = reader.GetBoolean(15);
					//16:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(16);
					//17:Parameter DoctorID of type Guid
					resultItem.DoctorID = reader.GetGuid(17);
					//18:Parameter OrderCreationTimestamp of type DateTime
					resultItem.OrderCreationTimestamp = reader.GetDate(18);
					//19:Parameter CaseCreationDate of type DateTime
					resultItem.CaseCreationDate = reader.GetDate(19);
					//20:Parameter OrderComment of type String
					resultItem.OrderComment = reader.GetString(20);
					//21:Parameter HeaderComment of type String
					resultItem.HeaderComment = reader.GetString(21);
					//22:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(22);
					//23:Parameter PharmacyName of type String
					resultItem.PharmacyName = reader.GetString(23);
					//24:Parameter PharmacyID of type Guid
					resultItem.PharmacyID = reader.GetGuid(24);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Orders_for_Report_for_Statuses",ex);
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
		public static FR_OR_GOfRfS_1038_Array Invoke(string ConnectionString,P_OR_GOfRfS_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_OR_GOfRfS_1038_Array Invoke(DbConnection Connection,P_OR_GOfRfS_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_OR_GOfRfS_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_OR_GOfRfS_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_OR_GOfRfS_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_OR_GOfRfS_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_OR_GOfRfS_1038_Array functionReturn = new FR_OR_GOfRfS_1038_Array();
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

				throw new Exception("Exception occured in method cls_Get_Orders_for_Report_for_Statuses",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_OR_GOfRfS_1038_Array : FR_Base
	{
		public OR_GOfRfS_1038[] Result	{ get; set; } 
		public FR_OR_GOfRfS_1038_Array() : base() {}

		public FR_OR_GOfRfS_1038_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_OR_GOfRfS_1038 for attribute P_OR_GOfRfS_1038
		[DataContract]
		public class P_OR_GOfRfS_1038 
		{
			//Standard type parameters
			[DataMember]
			public String[] OrderStatuses { get; set; } 

		}
		#endregion
		#region SClass OR_GOfRfS_1038 for attribute OR_GOfRfS_1038
		[DataContract]
		public class OR_GOfRfS_1038 
		{
			//Standard type parameters
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public Double StatusCode { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid StatusID { get; set; } 
			[DataMember]
			public Guid BusinesParticipantWhoCreatedOrder { get; set; } 
			[DataMember]
			public Guid OrderID { get; set; } 
			[DataMember]
			public String OrderNumber { get; set; } 
			[DataMember]
			public String CaseNumber { get; set; } 
			[DataMember]
			public String DrugName { get; set; } 
			[DataMember]
			public String PZN { get; set; } 
			[DataMember]
			public DateTime DeliveryDate { get; set; } 
			[DataMember]
			public DateTime DeliveryTimeFrom { get; set; } 
			[DataMember]
			public DateTime DeliveryTimeTo { get; set; } 
			[DataMember]
			public Boolean OnlyLabel { get; set; } 
			[DataMember]
			public Boolean ChargesFee { get; set; } 
			[DataMember]
			public Boolean SendInvoiceToPractice { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public DateTime OrderCreationTimestamp { get; set; } 
			[DataMember]
			public DateTime CaseCreationDate { get; set; } 
			[DataMember]
			public String OrderComment { get; set; } 
			[DataMember]
			public String HeaderComment { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public String PharmacyName { get; set; } 
			[DataMember]
			public Guid PharmacyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_OR_GOfRfS_1038_Array cls_Get_Orders_for_Report_for_Statuses(,P_OR_GOfRfS_1038 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_OR_GOfRfS_1038_Array invocationResult = cls_Get_Orders_for_Report_for_Statuses.Invoke(connectionString,P_OR_GOfRfS_1038 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Atomic.Retrieval.P_OR_GOfRfS_1038();
parameter.OrderStatuses = ...;

*/
