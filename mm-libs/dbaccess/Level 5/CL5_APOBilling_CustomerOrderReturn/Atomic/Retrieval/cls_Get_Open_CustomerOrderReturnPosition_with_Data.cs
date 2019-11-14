/* 
 * Generated on 8/27/2014 5:03:34 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOBilling_CustomerOrderReturn.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Open_CustomerOrderReturnPosition_with_Data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Open_CustomerOrderReturnPosition_with_Data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OR_GOCORPwD_1526_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OR_GOCORPwD_1526_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_CustomerOrderReturn.Atomic.Retrieval.SQL.cls_Get_Open_CustomerOrderReturnPosition_with_Data.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5OR_GOCORPwD_1526> results = new List<L5OR_GOCORPwD_1526>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrderReturn_PositionID","CMN_PRO_Product_RefID","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal","CustomerOrderReturnNumber","ValuePerUnit","CustomerName","CMN_BPT_BusinessParticipantID","CurrencySymbol","CurrencyISO" });
				while(reader.Read())
				{
					L5OR_GOCORPwD_1526 resultItem = new L5OR_GOCORPwD_1526();
					//0:Parameter ORD_CUO_CustomerOrderReturn_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrderReturn_PositionID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(1);
					//2:Parameter Position_Quantity of type String
					resultItem.Position_Quantity = reader.GetString(2);
					//3:Parameter Position_ValuePerUnit of type Decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(3);
					//4:Parameter Position_ValueTotal of type Decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(4);
					//5:Parameter CustomerOrderReturnNumber of type String
					resultItem.CustomerOrderReturnNumber = reader.GetString(5);
					//6:Parameter ValuePerUnit of type Decimal
					resultItem.ValuePerUnit = reader.GetDecimal(6);
					//7:Parameter CustomerName of type String
					resultItem.CustomerName = reader.GetString(7);
					//8:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(8);
					//9:Parameter CurrencySymbol of type String
					resultItem.CurrencySymbol = reader.GetString(9);
					//10:Parameter CurrencyISO of type String
					resultItem.CurrencyISO = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Open_CustomerOrderReturnPosition_with_Data",ex);
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
		public static FR_L5OR_GOCORPwD_1526_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OR_GOCORPwD_1526_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OR_GOCORPwD_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OR_GOCORPwD_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OR_GOCORPwD_1526_Array functionReturn = new FR_L5OR_GOCORPwD_1526_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Open_CustomerOrderReturnPosition_with_Data",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OR_GOCORPwD_1526_Array : FR_Base
	{
		public L5OR_GOCORPwD_1526[] Result	{ get; set; } 
		public FR_L5OR_GOCORPwD_1526_Array() : base() {}

		public FR_L5OR_GOCORPwD_1526_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OR_GOCORPwD_1526 for attribute L5OR_GOCORPwD_1526
		[DataContract]
		public class L5OR_GOCORPwD_1526 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrderReturn_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public String Position_Quantity { get; set; } 
			[DataMember]
			public Decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public Decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public String CustomerOrderReturnNumber { get; set; } 
			[DataMember]
			public Decimal ValuePerUnit { get; set; } 
			[DataMember]
			public String CustomerName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String CurrencySymbol { get; set; } 
			[DataMember]
			public String CurrencyISO { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OR_GOCORPwD_1526_Array cls_Get_Open_CustomerOrderReturnPosition_with_Data(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OR_GOCORPwD_1526_Array invocationResult = cls_Get_Open_CustomerOrderReturnPosition_with_Data.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

