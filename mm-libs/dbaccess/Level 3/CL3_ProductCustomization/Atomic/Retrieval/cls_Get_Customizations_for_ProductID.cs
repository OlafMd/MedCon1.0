/* 
 * Generated on 2/12/2015 16:10:53
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

namespace CL3_ProductCustomization.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Customizations_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Customizations_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PC_GCfP_1628_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PC_GCfP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PC_GCfP_1628_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ProductCustomization.Atomic.Retrieval.SQL.cls_Get_Customizations_for_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L3PC_GCfP_1628_raw> results = new List<L3PC_GCfP_1628_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_CUS_CustomizationID","InstantiatedFrom_CustomizationTemplate_RefID","Product_RefID","Customization_Name_DictID","Customization_Description_DictID","OrderSequence","CMN_PRO_CUS_Customization_VariantID","CustomizationVariant_Name_DictID","VariantOrderSequence" });
				while(reader.Read())
				{
					L3PC_GCfP_1628_raw resultItem = new L3PC_GCfP_1628_raw();
					//0:Parameter CMN_PRO_CUS_CustomizationID of type Guid
					resultItem.CMN_PRO_CUS_CustomizationID = reader.GetGuid(0);
					//1:Parameter InstantiatedFrom_CustomizationTemplate_RefID of type Guid
					resultItem.InstantiatedFrom_CustomizationTemplate_RefID = reader.GetGuid(1);
					//2:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(2);
					//3:Parameter Customization_Name_DictID of type Dict
					resultItem.Customization_Name_DictID = reader.GetDictionary(3);
					resultItem.Customization_Name_DictID.SourceTable = "cmn_pro_cus_customizations";
					loader.Append(resultItem.Customization_Name_DictID);
					//4:Parameter Customization_Description_DictID of type Dict
					resultItem.Customization_Description_DictID = reader.GetDictionary(4);
					resultItem.Customization_Description_DictID.SourceTable = "cmn_pro_cus_customizations";
					loader.Append(resultItem.Customization_Description_DictID);
					//5:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(5);
					//6:Parameter CMN_PRO_CUS_Customization_VariantID of type Guid
					resultItem.CMN_PRO_CUS_Customization_VariantID = reader.GetGuid(6);
					//7:Parameter CustomizationVariant_Name of type Dict
					resultItem.CustomizationVariant_Name = reader.GetDictionary(7);
					resultItem.CustomizationVariant_Name.SourceTable = "cmn_pro_cus_customization_variants";
					loader.Append(resultItem.CustomizationVariant_Name);
					//8:Parameter VariantOrderSequence of type int
					resultItem.VariantOrderSequence = reader.GetInteger(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Customizations_for_ProductID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3PC_GCfP_1628_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PC_GCfP_1628_Array Invoke(string ConnectionString,P_L3PC_GCfP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PC_GCfP_1628_Array Invoke(DbConnection Connection,P_L3PC_GCfP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PC_GCfP_1628_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PC_GCfP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PC_GCfP_1628_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PC_GCfP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PC_GCfP_1628_Array functionReturn = new FR_L3PC_GCfP_1628_Array();
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

				throw new Exception("Exception occured in method cls_Get_Customizations_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3PC_GCfP_1628_raw 
	{
		public Guid CMN_PRO_CUS_CustomizationID; 
		public Guid InstantiatedFrom_CustomizationTemplate_RefID; 
		public Guid Product_RefID; 
		public Dict Customization_Name_DictID; 
		public Dict Customization_Description_DictID; 
		public int OrderSequence; 
		public Guid CMN_PRO_CUS_Customization_VariantID; 
		public Dict CustomizationVariant_Name; 
		public int VariantOrderSequence; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3PC_GCfP_1628[] Convert(List<L3PC_GCfP_1628_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3PC_GCfP_1628 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_CUS_CustomizationID)).ToArray()
	group el_L3PC_GCfP_1628 by new 
	{ 
		el_L3PC_GCfP_1628.CMN_PRO_CUS_CustomizationID,

	}
	into gfunct_L3PC_GCfP_1628
	select new L3PC_GCfP_1628
	{     
		CMN_PRO_CUS_CustomizationID = gfunct_L3PC_GCfP_1628.Key.CMN_PRO_CUS_CustomizationID ,
		InstantiatedFrom_CustomizationTemplate_RefID = gfunct_L3PC_GCfP_1628.FirstOrDefault().InstantiatedFrom_CustomizationTemplate_RefID ,
		Product_RefID = gfunct_L3PC_GCfP_1628.FirstOrDefault().Product_RefID ,
		Customization_Name_DictID = gfunct_L3PC_GCfP_1628.FirstOrDefault().Customization_Name_DictID ,
		Customization_Description_DictID = gfunct_L3PC_GCfP_1628.FirstOrDefault().Customization_Description_DictID ,
		OrderSequence = gfunct_L3PC_GCfP_1628.FirstOrDefault().OrderSequence ,

		Variants = 
		(
			from el_Variants in gfunct_L3PC_GCfP_1628.Where(element => !EqualsDefaultValue(element.CMN_PRO_CUS_Customization_VariantID)).ToArray()
			group el_Variants by new 
			{ 
				el_Variants.CMN_PRO_CUS_Customization_VariantID,

			}
			into gfunct_Variants
			select new L3PC_GCfP_1628a
			{     
				CMN_PRO_CUS_Customization_VariantID = gfunct_Variants.Key.CMN_PRO_CUS_Customization_VariantID ,
				CustomizationVariant_Name = gfunct_Variants.FirstOrDefault().CustomizationVariant_Name ,
				VariantOrderSequence = gfunct_Variants.FirstOrDefault().VariantOrderSequence ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3PC_GCfP_1628_Array : FR_Base
	{
		public L3PC_GCfP_1628[] Result	{ get; set; } 
		public FR_L3PC_GCfP_1628_Array() : base() {}

		public FR_L3PC_GCfP_1628_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PC_GCfP_1628 for attribute P_L3PC_GCfP_1628
		[DataContract]
		public class P_L3PC_GCfP_1628 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L3PC_GCfP_1628 for attribute L3PC_GCfP_1628
		[DataContract]
		public class L3PC_GCfP_1628 
		{
			[DataMember]
			public L3PC_GCfP_1628a[] Variants { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CUS_CustomizationID { get; set; } 
			[DataMember]
			public Guid InstantiatedFrom_CustomizationTemplate_RefID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Dict Customization_Name_DictID { get; set; } 
			[DataMember]
			public Dict Customization_Description_DictID { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 

		}
		#endregion
		#region SClass L3PC_GCfP_1628a for attribute Variants
		[DataContract]
		public class L3PC_GCfP_1628a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CUS_Customization_VariantID { get; set; } 
			[DataMember]
			public Dict CustomizationVariant_Name { get; set; } 
			[DataMember]
			public int VariantOrderSequence { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PC_GCfP_1628_Array cls_Get_Customizations_for_ProductID(,P_L3PC_GCfP_1628 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PC_GCfP_1628_Array invocationResult = cls_Get_Customizations_for_ProductID.Invoke(connectionString,P_L3PC_GCfP_1628 Parameter,securityTicket);
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
var parameter = new CL3_ProductCustomization.Atomic.Retrieval.P_L3PC_GCfP_1628();
parameter.ProductID = ...;

*/
