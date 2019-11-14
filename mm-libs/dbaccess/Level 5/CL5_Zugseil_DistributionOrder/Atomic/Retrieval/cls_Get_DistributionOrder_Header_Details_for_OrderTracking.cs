/* 
 * Generated on 26.1.2015 14:15:15
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

namespace CL5_Zugseil_DistributionOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DistributionOrder_Header_Details_for_OrderTracking.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DistributionOrder_Header_Details_for_OrderTracking
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GDOHDfOT_1654 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GDOHDfOT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GDOHDfOT_1654();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_DistributionOrder.Atomic.Retrieval.SQL.cls_Get_DistributionOrder_Header_Details_for_OrderTracking.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DistributionOrderHeaderID", Parameter.DistributionOrderHeaderID);



			List<L5DO_GDOHDfOT_1654_raw> results = new List<L5DO_GDOHDfOT_1654_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_DIS_DistributionOrder_HeaderID","DistributionOrderDate","DistributionOrderNumber","IsCanceled","IsPartiallyFullfilled","IsFullyFullfilled","CostCenterName_DictID","OfficeName_DictID","EmployeeName","WarehouseName","CreatedBy_BusinessParticipantID","CreatedBy_BusinessParticipantDisplayName","ORD_DIS_DistributionOrder_PositionID","Quantity","Position_OrdinalNumber","CMN_PRO_ProductID","Product_Name_DictID","Product_Number","CMN_PRO_Product_VariantID","IsStandardProductVariant","VariantName_DictID" });
				while(reader.Read())
				{
					L5DO_GDOHDfOT_1654_raw resultItem = new L5DO_GDOHDfOT_1654_raw();
					//0:Parameter ORD_DIS_DistributionOrder_HeaderID of type Guid
					resultItem.ORD_DIS_DistributionOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter DistributionOrderDate of type DateTime
					resultItem.DistributionOrderDate = reader.GetDate(1);
					//2:Parameter DistributionOrderNumber of type string
					resultItem.DistributionOrderNumber = reader.GetString(2);
					//3:Parameter IsCanceled of type bool
					resultItem.IsCanceled = reader.GetBoolean(3);
					//4:Parameter IsPartiallyFullfilled of type bool
					resultItem.IsPartiallyFullfilled = reader.GetBoolean(4);
					//5:Parameter IsFullyFullfilled of type bool
					resultItem.IsFullyFullfilled = reader.GetBoolean(5);
					//6:Parameter CostCenterName of type Dict
					resultItem.CostCenterName = reader.GetDictionary(6);
					resultItem.CostCenterName.SourceTable = "cmn_str_costcenters";
					loader.Append(resultItem.CostCenterName);
					//7:Parameter OfficeName of type Dict
					resultItem.OfficeName = reader.GetDictionary(7);
					resultItem.OfficeName.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.OfficeName);
					//8:Parameter EmployeeName of type string
					resultItem.EmployeeName = reader.GetString(8);
					//9:Parameter WarehouseName of type string
					resultItem.WarehouseName = reader.GetString(9);
					//10:Parameter CreatedBy_BusinessParticipantID of type Guid
					resultItem.CreatedBy_BusinessParticipantID = reader.GetGuid(10);
					//11:Parameter CreatedBy_BusinessParticipantDisplayName of type string
					resultItem.CreatedBy_BusinessParticipantDisplayName = reader.GetString(11);
					//12:Parameter ORD_DIS_DistributionOrder_PositionID of type Guid
					resultItem.ORD_DIS_DistributionOrder_PositionID = reader.GetGuid(12);
					//13:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(13);
					//14:Parameter Position_OrdinalNumber of type int
					resultItem.Position_OrdinalNumber = reader.GetInteger(14);
					//15:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(15);
					//16:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(16);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//17:Parameter Product_Number of type string
					resultItem.Product_Number = reader.GetString(17);
					//18:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(18);
					//19:Parameter IsStandardProductVariant of type bool
					resultItem.IsStandardProductVariant = reader.GetBoolean(19);
					//20:Parameter VariantName of type Dict
					resultItem.VariantName = reader.GetDictionary(20);
					resultItem.VariantName.SourceTable = "cmn_pro_product_variants";
					loader.Append(resultItem.VariantName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DistributionOrder_Header_Details_for_OrderTracking",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DO_GDOHDfOT_1654_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DO_GDOHDfOT_1654 Invoke(string ConnectionString,P_L5DO_GDOHDfOT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GDOHDfOT_1654 Invoke(DbConnection Connection,P_L5DO_GDOHDfOT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GDOHDfOT_1654 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GDOHDfOT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GDOHDfOT_1654 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GDOHDfOT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GDOHDfOT_1654 functionReturn = new FR_L5DO_GDOHDfOT_1654();
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

				throw new Exception("Exception occured in method cls_Get_DistributionOrder_Header_Details_for_OrderTracking",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DO_GDOHDfOT_1654_raw 
	{
		public Guid ORD_DIS_DistributionOrder_HeaderID; 
		public DateTime DistributionOrderDate; 
		public string DistributionOrderNumber; 
		public bool IsCanceled; 
		public bool IsPartiallyFullfilled; 
		public bool IsFullyFullfilled; 
		public Dict CostCenterName; 
		public Dict OfficeName; 
		public string EmployeeName; 
		public string WarehouseName; 
		public Guid CreatedBy_BusinessParticipantID; 
		public string CreatedBy_BusinessParticipantDisplayName; 
		public Guid ORD_DIS_DistributionOrder_PositionID; 
		public double Quantity; 
		public int Position_OrdinalNumber; 
		public Guid CMN_PRO_ProductID; 
		public Dict Product_Name; 
		public string Product_Number; 
		public Guid CMN_PRO_Product_VariantID; 
		public bool IsStandardProductVariant; 
		public Dict VariantName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DO_GDOHDfOT_1654[] Convert(List<L5DO_GDOHDfOT_1654_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DO_GDOHDfOT_1654 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_DIS_DistributionOrder_HeaderID)).ToArray()
	group el_L5DO_GDOHDfOT_1654 by new 
	{ 
		el_L5DO_GDOHDfOT_1654.ORD_DIS_DistributionOrder_HeaderID,

	}
	into gfunct_L5DO_GDOHDfOT_1654
	select new L5DO_GDOHDfOT_1654
	{     
		ORD_DIS_DistributionOrder_HeaderID = gfunct_L5DO_GDOHDfOT_1654.Key.ORD_DIS_DistributionOrder_HeaderID ,
		DistributionOrderDate = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().DistributionOrderDate ,
		DistributionOrderNumber = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().DistributionOrderNumber ,
		IsCanceled = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().IsCanceled ,
		IsPartiallyFullfilled = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().IsPartiallyFullfilled ,
		IsFullyFullfilled = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().IsFullyFullfilled ,
		CostCenterName = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().CostCenterName ,
		OfficeName = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().OfficeName ,
		EmployeeName = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().EmployeeName ,
		WarehouseName = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().WarehouseName ,
		CreatedBy_BusinessParticipantID = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().CreatedBy_BusinessParticipantID ,
		CreatedBy_BusinessParticipantDisplayName = gfunct_L5DO_GDOHDfOT_1654.FirstOrDefault().CreatedBy_BusinessParticipantDisplayName ,

		Positions = 
		(
			from el_Positions in gfunct_L5DO_GDOHDfOT_1654.ToArray()
			select new L5DO_GDOHDfOT_1654a
			{     
				ORD_DIS_DistributionOrder_PositionID = el_Positions.ORD_DIS_DistributionOrder_PositionID,
				Quantity = el_Positions.Quantity,
				Position_OrdinalNumber = el_Positions.Position_OrdinalNumber,
				CMN_PRO_ProductID = el_Positions.CMN_PRO_ProductID,
				Product_Name = el_Positions.Product_Name,
				Product_Number = el_Positions.Product_Number,
				CMN_PRO_Product_VariantID = el_Positions.CMN_PRO_Product_VariantID,
				IsStandardProductVariant = el_Positions.IsStandardProductVariant,
				VariantName = el_Positions.VariantName,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GDOHDfOT_1654 : FR_Base
	{
		public L5DO_GDOHDfOT_1654 Result	{ get; set; }

		public FR_L5DO_GDOHDfOT_1654() : base() {}

		public FR_L5DO_GDOHDfOT_1654(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GDOHDfOT_1654 for attribute P_L5DO_GDOHDfOT_1654
		[DataContract]
		public class P_L5DO_GDOHDfOT_1654 
		{
			//Standard type parameters
			[DataMember]
			public Guid DistributionOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDOHDfOT_1654 for attribute L5DO_GDOHDfOT_1654
		[DataContract]
		public class L5DO_GDOHDfOT_1654 
		{
			[DataMember]
			public L5DO_GDOHDfOT_1654a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_DIS_DistributionOrder_HeaderID { get; set; } 
			[DataMember]
			public DateTime DistributionOrderDate { get; set; } 
			[DataMember]
			public string DistributionOrderNumber { get; set; } 
			[DataMember]
			public bool IsCanceled { get; set; } 
			[DataMember]
			public bool IsPartiallyFullfilled { get; set; } 
			[DataMember]
			public bool IsFullyFullfilled { get; set; } 
			[DataMember]
			public Dict CostCenterName { get; set; } 
			[DataMember]
			public Dict OfficeName { get; set; } 
			[DataMember]
			public string EmployeeName { get; set; } 
			[DataMember]
			public string WarehouseName { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipantID { get; set; } 
			[DataMember]
			public string CreatedBy_BusinessParticipantDisplayName { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDOHDfOT_1654a for attribute Positions
		[DataContract]
		public class L5DO_GDOHDfOT_1654a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_DIS_DistributionOrder_PositionID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public int Position_OrdinalNumber { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public string Product_Number { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public bool IsStandardProductVariant { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GDOHDfOT_1654 cls_Get_DistributionOrder_Header_Details_for_OrderTracking(,P_L5DO_GDOHDfOT_1654 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GDOHDfOT_1654 invocationResult = cls_Get_DistributionOrder_Header_Details_for_OrderTracking.Invoke(connectionString,P_L5DO_GDOHDfOT_1654 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_DistributionOrder.Atomic.Retrieval.P_L5DO_GDOHDfOT_1654();
parameter.DistributionOrderHeaderID = ...;

*/
