/* 
 * Generated on 6/18/2014 12:19:57 PM
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

namespace CL5_APOBilling_Dunning.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DunningDetails_for_BillHeaderList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DunningDetails_for_BillHeaderList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GDDfBHL_1117_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GDDfBHL_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BD_GDDfBHL_1117_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Dunning.Atomic.Retrieval.SQL.cls_Get_DunningDetails_for_BillHeaderList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@BillHeaderID_List"," IN $$BillHeaderID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$BillHeaderID_List$",Parameter.BillHeaderID_List);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DunningDateFrom", Parameter.DunningDateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DunningDateTo", Parameter.DunningDateTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillDunningStatusGlobalProperty", Parameter.BillDunningStatusGlobalProperty);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsReminded", Parameter.IsReminded);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DunningLevelID", Parameter.DunningLevelID);



			List<L5BD_GDDfBHL_1117> results = new List<L5BD_GDDfBHL_1117>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_DUN_DunningProcess_MemberBillID","BIL_BillHeader_RefID","ApplicableProcessDunningFees","CurrentUnpaidBillFraction","ACC_DUN_DunningProcessID","ACC_DUN_Dunning_ModelID","IsDunningProcessClosed","IsCurrentStep","IsSentToCustomer","ACC_DUN_DunningProcess_HistoryID","DunnedAmount_Total","ACC_DUN_Dunning_LevelID","DunningProcessClosedAt_Date","DunningProcessClosedBy_BusinessParticipnant_RefID","Default_DunningFee","ReachesNextDunningLevelAtDate","OrderSequence","DunningFee","GlobalPropertyMatchingID","DunningLevelName_DictID" });
				while(reader.Read())
				{
					L5BD_GDDfBHL_1117 resultItem = new L5BD_GDDfBHL_1117();
					//0:Parameter ACC_DUN_DunningProcess_MemberBillID of type Guid
					resultItem.ACC_DUN_DunningProcess_MemberBillID = reader.GetGuid(0);
					//1:Parameter BIL_BillHeader_RefID of type Guid
					resultItem.BIL_BillHeader_RefID = reader.GetGuid(1);
					//2:Parameter ApplicableProcessDunningFees of type String
					resultItem.ApplicableProcessDunningFees = reader.GetString(2);
					//3:Parameter CurrentUnpaidBillFraction of type String
					resultItem.CurrentUnpaidBillFraction = reader.GetString(3);
					//4:Parameter ACC_DUN_DunningProcessID of type Guid
					resultItem.ACC_DUN_DunningProcessID = reader.GetGuid(4);
					//5:Parameter ACC_DUN_Dunning_ModelID of type Guid
					resultItem.ACC_DUN_Dunning_ModelID = reader.GetGuid(5);
					//6:Parameter IsDunningProcessClosed of type Boolean
					resultItem.IsDunningProcessClosed = reader.GetBoolean(6);
					//7:Parameter IsCurrentStep of type Boolean
					resultItem.IsCurrentStep = reader.GetBoolean(7);
					//8:Parameter IsSentToCustomer of type Boolean
					resultItem.IsSentToCustomer = reader.GetBoolean(8);
					//9:Parameter ACC_DUN_DunningProcess_HistoryID of type Guid
					resultItem.ACC_DUN_DunningProcess_HistoryID = reader.GetGuid(9);
					//10:Parameter DunnedAmount_Total of type Double
					resultItem.DunnedAmount_Total = reader.GetDouble(10);
					//11:Parameter ACC_DUN_Dunning_LevelID of type Guid
					resultItem.ACC_DUN_Dunning_LevelID = reader.GetGuid(11);
					//12:Parameter DunningProcessClosedAt_Date of type DateTime
					resultItem.DunningProcessClosedAt_Date = reader.GetDate(12);
					//13:Parameter DunningProcessClosedBy_BusinessParticipnant_RefID of type Guid
					resultItem.DunningProcessClosedBy_BusinessParticipnant_RefID = reader.GetGuid(13);
					//14:Parameter Default_DunningFee of type Decimal
					resultItem.Default_DunningFee = reader.GetDecimal(14);
					//15:Parameter ReachesNextDunningLevelAtDate of type DateTime
					resultItem.ReachesNextDunningLevelAtDate = reader.GetDate(15);
					//16:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(16);
					//17:Parameter DunningFee of type Decimal
					resultItem.DunningFee = reader.GetDecimal(17);
					//18:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(18);
					//19:Parameter DunningLevelName_DictID of type Dict
					resultItem.DunningLevelName_DictID = reader.GetDictionary(19);
					resultItem.DunningLevelName_DictID.SourceTable = "acc_dun_dunning_levels";
					loader.Append(resultItem.DunningLevelName_DictID);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DunningDetails_for_BillHeaderList",ex);
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
		public static FR_L5BD_GDDfBHL_1117_Array Invoke(string ConnectionString,P_L5BD_GDDfBHL_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GDDfBHL_1117_Array Invoke(DbConnection Connection,P_L5BD_GDDfBHL_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GDDfBHL_1117_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GDDfBHL_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GDDfBHL_1117_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GDDfBHL_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GDDfBHL_1117_Array functionReturn = new FR_L5BD_GDDfBHL_1117_Array();
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

				throw new Exception("Exception occured in method cls_Get_DunningDetails_for_BillHeaderList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GDDfBHL_1117_Array : FR_Base
	{
		public L5BD_GDDfBHL_1117[] Result	{ get; set; } 
		public FR_L5BD_GDDfBHL_1117_Array() : base() {}

		public FR_L5BD_GDDfBHL_1117_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GDDfBHL_1117 for attribute P_L5BD_GDDfBHL_1117
		[DataContract]
		public class P_L5BD_GDDfBHL_1117 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] BillHeaderID_List { get; set; } 
			[DataMember]
			public DateTime? DunningDateFrom { get; set; } 
			[DataMember]
			public DateTime? DunningDateTo { get; set; } 
			[DataMember]
			public String BillDunningStatusGlobalProperty { get; set; } 
			[DataMember]
			public Boolean? IsReminded { get; set; } 
			[DataMember]
			public Guid? DunningLevelID { get; set; } 

		}
		#endregion
		#region SClass L5BD_GDDfBHL_1117 for attribute L5BD_GDDfBHL_1117
		[DataContract]
		public class L5BD_GDDfBHL_1117 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_DUN_DunningProcess_MemberBillID { get; set; } 
			[DataMember]
			public Guid BIL_BillHeader_RefID { get; set; } 
			[DataMember]
			public String ApplicableProcessDunningFees { get; set; } 
			[DataMember]
			public String CurrentUnpaidBillFraction { get; set; } 
			[DataMember]
			public Guid ACC_DUN_DunningProcessID { get; set; } 
			[DataMember]
			public Guid ACC_DUN_Dunning_ModelID { get; set; } 
			[DataMember]
			public Boolean IsDunningProcessClosed { get; set; } 
			[DataMember]
			public Boolean IsCurrentStep { get; set; } 
			[DataMember]
			public Boolean IsSentToCustomer { get; set; } 
			[DataMember]
			public Guid ACC_DUN_DunningProcess_HistoryID { get; set; } 
			[DataMember]
			public Double DunnedAmount_Total { get; set; } 
			[DataMember]
			public Guid ACC_DUN_Dunning_LevelID { get; set; } 
			[DataMember]
			public DateTime DunningProcessClosedAt_Date { get; set; } 
			[DataMember]
			public Guid DunningProcessClosedBy_BusinessParticipnant_RefID { get; set; } 
			[DataMember]
			public Decimal Default_DunningFee { get; set; } 
			[DataMember]
			public DateTime ReachesNextDunningLevelAtDate { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public Decimal DunningFee { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict DunningLevelName_DictID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_GDDfBHL_1117_Array cls_Get_DunningDetails_for_BillHeaderList(,P_L5BD_GDDfBHL_1117 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BD_GDDfBHL_1117_Array invocationResult = cls_Get_DunningDetails_for_BillHeaderList.Invoke(connectionString,P_L5BD_GDDfBHL_1117 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Dunning.Atomic.Retrieval.P_L5BD_GDDfBHL_1117();
parameter.BillHeaderID_List = ...;
parameter.DunningDateFrom = ...;
parameter.DunningDateTo = ...;
parameter.BillDunningStatusGlobalProperty = ...;
parameter.IsReminded = ...;
parameter.DunningLevelID = ...;

*/
