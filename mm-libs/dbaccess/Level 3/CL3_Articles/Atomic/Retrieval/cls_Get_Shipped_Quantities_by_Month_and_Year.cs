/* 
 * Generated on 5/27/2014 8:50:03 AM
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

namespace CL3_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Shipped_Quantities_by_Month_and_Year.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Shipped_Quantities_by_Month_and_Year
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_GSQbMaY_1546_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_GSQbMaY_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AR_GSQbMaY_1546_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Articles.Atomic.Retrieval.SQL.cls_Get_Shipped_Quantities_by_Month_and_Year.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductID_List"," IN $$ProductID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductID_List$",Parameter.ProductID_List);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShippedStatusID", Parameter.ShippedStatusID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Year", Parameter.Year);



			List<L3AR_GSQbMaY_1546_raw> results = new List<L3AR_GSQbMaY_1546_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProductID","SoldQuantity","MonthOfSale","YearOfSale" });
				while(reader.Read())
				{
					L3AR_GSQbMaY_1546_raw resultItem = new L3AR_GSQbMaY_1546_raw();
					//0:Parameter ProductID of type Guid
					resultItem.ProductID = reader.GetGuid(0);
					//1:Parameter SoldQuantity of type Double
					resultItem.SoldQuantity = reader.GetDouble(1);
					//2:Parameter MonthOfSale of type int
					resultItem.MonthOfSale = reader.GetInteger(2);
					//3:Parameter YearOfSale of type int
					resultItem.YearOfSale = reader.GetInteger(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Shipped_Quantities_by_Month_and_Year",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3AR_GSQbMaY_1546_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AR_GSQbMaY_1546_Array Invoke(string ConnectionString,P_L3AR_GSQbMaY_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_GSQbMaY_1546_Array Invoke(DbConnection Connection,P_L3AR_GSQbMaY_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_GSQbMaY_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_GSQbMaY_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_GSQbMaY_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_GSQbMaY_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_GSQbMaY_1546_Array functionReturn = new FR_L3AR_GSQbMaY_1546_Array();
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

				throw new Exception("Exception occured in method cls_Get_Shipped_Quantities_by_Month_and_Year",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3AR_GSQbMaY_1546_raw 
	{
		public Guid ProductID; 
		public Double SoldQuantity; 
		public int MonthOfSale; 
		public int YearOfSale; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3AR_GSQbMaY_1546[] Convert(List<L3AR_GSQbMaY_1546_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3AR_GSQbMaY_1546 in gfunct_rawResult.ToArray()
	group el_L3AR_GSQbMaY_1546 by new 
	{ 
	}
	into gfunct_L3AR_GSQbMaY_1546
	select new L3AR_GSQbMaY_1546
	{     
		ProductID = gfunct_L3AR_GSQbMaY_1546.FirstOrDefault().ProductID ,
		SoldQuantity = gfunct_L3AR_GSQbMaY_1546.FirstOrDefault().SoldQuantity ,
		MonthOfSale = gfunct_L3AR_GSQbMaY_1546.FirstOrDefault().MonthOfSale ,
		YearOfSale = gfunct_L3AR_GSQbMaY_1546.FirstOrDefault().YearOfSale ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3AR_GSQbMaY_1546_Array : FR_Base
	{
		public L3AR_GSQbMaY_1546[] Result	{ get; set; } 
		public FR_L3AR_GSQbMaY_1546_Array() : base() {}

		public FR_L3AR_GSQbMaY_1546_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_GSQbMaY_1546 for attribute P_L3AR_GSQbMaY_1546
		[DataContract]
		public class P_L3AR_GSQbMaY_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductID_List { get; set; } 
			[DataMember]
			public Guid ShippedStatusID { get; set; } 
			[DataMember]
			public int Year { get; set; } 

		}
		#endregion
		#region SClass L3AR_GSQbMaY_1546 for attribute L3AR_GSQbMaY_1546
		[DataContract]
		public class L3AR_GSQbMaY_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Double SoldQuantity { get; set; } 
			[DataMember]
			public int MonthOfSale { get; set; } 
			[DataMember]
			public int YearOfSale { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AR_GSQbMaY_1546_Array cls_Get_Shipped_Quantities_by_Month_and_Year(,P_L3AR_GSQbMaY_1546 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_GSQbMaY_1546_Array invocationResult = cls_Get_Shipped_Quantities_by_Month_and_Year.Invoke(connectionString,P_L3AR_GSQbMaY_1546 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Atomic.Retrieval.P_L3AR_GSQbMaY_1546();
parameter.ProductID_List = ...;
parameter.ShippedStatusID = ...;
parameter.Year = ...;

*/
