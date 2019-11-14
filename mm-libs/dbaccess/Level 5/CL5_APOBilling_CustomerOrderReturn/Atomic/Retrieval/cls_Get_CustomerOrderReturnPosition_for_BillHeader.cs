/* 
 * Generated on 07.11.2014 10:59:51
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

namespace CL5_APOBilling_CustomerOrderReturn.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderReturnPosition_for_BillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderReturnPosition_for_BillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OR_GCORPfBH_1045_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OR_GCORPfBH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OR_GCORPfBH_1045_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_CustomerOrderReturn.Atomic.Retrieval.SQL.cls_Get_CustomerOrderReturnPosition_for_BillHeader.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillHeaderID", Parameter.BillHeaderID);



			List<L5OR_GCORPfBH_1045> results = new List<L5OR_GCORPfBH_1045>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BIL_BillPositionID","Quantity","PositionValue_BeforeTax","PositionValue_IncludingTax","CMN_PRO_Product_RefID","Position_ValuePerUnit","ORD_CUO_CustomerOrderReturn_PositionID","CustomerOrderReturnNumber","DisplayName","CMN_BPT_BusinessParticipantID","CurrencySymbol","CMN_BPT_CTM_OrganizationalUnitID","OrganizationalUnit_SimpleName","OrganizationalUnit_Name_DictID","OrganizationalUnit_Description_DictID","InternalOrganizationalUnitNumber","InternalOrganizationalUnitSimpleName","ExternalOrganizationalUnitNumber","ORD_CUO_CustomerOrderReturn_HeaderID","Creation_Timestamp","DateOfCustomerReturn","PositionPricePerUnitValue_BeforeTax","PositionPricePerUnitValue_IncludingTax" });
				while(reader.Read())
				{
					L5OR_GCORPfBH_1045 resultItem = new L5OR_GCORPfBH_1045();
					//0:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(0);
					//1:Parameter Quantity of type Double
					resultItem.Quantity = reader.GetDouble(1);
					//2:Parameter PositionValue_BeforeTax of type Decimal
					resultItem.PositionValue_BeforeTax = reader.GetDecimal(2);
					//3:Parameter PositionValue_IncludingTax of type Decimal
					resultItem.PositionValue_IncludingTax = reader.GetDecimal(3);
					//4:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(4);
					//5:Parameter Position_ValuePerUnit of type Decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(5);
					//6:Parameter ORD_CUO_CustomerOrderReturn_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrderReturn_PositionID = reader.GetGuid(6);
					//7:Parameter CustomerOrderReturnNumber of type String
					resultItem.CustomerOrderReturnNumber = reader.GetString(7);
					//8:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(8);
					//9:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(9);
					//10:Parameter CurrencySymbol of type String
					resultItem.CurrencySymbol = reader.GetString(10);
					//11:Parameter CMN_BPT_CTM_OrganizationalUnitID of type Guid
					resultItem.CMN_BPT_CTM_OrganizationalUnitID = reader.GetGuid(11);
					//12:Parameter OrganizationalUnit_SimpleName of type String
					resultItem.OrganizationalUnit_SimpleName = reader.GetString(12);
					//13:Parameter OrganizationalUnit_Name_DictID of type Dict
					resultItem.OrganizationalUnit_Name_DictID = reader.GetDictionary(13);
					resultItem.OrganizationalUnit_Name_DictID.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Name_DictID);
					//14:Parameter OrganizationalUnit_Description_DictID of type Dict
					resultItem.OrganizationalUnit_Description_DictID = reader.GetDictionary(14);
					resultItem.OrganizationalUnit_Description_DictID.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Description_DictID);
					//15:Parameter InternalOrganizationalUnitNumber of type String
					resultItem.InternalOrganizationalUnitNumber = reader.GetString(15);
					//16:Parameter InternalOrganizationalUnitSimpleName of type String
					resultItem.InternalOrganizationalUnitSimpleName = reader.GetString(16);
					//17:Parameter ExternalOrganizationalUnitNumber of type String
					resultItem.ExternalOrganizationalUnitNumber = reader.GetString(17);
					//18:Parameter ORD_CUO_CustomerOrderReturn_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrderReturn_HeaderID = reader.GetGuid(18);
					//19:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(19);
					//20:Parameter DateOfCustomerReturn of type DateTime
					resultItem.DateOfCustomerReturn = reader.GetDate(20);
					//21:Parameter PositionPricePerUnitValue_BeforeTax of type Decimal
					resultItem.PositionPricePerUnitValue_BeforeTax = reader.GetDecimal(21);
					//22:Parameter PositionPricePerUnitValue_IncludingTax of type Decimal
					resultItem.PositionPricePerUnitValue_IncludingTax = reader.GetDecimal(22);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderReturnPosition_for_BillHeader",ex);
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
		public static FR_L5OR_GCORPfBH_1045_Array Invoke(string ConnectionString,P_L5OR_GCORPfBH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OR_GCORPfBH_1045_Array Invoke(DbConnection Connection,P_L5OR_GCORPfBH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OR_GCORPfBH_1045_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OR_GCORPfBH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OR_GCORPfBH_1045_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OR_GCORPfBH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OR_GCORPfBH_1045_Array functionReturn = new FR_L5OR_GCORPfBH_1045_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderReturnPosition_for_BillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OR_GCORPfBH_1045_Array : FR_Base
	{
		public L5OR_GCORPfBH_1045[] Result	{ get; set; } 
		public FR_L5OR_GCORPfBH_1045_Array() : base() {}

		public FR_L5OR_GCORPfBH_1045_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OR_GCORPfBH_1045 for attribute P_L5OR_GCORPfBH_1045
		[DataContract]
		public class P_L5OR_GCORPfBH_1045 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5OR_GCORPfBH_1045 for attribute L5OR_GCORPfBH_1045
		[DataContract]
		public class L5OR_GCORPfBH_1045 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public Double Quantity { get; set; } 
			[DataMember]
			public Decimal PositionValue_BeforeTax { get; set; } 
			[DataMember]
			public Decimal PositionValue_IncludingTax { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrderReturn_PositionID { get; set; } 
			[DataMember]
			public String CustomerOrderReturnNumber { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String CurrencySymbol { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnitID { get; set; } 
			[DataMember]
			public String OrganizationalUnit_SimpleName { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Name_DictID { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Description_DictID { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitSimpleName { get; set; } 
			[DataMember]
			public String ExternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrderReturn_HeaderID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime DateOfCustomerReturn { get; set; } 
			[DataMember]
			public Decimal PositionPricePerUnitValue_BeforeTax { get; set; } 
			[DataMember]
			public Decimal PositionPricePerUnitValue_IncludingTax { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OR_GCORPfBH_1045_Array cls_Get_CustomerOrderReturnPosition_for_BillHeader(,P_L5OR_GCORPfBH_1045 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OR_GCORPfBH_1045_Array invocationResult = cls_Get_CustomerOrderReturnPosition_for_BillHeader.Invoke(connectionString,P_L5OR_GCORPfBH_1045 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_CustomerOrderReturn.Atomic.Retrieval.P_L5OR_GCORPfBH_1045();
parameter.BillHeaderID = ...;

*/
