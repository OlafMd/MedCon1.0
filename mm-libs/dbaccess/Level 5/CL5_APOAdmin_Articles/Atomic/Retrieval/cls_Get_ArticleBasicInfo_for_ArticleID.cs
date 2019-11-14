/* 
 * Generated on 6/24/2014 5:00:27 PM
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

namespace CL5_APOAdmin_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ArticleBasicInfo_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ArticleBasicInfo_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GABIfAID_0950 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GABIfAID_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_GABIfAID_0950();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Articles.Atomic.Retrieval.SQL.cls_Get_ArticleBasicInfo_for_ArticleID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ArticleID", Parameter.ArticleID);



			List<L5AR_GABIfAID_0950_raw> results = new List<L5AR_GABIfAID_0950_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Product_Description_DictID","Product_Number","DefaultStorageTemperature_max_in_kelvin","DefaultStorageTemperature_min_in_kelvin","ProducerName","DefaultExpirationPeriod_in_sec","ProductSuccessor_RefID","ProductCode_Value","ProductDosageForm_RefID","ApplicableSalesTax_RefID","ProductType_RefID","PackageContent_Amount","PackageContent_DisplayLabel","PackageContent_MeasuredInUnit_RefID","Product_Name_Successor","CMN_PRO_ProductGroup_RefID","DosageForm_Name_DictID","ProductITL","ISOCode","IsStorage_CoolingRequired","IsStorage_BatchNumberMandatory","IsStorage_ExpiryDateMandatory","IsProductPartOfDefaultStock","IsProduct_AddictiveDrug","ProductAdditionalInfoXML","IsPlaceholderArticle","CMN_PRO_ProductGroupID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5AR_GABIfAID_0950_raw resultItem = new L5AR_GABIfAID_0950_raw();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(2);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//3:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(3);
					//4:Parameter DefaultStorageTemperature_max_in_kelvin of type Double
					resultItem.DefaultStorageTemperature_max_in_kelvin = reader.GetDouble(4);
					//5:Parameter DefaultStorageTemperature_min_in_kelvin of type Double
					resultItem.DefaultStorageTemperature_min_in_kelvin = reader.GetDouble(5);
					//6:Parameter ProducerName of type String
					resultItem.ProducerName = reader.GetString(6);
					//7:Parameter DefaultExpirationPeriod_in_sec of type int
					resultItem.DefaultExpirationPeriod_in_sec = reader.GetInteger(7);
					//8:Parameter ProductSuccessor_RefID of type Guid
					resultItem.ProductSuccessor_RefID = reader.GetGuid(8);
					//9:Parameter ProductCode_Value of type String
					resultItem.ProductCode_Value = reader.GetString(9);
					//10:Parameter ProductDosageForm_RefID of type Guid
					resultItem.ProductDosageForm_RefID = reader.GetGuid(10);
					//11:Parameter ApplicableSalesTax_RefID of type Guid
					resultItem.ApplicableSalesTax_RefID = reader.GetGuid(11);
					//12:Parameter ProductType_RefID of type Guid
					resultItem.ProductType_RefID = reader.GetGuid(12);
					//13:Parameter PackageContent_Amount of type Double
					resultItem.PackageContent_Amount = reader.GetDouble(13);
					//14:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(14);
					//15:Parameter PackageContent_MeasuredInUnit_RefID of type Guid
					resultItem.PackageContent_MeasuredInUnit_RefID = reader.GetGuid(15);
					//16:Parameter Product_Name_Successor of type Dict
					resultItem.Product_Name_Successor = reader.GetDictionary(16);
					resultItem.Product_Name_Successor.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name_Successor);
					//17:Parameter CMN_PRO_ProductGroup_RefID of type Guid
					resultItem.CMN_PRO_ProductGroup_RefID = reader.GetGuid(17);
					//18:Parameter DosageForm_Name_DictID of type Dict
					resultItem.DosageForm_Name_DictID = reader.GetDictionary(18);
					resultItem.DosageForm_Name_DictID.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name_DictID);
					//19:Parameter ProductITL of type String
					resultItem.ProductITL = reader.GetString(19);
					//20:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(20);
					//21:Parameter IsStorage_CoolingRequired of type Boolean
					resultItem.IsStorage_CoolingRequired = reader.GetBoolean(21);
					//22:Parameter IsStorage_BatchNumberMandatory of type Boolean
					resultItem.IsStorage_BatchNumberMandatory = reader.GetBoolean(22);
					//23:Parameter IsStorage_ExpiryDateMandatory of type Boolean
					resultItem.IsStorage_ExpiryDateMandatory = reader.GetBoolean(23);
					//24:Parameter IsProductPartOfDefaultStock of type Boolean
					resultItem.IsProductPartOfDefaultStock = reader.GetBoolean(24);
					//25:Parameter IsProduct_AddictiveDrug of type Boolean
					resultItem.IsProduct_AddictiveDrug = reader.GetBoolean(25);
					//26:Parameter ProductAdditionalInfoXML of type String
					resultItem.ProductAdditionalInfoXML = reader.GetString(26);
					//27:Parameter IsPlaceholderArticle of type Boolean
					resultItem.IsPlaceholderArticle = reader.GetBoolean(27);
					//28:Parameter CMN_PRO_ProductGroupID of type Guid
					resultItem.CMN_PRO_ProductGroupID = reader.GetGuid(28);
					//29:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(29);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ArticleBasicInfo_for_ArticleID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AR_GABIfAID_0950_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AR_GABIfAID_0950 Invoke(string ConnectionString,P_L5AR_GABIfAID_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GABIfAID_0950 Invoke(DbConnection Connection,P_L5AR_GABIfAID_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GABIfAID_0950 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GABIfAID_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GABIfAID_0950 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GABIfAID_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GABIfAID_0950 functionReturn = new FR_L5AR_GABIfAID_0950();
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

				throw new Exception("Exception occured in method cls_Get_ArticleBasicInfo_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AR_GABIfAID_0950_raw 
	{
		public Guid CMN_PRO_ProductID; 
		public Dict Product_Name; 
		public Dict Product_Description; 
		public String Product_Number; 
		public Double DefaultStorageTemperature_max_in_kelvin; 
		public Double DefaultStorageTemperature_min_in_kelvin; 
		public String ProducerName; 
		public int DefaultExpirationPeriod_in_sec; 
		public Guid ProductSuccessor_RefID; 
		public String ProductCode_Value; 
		public Guid ProductDosageForm_RefID; 
		public Guid ApplicableSalesTax_RefID; 
		public Guid ProductType_RefID; 
		public Double PackageContent_Amount; 
		public String PackageContent_DisplayLabel; 
		public Guid PackageContent_MeasuredInUnit_RefID; 
		public Dict Product_Name_Successor; 
		public Guid CMN_PRO_ProductGroup_RefID; 
		public Dict DosageForm_Name_DictID; 
		public String ProductITL; 
		public String ISOCode; 
		public Boolean IsStorage_CoolingRequired; 
		public Boolean IsStorage_BatchNumberMandatory; 
		public Boolean IsStorage_ExpiryDateMandatory; 
		public Boolean IsProductPartOfDefaultStock; 
		public Boolean IsProduct_AddictiveDrug; 
		public String ProductAdditionalInfoXML; 
		public Boolean IsPlaceholderArticle; 
		public Guid CMN_PRO_ProductGroupID; 
		public String GlobalPropertyMatchingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AR_GABIfAID_0950[] Convert(List<L5AR_GABIfAID_0950_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AR_GABIfAID_0950 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L5AR_GABIfAID_0950 by new 
	{ 
		el_L5AR_GABIfAID_0950.CMN_PRO_ProductID,

	}
	into gfunct_L5AR_GABIfAID_0950
	select new L5AR_GABIfAID_0950
	{     
		CMN_PRO_ProductID = gfunct_L5AR_GABIfAID_0950.Key.CMN_PRO_ProductID ,
		Product_Name = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().Product_Name ,
		Product_Description = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().Product_Description ,
		Product_Number = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().Product_Number ,
		DefaultStorageTemperature_max_in_kelvin = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().DefaultStorageTemperature_max_in_kelvin ,
		DefaultStorageTemperature_min_in_kelvin = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().DefaultStorageTemperature_min_in_kelvin ,
		ProducerName = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ProducerName ,
		DefaultExpirationPeriod_in_sec = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().DefaultExpirationPeriod_in_sec ,
		ProductSuccessor_RefID = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ProductSuccessor_RefID ,
		ProductCode_Value = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ProductCode_Value ,
		ProductDosageForm_RefID = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ProductDosageForm_RefID ,
		ApplicableSalesTax_RefID = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ApplicableSalesTax_RefID ,
		ProductType_RefID = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ProductType_RefID ,
		PackageContent_Amount = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().PackageContent_Amount ,
		PackageContent_DisplayLabel = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().PackageContent_DisplayLabel ,
		PackageContent_MeasuredInUnit_RefID = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().PackageContent_MeasuredInUnit_RefID ,
		Product_Name_Successor = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().Product_Name_Successor ,
		CMN_PRO_ProductGroup_RefID = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().CMN_PRO_ProductGroup_RefID ,
		DosageForm_Name_DictID = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().DosageForm_Name_DictID ,
		ProductITL = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ProductITL ,
		ISOCode = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ISOCode ,
		IsStorage_CoolingRequired = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().IsStorage_CoolingRequired ,
		IsStorage_BatchNumberMandatory = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().IsStorage_BatchNumberMandatory ,
		IsStorage_ExpiryDateMandatory = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().IsStorage_ExpiryDateMandatory ,
		IsProductPartOfDefaultStock = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().IsProductPartOfDefaultStock ,
		IsProduct_AddictiveDrug = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().IsProduct_AddictiveDrug ,
		ProductAdditionalInfoXML = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().ProductAdditionalInfoXML ,
		IsPlaceholderArticle = gfunct_L5AR_GABIfAID_0950.FirstOrDefault().IsPlaceholderArticle ,

		ProductGroups = 
		(
			from el_ProductGroups in gfunct_L5AR_GABIfAID_0950.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductGroupID)).ToArray()
			group el_ProductGroups by new 
			{ 
				el_ProductGroups.CMN_PRO_ProductGroupID,

			}
			into gfunct_ProductGroups
			select new L5AR_GABIfAID_0950a
			{     
				CMN_PRO_ProductGroupID = gfunct_ProductGroups.Key.CMN_PRO_ProductGroupID ,
				GlobalPropertyMatchingID = gfunct_ProductGroups.FirstOrDefault().GlobalPropertyMatchingID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GABIfAID_0950 : FR_Base
	{
		public L5AR_GABIfAID_0950 Result	{ get; set; }

		public FR_L5AR_GABIfAID_0950() : base() {}

		public FR_L5AR_GABIfAID_0950(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GABIfAID_0950 for attribute P_L5AR_GABIfAID_0950
		[DataContract]
		public class P_L5AR_GABIfAID_0950 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 

		}
		#endregion
		#region SClass L5AR_GABIfAID_0950 for attribute L5AR_GABIfAID_0950
		[DataContract]
		public class L5AR_GABIfAID_0950 
		{
			[DataMember]
			public L5AR_GABIfAID_0950a[] ProductGroups { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Double DefaultStorageTemperature_max_in_kelvin { get; set; } 
			[DataMember]
			public Double DefaultStorageTemperature_min_in_kelvin { get; set; } 
			[DataMember]
			public String ProducerName { get; set; } 
			[DataMember]
			public int DefaultExpirationPeriod_in_sec { get; set; } 
			[DataMember]
			public Guid ProductSuccessor_RefID { get; set; } 
			[DataMember]
			public String ProductCode_Value { get; set; } 
			[DataMember]
			public Guid ProductDosageForm_RefID { get; set; } 
			[DataMember]
			public Guid ApplicableSalesTax_RefID { get; set; } 
			[DataMember]
			public Guid ProductType_RefID { get; set; } 
			[DataMember]
			public Double PackageContent_Amount { get; set; } 
			[DataMember]
			public String PackageContent_DisplayLabel { get; set; } 
			[DataMember]
			public Guid PackageContent_MeasuredInUnit_RefID { get; set; } 
			[DataMember]
			public Dict Product_Name_Successor { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductGroup_RefID { get; set; } 
			[DataMember]
			public Dict DosageForm_Name_DictID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public Boolean IsStorage_CoolingRequired { get; set; } 
			[DataMember]
			public Boolean IsStorage_BatchNumberMandatory { get; set; } 
			[DataMember]
			public Boolean IsStorage_ExpiryDateMandatory { get; set; } 
			[DataMember]
			public Boolean IsProductPartOfDefaultStock { get; set; } 
			[DataMember]
			public Boolean IsProduct_AddictiveDrug { get; set; } 
			[DataMember]
			public String ProductAdditionalInfoXML { get; set; } 
			[DataMember]
			public Boolean IsPlaceholderArticle { get; set; } 

		}
		#endregion
		#region SClass L5AR_GABIfAID_0950a for attribute ProductGroups
		[DataContract]
		public class L5AR_GABIfAID_0950a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductGroupID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GABIfAID_0950 cls_Get_ArticleBasicInfo_for_ArticleID(,P_L5AR_GABIfAID_0950 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GABIfAID_0950 invocationResult = cls_Get_ArticleBasicInfo_for_ArticleID.Invoke(connectionString,P_L5AR_GABIfAID_0950 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Retrieval.P_L5AR_GABIfAID_0950();
parameter.ArticleID = ...;

*/
