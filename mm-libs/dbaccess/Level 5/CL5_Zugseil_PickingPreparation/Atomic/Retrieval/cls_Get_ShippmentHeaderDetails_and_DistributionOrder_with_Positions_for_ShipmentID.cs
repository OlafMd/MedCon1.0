/* 
 * Generated on 3/13/2015 2:53:31 PM
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
    /// var result = cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PP_GSHDwPfS_1428_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PP_GSHDaDOwPfS_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PP_GSHDwPfS_1428_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_PickingPreparation.Atomic.Retrieval.SQL.cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);



			List<L5PP_GSHDaDOwPfS_1428> results = new List<L5PP_GSHDaDOwPfS_1428>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","ShipmentHeader_Number","LOG_SHP_Shipment_PositionID","CMN_PRO_ProductID","Product_Name_DictID","Product_Number","CMN_PRO_Product_VariantID","VariantName_DictID","Quantity","ORD_DIS_DistributionOrder_PositionID","DistributionOrder_Header_RefID","ORD_DIS_DistributionOrder_HeaderID","DistributionOrderDate","DistributionOrderNumber","CMN_STR_CostCenterID","Name_DictID","CMN_STR_OfficeID","Office_Name_DictID","Office_InternalName","IsShippingAddress","IsBillingAddress","IsSpecialAddress","IsDefault","CMN_AddressID","Street_Name","Street_Number","City_Name","City_PostalCode","Country_Name","Country_ISOCode","ShipmentCreationDate" });
				while(reader.Read())
				{
					L5PP_GSHDaDOwPfS_1428 resultItem = new L5PP_GSHDaDOwPfS_1428();
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
					//8:Parameter Quantity of type String
					resultItem.Quantity = reader.GetString(8);
					//9:Parameter ORD_DIS_DistributionOrder_PositionID of type Guid
					resultItem.ORD_DIS_DistributionOrder_PositionID = reader.GetGuid(9);
					//10:Parameter DistributionOrder_Header_RefID of type Guid
					resultItem.DistributionOrder_Header_RefID = reader.GetGuid(10);
					//11:Parameter ORD_DIS_DistributionOrder_HeaderID of type Guid
					resultItem.ORD_DIS_DistributionOrder_HeaderID = reader.GetGuid(11);
					//12:Parameter DistributionOrderDate of type DateTime
					resultItem.DistributionOrderDate = reader.GetDate(12);
					//13:Parameter DistributionOrderNumber of type String
					resultItem.DistributionOrderNumber = reader.GetString(13);
					//14:Parameter CMN_STR_CostCenterID of type Guid
					resultItem.CMN_STR_CostCenterID = reader.GetGuid(14);
					//15:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(15);
					resultItem.Name.SourceTable = "cmn_str_costcenters";
					loader.Append(resultItem.Name);
					//16:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(16);
					//17:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(17);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//18:Parameter Office_InternalName of type String
					resultItem.Office_InternalName = reader.GetString(18);
					//19:Parameter IsShippingAddress of type bool
					resultItem.IsShippingAddress = reader.GetBoolean(19);
					//20:Parameter IsBillingAddress of type bool
					resultItem.IsBillingAddress = reader.GetBoolean(20);
					//21:Parameter IsSpecialAddress of type bool
					resultItem.IsSpecialAddress = reader.GetBoolean(21);
					//22:Parameter IsDefault of type bool
					resultItem.IsDefault = reader.GetBoolean(22);
					//23:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(23);
					//24:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(24);
					//25:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(25);
					//26:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(26);
					//27:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(27);
					//28:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(28);
					//29:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(29);
					//30:Parameter ShipmentCreationDate of type DateTime
					resultItem.ShipmentCreationDate = reader.GetDate(30);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID",ex);
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
		public static FR_L5PP_GSHDwPfS_1428_Array Invoke(string ConnectionString,P_L5PP_GSHDaDOwPfS_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHDwPfS_1428_Array Invoke(DbConnection Connection,P_L5PP_GSHDaDOwPfS_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHDwPfS_1428_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PP_GSHDaDOwPfS_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PP_GSHDwPfS_1428_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PP_GSHDaDOwPfS_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PP_GSHDwPfS_1428_Array functionReturn = new FR_L5PP_GSHDwPfS_1428_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PP_GSHDwPfS_1428_Array : FR_Base
	{
		public L5PP_GSHDaDOwPfS_1428[] Result	{ get; set; } 
		public FR_L5PP_GSHDwPfS_1428_Array() : base() {}

		public FR_L5PP_GSHDwPfS_1428_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
        #region SClass P_L5PP_GSHDaDOwPfS_1428 for attribute P_L5PP_GSHDaDOwPfS_1428
        [DataContract]
		public class P_L5PP_GSHDaDOwPfS_1428 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
        #region SClass L5PP_GSHDaDOwPfS_1428 for attribute L5PP_GSHDaDOwPfS_1428
        [DataContract]
		public class L5PP_GSHDaDOwPfS_1428 
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
			public String Quantity { get; set; } 
			[DataMember]
			public Guid ORD_DIS_DistributionOrder_PositionID { get; set; } 
			[DataMember]
			public Guid DistributionOrder_Header_RefID { get; set; } 
			[DataMember]
			public Guid ORD_DIS_DistributionOrder_HeaderID { get; set; } 
			[DataMember]
			public DateTime DistributionOrderDate { get; set; } 
			[DataMember]
			public String DistributionOrderNumber { get; set; } 
			[DataMember]
			public Guid CMN_STR_CostCenterID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String Office_InternalName { get; set; } 
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

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PP_GSHDwPfS_1428_Array cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID(,P_L5PP_GSHDwPfS_1428 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PP_GSHDwPfS_1428_Array invocationResult = cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID.Invoke(connectionString,P_L5PP_GSHDwPfS_1428 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_PickingPreparation.Atomic.Retrieval.P_L5PP_GSHDwPfS_1428();
parameter.ShipmentHeaderID = ...;

*/
