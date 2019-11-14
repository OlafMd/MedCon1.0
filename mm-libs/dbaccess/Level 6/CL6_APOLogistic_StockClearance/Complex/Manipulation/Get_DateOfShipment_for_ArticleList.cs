/* 
 * Generated on 7/16/2014 3:04:27 PM
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

namespace CL6_APOLogistic_StockClearance.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = Get_DateOfShipment_for_ArticleList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class Get_DateOfShipment_for_ArticleList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SC_GDSfAL_1418_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6SC_GDSfAL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6SC_GDSfAL_1418_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOLogistic_StockClearance.Complex.Manipulation.SQL.Get_DateOfShipment_for_ArticleList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductID_List"," IN $$ProductID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductID_List$",Parameter.ProductID_List);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"shipmentStatus", Parameter.shipmentStatus);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateFrom", Parameter.DateFrom);



			List<L6SC_GDSfAL_1418> results = new List<L6SC_GDSfAL_1418>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Creation_Timestamp","CMN_PRO_Product_RefID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L6SC_GDSfAL_1418 resultItem = new L6SC_GDSfAL_1418();
					//0:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(0);
					//1:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(1);
					//2:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method Get_DateOfShipment_for_ArticleList",ex);
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
		public static FR_L6SC_GDSfAL_1418_Array Invoke(string ConnectionString,P_L6SC_GDSfAL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SC_GDSfAL_1418_Array Invoke(DbConnection Connection,P_L6SC_GDSfAL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SC_GDSfAL_1418_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SC_GDSfAL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SC_GDSfAL_1418_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SC_GDSfAL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SC_GDSfAL_1418_Array functionReturn = new FR_L6SC_GDSfAL_1418_Array();
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

				throw new Exception("Exception occured in method Get_DateOfShipment_for_ArticleList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SC_GDSfAL_1418_Array : FR_Base
	{
		public L6SC_GDSfAL_1418[] Result	{ get; set; } 
		public FR_L6SC_GDSfAL_1418_Array() : base() {}

		public FR_L6SC_GDSfAL_1418_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SC_GDSfAL_1418 for attribute P_L6SC_GDSfAL_1418
		[DataContract]
		public class P_L6SC_GDSfAL_1418 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductID_List { get; set; } 
			[DataMember]
			public string shipmentStatus { get; set; } 
			[DataMember]
			public DateTime? DateFrom { get; set; } 

		}
		#endregion
		#region SClass L6SC_GDSfAL_1418 for attribute L6SC_GDSfAL_1418
		[DataContract]
		public class L6SC_GDSfAL_1418 
		{
			//Standard type parameters
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SC_GDSfAL_1418_Array Get_DateOfShipment_for_ArticleList(,P_L6SC_GDSfAL_1418 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SC_GDSfAL_1418_Array invocationResult = Get_DateOfShipment_for_ArticleList.Invoke(connectionString,P_L6SC_GDSfAL_1418 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_StockClearance.Complex.Manipulation.P_L6SC_GDSfAL_1418();
parameter.ProductID_List = ...;
parameter.shipmentStatus = ...;
parameter.DateFrom = ...;

*/
