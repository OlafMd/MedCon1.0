/* 
 * Generated on 3/27/2014 2:51:14 PM
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
    /// var result = cls_Get_BilledTreatmentData_for_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BilledTreatmentData_for_Report
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BH_GBTDfR_1158_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BH_GBTDfR_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BH_GBTDfR_1158_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_BillingHistory.Atomic.Retrieval.SQL.cls_Get_BilledTreatmentData_for_Report.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@TreatmentID"," IN $$TreatmentID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$TreatmentID$",Parameter.TreatmentID);


			List<L5BH_GBTDfR_1158_raw> results = new List<L5BH_GBTDfR_1158_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "VorgangsNumber","TreatmentDate","FirstName","LastName","GPOS","Creation_Timestamp","PositionValue_IncludingTax","BIL_BillPositionID","BirthDate","HEC_Patient_TreatmentID","External_PositionType","TreatmentPractice_RefID","TCode","CMN_PRO_ProductID","Product_Name_DictID" });
				while(reader.Read())
				{
					L5BH_GBTDfR_1158_raw resultItem = new L5BH_GBTDfR_1158_raw();
					//0:Parameter VorgangsNumber of type String
					resultItem.VorgangsNumber = reader.GetString(0);
					//1:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(1);
					//2:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(2);
					//3:Parameter LastName of type String
					resultItem.LastName = reader.GetString(3);
					//4:Parameter GPOS of type String
					resultItem.GPOS = reader.GetString(4);
					//5:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(5);
					//6:Parameter PositionValue_IncludingTax of type String
					resultItem.PositionValue_IncludingTax = reader.GetString(6);
					//7:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(7);
					//8:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(8);
					//9:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(9);
					//10:Parameter External_PositionType of type String
					resultItem.External_PositionType = reader.GetString(10);
					//11:Parameter TreatmentPractice_RefID of type Guid
					resultItem.TreatmentPractice_RefID = reader.GetGuid(11);
					//12:Parameter TCode of type String
					resultItem.TCode = reader.GetString(12);
					//13:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(13);
					//14:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(14);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BilledTreatmentData_for_Report",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5BH_GBTDfR_1158_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BH_GBTDfR_1158_Array Invoke(string ConnectionString,P_L5BH_GBTDfR_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BH_GBTDfR_1158_Array Invoke(DbConnection Connection,P_L5BH_GBTDfR_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BH_GBTDfR_1158_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BH_GBTDfR_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BH_GBTDfR_1158_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BH_GBTDfR_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BH_GBTDfR_1158_Array functionReturn = new FR_L5BH_GBTDfR_1158_Array();
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

				throw new Exception("Exception occured in method cls_Get_BilledTreatmentData_for_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5BH_GBTDfR_1158_raw 
	{
		public String VorgangsNumber; 
		public DateTime TreatmentDate; 
		public String FirstName; 
		public String LastName; 
		public String GPOS; 
		public DateTime Creation_Timestamp; 
		public String PositionValue_IncludingTax; 
		public Guid BIL_BillPositionID; 
		public DateTime BirthDate; 
		public Guid HEC_Patient_TreatmentID; 
		public String External_PositionType; 
		public Guid TreatmentPractice_RefID; 
		public String TCode; 
		public Guid CMN_PRO_ProductID; 
		public Dict Product_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BH_GBTDfR_1158[] Convert(List<L5BH_GBTDfR_1158_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BH_GBTDfR_1158 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.BIL_BillPositionID)).ToArray()
	group el_L5BH_GBTDfR_1158 by new 
	{ 
		el_L5BH_GBTDfR_1158.BIL_BillPositionID,

	}
	into gfunct_L5BH_GBTDfR_1158
	select new L5BH_GBTDfR_1158
	{     
		VorgangsNumber = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().VorgangsNumber ,
		TreatmentDate = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().TreatmentDate ,
		FirstName = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().FirstName ,
		LastName = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().LastName ,
		GPOS = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().GPOS ,
		Creation_Timestamp = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().Creation_Timestamp ,
		PositionValue_IncludingTax = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().PositionValue_IncludingTax ,
		BIL_BillPositionID = gfunct_L5BH_GBTDfR_1158.Key.BIL_BillPositionID ,
		BirthDate = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().BirthDate ,
		HEC_Patient_TreatmentID = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().HEC_Patient_TreatmentID ,
		External_PositionType = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().External_PositionType ,
		TreatmentPractice_RefID = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().TreatmentPractice_RefID ,
		TCode = gfunct_L5BH_GBTDfR_1158.FirstOrDefault().TCode ,

		Products = 
		(
			from el_Products in gfunct_L5BH_GBTDfR_1158.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
			group el_Products by new 
			{ 
				el_Products.CMN_PRO_ProductID,

			}
			into gfunct_Products
			select new Get_BilledTreatmentData_for_Report_Products
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
	public class FR_L5BH_GBTDfR_1158_Array : FR_Base
	{
		public L5BH_GBTDfR_1158[] Result	{ get; set; } 
		public FR_L5BH_GBTDfR_1158_Array() : base() {}

		public FR_L5BH_GBTDfR_1158_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BH_GBTDfR_1158 for attribute P_L5BH_GBTDfR_1158
		[DataContract]
		public class P_L5BH_GBTDfR_1158 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L5BH_GBTDfR_1158 for attribute L5BH_GBTDfR_1158
		[DataContract]
		public class L5BH_GBTDfR_1158 
		{
			[DataMember]
			public Get_BilledTreatmentData_for_Report_Products[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public String VorgangsNumber { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String GPOS { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String PositionValue_IncludingTax { get; set; } 
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public String External_PositionType { get; set; } 
			[DataMember]
			public Guid TreatmentPractice_RefID { get; set; } 
			[DataMember]
			public String TCode { get; set; } 

		}
		#endregion
		#region SClass Get_BilledTreatmentData_for_Report_Products for attribute Products
		[DataContract]
		public class Get_BilledTreatmentData_for_Report_Products 
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
FR_L5BH_GBTDfR_1158_Array cls_Get_BilledTreatmentData_for_Report(,P_L5BH_GBTDfR_1158 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BH_GBTDfR_1158_Array invocationResult = cls_Get_BilledTreatmentData_for_Report.Invoke(connectionString,P_L5BH_GBTDfR_1158 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_BillingHistory.Atomic.Retrieval.P_L5BH_GBTDfR_1158();
parameter.TreatmentID = ...;

*/
