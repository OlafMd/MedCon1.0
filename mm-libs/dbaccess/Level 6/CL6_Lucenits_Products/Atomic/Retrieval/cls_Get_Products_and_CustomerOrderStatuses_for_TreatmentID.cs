/* 
 * Generated on 3/26/2014 11:34:19 AM
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
    /// var result = cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PD_GPaCOSfT_1120_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PD_GPaCOSfT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PD_GPaCOSfT_1120_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Products.Atomic.Retrieval.SQL.cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentID", Parameter.TreatmentID);



			List<L6PD_GPaCOSfT_1120_raw> results = new List<L6PD_GPaCOSfT_1120_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_Treatment_RequiredProductID","CMN_PRO_ProductID","Product_Name_DictID","Product_Number","Quantity","ExpectedDateOfDelivery","HEC_Patient_Treatment_RefID","ORD_CUO_CustomerOrder_PositionID","Position_RequestedDateOfDelivery","HEC_PharmacyID","PharmacyName","HEC_ProductID","Recepie","ORD_CUO_CustomerOrder_StatusID","Status_Name_DictID","Status_Code","GlobalPropertyMatchingID","Creation_Timestamp","OrderNumber","Current_CustomerOrderStatus_RefID" });
				while(reader.Read())
				{
					L6PD_GPaCOSfT_1120_raw resultItem = new L6PD_GPaCOSfT_1120_raw();
					//0:Parameter HEC_Patient_Treatment_RequiredProductID of type Guid
					resultItem.HEC_Patient_Treatment_RequiredProductID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(1);
					//2:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(2);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//3:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(3);
					//4:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(4);
					//5:Parameter ExpectedDateOfDelivery of type DateTime
					resultItem.ExpectedDateOfDelivery = reader.GetDate(5);
					//6:Parameter HEC_Patient_Treatment_RefID of type Guid
					resultItem.HEC_Patient_Treatment_RefID = reader.GetGuid(6);
					//7:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(7);
					//8:Parameter Position_RequestedDateOfDelivery of type String
					resultItem.Position_RequestedDateOfDelivery = reader.GetString(8);
					//9:Parameter HEC_PharmacyID of type Guid
					resultItem.HEC_PharmacyID = reader.GetGuid(9);
					//10:Parameter PharmacyName of type String
					resultItem.PharmacyName = reader.GetString(10);
					//11:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(11);
					//12:Parameter Recepie of type String
					resultItem.Recepie = reader.GetString(12);
					//13:Parameter ORD_CUO_CustomerOrder_StatusID of type Guid
					resultItem.ORD_CUO_CustomerOrder_StatusID = reader.GetGuid(13);
					//14:Parameter Status_Name of type Dict
					resultItem.Status_Name = reader.GetDictionary(14);
					resultItem.Status_Name.SourceTable = "ord_cuo_customerorder_statuses";
					loader.Append(resultItem.Status_Name);
					//15:Parameter Status_Code of type String
					resultItem.Status_Code = reader.GetString(15);
					//16:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(16);
					//17:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(17);
					//18:Parameter OrderNumber of type String
					resultItem.OrderNumber = reader.GetString(18);
					//19:Parameter Current_CustomerOrderStatus_RefID of type Guid
					resultItem.Current_CustomerOrderStatus_RefID = reader.GetGuid(19);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6PD_GPaCOSfT_1120_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PD_GPaCOSfT_1120_Array Invoke(string ConnectionString,P_L6PD_GPaCOSfT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PD_GPaCOSfT_1120_Array Invoke(DbConnection Connection,P_L6PD_GPaCOSfT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PD_GPaCOSfT_1120_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PD_GPaCOSfT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PD_GPaCOSfT_1120_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PD_GPaCOSfT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PD_GPaCOSfT_1120_Array functionReturn = new FR_L6PD_GPaCOSfT_1120_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6PD_GPaCOSfT_1120_raw 
	{
		public Guid HEC_Patient_Treatment_RequiredProductID; 
		public Guid CMN_PRO_ProductID; 
		public Dict Product_Name; 
		public String Product_Number; 
		public double Quantity; 
		public DateTime ExpectedDateOfDelivery; 
		public Guid HEC_Patient_Treatment_RefID; 
		public Guid ORD_CUO_CustomerOrder_PositionID; 
		public String Position_RequestedDateOfDelivery; 
		public Guid HEC_PharmacyID; 
		public String PharmacyName; 
		public Guid HEC_ProductID; 
		public String Recepie; 
		public Guid ORD_CUO_CustomerOrder_StatusID; 
		public Dict Status_Name; 
		public String Status_Code; 
		public String GlobalPropertyMatchingID; 
		public DateTime Creation_Timestamp; 
		public String OrderNumber; 
		public Guid Current_CustomerOrderStatus_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6PD_GPaCOSfT_1120[] Convert(List<L6PD_GPaCOSfT_1120_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6PD_GPaCOSfT_1120 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_Treatment_RequiredProductID)).ToArray()
	group el_L6PD_GPaCOSfT_1120 by new 
	{ 
		el_L6PD_GPaCOSfT_1120.HEC_Patient_Treatment_RequiredProductID,

	}
	into gfunct_L6PD_GPaCOSfT_1120
	select new L6PD_GPaCOSfT_1120
	{     
		HEC_Patient_Treatment_RequiredProductID = gfunct_L6PD_GPaCOSfT_1120.Key.HEC_Patient_Treatment_RequiredProductID ,
		CMN_PRO_ProductID = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().CMN_PRO_ProductID ,
		Product_Name = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().Product_Name ,
		Product_Number = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().Product_Number ,
		Quantity = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().Quantity ,
		ExpectedDateOfDelivery = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().ExpectedDateOfDelivery ,
		HEC_Patient_Treatment_RefID = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().HEC_Patient_Treatment_RefID ,
		ORD_CUO_CustomerOrder_PositionID = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().ORD_CUO_CustomerOrder_PositionID ,
		Position_RequestedDateOfDelivery = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().Position_RequestedDateOfDelivery ,
		HEC_PharmacyID = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().HEC_PharmacyID ,
		PharmacyName = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().PharmacyName ,
		HEC_ProductID = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().HEC_ProductID ,
		Recepie = gfunct_L6PD_GPaCOSfT_1120.FirstOrDefault().Recepie ,

		Statuses = 
		(
			from el_Statuses in gfunct_L6PD_GPaCOSfT_1120.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_StatusID)).ToArray()
			group el_Statuses by new 
			{ 
				el_Statuses.ORD_CUO_CustomerOrder_StatusID,

			}
			into gfunct_Statuses
			select new L6PD_GPaCOSfT_1120a
			{     
				ORD_CUO_CustomerOrder_StatusID = gfunct_Statuses.Key.ORD_CUO_CustomerOrder_StatusID ,
				Status_Name = gfunct_Statuses.FirstOrDefault().Status_Name ,
				Status_Code = gfunct_Statuses.FirstOrDefault().Status_Code ,
				GlobalPropertyMatchingID = gfunct_Statuses.FirstOrDefault().GlobalPropertyMatchingID ,
				Creation_Timestamp = gfunct_Statuses.FirstOrDefault().Creation_Timestamp ,
				OrderNumber = gfunct_Statuses.FirstOrDefault().OrderNumber ,
				Current_CustomerOrderStatus_RefID = gfunct_Statuses.FirstOrDefault().Current_CustomerOrderStatus_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6PD_GPaCOSfT_1120_Array : FR_Base
	{
		public L6PD_GPaCOSfT_1120[] Result	{ get; set; } 
		public FR_L6PD_GPaCOSfT_1120_Array() : base() {}

		public FR_L6PD_GPaCOSfT_1120_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PD_GPaCOSfT_1120 for attribute P_L6PD_GPaCOSfT_1120
		[DataContract]
		public class P_L6PD_GPaCOSfT_1120 
		{
			//Standard type parameters
			[DataMember]
			public Guid TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L6PD_GPaCOSfT_1120 for attribute L6PD_GPaCOSfT_1120
		[DataContract]
		public class L6PD_GPaCOSfT_1120 
		{
			[DataMember]
			public L6PD_GPaCOSfT_1120a[] Statuses { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Treatment_RequiredProductID { get; set; } 
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
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public String Position_RequestedDateOfDelivery { get; set; } 
			[DataMember]
			public Guid HEC_PharmacyID { get; set; } 
			[DataMember]
			public String PharmacyName { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public String Recepie { get; set; } 

		}
		#endregion
		#region SClass L6PD_GPaCOSfT_1120a for attribute Statuses
		[DataContract]
		public class L6PD_GPaCOSfT_1120a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_StatusID { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public String Status_Code { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String OrderNumber { get; set; } 
			[DataMember]
			public Guid Current_CustomerOrderStatus_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PD_GPaCOSfT_1120_Array cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID(,P_L6PD_GPaCOSfT_1120 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PD_GPaCOSfT_1120_Array invocationResult = cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID.Invoke(connectionString,P_L6PD_GPaCOSfT_1120 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Products.Atomic.Retrieval.P_L6PD_GPaCOSfT_1120();
parameter.TreatmentID = ...;

*/
