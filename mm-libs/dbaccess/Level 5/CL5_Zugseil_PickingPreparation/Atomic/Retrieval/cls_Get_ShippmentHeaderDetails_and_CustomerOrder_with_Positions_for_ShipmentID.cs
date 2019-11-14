/* 
 * Generated on 3/17/2015 11:27:05 AM
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

namespace CL5_Zugseil_PickingPreparation.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PP_GSHDaCOwPfS_1125_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PP_GSHDaCOwPfS_1125 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PP_GSHDaCOwPfS_1125_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_PickingPreparation.Atomic.Retrieval.SQL.cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);



			List<L5PP_GSHDaCOwPfS_1125> results = new List<L5PP_GSHDaCOwPfS_1125>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","ShipmentHeader_Number","LOG_SHP_Shipment_PositionID","CMN_PRO_ProductID","Product_Name_DictID","Product_Number","CMN_PRO_Product_VariantID","VariantName_DictID","IsShippingAddress","IsBillingAddress","IsSpecialAddress","IsDefault","CMN_AddressID","Street_Name","Street_Number","City_Name","City_PostalCode","Country_Name","Country_ISOCode","ShipmentCreationDate","Position_Quantity","ORD_CUO_CustomerOrder_PositionID","ORD_CUO_CustomerOrder_HeaderID","CustomerOrder_Number","CustomerOrder_Date","DisplayName" });
				while(reader.Read())
				{
					L5PP_GSHDaCOwPfS_1125 resultItem = new L5PP_GSHDaCOwPfS_1125();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(1);
					//2:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(2);
					//3:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(3);
					//4:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(4);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//5:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(5);
					//6:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(6);
					//7:Parameter VariantName of type Dict
					resultItem.VariantName = reader.GetDictionary(7);
					resultItem.VariantName.SourceTable = "cmn_pro_product_variants";
					loader.Append(resultItem.VariantName);
					//8:Parameter IsShippingAddress of type bool
					resultItem.IsShippingAddress = reader.GetBoolean(8);
					//9:Parameter IsBillingAddress of type bool
					resultItem.IsBillingAddress = reader.GetBoolean(9);
					//10:Parameter IsSpecialAddress of type bool
					resultItem.IsSpecialAddress = reader.GetBoolean(10);
					//11:Parameter IsDefault of type bool
					resultItem.IsDefault = reader.GetBoolean(11);
					//12:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(12);
					//13:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(13);
					//14:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(14);
					//15:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(15);
					//16:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(16);
					//17:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(17);
					//18:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(18);
					//19:Parameter ShipmentCreationDate of type DateTime
					resultItem.ShipmentCreationDate = reader.GetDate(19);
					//20:Parameter Position_Quantity of type String
					resultItem.Position_Quantity = reader.GetString(20);
					//21:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(21);
					//22:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(22);
					//23:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(23);
					//24:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(24);
					//25:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(25);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID",ex);
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
		public static FR_L5PP_GSHDaCOwPfS_1125_Array Invoke(string ConnectionString,P_L5PP_GSHDaCOwPfS_1125 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHDaCOwPfS_1125_Array Invoke(DbConnection Connection,P_L5PP_GSHDaCOwPfS_1125 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHDaCOwPfS_1125_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PP_GSHDaCOwPfS_1125 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PP_GSHDaCOwPfS_1125_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PP_GSHDaCOwPfS_1125 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PP_GSHDaCOwPfS_1125_Array functionReturn = new FR_L5PP_GSHDaCOwPfS_1125_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PP_GSHDaCOwPfS_1125_Array : FR_Base
	{
		public L5PP_GSHDaCOwPfS_1125[] Result	{ get; set; } 
		public FR_L5PP_GSHDaCOwPfS_1125_Array() : base() {}

		public FR_L5PP_GSHDaCOwPfS_1125_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PP_GSHDaCOwPfS_1125 for attribute P_L5PP_GSHDaCOwPfS_1125
		[DataContract]
		public class P_L5PP_GSHDaCOwPfS_1125 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5PP_GSHDaCOwPfS_1125 for attribute L5PP_GSHDaCOwPfS_1125
		[DataContract]
		public class L5PP_GSHDaCOwPfS_1125 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 
			[DataMember]
			public bool IsShippingAddress { get; set; } 
			[DataMember]
			public bool IsBillingAddress { get; set; } 
			[DataMember]
			public bool IsSpecialAddress { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public DateTime ShipmentCreationDate { get; set; } 
			[DataMember]
			public String Position_Quantity { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PP_GSHDaCOwPfS_1125_Array cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID(,P_L5PP_GSHDaCOwPfS_1125 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PP_GSHDaCOwPfS_1125_Array invocationResult = cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID.Invoke(connectionString,P_L5PP_GSHDaCOwPfS_1125 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_PickingPreparation.Atomic.Retrieval.P_L5PP_GSHDaCOwPfS_1125();
parameter.ShipmentHeaderID = ...;

*/
