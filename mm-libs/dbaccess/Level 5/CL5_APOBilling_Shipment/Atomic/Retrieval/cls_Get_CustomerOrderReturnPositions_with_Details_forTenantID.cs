/* 
 * Generated on 6/11/2014 1:38:09 PM
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
using System.Runtime.Serialization;

namespace CL5_APOBilling_Shipment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SH_GCORPwDfT_1455_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SH_GCORPwDfT_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SH_GCORPwDfT_1455_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Shipment.Atomic.Retrieval.SQL.cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderNumber", Parameter.OrderNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Customer", Parameter.Customer);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PeriodFrom", Parameter.PeriodFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PeriodTo", Parameter.PeriodTo);



			List<L5SH_GCORPwDfT_1455_raw> results = new List<L5SH_GCORPwDfT_1455_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrderReturn_HeaderID","CustomerOrderReturnNumber","Creation_Timestamp","OrderDate","CMN_BPT_CTM_CustomerID","InternalCustomerNumber","CustomerBusinessParticipantID","CustomerName","CMN_PRO_Product_RefID","Position_ValueTotal","CurrencySymbol","TaxRate" });
				while(reader.Read())
				{
					L5SH_GCORPwDfT_1455_raw resultItem = new L5SH_GCORPwDfT_1455_raw();
					//0:Parameter ORD_CUO_CustomerOrderReturn_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrderReturn_HeaderID = reader.GetGuid(0);
					//1:Parameter CustomerOrderReturnNumber of type String
					resultItem.CustomerOrderReturnNumber = reader.GetString(1);
					//2:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(2);
					//3:Parameter OrderDate of type DateTime
					resultItem.OrderDate = reader.GetDate(3);
					//4:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(4);
					//5:Parameter InternalCustomerNumber of type String
					resultItem.InternalCustomerNumber = reader.GetString(5);
					//6:Parameter CustomerBusinessParticipantID of type Guid
					resultItem.CustomerBusinessParticipantID = reader.GetGuid(6);
					//7:Parameter CustomerName of type String
					resultItem.CustomerName = reader.GetString(7);
					//8:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(8);
					//9:Parameter Position_ValueTotal of type decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(9);
					//10:Parameter CurrencySymbol of type String
					resultItem.CurrencySymbol = reader.GetString(10);
					//11:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5SH_GCORPwDfT_1455_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SH_GCORPwDfT_1455_Array Invoke(string ConnectionString,P_L5SH_GCORPwDfT_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SH_GCORPwDfT_1455_Array Invoke(DbConnection Connection,P_L5SH_GCORPwDfT_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SH_GCORPwDfT_1455_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SH_GCORPwDfT_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SH_GCORPwDfT_1455_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SH_GCORPwDfT_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SH_GCORPwDfT_1455_Array functionReturn = new FR_L5SH_GCORPwDfT_1455_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5SH_GCORPwDfT_1455_raw 
	{
		public Guid ORD_CUO_CustomerOrderReturn_HeaderID; 
		public String CustomerOrderReturnNumber; 
		public DateTime Creation_Timestamp; 
		public DateTime OrderDate; 
		public Guid CMN_BPT_CTM_CustomerID; 
		public String InternalCustomerNumber; 
		public Guid CustomerBusinessParticipantID; 
		public String CustomerName; 
		public Guid CMN_PRO_Product_RefID; 
		public decimal Position_ValueTotal; 
		public String CurrencySymbol; 
		public double TaxRate; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5SH_GCORPwDfT_1455[] Convert(List<L5SH_GCORPwDfT_1455_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5SH_GCORPwDfT_1455 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrderReturn_HeaderID)).ToArray()
	group el_L5SH_GCORPwDfT_1455 by new 
	{ 
		el_L5SH_GCORPwDfT_1455.ORD_CUO_CustomerOrderReturn_HeaderID,

	}
	into gfunct_L5SH_GCORPwDfT_1455
	select new L5SH_GCORPwDfT_1455
	{     
		ORD_CUO_CustomerOrderReturn_HeaderID = gfunct_L5SH_GCORPwDfT_1455.Key.ORD_CUO_CustomerOrderReturn_HeaderID ,
		CustomerOrderReturnNumber = gfunct_L5SH_GCORPwDfT_1455.FirstOrDefault().CustomerOrderReturnNumber ,
		Creation_Timestamp = gfunct_L5SH_GCORPwDfT_1455.FirstOrDefault().Creation_Timestamp ,
		OrderDate = gfunct_L5SH_GCORPwDfT_1455.FirstOrDefault().OrderDate ,
		CMN_BPT_CTM_CustomerID = gfunct_L5SH_GCORPwDfT_1455.FirstOrDefault().CMN_BPT_CTM_CustomerID ,
		InternalCustomerNumber = gfunct_L5SH_GCORPwDfT_1455.FirstOrDefault().InternalCustomerNumber ,
		CustomerBusinessParticipantID = gfunct_L5SH_GCORPwDfT_1455.FirstOrDefault().CustomerBusinessParticipantID ,
		CustomerName = gfunct_L5SH_GCORPwDfT_1455.FirstOrDefault().CustomerName ,

		InfoProducts = 
		(
			from el_InfoProducts in gfunct_L5SH_GCORPwDfT_1455.Where(element => !EqualsDefaultValue(element.CMN_PRO_Product_RefID)).ToArray()
			group el_InfoProducts by new 
			{ 
				el_InfoProducts.CMN_PRO_Product_RefID,

			}
			into gfunct_InfoProducts
			select new L5SH_GCORPwDfT_1455_InfoProduct
			{     
				CMN_PRO_Product_RefID = gfunct_InfoProducts.Key.CMN_PRO_Product_RefID ,
				Position_ValueTotal = gfunct_InfoProducts.FirstOrDefault().Position_ValueTotal ,
				CurrencySymbol = gfunct_InfoProducts.FirstOrDefault().CurrencySymbol ,
				TaxRate = gfunct_InfoProducts.FirstOrDefault().TaxRate ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5SH_GCORPwDfT_1455_Array : FR_Base
	{
		public L5SH_GCORPwDfT_1455[] Result	{ get; set; } 
		public FR_L5SH_GCORPwDfT_1455_Array() : base() {}

		public FR_L5SH_GCORPwDfT_1455_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SH_GCORPwDfT_1455 for attribute P_L5SH_GCORPwDfT_1455
		[DataContract]
		public class P_L5SH_GCORPwDfT_1455 
		{
			//Standard type parameters
			[DataMember]
			public string OrderNumber { get; set; } 
			[DataMember]
			public string Customer { get; set; } 
			[DataMember]
			public DateTime? PeriodFrom { get; set; } 
			[DataMember]
			public DateTime? PeriodTo { get; set; } 

		}
		#endregion
		#region SClass L5SH_GCORPwDfT_1455 for attribute L5SH_GCORPwDfT_1455
		[DataContract]
		public class L5SH_GCORPwDfT_1455 
		{
			[DataMember]
			public L5SH_GCORPwDfT_1455_InfoProduct[] InfoProducts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrderReturn_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrderReturnNumber { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime OrderDate { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public String InternalCustomerNumber { get; set; } 
			[DataMember]
			public Guid CustomerBusinessParticipantID { get; set; } 
			[DataMember]
			public String CustomerName { get; set; } 

		}
		#endregion
		#region SClass L5SH_GCORPwDfT_1455_InfoProduct for attribute InfoProducts
		[DataContract]
		public class L5SH_GCORPwDfT_1455_InfoProduct 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public String CurrencySymbol { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SH_GCORPwDfT_1455_Array cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID(,P_L5SH_GCORPwDfT_1455 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SH_GCORPwDfT_1455_Array invocationResult = cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID.Invoke(connectionString,P_L5SH_GCORPwDfT_1455 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Shipment.Atomic.Retrieval.P_L5SH_GCORPwDfT_1455();
parameter.OrderNumber = ...;
parameter.Customer = ...;
parameter.PeriodFrom = ...;
parameter.PeriodTo = ...;

*/
