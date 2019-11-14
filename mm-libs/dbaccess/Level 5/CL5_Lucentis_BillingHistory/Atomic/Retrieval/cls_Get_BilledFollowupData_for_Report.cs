/* 
 * Generated on 3/27/2014 2:51:17 PM
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

namespace CL5_Lucentis_BillingHistory.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BilledFollowupData_for_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BilledFollowupData_for_Report
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BH_GBFDfR_1443_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BH_GBFDfR_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BH_GBFDfR_1443_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_BillingHistory.Atomic.Retrieval.SQL.cls_Get_BilledFollowupData_for_Report.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@FollowUpID"," IN $$FollowUpID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$FollowUpID$",Parameter.FollowUpID);


			List<L5BH_GBFDfR_1443_raw> results = new List<L5BH_GBFDfR_1443_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "VorgangsNumber","FollowupDate","GPOS","FirstName","LastName","PositionValue_IncludingTax","BIL_BillPositionID","BirthDate","FollowupPracticeID","External_PositionType","TCode","CMN_PRO_ProductID","Product_Name_DictID" });
				while(reader.Read())
				{
					L5BH_GBFDfR_1443_raw resultItem = new L5BH_GBFDfR_1443_raw();
					//0:Parameter VorgangsNumber of type String
					resultItem.VorgangsNumber = reader.GetString(0);
					//1:Parameter FollowupDate of type DateTime
					resultItem.FollowupDate = reader.GetDate(1);
					//2:Parameter GPOS of type String
					resultItem.GPOS = reader.GetString(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter PositionValue_IncludingTax of type String
					resultItem.PositionValue_IncludingTax = reader.GetString(5);
					//6:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(6);
					//7:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(7);
					//8:Parameter FollowupPracticeID of type Guid
					resultItem.FollowupPracticeID = reader.GetGuid(8);
					//9:Parameter External_PositionType of type String
					resultItem.External_PositionType = reader.GetString(9);
					//10:Parameter TCode of type String
					resultItem.TCode = reader.GetString(10);
					//11:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(11);
					//12:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(12);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BilledFollowupData_for_Report",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5BH_GBFDfR_1443_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BH_GBFDfR_1443_Array Invoke(string ConnectionString,P_L5BH_GBFDfR_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BH_GBFDfR_1443_Array Invoke(DbConnection Connection,P_L5BH_GBFDfR_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BH_GBFDfR_1443_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BH_GBFDfR_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BH_GBFDfR_1443_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BH_GBFDfR_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BH_GBFDfR_1443_Array functionReturn = new FR_L5BH_GBFDfR_1443_Array();
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

				throw new Exception("Exception occured in method cls_Get_BilledFollowupData_for_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5BH_GBFDfR_1443_raw 
	{
		public String VorgangsNumber; 
		public DateTime FollowupDate; 
		public String GPOS; 
		public String FirstName; 
		public String LastName; 
		public String PositionValue_IncludingTax; 
		public Guid BIL_BillPositionID; 
		public DateTime BirthDate; 
		public Guid FollowupPracticeID; 
		public String External_PositionType; 
		public String TCode; 
		public Guid CMN_PRO_ProductID; 
		public Dict Product_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BH_GBFDfR_1443[] Convert(List<L5BH_GBFDfR_1443_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BH_GBFDfR_1443 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.BIL_BillPositionID)).ToArray()
	group el_L5BH_GBFDfR_1443 by new 
	{ 
		el_L5BH_GBFDfR_1443.BIL_BillPositionID,

	}
	into gfunct_L5BH_GBFDfR_1443
	select new L5BH_GBFDfR_1443
	{     
		VorgangsNumber = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().VorgangsNumber ,
		FollowupDate = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().FollowupDate ,
		GPOS = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().GPOS ,
		FirstName = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().FirstName ,
		LastName = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().LastName ,
		PositionValue_IncludingTax = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().PositionValue_IncludingTax ,
		BIL_BillPositionID = gfunct_L5BH_GBFDfR_1443.Key.BIL_BillPositionID ,
		BirthDate = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().BirthDate ,
		FollowupPracticeID = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().FollowupPracticeID ,
		External_PositionType = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().External_PositionType ,
		TCode = gfunct_L5BH_GBFDfR_1443.FirstOrDefault().TCode ,

		Products = 
		(
			from el_Products in gfunct_L5BH_GBFDfR_1443.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
			group el_Products by new 
			{ 
				el_Products.CMN_PRO_ProductID,

			}
			into gfunct_Products
			select new Get_BilledFollowupData_for_Report_Products
			{     
				CMN_PRO_ProductID = gfunct_Products.Key.CMN_PRO_ProductID ,
				Product_Name = gfunct_Products.FirstOrDefault().Product_Name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5BH_GBFDfR_1443_Array : FR_Base
	{
		public L5BH_GBFDfR_1443[] Result	{ get; set; } 
		public FR_L5BH_GBFDfR_1443_Array() : base() {}

		public FR_L5BH_GBFDfR_1443_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BH_GBFDfR_1443 for attribute P_L5BH_GBFDfR_1443
		[DataContract]
		public class P_L5BH_GBFDfR_1443 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] FollowUpID { get; set; } 

		}
		#endregion
		#region SClass L5BH_GBFDfR_1443 for attribute L5BH_GBFDfR_1443
		[DataContract]
		public class L5BH_GBFDfR_1443 
		{
			[DataMember]
			public Get_BilledFollowupData_for_Report_Products[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public String VorgangsNumber { get; set; } 
			[DataMember]
			public DateTime FollowupDate { get; set; } 
			[DataMember]
			public String GPOS { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PositionValue_IncludingTax { get; set; } 
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid FollowupPracticeID { get; set; } 
			[DataMember]
			public String External_PositionType { get; set; } 
			[DataMember]
			public String TCode { get; set; } 

		}
		#endregion
		#region SClass Get_BilledFollowupData_for_Report_Products for attribute Products
		[DataContract]
		public class Get_BilledFollowupData_for_Report_Products 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BH_GBFDfR_1443_Array cls_Get_BilledFollowupData_for_Report(,P_L5BH_GBFDfR_1443 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BH_GBFDfR_1443_Array invocationResult = cls_Get_BilledFollowupData_for_Report.Invoke(connectionString,P_L5BH_GBFDfR_1443 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_BillingHistory.Atomic.Retrieval.P_L5BH_GBFDfR_1443();
parameter.FollowUpID = ...;

*/
