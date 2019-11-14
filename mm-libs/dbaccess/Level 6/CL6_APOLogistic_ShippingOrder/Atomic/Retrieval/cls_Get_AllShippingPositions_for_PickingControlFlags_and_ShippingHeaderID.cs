/* 
 * Generated on 6/9/2014 4:51:52 PM
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

namespace CL6_APOLogistic_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_GASPfPCFaSH_1202_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_GASPfPCFaSH_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6SO_GASPfPCFaSH_1202_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShippmentHeaderID", Parameter.ShippmentHeaderID);



			List<L6SO_GASPfPCFaSH_1202> results = new List<L6SO_GASPfPCFaSH_1202>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Number","Product_Name_DictID","Product_Description_DictID","ISOCode","PackageContent_Amount","GlobalPropertyMatchingID","DosageForm_Name_DictID","LOG_SHP_Shipment_HeaderID","LOG_SHP_Shipment_PositionID","QuantityToShip","ProducerName","CMN_BPT_CTM_OrganizationalUnitID","OrganizationalUnit_SimpleName","OrganizationalUnit_Name_DictID" });
				while(reader.Read())
				{
					L6SO_GASPfPCFaSH_1202 resultItem = new L6SO_GASPfPCFaSH_1202();
					//0:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(2);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//3:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(3);
					//4:Parameter PackageContent_Amount of type String
					resultItem.PackageContent_Amount = reader.GetString(4);
					//5:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(5);
					//6:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(6);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//7:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(7);
					//8:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(8);
					//9:Parameter QuantityToShip of type Double
					resultItem.QuantityToShip = reader.GetDouble(9);
					//10:Parameter ProducerName of type String
					resultItem.ProducerName = reader.GetString(10);
					//11:Parameter CMN_BPT_CTM_OrganizationalUnitID of type Guid
					resultItem.CMN_BPT_CTM_OrganizationalUnitID = reader.GetGuid(11);
					//12:Parameter OrganizationalUnit_SimpleName of type String
					resultItem.OrganizationalUnit_SimpleName = reader.GetString(12);
					//13:Parameter OrganizationalUnit_Name of type Dict
					resultItem.OrganizationalUnit_Name = reader.GetDictionary(13);
					resultItem.OrganizationalUnit_Name.SourceTable = "";
					loader.Append(resultItem.OrganizationalUnit_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID",ex);
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
		public static FR_L6SO_GASPfPCFaSH_1202_Array Invoke(string ConnectionString,P_L6SO_GASPfPCFaSH_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_GASPfPCFaSH_1202_Array Invoke(DbConnection Connection,P_L6SO_GASPfPCFaSH_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_GASPfPCFaSH_1202_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_GASPfPCFaSH_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_GASPfPCFaSH_1202_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_GASPfPCFaSH_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_GASPfPCFaSH_1202_Array functionReturn = new FR_L6SO_GASPfPCFaSH_1202_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_GASPfPCFaSH_1202_Array : FR_Base
	{
		public L6SO_GASPfPCFaSH_1202[] Result	{ get; set; } 
		public FR_L6SO_GASPfPCFaSH_1202_Array() : base() {}

		public FR_L6SO_GASPfPCFaSH_1202_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_GASPfPCFaSH_1202 for attribute P_L6SO_GASPfPCFaSH_1202
		[DataContract]
		public class P_L6SO_GASPfPCFaSH_1202 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShippmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SO_GASPfPCFaSH_1202 for attribute L6SO_GASPfPCFaSH_1202
		[DataContract]
		public class L6SO_GASPfPCFaSH_1202 
		{
			//Standard type parameters
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public String PackageContent_Amount { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Double QuantityToShip { get; set; } 
			[DataMember]
			public String ProducerName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnitID { get; set; } 
			[DataMember]
			public String OrganizationalUnit_SimpleName { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SO_GASPfPCFaSH_1202_Array cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID(,P_L6SO_GASPfPCFaSH_1202 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SO_GASPfPCFaSH_1202_Array invocationResult = cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID.Invoke(connectionString,P_L6SO_GASPfPCFaSH_1202 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L6SO_GASPfPCFaSH_1202();
parameter.ShippmentHeaderID = ...;

*/
