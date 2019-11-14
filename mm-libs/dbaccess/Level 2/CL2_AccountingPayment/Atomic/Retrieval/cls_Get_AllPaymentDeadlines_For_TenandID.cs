/* 
 * Generated on 10/21/2013 6:16:43 PM
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

namespace CL2_AccountingPayment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllPaymentDeadlines_For_TenandID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPaymentDeadlines_For_TenandID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_AP_GAPDfT_1605_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_AP_GAPDfT_1605_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_AccountingPayment.Atomic.Retrieval.SQL.cls_Get_AllPaymentDeadlines_For_TenandID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2_AP_GAPDfT_1605_raw> results = new List<L2_AP_GAPDfT_1605_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PaymentCondition_Name_DictID","ACC_PAY_ConditionID","MaximumPaymentTreshold_InDays","ACC_PAY_Condition_DetailID","SequenceNumber","DiscountPercentage","DateInterval_To","DateInterval_From" });
				while(reader.Read())
				{
					L2_AP_GAPDfT_1605_raw resultItem = new L2_AP_GAPDfT_1605_raw();
					//0:Parameter PaymentCondition_Name of type Dict
					resultItem.PaymentCondition_Name = reader.GetDictionary(0);
					resultItem.PaymentCondition_Name.SourceTable = "acc_pay_conditions";
					loader.Append(resultItem.PaymentCondition_Name);
					//1:Parameter ACC_PAY_ConditionID of type Guid
					resultItem.ACC_PAY_ConditionID = reader.GetGuid(1);
					//2:Parameter MaximumPaymentTreshold_InDays of type int
					resultItem.MaximumPaymentTreshold_InDays = reader.GetInteger(2);
					//3:Parameter ACC_PAY_Condition_DetailID of type Guid
					resultItem.ACC_PAY_Condition_DetailID = reader.GetGuid(3);
					//4:Parameter SequenceNumber of type int
					resultItem.SequenceNumber = reader.GetInteger(4);
					//5:Parameter DiscountPercentage of type double
					resultItem.DiscountPercentage = reader.GetDouble(5);
					//6:Parameter DateInterval_To of type int
					resultItem.DateInterval_To = reader.GetInteger(6);
					//7:Parameter DateInterval_From of type int
					resultItem.DateInterval_From = reader.GetInteger(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllPaymentDeadlines_For_TenandID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L2_AP_GAPDfT_1605_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2_AP_GAPDfT_1605_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_AP_GAPDfT_1605_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_AP_GAPDfT_1605_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_AP_GAPDfT_1605_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_AP_GAPDfT_1605_Array functionReturn = new FR_L2_AP_GAPDfT_1605_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_AllPaymentDeadlines_For_TenandID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L2_AP_GAPDfT_1605_raw 
	{
		public Dict PaymentCondition_Name; 
		public Guid ACC_PAY_ConditionID; 
		public int MaximumPaymentTreshold_InDays; 
		public Guid ACC_PAY_Condition_DetailID; 
		public int SequenceNumber; 
		public double DiscountPercentage; 
		public int DateInterval_To; 
		public int DateInterval_From; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L2_AP_GAPDfT_1605[] Convert(List<L2_AP_GAPDfT_1605_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L2_AP_GAPDfT_1605 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ACC_PAY_ConditionID)).ToArray()
	group el_L2_AP_GAPDfT_1605 by new 
	{ 
		el_L2_AP_GAPDfT_1605.ACC_PAY_ConditionID,

	}
	into gfunct_L2_AP_GAPDfT_1605
	select new L2_AP_GAPDfT_1605
	{     
		PaymentCondition_Name = gfunct_L2_AP_GAPDfT_1605.FirstOrDefault().PaymentCondition_Name ,
		ACC_PAY_ConditionID = gfunct_L2_AP_GAPDfT_1605.Key.ACC_PAY_ConditionID ,
		MaximumPaymentTreshold_InDays = gfunct_L2_AP_GAPDfT_1605.FirstOrDefault().MaximumPaymentTreshold_InDays ,

		Details = 
		(
			from el_Details in gfunct_L2_AP_GAPDfT_1605.Where(element => !EqualsDefaultValue(element.ACC_PAY_Condition_DetailID)).ToArray()
			group el_Details by new 
			{ 
				el_Details.ACC_PAY_Condition_DetailID,

			}
			into gfunct_Details
			select new L2_AP_GAPDfT_1605_Detail
			{     
				ACC_PAY_Condition_DetailID = gfunct_Details.Key.ACC_PAY_Condition_DetailID ,
				SequenceNumber = gfunct_Details.FirstOrDefault().SequenceNumber ,
				DiscountPercentage = gfunct_Details.FirstOrDefault().DiscountPercentage ,
				DateInterval_To = gfunct_Details.FirstOrDefault().DateInterval_To ,
				DateInterval_From = gfunct_Details.FirstOrDefault().DateInterval_From ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L2_AP_GAPDfT_1605_Array : FR_Base
	{
		public L2_AP_GAPDfT_1605[] Result	{ get; set; } 
		public FR_L2_AP_GAPDfT_1605_Array() : base() {}

		public FR_L2_AP_GAPDfT_1605_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2_AP_GAPDfT_1605 for attribute L2_AP_GAPDfT_1605
		[DataContract]
		public class L2_AP_GAPDfT_1605 
		{
			[DataMember]
			public L2_AP_GAPDfT_1605_Detail[] Details { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict PaymentCondition_Name { get; set; } 
			[DataMember]
			public Guid ACC_PAY_ConditionID { get; set; } 
			[DataMember]
			public int MaximumPaymentTreshold_InDays { get; set; } 

		}
		#endregion
		#region SClass L2_AP_GAPDfT_1605_Detail for attribute Details
		[DataContract]
		public class L2_AP_GAPDfT_1605_Detail 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_PAY_Condition_DetailID { get; set; } 
			[DataMember]
			public int SequenceNumber { get; set; } 
			[DataMember]
			public double DiscountPercentage { get; set; } 
			[DataMember]
			public int DateInterval_To { get; set; } 
			[DataMember]
			public int DateInterval_From { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_AP_GAPDfT_1605_Array cls_Get_AllPaymentDeadlines_For_TenandID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_AP_GAPDfT_1605_Array invocationResult = cls_Get_AllPaymentDeadlines_For_TenandID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

