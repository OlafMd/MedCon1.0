/* 
 * Generated on 4/17/2014 10:27:44 AM
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

namespace CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllCustomerOrderPositions_for_Unshipped_ShipmentPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllCustomerOrderPositions_for_Unshipped_ShipmentPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GACOPfUSP_1038_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_GACOPfUSP_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CO_GACOPfUSP_1038_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_AllCustomerOrderPositions_for_Unshipped_ShipmentPositions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrganizationalUnitID", Parameter.OrganizationalUnitID);



			List<L5CO_GACOPfUSP_1038> results = new List<L5CO_GACOPfUSP_1038>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CustomerOrder_Header_RefID","CMN_PRO_Product_RefID","ORD_CUO_CustomerOrder_PositionID","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal" });
				while(reader.Read())
				{
					L5CO_GACOPfUSP_1038 resultItem = new L5CO_GACOPfUSP_1038();
					//0:Parameter CustomerOrder_Header_RefID of type Guid
					resultItem.CustomerOrder_Header_RefID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(1);
					//2:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(2);
					//3:Parameter Position_Quantity of type double
					resultItem.Position_Quantity = reader.GetDouble(3);
					//4:Parameter Position_ValuePerUnit of type decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(4);
					//5:Parameter Position_ValueTotal of type decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllCustomerOrderPositions_for_Unshipped_ShipmentPositions",ex);
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
		public static FR_L5CO_GACOPfUSP_1038_Array Invoke(string ConnectionString,P_L5CO_GACOPfUSP_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GACOPfUSP_1038_Array Invoke(DbConnection Connection,P_L5CO_GACOPfUSP_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GACOPfUSP_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_GACOPfUSP_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GACOPfUSP_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_GACOPfUSP_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GACOPfUSP_1038_Array functionReturn = new FR_L5CO_GACOPfUSP_1038_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllCustomerOrderPositions_for_Unshipped_ShipmentPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GACOPfUSP_1038_Array : FR_Base
	{
		public L5CO_GACOPfUSP_1038[] Result	{ get; set; } 
		public FR_L5CO_GACOPfUSP_1038_Array() : base() {}

		public FR_L5CO_GACOPfUSP_1038_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_GACOPfUSP_1038 for attribute P_L5CO_GACOPfUSP_1038
		[DataContract]
		public class P_L5CO_GACOPfUSP_1038 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid? OrganizationalUnitID { get; set; } 

		}
		#endregion
		#region SClass L5CO_GACOPfUSP_1038 for attribute L5CO_GACOPfUSP_1038
		[DataContract]
		public class L5CO_GACOPfUSP_1038 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrder_Header_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public double Position_Quantity { get; set; } 
			[DataMember]
			public decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public decimal Position_ValueTotal { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GACOPfUSP_1038_Array cls_Get_AllCustomerOrderPositions_for_Unshipped_ShipmentPositions(,P_L5CO_GACOPfUSP_1038 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GACOPfUSP_1038_Array invocationResult = cls_Get_AllCustomerOrderPositions_for_Unshipped_ShipmentPositions.Invoke(connectionString,P_L5CO_GACOPfUSP_1038 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.P_L5CO_GACOPfUSP_1038();
parameter.ShipmentHeaderID = ...;
parameter.OrganizationalUnitID = ...;

*/
