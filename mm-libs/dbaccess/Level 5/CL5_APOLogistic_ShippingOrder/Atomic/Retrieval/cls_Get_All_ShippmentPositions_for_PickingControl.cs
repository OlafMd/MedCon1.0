/* 
 * Generated on 7/28/2014 4:57:02 PM
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

namespace CL5_APOLogistic_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_ShippmentPositions_for_PickingControl.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_ShippmentPositions_for_PickingControl
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GASPfPC_1725_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GASPfPC_1725 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SO_GASPfPC_1725_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_All_ShippmentPositions_for_PickingControl.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShippmentHeaderID", Parameter.ShippmentHeaderID);



			List<L5SO_GASPfPC_1725> results = new List<L5SO_GASPfPC_1725>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","LOG_SHP_Shipment_PositionID","QuantityToShip","OrganizationalUnit_SimpleName","OrganizationalUnit_Name_DictID","CMN_PRO_Product_RefID","CMN_BPT_CTM_OrganizationalUnitID","IsReadyForPicking","CustomerOrder_Number","InternalOrganizationalUnitSimpleName","CompanyName_Line1" });
				while(reader.Read())
				{
					L5SO_GASPfPC_1725 resultItem = new L5SO_GASPfPC_1725();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(1);
					//2:Parameter QuantityToShip of type Double
					resultItem.QuantityToShip = reader.GetDouble(2);
					//3:Parameter OrganizationalUnit_SimpleName of type String
					resultItem.OrganizationalUnit_SimpleName = reader.GetString(3);
					//4:Parameter OrganizationalUnit_Name of type Dict
					resultItem.OrganizationalUnit_Name = reader.GetDictionary(4);
					resultItem.OrganizationalUnit_Name.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Name);
					//5:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(5);
					//6:Parameter CMN_BPT_CTM_OrganizationalUnitID of type Guid
					resultItem.CMN_BPT_CTM_OrganizationalUnitID = reader.GetGuid(6);
					//7:Parameter IsReadyForPicking of type bool
					resultItem.IsReadyForPicking = reader.GetBoolean(7);
					//8:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(8);
					//9:Parameter InternalOrganizationalUnitSimpleName of type String
					resultItem.InternalOrganizationalUnitSimpleName = reader.GetString(9);
					//10:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_ShippmentPositions_for_PickingControl",ex);
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
		public static FR_L5SO_GASPfPC_1725_Array Invoke(string ConnectionString,P_L5SO_GASPfPC_1725 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GASPfPC_1725_Array Invoke(DbConnection Connection,P_L5SO_GASPfPC_1725 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GASPfPC_1725_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GASPfPC_1725 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GASPfPC_1725_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GASPfPC_1725 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GASPfPC_1725_Array functionReturn = new FR_L5SO_GASPfPC_1725_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_ShippmentPositions_for_PickingControl",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GASPfPC_1725_Array : FR_Base
	{
		public L5SO_GASPfPC_1725[] Result	{ get; set; } 
		public FR_L5SO_GASPfPC_1725_Array() : base() {}

		public FR_L5SO_GASPfPC_1725_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GASPfPC_1725 for attribute P_L5SO_GASPfPC_1725
		[DataContract]
		public class P_L5SO_GASPfPC_1725 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShippmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_GASPfPC_1725 for attribute L5SO_GASPfPC_1725
		[DataContract]
		public class L5SO_GASPfPC_1725 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Double QuantityToShip { get; set; } 
			[DataMember]
			public String OrganizationalUnit_SimpleName { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Name { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnitID { get; set; } 
			[DataMember]
			public bool IsReadyForPicking { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitSimpleName { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GASPfPC_1725_Array cls_Get_All_ShippmentPositions_for_PickingControl(,P_L5SO_GASPfPC_1725 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GASPfPC_1725_Array invocationResult = cls_Get_All_ShippmentPositions_for_PickingControl.Invoke(connectionString,P_L5SO_GASPfPC_1725 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L5SO_GASPfPC_1725();
parameter.ShippmentHeaderID = ...;

*/
