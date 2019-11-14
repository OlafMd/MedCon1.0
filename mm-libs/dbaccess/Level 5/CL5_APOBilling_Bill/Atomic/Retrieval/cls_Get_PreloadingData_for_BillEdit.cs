/* 
 * Generated on 24/9/2014 11:19:21
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

namespace CL5_APOBilling_Bill.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadingData_for_BillEdit.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadingData_for_BillEdit
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GPDfBE_1635 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GPDfBE_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BL_GPDfBE_1635();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Bill.Atomic.Retrieval.SQL.cls_Get_PreloadingData_for_BillEdit.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillHeaderID", Parameter.BillHeaderID);



			List<L5BL_GPDfBE_1635_raw> results = new List<L5BL_GPDfBE_1635_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BIL_BillHeaderID","BillRecipient_BuisnessParticipant_RefID","CreatedBy_BusinessParticipant_RefID","BillNumber","BillComment","BillHeader_PaymentCondition_RefID","ACC_PAY_Type_RefID","DateOnBill","BillingAddress_UCD_RefID","CMN_UniversalContactDetailID","CompanyName_Line1","First_Name","Last_Name","Country_Name","Country_639_1_ISOCode","Street_Name","Street_Number","ZIP","Town","Tenant_RefID","TotalValue_BeforeTax","TotalValue_IncludingTax","Status_AssignmentID","CMN_BPT_CTM_CustomerID","Symbol","ISO4127","NotesNumber","BIL_BillStatusID","Status_GlobalPropertyMatchingID","BillStatus_Name_DictID","IsCurrentStatus" });
				while(reader.Read())
				{
					L5BL_GPDfBE_1635_raw resultItem = new L5BL_GPDfBE_1635_raw();
					//0:Parameter BIL_BillHeaderID of type Guid
					resultItem.BIL_BillHeaderID = reader.GetGuid(0);
					//1:Parameter BillRecipient_BuisnessParticipant_RefID of type Guid
					resultItem.BillRecipient_BuisnessParticipant_RefID = reader.GetGuid(1);
					//2:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(2);
					//3:Parameter BillNumber of type String
					resultItem.BillNumber = reader.GetString(3);
					//4:Parameter BillComment of type String
					resultItem.BillComment = reader.GetString(4);
					//5:Parameter BillHeader_PaymentCondition_RefID of type Guid
					resultItem.BillHeader_PaymentCondition_RefID = reader.GetGuid(5);
					//6:Parameter ACC_PAY_Type_RefID of type Guid
					resultItem.ACC_PAY_Type_RefID = reader.GetGuid(6);
					//7:Parameter DateOnBill of type DateTime
					resultItem.DateOnBill = reader.GetDate(7);
					//8:Parameter BillingAddress_UCD_RefID of type Guid
					resultItem.BillingAddress_UCD_RefID = reader.GetGuid(8);
					//9:Parameter CMN_UniversalContactDetailID of type Guid
					resultItem.CMN_UniversalContactDetailID = reader.GetGuid(9);
					//10:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(10);
					//11:Parameter First_Name of type String
					resultItem.First_Name = reader.GetString(11);
					//12:Parameter Last_Name of type String
					resultItem.Last_Name = reader.GetString(12);
					//13:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(13);
					//14:Parameter Country_639_1_ISOCode of type String
					resultItem.Country_639_1_ISOCode = reader.GetString(14);
					//15:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(15);
					//16:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(16);
					//17:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(17);
					//18:Parameter Town of type String
					resultItem.Town = reader.GetString(18);
					//19:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(19);
					//20:Parameter TotalValue_BeforeTax of type Double
					resultItem.TotalValue_BeforeTax = reader.GetDouble(20);
					//21:Parameter TotalValue_IncludingTax of type Double
					resultItem.TotalValue_IncludingTax = reader.GetDouble(21);
					//22:Parameter Status_AssignmentID of type Guid
					resultItem.Status_AssignmentID = reader.GetGuid(22);
					//23:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(23);
					//24:Parameter Symbol of type String
					resultItem.Symbol = reader.GetString(24);
					//25:Parameter ISO4127 of type String
					resultItem.ISO4127 = reader.GetString(25);
					//26:Parameter NotesNumber of type int
					resultItem.NotesNumber = reader.GetInteger(26);
					//27:Parameter BIL_BillStatusID of type Guid
					resultItem.BIL_BillStatusID = reader.GetGuid(27);
					//28:Parameter Status_GlobalPropertyMatchingID of type string
					resultItem.Status_GlobalPropertyMatchingID = reader.GetString(28);
					//29:Parameter BillStatus_Name of type Dict
					resultItem.BillStatus_Name = reader.GetDictionary(29);
					resultItem.BillStatus_Name.SourceTable = "bil_billstatuses";
					loader.Append(resultItem.BillStatus_Name);
					//30:Parameter IsCurrentStatus of type bool
					resultItem.IsCurrentStatus = reader.GetBoolean(30);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PreloadingData_for_BillEdit",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5BL_GPDfBE_1635_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BL_GPDfBE_1635 Invoke(string ConnectionString,P_L5BL_GPDfBE_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GPDfBE_1635 Invoke(DbConnection Connection,P_L5BL_GPDfBE_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GPDfBE_1635 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GPDfBE_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GPDfBE_1635 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GPDfBE_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GPDfBE_1635 functionReturn = new FR_L5BL_GPDfBE_1635();
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

				throw new Exception("Exception occured in method cls_Get_PreloadingData_for_BillEdit",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5BL_GPDfBE_1635_raw 
	{
		public Guid BIL_BillHeaderID; 
		public Guid BillRecipient_BuisnessParticipant_RefID; 
		public Guid CreatedBy_BusinessParticipant_RefID; 
		public String BillNumber; 
		public String BillComment; 
		public Guid BillHeader_PaymentCondition_RefID; 
		public Guid ACC_PAY_Type_RefID; 
		public DateTime DateOnBill; 
		public Guid BillingAddress_UCD_RefID; 
		public Guid CMN_UniversalContactDetailID; 
		public String CompanyName_Line1; 
		public String First_Name; 
		public String Last_Name; 
		public String Country_Name; 
		public String Country_639_1_ISOCode; 
		public String Street_Name; 
		public String Street_Number; 
		public String ZIP; 
		public String Town; 
		public Guid Tenant_RefID; 
		public Double TotalValue_BeforeTax; 
		public Double TotalValue_IncludingTax; 
		public Guid Status_AssignmentID; 
		public Guid CMN_BPT_CTM_CustomerID; 
		public String Symbol; 
		public String ISO4127; 
		public int NotesNumber; 
		public Guid BIL_BillStatusID; 
		public string Status_GlobalPropertyMatchingID; 
		public Dict BillStatus_Name; 
		public bool IsCurrentStatus; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BL_GPDfBE_1635[] Convert(List<L5BL_GPDfBE_1635_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BL_GPDfBE_1635 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.BIL_BillHeaderID)).ToArray()
	group el_L5BL_GPDfBE_1635 by new 
	{ 
		el_L5BL_GPDfBE_1635.BIL_BillHeaderID,

	}
	into gfunct_L5BL_GPDfBE_1635
	select new L5BL_GPDfBE_1635
	{     
		BIL_BillHeaderID = gfunct_L5BL_GPDfBE_1635.Key.BIL_BillHeaderID ,
		BillRecipient_BuisnessParticipant_RefID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().BillRecipient_BuisnessParticipant_RefID ,
		CreatedBy_BusinessParticipant_RefID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().CreatedBy_BusinessParticipant_RefID ,
		BillNumber = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().BillNumber ,
		BillComment = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().BillComment ,
		BillHeader_PaymentCondition_RefID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().BillHeader_PaymentCondition_RefID ,
		ACC_PAY_Type_RefID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().ACC_PAY_Type_RefID ,
		DateOnBill = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().DateOnBill ,
		BillingAddress_UCD_RefID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().BillingAddress_UCD_RefID ,
		CMN_UniversalContactDetailID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().CMN_UniversalContactDetailID ,
		CompanyName_Line1 = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().CompanyName_Line1 ,
		First_Name = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().First_Name ,
		Last_Name = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Last_Name ,
		Country_Name = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Country_Name ,
		Country_639_1_ISOCode = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Country_639_1_ISOCode ,
		Street_Name = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Street_Number ,
		ZIP = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().ZIP ,
		Town = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Town ,
		Tenant_RefID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Tenant_RefID ,
		TotalValue_BeforeTax = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().TotalValue_BeforeTax ,
		TotalValue_IncludingTax = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().TotalValue_IncludingTax ,
		Status_AssignmentID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Status_AssignmentID ,
		CMN_BPT_CTM_CustomerID = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().CMN_BPT_CTM_CustomerID ,
		Symbol = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().Symbol ,
		ISO4127 = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().ISO4127 ,
		NotesNumber = gfunct_L5BL_GPDfBE_1635.FirstOrDefault().NotesNumber ,

		BillStatus = 
		(
			from el_BillStatus in gfunct_L5BL_GPDfBE_1635.Where(element => !EqualsDefaultValue(element.BIL_BillStatusID)).ToArray()
			group el_BillStatus by new 
			{ 
				el_BillStatus.BIL_BillStatusID,

			}
			into gfunct_BillStatus
			select new L5BL_GPDfBE_1635_BillStatus
			{     
				BIL_BillStatusID = gfunct_BillStatus.Key.BIL_BillStatusID ,
				Status_GlobalPropertyMatchingID = gfunct_BillStatus.FirstOrDefault().Status_GlobalPropertyMatchingID ,
				BillStatus_Name = gfunct_BillStatus.FirstOrDefault().BillStatus_Name ,
				IsCurrentStatus = gfunct_BillStatus.FirstOrDefault().IsCurrentStatus ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GPDfBE_1635 : FR_Base
	{
		public L5BL_GPDfBE_1635 Result	{ get; set; }

		public FR_L5BL_GPDfBE_1635() : base() {}

		public FR_L5BL_GPDfBE_1635(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GPDfBE_1635 for attribute P_L5BL_GPDfBE_1635
		[DataContract]
		public class P_L5BL_GPDfBE_1635 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GPDfBE_1635 for attribute L5BL_GPDfBE_1635
		[DataContract]
		public class L5BL_GPDfBE_1635 
		{
			[DataMember]
			public L5BL_GPDfBE_1635_BillStatus[] BillStatus { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid BIL_BillHeaderID { get; set; } 
			[DataMember]
			public Guid BillRecipient_BuisnessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String BillNumber { get; set; } 
			[DataMember]
			public String BillComment { get; set; } 
			[DataMember]
			public Guid BillHeader_PaymentCondition_RefID { get; set; } 
			[DataMember]
			public Guid ACC_PAY_Type_RefID { get; set; } 
			[DataMember]
			public DateTime DateOnBill { get; set; } 
			[DataMember]
			public Guid BillingAddress_UCD_RefID { get; set; } 
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String First_Name { get; set; } 
			[DataMember]
			public String Last_Name { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String Country_639_1_ISOCode { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Double TotalValue_BeforeTax { get; set; } 
			[DataMember]
			public Double TotalValue_IncludingTax { get; set; } 
			[DataMember]
			public Guid Status_AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public String Symbol { get; set; } 
			[DataMember]
			public String ISO4127 { get; set; } 
			[DataMember]
			public int NotesNumber { get; set; } 

		}
		#endregion
		#region SClass L5BL_GPDfBE_1635_BillStatus for attribute BillStatus
		[DataContract]
		public class L5BL_GPDfBE_1635_BillStatus 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_BillStatusID { get; set; } 
			[DataMember]
			public string Status_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict BillStatus_Name { get; set; } 
			[DataMember]
			public bool IsCurrentStatus { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GPDfBE_1635 cls_Get_PreloadingData_for_BillEdit(,P_L5BL_GPDfBE_1635 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GPDfBE_1635 invocationResult = cls_Get_PreloadingData_for_BillEdit.Invoke(connectionString,P_L5BL_GPDfBE_1635 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Atomic.Retrieval.P_L5BL_GPDfBE_1635();
parameter.BillHeaderID = ...;

*/
