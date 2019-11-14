/* 
 * Generated on 3/3/2014 11:24:47 AM
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

namespace CL6_Lucenits_Products.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PD_GPaPOSfT_1702_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PD_GPaPOSfT_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PD_GPaPOSfT_1702_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Products.Atomic.Retrieval.SQL.cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentID", Parameter.TreatmentID);



			List<L6PD_GPaPOSfT_1702> results = new List<L6PD_GPaPOSfT_1702>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Product_Number","Quantity","ExpectedDateOfDelivery","HEC_Patient_Treatment_RefID","HEC_Patient_Treatment_RequiredProductID","PharmacyName","HEC_PharmacyID","HEC_ProductID","Recepie","BoundTo_ProcurementOrderPosition_RefID" });
				while(reader.Read())
				{
					L6PD_GPaPOSfT_1702 resultItem = new L6PD_GPaPOSfT_1702();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(2);
					//3:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(3);
					//4:Parameter ExpectedDateOfDelivery of type DateTime
					resultItem.ExpectedDateOfDelivery = reader.GetDate(4);
					//5:Parameter HEC_Patient_Treatment_RefID of type Guid
					resultItem.HEC_Patient_Treatment_RefID = reader.GetGuid(5);
					//6:Parameter HEC_Patient_Treatment_RequiredProductID of type Guid
					resultItem.HEC_Patient_Treatment_RequiredProductID = reader.GetGuid(6);
					//7:Parameter PharmacyName of type String
					resultItem.PharmacyName = reader.GetString(7);
					//8:Parameter HEC_PharmacyID of type Guid
					resultItem.HEC_PharmacyID = reader.GetGuid(8);
					//9:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(9);
					//10:Parameter Recepie of type String
					resultItem.Recepie = reader.GetString(10);
					//11:Parameter BoundTo_ProcurementOrderPosition_RefID of type Guid
					resultItem.BoundTo_ProcurementOrderPosition_RefID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID",ex);
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
		public static FR_L6PD_GPaPOSfT_1702_Array Invoke(string ConnectionString,P_L6PD_GPaPOSfT_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PD_GPaPOSfT_1702_Array Invoke(DbConnection Connection,P_L6PD_GPaPOSfT_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PD_GPaPOSfT_1702_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PD_GPaPOSfT_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PD_GPaPOSfT_1702_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PD_GPaPOSfT_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PD_GPaPOSfT_1702_Array functionReturn = new FR_L6PD_GPaPOSfT_1702_Array();
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

				throw new Exception("Exception occured in method cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PD_GPaPOSfT_1702_Array : FR_Base
	{
		public L6PD_GPaPOSfT_1702[] Result	{ get; set; } 
		public FR_L6PD_GPaPOSfT_1702_Array() : base() {}

		public FR_L6PD_GPaPOSfT_1702_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PD_GPaPOSfT_1702 for attribute P_L6PD_GPaPOSfT_1702
		[DataContract]
		public class P_L6PD_GPaPOSfT_1702 
		{
			//Standard type parameters
			[DataMember]
			public Guid TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L6PD_GPaPOSfT_1702 for attribute L6PD_GPaPOSfT_1702
		[DataContract]
		public class L6PD_GPaPOSfT_1702 
		{
			[DataMember]
			public L6PD_GPaPOSfT_1702_OrderIn[] OrderIn { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public DateTime ExpectedDateOfDelivery { get; set; } 
			[DataMember]
			public Guid HEC_Patient_Treatment_RefID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_Treatment_RequiredProductID { get; set; } 
			[DataMember]
			public String PharmacyName { get; set; } 
			[DataMember]
			public Guid HEC_PharmacyID { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public String Recepie { get; set; } 
			[DataMember]
			public Guid BoundTo_ProcurementOrderPosition_RefID { get; set; } 

		}
		#endregion
		#region SClass L6PD_GPaPOSfT_1702_OrderIn for attribute OrderIn
		[DataContract]
		public class L6PD_GPaPOSfT_1702_OrderIn 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_StatusID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp1 { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public String Status_Code { get; set; } 
			[DataMember]
			public Guid GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public String Position_RequestedDateOfDelivery { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_PositionID { get; set; } 
			[DataMember]
			public DateTime ProcurementOrder_Date { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PD_GPaPOSfT_1702_Array cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID(,P_L6PD_GPaPOSfT_1702 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PD_GPaPOSfT_1702_Array invocationResult = cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID.Invoke(connectionString,P_L6PD_GPaPOSfT_1702 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Products.Atomic.Retrieval.P_L6PD_GPaPOSfT_1702();
parameter.TreatmentID = ...;

*/
