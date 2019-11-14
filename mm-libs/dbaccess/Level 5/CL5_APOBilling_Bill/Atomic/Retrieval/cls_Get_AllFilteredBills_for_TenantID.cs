/* 
 * Generated on 06.10.2014 11:30:46
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

namespace CL5_APOBilling_Bill.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllFilteredBills_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllFilteredBills_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GAFBfT_1508_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GAFBfT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BL_GAFBfT_1508_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Bill.Atomic.Retrieval.SQL.cls_Get_AllFilteredBills_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentStatusID", Parameter.ShipmentStatusID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillStatusGlobalProperty", Parameter.BillStatusGlobalProperty);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillPaymentTypeID", Parameter.BillPaymentTypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillNumber", Parameter.BillNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Customer_NameOrNumber", Parameter.Customer_NameOrNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeliveryDateFrom", Parameter.DeliveryDateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeliveryDateTo", Parameter.DeliveryDateTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateOnBillFrom", Parameter.DateOnBillFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateOnBillTo", Parameter.DateOnBillTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PaymentDeadlineFrom", Parameter.PaymentDeadlineFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PaymentDeadlineTo", Parameter.PaymentDeadlineTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TotalValueFrom", Parameter.TotalValueFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TotalValueTo", Parameter.TotalValueTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TransactionDateFrom", Parameter.TransactionDateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TransactionDateTo", Parameter.TransactionDateTo);



			List<L5BL_GAFBfT_1508> results = new List<L5BL_GAFBfT_1508>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "NumberOfPositions","BillStatusCreationTime","ShipmentStatusTime","TotalValueBeforeTax","TotalValueIncludingTax","BillStatusGlobalProperty","BillStatus_Name_DictID","BIL_BillHeaderID","BillNumber","DateOnBill","CreatedByName","BillRecipientName","CustomerName","CustomerNumber","BillComment","MaximumPaymentTreshold_InDays","ACC_PAY_ConditionID","ACC_DUN_DunningProcess_MemberBillID","IsFullyPaid" });
				while(reader.Read())
				{
					L5BL_GAFBfT_1508 resultItem = new L5BL_GAFBfT_1508();
					//0:Parameter NumberOfPositions of type int
					resultItem.NumberOfPositions = reader.GetInteger(0);
					//1:Parameter BillStatusCreationTime of type DateTime
					resultItem.BillStatusCreationTime = reader.GetDate(1);
					//2:Parameter ShipmentStatusTime of type DateTime
					resultItem.ShipmentStatusTime = reader.GetDate(2);
					//3:Parameter TotalValueBeforeTax of type double
					resultItem.TotalValueBeforeTax = reader.GetDouble(3);
					//4:Parameter TotalValueIncludingTax of type double
					resultItem.TotalValueIncludingTax = reader.GetDouble(4);
					//5:Parameter BillStatusGlobalProperty of type String
					resultItem.BillStatusGlobalProperty = reader.GetString(5);
					//6:Parameter BillStatus_Name of type Dict
					resultItem.BillStatus_Name = reader.GetDictionary(6);
					resultItem.BillStatus_Name.SourceTable = "bil_billstatuses";
					loader.Append(resultItem.BillStatus_Name);
					//7:Parameter BIL_BillHeaderID of type Guid
					resultItem.BIL_BillHeaderID = reader.GetGuid(7);
					//8:Parameter BillNumber of type String
					resultItem.BillNumber = reader.GetString(8);
					//9:Parameter DateOnBill of type DateTime
					resultItem.DateOnBill = reader.GetDate(9);
					//10:Parameter CreatedByName of type String
					resultItem.CreatedByName = reader.GetString(10);
					//11:Parameter BillRecipientName of type String
					resultItem.BillRecipientName = reader.GetString(11);
					//12:Parameter CustomerName of type String
					resultItem.CustomerName = reader.GetString(12);
					//13:Parameter CustomerNumber of type String
					resultItem.CustomerNumber = reader.GetString(13);
					//14:Parameter BillComment of type String
					resultItem.BillComment = reader.GetString(14);
					//15:Parameter MaximumPaymentTreshold_InDays of type int
					resultItem.MaximumPaymentTreshold_InDays = reader.GetInteger(15);
					//16:Parameter ACC_PAY_ConditionID of type Guid
					resultItem.ACC_PAY_ConditionID = reader.GetGuid(16);
					//17:Parameter ACC_DUN_DunningProcess_MemberBillID of type Guid
					resultItem.ACC_DUN_DunningProcess_MemberBillID = reader.GetGuid(17);
					//18:Parameter IsFullyPaid of type bool
					resultItem.IsFullyPaid = reader.GetBoolean(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllFilteredBills_for_TenantID",ex);
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
		public static FR_L5BL_GAFBfT_1508_Array Invoke(string ConnectionString,P_L5BL_GAFBfT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GAFBfT_1508_Array Invoke(DbConnection Connection,P_L5BL_GAFBfT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GAFBfT_1508_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GAFBfT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GAFBfT_1508_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GAFBfT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GAFBfT_1508_Array functionReturn = new FR_L5BL_GAFBfT_1508_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllFilteredBills_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GAFBfT_1508_Array : FR_Base
	{
		public L5BL_GAFBfT_1508[] Result	{ get; set; } 
		public FR_L5BL_GAFBfT_1508_Array() : base() {}

		public FR_L5BL_GAFBfT_1508_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GAFBfT_1508 for attribute P_L5BL_GAFBfT_1508
		[DataContract]
		public class P_L5BL_GAFBfT_1508 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentStatusID { get; set; } 
			[DataMember]
			public string BillStatusGlobalProperty { get; set; } 
			[DataMember]
			public Guid? BillPaymentTypeID { get; set; } 
			[DataMember]
			public string BillNumber { get; set; } 
			[DataMember]
			public string Customer_NameOrNumber { get; set; } 
			[DataMember]
			public DateTime? DeliveryDateFrom { get; set; } 
			[DataMember]
			public DateTime? DeliveryDateTo { get; set; } 
			[DataMember]
			public DateTime? DateOnBillFrom { get; set; } 
			[DataMember]
			public DateTime? DateOnBillTo { get; set; } 
			[DataMember]
			public DateTime? PaymentDeadlineFrom { get; set; } 
			[DataMember]
			public DateTime? PaymentDeadlineTo { get; set; } 
			[DataMember]
			public double? TotalValueFrom { get; set; } 
			[DataMember]
			public double? TotalValueTo { get; set; } 
			[DataMember]
			public DateTime? TransactionDateFrom { get; set; } 
			[DataMember]
			public DateTime? TransactionDateTo { get; set; } 

		}
		#endregion
		#region SClass L5BL_GAFBfT_1508 for attribute L5BL_GAFBfT_1508
		[DataContract]
		public class L5BL_GAFBfT_1508 
		{
			//Standard type parameters
			[DataMember]
			public int NumberOfPositions { get; set; } 
			[DataMember]
			public DateTime BillStatusCreationTime { get; set; } 
			[DataMember]
			public DateTime ShipmentStatusTime { get; set; } 
			[DataMember]
			public double TotalValueBeforeTax { get; set; } 
			[DataMember]
			public double TotalValueIncludingTax { get; set; } 
			[DataMember]
			public String BillStatusGlobalProperty { get; set; } 
			[DataMember]
			public Dict BillStatus_Name { get; set; } 
			[DataMember]
			public Guid BIL_BillHeaderID { get; set; } 
			[DataMember]
			public String BillNumber { get; set; } 
			[DataMember]
			public DateTime DateOnBill { get; set; } 
			[DataMember]
			public String CreatedByName { get; set; } 
			[DataMember]
			public String BillRecipientName { get; set; } 
			[DataMember]
			public String CustomerName { get; set; } 
			[DataMember]
			public String CustomerNumber { get; set; } 
			[DataMember]
			public String BillComment { get; set; } 
			[DataMember]
			public int MaximumPaymentTreshold_InDays { get; set; } 
			[DataMember]
			public Guid ACC_PAY_ConditionID { get; set; } 
			[DataMember]
			public Guid ACC_DUN_DunningProcess_MemberBillID { get; set; } 
			[DataMember]
			public bool IsFullyPaid { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GAFBfT_1508_Array cls_Get_AllFilteredBills_for_TenantID(,P_L5BL_GAFBfT_1508 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GAFBfT_1508_Array invocationResult = cls_Get_AllFilteredBills_for_TenantID.Invoke(connectionString,P_L5BL_GAFBfT_1508 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Atomic.Retrieval.P_L5BL_GAFBfT_1508();
parameter.ShipmentStatusID = ...;
parameter.BillStatusGlobalProperty = ...;
parameter.BillPaymentTypeID = ...;
parameter.BillNumber = ...;
parameter.Customer_NameOrNumber = ...;
parameter.DeliveryDateFrom = ...;
parameter.DeliveryDateTo = ...;
parameter.DateOnBillFrom = ...;
parameter.DateOnBillTo = ...;
parameter.PaymentDeadlineFrom = ...;
parameter.PaymentDeadlineTo = ...;
parameter.TotalValueFrom = ...;
parameter.TotalValueTo = ...;
parameter.TransactionDateFrom = ...;
parameter.TransactionDateTo = ...;

*/
